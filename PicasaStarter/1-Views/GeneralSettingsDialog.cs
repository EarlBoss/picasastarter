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
        private string _appSettingsDir;
        private Settings _localSettings = null;
        private bool _setDefaultIniPath;
        private bool _iniPathChanged;

        public string PicasaExePath { get; set; }
        public string ReturnPicasaExePath { get; private set; }
        public Settings ReturnPicasaSettings { get; private set; }
        public string ReturnAppSettingsDir { get ; private set; }

        public GeneralSettingsDialog(string appSettingsDir, string picasaExePath)
        {
            InitializeComponent();

            ReturnAppSettingsDir = _appSettingsDir = appSettingsDir;
            ReturnPicasaExePath = PicasaExePath = picasaExePath;
        }

        private void GeneralSettingsForm_Load(object sender, EventArgs e)
        {
            textBoxPicasaExePath.Text = PicasaExePath;
            if (_appSettingsDir == SettingsHelper.ConfigurationDir)
                textBoxSettingsXMLPath.Text = SettingsHelper.ConfigurationDir;
            else 
                textBoxSettingsXMLPath.Text = _appSettingsDir;
        }

        private void textBoxPicasaExePath_TextChanged(object sender, EventArgs e)
        {
            PicasaExePath = textBoxPicasaExePath.Text;
        }

        private void buttonBrowsePicasaExePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Path.GetDirectoryName(PicasaExePath);
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
            Configuration config = new Configuration();
            if ((_localSettings != null) || _iniPathChanged)
            {
                DialogResult result = MessageBox.Show(
                        "If you proceed, the selected settings file\nwill become your current settings.\n    Are you sure you want to do this?",
                        "Change current settings?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (_iniPathChanged)
                    {
                        if (_setDefaultIniPath)
                        {
                            config.picasaStarterSettingsXMLPath = "";
                            ReturnAppSettingsDir = SettingsHelper.ConfigurationDir;
                        }
                        else
                        {
                            config.picasaStarterSettingsXMLPath = textBoxSettingsXMLPath.Text;
                            ReturnAppSettingsDir = config.picasaStarterSettingsXMLPath;
                        }
                        config.configPicasaExePath = PicasaExePath;
                        try
                        {
                            SettingsHelper.SerializeConfig(config,
                                    SettingsHelper.ConfigurationDir + "\\" + SettingsHelper.ConfigFileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Gs Error saving settings: " + ex.Message);
                        }
                    }
                    ReturnPicasaSettings = _localSettings;
                }
            }
            ReturnPicasaExePath = PicasaExePath;

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

        private void SetXMLToDef_Click(object sender, EventArgs e)
        {
            textBoxSettingsXMLPath.Text = SettingsHelper.ConfigurationDir;
            _appSettingsDir = SettingsHelper.ConfigurationDir;
            try
            {
                _localSettings = SettingsHelper.DeSerializeSettings(
                    _appSettingsDir + "\\" + SettingsHelper.SettingsFileName);
                _setDefaultIniPath = true;
                _iniPathChanged = true;
            }
            catch (Exception)
            {
                _setDefaultIniPath = false;
                _iniPathChanged = false;

                DialogResult result = MessageBox.Show(
                        "Settings file not found in the default location:\n" + _appSettingsDir +
                        "\n\nClick YES to Create a New Settings File in the default Location" +
                        "\n\nClick NO then Cancel to select a different location.",
                        "No Settings File Found in the Default Location", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // If the settings couldn't be loaded, create new empty settings object, but add default picasa database...
                    _localSettings = new Settings();
                    _localSettings.picasaDBs.Add(SettingsHelper.GetDefaultPicasaDB());
                    _setDefaultIniPath = true;
                    _iniPathChanged = true;
                }
            }
            //PicasaExePath = _localSettings.PicasaExePath;
            //_setDefaultIniPath = true;
            //_iniPathChanged = true;
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
                    _iniPathChanged = true;
                }
                catch (Exception)
                {
                    _iniPathChanged = false;

                    DialogResult result = MessageBox.Show(
                            "Settings file not found in this location:\n" + _appSettingsDir +
                            "\n\nSince this is not the default location for the settings file, " +
                            "you are probably trying to select a shared settings file that doesn't exist in this location." +
                            "\n\nClick YES to Create a New Settings File in this Location" +
                            "\n\nClick NO to try a different location",
                            "No Settings File Found in This Location", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // If the settings couldn't be loaded, create new empty settings object, but add default picasa database...
                        _localSettings = new Settings();
                        _localSettings.picasaDBs.Add(SettingsHelper.GetDefaultPicasaDB());
                        _setDefaultIniPath = false;
                        _iniPathChanged = true;
                    }
                }
            }
        }

        private void buttonExploreLogging_Click(object sender, EventArgs e)
        {
            try
            {
                string logDir = Path.GetTempPath() + "\\PicasaStarter\\Log";
                Directory.CreateDirectory(logDir);
                System.Diagnostics.Process.Start(logDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening log dir: " + ex.Message);
            }
        }
    }
}
