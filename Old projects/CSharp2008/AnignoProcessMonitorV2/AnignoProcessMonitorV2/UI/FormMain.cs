using System;
using System.Windows.Forms;
using AnignoProcessMonitorV2.Data;
using LoggingProvider;
using System.IO;
using AnignoLibrary.Helpers;
using AnignoLibrary.UI.Forms;
using System.Drawing;

namespace AnignoProcessMonitorV2.UI
{
    public partial class FormMain : Form
    {

		#region Fields (1) 


        private readonly ProcessMonitor _monitor = new ProcessMonitor();

		#endregion Fields 

		#region Constructors (1) 

        public FormMain()
        {
            InitializeComponent();
            UpdateFormControls();
            listViewProcessesMain.OnAllowUpdated += listViewProcessesMain_OnAllowUpdated;
            listViewProcessesMain.OnAnnounceUpdated += listViewProcessesMain_OnAnnounceUpdated;
            listViewProcessesMain.OnDescriptionUpdated += listViewProcessesMain_OnDescriptionUpdated;
            _monitor.OnProcessAddedToProcessList += _monitor_OnProcessAddedToProcessList;
            _monitor.OnProcessInstancesChanged += _monitor_OnProcessInstancesChanged;
            _monitor.OnProcessBlocked += _monitor_OnProcessBlocked;
            _monitor.Start();
        }

		#endregion Constructors 

		#region Delegates (1) 

        private delegate void ListViewLogAddItemDelegate(string action,string fileName,string description,Color color);

		#endregion Delegates 

		#region Event Handlers (23) 

        void _monitor_OnProcessAddedToProcessList(ProcessDataEntity processData)
        {
            Logger.LogDebug("_monitor_OnProcessAddedToProcessList: Process={0}", processData.ProcessDescriptor);
            listViewProcessesMain.AddProcessItemInvoked(processData.ProcessDescriptor, processData.IsSystemProcess, Path.GetFileNameWithoutExtension(processData.ProcessDescriptor), processData.ProcessDescription, 0, processData.ProcessAnnounceAllow, processData.ProcessAllowed);
        }

        void _monitor_OnProcessBlocked(string descriptor, uint pid)
        {
            Logger.LogDebug("_monitor_OnProcessBlocked: Process={0} pid={1}", descriptor,pid);
            ListViewLogAddItemInvoked("Blocked", Path.GetFileNameWithoutExtension(descriptor), "pid=" + pid + " Full path=" + descriptor, Color.LightSalmon);
            notifyIconMain.ShowBalloonTip(5000, "Anigno Process Monitor V2", "Process blocked: " + descriptor, ToolTipIcon.Info);
        }

        void _monitor_OnProcessInstancesChanged(ProcessDataEntity processData, uint instances,uint oldInstances)
        {
            Logger.LogDebug("_monitor_OnProcessInstancesChanged: Process={0} instances={1}", processData.ProcessDescriptor, instances);
            listViewProcessesMain.UpdateInstancesInvoked(processData.ProcessDescriptor, instances);
            if (instances > oldInstances)
            {
                ListViewLogAddItemInvoked("Instance Created", Path.GetFileNameWithoutExtension(processData.ProcessDescriptor), " Instances: " + instances + " Full path=" + processData.ProcessDescriptor, Color.LightGreen);
            }
            else
            {
                ListViewLogAddItemInvoked("Instances Deleted", Path.GetFileNameWithoutExtension(processData.ProcessDescriptor), " Instances: " + instances + " Full path=" + processData.ProcessDescriptor, Color.YellowGreen);
            }
        }

        private void addToSystemProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log();
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                string descriptor = item.SubItems[5].Text;
                ProcessDataEntity processData = _monitor.GetProcessData(descriptor);
                processData.IsSystemProcess = true;
                listViewProcessesMain.SetIsSystemInvoked(descriptor, true);
                //Read data again because system process cannot be blocked
                listViewProcessesMain.SetAllowInvoked(descriptor, _monitor.GetProcessData(descriptor).ProcessAllowed);
                ListViewLogAddItemInvoked("System processes", Path.GetFileName(descriptor), "Process:" + descriptor + " was added", Color.Khaki);
            }
        }

        private void allowProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log();
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                string descriptor = item.SubItems[5].Text;
                ProcessDataEntity processData = _monitor.GetProcessData(descriptor);
                processData.ProcessAllowed = true;
                listViewProcessesMain.SetAllowInvoked(descriptor, true);
                ListViewLogAddItemInvoked("Allow processes", Path.GetFileName(descriptor), "Process:" + descriptor + " will be Allowed", Color.Khaki);
            }
        }

        private void announceProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log();
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                string descriptor = item.SubItems[5].Text;
                ProcessDataEntity processData = _monitor.GetProcessData(descriptor);
                processData.ProcessAnnounceAllow = true;
                listViewProcessesMain.SetAnnounceInvoked(descriptor, true);
            }
        }

        private void blockProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log();
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                string descriptor = item.SubItems[5].Text;
                ProcessDataEntity processData = _monitor.GetProcessData(descriptor);
                processData.ProcessAllowed = false;
                //Read data again because system process cannot be blocked
                _monitor.UpdateAllow(descriptor, processData.ProcessAllowed);
                listViewProcessesMain.SetAllowInvoked(descriptor, processData.ProcessAllowed);
                if (!processData.ProcessAllowed)
                {
                    ListViewLogAddItemInvoked("Block processes", Path.GetFileName(descriptor), "Process:" + descriptor + " will be blocked", Color.Khaki);
                }
                else
                {
                    ListViewLogAddItemInvoked("Block processes failed", Path.GetFileName(descriptor), "Process:" + descriptor + " couldn't be blocked", Color.Gold);
                }
            }
        }

        private void buttonRoundedGlowClearProcesses_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            Logger.Log();
            if (MessageBox.Show(this, "Erase processes with no description?\n", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            foreach (ListViewItem listViewitem in listViewProcessesMain.Items)
            {
                string descriptor = listViewitem.SubItems[5].Text;
                string Description = listViewitem.SubItems[1].Text;
                if (Description == string.Empty)
                {
                    ProcessDataEntity processData=_monitor.GetProcessData(descriptor);
                    if (!processData.ProcessAllowed)
                    {
                        listViewProcessesMain.RemoveProcessItemInvoked(descriptor);
                        _monitor.RemoveKnownProcess(descriptor);
                        ListViewLogAddItemInvoked("Erased processes", Path.GetFileName(descriptor), "Process:" + descriptor + " was erased", Color.Khaki);
                    }
                    else
                    {
                        ListViewLogAddItemInvoked("Erased processes", Path.GetFileName(descriptor), "Process:" + descriptor + " is allowed and was not erased", Color.Gold);
                    }
                }
            }
        }

        private void buttonRoundedGlowEraseProcesses_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            Logger.Log();
            if (listViewProcessesMain.SelectedItems.Count == 0) return;
            string items = string.Empty;
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                items += item.SubItems[0].Text + "\n";
            }
            if (MessageBox.Show(this, "Erase selected processes?\n" + items, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                string descriptor = item.SubItems[5].Text;
                listViewProcessesMain.RemoveProcessItemInvoked(descriptor);
                _monitor.RemoveKnownProcess(descriptor);
                ListViewLogAddItemInvoked("Erased processes", Path.GetFileName(descriptor), "Process:" + descriptor + " was erased", Color.Khaki);
            }
        }

        private void buttonRoundedGlowKillProcesses_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            Logger.Log();
            if (listViewProcessesMain.SelectedItems.Count == 0) return;
            string items=string.Empty;
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                items += item.SubItems[0].Text + "\n";
            }
            if (MessageBox.Show(this, "Kill selected processes?\n"+items, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                string descriptor = item.SubItems[5].Text;
                _monitor.KillAllInstances(descriptor);
                ListViewLogAddItemInvoked("Kill processes", Path.GetFileName(descriptor), "Process:" + descriptor + " was killed", Color.Khaki);
            }
        }

        private void buttonRoundedGlowRenameProcesses_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            Logger.Log();
            if (listViewProcessesMain.SelectedItems.Count == 0) return;
            string items = string.Empty;
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                items += item.SubItems[0].Text + "\n";
            }
            if (MessageBox.Show(this, "Rename selected processes?\n" + items, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                string descriptor = item.SubItems[5].Text;
                _monitor.UpdateAllow(descriptor, false);
                _monitor.KillAllInstances(descriptor);
                if (_monitor.RenameProcess(descriptor))
                {
                    ListViewLogAddItemInvoked("Renamed", Path.GetFileName(descriptor), "File was renamed to: " + descriptor + "_", Color.Khaki);
                }
                else
                {
                    ListViewLogAddItemInvoked("Renamed", Path.GetFileName(descriptor), "Failed to rename to: " + descriptor + "_", Color.Gold);
                }
            }
        }

        private void checkBoxAnnounceActive_CheckedChanged(object sender, EventArgs e)
        {
            Logger.Log();
            _monitor.AnnounceActive = checkBoxAnnounceActive.Checked;
        }

        private void checkBoxColoredBlockingActive_CheckedChanged(object sender, EventArgs e)
        {
            Logger.Log();
            _monitor.BlockingActive = checkBoxColoredBlockingActive.Checked;
            panelRoundedContainerBlocking.ColorFirst = panelRoundedContainerBlocking.ColorSecond = checkBoxColoredBlockingActive.Checked ? checkBoxColoredBlockingActive.ColorChecked : checkBoxColoredBlockingActive.ColorUnChecked;
        }

        private void DoNotAnnounceProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log();
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                string descriptor = item.SubItems[5].Text;
                ProcessDataEntity processData = _monitor.GetProcessData(descriptor);
                processData.ProcessAnnounceAllow = false;
                listViewProcessesMain.SetAnnounceInvoked(descriptor, false);
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.Log();
            _monitor.Stop();
            //Gets here only in application has ended correctly
            _monitor.IsApplicationClosedCorrectly = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Text += " V"+Program.VERSION_STRING;
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = false;
            }
        }

        private void googleProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log();
            using (FormWebBrowser wb = new FormWebBrowser())
            {
                wb.TopMost=true;
                foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
                {
                    string descriptor = item.SubItems[5].Text;
                    string fileName = Path.GetFileName(descriptor);
                    wb.Navigate(@"http://www.google.co.il/search?hl=en&q=process+information+%22" + fileName + "%22");
                    wb.ShowDialog(this);
                }
            }
        }

        void listViewProcessesMain_OnAllowUpdated(string descriptor, string newData)
        {
            Logger.LogDebug("ProcessDescriptor={0} newData={1}", descriptor, newData);
            bool isAllow = (newData == ListViewProcesses.ALLOW_TRUE);
            _monitor.UpdateAllow(descriptor, isAllow);
            //Read data again because system process cannot be blocked
            listViewProcessesMain.SetAllowInvoked(descriptor, _monitor.GetProcessData(descriptor).ProcessAllowed);
            ListViewLogAddItemInvoked("Allowed changed", Path.GetFileName(descriptor), "Process:" + descriptor + " Allowed is: " + _monitor.GetProcessData(descriptor).ProcessAllowed, Color.Khaki);
        }

        void listViewProcessesMain_OnAnnounceUpdated(string descriptor, string newData)
        {
            Logger.LogDebug("ProcessDescriptor={0} newData={1}", descriptor, newData);
            _monitor.UpdateAnnounce(descriptor, (newData == ListViewProcesses.ANNOUNCE_TRUE));
        }

        void listViewProcessesMain_OnDescriptionUpdated(string descriptor, string newData)
        {
            Logger.LogDebug("ProcessDescriptor={0} newData={1}", descriptor, newData);
            _monitor.UpdateDescription(descriptor, newData);
            ListViewLogAddItemInvoked("Process description", Path.GetFileName(descriptor), "Process:" + descriptor + " description changed", Color.Khaki);
        }

        private void notifyIconMain_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
            if (Visible)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void removeFromSystemProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Log();
            foreach (ListViewItem item in listViewProcessesMain.SelectedItems)
            {
                string descriptor = item.SubItems[5].Text;
                ProcessDataEntity processData = _monitor.GetProcessData(descriptor);
                processData.IsSystemProcess = false;
                listViewProcessesMain.SetIsSystemInvoked(descriptor, false);
            }
        }

		#endregion Event Handlers 

		#region Private Methods (1) 

        private void ListViewLogAddItemInvoked(string action,string fileName,string description,Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ListViewLogAddItemDelegate(ListViewLogAddItemInvoked), action, fileName, description, color);
            }
            else
            {
                ListViewItem item = new ListViewItem(new[] { StringHelper.GetDateTimeString(), action, fileName, description });
                listViewLog.Items.Add(item);
                item.BackColor=color;
                item.EnsureVisible();
                listViewLog.Refresh();
            }

        }

		#endregion Private Methods 

		#region Public Methods (1) 

        public void UpdateFormControls()
        {
            Logger.Log();
            //Update known processes
            ProcessDataEntity[] processes = _monitor.GetKnownProcesses();
            Logger.LogDebug("UpdateFormControls: Found {0} known processes", processes.Length);
            foreach (ProcessDataEntity processData in processes)
            {
                listViewProcessesMain.AddProcessItemInvoked(processData.ProcessDescriptor, processData.IsSystemProcess, Path.GetFileNameWithoutExtension(processData.ProcessDescriptor), processData.ProcessDescription, 0, processData.ProcessAnnounceAllow, processData.ProcessAllowed);
            }
            checkBoxColoredBlockingActive.Checked = _monitor.BlockingActive;
            checkBoxAnnounceActive.Checked = _monitor.AnnounceActive;

        }

		#endregion Public Methods 

    }
}