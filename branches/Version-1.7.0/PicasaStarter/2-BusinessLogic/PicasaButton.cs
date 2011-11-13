using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ionic.Zip;

namespace PicasaStarter
{
    public class PicasaButton
    {
        public string ButtonID { get; set; }
        public int Version { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string ToolTipText { get; set; }
        public byte[] Icon { get; set; }
        public string IconLayer { get; set; }

        public ExecType ExecutionType = ExecType.Executable;
        public string ExeDirRegKey { get; set; }
        public string ExeDir { get; set; }
        public string ExeFileName { get; set; }
        public string Script { get; set; }

        public bool ExecuteForeach { get; set; }
        public bool ExportFirst { get; set; }

        public enum ExecType
        {
            Executable = 1,
            Script = 2
        }

        public PicasaButton()
        {
        }

/*        
        public bool SetIcon(string fileName)
        {
            PsdFile psdFile = new PsdFile();

            psdFile.Load(fileName);
            return true;
        }
*/
        /// <summary>
        /// Can throw exceptions
        /// </summary>
        /// <param name="destDirectory"></param>
        /// <param name="isButtonForDefaultDB">If true, a script button will always point to the script in the default Picasa database.</param>
        /// <returns></returns>
        public bool CreateButtonFile(string destDirectory, bool isButtonForDefaultDB = false)
        {
            // Init correct paths
            string pbfFilePath = System.IO.Path.GetTempPath() + "PicasaStarter\\" + ButtonID + ".pbf";
            string psdFilePath = System.IO.Path.GetTempPath() + "PicasaStarter\\" + ButtonID + ".psd";
            string scriptFilePath = destDirectory + '\\' + "PS_Button" + Label + ".bat";
            FileInfo pbzFile = new FileInfo(destDirectory + '\\' + "PS_Button" + Label + ".pbz");
            if (!pbzFile.Directory.Exists)
                pbzFile.Directory.Create();
            
            // Prepare source files
            this.WritePBF(pbfFilePath, destDirectory, isButtonForDefaultDB);

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

            if (ExecutionType == ExecType.Script)
                File.WriteAllText(scriptFilePath, Script);

            // Cleanup temp files...
            File.Delete(pbfFilePath);
            File.Delete(psdFilePath);

            return true;
        }

        private void WritePBF(string pbfFilePath, string pbzDir, bool isButtonForDefaultDB)
        {
            // Some variables need some preprocessing before using them in the xml field...
            int foreach_field = (ExecuteForeach == true) ? 1 : 0;  // If true: 1, else: 0
            int export_field = (ExportFirst == true) ? 1 : 0;   // If true: 1, else: 0

            string exe_name_field= "";
            string exe_path_regkey = "";

            if (ExecutionType == ExecType.Executable)
            {
                exe_name_field = ExeDir + '\\' + ExeFileName;
                exe_path_regkey = ExeDirRegKey;
            }
            else
            {
                // If the button is for a default DB, create it so it always searches its script in %LOCALAPPDATA%\...
                if (isButtonForDefaultDB == true)
                {
                    exe_name_field = "\\Google\\Picasa2\\buttons\\PS_Button" + Label + ".bat";
                    exe_path_regkey = "HKEY_CURRENT_USER\\Volatile Environment\\LOCALAPPDATA";
                }
                else
                {
                    exe_name_field = pbzDir + "\\PS_Button" + Label + ".bat";
                }
            }

            string xml = "";
            xml += "<?xml version='1.0' encoding='utf-8' ?>" + Environment.NewLine;
            xml += "<buttons format='1' version='" + Version + "'>" + Environment.NewLine;
            xml += "  <button id='" + ButtonID + "' type='dynamic'>" + Environment.NewLine;
            xml += "    <label>" + Label + "</label>" + Environment.NewLine;
            xml += "    <icon name='" + ButtonID + "/" + IconLayer + "' src='pbz'/>" + Environment.NewLine;
            xml += "    <tooltip>" + ToolTipText + "</tooltip>" + Environment.NewLine;
            xml += "    <action verb='trayexec'>" + Environment.NewLine;
            xml += "      <param name='exe_name' value='" + exe_name_field + "'/>" + Environment.NewLine;

            if (exe_path_regkey != "")
                xml += "      <param name='exe_path_regkey' value='" + exe_path_regkey + "'/>" + Environment.NewLine;

            xml += "      <param name='foreach'  value='" + foreach_field + "'/>" + Environment.NewLine;
            xml += "      <param name='export'  value='" + export_field + "'/>" + Environment.NewLine;
            xml += "    </action>" + Environment.NewLine;
            xml += "  </button>" + Environment.NewLine;
            xml += "</buttons>";

            File.WriteAllText(pbfFilePath, xml);
        }

        public string pbzDir { get; set; }
    }
}
