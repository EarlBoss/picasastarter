using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;           // Needed for working with process...
using System.IO;

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

            Settings settings;
            bool firstRun = false;

            // Initialisations: create temp dir, load settings,...
            //---------------------------------------------------------------------------
            appSettingsDir = SettingsHelper.DetermineSettingsDir();

            // Create temp dir and load settings... 
            try
            {
                settings = SettingsHelper.DeSerializeSettings(
                    appSettingsDir + "\\" + SettingsHelper.SettingsFileName);
            }
            catch (Exception)
            {
                // If the settings couldn't be loaded, create new empty settings object, but add default picasa database...
                settings = new Settings();
                settings.picasaDBs.Add(SettingsHelper.GetDefaultPicasaDB());
                firstRun = true;
            }

            // Process command line arguments...
            //---------------------------------------------------------------------------
            bool showGUI = true;
            string autoRunDatabaseName = null;

            for (int i = 1 ; i < Environment.GetCommandLineArgs().Length ; i++ )
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
                        autoRunDatabaseName = autoRunDatabaseName.Trim(new char[] { '"', ' ' } );
                    }
                    else
                    {
                        MessageBox.Show("The /autorun directive should be followed by an existing Picasa database name or \"Personal\"");
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
                        MessageBox.Show("The /CreateSymbolicLink directive should be followed by a valid path name and the destination path");
                    }

                    IOHelper.CreateSymbolicLink(symLinkPath, symLinkDest, true);
                }
                else
                {
                    MessageBox.Show("Invalid command line parameter: " + arg);
                }
            }

            // If /autorun argument was passed...
            //---------------------------------------------------------------------------
            if (autoRunDatabaseName != null)
            {
                // First check if he wants to run with the standard personal database...
                if (autoRunDatabaseName.Equals("personal", StringComparison.CurrentCultureIgnoreCase))
                {
                    // If the user wants to run his personal default database... (cmd line arg was "personal") 
                    PicasaRunner runner = new PicasaRunner(appDataDir, settings.PicasaExePath);
                    runner.RunPicasa(null);
                }
                else
                {
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
                            runner.RunPicasa(null);
                        // If the user wants to run a custom database...
                        else
                        {
                            if (Directory.Exists(foundDB.BaseDir))
                                runner.RunPicasa(foundDB.BaseDir);
                            else
                                MessageBox.Show("The base directory of this database doesn't exist or you didn't choose one yet.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The database passed with the /autorun parameter was not found: " + autoRunDatabaseName);
                        autoRunDatabaseName = null;
                    }
                }
            }

            if (showGUI == true)
            {
                Application.Run(new MainForm(settings, appDataDir, appSettingsDir, firstRun));
            }
            else
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
                    MessageBox.Show("Ss Error saving settings: " + ex.Message);
                }
            }
        }
    }
}
