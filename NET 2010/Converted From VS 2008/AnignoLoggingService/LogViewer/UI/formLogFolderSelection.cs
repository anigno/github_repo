using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LogViewer.Managment;

namespace LogViewer
{
    public partial class formLogSelection : Form
    {
        #region Fields
        private LogViewerConfig _config;
        private string _selectedLogFilePath = string.Empty;
        #endregion

        #region Properties
        public string SelectedLogFilePath
        {
            get { return _selectedLogFilePath; }
        }
        #endregion

        #region CTOR
        public formLogSelection(LogViewerConfig config)
        {
            InitializeComponent();
            _config = config;
            UpdateFormControls();
        }
        #endregion

        #region Events handlers
        private void toolStripButtonAddLogPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = false;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    listBoxApplicationLogPath.Items.Add(fbd.SelectedPath);
                    _config.ApplicationLogPath.Add(fbd.SelectedPath);
                }
            }
        }

        private void listBoxApplicationLogPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = false;
            listBoxLogFiles.Items.Clear();
            if (listBoxApplicationLogPath.SelectedIndex < 0) return;
            string searchPath = listBoxApplicationLogPath.SelectedItem.ToString();
            if (!Directory.Exists(searchPath)) return;
            string[] logFiles = Directory.GetFiles(searchPath, "*-0001.log", SearchOption.TopDirectoryOnly);
            listBoxLogFiles.Items.Clear();
            foreach (string file in logFiles)
            {
                listBoxLogFiles.Items.Add(Path.GetFileName(file));
            }
        }

        private void listBoxLogFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxLogFiles.SelectedIndex >= 0)
            {
                buttonOK.Enabled = true;
            }
            else
            {
                buttonOK.Enabled = false;
            }
        }

        private void toolStripButtonRemoveLogPath_Click(object sender, EventArgs e)
        {
            if (listBoxApplicationLogPath.SelectedIndex < 0) return;
            _config.ApplicationLogPath.RemoveAt(listBoxApplicationLogPath.SelectedIndex);
            UpdateFormControls();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (listBoxLogFiles.SelectedIndex < 0) return;
            string s = listBoxApplicationLogPath.SelectedItem.ToString() + "\\" + listBoxLogFiles.SelectedItem.ToString();
            _selectedLogFilePath = s;
        }
        #endregion

        #region Private
        private void UpdateFormControls()
        {
            listBoxApplicationLogPath.Items.Clear();
            listBoxLogFiles.Items.Clear();
            foreach (string s in _config.ApplicationLogPath)
            {
                listBoxApplicationLogPath.Items.Add(s);
            }
        }
        #endregion

    }
}