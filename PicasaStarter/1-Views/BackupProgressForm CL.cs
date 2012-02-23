using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BackupNS;

namespace PicasaStarter
{
    public partial class BackupProgressForm_CL : Form
    {
        private int _progressPct = 0;
        private string _status = "";
        private int _nbFiles = 0;
        private int _nbFilesDoneChanged = 0;
        private int _nbFilesDoneUnchanged = 0;
        private long _nbMBDoneChanged = 0;
        private long _nbMBDoneUnchanged = 0;
        private BackupForm_CL _parent = null;
        private TimeSpan _timeCounter;

        
        public BackupProgressForm_CL(BackupForm_CL parent)
        {
            InitializeComponent();

            _parent = parent;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            _timeCounter = new TimeSpan();
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000; // 1 second
            timer.Start();
            labelTimeElapsed.Text = _timeCounter.ToString();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            _timeCounter += new TimeSpan(1 * TimeSpan.TicksPerSecond);

            labelTimeElapsed.Text = _timeCounter.ToString();
            labelTimeElapsed.Refresh();
 
        }

        public void Progress(object sender, BackupNS.Backup.ProgressEventParams progress)
        {
            // If total number files = 0 -> divide by zero...
            if (progress.NbFiles <= 0)
                return;

            // Update and refresh the fields when relevant
            if (_progressPct != ((progress.NbFilesDoneChanged + progress.NbFilesDoneUnchanged) * 100 / progress.NbFiles))
            {
                _progressPct = (progress.NbFilesDoneChanged + progress.NbFilesDoneUnchanged) * 100 / progress.NbFiles;
                if (_progressPct > 100)
                    _progressPct = 100;

                progressBar.Value = _progressPct;
            }

            if (_status != progress.CurDirToBackup)
            {
                _status = progress.CurDirToBackup;
                labelStatus.Text = "Processing " + _status;
                labelStatus.Refresh();
            }

            if (_nbFiles != progress.NbFiles)
            {
                _nbFiles = progress.NbFiles;
                labelNumberFiles.Text = _nbFiles.ToString();
                labelNumberFiles.Refresh();
            }

            if (_nbFilesDoneChanged != progress.NbFilesDoneChanged)
            {
                _nbFilesDoneChanged = progress.NbFilesDoneChanged;
                labelNumberChanged.Text = _nbFilesDoneChanged.ToString();
                labelNumberChanged.Refresh();
            }

            if (_nbFilesDoneUnchanged != progress.NbFilesDoneUnchanged)
            {
                _nbFilesDoneUnchanged = progress.NbFilesDoneUnchanged;
                labelNumberUnchanged.Text = _nbFilesDoneUnchanged.ToString();
                labelNumberUnchanged.Refresh();
            }

            if (_nbMBDoneChanged != progress.NbMBDoneChanged)
            {
                _nbMBDoneChanged = progress.NbMBDoneChanged;
                labelMBDoneChanged.Text = '(' + FormatDiskSpace(_nbMBDoneChanged) + ')';
                labelMBDoneChanged.Refresh();
            }

            if (_nbMBDoneUnchanged != progress.NbFilesDoneUnchanged)
            {
                _nbMBDoneUnchanged = progress.NbMBDoneUnchanged;
                labelMBDoneUnchanged.Text = '(' + FormatDiskSpace(_nbMBDoneUnchanged) + ')';
                labelMBDoneUnchanged.Refresh();
            }
        }


        #region Private helper functions

        private string FormatDiskSpace(long Bytes)
        {
            long MByte = (Bytes / 1024) / 1024;
            long GByte = MByte / 1024;
            string formattedValue = "";

            if (GByte > 1)
            {
                MByte -= GByte * 1024;
                formattedValue = GByte + " GB, " + MByte + " MB";
            }
            else
                formattedValue = MByte + " MB";

            return formattedValue;
        }

        #endregion

        private void BackupProgressForm_CL_Load(object sender, EventArgs e)
        {
            //_parent.Hide();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Cancelling...";
            _parent.CancelBackup();
            timer.Stop();
            this.Hide();
         }
    }
}
