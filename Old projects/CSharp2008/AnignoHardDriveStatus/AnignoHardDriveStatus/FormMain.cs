using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AnignoHardDriveStatus
{
    public partial class FormMain : Form
    {
        private Dictionary<string, DriveInfo> drivesInforDictionary = new Dictionary<string, DriveInfo>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo di in drives)
            {
                if (!di.IsReady) continue;
                string driveDescriptor = string.Format("{0} [{1}]", di.Name, di.VolumeLabel);
                comboBoxDrives.Items.Add(driveDescriptor);
                drivesInforDictionary.Add(driveDescriptor, di);
            }
            comboBoxDrives.SelectedIndex = 0;
        }

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDrives.SelectedIndex < 0) return;
            DriveInfo di = drivesInforDictionary[comboBoxDrives.SelectedItem.ToString()];
            anignoRoundGaugeDrive.Maximum = (float)di.TotalSize / 1024 / 1024 ;
            anignoRoundGaugeDrive.Value = (float)di.TotalFreeSpace / 1024 / 1024 ;
            anignoRoundGaugeDrive.Text = ((long)anignoRoundGaugeDrive.Value).ToString()+" MB";
        }
    }
}