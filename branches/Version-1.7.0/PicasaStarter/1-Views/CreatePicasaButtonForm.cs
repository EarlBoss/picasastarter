using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PicasaStarter
{
    public partial class CreatePicasaButtonForm : Form
    {
        private PicasaButton _picasaButton;
        private string _appSettingsDir;

        // Some PicasaButton properties needn't be shown, so just put them in member variables to pass the over if needed...
        private string _buttonID = "";
        private byte[] _icon = null;
        private string _script = "";

        public PicasaButton PicasaButton
        {
            get { return _picasaButton; }
        }

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
        }

        public CreatePicasaButtonForm(PicasaButton button, string appSettingsDir)
        {
            InitializeComponent();

            _appSettingsDir = appSettingsDir;

            _buttonID = button.ButtonID;
            textBoxLabel.Text = button.Label;
            textBoxDescription.Text = button.Description;
            textBoxTooltip.Text = button.ToolTipText;
            _icon = button.Icon;
            textBoxIconLayer.Text = button.IconLayer;

            textBoxExePath.Text = button.ExeFilePath;
            textBoxExeArguments.Text = button.ExeArguments;
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
            // Check some fields...
            if(textBoxLabel.Text == "")
            {
                MessageBox.Show("You need to specify a label for the button!");
                return;
            }

            if (_icon != null && _icon.Length > 0)
            {
                if (textBoxIconLayer.Text == "")
                {
                    MessageBox.Show("If you select an icon it is mandatory to specify the layer of the icon.");
                    return;
                }
            }

            _picasaButton = new PicasaButton();

            _picasaButton.ButtonID = _buttonID;
            _picasaButton.Version = 1;
            _picasaButton.Label = textBoxLabel.Text;
            _picasaButton.Description = textBoxDescription.Text;
            _picasaButton.ToolTipText = textBoxTooltip.Text;
            _picasaButton.Icon = _icon;
            _picasaButton.IconLayer = textBoxIconLayer.Text;

            if (radioButtonExe.Checked == true)
            {
                _picasaButton.ExecutionType = PicasaButton.ExecType.Executable;
                _picasaButton.ExeFilePath = textBoxExePath.Text;
                _picasaButton.ExeArguments = textBoxExeArguments.Text;
            }
            else
            {
                _picasaButton.ExecutionType = PicasaButton.ExecType.Script;
                _picasaButton.Script = _script;
            }

            _picasaButton.ExecuteForeach = checkBoxExecuteForeach.Checked;
            _picasaButton.ExportFirst = checkBoxExportFirst.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
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
                textBoxExePath.Text = openFileDialog.FileName;
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
            if (radioButtonExe.Checked == true)
            {
                buttonBrowseExe.Enabled = true;
                textBoxExeArguments.Enabled = true;
            }
            else
            {
                buttonBrowseExe.Enabled = false;
                textBoxExeArguments.Enabled = false;
            }
        }

        private void radioButtonScript_CheckedChanged(object sender, EventArgs e)
        {
            // Make sure the right buttons, textfield are enabled/disabled...
            if (radioButtonScript.Checked == true)
            {
                buttonEditScript.Enabled = true;
            }
            else
            {
                buttonEditScript.Enabled = false;
            }
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
    }
}
