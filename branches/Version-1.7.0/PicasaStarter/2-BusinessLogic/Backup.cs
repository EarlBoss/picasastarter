
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;            // Necessary for BackgroundWorker...
using Logger;                           // Static logging class
using HelperClasses;                    // Necessary for creating Hardlinks

namespace BackupNS
{
    /// <summary>
    /// Backup Class
    ///     Backup a list of directories (and all directories and files in them) to a specified backup location.
    ///     
    ///     The only backup strategy supported is a full backup with SIS (single instance storage) based on the previous backup and hardlinks.
    /// </summary>
    public class Backup
    {
        #region Public Events

        // Delegate declarations.
        public delegate void BackupProgressEventHandler(object sender, ProgressEventParams e);

        // Delegate declarations.
        public delegate void BackupCompletedEventHandler(object sender, CompletedEventParams e);
        
        /// <summary>
        ///  ProgressEventParams:   Defines a  progress event. Used for displaying file backup progress.
        /// </summary>
        public class ProgressEventParams : EventArgs
        {
            public readonly string CurDirToBackup;      // The directory that is being backed up now
            public readonly string CurFileNameToBackup; // The file that is being backed up now...
            public readonly int NbFiles;                // The number of files in the dir being backed up now
            public readonly int NbFilesDoneChanged;     // The nb of files done, that changed since the last backup 
            public readonly int NbFilesDoneUnchanged;   // The nb of files done, that didn't change since the last backup 
            public readonly long NbMBDoneChanged;       // The nb of MegaBytes done, that didn't change since the last backup 
            public readonly long NbMBDoneUnchanged;     // The nb of MegaBytes done, that didn't change since the last backup 
            
            public ProgressEventParams(string curDirToBackup, string curFileNameToBackup,
                    int nbFiles, 
                    int nbFilesDoneChanged, int nbFilesDoneUnchanged, 
                    long nbMBDoneChanged, long nbMBDoneUnchanged)
            {    
                this.CurDirToBackup = curDirToBackup;
                this.CurFileNameToBackup = curFileNameToBackup;
                this.NbFiles = nbFiles;
                this.NbFilesDoneChanged = nbFilesDoneChanged;
                this.NbFilesDoneUnchanged = nbFilesDoneUnchanged;
                this.NbMBDoneChanged = nbMBDoneChanged;
                this.NbMBDoneUnchanged = nbMBDoneUnchanged;
            }
        }

        public class CompletedEventParams : EventArgs
        {
            public bool Success = false;
            public bool Cancelled = false;
            public Exception Error = null;
        }

        // The protected OnProgressEvent method raises the event by invoking
        // the delegate. The sender is always this: the current instance 
        // of the class.
        protected virtual void OnProgressEvent(ProgressEventParams e)
        {
            if (ProgressEvent != null)
            {
                // Invokes the delegate. 
                ProgressEvent(this, e);
            }
        }

        // The protected OnCompletedEvent method raises the event by invoking
        // the delegate. The sender is always this: the current instance 
        // of the class.
        protected virtual void OnCompletedEvent(CompletedEventParams e)
        {
            if (CompletedEvent != null)
            {
                // Invokes the delegate. 
                CompletedEvent(this, e);
            }
        }

        #endregion

        #region Private classes

        private class DirectoryWithFiles
        {
            private DirectoryInfo _dir;
            private FileInfo[] _files;

            public DirectoryInfo Dir
            {
                get { return _dir; }
                set { _dir = value; }
            }
            public FileInfo[] Files
            {
                get { return _files; }
                set { _files = value; }
            }

            public DirectoryWithFiles(DirectoryInfo dir, FileInfo[] files)
            {
                _dir = dir;
                _files = files;
            }
        }

        #endregion

        #region Private Members

        private BackupStrategy _strategy = BackupStrategy.SISRotating;
        private string _destinationDir = "";
        private List<string> _dirsToBackup = new List<string>();
        private List<string> _dirsToExclude = new List<string>();

        private Boolean _onlySimulate = false;      // If true, the backup isn't actualy created, only the logging is written...
        private string _dirPrevBackup = "";
        private string _dirToBackupTo = "";
        private int _maxNbBackups = 100;

        private BackgroundWorker _bw = null;
        private bool _backupCancelled = false;
        

        #endregion

        #region Constructors

        /// <summary>
        ///  Constructor
        /// </summary>
        public Backup()
        {
        }

        #endregion Constructors

        #region Public Enums

        /// <summary>
        /// The strategy to use for the backups.
        /// </summary>
        public enum BackupStrategy
        {
            /// <summary>
            /// Create a new backup directory every time, with all files in it, but files that didn't 
            /// change don't take any diskspace (=Single Instance Store or deduplication).
            /// 
            /// Remark: only supported on NTFS filesystems not located on a network drive.
            /// </summary>
            SISRotating = 0,
            /// <summary>
            /// Create a new backup directory every time, with only changed or new files put in the new backup.
            /// </summary>
            Incremental = 1,
            /// <summary>
            /// Create a full backup every time (takes most diskspace).
            /// </summary>
            FullRotating = 2,
            /// <summary>
            /// Mirror the data to the backup location.
            /// </summary>
            Mirror = 3
        }

        #endregion Public Enums

        #region Public Properties

        public BackupStrategy Strategy
        { 
            get { return _strategy; } 
            set { _strategy = value; } 
        }
        public List<string> DirsToBackup
        {
            get { return _dirsToBackup; }
            set { _dirsToBackup = value; }
        }
        public List<string> DirsToExclude
        {
            get { return _dirsToExclude; }
            set { _dirsToExclude = value; }
        }
        public string DestinationDir
        {
            get { return _destinationDir; }
            set { _destinationDir = value; }
        }
        public int MaxNbBackups
        {
            get { return _maxNbBackups; }
            set { _maxNbBackups = value; }
        }
        
        public Boolean OnlySimulate
        {
            get { return _onlySimulate; }
            set { _onlySimulate = value; }
        }
        #endregion

        #region Public Events

        public event BackupProgressEventHandler ProgressEvent;
        public event BackupCompletedEventHandler CompletedEvent;
        
        #endregion

        #region Public Methods

        /// <summary>
        /// This method checks if a certain direcory qualifies to write backups to. 
        /// 
        /// The directory should be writable and it should support the creation of hardlinks.
        /// </summary>
        /// <param name="DirToBackupTo">Directory where the backup should be written to.</param>
        /// <returns>True if location is OK, throws Exception when the location is not OK.</returns>
        public bool IsBackupLocationOK(DirectoryInfo DirToBackupTo)
        {
            string fileNameTest = DirToBackupTo.FullName + '\\' + "testFile.txt";
            string fileNameTestHardLink = DirToBackupTo.FullName + '\\' + "testFileHardLink.txt";
            
            try
            {
                FileInfo fileTest = new FileInfo(fileNameTest);
                FileInfo fileTestHardLink = new FileInfo(fileNameTestHardLink);

                // Delete them first to be sure...
                if (fileTestHardLink.Exists)
                    fileTestHardLink.Delete();
                if(fileTest.Exists)
                    fileTest.Delete();

                File.WriteAllText(fileNameTest, "Test");
                IOHelper.CreateHardLink(fileTestHardLink.FullName, fileTest.FullName);

                // Delete test files...
                fileTest = new FileInfo(fileNameTest);
                fileTestHardLink = new FileInfo(fileNameTestHardLink);

                if (fileTestHardLink.Exists)
                    fileTestHardLink.Delete();
                if (fileTest.Exists)
                    fileTest.Delete();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw;
            }
            return true;
        }

        /// <summary>
        /// Start the backup assynchronous. You can follow progress using the appropriate events...
        /// </summary>
        public void StartBackupAssync()
        {
            // If there is still a backup busy, return!
            if (_bw != null)
                return;

            // Initialize the backgroundworker...
            _bw = new BackgroundWorker();
            _bw.WorkerReportsProgress = true;
            _bw.WorkerSupportsCancellation = true;

            // Initialise the cancelled flag to false...
            _backupCancelled = false;

            // Register event handlers to follow progress of the background thread...
            _bw.DoWork += bw_DoWork;
            _bw.ProgressChanged += bw_ProgressChanged;
            _bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            // Go!
            _bw.RunWorkerAsync();
        }

        /// <summary>
        /// Cancels the running backup... but only possible if the backup was started assync!
        /// </summary>
        public void CancelBackupAssync()
        {
            if (_bw == null)
                return;

            if (_bw.IsBusy)
            {
                _bw.CancelAsync();
                _backupCancelled = true;
            }
        }

        /// <summary>
        /// Starts the backup.
        /// </summary>
        /// <remarks> This function can raise exceptions </remarks>
        public void StartBackup()
        {
            long startTicks, finishTicks, seconds, minutes = 0;

            // Timestamp for the start of the backup.
            startTicks = DateTime.Now.Ticks;

            Log.Info("Start backup, using this strategy: " + Strategy);

            // Check if the destination directory for the backup is OK.
            IsBackupLocationOK(new DirectoryInfo(DestinationDir));

            _dirPrevBackup = GetPreviousBackupDir();
            _dirToBackupTo = GetNewBackupDir();

            BackupDirs(DirsToBackup.ToArray(), DirsToExclude.ToArray());

            // Timestamp for end of backup.
            finishTicks = DateTime.Now.Ticks;

            // Calculate the number of backup seconds 
            seconds = (finishTicks - startTicks) / 10000000;

            if (seconds < 60)
                Log.Info("Backup run time: " + seconds.ToString() + " seconds");
            else
            {
                minutes = seconds / 60;
                long spareseconds = seconds % 60;
                Log.Info("Backup run time: " + minutes.ToString() + " minutes, " +
                        spareseconds.ToString() + " seconds");
            }
        }

        #endregion 

        #region Private event handlers for backgroundworker

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            StartBackup();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CompletedEventParams completed = new CompletedEventParams();
            if (_backupCancelled == true)
                completed.Cancelled = true;
            else if (e.Error != null)
                completed.Error = e.Error;
            else
                completed.Success = true;

            OnCompletedEvent(completed);
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnProgressEvent((ProgressEventParams)e.UserState);
        }

        #endregion

        #region Private methods: Backup logic

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dirsToBackup"></param>
        /// <param name="dirsToExclude"></param>
        private void BackupDirs(string[] dirsToBackup, string[] dirsToExclude)
        {
            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
            List<DirectoryInfo> dirsExcl = new List<DirectoryInfo>();

            foreach (string dir in dirsToBackup)
            {
                try
                {
                    dirs.Add(new DirectoryInfo(dir));
                }
                catch (Exception ex)
                {
                    Log.Error("Directory to backup <" + dir + "> gives error: " + ex.Message);
                }
            }
            foreach (string dir in dirsToExclude)
            {
                try
                {
                    dirsExcl.Add(new DirectoryInfo(dir));
                }
                catch (Exception ex)
                {
                    Log.Error("Directory to exclude <" + dir + "> gives error: " + ex.Message);
                }
            }

            BackupDirs(dirs.ToArray(), dirsExcl.ToArray());
        }
        
        /// <summary>
        /// Backup a directory recursively.
        /// </summary>
        /// <param name="dirsToBackup"> Full path to the dir to backuped (recursively) </param>
        /// <param name="dirsToExclude"> Full path to the dir to backuped (recursively) </param>
        private void BackupDirs(DirectoryInfo[] dirsToBackup, DirectoryInfo[] dirsToExclude)
        {
            // First cleanup excess backups...
            CleanupBackupLocation();

            // Get list of all files...
            DirectoryWithFiles[] dirsAndFiles = null;
            Log.Info("Start getting dirs and files");
           
            try
            {
                dirsAndFiles = GetDirectoriesWithFiles(dirsToBackup, dirsToExclude);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return;
            }

            Log.Info("Stop getting dirs and files");
           
            FileInfo curFileToBackup = null;
            string curDirToBackup = null;

            ProgressEventParams pE;
            Boolean fileChanged = false;
            int nbFilesDoneChanged = 0;
            int nbFilesDoneUnchanged = 0;
            long nbMBDoneChanged = 0;
            long nbMBDoneUnchanged = 0;

            int nbDirs = dirsAndFiles.Length;

            // Count the total number of files to backup...
            int totalNbFiles = 0;
            for (int i = 0; i <= (nbDirs - 1); i++)
            {
                totalNbFiles += dirsAndFiles[i].Files.Length;
            }

            Log.Info("Stop counting files");

            // Take the necessary actions directory per directory...
            for (int i = 0; i <= (nbDirs - 1); i++)
            {
                int nbFiles = dirsAndFiles[i].Files.Length;
                curDirToBackup = dirsAndFiles[i].Dir.FullName;

                // Prepare the dir where to put the file inside the backup directory
                string curDirTmp = '\\' + System.Environment.MachineName + "_Drive-" + curDirToBackup.Replace(":", "");
                string curDirToBackupTo = _dirToBackupTo + curDirTmp;
                string prevDirBackedupTo = _dirPrevBackup + curDirTmp;

                // If not simulating the backup, create the directory if it doesn't exist...
                if (OnlySimulate != true)
                    Directory.CreateDirectory(curDirToBackupTo);

                // Take the necessary actions file per file...           
                for (int j = 0; j <= (nbFiles - 1); j++)
                {
                    if (_bw != null && _bw.CancellationPending) 
                    { 
                        Log.Info("Backup cancelled... delete partial backup...");
                        try
                        {
                            Directory.Delete(_dirToBackupTo, true);
                            Log.Info("Partial backup deleted");
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex.Message);
                        }
                        
                        return; 
                    }
                    
                    // The file to be backed up...
                    string curFileNameToBackup = dirsAndFiles[i].Files[j].Name;
                    curFileToBackup = new FileInfo(curDirToBackup + '\\' + curFileNameToBackup);
                    // Where does the backup need to be put?
                    FileInfo CurFileToBackupTo = new FileInfo(curDirToBackupTo + '\\' + curFileNameToBackup);
                    // Where is the previous backup of the file standing, if it exists...
                    FileInfo PrevFileBackedupTo = new FileInfo(prevDirBackedupTo + '\\' + curFileNameToBackup);

                    fileChanged = BackupFile(curFileToBackup, CurFileToBackupTo, PrevFileBackedupTo);

                    // Change the counters for the progress reporting...
                    if (fileChanged == true)
                    {
                        nbFilesDoneChanged++;
                        nbMBDoneChanged += curFileToBackup.Length;
                    }
                    else
                    {
                        nbFilesDoneUnchanged++;
                        nbMBDoneUnchanged += curFileToBackup.Length;
                    }

                    pE = new ProgressEventParams(curDirToBackup, curFileNameToBackup, totalNbFiles, nbFilesDoneChanged, 
                            nbFilesDoneUnchanged, nbMBDoneChanged, nbMBDoneUnchanged);
                    
                    // If running assynchronously, report via backgroundworker object...
                    if(_bw != null)
                        _bw.ReportProgress(0, pE);
                    else
                        OnProgressEvent(pE);
                }
            }

            // If there aren't any files that were changed... better delete the backup.
            if (nbFilesDoneChanged == 0)
            {
                Log.Info("There were no files changed in backup... so better to delete it again...");

                pE = new ProgressEventParams("- Cancelling backup as there were no changed files...", 
                        "", totalNbFiles, nbFilesDoneChanged,
                        nbFilesDoneUnchanged, nbMBDoneChanged, nbMBDoneUnchanged);

                // If running assynchronously, report via backgroundworker object...
                if (_bw != null)
                    _bw.ReportProgress(0, pE);
                else
                    OnProgressEvent(pE);

                try
                {
                    Directory.Delete(_dirToBackupTo, true);
                    Log.Info("Partial backup deleted");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }
            }       
        }

        /// <summary>
        /// Cleans up the backup destination directories...
        /// </summary>
        /// <param name="MaxNbBackups"></param>
        private void CleanupBackupLocation()
        {
            // Get the list of existing backup directories...
            string[] dirArray = Directory.GetDirectories(DestinationDir, "Backup*", SearchOption.TopDirectoryOnly);

            // Check if there are too many backups at the moment...
            int iNbToDelete = dirArray.Length - MaxNbBackups;
            if (iNbToDelete <= 0)
                return;

            // Sort the backups alphabetically (the oldest will be first due to the naming convention used).
            List<string> dirList = new List<string>(dirArray);
            dirList.Sort();

            // Loop over all dirs in the list and remove the oldest till the number equals the maximum...
            for (int i = 0; i < iNbToDelete; i++)
            {
                Directory.Delete(dirList[i], true);
            }
        }

        /// <summary>
        /// Backup a file, using the SIS principle: if the file exists already in the previous backup, 
        /// create a hardlink instead of making another copy.
        /// </summary>
        /// <param name="fileToBackup"> Full path to the file to backuped </param>
        /// <param name="fileToBackupTo"> Base directory to backup to </param>
        /// <param name="BaseDirPrevBackup"> Base directory of the previous backup </param>
        /// <returns> true if the file was actualy copied, false if the file didn't change since a previous backup </returns>
        private Boolean BackupFile(FileInfo fileToBackup, FileInfo fileToBackupTo, FileInfo prevBackupFile)
        {
            Boolean fileChanged = false;
            
            try
            {
                // Check if the file was backed up in the previous backup and wasn't changed afterwards, 
                // to create a hardlink rather then copying the file again.
                if (prevBackupFile.Exists && IOHelper.Compare(prevBackupFile, fileToBackup, false))
                {                    
                    fileChanged = false;

                    if (OnlySimulate != true)
                        IOHelper.CreateHardLink(fileToBackupTo.FullName, prevBackupFile.FullName);
                    Log.Debug("HARDLINK " + fileToBackupTo.FullName + " TO " + prevBackupFile + " (= previous backup");
                }
                else
                {
                    fileChanged = true;

                    if (OnlySimulate != true)
                        File.Copy(fileToBackup.FullName, fileToBackupTo.FullName);
                    Log.Debug("COPY " + fileToBackup + " TO " + fileToBackupTo.FullName);
                }
            }
            catch (Exception ex)
            {
                Log.Error(fileToBackup + " TO " + fileToBackupTo.FullName + ": " + ex.Message);
            }

            return fileChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseDirs"></param>
        /// <param name="dirsToExclude"></param>
        /// <returns></returns>
        private DirectoryWithFiles[] GetDirectoriesWithFiles(DirectoryInfo[] baseDirs, DirectoryInfo[] dirsToExclude)
        {
            List<DirectoryWithFiles> dirList = new List<DirectoryWithFiles>();

            foreach (DirectoryInfo dir in baseDirs)
            {
                bool exclude = false; 
                foreach (DirectoryInfo dirToExclude in dirsToExclude)
                {
                    if (dir == dirToExclude)
                        exclude = true;
                }
                if (exclude == true)
                    continue;

                try
                {
                    FileInfo[] files = dir.GetFiles();
                    
                    if (files.Length > 0)
                        dirList.Add(new DirectoryWithFiles(dir, files));

                    DirectoryInfo[] dirs = dir.GetDirectories();
                    if (dirs.Length > 0)
                        dirList.AddRange(GetDirectoriesWithFiles(dirs, dirsToExclude));
                }
                catch (Exception ex)
                {
                    Log.Error(dir + ": " + ex.Message);
                }
            }

            return (dirList.ToArray());
        }

        /// <summary>
        /// This function searches in the source directory for the last previous backup.
        /// </summary>
        /// <param name="BasePath"> The path to look for a previous backup </param>
        /// <returns> The directory path of the previous backup </returns>
        /// <remarks></remarks>
        private string GetPreviousBackupDir()
        {
            string returnPath = "";

            try
            {
                // Get list of all dirs in the backup destination dir...
                string[] dirList = Directory.GetDirectories(DestinationDir, "Backup*", SearchOption.TopDirectoryOnly);

                // Loop over all dirs in the list and keep the "Largest" -> is the latest backup 
                // because of the way the directory name is created
                foreach (string Dir in dirList)
                {
                    if (string.Compare(Dir, returnPath) > 0)
                    {
                        returnPath = Dir;
                    }
                }
            }
            catch (Exception ex)
            {
                // There are apparently no previous backup dirs...
                Log.Warn("There are no previous backups found, exception: " + ex.Message);
            }

            return returnPath;
        }

        /// <summary>
        /// Make a new, unique backup directory to put the new backup in, with the following format:
        /// [BasePath]\Backup_[YYYY-MM-DD]_[III]
        /// </summary>
        /// <param name="BasePath"> The base path where the backups are put </param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string GetNewBackupDir()
        {
            string destDirName = "Backup_" + System.DateTime.Now.ToString("yyyy-MM-dd");
            string fullDestDir = DestinationDir + '\\' + destDirName;

            try
            {
                // Get list of all dirs in the backup destination dir from the same day...
                string[] dirList = Directory.GetDirectories(DestinationDir, destDirName + "*", SearchOption.TopDirectoryOnly);

                // No backups today yet... so just the normal fullDestDir will do...
                if (dirList.Length == 0)
                {
                    Directory.CreateDirectory(fullDestDir);
                    return fullDestDir;
                }

                // Otherwise we'll need to make the file name unique...
                // First find the directory that is alphabetically "Largest" -> this is the most recent backup today
                string largestDir = "";
                foreach (string dir in dirList)
                {
                    if (string.Compare(dir, largestDir) > 0)
                    {
                        largestDir = dir;
                    }
                }

                // If the largest dir equals the basic dir name... the index to add is just 1
                int indexToAdd = 0;
                if (largestDir == fullDestDir)
                    indexToAdd = 1;
                else
                {
                    string indexTmp = largestDir.Substring(largestDir.LastIndexOf('_') + 1);
                    indexToAdd = int.Parse(indexTmp) + 1;
                }

                fullDestDir = DestinationDir + '\\' + destDirName + "_" + indexToAdd.ToString("D3");
                Directory.CreateDirectory(fullDestDir);
                return fullDestDir;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex.Message);
                throw;
            }
        }

        #endregion 
    }
}