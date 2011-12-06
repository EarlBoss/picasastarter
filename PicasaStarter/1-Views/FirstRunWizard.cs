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
    public partial class FirstRunWizard : Form
    {
        private string _appSettingsDir = "";
        private string _picasaExePath;
        private string _returnAppSettingsDir;
        private Settings _returnSettings = null;
        private Settings _localSettings = null;
        private bool _setDefaultIniPath = false;
        //private bool _iniPathChanged = false;
        private string _returnPicasaExePath;

        public string ReturnPicasaExePath { get { return _returnPicasaExePath; } private set { _returnPicasaExePath = value; } }
        public Settings ReturnPicasaSettings { get { return _returnSettings; } private set { _returnSettings = value; } }
        public string ReturnAppSettingsDir { get { return _returnAppSettingsDir; } private set { _returnAppSettingsDir = value; } }

        public FirstRunWizard(string appsDirPath, Settings localSettings)
        {
            InitializeComponent();

            _returnAppSettingsDir = _appSettingsDir = appsDirPath;
            _localSettings = localSettings;
            _returnPicasaExePath = _picasaExePath = localSettings.PicasaExePath;
        }

        private void FirstRunWizard_Load(object sender, EventArgs e)
        {
            textBoxPicasaExePath.Text = _picasaExePath;
            if (_appSettingsDir == SettingsHelper.ConfigurationDir)
             {
               textBoxSettingsXMLPath.Text = SettingsHelper.ConfigurationDir;
               _setDefaultIniPath = true;
            }
            else
            {
                textBoxSettingsXMLPath.Text = _appSettingsDir;
                _setDefaultIniPath = false;
            }
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
                textBoxPicasaExePath.Text = _picasaExePath = openFileDialog1.FileName;
            }
        }

        private void SelXMLPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = true;
            fd.SelectedPath = _appSettingsDir;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBoxSettingsXMLPath.Text = fd.SelectedPath;
                _appSettingsDir = textBoxSettingsXMLPath.Text.Trim(new char[] { '"', ' ' });
                _appSettingsDir = _appSettingsDir.TrimEnd(new char[] { '\\' });

                try
                {
                    _localSettings = SettingsHelper.DeSerializeSettings(
                    _appSettingsDir + "\\" + SettingsHelper.SettingsFileName);
                    _setDefaultIniPath = false;
                }
                catch (Exception)
                {
                    DialogResult result = MessageBox.Show(
                            "Settings file not found in: " + _appSettingsDir +
                            "\nClick YES to Create a New Settings File in that Location" +
                            "\nClick NO to Try Again",
                            "No Settings File Found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // If the settings couldn't be loaded, create new empty settings object, but add default picasa database...
                        _localSettings = new Settings();
                        _localSettings.picasaDBs.Add(SettingsHelper.GetDefaultPicasaDB());
                        _setDefaultIniPath = false;
                    }
                }
            }
        }

        private void SetXMLToDef_Click(object sender, EventArgs e)
        {
            textBoxSettingsXMLPath.Text = SettingsHelper.ConfigurationDir;
            _appSettingsDir = SettingsHelper.ConfigurationDir;
            try
            {
                _localSettings = SettingsHelper.DeSerializeSettings(
                    _appSettingsDir + "\\" + SettingsHelper.SettingsFileName);
                _setDefaultIniPath = true;
            }
            catch (Exception)
            {
                _setDefaultIniPath = false;

                DialogResult result = MessageBox.Show(
                        "Settings file not found in: " + _appSettingsDir +
                        "\nClick YES to Create a New Settings File in that Location" +
                        "\nClick NO to Try Again",
                        "No Settings File Found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // If the settings couldn't be loaded, create new empty settings object, but add default picasa database...
                    _localSettings = new Settings();
                    _localSettings.picasaDBs.Add(SettingsHelper.GetDefaultPicasaDB());
                    _setDefaultIniPath = true;
                }
            }
            //PicasaExePath = _localSettings.PicasaExePath;
            //_setDefaultIniPath = true;
            //_iniPathChanged = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Configuration config = new Configuration();
            //if (_iniPathChanged)
            //{
                _localSettings.PicasaExePath = _picasaExePath;
                ReturnPicasaSettings = _localSettings;
                config.configPicasaExePath = _picasaExePath;

                if (_setDefaultIniPath)
                {
                    config.picasaStarterSettingsXMLPath = "";
                    _returnAppSettingsDir = SettingsHelper.ConfigurationDir;
                }
                else
                {
                    config.picasaStarterSettingsXMLPath = textBoxSettingsXMLPath.Text;
                    _returnAppSettingsDir = config.picasaStarterSettingsXMLPath;
                }
                try
                {
                    SettingsHelper.SerializeConfig(config,
                            SettingsHelper.ConfigurationDir + "\\" + SettingsHelper.ConfigFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving config file: " + ex.Message);
                }
                ReturnAppSettingsDir = _returnAppSettingsDir;
            //}
            ReturnPicasaExePath = _picasaExePath;
 
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
