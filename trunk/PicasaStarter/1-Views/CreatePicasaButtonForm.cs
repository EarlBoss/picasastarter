using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HelperClasses.Logger;             // Static logging class

namespace PicasaStarter
{
    public partial class CreatePicasaButtonForm : Form
    {
		public PicasaButton PicasaButton { get; private set; }
        
        private string _appSettingsDir;

        // Some PicasaButton properties needn't be shown, so just put them in member variables to pass the over if needed...
        private string _buttonID = "";
        private byte[] _icon = null;
        private string _script = "";

        public CreatePicasaButtonForm(string appSettingsDir)
        {
            InitializeComponent();

            _appSettingsDir = appSettingsDir;

            // Init the ID field with a new GUID...
            Guid guid = Guid.NewGuid();
            _buttonID = guid.ToString("B");

            // For a new button you can't remove the icon yet, nor can you set the layer...
            buttonRemoveIcon.Enabled = false;
            textBoxIconLayer.Enabled = false;

            // Default enable exe
            radioButtonScript.Checked = true;  // First set this one, otherwise the CheckedChanged of this icon isn't executed :-(.
            radioButtonExe.Checked = true;

            // Default execute for every selected file...
            checkBoxExecuteForeach.Checked = true;
        }

        public CreatePicasaButtonForm(PicasaButton button, string appSettingsDir)
        {
            InitializeComponent();

            _appSettingsDir = appSettingsDir;

            _buttonID = button.ButtonID;
            textBoxLabel.Text = button.Label;
            textBoxDescription.Text = button.Description;
            textBoxTooltip.Text = button.ToolTipText;
//            _icon = button.Icon.PsdData;
//            textBoxIconLayer.Text = button.Icon.PsdLayer;

            textBoxExeFileRegKey.Text = button.ExeFileRegKey;
            textBoxExeDirRegKey.Text = button.ExeDirRegKey;
            textBoxExeDir.Text = button.ExeDir;
            textBoxExeFileName.Text = button.ExeFileName;
            _script = button.Script;

            checkBoxExecuteForeach.Checked = button.ExecuteForeach;
            checkBoxExportFirst.Checked = button.ExportFirst;

            // Enable layer field if there is a button...
            if (_icon != null && _icon.Length > 0)
            {
                textBoxIconLayer.Enabled = true;
                buttonRemoveIcon.Enabled = true;
            }
            else
            {
                textBoxIconLayer.Enabled = false;
                buttonRemoveIcon.Enabled = false;
            }

            // Check exe radiobutton if there is an exe
            // Set them both first to true, otherwise the checkedChanged event handler doesn't do its job :-(.
            radioButtonExe.Checked = true;      
            radioButtonScript.Checked = true;
            if (button.ExecutionType == PicasaButton.ExecType.Executable)
                radioButtonExe.Checked = true;
            else
                radioButtonScript.Checked = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Check and get the data filled out in the form... if OK, close the form
            if (GetDataFromForm() == true)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBrowseExe_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\" ;
            openFileDialog.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*" ;
            openFileDialog.FilterIndex = 2 ;
            openFileDialog.RestoreDirectory = true ;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog.FileName);
                textBoxExeDir.Text = file.DirectoryName;
                textBoxExeFileName.Text = file.Name;
            } 
        }

        private void buttonChangeIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\" ;
            openFileDialog.Filter = "psd files (*.psd)|*.psd";
            openFileDialog.FilterIndex = 2 ;
            openFileDialog.RestoreDirectory = true ;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // If a (new) icon is choosen... put the bytestream in the PicasaButton...
                try
                {
                    _icon = File.ReadAllBytes(openFileDialog.FileName);
                    textBoxIconLayer.Enabled = true;
                    buttonRemoveIcon.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading icon file: " + ex.Message);
                    return;
                }
            } 
        }

        private void buttonRemoveIcon_Click(object sender, EventArgs e)
        {
            _icon = null;
            textBoxIconLayer.Text = "";
            textBoxIconLayer.Enabled = false;
        }

        private void radioButtonExe_CheckedChanged(object sender, EventArgs e)
        {
            // Make sure the right buttons, textfield are enabled/disabled...
            buttonBrowseExe.Enabled = radioButtonExe.Checked;
            textBoxExeFileRegKey.Enabled = radioButtonExe.Checked;
            textBoxExeDir.Enabled = radioButtonExe.Checked;
            textBoxExeDirRegKey.Enabled = radioButtonExe.Checked;
            textBoxExeFileName.Enabled = radioButtonExe.Checked;
        }

        private void radioButtonScript_CheckedChanged(object sender, EventArgs e)
        {
            // Make sure the right buttons, textfield are enabled/disabled...
            buttonEditScript.Enabled = radioButtonScript.Checked;
        }

        private void buttonEditScript_Click(object sender, EventArgs e)
        {
            CreatePicasaButtonScriptForm scriptForm = new CreatePicasaButtonScriptForm(_script);

            DialogResult result = scriptForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                _script = scriptForm.Script;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetDataFromForm() == true)
                {
                    // Set the directory to put the PicasaButtons in the PicasaDB...
                    string destButtonDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                            "\\Google\\Picasa2\\buttons";

                    PicasaButton.CreateButtonFile(destButtonDir);

                    System.Diagnostics.Process.Start(destButtonDir);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                MessageBox.Show("Error creating Picasa button: " + ex.Message);
            }
        }

        private bool GetDataFromForm()
        {
            // Check some fields...
            if (textBoxLabel.Text == "")
            {
                MessageBox.Show("You need to specify a label for the button!");
                return false;
            }

            if (_icon != null && _icon.Length > 0)
            {
                if (textBoxIconLayer.Text == "")
                {
                    MessageBox.Show("If you select an icon it is mandatory to specify the layer of the icon.");
                    return false;
                }
            }

            PicasaButton button = new PicasaButton();

            button.ButtonID = _buttonID;
            button.Version = 1;
            button.Label = textBoxLabel.Text;
            button.Description = textBoxDescription.Text;
            button.ToolTipText = textBoxTooltip.Text;
            button.Icon = _icon;
            button.IconLayer = textBoxIconLayer.Text;

            if (radioButtonExe.Checked == true)
            {
                button.ExecutionType = PicasaButton.ExecType.Executable;
                button.ExeFileRegKey = textBoxExeFileRegKey.Text;
                button.ExeDirRegKey = textBoxExeDirRegKey.Text;
                button.ExeDir = textBoxExeDir.Text;
                button.ExeFileName = textBoxExeFileName.Text;
            }
            else
            {
                button.ExecutionType = PicasaButton.ExecType.Script;
                button.Script = _script;
            }

            button.ExecuteForeach = checkBoxExecuteForeach.Checked;
            button.ExportFirst = checkBoxExportFirst.Checked;

            PicasaButton = button;
            return true;
        }

        private void textBoxExeFileRegKey_TextChanged(object sender, EventArgs e)
        {
            bool isExeFileRegKeySpecified = false;
            if (textBoxExeFileRegKey.Text.Trim() != "")
                isExeFileRegKeySpecified = true;

            textBoxExeDir.Enabled = !isExeFileRegKeySpecified;
            textBoxExeDirRegKey.Enabled = !isExeFileRegKeySpecified;
            textBoxExeFileName.Enabled = !isExeFileRegKeySpecified;
        }
    }
}
