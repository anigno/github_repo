using System;
using System.Drawing;
using System.Windows.Forms;
using LoggingProvider;
using System.IO;
using LogViewer.Managment;

namespace LogViewer
{
    public partial class formLogViewer : Form
    {

		#region (------  Fields  ------)


        private LogViewerManager _manager = null;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        //private List<LogMessage> _currentDisplayedPage = new List<LogMessage>();
        public formLogViewer()
        {
            InitializeComponent();
            foreach (SeverityEnum e in Enum.GetValues(typeof(SeverityEnum)))
            {
                ListViewItem lvi = new ListViewItem(new[] { "", e.ToString() });
                lvi.Tag = e;
                listViewSeverityFilters.Items.Add(lvi);
            }
            _manager = new LogViewerManager(timerLogFileRead);
            _manager.LoadConfig();
            ShowFilters();
            _manager.OnNewRunDetected += _manager_OnNewRunDetected;
            _manager.OnNewLogMessagesRead += _manager_OnNewLogMessagesRead;
            _manager.OnPageChanged += _manager_OnPageChanged;
            _manager.OnLoadOldPage += _manager_OnLoadOldPage;
        }

		#endregion (------  Constructors  ------)

		#region (------  Event Handlers  ------)

        void _manager_OnLoadOldPage(string pageFile, int errors, int warnings, DateTime startTime, DateTime endTime)
        {
            ListViewItem lvi = new ListViewItem(new[] {
                (listViewPages.Items.Count+1).ToString(),
                Common.GetdateTimeString(startTime),
                Common.GetdateTimeString( endTime),
                errors.ToString(),
                warnings.ToString() });
            listViewPages.Items.Add(lvi);
            lvi.Tag = pageFile;
            lvi.EnsureVisible();
        }

        void _manager_OnNewLogMessagesRead(string pageFile, LogMessage[] newLogMessages, DateTime startTime, DateTime endTime, int totalErrors, int totalWarnings)
        {
            listViewMessages.SuspendLayout();
            foreach (LogMessage message in newLogMessages)
            {
                ListViewItem lvi = GetLogMessageListViewItem(listViewMessages.Items.Count + 1, message);
                listViewMessages.Items.Add(lvi);
            }
            if (listViewMessages.Items.Count > 0)
            {
                listViewMessages.Items[listViewMessages.Items.Count - 1].EnsureVisible();
            }
            listViewMessages.ResumeLayout();
            SetFilters();
            //Update current page (last page)
            listViewLastPage.Items.Clear();
            ListViewItem lviLastPage = new ListViewItem(new[] {
                (listViewPages.Items.Count+1).ToString(),
                Common.GetdateTimeString(startTime),
                Common.GetdateTimeString(endTime),
                totalErrors.ToString(),
                totalWarnings.ToString()
            });
            lviLastPage.Tag = pageFile;
            listViewLastPage.Items.Add(lviLastPage);
        }

        void _manager_OnNewRunDetected(string exeFile)
        {
            //Text = "Log Viewer " + exeFile;
            listViewPages.Items.Clear();
            listViewMessages.Items.Clear();
            //_currentDisplayedPage.Clear();
        }

        void _manager_OnPageChanged()
        {
            listViewMessages.Items.Clear();
            //_currentDisplayedPage.Clear();
        }

        private void checkBoxFiltersActivate_CheckedChanged(object sender, EventArgs e)
        {
            SetFilters();
        }

        private void comboBoxReadInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            _manager.ReadInterval = int.Parse(comboBoxReadInterval.Text) * 1000;
        }


        private void listViewFilters_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ((Filter)e.Item.Tag).Active = e.Item.Checked;
            SetFilters();
        }

        private void listViewLastPage_Click(object sender, EventArgs e)
        {
            if (listViewLastPage.Items.Count <= 0) return;
            string pageFile = (string)listViewLastPage.Items[0].Tag;
            DisplayOldPageData(pageFile);
            listViewLastPage.Items[0].Selected = false;
        }

        private void listViewMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMessages.SelectedItems.Count <= 0) return;
            LogMessage message = (LogMessage)listViewMessages.SelectedItems[0].Tag;
            richTextBoxText.Text = message.Text;
            
            textBoxTime.Text = message.Time + "." + message.Time.Millisecond;
            textBoxMethod.Text = message.MethodName;
            textBoxClass.Text = message.ClassName;
            textBoxThread.Text = message.ThreadId;
            textBoxAssembly.Text = message.AssemblyName;
            textBoxSeverity.Text = message.Severity.ToString();
        }

        private void listViewPages_Click(object sender, EventArgs e)
        {
            if (listViewPages.SelectedIndices.Count == 0) return;
            string pageFile = (string)listViewPages.SelectedItems[0].Tag;
            DisplayOldPageData(pageFile);
        }

        private void listViewPages_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listViewSeverityFilters_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            SetFilters();
        }

        private void toolStripButtonAddFilter_Click(object sender, EventArgs e)
        {
            using (formFilterAddEdit f = new formFilterAddEdit())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Filter filter=new Filter();
                    filter.FilterType=f.FilterType;
                    filter.FilterWildCard=f.FilterWildCard;
                    _manager.Config.Filters.Add(filter);
                    ShowFilters();
                }

            }
        }

        private void toolStripButtonOpenExe_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "EXE|*.exe";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _manager.SetExeFile(ofd.FileName);
                }
            }
        }

        private void toolStripButtonOpenFolder_Click(object sender, EventArgs e)
        {
            using (formLogSelection f = new formLogSelection(_manager.Config))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _manager.SetCurrentPageFile(f.SelectedLogFilePath);
                }
            }
        }

        private void toolStripButtonRemoveFilter_Click(object sender, EventArgs e)
        {
            if (listViewFilters.SelectedItems.Count <= 0) return;
            Filter f = (Filter)listViewFilters.SelectedItems[0].Tag;
            _manager.Config.Filters.Remove(f);
            ShowFilters();
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            toolStripButtonStart.Enabled = false;
            toolStripButtonStop.Enabled = true;
            _manager.SetActive(true);
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            toolStripButtonStart.Enabled = true;
            toolStripButtonStop.Enabled = false;
            _manager.SetActive(false);
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Private Methods  ------)

        private void DisplayOldPageData(string pageFile)
        {
            TextReader tr = new StreamReader(pageFile);
            listViewMessages.Items.Clear();
            while (tr.Peek() >= 0)
            {
                string s = tr.ReadLine();
                LogMessage message = LogMessage.FromString(s);
                ListViewItem lvi = GetLogMessageListViewItem(listViewMessages.Items.Count + 1, message);
                listViewMessages.Items.Add(lvi);
            }
            tr.Close();
            SetFilters();
        }

        private ListViewItem GetLogMessageListViewItem(int number, LogMessage message)
        {
            ListViewItem lvi = new ListViewItem(new[]
                                                    {
                                                        number.ToString(),
                                                        Common.GetdateTimeString(message.Time),
                                                        message.Text,
                                                        message.MethodName,
                                                        message.ClassName,
                                                        message.AssemblyName,
                                                        message.ThreadId,
                                                        message.Severity.ToString()
                                                    });
            lvi.Tag = message;
            return lvi;
        }

        private void SetFilters()
        {
            //Iterate through current page messages and filter them
            foreach (ListViewItem lviMessage in listViewMessages.Items)
            {
                LogMessage message = (LogMessage)lviMessage.Tag;
                bool itemFilterizedIn = true;
                //Filter in severity
                foreach (ListViewItem item in listViewSeverityFilters.CheckedItems)
                {
                    SeverityEnum se = (SeverityEnum)item.Tag;
                    if (message.Severity != se)
                    {
                        itemFilterizedIn = false;
                    }
                    else
                    {
                        itemFilterizedIn = true;
                        break;
                    }
                }
                //check filters
                if (checkBoxFiltersActivate.Checked)
                {
                    foreach (ListViewItem item in listViewFilters.CheckedItems)
                    {
                        string checkedText = string.Empty;
                        Filter filter = (Filter)item.Tag;
                        switch (filter.FilterType)
                        {
                            case FilterTypeEnum.Assembly:
                                checkedText = lviMessage.SubItems[5].Text;
                                break;
                            case FilterTypeEnum.Class:
                                checkedText = lviMessage.SubItems[4].Text;
                                break;
                            case FilterTypeEnum.Method:
                                checkedText = lviMessage.SubItems[3].Text;
                                break;
                            case FilterTypeEnum.Text:
                                checkedText = lviMessage.SubItems[2].Text;
                                break;
                            case FilterTypeEnum.Thread:
                                checkedText = lviMessage.SubItems[6].Text;
                                break;
                        }
                        if (filter.FilteredIn(checkedText))
                        {
                            itemFilterizedIn &= true;
                        }
                        else
                        {
                            itemFilterizedIn &= false;
                        }
                    }
                }
                if (itemFilterizedIn == false)
                {
                    //apply not filtered in color
                    lviMessage.BackColor = Color.Gray;
                    lviMessage.ForeColor = Color.DarkGray;
                }
                else
                {
                    //Apply filtered in severity color
                    lviMessage.ForeColor = Color.Black;
                    switch (message.Severity)
                    {
                        case SeverityEnum.Debug:
                            lviMessage.BackColor = Color.LightGreen;
                            break;
                        case SeverityEnum.Info:
                            lviMessage.BackColor = Color.LightBlue;
                            break;
                        case SeverityEnum.Warning:
                            lviMessage.BackColor = Color.Khaki;
                            break;
                        case SeverityEnum.Error:
                            lviMessage.BackColor = Color.LightCoral;
                            break;
                    }
                }
            }
        }

        private void ShowFilters()
        {
            listViewFilters.Items.Clear();
            foreach (Filter f in _manager.Config.Filters)
            {
                ListViewItem lvi = new ListViewItem(new[] { "",f.FilterType.ToString(), f.FilterWildCard });
                lvi.Tag = f;
                if (f.Active) lvi.Checked = true;
                listViewFilters.Items.Add(lvi);
            }
        }

		#endregion (------  Private Methods  ------)

        private void formLogViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _manager.SaveConfig();
        }

        private void formLogViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            //_manager.SaveConfig();
        }

/*
        private void checkBoxUseColors_CheckedChanged(object sender, EventArgs e)
        {
            //_controller.UseColors = checkBoxUseColors.Checked;
        }
*/

    }
}