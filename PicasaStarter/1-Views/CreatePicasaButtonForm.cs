using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PicasaStarter
{
    public partial class CreatePicasaButtonForm : Form
    {
        private PicasaButton _picasaButton;
        private string _appSettingsDir;

        // Some PicasaButton properties needn't be shown, so just put them in member variables...
        private bool _visible = true;           // Should the button be visible in Picasa or not?
        private string _buttonID = "";

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
            _buttonID = '{' + guid.ToString() + '}';
        }

        public CreatePicasaButtonForm(PicasaButton button, string appSettingsDir)
        {
            InitializeComponent();

            _appSettingsDir = appSettingsDir;

            _buttonID = button.ButtonID;
//            textBoxVersion.Text = 1;
            textBoxLabel.Text = button.Label;
            textBoxDescription.Text = button.Description;
            textBoxTooltip.Text = button.ToolTipText;
            textBoxIconPath.Text = button.IconPath;
            textBoxExePath.Text = button.ExeFilePath;
            textBoxArguments.Text = button.ExeArguments;
            _visible = button.Visible;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _picasaButton = new PicasaButton();

            _picasaButton.ButtonID = _buttonID;
            _picasaButton.Version = 1;
            _picasaButton.Label = textBoxLabel.Text;
            _picasaButton.Description = textBoxDescription.Text;
            _picasaButton.ToolTipText = textBoxTooltip.Text;
            _picasaButton.IconPath = textBoxIconPath.Text;
            _picasaButton.ExeFilePath = textBoxExePath.Text;
            _picasaButton.ExeArguments = textBoxArguments.Text;

            if(_visible == true)
                _picasaButton.CreateButtonFile(_appSettingsDir + '\\' + SettingsHelper.PicasaButtonVisibleDir);
            else
                _picasaButton.CreateButtonFile(_appSettingsDir + '\\' + SettingsHelper.PicasaButtonHiddenDir);

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

        private void buttonBrowseIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\" ;
            openFileDialog.Filter = "psd files (*.psd)|*.psd";
            openFileDialog.FilterIndex = 2 ;
            openFileDialog.RestoreDirectory = true ;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxIconPath.Text = openFileDialog.FileName;
            } 
        }
    }
}
