using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicasaStarter
{
    public partial class FirstRunWizardStep2 : Form
    {
        public string AppSettingsDir { get; private set; }
        public string DefaultAppSettingsDir { get; private set; }

        public FirstRunWizardStep2(string defaultAppSettingsDir)
        {
            InitializeComponent();

            AppSettingsDir = DefaultAppSettingsDir = defaultAppSettingsDir;
        }

        private void FirstRunWizardStep2_Load(object sender, EventArgs e)
        {
            textBoxSettingsXMLPath.Text = AppSettingsDir;
        }

        private void ButtonSetXMLToDef_Click(object sender, EventArgs e)
        {
            textBoxSettingsXMLPath.Text = DefaultAppSettingsDir;

            CheckSettingsfile();
        }

        private void ButtonSelXMLPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowNewFolderButton = true;
            fd.SelectedPath = AppSettingsDir;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBoxSettingsXMLPath.Text = fd.SelectedPath;
                AppSettingsDir = textBoxSettingsXMLPath.Text.Trim(new char[] { '"', ' ' });
                AppSettingsDir = AppSettingsDir.TrimEnd(new char[] { '\\' });
            }

            CheckSettingsfile();
        }

        private void CheckSettingsfile()
        {
            Settings settings;

            try
            {
                settings = SettingsHelper.DeSerializeSettings(
                AppSettingsDir + "\\" + SettingsHelper.SettingsFileName);
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show(
                        "Settings file not found in this location:\n" + AppSettingsDir +
                        "\n\nSince this is not the default location for the settings file, " +
                        "you are probably trying to select a shared settings file that doesn't exist in this location." +
                        "\n\nClick YES to Create a New Settings File in this Location" +
                        "\n\nClick NO to try a different location",
                        "No Settings File Found in This Location", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // If the settings couldn't be loaded, create new empty settings object, but add default picasa database...
                    settings = new Settings();
                    settings.picasaDBs.Add(SettingsHelper.GetDefaultPicasaDB());
                }
            }
        }
    }
}
