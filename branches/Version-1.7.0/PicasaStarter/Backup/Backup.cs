/*
 * 
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;            // Necessary for BackgroundWorker...
using System.Runtime.InteropServices;   // Necessary for creating Hardlinks
using Logger;                           // Static logging class

namespace BackupNS
{
    /// <summary>
    /// Backup Class
    ///     Backup files and/or entire directory trees to a specified backup location.
    ///     
    ///     Different backup strategies are supported.
    /// </summary>
    public class Backup
    {
        #region Events

        // Delegate declarations.
        public delegate void BackupProgressEventHandler(object sender, ProgressEventParams e);

        // Delegate declarations.
        public delegate void BackupCompletedEventHandler(object sender, CompletedEventParams e);
        
        /// <summary>
        ///  ProgressEventParams:   Defines a  progress event. Used for displaying file backup progress.
        /// </summary>
        public class ProgressEventParams : EventArgs
        {
            private readonly string _CurDirToBackup;     // The directory that is being backed up now
            private readonly int _NbFiles;               // The number of files in the dir being backed up now
            private readonly int _NbFilesDoneChanged;    // The nb of files done, that changed since the last backup 
            private readonly int _NbFilesDoneUnChanged;  // The nb of files done, that didn't change since the last backup 
            private readonly string _CurFileToBackup;    // The file that is next to be backed up...

            #region Constructor
            public ProgressEventParams(string CurDirToBackup, int NbFiles, int NbFilesDoneChanged, int NbFilesDoneUnChanged, 
                    string CurFileToBackup)
            {
                this._CurDirToBackup = CurDirToBackup;
                this._NbFiles = NbFiles;
                this._NbFilesDoneChanged = NbFilesDoneChanged;
                this._NbFilesDoneUnChanged = NbFilesDoneUnChanged;
                this._CurFileToBackup = CurFileToBackup;
            }
            #endregion

            #region Public Properties
            public string CurDirToBackup
            {
                get { return _CurDirToBackup; }
            }
            public int NbFiles
            {
                get { return _NbFiles; }
            }
            public int NbFilesDoneChanged
            {
                get { return _NbFilesDoneChanged; }
            }
            public int NbFilesDoneUnChanged
            {
                get { return _NbFilesDoneUnChanged; }
            }
            public string CurFileToBackup
            {
                get { return _CurFileToBackup; }
            }

            #endregion
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
        /// Start the backup assynchronous. You can follow progress using the appropriate events...
        /// </summary>
        public void StartBackupAssync()
        {
            // If there is still a backup busy, return!
            if (_bw != null)
            {
                return;
            }

            _bw = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

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

            // For these types of backup it is necessary to check if a file exists already in the previous backup
            if (Strategy == BackupStrategy.Incremental 
                    || Strategy == BackupStrategy.SISRotating)
                _dirPrevBackup = GetPreviousBackupDir();

            // For these backup strategies we need a new, unique backup directory in the base backup directory
            if (Strategy == BackupStrategy.Incremental
                    || Strategy == BackupStrategy.SISRotating
                    || Strategy == BackupStrategy.FullRotating)
                _dirToBackupTo = GetNewBackupDir();
            else
                _dirToBackupTo = DestinationDir;

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

        #endregion Public methods

        #region Protected Methods

        protected void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            StartBackup();
        }

        protected void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        protected void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnProgressEvent((ProgressEventParams)e.UserState);
        }

        #endregion

        #region Private methods: Backup

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
            // Get list of all files...
            DirectoryWithFiles[] DirsAndFiles = null;
            Log.Info("Start getting dirs and files");
           
            try
            {
                DirsAndFiles = GetDirectoriesWithFiles(dirsToBackup, dirsToExclude);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return;
            }

            Log.Info("Stop getting dirs and files");
           
            FileInfo CurFileToBackup = null;
            string CurDirToBackup = null;

            ProgressEventParams pE;
            Boolean FileChanged = false;
            int NbFilesChanged = 0;
            int NbFilesNotChanged = 0;
            int NbDirs = DirsAndFiles.Length;

            // Count the total number of files to backup...
            int TotalNbFiles = 0;
            for (int i = 0; i <= (NbDirs - 1); i++)
            {
                TotalNbFiles += DirsAndFiles[i].Files.Length;
            }

            Log.Info("Stop counting files");

            // Take the necessary actions directory per directory...
            for (int i = 0; i <= (NbDirs - 1); i++)
            {
                int NbFiles = DirsAndFiles[i].Files.Length;
                CurDirToBackup = DirsAndFiles[i].Dir.FullName;

                // Prepare the dir where to put the file inside the backup directory
                string CurDirTmp = '\\' + System.Environment.MachineName + "_Drive-" + CurDirToBackup.Replace(":", "");
                string CurDirToBackupTo = _dirToBackupTo + CurDirTmp;
                string PrevDirBackedupTo = _dirPrevBackup + CurDirTmp;

                // If not simulating the backup, create the directory if it doesn't exist...
                if (OnlySimulate != true)
                    Directory.CreateDirectory(CurDirToBackupTo);

                // Take the necessary actions file per file...           
                for (int j = 0; j <= (NbFiles - 1); j++)
                {
                    if (_bw != null && _bw.CancellationPending) 
                    { 
//                        e.Cancel = true; 
                        Log.Info("Backup cancelled...");
                        return; 
                    }
                    
                    // The file to be backed up...
                    string CurFileNameToBackup = DirsAndFiles[i].Files[j].Name;
                    CurFileToBackup = new FileInfo(CurDirToBackup + '\\' + CurFileNameToBackup);
                    // Where does the backup need to be put?
                    FileInfo CurFileToBackupTo = new FileInfo(CurDirToBackupTo + '\\' + CurFileNameToBackup);
                    // Where is the previous backup of the file standing, if it exists...
                    FileInfo PrevFileBackedupTo = new FileInfo(PrevDirBackedupTo + '\\' + CurFileNameToBackup);

                    FileChanged = BackupFile(CurFileToBackup, CurFileToBackupTo, PrevFileBackedupTo);

                    // Change the counters for the progress reporting...
                    if (FileChanged == true)
                        NbFilesChanged++;
                    else
                        NbFilesNotChanged++;

                    pE = new ProgressEventParams(CurDirToBackup, TotalNbFiles, NbFilesChanged, NbFilesNotChanged, CurFileNameToBackup);
                    
                    // If running assynchronously, report via backgroundworker object...
                    if(_bw != null)
                        _bw.ReportProgress(i, pE);
                    else
                        OnProgressEvent(pE);
                }
            }
        }

        /// <summary>
        /// Backup a file, using the SIS principle: if the file exists already in the previous backup, 
        /// create a hardlink instead of making another copy.
        /// </summary>
        /// <param name="FileToBackup"> Full path to the file to backuped </param>
        /// <param name="FileToBackupTo"> Base directory to backup to </param>
        /// <param name="BaseDirPrevBackup"> Base directory of the previous backup </param>
        /// <returns> true if the file was actualy copied, false if the file didn't change since a previous backup </returns>
        private Boolean BackupFile(FileInfo FileToBackup, FileInfo FileToBackupTo, FileInfo PrevBackupFile)
        {
            Boolean FileChanged = false;
            
            try
            {
                // Check if the file was backed up in the previous backup and wasn't changed afterwards, 
                // to create a hardlink rather then copying the file again.
                if (PrevBackupFile.Exists && Compare(PrevBackupFile, FileToBackup, false))
                {                    
                    FileChanged = false;

                    if (OnlySimulate != true)
                        CreateHardLink(FileToBackupTo, PrevBackupFile, IntPtr.Zero);
                    Log.Debug("HARDLINK " + FileToBackupTo.FullName + " TO " + PrevBackupFile + " (= previous backup");
                }
                else
                {
                    FileChanged = true;

                    if (OnlySimulate != true)
                        File.Copy(FileToBackup.FullName, FileToBackupTo.FullName);
                    Log.Debug("COPY " + FileToBackup + " TO " + FileToBackupTo.FullName);
                }
            }
            catch (Exception ex)
            {
                Log.Error(FileToBackup + " TO " + FileToBackupTo.FullName + ": " + ex.Message);
            }

            return FileChanged;
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
            string ReturnPath = "";

            try
            {
                // Get list of all dirs in the backup destination dir...
                string[] DirList = Directory.GetDirectories(DestinationDir, "Backup*", SearchOption.TopDirectoryOnly);

                // Loop over all dirs in the list and keep the "Largest" -> is the latest backup 
                // because of the way the directory name is created
                foreach (string Dir in DirList)
                {
                    if (string.Compare(Dir, ReturnPath) > 0)
                    {
                        ReturnPath = Dir;
                    }
                }
            }
            catch (Exception ex)
            {
                // There are apparently no previous backup dirs...
                Log.Warn("There are no previous backups found, exception: " + ex.Message);
            }

            return ReturnPath;
        }

        /// <summary>
        /// Make a new, unique backup directory to put the new backup in, with the following format:
        /// [BasePath]\Backup_[YYYY-MM-DD]_[SSSSS]
        /// </summary>
        /// <param name="BasePath"> The base path where the backups are put </param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string GetNewBackupDir()
        {
            string DirToBackupToFull = DestinationDir + "\\Backup_" + System.DateTime.Now.ToString("yyyy-MM-dd");

            // Check if path exists already... and create a unique one if necessary...
            if (Directory.Exists(DirToBackupToFull))
            {
                DirToBackupToFull = MakeDirPathUnique(DirToBackupToFull);
            }

            return DirToBackupToFull;
        }

        /// <summary>
        /// Makes a path given as parameter unique by adding a sequence, if necessary, in the following format:
        /// [BasePath]_[SSSSS]
        /// SSSSS indicates a 5 digit sequence, left-padded with zero's.
        /// </summary>
        /// <param name="OriginalPath"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string MakeDirPathUnique(string OriginalPath)
        {
            string ReturnPath = "";
            string ReturnPathTmp = null;

            for (int seq = 1; seq < int.MaxValue; seq++)
            {
                // Try if next value for seq creates a non-existing dirname...
                ReturnPathTmp = OriginalPath + "_" + seq.ToString("D5");
                if (!Directory.Exists(ReturnPathTmp))
                {
                    ReturnPath = ReturnPathTmp;
                    Directory.CreateDirectory(ReturnPath);
                    break;
                }
            }
            return ReturnPath;
        }

        private bool CreateHardLink(FileInfo newHardLink, FileInfo existingFile, IntPtr lpSecurityAttributes)
        {
            return CreateHardLink(newHardLink.FullName, existingFile.FullName, lpSecurityAttributes);
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool CreateHardLink(string lpFileName, string lpExistingFileName, IntPtr lpSecurityAttributes);

        #endregion Private methods: Backup FullRotatingWithSIS

        #region Private methods: General

        /// <summary>
        ///   Sets the Normal attribute on any particular file.
        /// </summary>
        /// <param name="file"></param>
        private void SetNormalFileAttribute(string file)
        {
            FileAttributes attr = FileAttributes.Normal;
            File.SetAttributes(file, attr);
        }

        /// <summary>
        ///   This function compares like this
        ///       - Same filename = identical files
        ///       - Different file size = not identical
        ///       - Different modify date = not identical
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="compareBinary"> Should the files be binary compared to be sure they are the same? </param>
        /// <returns></returns>
        /// <remarks>
        ///   This function can throw exceptions is a file isn't found or something like that...
        /// </remarks>
        private bool Compare(FileInfo file1, FileInfo file2, bool compareBinary)
        {
            // If user has selected the same file as file one and file two....
            if ((file1 == file2))
            {
                return true;
            }

            // If the files are the same length and the modify time is different... they are probably the same...
            if ((file1.Length == file2.Length) && (file1.LastWriteTime == file2.LastWriteTime))
            {
                if (compareBinary == false)
                    return true;
                else
                    return CompareBinary(file1, file2);
            }
            else
                return false;
        }

        /// <summary>
        ///   This function compares like this
        ///       - Same filename = identical files
        ///       - Different file size = not identical
        ///       - Complete binary comparison of data
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <returns></returns>
        /// <remarks>
        ///   This function can throw exceptions is a file isn't foud or something like that...
        /// </remarks>
        private bool CompareBinary(FileInfo file1, FileInfo file2)
        {
            // If user has selected the same file as file one and file two....
            if ((file1 == file2))
            {
                return true;
            }
            const int ReadBufferSize = 65536;   // 64 kB, blijkbaar een of andere buffergrootte van NTFS

            // Open a FileStream for each file.
            FileStream fileStream1 = default(FileStream);
            FileStream fileStream2 = default(FileStream);

            fileStream1 = new FileStream(file1.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, ReadBufferSize, FileOptions.SequentialScan);
            fileStream2 = new FileStream(file2.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, ReadBufferSize, FileOptions.SequentialScan);

            // If the files are not the same length...
            if ((fileStream1.Length != fileStream2.Length))
            {
                fileStream1.Close();
                fileStream2.Close();

                // File's are not equal.
                return false;
            }

            // Loop through data in the files until
            //  data in file 1 <> data in file 2 OR end of one of the files is reached.
            int count1 = ReadBufferSize;
            int count2 = ReadBufferSize;
            byte[] buffer1 = new byte[count1];
            byte[] buffer2 = new byte[count2];
            bool areFilesEqual = true;

            while(areFilesEqual == true)
            {
                count1 = fileStream1.Read(buffer1, 0, count1);
                count2 = fileStream2.Read(buffer2, 0, count2);

                // If one of the files are at his end... stop the loop
                if (count1 == 0 | count2 == 0)
                {
                    break;
                }

                // Check if the data read is identical
                for (int i = 0; i <= (count1 - 1); i++)
                {
                    if (buffer1[i] != buffer2[i])
                    {
                        areFilesEqual = false;
                        break;
                    }
                }
            }
           
            // Close the FileStreams.
            fileStream1.Close();
            fileStream2.Close();

            return areFilesEqual;
        }

        #endregion Private methods: General
    }
}