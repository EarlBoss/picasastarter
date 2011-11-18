using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PicasaStarter
{
    public partial class HelpDialog : Form
    {
        private string _help =
             "{\\rtf1 "
             + "{\\b Hello! }\\line"
             + " \\line "
             + "This small application can be used to start picasa using different picasa databases. These databases can be located on a network drive, or on a local disk. \\line "
             + " \\line "
             + "{\\b This is how you should use it: }\\line "
             + "- Do {\\b \"Add database\" } to add a link to a new or existing picasa databases on a mapped network drive (like E:\\) or on any places on your computer. \\line "
             + "- Edit the properties in the right-hand side of the screen, give it a {\\b name }, a {\\b description } and browse to the {\\b path } where you want the database to be created. \\line "
             + "- I you want to start from a {\\b copy of an existing database }, you need to copy the \"picasa2\" AND \"picasa2albums\" directories from one "
             + "\"Full directory\" to the other one. \\line "
             + "- You can let picasastarter start Picasa with a custom database without showing the Picasastarter screen. Check the FAQ on the Picasastarter website for details. \\line "
             + " \\line "
             + "{\\b Remark: } If you use exactly the same custom database paths from several computers on the network, your database will be shared. "
             + "There is a check implemented that it isn't possible to start multiple picasa's at the same time using the same database. "
             + "If you bypass this, this is at your own risk of getting a corrupted database... \\line "
             + " \\line "
             + "{\\b Have fun! }\\line "
             + " \\line\\line\\line\\line "
             + "{\\b Troubleshooting tips: }\\line "
             + "- If \"Run Picasa\" doesn't work, maybe you didn't install Picasa in the default directory. Check out the \"General settings\" to provide the right path... \\line "
             + "- Make sure that, if you put your pictures on a shared directory, the mapped drive used is the same on all computers (eg. X:). Check the FAQ on the Picasastarter website for details. \\line "
             + " \\line "
             + "More information and new versions can be found at http://sites.google.com/site/picasastartersite/"
             + "}"
             ;

        public HelpDialog()
        {
            InitializeComponent();
        }

        private void HelpDialog_Load(object sender, EventArgs e)
        {
            richTextBoxHelp.Rtf = _help;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
