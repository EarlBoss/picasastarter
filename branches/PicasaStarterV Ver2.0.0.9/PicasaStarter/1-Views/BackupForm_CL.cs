using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;                       // Added to be able to check if a directory exists
using BackupNS;
using HelperClasses;
using HelperClasses.Logger;            // Static logging class

namespace PicasaStarter
{
    public partial class BackupForm_CL : Form
    {
        private static Backup _backup = null;
        private static BackupProgressForm_CL _progressForm;
        private static PicasaDB _db = null;
        private static String settingsDir;
        public bool backupCancelled = false;

        public BackupForm_CL(PicasaDB db, String _settingsDir)
        {
            InitializeComponent();
            _db = db;
            settingsDir = _settingsDir;
        }

        public void CancelBackup()
        {
            if (_backup != null)
            {
                _backup.CancelBackupAssync();
                backupCancelled = true;
            }
        }

        private void BackupForm_CL_Load(object sender, EventArgs e)
        {
            //Quick & Dirty way to make this form invisible - 2000 pixels offscreen top left           
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(-2000, -2000);
            Size = new System.Drawing.Size(1, 1);
             

            // Don't do the backup if this is not the defined backup Computer
            if (!string.IsNullOrEmpty(_db.BackupComputerName) &&
            _db.BackupComputerName == Environment.MachineName)
            {
                StartBackupCL();
            }
            else
            {
                Close();
            }
        }

        private void StartBackupCL()
        {
            //Function will back up pictures and database when cmd line arg is /backup "database name"
 
            if (!Directory.Exists(_db.BaseDir))
            {
                //MessageBox.Show("The base directory of this database doesn't exist or you didn't choose one yet.");
                return;
            }
            if (!Directory.Exists(_db.BackupDir))
            {
                //MessageBox.Show("The backup directory of this database doesn't exist or you didn't choose one yet.");
                return;
            }
            if (_backup != null)
            {
                //MessageBox.Show("There is a backup still running... please wait until it is finished before starting one again.");
                return;
            }

            try
            {
                // Initialise the paths where the database and the albums can be found
                String picasaDBPath = _db.BaseDir + "\\Google\\Picasa2";
                String picasaAlbumsPath = _db.BaseDir + "\\Google\\Picasa2Albums";
                String psSettingsPath = settingsDir;

                // Read directories watched/excluded by Picasa in the text files in the Album dir... 
                string watched = File.ReadAllText(picasaAlbumsPath + "\\watchedfolders.txt");
                string excluded = File.ReadAllText(picasaAlbumsPath + "\\frexcludefolders.txt");

                string[] watchedDirs = watched.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string[] excludedDirs = excluded.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                _backup = new Backup();
                if (_db.BackupDBOnly == false)
                {
                    _backup.DestDirPrefix = "Backup_";
                    _backup.DestinationDir = _db.BackupDir;
                    _backup.DirsToBackup.AddRange(watchedDirs);     // Backup watched dirs
                    _backup.DirsToBackup.Add(picasaDBPath);         // Backup Picasa database
                    _backup.DirsToBackup.Add(picasaAlbumsPath);     // Backup albums
                    _backup.DirsToBackup.Add(psSettingsPath);     // Backup Settings
                    _backup.DirsToExclude.AddRange(excludedDirs);   // Exclude explicitly unwatched dirs
                    _backup.MaxNbBackups = 100;                     // Max nb. backups to keep
                }
                else
                {
                    _backup.DestDirPrefix = "DBBackup_";
                    _backup.DestinationDir = _db.BackupDir;
                    _backup.DirsToBackup.Add(picasaDBPath);         // Backup Picasa database
                    _backup.DirsToBackup.Add(picasaAlbumsPath);     // Backup albums
                    _backup.DirsToBackup.Add(psSettingsPath);     // Backup Settings
                    _backup.MaxNbBackups = 100;                     // Max nb. backups to keep

                }

                _progressForm = new BackupProgressForm_CL(this);
                _progressForm.Show();
                this.Enabled = false;
                this.Opacity = 0.3 ;

                _backup.ProgressEvent += new Backup.BackupProgressEventHandler(_progressForm.Progress);
                _backup.CompletedEvent += new Backup.BackupCompletedEventHandler(BackupCompleted);

                // Start the asynchronous operation.
                _backup.StartBackupAssync();
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BackupCompleted(object sender, EventArgs e)
        {
            this.Enabled = true;
            //WindowState = FormWindowState.Normal; //Show
            _progressForm.Hide();
            _progressForm = null;
            _backup = null;
            if (!backupCancelled)
            {
                BackupDateUpdate();
                backupCancelled = false;
            }
            Close();
        }

        public void BackupDateUpdate()
        {
            Program.BackupComplete = true;
        }

    }
}
