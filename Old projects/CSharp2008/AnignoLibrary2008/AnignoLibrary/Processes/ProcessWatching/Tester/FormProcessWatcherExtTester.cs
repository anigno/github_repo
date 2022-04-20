using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoLibrary.Processes.ProcessMonitoring.Tester
{
    public partial class FormProcessWatcherExtTester : Form
    {
        private delegate void InvokedMethodWithString(string s);
        private readonly ProcessWatcherExt_old watcher = new ProcessWatcherExt_old();

        public FormProcessWatcherExtTester()
        {
            InitializeComponent();
            watcher.OnProcessFoundRunning += new OnProcessWatcherExtActionDelegate(watcher_OnProcessFoundRunning);
            watcher.OnProcessCreated += new OnProcessWatcherExtActionDelegate(watcher_OnProcessCreated);
            watcher.OnProcessDeleted += new OnProcessWatcherExtActionDelegate(watcher_OnProcessDeleted);
            watcher.Start();
        }

        void watcher_OnProcessDeleted(string processFullPath)
        {
            if (InvokeRequired)
            {
                Invoke(new InvokedMethodWithString(watcher_OnProcessDeleted), processFullPath);
            }
            else
            {
                listBox1.Items.Add("watcher_OnProcessDeleted: "+processFullPath);
            }
        }

        void watcher_OnProcessCreated(string processFullPath)
        {
            if (InvokeRequired)
            {
                Invoke(new InvokedMethodWithString(watcher_OnProcessCreated), processFullPath);
            }
            else
            {
                listBox1.Items.Add("watcher_OnProcessCreated: " + processFullPath);
            }
        }

        void watcher_OnProcessFoundRunning(string processFullPath)
        {
            if (InvokeRequired)
            {
                Invoke(new InvokedMethodWithString(watcher_OnProcessFoundRunning), processFullPath);
            }
            else
            {
                listBox1.Items.Add("watcher_OnProcessFoundRunning: " + processFullPath);
            }
        }

        private void FormProcessWatcherExtTester_FormClosed(object sender, FormClosedEventArgs e)
        {
            watcher.Stop();
        }
    }
}
