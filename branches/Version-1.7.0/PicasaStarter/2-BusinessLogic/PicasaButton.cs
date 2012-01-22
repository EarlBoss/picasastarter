using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ionic.Zip;
using System.Xml.Serialization;     // Added to use serialisation

namespace PicasaStarter
{
    public class PicasaButton
    {
#region Properties

        public class PsdIcon
        {
            /// <summary>
            /// Bytestream of the .psd file containing the icon.
            /// </summary>
            public byte[] PsdData { get; set; }

            /// <summary>
            /// Layer containing the icon in the .psd file in "Icon" property. If you specify an icon, this property is mandatory.
            /// </summary>
            public string PsdLayer { get; set; }

            public PsdIcon()
            {
            } 
        }

        private Buttons _pbfButton = new Buttons();
        private PsdIcon _icon = new PsdIcon();

        public Action Action
        {
            get { return _pbfButton.Button.Action; }
            set { _pbfButton.Button.Action = value; }
        }

        public PsdIcon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public string ButtonID 
        {
            get { return _pbfButton.Button.Id; }
            set { _pbfButton.Button.Id = value; }
        }

        public int Version
        { 
            get { return _pbfButton.Version; }
            set { _pbfButton.Version = value; }
        }

        public string Label 
        {
            get { return _pbfButton.Button.Label; }
            set { _pbfButton.Button.Label = value; }
        }

        public string ToolTipText 
        {
            get { return _pbfButton.Button.Tooltip; }
            set { _pbfButton.Button.Tooltip = value; }
        }

        public string Description { get; set; }

#endregion

#region Methods

        public PicasaButton()
        {
        }

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
            if (Icon != null && Icon.PsdData != null && Icon.PsdData.Length > 0)
                File.WriteAllBytes(psdFilePath, Icon.PsdData);

            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(pbfFilePath, "");
                if (Icon != null && Icon.PsdData != null && Icon.PsdData.Length > 0)
                    zip.AddFile(psdFilePath, "");
                zip.Save(pbzFile.FullName);
                zip.Dispose();
            }

            // If trayexec and script -> write the script...
            if (Action.Verb == "TrayExec")
            {
                ActionTrayExec action = (ActionTrayExec)Action;

                if (action.ExecutionType == ActionTrayExec.ExecType.Script)
                    File.WriteAllText(scriptFilePath, action.Script);
            }

            // Cleanup temp files...
            File.Delete(pbfFilePath);
            File.Delete(psdFilePath);

            return true;
        }

        private void WritePBF(string pbfFilePath, string pbzDir, bool isButtonForDefaultDB)
        {
            // Another way to write the pbf:
            //Buttons buttons = new Buttons();
            //buttons.Button = new Button();
            //buttons.Button.Id = "123ABC";
            //buttons.Button.Label = "ButtonLabel";
            //buttons.Button.Tooltip = "ButtonTooltip";
            //buttons.Button.Icon.Name = "IconName";
            //buttons.Button.Action.Verb = "trayexec";
            //buttons.Button.Action.ParamList.Add(new Param("testParam", "testParamValue"));

            PicasaButtonPBF.Serialize(_pbfButton, pbfFilePath);

/*            // Some variables need some preprocessing before using them in the xml field...
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
            xml += "    <icon name='" + ButtonID + "/" + Icon.PsdLayer + "' src='pbz'/>" + Environment.NewLine;
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

            FileInfo file = new FileInfo(pbfFilePath);
            file.Directory.Create();

            File.WriteAllText(pbfFilePath, xml);
*/
        }

#endregion

    }
}
