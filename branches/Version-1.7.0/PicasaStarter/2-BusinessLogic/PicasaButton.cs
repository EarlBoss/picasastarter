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
        public string IconPath = null;
        public string IconLayer = null;
        public string ExeFilePath = null;
        public string ExeArguments = null;
        public bool Visible = true;

        public PicasaButton()
        {
        }

        public bool CreateButtonFile(string destDirectory)
        {
            // Init correct paths
            string pbfFilePath = System.IO.Path.GetTempPath() + ButtonID + ".pbf";
            string psdFilePath = System.IO.Path.GetTempPath() + ButtonID + ".psd";
            FileInfo pbzFile = new FileInfo(destDirectory + '\\' + "Button" + Label + ".pbz");
            if (!pbzFile.Directory.Exists)
                pbzFile.Directory.Create();
            
            // Prepare source files
            this.WritePBF(pbfFilePath);

            // If an Icon was specified... copy and rename it to the right name...
            if(IconPath != "")
                File.Copy(IconPath, psdFilePath);

            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(pbfFilePath, "");
                if (IconPath != "")
                    zip.AddFile(psdFilePath, "");
                zip.Save(pbzFile.FullName);
            }

            return true;
        }

        private void WritePBF(string path)
        {
            FileInfo exeFile = new FileInfo(ExeFilePath);

            string xml = 
                "<?xml version='1.0' encoding='utf-8' ?>" + "\n" +
                "<buttons format='1' version='" + Version + "'>" + "\n" +
                "  <button id='" + ButtonID + "' type='dynamic'>" + "\n" +
                "    <label>" + Label + "</label>" + "\n" +
                "    <icon name='" + ButtonID + ".psd/" + IconLayer + "' src='pbz'/>" + "\n" +
                "    <tooltip>" + ToolTipText + "</tooltip>" + "\n" +
                "    <action verb='trayexec'>" + "\n" +
                "      <param  name='exe_name' value='" + exeFile.Name + " " + ExeArguments + "'/>" + "\n" +
                "      <param  name='exe_path' value='" + exeFile.DirectoryName + "'/>" + "\n" +
                "    </action>" + "\n" +
                "  </button>" + "\n" +
                "</buttons>" + "\n"
                ;

            File.WriteAllText(path, xml);
        }
    }
}
