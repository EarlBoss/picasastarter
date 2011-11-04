using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ionic.Zip;

namespace PicasaStarter
{
    public class PicasaButton
    {
        public string ButtonID = null;
        public int Version = 1;
        public string Label = "Label";
        public string Description = "";
        public string ToolTipText = "Tooltip";
        public byte[] Icon = null;
        public string IconLayer = null;

        public ExecType ExecutionType = ExecType.Executable; 
        public string ExeFilePath = null;
        public string ExeArguments = null;
        public string Script = "";

        public bool ExecuteForeach = false;
        public bool ExportFirst = false;

        public enum ExecType
        {
            Executable = 1,
            Script = 2
        }

        public PicasaButton()
        {
        }

        public bool CreateButtonFile(string destDirectory)
        {
            // Init correct paths
            string pbfFilePath = System.IO.Path.GetTempPath() + "PicasaStarter\\" + ButtonID + ".pbf";
            string psdFilePath = System.IO.Path.GetTempPath() + "PicasaStarter\\" + ButtonID + ".psd";
            string scriptFilePath = destDirectory + '\\' + "PS_Button" + Label + ".bat";
            FileInfo pbzFile = new FileInfo(destDirectory + '\\' + "PS_Button" + Label + ".pbz");
            if (!pbzFile.Directory.Exists)
                pbzFile.Directory.Create();
            
            // Prepare source files
            this.WritePBF(pbfFilePath);

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

        private void WritePBF(string path)
        {
            // Some variables need some preprocessing before using them in the xml field...
            int foreach_field = (ExecuteForeach == true) ? 1 : 0;  // If true: 1, else: 0
            int export_field = (ExportFirst == true) ? 1 : 0;   // If true: 1, else: 0

            string exe_name_field;
            if (ExecutionType == ExecType.Executable)
            {
                FileInfo exeFile = new FileInfo(ExeFilePath);

                exe_name_field = exeFile.FullName + " " + ExeArguments;
            }
            else
                exe_name_field = "PS_Button" + Label + ".bat";

            string xml =
                "<?xml version='1.0' encoding='utf-8' ?>" + Environment.NewLine +
                "<buttons format='1' version='" + Version + "'>" + Environment.NewLine +
                "  <button id='" + ButtonID + "' type='dynamic'>" + Environment.NewLine +
                "    <label>" + Label + "</label>" + Environment.NewLine +
                "    <icon name='" + ButtonID + "/" + IconLayer + "' src='pbz'/>" + Environment.NewLine +
                "    <tooltip>" + ToolTipText + "</tooltip>" + Environment.NewLine +
                "    <action verb='trayexec'>" + Environment.NewLine +
                "      <param name='exe_name' value='" + exe_name_field + "'/>" + Environment.NewLine +
                "      <param name='foreach'  value='" + foreach_field + "'/>" + Environment.NewLine +
                "      <param name='export'  value='" + export_field + "'/>" + Environment.NewLine +
                "    </action>" + Environment.NewLine +
                "  </button>" + Environment.NewLine +
                "</buttons>"
                ;

            File.WriteAllText(path, xml);
        }
    }
}
