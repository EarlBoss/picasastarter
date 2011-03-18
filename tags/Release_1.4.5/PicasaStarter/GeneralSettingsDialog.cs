using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;                    // Added to use Path class

namespace PicasaStarter
{
    public partial class GeneralSettingsDialog : Form
    {
        private string _appSettingsDir = "";
        private string _picasaExePath;
        private string _returnPicasaExePath;
        private Settings _localSettings = null;
        private Settings _returnSettings = null;

        public string PicasaExePath { get { return _picasaExePath; } set { _picasaExePath = value; } }

        public string ReturnPicasaExePath { get { return _returnPicasaExePath; } private set { _returnPicasaExePath = value; } }
        public Settings ReturnPicasaSettings { get { return _returnSettings; } private set { _returnSettings = value; } }

        public GeneralSettingsDialog(string appSettingsDir, string picasaExePath)
        {
            InitializeComponent();

            _appSettingsDir = appSettingsDir;
            _returnPicasaExePath = _picasaExePath = picasaExePath;
        }

        private void GeneralSettingsForm_Load(object sender, EventArgs e)
        {
            textBoxPicasaExePath.Text = _picasaExePath;
        }

        private void textBoxPicasaExePath_TextChanged(object sender, EventArgs e)
        {
            _picasaExePath = textBoxPicasaExePath.Text;
        }

        private void buttonBrowsePicasaExePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Path.GetDirectoryName(_picasaExePath);
            openFileDialog1.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxPicasaExePath.Text = openFileDialog1.FileName;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (_localSettings != null)
            {
                DialogResult result = MessageBox.Show(
                        "If you proceed the imported settings will overwrite your current settings? Are you sure you want to do this?",
                        "Overwrite current settings?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    ReturnPicasaSettings = _localSettings;
            }
            ReturnPicasaExePath = _picasaExePath;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonExportSettings_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.FileName = SettingsHelper.SettingsFileName;
            dialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(_appSettingsDir + "\\" + SettingsHelper.SettingsFileName,
                        dialog.FileName, true);
            }
        }

        private void buttonImportSettings_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FileName = SettingsHelper.SettingsFileName;
            dialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _localSettings = SettingsHelper.DeSerializeSettings(dialog.FileName);
                PicasaExePath = _localSettings.PicasaExePath;
                textBoxPicasaExePath.Text = PicasaExePath;
            }
        }
    }
}
