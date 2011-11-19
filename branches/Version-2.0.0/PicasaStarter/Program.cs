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
            string configurationDir = "";

            Configuration config;
            Settings settings;
            bool firstRun = false;
            bool settingsfound = false;

                // Initialisations: create temp dir, load settings,...
                //---------------------------------------------------------------------------
                configurationDir = SettingsHelper.DetermineConfigDir();
                appSettingsDir = SettingsHelper.DetermineSettingsDir(configurationDir);
                settings = new Settings();
                config = new Configuration();
                bool showGUI = true;

                try
                {
                    config = SettingsHelper.DeSerializeConfig(
                        configurationDir + "\\" + SettingsHelper.ConfigFileName);
                }
                catch (Exception)
                {
                    //No config file, set config & settings defaults and signal first time run
                    firstRun = true;
                    config.picasaStarterSettingsXMLPath = "";
                    config.configPicasaExePath = SettingsHelper.ProgramFilesx86();
                    settings.picasaDBs.Add(SettingsHelper.GetDefaultPicasaDB());
                }
                // load settings...
                if (!firstRun)
                {
                    bool cancelSearching = false;

                    while (!settingsfound && cancelSearching == false)
                    {
                        if (!File.Exists(appSettingsDir + "\\" + SettingsHelper.SettingsFileName))
                        {
                            // Take care of case where the settings file is not available but it is referenced in the config file (The settings drive/dir is missing).
                            // Initializes the variables to pass to the MessageBox.Show method.
                            string message = "The Picasa Starter settings file was not found in:   " + appSettingsDir + "\n\n If it is on a NAS or Portable Drive, " +
                                "Please Connect the drive as the correct drive letter and push Retry.\n\n" +
                                "To define a new Settings File location, Cancel this Message,\n" +
                                "Then set the Settings File location in the First Run dialog";
                            string caption = "Missing Settings File";

                            // Displays the MessageBox.
                            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.RetryCancel);

                            if (result == DialogResult.Retry)
                            {
                                settingsfound = false;
                            }
                            else if (result == DialogResult.Cancel)
                            {
                                firstRun = true;
                                cancelSearching = true;
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
                if (!firstRun)
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
                        if ((arg.Equals("/autorun", StringComparison.CurrentCultureIgnoreCase)) && !firstRun)
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
                    Application.Run(new MainForm(settings, appDataDir, appSettingsDir, firstRun));
                }

        }
    }
}
