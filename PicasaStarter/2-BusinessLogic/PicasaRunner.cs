using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;               // Needed for creating a process...
using System.IO;
using System.Windows.Forms;             // Added to be able to show messageboxes
using System.ComponentModel;            // Added to use Win32Exception
using HelperClasses.Logger;             // For logging...
using Microsoft.Win32;                  // Required for reading/writing into the registry:      

namespace PicasaStarter
{
    class PicasaRunner
    {
        public string PicasaExePath { get; private set; }
        public string GoogleAppDir { get; private set; }
        public string AppSettingsDir { get; private set; }
        
        public PicasaRunner(string picasaExePath)
        {
            PicasaExePath = picasaExePath;     //Path from the settings File
        }

        public void RunPicasa(string picasaDBPath, string appSettingsDir)
        {
            AppSettingsDir = appSettingsDir;

            // Check if the executable from settings exists...
            if (!File.Exists(PicasaExePath))
            {
                throw new Exception("Picasa exe not found at: " + PicasaExePath);
            }
            // The user should run Picasa 3.9 or higher... so check file version of the Picasa Exe File
            FileVersionInfo.GetVersionInfo(PicasaExePath);
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(PicasaExePath);
            string Picasaversionstring = myFileVersionInfo.FileVersion.Substring(0, 1) + myFileVersionInfo.FileVersion.Substring(2, 1);
            Int32 picasaversion = Convert.ToInt32(Picasaversionstring);
            if (picasaversion <= 38)
            {
                throw new Exception("PicasaStarter 2.x only supports Picasa 3.9, \n   Please upgrade Picasa from picasa.google.com");
            }
            // Everything seems OK... so go for it!
            FileInfo lockFile = null;
            try
            {
                // Now check the lock file, and create it if it doesn't exist yet...
                DialogResult res = DialogResult.Yes;
                lockFile = GetLockFile(picasaDBPath);
                if (lockFile.Exists)
                {
                    string messageRead = File.ReadAllText(lockFile.FullName);

                    string message = "Running Picasa two times on the same database leads to a corrupted database, so you shouldn't do this! "
                            + "PicasaStarter detected that another Picasa is probably running using this same database:"
                            + Environment.NewLine + Environment.NewLine + messageRead + Environment.NewLine + Environment.NewLine
                            + "If you are really sure this is not the case, you can override this check. So are you sure you want to start Picasa?";
                    res = MessageBox.Show(message, "Are you sure there is no other Picasa running using the same database?",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2,
                            (MessageBoxOptions)0x40000);

                    // If the user isn't sure that there is no other Picasa is running... stop!
                    if (res == DialogResult.No)
                        return;
                }

                string messageToWrite = "That Picasa was started by " + Environment.UserName
                    + " on computer " + Environment.MachineName + " at " + DateTime.Now;
                lockFile.Directory.Create();
                File.WriteAllText(lockFile.FullName, messageToWrite);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating lock file in database path <" + picasaDBPath + ">: "
                        + Environment.NewLine + Environment.NewLine + ex.Message);
                return;
            }
           // Prepare the environment to start Picasa, if a custom db path was provided...
            string originalUserProfile = "";
            string savedUserProfile = "";

            // Check if the user moved the database already using the default functionality of Picasa...
            RegistryKey preferencesKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Google\\Picasa\\Picasa2\\Preferences\\", true);
            originalUserProfile = (string)preferencesKey.GetValue("AppLocalDataPath");
            savedUserProfile = (string)preferencesKey.GetValue("AppLocalDataPathSaved");
            if (savedUserProfile != null) //PS didn't end correctly last time
            {
                // Ask if the user want to restore original database dir
                string userprofilemsg = "Default";
                string originalprofilemsg = "Default";
                if (savedUserProfile != "")
                    userprofilemsg = savedUserProfile;
                if (string.IsNullOrEmpty(originalUserProfile) == false)
                    originalprofilemsg = originalUserProfile;

                DialogResult result = MessageBox.Show(
                        "PicasaStarter may have ended unexpectedly and changed the Picasa database location" +
                        "\nDo you want to restore the original default of: " + userprofilemsg+ " Directory" +
                        "\n\nIf not, the Picasa default directory will remain: " + originalprofilemsg +" Directory" +
                        "\n\nDo you want to restore the original default directory? (YES/NO ", 
                        "Picasa Database Location Problem",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                        (MessageBoxOptions)0x40000);

                // If yes, restore the user profile
                if (result == DialogResult.Yes)
                {
                    //handle a app crash that left a value in the saved key
                    if (savedUserProfile == "")
                    {
                        //originalUserProfile = savedUserProfile;
                        originalUserProfile = null;
                    }
                    else
                    {
                        originalUserProfile = savedUserProfile;
                    }
                }
                else
                {

                }
            }

            if (string.IsNullOrEmpty(originalUserProfile) == false)
            {
                preferencesKey.SetValue("AppLocalDataPathSaved", originalUserProfile);
               // If last character is a \, remove it as directories never end on \ in PS.
               if (originalUserProfile.EndsWith("\\") == true)
                    originalUserProfile = originalUserProfile.Remove(originalUserProfile.Length - 1);
            }
            else
                preferencesKey.SetValue("AppLocalDataPathSaved", "");

            // If no custom path was provided... only init DB so popup doesn't show to scan entire PC...
            if (picasaDBPath == null)
            {
                // This is the path where the Picasa database will be put...
                if (string.IsNullOrEmpty(originalUserProfile) == false)
                    GoogleAppDir = originalUserProfile;
                else
                    GoogleAppDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                
                InitializeDB(GoogleAppDir);
            }
            else
            {
                GoogleAppDir = picasaDBPath;
                InitializeDB(GoogleAppDir);

                // Check if the custom database directory is available, otherwise try to create it...
                try
                {
                    Directory.CreateDirectory(picasaDBPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + ", Path: " + picasaDBPath);
                    lockFile.Delete();
                    return;
                }

                // Add custom DB path to Picasa Registry unless it is default path
                preferencesKey.SetValue("AppLocalDataPath", picasaDBPath + "\\");
            }

            // Set some environment variables for Pre_RunPicasa.bat and Post_RunPicasa.bat
            Environment.SetEnvironmentVariable("PS_PicasaDBGoogleDir", GoogleAppDir);
            Environment.SetEnvironmentVariable("PS_SettingsDir", AppSettingsDir);


            StartBatFile("Pre_RunPicasa.bat");

            // Create a process to launch Picasa in...
            Process picasa = new Process();
            picasa.StartInfo.FileName = PicasaExePath;
            picasa.StartInfo.WorkingDirectory = picasaDBPath;

            try
            {
                // Start picasa...
                picasa.Start();

                // Wait until the process started is finished
                picasa.WaitForExit();

                // Release the resources        
                picasa.Close();

                // Run the Post_RunPicasa.bat script if it exists, for users that want to do some preprocessing before starting Picasa.
                StartBatFile("Post_Runpicasa.bat");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": <" + PicasaExePath + ">");
            }
            finally
            {
                // Remove registry keys for changing database spot...
                preferencesKey.DeleteValue("AppLocalDataPath", false);

                // If the user used move database in picasa before starting to use picasastarter, 
                // Put the key back...
                if (string.IsNullOrEmpty(originalUserProfile) == false)
                    preferencesKey.SetValue("AppLocalDataPath", originalUserProfile + "\\");

               // Get rid of the saved value once PS exits
               preferencesKey.DeleteValue("AppLocalDataPathSaved", false);
               // Delete lock file...
               lockFile.Delete();
            }
        }

        #region private helper functions...

        private void StartBatFile(string fileName)
        {
            // Run the Pre_RunPicasa.bat script if it exists, for users that want to do some preprocessing before starting Picasa.
            try
            {
                // Set some environment variables for Pre_RunPicasa.bat and Post_RunPicasa.bat
                //Environment.SetEnvironmentVariable("PS_PicasaDBGoogleDir", GoogleAppDir);
                //Environment.SetEnvironmentVariable("PS_SettingsDir", AppSettingsDir);
            
                string batFilePreRunPicasa = AppSettingsDir + "\\" + fileName;

                if (File.Exists(batFilePreRunPicasa))
                {
                    Process batFile = System.Diagnostics.Process.Start(batFilePreRunPicasa);
                    // Wait until the process started is finished
                    batFile.WaitForExit();

                    // Release the resources        
                    batFile.Close();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("Error running " + fileName + ": " + ex.Message);
            }
        }

        private FileInfo GetLockFile(string picasaDBPath)
        {
            // Check if a picasa is running already on this database...
            string lockFileDir = picasaDBPath;
            string lockFilePath = lockFileDir + "\\PicasaRunning.txt";

            // If no custom path was provided... search the lock file in userprofile...
            if (picasaDBPath == null)
            {
                lockFileDir = Environment.GetEnvironmentVariable("userprofile");
                lockFilePath = lockFileDir + "\\PicasaRunning.txt";
            }

            return new FileInfo(lockFilePath);
        }

        private void InitializeDB(string googleAppDir)
        {
            // If the DB existst already... don't do anything...
            string PicasaAlbumsDir = googleAppDir + "\\Google\\Picasa2Albums";
            string PicasaDBDir = googleAppDir + "\\Google\\Picasa2";
            if (Directory.Exists(PicasaAlbumsDir))
                return;
            
            // Ask if the user want the popup to let Picasa scan the computer...
            DialogResult result = MessageBox.Show(
                    "Do you want to let Picasa search for all your images on your computer?" +
                    "\n\nIf not, you need to add the folders you want to be scanned by Picasa using " +
                    "\"File\"/\"Add folder to Picasa\".", "Do you want to let Picasa search your images?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
                    (MessageBoxOptions)0x40000);

            // If yes, nothing more to do...
            if (result == DialogResult.Yes)
                return;

            // Otherwise, initialise the necessary files so the popup for choosing doesn't show...
            Directory.CreateDirectory(PicasaAlbumsDir);
            File.WriteAllText(PicasaAlbumsDir + "\\watchedfolders.txt", "");
            File.WriteAllText(PicasaAlbumsDir + "\\frexcludefolders.txt", "");
            if (!Directory.Exists(PicasaDBDir + "\\db3"))
                Directory.CreateDirectory(PicasaDBDir + "\\db3");
            File.WriteAllBytes(PicasaDBDir + "\\db3\\thumbs_index.db", Properties.Resources.thumbs_index);
        }

        #endregion

    }
}