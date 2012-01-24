using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ionic.Zip;
using HelperClasses;

namespace PicasaStarter
{
    public class PicasaButton
    {
#region Properties

        public string ButtonID { get; set; }
        public int Version { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string ToolTipText { get; set; }

        /// <summary>
        /// Bytestream of the .psd file containing the icon.
        /// </summary>
        public byte[] Icon { get; set; }

        /// <summary>
        /// Layer containing the icon in the .psd file in "Icon" property. If you specify an icon, this property is mandatory.
        /// </summary>
        public string IconLayer { get; set; }

        /// <summary>
        /// Is the button executing an executable directly or is it starting a script
        /// </summary>
        public ExecType ExecutionType = ExecType.Executable;
        
        /// <summary>
        /// Registry key that contains the entire path to the executable. If this is specified, 
        /// all other "exe..." properties are ignored.
        /// </summary>
        public string ExeFileRegKey { get; set; }
        
        /// <summary>
        /// Registry key that contains the directory to the executable. If you specify ExeDir as well, the content in ExeDir 
        /// will be interpreted as a relative path starting from the directory in the registry key.
        /// </summary>        
        public string ExeDirRegKey { get; set; }
        
        public string ExeDir { get; set; }
        /// <summary>
        /// The file name of the executable.
        /// </summary>
        public string ExeFileName { get; set; }

        /// <summary>
        /// The script to be executed when pushing the button. Must be written as a windows batch file.
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// If true, Picasa will run the exe/script for every selected file seperatly when pushing the button.
        /// If false, Picasa will turn the exe/script once and pass all filenames as command line parameters.
        /// </summary>
        public bool ExecuteForeach { get; set; }

        /// <summary>
        /// If true, Picasa wil export the selected images first to a temporary location before starting the exe/script.
        /// If false, the current files will be passed to the exe/script.
        /// </summary>
        public bool ExportFirst { get; set; }

        public enum ExecType
        {
            /// <summary>
            /// If the button starts an executable, you need to specify one or more of the "Exe..." properties.
            /// </summary>
            Executable = 1,
            /// <summary>
            /// If the button starts a script, the "Exe..." properties are not used, but you need to put the batch script in the "Script" property.
            /// </summary>
            Script = 2
        }

#endregion

#region Methods

        public PicasaButton()
        {
        }

        /// <summary>
        /// Can throw exceptions
        /// </summary>
        /// <param name="destDirectory">Directory where the button file should be placed.</param>
        /// <param name="scriptDir">Directory where the script should be placed.</param>
        /// <returns></returns>
        public bool CreateButtonFile(string destDirectory, string scriptDir = "C:\\Tools\\PicasaScripts")
        {
            // Init correct paths
            string pbfFilePath = System.IO.Path.GetTempPath() + "PicasaStarter\\" + ButtonID + ".pbf";
            string psdFilePath = System.IO.Path.GetTempPath() + "PicasaStarter\\" + ButtonID + ".psd";
            string scriptFileName = "PS_Button" + Label + ".bat";
            string scriptFilePath = scriptDir + "\\" + scriptFileName;
            
            FileInfo pbzFile = new FileInfo(destDirectory + '\\' + "PS_Button" + Label + ".pbz");
            if (!pbzFile.Directory.Exists)
                pbzFile.Directory.Create();

            // Prepare source files
            this.WritePBF(pbfFilePath, destDirectory, scriptFilePath);

            // If an Icon was specified... copy and rename it to the right name...
            if (Icon != null && Icon.Length > 0)
                File.WriteAllBytes(psdFilePath, Icon);

            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(pbfFilePath, "");
                if (Icon != null && Icon.Length > 0)
                    zip.AddFile(psdFilePath, "");
                zip.Save(pbzFile.FullName);
                zip.Dispose();
            }

            // If it is a script button... write the script if necessary...
            if (ExecutionType == ExecType.Script)
            {
                if (!Directory.Exists(scriptDir))
                    Directory.CreateDirectory(scriptDir);

                // If script exists already, check if it was changed in any way...
                if (File.Exists(scriptFilePath))
                {
                    string existingScript = File.ReadAllText(scriptFilePath);

                    if (existingScript != Script)
                    {
                        string scriptBackupDir = scriptDir + "\\Backup";
                        if (!Directory.Exists(scriptBackupDir))
                            Directory.CreateDirectory(scriptBackupDir);

                        File.Move(scriptFilePath, IOHelper.MakeFilenameUnique(scriptBackupDir + "\\" + scriptFileName, false));
                        File.WriteAllText(scriptFilePath, Script);
                    }
                }
                else
                    File.WriteAllText(scriptFilePath, Script);
            }

            // Cleanup temp files...
            File.Delete(pbfFilePath);
            File.Delete(psdFilePath);

            return true;
        }

        private void WritePBF(string pbfFilePath, string pbzDir, string scriptPath)
        {
            // Some variables need some preprocessing before using them in the xml field...
            int foreach_field = (ExecuteForeach == true) ? 1 : 0;  // If true: 1, else: 0
            int export_field = (ExportFirst == true) ? 1 : 0;   // If true: 1, else: 0

            string exe_name_field = "", exe_name_regkey = "", exe_path_regkey = "";

            if (ExecutionType == ExecType.Executable)
            {
                exe_name_regkey = ExeFileRegKey;
                exe_name_field = ExeDir + '\\' + ExeFileName;
                exe_path_regkey = ExeDirRegKey;
            }
            else
            {
                // If the button is for a default DB, create it so it always searches its script in %LOCALAPPDATA%\...
                if (string.IsNullOrEmpty(scriptPath) == false)
                    exe_name_field = scriptPath;
                else
                    throw new Exception("No script path passed for a script button...");
            }

            string xml = "";
            xml += "<?xml version='1.0' encoding='utf-8' ?>" + Environment.NewLine;
            xml += "<buttons format='1' version='" + Version + "'>" + Environment.NewLine;
            xml += "  <button id='" + ButtonID + "' type='dynamic'>" + Environment.NewLine;
            xml += "    <label>" + Label + "</label>" + Environment.NewLine;
            xml += "    <icon name='" + ButtonID + "/" + IconLayer + "' src='pbz'/>" + Environment.NewLine;
            xml += "    <tooltip>" + ToolTipText + "</tooltip>" + Environment.NewLine;
            xml += "    <action verb='trayexec'>" + Environment.NewLine;

            // The exe file name fields sometimes need to be there, sometimes they don't...
            if (exe_name_regkey != "")
                xml += "      <param name='exe_name_regkey' value='" + exe_name_regkey + "'/>" + Environment.NewLine;
            else
            {
                xml += "      <param name='exe_name' value='" + exe_name_field + "'/>" + Environment.NewLine;

                if (exe_path_regkey != "")
                    xml += "      <param name='exe_path_regkey' value='" + exe_path_regkey + "'/>" + Environment.NewLine;
            }

            xml += "      <param name='foreach'  value='" + foreach_field + "'/>" + Environment.NewLine;
            xml += "      <param name='export'  value='" + export_field + "'/>" + Environment.NewLine;
            xml += "    </action>" + Environment.NewLine;
            xml += "  </button>" + Environment.NewLine;
            xml += "</buttons>";

            File.WriteAllText(pbfFilePath, xml);
        }

#endregion

    }
}
