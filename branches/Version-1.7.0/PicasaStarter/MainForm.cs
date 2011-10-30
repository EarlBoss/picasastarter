using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;                       // Added to be able to check if a directory exists
using BackupNS;

namespace PicasaStarter
{
    public partial class MainForm : Form
    {
        #region Private members

        private Settings _settings;
        private string _appDataDir = "";
        private string _appSettingsDir = "";
        private bool _firstRun = false;
        private Backup _backup = null;
        private BackupProgressForm _progressForm = null;

        #endregion

        #region Public or internal methods

        public MainForm(Settings settings, string appDataDir, string appSettingsDir, bool firstRun)
        {
            InitializeComponent();
            _settings = settings;
            _appDataDir = appDataDir;
            _appSettingsDir = appSettingsDir;
            _firstRun = firstRun;
        }

        internal void CancelBackup()
        {
            if(_backup != null)
                _backup.CancelBackupAssync();
        }

        #endregion

        #region Initialisation and closing of the Form...

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set version in title bar
            this.Text = this.Text + " " + System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;

            //Ask for apps dir and exe path if new instance
            if (_firstRun == true)
            {
                FirstRunWizard firstRunWizard = new FirstRunWizard(_appSettingsDir, _settings);
                DialogResult result = firstRunWizard.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (firstRunWizard.ReturnPicasaSettings != null)
                    {
                        _settings = firstRunWizard.ReturnPicasaSettings;
                        _appSettingsDir = firstRunWizard.ReturnAppSettingsDir;
                    }
                    _settings.PicasaExePath = firstRunWizard.ReturnPicasaExePath;

                }
            }

            // Initialise all controls on the screen with the proper data
            ReFillPicasaDBList(false);

            // If the saved defaultselectedDB is valid, select it in the list...
            int defaultSelectedDBIndex = listBoxPicasaDBs.FindStringExact(_settings.picasaDefaultSelectedDB);
            if (defaultSelectedDBIndex != ListBox.NoMatches)
                listBoxPicasaDBs.SelectedIndex = defaultSelectedDBIndex;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((listBoxPicasaDBs.SelectedIndex > -1)
                    && listBoxPicasaDBs.SelectedIndex < _settings.picasaDBs.Count)
            {
                _settings.picasaDefaultSelectedDB = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].Name;
            }

            // Save settings
            try
            {
                SettingsHelper.SerializeSettings(_settings,
                        _appSettingsDir + "\\" + SettingsHelper.SettingsFileName);
            }
            catch (Exception ex)
            {
                string message = "Error saving settings: " + ex.Message +
                "\n\nThe Settings directory was not writable or it was on a NAS or Portable Drive that was disconnected." +
                "        ---->   PicasaStarter will Exit.   <----" +
                "\n\nMake sure the NAS or Portable drive is available and try again." +
                "\nGo to General Settings if you wish to select a new settings directory,";

                string caption = "Can't Save Settings File";

                // Displays the MessageBox.

                MessageBox.Show(message, caption);
            }
        }

        #endregion

        #region Event handlers for buttons at the bottom of the main form

        private void buttonGeneralSettings_Click(object sender, EventArgs e)
        {
            GeneralSettingsDialog generalSettingsDialog = new GeneralSettingsDialog(_appSettingsDir, _settings.PicasaExePath);
            DialogResult result = generalSettingsDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (generalSettingsDialog.ReturnPicasaSettings != null)
                {
                    _settings = generalSettingsDialog.ReturnPicasaSettings;
                    // ReFillPicasaDBList(false);
                }
                _settings.PicasaExePath = generalSettingsDialog.ReturnPicasaExePath;
                _appSettingsDir = generalSettingsDialog.ReturnAppSettingsDir;
                // Initialise all controls on the screen with the proper data
                ReFillPicasaDBList(false);
                // If the saved defaultselectedDB is valid, select it in the list...
                int defaultSelectedDBIndex = listBoxPicasaDBs.FindStringExact(_settings.picasaDefaultSelectedDB);
                if (defaultSelectedDBIndex != ListBox.NoMatches)
                    listBoxPicasaDBs.SelectedIndex = defaultSelectedDBIndex;

                if (_firstRun == true)
                {
                    ShowHelp();
                }

            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Event handlers for buttons/events... concerning the list of Picasa databases

        private void listBoxPicasaDBs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPicasaDBs.SelectedIndex < 0)
                return;
            if (listBoxPicasaDBs.SelectedIndex >= _settings.picasaDBs.Count)
            {
                MessageBox.Show("Invalid item choosen from the database list");
                return;
            }

            textBoxDBName.Text = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].Name;
            textBoxDBBaseDir.Text = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BaseDir;
            textBoxBackupDir.Text = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BackupDir;
            textBoxDBDescription.Text = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].Description;
            textBoxDBFullDir.Text = SettingsHelper.GetFullDBDirectory(_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex]);

            // If it is the default database, fields should be read-only!
            if (_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].IsStandardDB == true)
            {
                textBoxDBName.ReadOnly = true;
                textBoxDBDescription.ReadOnly = true;
                buttonBrowseDBBaseDir.Enabled = false;
                buttonRemoveDB.Enabled = false;
            }
            else
            {
                textBoxDBName.ReadOnly = false;
                textBoxDBDescription.ReadOnly = false;
                buttonBrowseDBBaseDir.Enabled = true;
                buttonRemoveDB.Enabled = true;
            }
        }

        private void buttonAddDB_Click(object sender, EventArgs e)
        {
            _settings.picasaDBs.Add(new PicasaDB("New"));
            ReFillPicasaDBList(true);
        }

        private void buttonRemoveDB_Click(object sender, EventArgs e)
        {
            if (listBoxPicasaDBs.SelectedIndex == -1
                    || listBoxPicasaDBs.SelectedIndex >= _settings.picasaDBs.Count)
            {
                MessageBox.Show("Please choose a picasa database from the list first");
                return;
            }
            if (_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].IsStandardDB == true)
            {
                MessageBox.Show("The default database Picasa creates for you in you user directory cannot be removed from the list...");
            }

            DialogResult result = MessageBox.Show("Remark: This won't delete the picasa database itself, it will only remove the entry from this list!!!\n\n"
                    + "If you also want to recuperate the (little) diskspace taken by the database, it is better to do this first.\n\n"
                    + "Click \"OK\" if you want to remove the entry from the list, \"Cancel\" to... cancel",
                "Do you want to do this?", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                _settings.picasaDBs.RemoveAt(listBoxPicasaDBs.SelectedIndex);
                ReFillPicasaDBList(false);
            }
        }

        #endregion

        #region Event handlers for buttons/events... concerning actions on/changes to one chosen Picasa database

        private void buttonBrowseDBBaseDir_Click(object sender, EventArgs e)
        {
            textBoxDBBaseDir.Text = AskDirectoryPath(_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BaseDir);
        }

        private void buttonBrowseBackupDir_Click(object sender, EventArgs e)
        {
            textBoxBackupDir.Text = AskDirectoryPath(_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BackupDir);
        }

        private void textBoxDBName_TextChanged(object sender, EventArgs e)
        {
            if (listBoxPicasaDBs.SelectedIndex == -1
                || listBoxPicasaDBs.SelectedIndex >= _settings.picasaDBs.Count)
            {
                MessageBox.Show("Please choose a picasa database from the list first");
                return;
            }
        }

        private void textBoxDBName_Leave(object sender, EventArgs e)
        {
            if (listBoxPicasaDBs.SelectedIndex == -1
                || listBoxPicasaDBs.SelectedIndex >= _settings.picasaDBs.Count)
            {
                MessageBox.Show("Please choose a picasa database from the list first");
                return;
            }

            // if the User is changing the field, update the settings and the list as well...
            if (_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].Name != textBoxDBName.Text)
            {
                int selectedIndexBackup = listBoxPicasaDBs.SelectedIndex;
                _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].Name = textBoxDBName.Text;
                listBoxPicasaDBs.Items.RemoveAt(selectedIndexBackup);
                listBoxPicasaDBs.Items.Insert(selectedIndexBackup, textBoxDBName.Text);
                //ReFillPicasaDBList(false);
                listBoxPicasaDBs.SelectedIndex = selectedIndexBackup;
            }
        }

        private void textBoxDBDescription_TextChanged(object sender, EventArgs e)
        {
            if (listBoxPicasaDBs.SelectedIndex == -1
                || listBoxPicasaDBs.SelectedIndex >= _settings.picasaDBs.Count)
            {
                MessageBox.Show("Please choose a picasa database from the list first");
                return;
            }
            _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].Description = textBoxDBDescription.Text;
        }

        private void textBoxDBBaseDir_TextChanged(object sender, EventArgs e)
        {
            if (listBoxPicasaDBs.SelectedIndex == -1
                || listBoxPicasaDBs.SelectedIndex >= _settings.picasaDBs.Count)
            {
                MessageBox.Show("Please choose a picasa database from the list first");
                return;
            }
            _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BaseDir = textBoxDBBaseDir.Text;
            textBoxDBFullDir.Text = SettingsHelper.GetFullDBDirectory(_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex]);
        }

        private void textBoxBackupDir_TextChanged(object sender, EventArgs e)
        {
            if (listBoxPicasaDBs.SelectedIndex == -1
                    || listBoxPicasaDBs.SelectedIndex >= _settings.picasaDBs.Count)
            {
                MessageBox.Show("Please choose a picasa database from the list first");
                return;
            }
            _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BackupDir = textBoxBackupDir.Text;
        }

        private void buttonDBOpenFullDir_Click(object sender, EventArgs e)
        {
            if (listBoxPicasaDBs.SelectedIndex == -1
                    || listBoxPicasaDBs.SelectedIndex >= _settings.picasaDBs.Count)
            {
                MessageBox.Show("Please choose a picasa database from the list first");
                return;
            }

            string DBFullDir = SettingsHelper.GetFullDBDirectory(_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex]);

            try
            {
                Directory.CreateDirectory(DBFullDir);
                System.Diagnostics.Process.Start(DBFullDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ", when trying to open directory: " + DBFullDir);
            }
        }

        private void buttonRunPicasa_Click(object sender, EventArgs e)
        {
            if (listBoxPicasaDBs.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a picasa database from the list first");
                return;
            }
            if (!Directory.Exists(_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BaseDir))
            {
                MessageBox.Show("The base directory of this database doesn't exist or you didn't choose one yet.");
                return;
            }
            WindowState = FormWindowState.Minimized; //Remove PicasaStarter window from desktop while Picasa is running
            PicasaRunner runner = new PicasaRunner(_appDataDir, _settings.PicasaExePath);

            // If the user wants to run his personal default database... 
            if (_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].IsStandardDB == true)
                runner.RunPicasa(null);
            // If the user wants to run a custom database...
            else
                runner.RunPicasa(_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BaseDir);
            WindowState = FormWindowState.Normal;
            //Show();
        }

        private void ButtonCreateShortcut_Click(object sender, EventArgs e)
        {
            string databasename = "Personal";
            if (listBoxPicasaDBs.SelectedIndex != 0)
                databasename = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].Name;

            CreateShortcutDialog createShortcutDialog = new CreateShortcutDialog(_appSettingsDir, databasename);
            DialogResult result = createShortcutDialog.ShowDialog();
        }

        private void buttonBackupPics_Click(object sender, EventArgs e)
        {
            if (listBoxPicasaDBs.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a picasa database from the list first");
                return;
            }
            if (!Directory.Exists(_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BaseDir))
            {
                MessageBox.Show("The base directory of this database doesn't exist or you didn't choose one yet.");
                return;
            }
            if (!Directory.Exists(_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BackupDir))
            {
                MessageBox.Show("The backup directory of this database doesn't exist or you didn't choose one yet.");
                return;
            }
            if (_backup != null)
            {
                MessageBox.Show("There is a backup still running... please wait until it is finished before starting one again.");
                return;
            }

            // Read directories watched/excluded by Picasa
            String picasaDatabasePath = SettingsHelper.GetFullDBDirectory(_settings.picasaDBs[listBoxPicasaDBs.SelectedIndex]) + "\\Picasa2Albums";
            try
            {
                string watched = File.ReadAllText(picasaDatabasePath + "\\watchedfolders.txt");
                string excluded = File.ReadAllText(picasaDatabasePath + "\\frexcludefolders.txt");

                string[] watchedDirs = watched.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string[] excludedDirs = excluded.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                _backup = new Backup();
                _backup.DestinationDir = _settings.picasaDBs[listBoxPicasaDBs.SelectedIndex].BackupDir;
                _backup.DirsToBackup.AddRange(watchedDirs);
                _backup.DirsToExclude.AddRange(excludedDirs);
                _backup.Strategy = Backup.BackupStrategy.SISRotating;

                _progressForm = new BackupProgressForm(this);
                _progressForm.Show();

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
            _progressForm.Hide();
            _progressForm = null;
            _backup = null;
        }

        #endregion

        #region Private helper functions

        private string AskDirectoryPath(string InitialDirectory)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = true;
            fd.SelectedPath = InitialDirectory;

            if (fd.ShowDialog() == DialogResult.OK)
                return fd.SelectedPath;
            else
                return InitialDirectory;
        }

        private void ReFillPicasaDBList(bool selectLastItem)
        {
            string tip = "";
            if(_appSettingsDir == SettingsHelper.ConfigurationDir)
                tip = "Default: ";
             listBoxPicasaDBs.BeginUpdate();
            listBoxPicasaDBs.SelectedIndex = -1;
            listBoxPicasaDBs.Items.Clear();
            // Set the tooltip for the DBList to the settings path
            toolTip.SetToolTip(listBoxPicasaDBs, "Database Settings Path: \r\n" + tip + _appSettingsDir);
            for (int i = 0; i < _settings.picasaDBs.Count; i++)
            {
                listBoxPicasaDBs.Items.Add(_settings.picasaDBs[i].Name);
            }

            if (listBoxPicasaDBs.Items.Count > 0)
            {
                if (selectLastItem == true)
                    listBoxPicasaDBs.SelectedIndex = listBoxPicasaDBs.Items.Count - 1;
                else
                    listBoxPicasaDBs.SelectedIndex = 0;
            }
            listBoxPicasaDBs.EndUpdate();
        }

        private void ShowHelp()
        {
            HelpDialog help = new HelpDialog();
            help.ShowDialog();
        }

        #endregion
    }
}
