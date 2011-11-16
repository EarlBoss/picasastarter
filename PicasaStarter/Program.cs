using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;           // Needed for working with process...
using System.IO;
using HelperClasses;                // Needed for making symbolic links,...

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

            bool symlinkCreated = false;

            //See if we just need to create a symlink
            for (int i = 1; i < Environment.GetCommandLineArgs().Length; i++)
            {
                string arg = Environment.GetCommandLineArgs()[i];

                // Check if Picasastarter should create a symlink...
                if (arg.Equals("/CreateSymbolicLink", StringComparison.CurrentCultureIgnoreCase))
                {
                    // The next argument should be the symbolic link file name...
                    string symLinkPath = "", symLinkDest = "", settingsBaseDir = "", mappeddrive = "";
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
                    if (i < Environment.GetCommandLineArgs().Length)
                    {
                        i++;
                        settingsBaseDir = Environment.GetCommandLineArgs()[i];
                    }
                    if (i < Environment.GetCommandLineArgs().Length)
                    {
                        i++;
                        mappeddrive = Environment.GetCommandLineArgs()[i];
                    }

                    if (mappeddrive != "")
                    {
                        string xyz = "";
                        xyz = IOHelper.MapFolderToDrive(mappeddrive, settingsBaseDir);
                    }
 
                    if (symLinkPath == "" || symLinkDest == "")
                    {
                        MessageBox.Show("The /CreateSymbolicLink directive should be followed by a valid path name and the destination path", "Symlink Not Created");
                    }
                    if (Directory.Exists(symLinkDest))
                    {
                        IOHelper.CreateSymbolicLink(symLinkPath, symLinkDest, true);
                    }
                    if (mappeddrive != "")
                    {
                        string xyz;
                        xyz = IOHelper.UnmapFolderFromDrive(mappeddrive, settingsBaseDir);
                    }
                    symlinkCreated = true;
                }
            }
            if (!symlinkCreated)
            {

                // Initialisations: create temp dir, load settings,...
                //---------------------------------------------------------------------------
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
                                "To Exit PicasaStarter Without Trying Again, Push NO. \n\n" +
                                "To define a new Settings File location, Cancel this Message,\n" +
                                "Then Correct the Settings File location in the First Run dialog";
                            string caption = "Missing Settings File";

                            // Displays the MessageBox.
                            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel);

                            if (result == DialogResult.Yes)
                            {
                                settingsfound = false;
                            }
                            if (result == DialogResult.No)
                            {
                                cancelSettingsFileSearch = true;
                                notConfigured = true;
                                showGUI = false;
                            }
                            else if (result == DialogResult.Cancel)
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

                    for (int i = 1; i < Environment.GetCommandLineArgs().Length; i++)
                    {
                        string arg = Environment.GetCommandLineArgs()[i];

                        // Check if Picasastarter should autorun Picasa with a specified database name...
                        if ((arg.Equals("/autorun", StringComparison.CurrentCultureIgnoreCase)) && !notConfigured)
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
                            runner.RunPicasa(null, appSettingsDir, null);
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
                                if (foundDB.EnableVirtualDrive)
                                {
                                    MappedDrive = IOHelper.MapFolderToDrive(foundDB.PictureVirtualDrive, appSettingsBaseDir);
                                }
                                PicasaRunner runner = new PicasaRunner(appDataDir, settings.PicasaExePath);

                                // If the user wants to run his personal default database... 
                                if (foundDB.IsStandardDB == true)
                                    runner.RunPicasa(null, appSettingsDir, null);
                                // If the user wants to run a custom database...
                                else
                                {
                                    if (Directory.Exists(foundDB.BaseDir))
                                        runner.RunPicasa(foundDB.BaseDir, appSettingsDir, MappedDrive);
                                    else
                                        MessageBox.Show("The base directory of this database doesn't exist or you didn't choose one yet.");
                                }
                                if (MappedDrive != "")
                                {
                                    string xyz;
                                    xyz = IOHelper.UnmapFolderFromDrive(MappedDrive, appSettingsBaseDir);
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("The database passed with the /autorun parameter was not found: (" + autoRunDatabaseName + ")");
                                autoRunDatabaseName = null;
                            }
                        }
                    }
                }

                if (showGUI == true)
                {
                    Application.Run(new MainForm(settings, appDataDir, appSettingsDir, notConfigured));
                }

            }
        }

    }
}
