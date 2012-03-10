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
        //private DateTime LastBackupDateOnEntry;
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
            BackupFrequencyBox.SelectedIndex = PicasaDB.BackupFrequency;
            if(PicasaDB.LastBackupDate.Year <= 1900)
                textLastBackupDate.Text = "Never Backed Up";
            else
                textLastBackupDate.Text = PicasaDB.LastBackupDate.ToString();
            textBoxDBBaseDir.Text = PicasaDB.BaseDir;
            textBoxDBDescription.Text = PicasaDB.Description;
            textBoxDBName.Text = PicasaDB.Name;
            messageBoxDB.ForeColor = Color.Blue;
            messageBoxDB.Text = "";
            textBoxVDSource.Text = appSettingsBaseDir;

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
                //if (xyz != PicDrivecomboBox.Text)
                //{
                //    MessageBox.Show("Virtual Drive not mapped Successfully \nDrive letter " + PicDrivecomboBox.Text + " is already mapped," +
                //        "\nOr already exists on this PC.");
                //}
            }
            textBoxDBBaseDir.Text = DialogHelper.AskDirectoryPath(PicasaDB.BaseDir);
            PicasaDB.BaseDir = textBoxDBBaseDir.Text;
            messageBoxDB.ForeColor = Color.Blue;
            messageBoxDB.Text = "";

        }

        private void buttonBackupDir_Click(object sender, EventArgs e)
        {
            textBoxBackupDir.Text = DialogHelper.AskDirectoryPath(PicasaDB.BackupDir);
            PicasaDB.LastBackupDate = new DateTime();
            textLastBackupDate.Text = "Never Backed Up";

        }
        private void buttonNoBackupDir_Click(object sender, EventArgs e)
        {
            textBoxBackupDir.Text = null;
            PicasaDB.LastBackupDate = new DateTime();
            textLastBackupDate.Text = "Never Backed Up";
        }

        private void textBoxDBBaseDir_TextChanged(object sender, EventArgs e)
        {
            PicasaDB.BaseDir = textBoxDBBaseDir.Text;
            full38DBDirectory = PicasaDB.BaseDir + "\\Local Settings\\Application Data";

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
                PicasaDB.BackupDir = textBoxBackupDir.Text;
                PicasaDB.BackupFrequency = BackupFrequencyBox.SelectedIndex;
                PicasaDB.BaseDir = textBoxDBBaseDir.Text;
                PicasaDB.Description = textBoxDBDescription.Text;
                PicasaDB.Name = textBoxDBName.Text;
                PicasaDB.PictureVirtualDrive = PicDrivecomboBox.Text;
                PicasaDB.EnableVirtualDrive = EnablecheckBox.Checked;
                if (!Directory.Exists(PicasaDB.BaseDir + "\\Google\\Picasa2"))
                {
                    string msg = "";
                    if (Directory.Exists(PicasaDB.BaseDir + "\\Local Settings\\Application Data\\Google\\Picasa2"))
                    {
                       msg = "Database selected is in Picasa 3.8 format.\n\nDo you still wish to continue? (YES/NO)";
                    }
                    else
                        msg = "Database directory doesn't exist,\nor doesn't contain a Picasa database.\n\n Do you still wish to continue? (YES/NO)";

                    DialogResult result = MessageBox.Show(msg, "Exiting Database Creation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                }
                else
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
                    MessageBox.Show("Virtual Drive not mapped Successfully \nDrive letter " + PicDrivecomboBox.Text + " is already mapped," +
                            "\nOr already exists on this PC.");
                }
            }
                

        }

        private void CreatePicasaDBForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonConvert38_Click(object sender, EventArgs e)
        {
            messageBoxDB.ForeColor = Color.Blue;
            messageBoxDB.Text = "Converting Picasa 3.8 Database to 3.9+";

            // If it is the standard Picasa database, return AppData
            if (PicasaDB.IsStandardDB == true)
            {
                messageBoxDB.Text = "Picasa standard database does not require conversion";
                return;
            }
            else
            {
                if (Directory.Exists(full38DBDirectory + "\\Google\\Picasa2"))
                {
                    if (Directory.Exists(PicasaDB.BaseDir + "\\Google\\Picasa2") || Directory.Exists(PicasaDB.BaseDir + "\\Google\\Picasa2Albums"))
                    {
                        // Ask user if he wants to overwrite the existing DB
                        string message = "There may already be a Picasa database in:\n" + PicasaDB.BaseDir +
                            "\nIf you convert the version 3.8 database, it will overwrite this database,\n" +
                            " Click YES to continue the conversion\n\n" +
                            "To back up the existing database directory to:\n" +
                            PicasaDB.BaseDir + "\\GoogleOld\\,\n" +
                            "and then convert the version 3.8 Database, Click NO\n\n" +
                            "NOTE: If there is an existing \\GoogleOld\\ backup, it will be deleted\n\n" +
                            "To Cancel conversion of the Picasa version 3.8 database, Click CANCEL.";
                         string caption = "Convert Picasa Version 3.8 database to 3.9+";

                        // Displays the MessageBox.
                        DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel);

                        if (result == DialogResult.Yes || result == DialogResult.No)
                        {
                            try
                            {
                                //Delete backup before making another if answer is No
                                if (Directory.Exists(PicasaDB.BaseDir + "\\GoogleOld") && result == DialogResult.No)
                                {
                                    Directory.Delete(PicasaDB.BaseDir + "\\GoogleOld", true);
                                }
                                //If destination directory exists, rename it
                                if (result == DialogResult.No)
                                {
                                    //Save old database if answer is no
                                    Directory.CreateDirectory(PicasaDB.BaseDir + "\\GoogleOld");
                                    Directory.Move(PicasaDB.BaseDir + "\\Google\\Picasa2", PicasaDB.BaseDir + "\\GoogleOld\\Picasa2");
                                    Directory.Move(PicasaDB.BaseDir + "\\Google\\Picasa2Albums", PicasaDB.BaseDir + "\\GoogleOld\\Picasa2Albums");
                                }
                                else
                                    Directory.Delete(PicasaDB.BaseDir + "\\Google", true); //answer YES, Delete old db

                                //Move Database directories to new location
                                Directory.CreateDirectory(PicasaDB.BaseDir + "\\Google");
                                Directory.Move(full38DBDirectory + "\\Google\\Picasa2", PicasaDB.BaseDir + "\\Google\\Picasa2");
                                Directory.Move(full38DBDirectory + "\\Google\\Picasa2Albums", PicasaDB.BaseDir + "\\Google\\Picasa2Albums");
 
                            }
                            catch (Exception )
                            {
                                messageBoxDB.ForeColor = Color.Red;
                                messageBoxDB.Text = "Error converting the Picasa Version 3.8 Database";
                                return;
                            }

                        }
                        if (result == DialogResult.Cancel)
                        {
                            messageBoxDB.ForeColor = Color.Red;
                            messageBoxDB.Text = "Picasa 3.8 Database conversion was cancelled ";
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            //Move the directories to the base dir
                            //MessageBox.Show("Move Picasa database files in:\n" + full38DBDirectory + "\nto:\n" + PicasaDB.BaseDir);
                            //Move Database directories to new location
                            Directory.CreateDirectory(PicasaDB.BaseDir + "\\Google");
                            Directory.Move(full38DBDirectory + "\\Google\\Picasa2", PicasaDB.BaseDir + "\\Google\\Picasa2");
                            Directory.Move(full38DBDirectory + "\\Google\\Picasa2Albums", PicasaDB.BaseDir + "\\Google\\Picasa2Albums");
                        }
                        catch (Exception )
                        {
                            messageBoxDB.ForeColor = Color.Red;
                            messageBoxDB.Text = "Error moving the Picasa Version 3.8 Database";
                            return;
                        }
                    }

                }
                else
                {
                    messageBoxDB.ForeColor = Color.Red;
                    messageBoxDB.Text = "Existing Picasa version 3.8 database not found";
                    return;
                }
                messageBoxDB.ForeColor = Color.Blue;
                messageBoxDB.Text = "Picasa 3.8 Database Converted to 3.9+";
            }
 
        }

        private void buttonCreateNewDB_Click(object sender, EventArgs e)
        {
            messageBoxDB.ForeColor = Color.Blue;
            messageBoxDB.Text = "Creating Empty Database ";
            if (Directory.Exists(PicasaDB.BaseDir + "\\Google\\Picasa2\\db3"))
            {
                // Ask user if he wants to overwrite the existing DB
                string message = "There is already a Picasa database in:\n" + PicasaDB.BaseDir +
                    "\nIf you Create an Empty Database, this existing database\n" +
                    "will be Erased and replaced with the empty database.\n" +
                    " Click YES to Create the Empty Database\n\n" +
                    "Click NO To rename the existing database directory to:\n" +
                    PicasaDB.BaseDir + "\\GoogleOld\\,\n" +
                    "and then Create an Empty Database\n\n" +
                    "Click CANCEL to return to previous menu."; 
                string caption = "Create New Empty Database";

                // Displays the MessageBox.
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes || result == DialogResult.No)
                {
                    try
                    {
                        //Delete backup before making another if answer is No
                        if (Directory.Exists(PicasaDB.BaseDir + "\\GoogleOld") && result == DialogResult.No)
                        {
                            Directory.Delete(PicasaDB.BaseDir + "\\GoogleOld", true);
                        }
                        //If destination directory exists, rename it
                        if (result == DialogResult.No)
                        {
                            //Save old database if answer is no
                            Directory.CreateDirectory(PicasaDB.BaseDir + "\\GoogleOld");
                            Directory.Move(PicasaDB.BaseDir + "\\Google\\Picasa2", PicasaDB.BaseDir + "\\GoogleOld\\Picasa2");
                            Directory.Move(PicasaDB.BaseDir + "\\Google\\Picasa2Albums", PicasaDB.BaseDir + "\\GoogleOld\\Picasa2Albums");
                        }
                        else
                            Directory.Delete(PicasaDB.BaseDir + "\\Google", true); //answer YES, Delete old db

                        //Create empty directory
                        Directory.CreateDirectory(PicasaDB.BaseDir + "\\Google\\Picasa2");

                    }
                    catch (Exception )
                    {
                        messageBoxDB.ForeColor = Color.Red ;
                        messageBoxDB.Text = "Error Creating Empty Database ";
                        return;
                    }

                }
                if (result == DialogResult.Cancel)
                {
                    messageBoxDB.ForeColor = Color.Red;
                    messageBoxDB.Text = "Empty Database creation was cancelled ";
                    return;
                }
            }
            else if (Directory.Exists(full38DBDirectory + "\\Google\\Picasa2\\db3"))
            {
                messageBoxDB.ForeColor = Color.Red;
                messageBoxDB.Text = " 3.8 Database Directory exists, Use Convert From 3.8 Instead";
                return;

            }
            else if (Directory.Exists(PicasaDB.BaseDir))
            {
                Directory.CreateDirectory(PicasaDB.BaseDir + "\\Google\\Picasa2");
            }
            else
            {
                messageBoxDB.ForeColor = Color.Red;
                messageBoxDB.Text = "Database Directory doesn't exist";
                return;
            }
            messageBoxDB.ForeColor = Color.Blue;
            messageBoxDB.Text = "Empty Database Directory successfully created ";
        }

        private void buttonCopyDB_Click(object sender, EventArgs e)
        {
            messageBoxDB.ForeColor = Color.Blue;
            messageBoxDB.Text = "Copying an existing database";
            // Show Copy Database menu 
            CopyExistingDBForm copyDBForm = new CopyExistingDBForm(PicasaDB, _settings);
            copyDBForm.ShowDialog();
            messageBoxDB.ForeColor = copyDBForm.ReturnColor;
            messageBoxDB.Text = copyDBForm.ReturnMessage;
             
        }

    }
}
