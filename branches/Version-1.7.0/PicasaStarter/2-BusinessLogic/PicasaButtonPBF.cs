using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;     // Added to use serialisation
using System.IO;                    // Added to use serialisation to file

namespace PicasaStarter
{
    class PicasaButtonPBF
    {
        public static void Serialize(Buttons pbf, string filePath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            pbf.Button.Action = new Action(pbf.Button.Action);

            using(TextWriter tw = new StreamWriter(filePath))
            {
                // Serialize settings to file
                XmlSerializer serializer = new XmlSerializer(typeof(Buttons));
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
            
                serializer.Serialize(tw, pbf, ns);
            }
        }

        public static Buttons DeSerialize(string filePath)
        {
            Buttons buttons = null;

            using (TextReader tr = new StreamReader(filePath))
            {
                // Deserialize settings
                XmlSerializer serializer = new XmlSerializer(typeof(Buttons));
                buttons = (Buttons)serializer.Deserialize(tr);
            }
            
            return buttons;
        }
    }

    public class Buttons
    {
        [XmlAttribute]
        public int Format { get; set; }
        [XmlAttribute]
        public int Version { get; set; }

        public Button Button { get; set; }

        public Buttons()
        {
            Button = new Button();

            Format = 1;
            Version = 1;
        }
    }

    public class Button
    {
        [XmlAttribute]
        public string Id { get; set; }
        
        [XmlAttribute]
        public string Type { get; set; }

        public string Label { get; set; }
        public string Tooltip { get; set; }
        public Icon Icon { get; set; }
        public Action Action { get; set; }

        public Button()
        {
            Type = "Dynamic";
            Action = new Action();
            Icon = new Icon();
        }
    }

    public class Icon
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Src { get; set; }

        public Icon()
        {
            Src = "pbz";
        }
    }

    [System.Xml.Serialization.XmlInclude(typeof(ActionTrayExec))]
    public class Action
    {
        [XmlAttribute]
        public string Verb { get; set; }

        [XmlElement("Param")]
        public List<Param> ParamList { get; set; }

        public Action()
        {
            ParamList = new List<Param>();
        }

        public Action(Action action)
        {
            this.Verb = action.Verb;
            this.ParamList = action.ParamList;
        }

        /// <summary>
        /// Gets the value for a given paramName.
        /// </summary>
        /// <param name="paramName"> The param you want to get the value of...</param>
        /// <returns> The corresponding value, or "" if the param doesn't exist.</returns>
        public string GetParamValue(string paramName)
        {
            foreach (Param param in ParamList)
            {
                if (param.Name == paramName)
                    return param.Value;
            }

            return "";
        }

        /// <summary>
        /// Sets the param with the given paramName and paramValue. If it exists already it is updated. 
        /// If the paramValue passed is null or "", the param is removed if it exists.
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        public void SetParam(string paramName, string paramValue)
        {
            bool IsFound = false;
            for (int i = 0 ; i < ParamList.Count() ; i++)
            {
                if (ParamList[i].Name == paramName)
                {
                    if (paramValue == null || paramValue == "")
                        ParamList.RemoveAt(i);
                    else
                        ParamList[i].Value = paramValue;

                    IsFound = true;
                }
            }

            if (IsFound == false && paramValue != null && paramValue != "")
                ParamList.Add(new Param(paramName, paramValue));
        }
    }

    public class ActionTrayExec : Action
    {
        public ActionTrayExec()
        {
            Verb = "TrayExec";
        }

        /// <summary>
        /// Is the button executing an executable directly or is it starting a script
        /// </summary>
        public ExecType ExecutionType = ExecType.Executable;

        /// <summary>
        /// The script to be executed when pushing the button. Must be written as a windows batch file.
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// Registry key that contains the entire path to the executable. If this is specified, 
        /// all other "exe..." properties are ignored.
        /// </summary>
        [XmlIgnore]
        public string ExeFileRegKey
        {
            get { return GetParamValue("exe_name_regkey"); }
            set { SetParam("exe_name_regkey", value); }
        }

        /// <summary>
        /// Registry key that contains the directory to the executable. If you specify ExeDir as well, the content in ExeDir 
        /// will be interpreted as a relative path starting from the directory in the registry key.
        /// </summary>
        [XmlIgnore]
        public string ExeDirRegKey
        {
            get { return GetParamValue("exe_path_regkey"); }
            set { SetParam("exe_path_regkey", value); }
        }

        /// <summary>
        /// The path to the executable...
        /// </summary>
        [XmlIgnore]
        public string ExeDir
        {
            get { return GetParamValue("exe_path"); }
            set { SetParam("exe_path", value); }
        }

        /// <summary>
        /// The file name of the executable.
        /// </summary>
        [XmlIgnore]
        public string ExeFileName
        {
            get { return GetParamValue("exe_name"); }
            set { SetParam("exe_name", value); }
        }

        /// <summary>
        /// If true, Picasa will run the exe/script for every selected file seperatly when pushing the button.
        /// If false, Picasa will turn the exe/script once and pass all filenames as command line parameters.
        /// </summary>
        [XmlIgnore]
        public bool ExecuteForeach
        {
            get { return GetParamValue("foreach") == "1" ? true : false; }
            set { SetParam("foreach", (value ? "1" : "0")); }
        }

        /// <summary>
        /// If true, Picasa wil export the selected images first to a temporary location before starting the exe/script.
        /// If false, the current files will be passed to the exe/script.
        /// </summary>
        [XmlIgnore]
        public bool ExportFirst
        {
            get { return GetParamValue("export") == "1" ? true : false; }
            set { SetParam("export", (value ? "1" : "0")); }
        }

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
    }

    public class Param
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Value { get; set; }

        public Param()
        {
        }

        public Param(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
