using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PRBackup;

namespace PicasaStarter
{
    public partial class BackupProgressForm : Form
    {
        private int _progressPct = 0;
        private string _curDirToBackup = "";
        private int _nbFiles = 0;
        private int _nbFilesDoneChanged = 0;
        private int _nbFilesDoneUnchanged = 0;

        public BackupProgressForm()
        {
            InitializeComponent();

            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
        }

        public void Progress(object sender, Backup.ProgressEventParams progress)
        {
            if (progress.NbFiles > 0)
            {
                if (_progressPct != ((progress.NbFilesDoneChanged + progress.NbFilesDoneUnChanged) * 100 / progress.NbFiles))
                {
                    _progressPct = (progress.NbFilesDoneChanged + progress.NbFilesDoneUnChanged) * 100 / progress.NbFiles;
                    progressBar.Value = _progressPct;
                }

                if (_curDirToBackup != progress.CurDirToBackup)
                {
                    _curDirToBackup = progress.CurDirToBackup;
                    labelDir.Text = _curDirToBackup;
                }

                if (_nbFiles != progress.NbFiles)
                {
                    _nbFiles = progress.NbFiles;
                    labelNumberFiles.Text = _nbFiles.ToString();
                }

                if (_nbFilesDoneChanged != progress.NbFilesDoneChanged)
                {
                    _nbFilesDoneChanged = progress.NbFilesDoneChanged;
                    labelNumberChanged.Text = _nbFilesDoneChanged.ToString();
                }

                if (_nbFilesDoneUnchanged != progress.NbFilesDoneUnChanged)
                {
                    _nbFilesDoneUnchanged = progress.NbFilesDoneUnChanged;
                    labelNumberUnchanged.Text = _nbFilesDoneUnchanged.ToString();
                }
                Refresh();
            }
        }
    }
}
