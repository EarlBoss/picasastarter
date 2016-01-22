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
    public partial class RebuildRestoreForm : Form
    {
        public string ReturnMessage = "Rebuild/Restore Task: Nothing Done";
        public Color ReturnColor = Color.Red;
        private Settings _settings;
        private PicasaDB _database;

        public RebuildRestoreForm(PicasaDB database, Settings settings)
        {
            InitializeComponent();
            _database = database;
            _settings = settings;
        }

        private void RebuildRestoreForm_Load(object sender, EventArgs e)
        {

        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
 
        }

        /*
         * Carry out tasks to rebuild the database
         */
        private void OkButton_Click(object sender, EventArgs e)
        {

        }

        /* Restore the database to a selected earlier copy in backups.
         * To do:
         * Ask to Back Up present database, warn if backup not defined.
         * Ask for Back Up database to restore to.
         * 
        */
        private void RestoreButton_Click(object sender, EventArgs e)
        {

        }

        /*Rebuild the database while Retaining the contacts,
         * the Watched folders, and the Face Recognition Excluded folders.
         * To do:
         * Ask to Back Up present database, warn if backup not defined.
         * 
         * Erase all files in db3 folder except 
         *   scanlist.xml, Thumbindex.db, thumb_index.db.
         *   
         * Rename Contacts.xml to backup.xml
        */
        private void RebuildMinButton_Click(object sender, EventArgs e)
        {
        }

        /* Totally Rebuild the database while Retaining nothing.
         * To do:
         * Ask to Back Up present database, warn if backup not defined.
         * 
         * Erase both database folders Picasa2
        */
        private void RebuildTotalButton_Click(object sender, EventArgs e)
        {

        }
    }
}
