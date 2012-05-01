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
        public bool IsDefaultLocation { get; private set; }
        public string DefaultAppSettingsDir { get; private set; }
        public Settings Settings { get; private set; }

        //private Boolean IsDefaultLocation = true;

        public FirstRunWizardStep2(string defaultAppSettingsDir)
        {
            InitializeComponent();

            AppSettingsDir = DefaultAppSettingsDir = defaultAppSettingsDir;
            IsDefaultLocation = true;
        }

        private void FirstRunWizardStep2_Load(object sender, EventArgs e)
        {
            textBoxSettingsXMLPath.Text = AppSettingsDir;
        }

        private void ButtonSetXMLToDef_Click(object sender, EventArgs e)
        {
            textBoxSettingsXMLPath.Text = "Default: " + DefaultAppSettingsDir;
            IsDefaultLocation = true;
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
                IsDefaultLocation = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Boolean isOK = false;
            Boolean createNewSettingsFile = false;

            try
            {
                Settings = SettingsHelper.DeSerializeSettings(AppSettingsDir + "\\" + SettingsHelper.SettingsFileName);
                
                isOK = true;
            }
            catch (Exception)
            {
                // If the settings couldn't be loaded from default location, just create new empty 
                // settings object, but add default picasa database...
                if (IsDefaultLocation == true)
                {
                    createNewSettingsFile = true;
                    isOK = true;
                }
                // If no default location... ask for confirmation...
                else
                {
                    DialogResult result = MessageBox.Show(
                            "Settings file not found in this location:\n" + AppSettingsDir +
                            "\n\nSince this is not the default location for the settings file, " +
                            "you are probably trying to select a shared settings file that doesn't exist in this location.\n" +
                            "\n  -> Click YES to Create a New Settings File in this Location" +
                            "\n  -> Click NO to try a different location",
                            "No Settings File Found in This Location", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // If the settings couldn't be loaded, create new empty settings object, but add default picasa database...
                        createNewSettingsFile = true;
                        isOK = true;
                    }
                }
            }

            if (createNewSettingsFile == true)
            {
                Settings = new Settings();
                Settings.picasaDBs.Add(SettingsHelper.GetDefaultPicasaDB());
            }

            if (isOK == true)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
