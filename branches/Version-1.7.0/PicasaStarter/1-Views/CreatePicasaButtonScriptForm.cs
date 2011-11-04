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

        public string Script
        { 
            get { return _script; } 
        }

        public CreatePicasaButtonScriptForm(string script)
        {
            InitializeComponent();

            textBoxScript.Text = script;
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
