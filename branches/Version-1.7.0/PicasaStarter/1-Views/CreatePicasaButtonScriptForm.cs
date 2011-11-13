using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PicasaStarter
{
    public partial class CreatePicasaButtonScriptForm : Form
    {
        private string _script = "";
        private string _defaultScript = 
                "@echo off" + Environment.NewLine +
                "" + Environment.NewLine +
                ":: initialise some variables that can be practical..."  + Environment.NewLine +
                "set BatFileDir=%~dp0"  + Environment.NewLine +
                "set SelectedFile1=%1" + Environment.NewLine +
                "set SelectedFile2=%2" + Environment.NewLine +
                "" + Environment.NewLine +
                ":: Start to do the real work" + Environment.NewLine +
                "echo This is the first selected file in Picasa:" + Environment.NewLine +
                "echo %SelectedFile1%" + Environment.NewLine +
                "echo." + Environment.NewLine +
                "" + Environment.NewLine +
                "echo This is the second selected file in Picasa:" + Environment.NewLine +
                "echo %SelectedFile2%" + Environment.NewLine +
                "echo." + Environment.NewLine +
                ""  + Environment.NewLine +
                ":: For debugging purposes pause is very handy, comment it if you are ready"  + Environment.NewLine +
                "pause";

        public string Script
        { 
            get { return _script; } 
        }

        public CreatePicasaButtonScriptForm(string script)
        {
            InitializeComponent();

            if (script != "")
                textBoxScript.Text = script;
            else
                textBoxScript.Text = _defaultScript;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            _script = textBoxScript.Text;

            this.Close();
        }
    }
}
