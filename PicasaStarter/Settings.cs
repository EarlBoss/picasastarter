using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;     // Added to use serialisation
using System.IO;                    // Added to use serialisation to file
using System.Collections;           // Test for serialisation
using Microsoft.Win32;              // For manipulating the registry...

namespace PicasaStarter
{
    public class PicasaDB
    {
        private string _name;

        public string Name { get { return _name; } set { _name = value.Trim(new char[] { ' ', '"' }); } }
        public string Description { get; set; }
        public string BaseDir { get; set; }
        public string BackupDir { get; set; }
        public int BackupFrequency { get; set; }
        public bool BackupDBOnly { get; set; }
        public DateTime LastBackupDate { get; set; }
        public string BackupComputerName { get; set; }
        public bool IsStandardDB { get; set; }
        public string PictureVirtualDrive { get; set; }
        public bool EnableVirtualDrive { get; set; }
        public string VirtualDriveBaseDir { get; set; }
        public bool VirtualDrivePathAbsolute { get; set; }

        public PicasaDB()
        {
        }

        public PicasaDB(string name)
        {
            Name = name;
        }

        public PicasaDB(PicasaDB picasaDB)
        {
            Name = picasaDB.Name;
            Description = picasaDB.Description;
            BaseDir = picasaDB.BaseDir;
            BackupDir = picasaDB.BackupDir;
            BackupFrequency = picasaDB.BackupFrequency;
            BackupDBOnly = picasaDB.BackupDBOnly;
            BackupComputerName = picasaDB.BackupComputerName;
            LastBackupDate = picasaDB.LastBackupDate;
            IsStandardDB = picasaDB.IsStandardDB;
            PictureVirtualDrive = picasaDB.PictureVirtualDrive;
            EnableVirtualDrive = picasaDB.EnableVirtualDrive;
            VirtualDriveBaseDir = picasaDB.VirtualDriveBaseDir;
            VirtualDrivePathAbsolute = picasaDB.VirtualDrivePathAbsolute;
        }
    }

    public class PathOnComputer
    {    
        public string ComputerName { get; set; }
        public string Path { get; set; }

        public PathOnComputer()
        {
        }

        public PathOnComputer(string computerName, string exePath)
        {
            ComputerName = computerName;
            Path = exePath;
        }
    }

    public class PathOnComputerCollection
    {
        public List<PathOnComputer> Paths { get; set; }

        public PathOnComputerCollection()
        {
            Paths = new List<PathOnComputer>();
        }

        public void SetPath(PathOnComputer path)
        {
            bool found = false;

            foreach (PathOnComputer curPath in Paths)
            {
                if (curPath.ComputerName == path.ComputerName)
                {
                    curPath.Path = path.Path;
                    found = true;
                    break;
                }
            }

            if (found != true)
                Paths.Add(path);
        }

        public string GetPath(string computerName)
        {
            foreach (PathOnComputer curPath in Paths)
            {
                if (curPath.ComputerName == computerName)
                {
                    return curPath.Path;
                }
            }

            return "";
        }
    }
      
    /// <summary>
    /// This class manages the settings to be used within PicasaStarter.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// The Name of the Picasa database that should be selected by default when starting PicasaStarter.
        /// </summary>
        public string picasaDefaultSelectedDB;

        /// <summary>
        /// The Paths to Picasa.exe that are known. The list contains one path for every computer
        /// PicasaStarter is used on so the settings can be put centrally for different computers. 
        /// 
        /// Remark: this member is put as being public to be able to use the default serializing functionality from .NET.
        /// </summary>
        public PathOnComputerCollection PicasaExePaths = new PathOnComputerCollection();

        /// <summary>
        /// The list of databases defined in PicasaStarter.
        /// </summary>
        [NonSerialized] 
        public List<PicasaDB> picasaDBs = new List<PicasaDB> ();

        /// <summary>
        /// The list of databases defined in PicasaStarter.
        /// </summary>        
        public PicasaButtons picasaButtons = new PicasaButtons();

        /// <summary>
        /// Contstructor of the settings class.
        /// </summary>
        public Settings()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Google\\Picasa\\Picasa2\\Runtime\\");
            string value = (string)key.GetValue("appPath");

            if (string.IsNullOrEmpty(value) == false)
                PicasaExePaths.SetPath(new PathOnComputer(Environment.MachineName, value));
            else
                PicasaExePaths.SetPath(new PathOnComputer(Environment.MachineName, SettingsHelper.ProgramFilesx86() + "\\google\\Picasa3\\picasa3.exe"));
        }

        /// <summary>
        /// Get or Set the Patch where Picasa3.exe can be found on this computer.
        /// 
        /// BugFix: added XmlIgnore so the current path to use isn't serialized to the XML anymore. Bug had as result
        /// that the feature to have a path per computer didn't work: this "last used path" always overruled 
        /// the previously saved path because it was deserialised later than the saved paths.
        /// </summary>
        [XmlIgnore] 
        public string PicasaExePath
        {
            get { return PicasaExePaths.GetPath(Environment.MachineName); }
            set { PicasaExePaths.SetPath(new PathOnComputer(Environment.MachineName, value)); }
        }
    }

    /// <summary>
    /// This class manages the Configuration values in PicasaStarter.
    /// It contains the path to the settings directory, and the Picasa Exe Path on the local PC
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The Directory that holds the PicasaStarterSettings.xml file when starting PicasaStarter.
        /// </summary>
        public string picasaStarterSettingsXMLPath;
        //public string configPicasaExePath;
    }

    public static class SettingsHelper
    {
        public const string SettingsFileName = "PicasaStarterSettings.xml";
        public const string ConfigFileName = "PicasaStarterConfiguration.xml";
        public static string ConfigurationDir = "";
        public static string ConfigPicasaExePath = "";
        public static string PicasaButtons = "PicasaButtons";

        public static string DetermineConfigDir()
        {
            // Determine what directory the Config File will be saved in?
            string configurationDir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);  // Default
            string configDirAppData = Environment.GetEnvironmentVariable("appdata") + "\\PicasaStarter"; // If exe dir read-only
            //Configuration config;

            // Check if the user has the necesarry rights on the default dir
            bool hasNeededRightsOnDefault = false;

            try
            {
                // Write test file to make sure we have the necessary rights...
                File.WriteAllText(configurationDir + "\\testPicasaStarterSettings.txt", "test");
                File.Delete(configurationDir + "\\testPicasaStarterSettings.txt");
                hasNeededRightsOnDefault = true;
            }
            catch (Exception)
            { }

            // If not enough rights... set appSettingDir to appdata...
            if (hasNeededRightsOnDefault == false)
            {
                configurationDir = configDirAppData;
            }
            // If there isn't a config file yet in exe dir, recuperate it from appdata if it exists there...
            // Leave a copy in the apps dir in case there is more than one copy of PicasaStarter on the PC,
            //   and some of those copies are in protected directories.
            else
            {
                if (!File.Exists(configurationDir + "\\" + ConfigFileName))
                {
                    // Get a copy of the Config file  if it exists
                    if (File.Exists(configDirAppData + "\\" + ConfigFileName))
                    {
                        try
                        {
                            File.Copy(configDirAppData + "\\" + ConfigFileName,
                                    configurationDir + "\\" + ConfigFileName);
                            //Directory.Delete(settingsDirAppData);
                        }
                        catch (Exception)
                        { }
                    }
                }
            }
            ConfigurationDir = configurationDir;
            return configurationDir;
        }

        public static string DetermineSettingsDir(string ConfigurationDir)
        {
            // Determine what directory the settings will be saved in?
            string settingsDir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);  // Default
            //string ConfigurationDir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);  // Default
            string settingsDirAppData = Environment.GetEnvironmentVariable("appdata") + "\\PicasaStarter"; // If exe dir read-only
            Configuration config;

            bool hasNeededRightsOnDefault = false;
            try
            {
                config = SettingsHelper.DeSerializeConfig(
                    ConfigurationDir + "\\" + SettingsHelper.ConfigFileName);
                if (config.picasaStarterSettingsXMLPath != "")
                {
                    settingsDir = config.picasaStarterSettingsXMLPath;

                } //else settings dir is the config dir
                else
                {
                    settingsDir = ConfigurationDir;
                }
           }
            catch (Exception) //No Config File
            {
                // Check if the user has the necesary rights on the default dir

                try
                {
                    // Write test file to make sure we have the necessary rights...
                    File.WriteAllText(settingsDir + "\\testPicasaStarterSettings.txt", "test");
                    File.Delete(settingsDir + "\\testPicasaStarterSettings.txt");
                    hasNeededRightsOnDefault = true;
                }
                catch (Exception)
                {}


                // If not enough rights... set appSettingDir to appdata...
                if (hasNeededRightsOnDefault == false)
                {
                    settingsDir = settingsDirAppData;
                }
                // If there isn't a settings file yet in exe dir, recuperate it from appdata if it exists there...
                // Leave a copy in the apps dir in case there is more than one copy of PicasaStarter on the PC,
                //   and some of those copies are in protected directories.
                else
                {
                    if(!File.Exists(settingsDir + "\\" + SettingsFileName))
                    {
                        if (File.Exists(settingsDirAppData + "\\" + SettingsFileName))
                        {
                            try
                            {
                                File.Copy(settingsDirAppData + "\\" + SettingsFileName,
                                        settingsDir + "\\" + SettingsFileName);
                                //Directory.Delete(settingsDirAppData);
                            }
                            catch (Exception)
                            { }
                        }
                    }
                }
            }
            return settingsDir;
        }

        public static PicasaDB GetDefaultPicasaDB()
        {
            PicasaDB picasaDB = new PicasaDB();
            picasaDB.Name = "Personal database of " + Environment.GetEnvironmentVariable("username") + " (=default for picasa)";
            picasaDB.BaseDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            picasaDB.IsStandardDB = true;
            picasaDB.Description = "This is the database Picasa always uses if you don't use Picasa starter. Because of some "
                    + "technical reasons in some situations it is not recommended to share this database. You cannot change any settings "
                    + "for this database either. Create a new one if you want to share a database... and if you want, copy your default "
                    + "one into it.";
            picasaDB.PictureVirtualDrive = "C:";
            picasaDB.EnableVirtualDrive = false;

            return picasaDB;
        }


        public static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        public static void SerializeSettings(Settings settings, string settingsFilePath)
        {
            string NewSettingsText = "";
            string PresentSettingsText = "";

            Directory.CreateDirectory(Path.GetDirectoryName(settingsFilePath));

            try
            {
                // Serialize settings to file
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                using (TextWriter tw = new StreamWriter(settingsFilePath + ".tmp"))
                {
                    serializer.Serialize(tw, settings);
                }
                NewSettingsText = File.ReadAllText(settingsFilePath + ".tmp");
                if(File.Exists(settingsFilePath))
                    PresentSettingsText = File.ReadAllText(settingsFilePath);
                if (NewSettingsText != PresentSettingsText)
                {
                    // Serialize settings to file
                    //XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    using (TextWriter tw = new StreamWriter(settingsFilePath))
                    {
                        serializer.Serialize(tw, settings);
                    }
                }
            }
            catch
            {
            }
            File.Delete(settingsFilePath + ".tmp");
        }
        public static Settings DeSerializeSettings(string settingsFilePath)
        {
            // Deserialize settings
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            Settings settings;
            using (StreamReader tr = new StreamReader(settingsFilePath))
            {
                settings = (Settings)serializer.Deserialize(tr);
            }

            // Loop through the PicasaDB objects to set some things right after deserialising...
            bool defaultDBFound = false;
            for (int i = 0; i < settings.picasaDBs.Count; i++)
            {
                // Overwrite the default DB with the just added version...
                if (settings.picasaDBs[i].IsStandardDB == true)
                {
                    string backupDir = settings.picasaDBs[i].BackupDir;
                    settings.picasaDBs[i] = GetDefaultPicasaDB();
                    settings.picasaDBs[i].BackupDir = backupDir;
                    defaultDBFound = true;
                }

                // NewLine's in an XML file are stored as \n while Windows wants \r\n in it's textboxes,...
                // Because the description can contain newlines... replace them.
                settings.picasaDBs[i].Description = settings.picasaDBs[i].Description.Replace("\n", Environment.NewLine);
            }

            // Loop through the PicasaButton objects to set some things right after deserialising...
            for (int i = 0; i < settings.picasaButtons.ButtonList.Count; i++)
            {
                // NewLine's in an XML file are stored as \n while Windows wants \r\n in it's textboxes,...
                // For all field that can contain newlines... replace them.
                settings.picasaButtons.ButtonList[i].Description = settings.picasaButtons.ButtonList[i].Description.Replace("\n", Environment.NewLine);
                if(!string.IsNullOrEmpty(settings.picasaButtons.ButtonList[i].Script))
                    settings.picasaButtons.ButtonList[i].Script = settings.picasaButtons.ButtonList[i].Script.Replace("\n", Environment.NewLine);
            }

            // Check if the settings contained a PicasaExePath. It will be null if the settings don't contain
            // an entry yet for the Path of this OS type (x86/x64) for this PC.  Set it to likely path if not.
            if (settings.PicasaExePath == "")
                settings.PicasaExePath = (SettingsHelper.ProgramFilesx86() + "\\google\\Picasa3\\picasa3.exe");

            if (defaultDBFound == false)
            {
                settings.picasaDBs.Insert(0, GetDefaultPicasaDB());
            }

            return settings;
        }

        public static void SerializeConfig(Configuration config, string configFilePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(configFilePath));

            // Serialize configuration to file
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            using (TextWriter tw = new StreamWriter(configFilePath))
            {
            serializer.Serialize(tw, config);
            }
        }

        public static Configuration DeSerializeConfig(string configFilePath)
        {
            Configuration config;
            
            // Deserialize Configuration
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            using (TextReader tr = new StreamReader(configFilePath))
            {
                config = (Configuration)serializer.Deserialize(tr);
            }

            return config;
        }

    }
}