using System.Windows.Forms;
using AnignoLibrary.DataTypes.DataManager;
using AnignoProcessMonitorV3.ProcessMonitoring;
using System;
using System.Drawing;

namespace AnignoProcessMonitorV3
{
    public partial class FormMain : Form
    {

		#region (------  Enums  ------)

        private enum ProcessLogActionEnum
        {
            Created,
            Deleted,
            Blocked,
            Error
        }

		#endregion (------  Enums  ------)

		#region (------  Fields  ------)


        private readonly Color PROCESS_ERROR_BACKCOLOR = Color.LightYellow;
        private readonly Color PROCESS_NOT_ALLOWED_BACKCOLOR = Color.FromArgb(255, 192, 192);
        private readonly Color PROCESS_NOT_RUNNING_BACKCOLOR = Color.Green;
private readonly Color PROCESS_RUNNING_BACKCOLOR = Color.LightGreen;
        private ProcessMonitor _processMonitor;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

public FormMain()
        {
            InitializeComponent();
            Init();
        }

		#endregion (------  Constructors  ------)

		#region (------  Event Handlers  ------)

        void _processMonitor_OnProcessAdded(ProcessData processData)
        {
            AddProcessData(processData);
            UpdateProcessListViewItemStyle(processData);
        }

        void _processMonitor_OnProcessBlocked(ProcessData processData)
        {
            AddLogData(processData, ProcessLogActionEnum.Blocked, "Commandline=" + processData.CommandLine);
        }

        void _processMonitor_OnProcessBlockedError(ProcessData processData)
        {
            AddLogData(processData, ProcessLogActionEnum.Error, "Blocking failed for process Commandline=" + processData.CommandLine);
        }

        void _processMonitor_OnProcessCreated(ProcessData processData)
        {
            UpdateProcessListViewItemStyle(processData);
            AddLogData(processData, ProcessLogActionEnum.Created, "Instances=" + processData.Instances);
        }

        void _processMonitor_OnProcessDeleted(ProcessData processData)
        {
            UpdateProcessListViewItemStyle(processData);
            AddLogData(processData, ProcessLogActionEnum.Deleted, "Instances=" + processData.Instances);
        }

        private void allowProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewExtProcesses.SelectedItems)
            {
                ProcessData pd = (ProcessData)item.Tag;
                pd.Allowed = true;
                UpdateProcessListViewItemStyle(pd);
            }
        }

        private void anignoCheckBoxBlocking_OnAfterCheckedChanged(AnignoLibrary.UI.CheckBoxs.AnignoCheckBox checkBox, bool checkState)
        {
        }

        private void listViewExtProcesses_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listViewExtProcesses.SelectedItems.Count < 1) return;
            propertyGridProcess.SelectedObject = listViewExtProcesses.SelectedItems[0].Tag;
        }

        private void listViewLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewLog.SelectedItems.Count < 1) return;
            propertyGridProcess.SelectedObject = listViewLog.SelectedItems[0].Tag;
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Private Methods  ------)

        private void AddLogData(ProcessData processData, ProcessLogActionEnum action, string message)
        {
            ListViewItem item = new ListViewItem(new[] { DateTime.Now.ToLongTimeString(), processData.Name, action.ToString(), message });
            item.Tag = processData;
            listViewLog.Items.Add(item);
            if (action == ProcessLogActionEnum.Created) item.BackColor = PROCESS_RUNNING_BACKCOLOR;
            if (action == ProcessLogActionEnum.Deleted) item.BackColor = PROCESS_NOT_RUNNING_BACKCOLOR;
            if (action == ProcessLogActionEnum.Blocked) item.BackColor = PROCESS_NOT_ALLOWED_BACKCOLOR;
            if (action == ProcessLogActionEnum.Error) item.BackColor = PROCESS_ERROR_BACKCOLOR;


            item.EnsureVisible();
        }

        private void AddProcessData(ProcessData processData)
        {
            ListViewItem item = new ListViewItem(processData.Name);
            item.SubItems.AddRange(new[] { processData.Instances.ToString(), processData.Description, processData.CommandLine, processData.Allowed.ToString() });
            item.Tag = processData;
            listViewExtProcesses.Items.Add(item);
            UpdateProcessListViewItemStyle(processData);
            item.EnsureVisible();
        }

        private ListViewItem GetListViewItem(ProcessData processData)
        {
            foreach (ListViewItem item in listViewExtProcesses.Items)
            {
                if (((ProcessData)item.Tag).CommandLine == processData.CommandLine) return item;
            }
            return null;
        }

        private void Init()
        {
            _processMonitor = new ProcessMonitor();
            foreach (ProcessData pd in DataManagerContractBased<MainData>.DataItem.ProcessesData.Values)
            {
                AddProcessData(pd);
            }
            anignoCheckBoxTwoColorsBlockingEngaged.Checked = DataManagerContractBased<MainData>.DataItem.BlockingEngage;
            _processMonitor.OnProcessAdded += _processMonitor_OnProcessAdded;
            _processMonitor.OnProcessCreated += _processMonitor_OnProcessCreated;
            _processMonitor.OnProcessDeleted += _processMonitor_OnProcessDeleted;
            _processMonitor.OnProcessBlocked += _processMonitor_OnProcessBlocked;
            _processMonitor.OnProcessBlockedError += _processMonitor_OnProcessBlockedError;
        }

        private void UpdateProcessListViewItemStyle(ProcessData processData)
        {
            ListViewItem item = GetListViewItem(processData);
            if (item == null)
            {
                AddLogData(processData, ProcessLogActionEnum.Error, "Process not found in list");
                return;
            }
            item.SubItems[1].Text = processData.Instances.ToString();
            if (processData.Allowed)
            {
                item.BackColor = processData.Instances > 0 ? PROCESS_RUNNING_BACKCOLOR : PROCESS_NOT_RUNNING_BACKCOLOR;
            }
            else
            {
                item.BackColor = PROCESS_NOT_ALLOWED_BACKCOLOR;
            }
            Refresh();
        }

		#endregion (------  Private Methods  ------)

        private void blockProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewExtProcesses.SelectedItems)
            {
                ProcessData pd = (ProcessData)item.Tag;
                pd.Allowed = false;
                _processMonitor.CheckKillProcess(pd,false);
                UpdateProcessListViewItemStyle(pd);
            }
        }

        private void anignoCheckBoxTwoColorsBlockingEngaged_OnCheckedChanged(AnignoLibrary.UI.CheckBoxs.AnignoCheckBoxTwoColors sender, bool checkedState)
        {
            DataManagerContractBased<MainData>.DataItem.BlockingEngage = anignoCheckBoxTwoColorsBlockingEngaged.Checked;
        }

    }
}
