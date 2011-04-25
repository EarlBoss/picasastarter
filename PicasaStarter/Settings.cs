using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;     // Added to use serialisation
using System.IO;                    // Added to use serialisation to file
using System.Collections;           // Test for serialisation

namespace PicasaStarter
{
    public class PicasaDB
    {
        private string _name;
        private string _description;
        private string _baseDir;
        private bool _isDefaultDB;

        public string Name { get { return _name; } set { _name = value.Trim(new char[] { ' ', '"' }); } }
        public string Description { get { return _description; } set { _description = value; } }
        public string BaseDir { get { return _baseDir; } set { _baseDir = value; } }
        public bool IsStandardDB { get { return _isDefaultDB; } set { _isDefaultDB = value; } }

        public PicasaDB()
        {
            _name = "";
            _description = "";
            _baseDir = "";
            _isDefaultDB = false;
        }

        public PicasaDB(string name)
        {
            _name = name;
            _description = "";
            _baseDir = "";
            _isDefaultDB = false;
        }
    }


    public class PathOnComputer
    {
        private string _computerName;
        private string _path;
    
        public string ComputerName { get { return _computerName; } set { _computerName = value; } }
        public string Path { get { return _path; } set { _path = value; } }

        public PathOnComputer()
        {
            _computerName = "";
            _path = "";
        }

        public PathOnComputer(string computerName, string exePath)
        {
            _computerName = computerName;
            _path = exePath;
        }
    }

    public class PathOnComputerCollection
    {
        private List<PathOnComputer> _paths = new List<PathOnComputer>();

        public List<PathOnComputer> Paths { get { return _paths; } }

        public void SetPath(PathOnComputer path)
        {
            bool found = false;

            foreach (PathOnComputer curPath in _paths)
            {
                if (curPath.ComputerName == path.ComputerName)
                {
                    curPath.Path = path.Path;
                    found = true;
                    break;
                }
            }

            if (found != true)
                _paths.Add(path);
        }

        public string GetPath(string computerName)
        {
            foreach (PathOnComputer curPath in _paths)
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
        [NonSerialized] public List<PicasaDB> picasaDBs = new List<PicasaDB> ();

        /// <summary>
        /// Contstructor of the settings class.
        /// </summary>
        public Settings()
        {
            PicasaExePaths.SetPath(new PathOnComputer(Environment.MachineName, SettingsHelper.ProgramFilesx86() + "\\google\\Picasa3\\picasa3.exe"));
        }

        /// <summary>
        /// Get or Set the Patch where Picasa3.exe can be found on this computer.
        /// </summary>
        public string PicasaExePath
        {
            get { return PicasaExePaths.GetPath(Environment.MachineName); }
            set { PicasaExePaths.SetPath(new PathOnComputer(Environment.MachineName, value)); }
        }
    }

    public static class SettingsHelper
    {
        public const string SettingsFileName = "PicasaStarterSettings.xml";

        public static string DetermineSettingsDir()
        {
            // Determine what directory the settings will be saved in?
            string settingsDir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);  // Default
            string settingsDirAppData = Environment.GetEnvironmentVariable("appdata") + "\\PicasaStarter"; // If exe dir read-only

            // For backwards compatibility, rename old settings filename to new...
            const string OldSettingsFileName = "Settings.xml";
            if (File.Exists(settingsDir + "\\" + OldSettingsFileName))
                File.Move(settingsDir + "\\" + OldSettingsFileName, settingsDir + "\\" + SettingsFileName);
            if (File.Exists(settingsDirAppData + "\\" + OldSettingsFileName))
                File.Move(settingsDirAppData + "\\" + OldSettingsFileName, settingsDirAppData + "\\" + SettingsFileName);

            // Check if the user has the necesarry rights on the default dir
            bool hasNeededRightsOnDefault = false;

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
            else
            {
                if(!File.Exists(settingsDir + "\\" + SettingsFileName))
                {
                    if(File.Exists(settingsDirAppData + "\\" + SettingsFileName))
                    {
                        try
                        {
                            File.Move(settingsDirAppData + "\\" + SettingsFileName,
                                    settingsDir + "\\" + SettingsFileName);
                            Directory.Delete(settingsDirAppData);
                        }
                        catch (Exception)
                        { }                        
                    }
                }
            }

            return settingsDir;
        }

        public static PicasaDB GetDefaultPicasaDB()
        {
            PicasaDB picasaDB = new PicasaDB();
            picasaDB.Name = "Personal database of " + Environment.GetEnvironmentVariable("username") + " (=default for picasa)";
            picasaDB.BaseDir = Environment.GetEnvironmentVariable("userprofile");
            picasaDB.IsStandardDB = true;
            picasaDB.Description = "This is the database Picasa always uses if you don't use Picasa starter. Because of some "
                    + "technical reasons in some situations it is not recommended to share this database. You cannot change any settings "
                    + "for this database either. Create a new one if you want to share a database... and if you want, copy your default "
                    + "one into it.";

            return picasaDB;
        }

        public static string GetFullDBDirectory(PicasaDB picasaDB)
        {
            string fullDBDirectory;

            // If it is the standard Picasa database, return AppData
            if (picasaDB.IsStandardDB == true)
            {
                string versionSpecificDir;
                if (Environment.OSVersion.Version.Major <= 5)
                    versionSpecificDir = "\\Local Settings\\Application Data";
                else
                    versionSpecificDir = "\\Appdata\\Local\\Google";
                fullDBDirectory = picasaDB.BaseDir + versionSpecificDir;
            }
            else
            {
                fullDBDirectory = picasaDB.BaseDir + "\\Local Settings\\Application Data\\Google";
            }
            return fullDBDirectory;
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
            Directory.CreateDirectory(Path.GetDirectoryName(settingsFilePath));
            
            // Serialize settings to file
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            TextWriter tw = new StreamWriter(settingsFilePath);
            serializer.Serialize(tw, settings);
            tw.Close();
       }

        public static Settings DeSerializeSettings(string settingsFilePath)
        {
            // Deserialize settings
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            TextReader tr = new StreamReader(settingsFilePath);
            Settings settings = (Settings)serializer.Deserialize(tr);
            tr.Close();

            // Overwrite the default DB with the just added version...
            bool defaultDBFound = false;
            for (int i = 0; i < settings.picasaDBs.Count; i++)
            {
                if (settings.picasaDBs[i].IsStandardDB == true)
                {
                    settings.picasaDBs[i] = GetDefaultPicasaDB();
                    defaultDBFound = true;
                }
            }

            if (defaultDBFound == false)
            {
                settings.picasaDBs.Insert(0, GetDefaultPicasaDB());
            }

            return settings;
        }    
    }
}