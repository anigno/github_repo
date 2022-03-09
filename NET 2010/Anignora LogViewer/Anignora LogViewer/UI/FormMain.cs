using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AnignoraCommonAndHelpers.Tracers;
using AnignoraDataTypes;
using AnignoraUI.Common;
using Anignora_LogViewer.BL;
using Anignora_LogViewer.BL.Filtering;
using log4net;
using log4net.Util;

namespace Anignora_LogViewer.UI
{
    public partial class FormMain : Form
    {
		#region (------  Fields  ------)
        private readonly string m_applicationNameAndVersion;
        private readonly FilteringManager m_filteringManager=new FilteringManager();
        private readonly LogHistoryReader m_logHistoryReader = new LogHistoryReader();
        private readonly List<string[]> m_logLinesList=new List<string[]>();
        private readonly LogReader m_logReader = new LogReader(new TracerNull());
        private string m_presentedLogFile;
        private static readonly ILog s_logger = LogManager.GetLogger(SystemInfo.ApplicationFriendlyName);
		#endregion (------  Fields  ------)

		#region (------  Events Handlers  ------)
        private void onFilteringManagerFilterAdded(object p_sender,BL.EventArgs.FilterChangedEventArgs p_e)
        {
            listViewFilters.Items.Add(p_e.FilterName);
        }

        private void onFilteringManagerFilterChanged(object p_sender, BL.EventArgs.FilterChangedEventArgs p_e)
        {
            reloadLogLinesFromList();
        }

        private void onFilteringManagerFilterRemoved(object p_sender,BL.EventArgs.FilterChangedEventArgs p_e)
        {
            int selectedltemlndex = listViewFilters.SelectedItems[0].Index;
            listViewFilters.Items.RemoveAt(selectedltemlndex);
            reloadLogLinesFromList();
        }

        private void onFormMainLoad(object p_sender, EventArgs p_e)
        {
            toolStripComboBoxUpdateInterval.Text = "3";
        }

        private void onListViewLinesClick(object p_sender, EventArgs p_e)
        {
            if (listViewLines.SelectedItems.Count == 0) return;
            changeLogLineDetails();
        }

        private void onLogHistoryReaderHistoryFileRead(object p_sender, BL.EventArgs.HistoryFileEventArgs p_e)
        {
            CrossThreadActivities.Do(this, p_main =>
                                               {
                                                   string[] sa = {
                                                                     p_e.FileData.SIndex,
                                                                     p_e.FileData.Warnings.ToString(),
                                                                     p_e.FileData.Errors.ToString(),
                                                                     p_e.FileData.Fatals.ToString(),
                                                                     p_e.FileData.SStartTime,
                                                                     p_e.FileData.SEndTime
                                                                 };
                                                   ListViewItem item = new ListViewItem(sa);
                                                   item.Tag = p_e.FileData.FilePath;
                                                   listViewHistory.Items.Add(item);
                                                   item.EnsureVisible();
                                               }
                );
        }

        private void onLogHistoryReaderPatternChanged(object p_sender,
                                                      BL.EventArgs.PatternEventArgs p_e)
        {
            CrossThreadActivities.Do(this, p_main =>
                                               {
                                                   s_logger.DebugFormat("History pattern changed to:[{0}] [{1}]", p_e.Path, p_e.Pattern);
                                                   listViewHistory.Items.Clear();
                                               });
        }

        private void onLogReaderLogFileChanged(object p_sender,
                                               BL.EventArgs.LogFileChangedEventArgs p_e)
        {
            s_logger.DebugFormat("new file: {0}",p_e.LogFilename);
            CrossThreadActivities.Do(this, p_main =>
                                               {
                                                   toolStripLabelCurrentLogFile.Text = p_e.LogFilename;
                                                   m_logLinesList.Clear();
                                                   clearListViewLines();
                                                   m_presentedLogFile = p_e.LogFilename;
                                               });
        }

        private void onLogReaderLogLinesRead(object p_sender,
                                             BL.EventArgs.LogLinesChangesEventArgs p_e)
        {
            CrossThreadActivities.Do(this, p_main =>
                                               {
                                                   ListViewItem lastltemAdded = null;
                                                   p_e.LogLines.DoForAll(p_line =>
                                                                             {
                                                                                 addNewLogLineToList(p_line);
                                                                                 lastltemAdded = addLogLineToListView(p_line);
                                                                             });
                                                   ensureLastltemVisible(listViewLines, lastltemAdded);
                                                   m_logHistoryReader.SetHistoryPattern(LogPath, LogPattern, false);
                                                   updateLastHistoryFile(p_e.LogLines, m_presentedLogFile)
                                                       ;
                                               });
        }

        private void onToolStripButtonAddFilterClick(object p_sender, EventArgs p_e)
        {
            FilterData filterData = new FilterData();
            FormFilter formFilter = new FormFilter(filterData, m_filteringManager.FiltersNames);
            DialogResult result = formFilter.ShowDialog();
            if (result == DialogResult.OK)
            {
                m_filteringManager.AddFilter(filterData);
            }
        }

        private void onToolStripButtonSelectExeClick(object p_sender, EventArgs p_e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.Filter = "Applications|*.EXE|Dlls|*.DLL|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.GetDirectoryName(ofd.FileName) + @"\" + "_logs";
                    m_logReader.SetLogFilesPath(path);
                    m_logHistoryReader.SetHistoryPath(path, true);
                    toolStripLabelCurrentLogFile.Text = ofd.FileName;
                    m_logLinesList.Clear();
                    clearListViewLines();
                }
            }
        }

        private void onToolStripButtonSelectLogFileClick(object p_sender, EventArgs p_e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.Filter = "Log Files|Log-*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.GetDirectoryName(ofd.FileName);
                    string pattern = LogReader.ExtractPatternFormFilePath(ofd.FileName);
                    m_logHistoryReader.SetHistoryPattern(path, pattern, true);
                    m_logReader.SetLogFilesPath(path);
                    toolStripLabelCurrentLogFile.Text = ofd.FileName;
                    m_logLinesList.Clear();
                    clearListViewLines();
                }
            }
        }

        private void onToolStripButtonStartClick(object p_sender, EventArgs p_e)
        {
            m_logLinesList.Clear();
            clearListViewLines();
            m_logReader.Start();
            listViewHistory.Enabled = false;
            toolStripButtonStart.Enabled = false;
            toolStripButtonStop.Enabled = true;
            listViewHistory.SelectedIndices.Clear();
        }

        private void onToolStripButtonStopClick(object p_sender, EventArgs p_e)
        {
            m_logReader.Stop();
            listViewHistory.Enabled = true;
            toolStripButtonStart.Enabled = true;
            toolStripButtonStop.Enabled = false;
        }

        private void onToolStripComboBoxUpdatelntervalDropDownClosed(object p_sender, EventArgs p_e)
        {
            int i = int.Parse(toolStripComboBoxUpdateInterval.Text);
            m_logReader.SetReadInterval(i*1000);
        }

        private void onListViewFiltersItemChecked(object p_sender, ItemCheckedEventArgs p_e)
        {
            int filterIndex = p_e.Item.Index;
            m_filteringManager.SetFilterEnable(filterIndex, p_e.Item.Checked);
        }

        private void onToolStripButtonFilterEditClick(object p_sender, EventArgs p_e)
        {
            if (listViewFilters.SelectedItems.Count == 0) return;
            string filterName = listViewFilters.SelectedItems[0].Text;
            FilterData filterData = m_filteringManager.GetFilterData(filterName);
            FormFilter f = new FormFilter(filterData, m_filteringManager.FiltersNames);
            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                listViewFilters.SelectedItems[0].Text = f.FilterDataItem.FilterName;
                reloadLogLinesFromList();
            }
        }

        private void onListViewLinesSelectedIndexChanged(object p_sender, EventArgs p_e)
        {
            if (listViewLines.SelectedItems.Count == 0) return;
            changeLogLineDetails();
        }

        private void onListViewHistorySelectedIndexChanged(object p_sender, EventArgs p_e)
        {
            if (listViewHistory.SelectedIndices.Count == 0) return;
            string requestedLogFile = (string)listViewHistory.SelectedItems[0].Tag;
            updateLogLinesListFromHistory(requestedLogFile);
        }
		#endregion (------  Events Handlers  ------)

		#region (------  Private Methods  ------)
        private ListViewItem addLogLineToListView(string[] p_line)
        {
            bool isFilteredln = m_filteringManager.IsFilteredln(p_line);
            if (isFilteredln)
            {
                ListViewItem item = new ListViewItem(p_line);
                item.Tag = p_line;
                item.BackColor = GetLevelColor(p_line);
                listViewLines.Items.Add(item);
                return item;
            }
            return null;
        }

        private void addNewLogLineToList(string[] p_line)
        {
            m_logLinesList.Add(p_line);
            p_line[7] = m_logLinesList.Count.ToString();
        }

        private void changeLogLineDetails()
        {
            string[] line = (string[])listViewLines.SelectedItems[0].Tag;
            textBoxTime.Text = line[0];
            textBoxLevel.Text = line[1];
            textBoxLogger.Text = line[2];
            textBoxType.Text = line[3];
            textBoxMethod.Text = line[4];
            textBoxMessage.Text = line[5];
            textBoxThread.Text = line[6];
        }

        private void clearListViewLines()
        {
            listViewLines.Items.Clear();
        }

        private static void ensureLastltemVisible(ListView p_listView, ListViewItem p_knownLastItem)
        {
            if (p_knownLastItem != null)
            {
                p_knownLastItem.EnsureVisible();
            }
            else if (p_listView.Items.Count > 0)
            {
                int lastlndex = p_listView.Items.Count - 1;
                p_knownLastItem = p_listView.Items[lastlndex];
                p_knownLastItem.EnsureVisible();
            }
        }

        private void reloadLogLinesFromList()
        {
            CrossThreadActivities.Do(this, p_main =>
                                               {
                                                   listViewLines.Visible = false;
                                                   ListViewItem lastltem = null;
                                                   clearListViewLines();
                                                   lock (m_logLinesList)
                                                   {
                                                       m_logLinesList.DoForAll(p_line =>
                                                                                   {
                                                                                       lastltem = addLogLineToListView(p_line);
                                                                                   });
                                                       ensureLastltemVisible(listViewLines, lastltem);
                                                   }
                                                   listViewLines.Visible = true;
                                               });
        }

        private void toolStripButtonRemoveFilterClick(object p_sender, EventArgs p_e)
        {
            if (listViewFilters.SelectedItems.Count == 0) return;
            int filterIndex = listViewFilters.SelectedIndices[0];
            m_filteringManager.RemoveFilter(filterIndex);
            reloadLogLinesFromList();
        }

        private void updateLastHistoryFile(string[][] p_logLines, string p_filrPath)
        {
            CrossThreadActivities.Do(this, p_main =>
                                               {
                                                   if (listViewHistory.Items.Count == 0) return;
                                                   HistoryFileData historyFileData = LogHistoryReader.AnalyzeLogLinesData(p_logLines, p_filrPath);
                                                   ListViewItem.ListViewSubItemCollection lastSubltems =
                                                       listViewHistory.Items[listViewHistory.Items.Count - 1].SubItems;
                                                   lastSubltems[5].Text = historyFileData.SEndTime;
                                                   int fatals = int.Parse(lastSubltems[3].Text);
                                                   int errors = int.Parse(lastSubltems[2].Text);
                                                   int warns = int.Parse(lastSubltems[1].Text);
                                                   fatals += historyFileData.Fatals;
                                                   errors += historyFileData.Errors;
                                                   warns += historyFileData.Warnings;
                                                   lastSubltems[3].Text =
                                                       fatals.ToString();
                                                   lastSubltems[2].Text =
                                                       errors.ToString();
                                                   lastSubltems[1].Text =
                                                       warns.ToString();
                                               });
        }

        private void updateLogLinesListFromHistory(string p_requestedLogFile)
        {
            listViewLines.Visible = false;
            m_logLinesList.Clear();
            clearListViewLines();
            string[][] logLines = m_logHistoryReader.GetHistoryLogFile(p_requestedLogFile);
            
            logLines.DoForAll(p_line =>
            {
                addNewLogLineToList(p_line);
                if (m_filteringManager.IsFilteredln(p_line))
                {
                    addLogLineToListView(p_line);
                }
            });
            listViewLines.Visible = true;
        }
		#endregion (------  Private Methods  ------)



        #region (---Constructors---)

        public FormMain()
        {
            InitializeComponent();
            m_applicationNameAndVersion = string.Format("{0} {1}", Application.ProductName, Application.ProductVersion);
            base.Text = m_applicationNameAndVersion;
            m_logReader.LogFileChanged += onLogReaderLogFileChanged;
            m_logReader.LogLinesRead += onLogReaderLogLinesRead;
            m_logHistoryReader.HistoryFileRead += onLogHistoryReaderHistoryFileRead;
            m_logHistoryReader.PatternChanged += onLogHistoryReaderPatternChanged;
            m_filteringManager.FilterAdded += onFilteringManagerFilterAdded;
            m_filteringManager.FilterChanged += onFilteringManagerFilterChanged;
            m_filteringManager.FilterRemoved += onFilteringManagerFilterRemoved;
            m_logHistoryReader.Start();
        }

        #endregion (--- Constructors ---)


        #region (---Properties---)

        private string LogPath
        {
            get { return Path.GetDirectoryName(m_presentedLogFile); }
        }

        private string LogPattern
        {
            get { return Path.GetFileNameWithoutExtension(m_presentedLogFile); }
        }

        #endregion (--- Properties ---)


        #region (--- Public Static Methods ---)

        public static Color GetLevelColor(string[] p_line)
        {
            string level = p_line[1];
            switch (level)
            {
                case Common.DEBUG_STRING:
                    return Color.LightGreen;
                case Common.INFO_STRING:
                    return Color.LightBlue;
                case Common.WARN_STRING:
                    return Color.PeachPuff;
                case Common.ERROR_STRING:
                    return Color.Pink;
                case Common.FATAL_STRING:
                    return Color.Red;
                default:
                    return Color.LightGray;
            }
        }

        #endregion (--- Public Static Methods ---)
    }
}