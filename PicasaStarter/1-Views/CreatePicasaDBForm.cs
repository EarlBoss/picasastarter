using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HelperClasses;
using System.IO;

namespace PicasaStarter
{
    public partial class CreatePicasaDBForm : Form
    {
        public Settings _settings;
        public PicasaDB PicasaDB { get; private set; }
        private string AppSettingsDir = "";
        private string appSettingsBaseDir = "";
        internal string full38DBDirectory = "";
        //public string VirtualDrive = "";
        //public bool VirtualDriveRemapped = false;


        public CreatePicasaDBForm(string appSettingsDir, Settings settings)
        {
            InitializeComponent();

            _settings = settings;
            AppSettingsDir = appSettingsDir;
            appSettingsBaseDir = Path.GetDirectoryName(AppSettingsDir);
            PicasaDB = new PicasaDB();
            PicDrivecomboBox.Text = "";
        }

        public CreatePicasaDBForm(PicasaDB picasaDB, string appSettingsDir, Settings settings, bool standardDatabase = false)
        {
            InitializeComponent();

            AppSettingsDir = appSettingsDir;
            appSettingsBaseDir = Path.GetDirectoryName(AppSettingsDir);
            PicasaDB = new PicasaDB(picasaDB);
            _settings = settings;

            textBoxBackupDir.Text = PicasaDB.BackupDir;
            textBoxDBBaseDir.Text = PicasaDB.BaseDir;
            textBoxDBDescription.Text = PicasaDB.Description;
            textBoxDBName.Text = PicasaDB.Name;
            PicDrivecomboBox.Text = PicasaDB.PictureVirtualDrive;
            EnablecheckBox.Checked = PicasaDB.EnableVirtualDrive;
            full38DBDirectory = PicasaDB.BaseDir + "\\Local Settings\\Application Data";
            if (standardDatabase == true)
            {
                textBoxDBName.Enabled = false;
                textBoxDBDescription.Enabled = false;
                buttonBrowseDBBaseDir.Enabled = false;
                PicDrivecomboBox.Text = "C:";
                PicDrivecomboBox.Enabled = false;
                EnablecheckBox.Checked = false;
                EnablecheckBox.Enabled = false;
                buttonConvert38.Enabled = false;
            }
        }

        private void buttonBrowseDBBaseDir_Click(object sender, EventArgs e)
        {
            if (EnablecheckBox.Checked == true && PicDrivecomboBox.Text != "")
            {
                string xyz = "";
                xyz = IOHelper.MapFolderToDrive(PicDrivecomboBox.Text, appSettingsBaseDir);
                if (xyz != PicDrivecomboBox.Text)
                {
                    MessageBox.Show("Virtual Drive not mapped Successfully \nDrive letter " + PicDrivecomboBox.Text + " Not Available");
                }
            }
            textBoxDBBaseDir.Text = DialogHelper.AskDirectoryPath(PicasaDB.BaseDir);
        }

        private void buttonBackupDir_Click(object sender, EventArgs e)
        {
            textBoxBackupDir.Text = DialogHelper.AskDirectoryPath(PicasaDB.BackupDir);
        }
        private void buttonNoBackupDir_Click(object sender, EventArgs e)
        {
            textBoxBackupDir.Text = null;
        }

        private void textBoxDBBaseDir_TextChanged(object sender, EventArgs e)
        {
            PicasaDB.BaseDir = textBoxDBBaseDir.Text;
            full38DBDirectory = PicasaDB.BaseDir + "\\Local Settings\\Application Data\\Google";

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            PicasaDB.BackupDir = textBoxBackupDir.Text;
            PicasaDB.BaseDir = textBoxDBBaseDir.Text;
            PicasaDB.Description = textBoxDBDescription.Text;
            PicasaDB.Name = textBoxDBName.Text;
            PicasaDB.PictureVirtualDrive = PicDrivecomboBox.Text;
            PicasaDB.EnableVirtualDrive = EnablecheckBox.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonCreateShortcut_Click(object sender, EventArgs e)
        {
            CreateShortcutDialog createShortcutDialog = new CreateShortcutDialog(PicasaDB.Name);
            DialogResult result = createShortcutDialog.ShowDialog();
        }


        private void PicDrivecomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EnablecheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonDoVDNow_Click(object sender, EventArgs e)
        {
            //Map folder or Path to drive letter if not already mapped
            if (EnablecheckBox.Checked == true && PicDrivecomboBox.Text != "")
            {
                string xyz = "";
                xyz = IOHelper.MapFolderToDrive(PicDrivecomboBox.Text, appSettingsBaseDir);
                if (xyz != PicDrivecomboBox.Text)
                {
                    MessageBox.Show ("Virtual Drive not mapped Successfully \nDrive letter "+ PicDrivecomboBox.Text + " Not Available");
                }
            }
                

        }

        private void CreatePicasaDBForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonConvert38_Click(object sender, EventArgs e)
        {

            // If it is the standard Picasa database, return AppData
            if (PicasaDB.IsStandardDB == true)
            {
                MessageBox.Show("Picasa standard database does not require conversion");
            }
            else
            {
                if (Directory.Exists(full38DBDirectory + "\\Google\\Picasa2"))
                {
                    if (Directory.Exists(PicasaDB.BaseDir + "\\Google\\Picasa2"))
                    {
                         // Ask user if he wants to overwrite the existing DB
                        string message = "There is already a Picasa database in:\n" + PicasaDB.BaseDir +
                            "\nIf you convert the version 3.8 database, it will overwrite this database,\n" +
                            " Click YES to continue the conversion\n\n" +
                            "To rename the existing database directory to:\n" +
                            PicasaDB.BaseDir + "\\GoogleOld\\,\n" +
                            "and then convert the version 3.8 Database, Click NO\n\n" +
                            "To Cancel conversion of the Picasa version 3.8 database, Click CANCEL." +
                            "\n\nNOTE:  To use the existing version 3.8 database path without conversion," +
                            "\n         set the Database Path to:\n" + full38DBDirectory;
                        string caption = "Convert Picasa Version 3.8 database to 3.9+";

                        // Displays the MessageBox.
                        DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                //If destination directory exists, rename it
                                Directory.Move(PicasaDB.BaseDir + "\\Google", PicasaDB.BaseDir + "\\GoogleOld");
                                //Move Database directories to new location
                                Directory.CreateDirectory(PicasaDB.BaseDir + "\\Google");
                                Directory.Move(full38DBDirectory + "\\Google\\Picasa2", PicasaDB.BaseDir + "\\Google\\Picasa2");
                                Directory.Move(full38DBDirectory + "\\Google\\Picasa2Albums", PicasaDB.BaseDir + "\\Google\\Picasa2Albums");
                                //Erase renamed directory
                                Directory.Delete(PicasaDB.BaseDir + "\\GoogleOld", true);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error converting the Picasa Version 3.8 Database directory: " + ex.Message);
                            }

                        }
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                        else if (result == DialogResult.No)
                        {
                           try
                            {
                                //If destination directory exists, rename it
                                Directory.Move(PicasaDB.BaseDir + "\\Google", PicasaDB.BaseDir + "\\GoogleOld");
                                //Move Database directories to new location
                                Directory.CreateDirectory(PicasaDB.BaseDir + "\\Google");
                                Directory.Move(full38DBDirectory + "\\Google\\Picasa2", PicasaDB.BaseDir + "\\Google\\Picasa2");
                                Directory.Move(full38DBDirectory + "\\Google\\Picasa2Albums", PicasaDB.BaseDir + "\\Google\\Picasa2Albums");
                            }
                           catch (Exception ex)
                           {
                               MessageBox.Show("Error saving previous \\Google|| directory or converting the Picasa Version 3.8 Database directory: " + ex.Message);
                            }

                        }
                    }
                    else
                    {
                        try
                        {
                            //Move the directories to the base dir
                            MessageBox.Show("Move Picasa database files in:\n" + full38DBDirectory+ "\nto:\n" + PicasaDB.BaseDir);
                            //Move Database directories to new location
                            Directory.CreateDirectory(PicasaDB.BaseDir + "\\Google");
                            Directory.Move(full38DBDirectory + "\\Google\\Picasa2", PicasaDB.BaseDir + "\\Google\\Picasa2");
                            Directory.Move(full38DBDirectory + "\\Google\\Picasa2Albums", PicasaDB.BaseDir + "\\Google\\Picasa2Albums");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error converting the Picasa Version 3.8 Database directory: " + ex.Message);
                        }
                    }

                }
                else
                    MessageBox.Show("Directory: " + full38DBDirectory + "  does not contain an existing \\Google\\ directory with a Picasa version 3.8 database");
            }
 
        }

        private void buttonCreateNewDB_Click(object sender, EventArgs e)
        {
            try
            {
                //Create database directory structure so Picasa can fill it in on next run
                Directory.CreateDirectory(PicasaDB.BaseDir + "\\Google\\Picasa2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating new Picasa Database directory: " + ex.Message);
            }
        }

        private void buttonCopyDB_Click(object sender, EventArgs e)
        {
            string xyz = "";
            // Show Database selection menu 
            // Show Database selection menu 
            CopyExistingDBForm copyDBForm = new CopyExistingDBForm(PicasaDB, _settings);
            copyDBForm.ShowDialog();

            if (copyDBForm.ReturnDBName != null)
            {
                xyz = copyDBForm.ReturnDBName;
            }

        }
    }
}
