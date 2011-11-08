using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;               // Needed for creating a process...
using System.IO;
using System.Windows.Forms;             // Added to be able to show messageboxes
using System.ComponentModel;            // Added to use Win32Exception
using HelperClasses;                    // Needed to make symbolic links,...
using HelperClasses.Logger;             // For logging...

namespace PicasaStarter
{
    class PicasaRunner
    {
        public string PicasaExePath { get; private set; }
        public string SymlinkBaseDir { get; private set; }
        public string PicasaDBBasePath { get; private set; }
        public string GoogleAppDir { get; private set; }
        public string AppSettingsDir { get; private set; }

        public PicasaRunner(string symlinkBaseDir, string picasaExePath)
        {
            SymlinkBaseDir = symlinkBaseDir;
            PicasaExePath = picasaExePath;     //Path from the settings File
        }

        public void RunPicasa(string customDBBasePath, string appSettingsDir)
        {
            PicasaDBBasePath = customDBBasePath;
            AppSettingsDir = appSettingsDir;

            // Check if the executable from settings exists...
            if (!File.Exists(PicasaExePath))
            {
                //Saved path doesn't exist, try Path from local Config File
                PicasaExePath = (SettingsHelper.ConfigPicasaExePath);
            }
            if (!File.Exists(PicasaExePath))
            {
                //Saved path doesn't exist, try default for this OS
                PicasaExePath = (SettingsHelper.ProgramFilesx86() + "\\google\\Picasa3\\picasa3.exe");
            }
            if (!File.Exists(PicasaExePath))
            {
                MessageBox.Show("Picasa executable isn't found here: " + PicasaExePath);
                return;
            }

            FileInfo lockFile = null;
            try
            {
                // Now check the lock file, and create it if it doesn't exist yet...
                DialogResult res = DialogResult.Yes;
                lockFile = GetLockFile();
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
                MessageBox.Show("Error creating lock file in database path <" + PicasaDBBasePath + ">: " 
                        + Environment.NewLine + Environment.NewLine + ex.Message);
                return;
            }

            // Prepare the environment to start Picasa, if a custom db path was provided...
            string originalUserProfile;
            originalUserProfile = "";

            // This information is needed if running from a localized (non-english) XP.
            string localAppDataXPEngPart1 = "\\Local Settings";
            string localAppDataXPEngPart2 = "\\Application Data";
            string localAppDataXPLocalPart1 = "";
            string localAppDataXPLocalPart2 = "";
            bool isLocalizedXP = false;
            
            // If no custom path was provided... only init DB so popup doesn't show to scan entire PC...
            if (PicasaDBBasePath == null)
            {
                // This is the path where the Picasa database will be put...
                GoogleAppDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google";

                this.InitializeDB(GoogleAppDir);
                this.StartBatFile("Pre_RunPicasa.bat");
            }
            else
            {
                string tmpUserProfile;

                // Default database path is the path for Windows XP. Needed for mixed systems.
                string CustomDBFullPath = PicasaDBBasePath + localAppDataXPEngPart1 + localAppDataXPEngPart2;
                GoogleAppDir = CustomDBFullPath + "\\Google";

                this.InitializeDB(GoogleAppDir);

                // If we are running on a Windows XP with a non-default language, we need to adapt the 
                // path where the Picasa database is stored...
                if (Environment.OSVersion.Version.Major <= 5)
                {
                    string fullLocalAppDataLocalized = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string[] splitted = fullLocalAppDataLocalized.Split(new Char[] { '\\' });

                    if (splitted.Length <= 2)
                    {
                        MessageBox.Show("Error getting LocalAppData directory:" + fullLocalAppDataLocalized);
                    }

                    localAppDataXPLocalPart1 = "\\" + splitted[splitted.Length - 2];
                    localAppDataXPLocalPart2 = "\\" + splitted[splitted.Length - 1];

                    // Check if it is a localized version of windows that is running...
                    if (localAppDataXPLocalPart1 != localAppDataXPEngPart1
                            || localAppDataXPLocalPart2 != localAppDataXPEngPart2)
                    {
                        isLocalizedXP = true;
                        CustomDBFullPath = PicasaDBBasePath + localAppDataXPLocalPart1 + localAppDataXPLocalPart2;

                        // If we are working on a localized XP, check if an "english" directory exists...
                        // and rename it to the localized dir if so...
                        try
                        {
                            if (Directory.Exists(PicasaDBBasePath + localAppDataXPEngPart1 + localAppDataXPEngPart2))
                            {
                                Directory.CreateDirectory(PicasaDBBasePath + localAppDataXPLocalPart1);
                                Directory.Move(PicasaDBBasePath + localAppDataXPEngPart1 + localAppDataXPEngPart2,
                                        PicasaDBBasePath + localAppDataXPLocalPart1 + localAppDataXPLocalPart2);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message + ", Path: " + CustomDBFullPath);
                            lockFile.Delete();
                            return;
                        }
                    }
                }

                // Check if the custom database directory is available, otherwise try to create it...
                try
                {
                    Directory.CreateDirectory(CustomDBFullPath);
                    // Otherwise Export functionality gives error
                    Directory.CreateDirectory(PicasaDBBasePath + "\\Desktop");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + ", Path: " + CustomDBFullPath);
                    lockFile.Delete();
                    return;
                }

                // If we are running on Windows XP, we let Picasa use DBPath as userprofile
                if (Environment.OSVersion.Version.Major <= 5)
                {
                    tmpUserProfile = PicasaDBBasePath;
                }

                // Starting from Vista or higher, create temporary symbolic links to point to the DBPath, and the 
                // environment variables have to point to the symbolic links...
                // This way we can always put the picasa database in a structure as required by windows XP
                // so you can have windows xp computers and windows vista + computers sharing a database.
                else
                {
                    // Create the directory to put the symlink, if he doesn't exist
                    string symLinkBaseDir = SymlinkBaseDir + "\\" + CustomDBFullPath.Replace('\\', '_').Replace(':', '_');
                    string symLinkDir = symLinkBaseDir + "\\Appdata";

                    try
                    {
                        Directory.CreateDirectory(symLinkDir);
                        // Otherwise Export functionality gives error
                        Directory.CreateDirectory(symLinkBaseDir + "\\Desktop");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message + ", Path: " + symLinkDir);
                        lockFile.Delete();
                        return;
                    }

                    // Create the symlink
                    string symLinkPath = symLinkDir + "\\Local";
                    string symLinkDest = CustomDBFullPath;

                    // If the symbolic link is actually a normal directory, rename it...
                    // REMARK: Included because an buggy version of PicasaStarter created a dir instead of a symlink is some occasions...
                    if (Directory.Exists(symLinkPath))
                    {
                        // If the file is a reparse point (or symbolic link)... OK
                        if ((File.GetAttributes(symLinkPath) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                        {
                            Directory.Move(symLinkPath, symLinkPath + "_OLD");
                        }
                    }

                    // If symlink doesn't exist
                    if (!Directory.Exists(symLinkPath))
                    {
                        //Create Symlink
                        try
                        {
                            IOHelper.CreateSymbolicLink(symLinkPath, symLinkDest, true);
                        }
                        catch (Win32Exception ex)
                        {
                            // If the code says the user doesn't have enough privileges, or in Windows 7 he gives another stupid fault, 
                            // try with elevated rights...)

                            if ((ex.NativeErrorCode == 1314)
                                || (ex.NativeErrorCode == 2))
                            {

                                MessageBox.Show("The first time you use a custom database, PicasaStarter needs more privileges to initialise some things. "
                                        + "In the next popup you will be asked if you want to allow this...", "Ask For Admin Privileges",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                                        (MessageBoxOptions)0x40000);      // specify MB_TOPMOST 
                                try
                                {
                                    // Create a process to launch Picasa in...
                                    Process createSymLink = new Process();
                                    createSymLink.StartInfo.FileName = Application.ExecutablePath;
                                    createSymLink.StartInfo.Verb = "runas";
                                    createSymLink.StartInfo.Arguments = "/CreateSymbolicLink \"" + symLinkPath + "\" \"" + symLinkDest + "\"";
                                    createSymLink.Start();

                                    // Wait until the process started is finished
                                    createSymLink.WaitForExit();

                                    // Release the resources        
                                    createSymLink.Close();
                                }
                                catch
                                {
                                    MessageBox.Show("Administrative Privileges Not Allowed By Operator", "Symlink Not Created",
                                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                                            (MessageBoxOptions)0x40000);      // specify MB_TOPMOST 
                                    return;
                                }

                            }
                            else
                            {
                                MessageBox.Show("There was an error creating the necessary symbolic link. Try this procedure please:\n1) Close PicasaStarter\n2) Run PicasaStarter once as administrator and click \"Run Picasa\" with this database", "Symlink Not Created",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                                        (MessageBoxOptions)0x40000);      // specify MB_TOPMOST 
                                return;
                            }
                        }
                    }

                    // To be sure, check again before continuing...
                    if (!Directory.Exists(symLinkPath))
                    {
                        MessageBox.Show("There was an error creating the necessary symbolic link. Try this procedure please:\n1) Close PicasaStarter\n2) Run PicasaStarter once as administrator and click \"Run Picasa\" with this database", "Symlink Not Created",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, 
                                (MessageBoxOptions)0x40000);      // specify MB_TOPMOST 
                        return;
                    }
                    // To finish, the userprofile will be put to the picasaRunTempPath. 
                    // The symlink will route it to the proper DBPath
                    tmpUserProfile = symLinkBaseDir;
                }

                if (Environment.OSVersion.Version.Major < 5 || Environment.OSVersion.Version.Major > 7)
                {
                    MessageBox.Show("Picasastarter wasn't tested on Windows version "
                            + Environment.OSVersion.Version.Major + Environment.NewLine + Environment.NewLine
                            + "Not sure if it is going to work");
                }

                // Backup userprofile environment variable and overwrite with DB path...
                originalUserProfile = Environment.GetEnvironmentVariable("userprofile");
                Environment.SetEnvironmentVariable("userprofile", tmpUserProfile);
            
            }

            StartBatFile("Pre_RunPicasa.bat");

            // Create a process to launch Picasa in...
            Process picasa = new Process();
            picasa.StartInfo.FileName = PicasaExePath;
            picasa.StartInfo.WorkingDirectory = PicasaDBBasePath;

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
                // Cleanup userprofile environment variable...
                if (PicasaDBBasePath != null)
                {
                    Environment.SetEnvironmentVariable("userprofile", originalUserProfile);
                }

                // Rename DB directory to english on a localized Windows XP...
                if (isLocalizedXP == true)
                {
                    DialogResult result = DialogResult.Retry;
                    string caption = "";
                    int tryCount = 0;

                    // Try several times, as it is possible that there is a delay on slow NAS devices...
                    while (result == DialogResult.Retry)
                    {
                        tryCount++;

                        try
                        {
                            // Be sure that the english version exists...
                            caption = "Create English Dir failed";
                            Directory.CreateDirectory(PicasaDBBasePath + localAppDataXPEngPart1);

                            // Move and rename the localized directory...
                            caption = "Localized Database Move Failure";
                            Directory.Move(PicasaDBBasePath + localAppDataXPLocalPart1 + localAppDataXPLocalPart2,
                                    PicasaDBBasePath + localAppDataXPEngPart1 + localAppDataXPEngPart2);
                            result = DialogResult.Cancel;
                        }
                        catch (Exception ex)
                        {
                            // Every 8 tries, ask the user if he wants to continue trying...
                            if (tryCount % 8 == 0)
                            {
                                // Ask operator to retry if there was an error
                                string message = "In XP, the localized database path could not be renamed to English. \n The error was: " + ex.Message +
                                    "\nLocalized Path: " + PicasaDBBasePath + localAppDataXPLocalPart1 + localAppDataXPLocalPart2 +
                                    "\nEnglish Path:   " + PicasaDBBasePath + localAppDataXPEngPart1 + localAppDataXPEngPart2 +
                                    "\n\nPush RETRY to try again, or push CANCEL to exit";

                                result = MessageBox.Show(message, caption, MessageBoxButtons.RetryCancel,
                                            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
                                            (MessageBoxOptions)0x40000);
                            }

                            System.Threading.Thread.Sleep(500); // wait .5 seconds for each retry
                        }                      
                    }
                }
                
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
                Environment.SetEnvironmentVariable("PS_PicasaDBGoogleDir", GoogleAppDir + "\\Google");
                Environment.SetEnvironmentVariable("PS_SettingsDir", AppSettingsDir);
            
                FileInfo picasaStarterExeFile = new FileInfo(Application.ExecutablePath);
                string batFilePreRunPicasa = picasaStarterExeFile.DirectoryName + fileName;
                if (File.Exists(batFilePreRunPicasa))
                    System.Diagnostics.Process.Start(batFilePreRunPicasa);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("Error running " + fileName + ": " + ex.Message);
            }
        }

        private FileInfo GetLockFile()
        {
            // Check if a picasa is running already on this database...
            string lockFileDir = PicasaDBBasePath;
            string lockFilePath = lockFileDir + "\\PicasaRunning.txt";

            // If no custom path was provided... search the lock file in userprofile...
            if (PicasaDBBasePath == null)
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
        #endregion

    }
}
