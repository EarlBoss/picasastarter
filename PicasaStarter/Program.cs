using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;           // Needed for working with process...
using System.IO;
using HelperClasses;                // Needed for making symbolic links,...
using BackupNS;
using HelperClasses.Logger;            // Static logging class

namespace PicasaStarter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string appDataDir = Environment.GetEnvironmentVariable("appdata") + "\\PicasaStarter";
            string appSettingsDir = "";
            string appSettingsBaseDir = "";
            string configurationDir = "";

            Configuration config;
             Settings settings;
            bool notConfigured = false;
            bool settingsfound = false;

            configurationDir = SettingsHelper.DetermineConfigDir();
            appSettingsDir = SettingsHelper.DetermineSettingsDir(configurationDir);
            settings = new Settings();
            config = new Configuration();
            bool showGUI = true;
            string MappedDrive = "";

                try
                {
                    config = SettingsHelper.DeSerializeConfig(
                        configurationDir + "\\" + SettingsHelper.ConfigFileName);
                }
                catch (Exception)
                {
                    //No config file, set config & settings defaults and signal first time run
                    notConfigured = true;
                    config.picasaStarterSettingsXMLPath = "";
                    config.configPicasaExePath = SettingsHelper.ProgramFilesx86();
                    settings.picasaDBs.Add(SettingsHelper.GetDefaultPicasaDB());
                }
                // load settings...
                if (!notConfigured)
                {
                    bool cancelSettingsFileSearch = false;
                    string currentDir = appSettingsDir;
                    currentDir = Path.GetDirectoryName(currentDir);
                    appSettingsBaseDir = currentDir;

                    while (!settingsfound && cancelSettingsFileSearch == false)
                    {
                        if (!File.Exists(appSettingsDir + "\\" + SettingsHelper.SettingsFileName))
                        {
                            // Take care of case where the settings file is not available but it is referenced in the config file (The settings drive/dir is missing).
                            // Initializes the variables to pass to the MessageBox.Show method.
                            string message = "The Picasa Starter settings file was not found in:\n" + appSettingsDir + "\n\n If it is on a NAS or Portable Drive, " +
                                "\nPlease Connect the drive as the correct drive letter.\n" +
                                "When the Drive is connected, Push YES to Try Again.\n\n" +
                                "To define a new Settings File location, Push NO,\n" +
                                "Then Correct the Settings File location in the First Run dialog \n\n" +
                                 "To Exit PicasaStarter Without Trying Again, Push CANCEL.";
                           string caption = "Missing Settings File";

                            // Displays the MessageBox.
                            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel);

                            if (result == DialogResult.Yes)
                            {
                                settingsfound = false;
                            }
                            if (result == DialogResult.Cancel)
                            {
                                cancelSettingsFileSearch = true;
                                notConfigured = true;
                                showGUI = false;
                            }
                            else if (result == DialogResult.No)
                            {
                                notConfigured = true;
                                cancelSettingsFileSearch = true;
                                settings.picasaDBs.Add(SettingsHelper.GetDefaultPicasaDB());
                            }
                        }
                        else
                            settingsfound = true;
                    }

                    // Try to read the settings file...
                    if (settingsfound == true)
                    {
                        try
                        {
                            settings = SettingsHelper.DeSerializeSettings(
                                appSettingsDir + "\\" + SettingsHelper.SettingsFileName);
                            settingsfound = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error reading settings file: " + ex.Message);
                            settings.picasaDBs.Add(SettingsHelper.GetDefaultPicasaDB());
                        }
                    }
                }
                if (!notConfigured)
                {
                    // Save settings
                    //---------------------------------------------------------------------------
                    try
                    {
                        SettingsHelper.SerializeSettings(settings,
                                appSettingsDir + "\\" + SettingsHelper.SettingsFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving settings: " + ex.Message);
                    }

                    // Process command line arguments...
                    //---------------------------------------------------------------------------
                    string autoRunDatabaseName = null;
                    string backupDatabaseName = null;

                    for (int i = 1; i < Environment.GetCommandLineArgs().Length; i++)
                    {
                        string arg = Environment.GetCommandLineArgs()[i];

                        // Check if Picasastarter should autorun Picasa with a specified database name...
                        if (arg.Equals("/autorun", StringComparison.CurrentCultureIgnoreCase))
                        {
                            showGUI = false;

                            // The next argument should be the database name...
                            i++;
                            if (i < Environment.GetCommandLineArgs().Length)
                            {
                                autoRunDatabaseName = Environment.GetCommandLineArgs()[i];
                                autoRunDatabaseName = autoRunDatabaseName.Trim(new char[] { '"', ' ' });
                            }
                            else
                            {
                                MessageBox.Show("The /autorun directive should be followed by an existing Picasa database name, or \"Personal\" or \"AskUser\"", "No Database Name");
                            }
                        }
                        else if (arg.Equals("/backup", StringComparison.CurrentCultureIgnoreCase))
                        {
                            showGUI = false;

                            // The next argument should be the database name...
                            i++;
                            if (i < Environment.GetCommandLineArgs().Length)
                            {
                                backupDatabaseName = Environment.GetCommandLineArgs()[i];
                                backupDatabaseName = backupDatabaseName.Trim(new char[] { '"', ' ' });
                            }
                            else
                            {
                                MessageBox.Show("The /backup directive should be followed by an existing Picasa database name, or \"Personal\" or \"AskUser\"", "No Database Name");
                            }
                        }
                        else if (arg.Equals("/CreateSymbolicLink", StringComparison.CurrentCultureIgnoreCase))
                        {
                            showGUI = false;

                            // The next argument should be the symbolic link file name...
                            string symLinkPath = "", symLinkDest = "";
                            if (i < Environment.GetCommandLineArgs().Length)
                            {
                                i++;
                                symLinkPath = Environment.GetCommandLineArgs()[i];
                            }

                            if (i < Environment.GetCommandLineArgs().Length)
                            {
                                i++;
                                symLinkDest = Environment.GetCommandLineArgs()[i];
                            }

                            if (symLinkPath == "" || symLinkDest == "")
                            {
                                MessageBox.Show("The /CreateSymbolicLink directive should be followed by a valid path name and the destination path", "Symlink Not Created");
                            }

                            IOHelper.CreateSymbolicLink(symLinkPath, symLinkDest, true);
                        }
                        else
                        {
                            MessageBox.Show("Invalid or no command line parameter: " + arg);
                        }
                    }

                    // If /autorun argument was passed...
                    //---------------------------------------------------------------------------
                    if (autoRunDatabaseName != null)
                    {
                        // First check if he wants to be asked which database to run
                        if (autoRunDatabaseName.Equals("AskUser", StringComparison.CurrentCultureIgnoreCase))
                        {
                            // Show Database selection menu 
                            SelectDBForm selectDBForm = new SelectDBForm(settings);
                            selectDBForm.ShowDialog();

                            if (selectDBForm.ReturnDBName != null)
                            {
                                autoRunDatabaseName = selectDBForm.ReturnDBName;
                            }

                        }
                        // Next check if he wants to run with the standard personal database...
                        if (autoRunDatabaseName.Equals("personal", StringComparison.CurrentCultureIgnoreCase))
                        {
                            // If the user wants to run his personal default database... (cmd line arg was "personal") 
                            PicasaRunner runner = new PicasaRunner(appDataDir, settings.PicasaExePath);
                            runner.RunPicasa(null, appSettingsDir);
                        }
                        else
                        {
                            // Exit if the Ask menu was cancelled
                            if (autoRunDatabaseName.Equals("AskUser", StringComparison.CurrentCultureIgnoreCase))
                            {
                                return;
                            }

                            PicasaDB foundDB = null;
                            foreach (PicasaDB db in settings.picasaDBs)
                            {
                                if (db.Name.Equals(autoRunDatabaseName, StringComparison.CurrentCultureIgnoreCase))
                                    foundDB = db;
                            }

                            if (foundDB != null)
                            {
                                if (foundDB.EnableVirtualDrive == true)
                                {
                                    MappedDrive = IOHelper.MapFolderToDrive(foundDB.PictureVirtualDrive, appSettingsBaseDir);
                                }
                                PicasaRunner runner = new PicasaRunner(appDataDir, settings.PicasaExePath);

                                // If the user wants to run his personal default database... 
                                if (foundDB.IsStandardDB == true)
                                    runner.RunPicasa(null, appSettingsDir);
                                // If the user wants to run a custom database...
                                else
                                {
                                    if (Directory.Exists(foundDB.BaseDir))
                                        runner.RunPicasa(foundDB.BaseDir, appSettingsDir);
                                    else
                                        MessageBox.Show("The base directory of this database doesn't exist or you didn't choose one yet.");
                                }
                                bool xyz;
                                xyz = IOHelper.UnmapVDrive();

                            }
                            else
                            {
                                MessageBox.Show("The database passed with the /autorun parameter was not found: (" + autoRunDatabaseName + ")");
                                autoRunDatabaseName = null;
                            }
                        }
                    }
                    // If /backup argument was passed...
                    //---------------------------------------------------------------------------
                    if (backupDatabaseName != null)
                    {
                        PicasaDB foundDB = null;
                        // First check if he wants to be asked which database to backup
                        if (backupDatabaseName.Equals("AskUser", StringComparison.CurrentCultureIgnoreCase))
                        {
                            // Show Database selection menu 
                            SelectDBForm selectDBForm = new SelectDBForm(settings);
                            selectDBForm.ShowDialog();

                            if (selectDBForm.ReturnDBName != null)
                            {
                                backupDatabaseName = selectDBForm.ReturnDBName;
                            }

                        }
                        // Next check if he wants to backup the standard personal database...
                        if (backupDatabaseName.Equals("personal", StringComparison.CurrentCultureIgnoreCase))
                        {
                            // If the user wants to backup his personal default database... (cmd line arg was "personal") 
                            StartBackup(settings.picasaDBs[0]); 
                        }
                        else
                        {
                            // Exit if the Ask menu was cancelled
                            if (backupDatabaseName.Equals("AskUser", StringComparison.CurrentCultureIgnoreCase))
                            {
                                return;
                            }

                            foreach (PicasaDB db in settings.picasaDBs)
                            {
                                //MessageBox.Show("db: " + db.Name + "\nBackup name: " + backupDatabaseName);
                                if (db.Name.Equals(backupDatabaseName, StringComparison.CurrentCultureIgnoreCase))
                                    foundDB = db;
                            }
                            //MessageBox.Show("Foundb: " + foundDB.Name + "\nBackup dir " + foundDB.BackupDir );

                            if (foundDB != null)
                            {
                                if (foundDB.EnableVirtualDrive == true)
                                {
                                    MappedDrive = IOHelper.MapFolderToDrive(foundDB.PictureVirtualDrive, appSettingsBaseDir);
                                }
                                StartBackup(foundDB); 

                              bool xyz;
                                xyz = IOHelper.UnmapVDrive();

                            }
                            else
                            {
                                MessageBox.Show("The database passed with the /backup parameter was not found: (" + backupDatabaseName + ")");
                                backupDatabaseName = null;
                            }
                        }
                    }
                }

                if (showGUI == true)
                {
                    Application.Run(new MainForm(settings, appDataDir, appSettingsDir, notConfigured));
                }

            }
       #region private helper functions...
         private static Backup _backup = null;
         private static BackupProgressForm _progressForm = null;
         private static PicasaDB _db = null;

        //Function will back up pictures and database when cmd line arg is /backup "database name"
        //Broken at the moment.
        private static void StartBackup(PicasaDB db)
        {
            _db = db;

           if (!Directory.Exists(_db.BaseDir))
            {
                MessageBox.Show("The base directory of this database doesn't exist or you didn't choose one yet.");
                return;
            }
           if (!Directory.Exists(_db.BackupDir))
            {
                MessageBox.Show("The backup directory of this database doesn't exist or you didn't choose one yet.");
                return;
            }
            if (_backup != null)
            {
                MessageBox.Show("There is a backup still running... please wait until it is finished before starting one again.");
                return;
            }

/*            try
            {
                // Initialise the paths where the database and the albums can be found
                String picasaDBPath = SettingsHelper.GetFullDBDirectory(_db) + "\\Picasa2";
                String picasaAlbumsPath = SettingsHelper.GetFullDBDirectory(_db) + "\\Picasa2Albums";

                // Read directories watched/excluded by Picasa in the text files in the Album dir... 
                string watched = File.ReadAllText(picasaAlbumsPath + "\\watchedfolders.txt");
                string excluded = File.ReadAllText(picasaAlbumsPath + "\\frexcludefolders.txt");

                string[] watchedDirs = watched.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string[] excludedDirs = excluded.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //MessageBox.Show("watch: " + watched + "\nexcluded: " + excluded);

                _backup = new Backup();
                _backup.DestinationDir = _db.BackupDir;
                _backup.DirsToBackup.AddRange(watchedDirs);     // Backup watched dirs
                _backup.DirsToBackup.Add(picasaDBPath);         // Backup Picasa database
                _backup.DirsToBackup.Add(picasaAlbumsPath);     // Backup albums
                _backup.DirsToExclude.AddRange(excludedDirs);   // Exclude explicitly unwatched dirs
                _backup.MaxNbBackups = 100;                     // Max nb. backups to keep

                _progressForm = new BackupProgressForm(null);
                _progressForm.Show();
                //this.Enabled = false;

                _backup.ProgressEvent += new Backup.BackupProgressEventHandler(_progressForm.Progress);
                _backup.CompletedEvent += new Backup.BackupCompletedEventHandler(BackupCompleted);

                // Start the asynchronous operation.
                _backup.StartBackupAssync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 */
        }
/*
        private static void BackupCompleted(object sender, EventArgs e)
        {
            //this.Enabled = true;
            _progressForm.Hide();
            _progressForm = null;
            _backup = null;
        }
 */
         #endregion

    }

}
