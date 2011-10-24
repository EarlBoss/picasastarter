/*
 * 
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;  // Necessary for creating Hardlinks
using Logger;                          // Static logging class

namespace PRBackup
{
    /// <summary>
    /// Backup Class
    ///     Backup files and/or entire directory trees to a specified backup location.
    ///     
    ///     Different backup strategies are supported.
    /// </summary>
    public class Backup
    {
        #region ProgessEventParams Stuff

        // Delegate declarations.
        public delegate void ProgressEventHandler(object sender, ProgressEventParams e);

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
        #endregion

        #region Private Members

        private BackupStrategy _strategy = BackupStrategy.SISRotating;
        private string _destinationDir = "";
        private List<string> _dirsToBackup = new List<string>();
        private List<string> _dirsToExclude = new List<string>();

        private Boolean _onlySimulate = false;      // If true, the backup isn't actualy created, only the logging is written...
        private string _dirPrevBackup = "";
        private string _dirToBackupTo = "";

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
        public event ProgressEventHandler ProgressEvent;
        #endregion

        #region Public Methods

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
            
            // Loop over every directory to backup
            foreach (string CurDirToBackup in DirsToBackup)
            {
                BackupDir(CurDirToBackup);
            }

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
        #endregion

        #region Private methods: Backup

        /// <summary>
        /// Backup a directory recursively.
        /// </summary>
        /// <param name="DirToBackup"> Full path to the dir to backuped (recursively) </param>
        private void BackupDir(string DirToBackup)
        {
            // Get list of all files...
            string[] ListSrcFiles = null;
            try
            {
                ListSrcFiles = Directory.GetFiles(DirToBackup, "*.*", SearchOption.AllDirectories);
            }
            catch (Exception ex)
            {
                Log.Debug("ERROR " + DirToBackup + ": " + ex.Message);
                return;
            }

            string CurFileToBackup = "";
            ProgressEventParams pE;
            Boolean FileChanged;
            int NbFiles = ListSrcFiles.Length;
            int NbFilesChanged = 0;
            int NbFilesNotChanged = 0;

            // Take the necessary actions file per file...
            for (int i = 0; i <= (NbFiles - 1); i++)
            {
                CurFileToBackup = ListSrcFiles[i];
                pE = new ProgressEventParams(_dirToBackupTo, NbFiles, NbFilesChanged, NbFilesNotChanged, CurFileToBackup);
                OnProgressEvent(pE);

                // Check if the file is in an "Excluded" directory...
                bool Excluded = false;
                foreach (string DirToExclude in DirsToExclude)
                    Excluded = CurFileToBackup.StartsWith(DirToExclude);

                // Backup the file...
                if (Excluded == false)
                    FileChanged = BackupFile(CurFileToBackup, _dirToBackupTo, _dirPrevBackup);
                else
                    FileChanged = false;

                // Change the counters for the progress reporting...
                if (FileChanged == true)
                    NbFilesChanged++;
                else
                    NbFilesNotChanged++;
            }

            // Also progress the last file...
            pE = new ProgressEventParams(_dirToBackupTo, NbFiles, NbFilesChanged, NbFilesNotChanged, CurFileToBackup);
            OnProgressEvent(pE);
        }

        /// <summary>
        /// Backup a file, using the SIS principle: if the file exists already in the previous backup, 
        /// create a hardlink instead of making another copy.
        /// </summary>
        /// <param name="FilePathSrc"> Full path to the file to backuped </param>
        /// <param name="BaseDirToBackupTo"> Base directory to backup to </param>
        /// <param name="BaseDirPrevBackup"> Base directory of the previous backup </param>
        /// <returns> true if the file was actualy copied, false if the file didn't change since a previous backup </returns>
        private Boolean BackupFile(string FilePathSrc, string BaseDirToBackupTo, string BaseDirPrevBackup)
        {
            Boolean FileChanged = false;
            
            // Prepare the path where to put the file inside the backup directory
            string FilePathInBackupPath = System.Environment.MachineName + "_Drive-" + FilePathSrc.Replace(":", "");
            //string FilePathInBackupPath = "Drive-" + FilePathSrc.Replace(":", "");

            // Create the complete file path for the actual backup
            string FilePathBackup = BaseDirToBackupTo + '\\' + FilePathInBackupPath;
            
            try
            {
                // If not simulating the backup, create the directory if it doesn't exist...
                if (OnlySimulate != true)
                {
                    FileInfo FileInfoBackup = new FileInfo(FilePathBackup);
                    string DirBackup = FileInfoBackup.DirectoryName;
                    Directory.CreateDirectory(DirBackup);
                }

                // Recreate the file path of the previous backup
                string FilePathBackupPrev = BaseDirPrevBackup + '\\' + FilePathInBackupPath;

                // Check if the file was backed up in the previous backup and wasn't changed afterwards, 
                // to create a hardlink rather then copying the file again.
                if (File.Exists(FilePathBackupPrev) && Compare(FilePathBackupPrev, FilePathSrc))
                {                    FileChanged = false;

                    if (OnlySimulate != true)
                        CreateHardLink(FilePathBackup, FilePathBackupPrev, IntPtr.Zero);
                    Log.Debug("HARDLINK " + FilePathBackup + " TO " + FilePathBackupPrev + " (Previous backup exists at " + BaseDirPrevBackup + ")");
                }
                else
                {
                    FileChanged = true;

                    if (OnlySimulate != true)
                        File.Copy(FilePathSrc, FilePathBackup);
                    Log.Debug("COPY " + FilePathSrc + " TO " + FilePathBackup);
                }
            }
            catch (Exception ex)
            {
                Log.Debug("ERROR " + FilePathSrc + " TO " + FilePathBackup + ": " + ex.Message);
            }

            return FileChanged;
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
        /// <param name="filePath1"></param>
        /// <param name="filePath2"></param>
        /// <returns></returns>
        /// <remarks>
        ///   This function can throw exceptions is a file isn't found or something like that...
        /// </remarks>
        private bool Compare(string filePath1, string filePath2)
        {
            // If user has selected the same file as file one and file two....
            if ((filePath1 == filePath2))
            {
                return true;
            }

            // Get the FileInfo for each file.
            FileInfo fileInfo1 = new FileInfo(filePath1);
            FileInfo fileInfo2 = new FileInfo(filePath2);

            // If the files are not the same length or the modify time is different...
            if ((fileInfo1.Length != fileInfo2.Length) | (fileInfo1.LastWriteTime != fileInfo2.LastWriteTime))
            {
                return false;
            }
            else
            {
                return CompareBinary(filePath1, filePath2);
            }
        }

        /// <summary>
        ///   This function compares like this
        ///       - Same filename = identical files
        ///       - Different file size = not identical
        ///       - Complete binary comparison of data
        /// </summary>
        /// <param name="filePath1"></param>
        /// <param name="filePath2"></param>
        /// <returns></returns>
        /// <remarks>
        ///   This function can throw exceptions is a file isn't foud or something like that...
        /// </remarks>
        private bool CompareBinary(string filePath1, string filePath2)
        {
            // If user has selected the same file as file one and file two....
            if ((filePath1 == filePath2))
            {
                return true;
            }
            const int ReadBufferSize = 65536;   // 64 kB, blijkbaar een of andere buffergrootte van NTFS

            // Open a FileStream for each file.
            FileStream fileStream1 = default(FileStream);
            FileStream fileStream2 = default(FileStream);

            fileStream1 = new FileStream(filePath1, FileMode.Open, FileAccess.Read, FileShare.Read, ReadBufferSize, FileOptions.SequentialScan);
            fileStream2 = new FileStream(filePath2, FileMode.Open, FileAccess.Read, FileShare.Read, ReadBufferSize, FileOptions.SequentialScan);

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