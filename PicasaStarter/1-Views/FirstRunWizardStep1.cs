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
    public partial class FirstRunWizardStep1 : Form
    {
        public string PicasaExePath { get; private set; }
        
        public FirstRunWizardStep1(string defaultPicasaExePath)
        {
            InitializeComponent();

            PicasaExePath = defaultPicasaExePath;
        }

        private void FirstRunWizardStep1_Load(object sender, EventArgs e)
        {
            textBoxPicasaExePath.Text = PicasaExePath;
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
            PicasaExePath = textBoxPicasaExePath.Text;

            if (!File.Exists(PicasaExePath))
            {
                MessageBox.Show("Please choose a path where Picasa.exe can be found or install Picasa first from picasa.google.com");
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
