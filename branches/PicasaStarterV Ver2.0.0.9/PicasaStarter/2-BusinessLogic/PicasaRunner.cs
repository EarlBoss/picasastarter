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
        
        public PicasaRunner(string symlinkBaseDir, string picasaExePath)
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
            Single picasaversion = Convert.ToSingle(myFileVersionInfo.FileVersion.Substring(0, 3));
            if (picasaversion <= 3.85)
            {
                throw new Exception("PicasaStarter 2.x only supports Picasa 3.9 and higher... Please upgrade Picasa from picasa.google.com");
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

            // Check if the user moved the database already using the default functionality of Picasa...
            RegistryKey preferencesKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Google\\Picasa\\Picasa2\\Preferences\\", true);
            originalUserProfile = (string)preferencesKey.GetValue("AppLocalDataPath");

            if (string.IsNullOrEmpty(originalUserProfile) == false)
            {
                MessageBox.Show("Picasa Database Directory was not at it's default location when PicasaStarter was started, " +
                                "It may have been moved by the Experimental Move Database Location command in Picasa or PicasaStarter " +
                                "may have exited unexpectedly. When Picasa exits this time the default location will be restored, but " +
                                "if database was moved with the Experimental command, the database may need to be restored manually from:\n " +
                                originalUserProfile + "  to the default User's  \\Application Data\\Google\\  directory",
                                "Picasa Database Not at Default Location",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                        (MessageBoxOptions)0x40000);      // specify MB_TOPMOST 
            }

            // Remove any registry key left in error
            preferencesKey.DeleteValue("AppLocalDataPath", false);
            // Remove any move database registry key
            preferencesKey.DeleteValue("AppLocalDataPathCopy", false);

            // If no custom path was provided... only init DB so popup doesn't show to scan entire PC...
            if (picasaDBPath == null)
            {
                // This is the path where the Picasa database will be put...
                GoogleAppDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google";
                InitializeDB(GoogleAppDir);
            }
            else
            {
                GoogleAppDir = picasaDBPath + "\\Google";
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
                preferencesKey.DeleteValue("AppLocalDataPathCopy", false);

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
                Environment.SetEnvironmentVariable("PS_PicasaDBGoogleDir", GoogleAppDir);
                Environment.SetEnvironmentVariable("PS_SettingsDir", AppSettingsDir);
            
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
            string PicasaAlbumsDir = googleAppDir + "\\Picasa2Albums";
            string PicasaDBDir = googleAppDir + "\\Picasa2";
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

/* Pieter: I don't think they are necessary, as they don't decrease the number of lines in code and makes the 
 * code slightly more difficult to read I think... Also swallows all exceptions, which is a risk...

        //Registry Key Functions
        
		private string subKey = "SOFTWARE\\Google\\Picasa\\Picasa2\\Preferences";
		/// <summary>
		/// A property to set the SubKey value
		/// (default = "SOFTWARE\\" + Application.ProductName.ToUpper())
		/// </summary>
		public string SubKey
		{
			get { return subKey; }
			set	{ subKey = value; }
		}

		private RegistryKey baseRegistryKey = Registry.CurrentUser;
		/// <summary>
		/// A property to set the BaseRegistryKey value.
		/// (default = Registry.LocalMachine)
		/// </summary>
		public RegistryKey BaseRegistryKey
		{
			get { return baseRegistryKey; }
			set	{ baseRegistryKey = value; }
		}

		/// <summary>
		/// To read a registry key.
		/// input: KeyName (string)
		/// output: value (string) 
		/// </summary>
		public string ReadKey(string KeyName)
		{
			// Opening the registry key
			RegistryKey rk = baseRegistryKey ;
			// Open a subKey as read-only
			RegistryKey sk1 = rk.OpenSubKey(subKey);
			// If the RegistrySubKey doesn't exist -> (null)
			if ( sk1 == null )
			{
				return null;
			}
			else
			{
				try 
				{
					// If the RegistryKey exists I get its value
					// or null is returned.
					return (string)sk1.GetValue(KeyName.ToUpper());
				}
				catch (Exception)
				{
					// AAAAAAAAAAARGH, an error!
					return null;
				}
			}
		}	

		/// <summary>
		/// To write into a registry key.
		/// input: KeyName (string) , Value (object)
		/// output: true or false 
		/// </summary>
		public bool WriteKey(string KeyName, object Value)
		{
			try
			{
				// Setting
				RegistryKey rk = baseRegistryKey ;
				// I have to use CreateSubKey 
				// (create or open it if already exits), 
				// 'cause OpenSubKey open a subKey as read-only
				RegistryKey sk1 = rk.CreateSubKey(subKey);
				// Save the value
				sk1.SetValue(KeyName.ToUpper(), Value);

				return true;
			}
			catch (Exception)
			{
				// AAAAAAAAAAARGH, an error!
				return false;
			}
		}

		/// <summary>
		/// To delete a registry key.
		/// input: KeyName (string)
		/// output: true or false 
		/// </summary>
		public bool DeleteKey(string KeyName)
		{
			try
			{
				// Setting
				RegistryKey rk = baseRegistryKey ;
				RegistryKey sk1 = rk.CreateSubKey(subKey);
				// If the RegistrySubKey doesn't exists -> (true)
				if ( sk1 == null )
					return true;
				else
					sk1.DeleteValue(KeyName);

				return true;
			}
			catch (Exception)
			{
				// AAAAAAAAAAARGH, an error!
				return false;
			}
		}
*/
        #endregion

    }
}