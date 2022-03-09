using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using AnignoraCommonAndHelpers;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using AnignoraFinanceAnalyzer4.Data;
using AnignoraFinanceAnalyzer4.UI.Controls;
using AnignoraUI;
using AnignoraUI.Common;
using Timer = System.Windows.Forms.Timer;
using System.Linq;
using LoggingProvider;

namespace AnignoraFinanceAnalyzer4.UI.Forms
{
    public partial class FormMain : Form
    {
		#region (------  Fields  ------)

        private MainApplicationManager m_applicationManager;
        private string m_lastSelectedSymbol;
        private Timer m_timerRefresh;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public FormMain()
        {
            InitializeComponent();
        }

		#endregion (------  Constructors  ------)

		#region (------  Protected Methods  ------)

        protected override void OnClosing(CancelEventArgs e)
        {
            Logger.Log();
            m_applicationManager.Stop();
            //Let all waiting invokes finish before closing main form
            Thread.Sleep(1000);
            base.OnClosing(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            Logger.Log();
            base.OnLoad(e);
            Login();
            Text = DataManager.Instance.GetFormHeaderString();
            //TimerRefresh init
            m_timerRefresh = new Timer();
            m_timerRefresh.Interval = 1000;
            m_timerRefresh.Tick += OnTimerRefreshTick;
            m_timerRefresh.Start();
            numericUpDownMaxSymbolData.ValueChanged += numericUpDownMaxSymbolData_ValueChanged;
            //Init gridSymbols
            gridSymbolsAll.SetColumnsVisible(false, "High", "Low", "Total%", "DoublerDate", "DailyR%");
            gridSymbolsSpecific.SetColumnsVisible(false, "QFP", "DailyR%");
            gridSymbolsActive.SetColumnsVisible(false, "High", "Low", "Close", "Daily%", "One", "Two", "Two%","MFI_A","MFI_B");
            gridSymbolsAll.Click += gridSymbolsAll_Click;
            gridSymbolsActive.Click += gridSymbolsActive_Click;
            gridSymbolsAll.KeyUp += gridSymbolsAll_Click;
            gridSymbolsActive.KeyUp += gridSymbolsActive_Click;
            //Navigate homepages
            ucWebBrowserA.HomePageUrl = DataManager.Instance.ApplicationDataItem.BrowserA;
            ucWebBrowserB.HomePageUrl = DataManager.Instance.ApplicationDataItem.BrowserB;
            ucWebBrowserC.HomePageUrl = DataManager.Instance.ApplicationDataItem.BrowserC;
            ucWebBrowserA.Navigate(ucWebBrowserA.HomePageUrl);
            ucWebBrowserB.Navigate(ucWebBrowserB.HomePageUrl);
            ucWebBrowserC.Navigate(ucWebBrowserC.HomePageUrl);
            Logger.LogDebug("Ended");
        }

		#endregion (------  Protected Methods  ------)

		#region (------  Private Methods  ------)

        void applicationManager_OnSymbolCalculatedAndUpdated(string p_descriptor, DateTime p_recentDate, bool p_isSucceeded)
        {
            Logger.LogDebug("{0} RecentDate={1} isSucceeded={2}", p_descriptor, p_recentDate,p_isSucceeded);
            if (!p_isSucceeded)
            {
                CrossThreadActivities.Do(labelLastUpdatedSymbol, l => l.Text = "Fail " + p_descriptor);
                Thread.Sleep(500);
                return;
            }
            CrossThreadActivities.Do(labelLastUpdatedSymbol, l => l.Text =  p_descriptor);
            //TODO: Read maxPositionDays length recent dates and update specific table with all instead of just the recent date
            SymbolDailyDataAnalyzed symbolDataRecent = DataManager.Instance.GetSymbolDailyDataAnalyzed(p_descriptor, p_recentDate);
            CrossThreadActivities.Do(gridSymbolsAll, g => g.AddUpdateSymbolRow(symbolDataRecent, false));
            CrossThreadActivities.Do(gridSymbolsActive, g => UpdateActiveSymbols());
            if(m_lastSelectedSymbol==p_descriptor)
            {
                //TODO: Update recent maxPositionDays  here
                CrossThreadActivities.Do(gridSymbolsSpecific, g => g.AddUpdateSymbolRow(symbolDataRecent, false));
            }
            Logger.LogDebug("{0} RecentDate={1} isSucceeded={2} Ended", p_descriptor, p_recentDate, p_isSucceeded);
        }

        private void buttonHistoryForm_Click(object sender, EventArgs e)
        {
            Logger.Log();
            FormHistory f = new FormHistory();
            f.Show();
        }

        private void buttonQMail_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Send Active Symbols Email?",
                Text,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
                ) != DialogResult.OK) return;
            Logger.Log();
            DataManager.Instance.SendActiveSymbolsEmail();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            FormSettings f=new FormSettings();
            f.ShowDialog();
        }

        void gridSymbolsActive_Click(object sender, EventArgs e)
        {
            Logger.Log();
            setSymbolSelection(sender);
            gridSymbolsAll.SetSelected(m_lastSelectedSymbol);
        }

        void gridSymbolsAll_Click(object sender, EventArgs e)
        {
            Logger.Log();
            setSymbolSelection(sender);
            gridSymbolsActive.SetSelected(m_lastSelectedSymbol);
        }

        private void Login()
        {
            Logger.Log();
            FormLogin fl = new FormLogin();
            DialogResult result = fl.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }
            try
            {
                DataManager.Instance.ApplicationDataItem.Username = fl.Username;
                m_applicationManager = new MainApplicationManager(fl.Username, fl.Password);
                m_applicationManager.OnSymbolCalculatedAndUpdated += applicationManager_OnSymbolCalculatedAndUpdated;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void numericUpDownMaxSymbolData_ValueChanged(object sender, EventArgs e)
        {
            UpdateGridSpecificSymbol();
        }

        private void OnTimerRefreshTick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString();
        }

        private void setSymbolSelection(object p_sender)
        {
            Logger.Log();
            GridSymbols gridClicked = p_sender as GridSymbols;
            if (gridClicked.SelectedRows.Count <= 0) return;
            SymbolDailyDataAnalyzed rowDailyData=gridClicked.SelectedRows[0].Tag as SymbolDailyDataAnalyzed;
            string nextSelectedSymbol = rowDailyData.Descriptor;
            //string nextSelectedSymbol = gridClicked.SelectedRows[0].Cells["Symbol"].Value.ToString();
            if (nextSelectedSymbol != m_lastSelectedSymbol)
            {
                m_lastSelectedSymbol = nextSelectedSymbol;
                UpdateGridSpecificSymbol();
                labelSelectedSymbol.Text = m_lastSelectedSymbol;
                Logger.LogDebug("Changed selected symbol to {0}",m_lastSelectedSymbol);
            }
        }

        private void UpdateActiveSymbols()
        {
            SymbolDailyDataAnalyzed[] activeSymbols = DataManager.Instance.GetActiveSymbols();
            //Remove none active rows
            List<DataGridViewRow> rowsToRemove=new List<DataGridViewRow>();
            foreach (DataGridViewRow row in gridSymbolsActive.Rows)
            {
                SymbolDailyDataAnalyzed rowData = row.Tag as SymbolDailyDataAnalyzed;
                if(!DataManager.Instance.IsSymbolDateInActiveList(rowData))rowsToRemove.Add(row);
            }
            foreach(DataGridViewRow row in rowsToRemove)
            {
                gridSymbolsActive.Rows.Remove(row);
            }
            //Add or update rows
            foreach(SymbolDailyDataAnalyzed symbolData in activeSymbols)
            {
                gridSymbolsActive.AddUpdateSymbolRow(symbolData, true);
            }
            labelDailyActivePer.Text = (DataManager.Instance.ActiveDailyChangePer*100).ToString("0.00");
            labelTotalActivePer.Text = (DataManager.Instance.ActiveSignalChangePer*100).ToString("0.00");
            labelLongsShorts.Text = DataManager.GetLongsShortsString(DataManager.Instance.LongsMinusShorts);
        }

        private void UpdateGridSpecificSymbol()
        {
            //Update grid
            gridSymbolsSpecific.Rows.Clear();
            SymbolDailyDataAnalyzed[] symbolDataArray = DataManager.Instance.GetSymbolDailyDataAnalyzed(m_lastSelectedSymbol, (int) numericUpDownMaxSymbolData.Value);
            foreach (SymbolDailyDataAnalyzed dailyData in symbolDataArray)
            {
                gridSymbolsSpecific.AddUpdateSymbolRow( dailyData,true);
            }
            //Update graph
            graphDateToFloatSymbolClose.ClearAllPoints();
            List<SymbolDailyDataAnalyzed> symbolDataArrayRevList = symbolDataArray.Reverse().ToList();
            graphDateToFloatSymbolClose.ClearAllPoints();
            foreach (SymbolDailyDataAnalyzed dailyData in symbolDataArrayRevList)
            {
                graphDateToFloatSymbolClose.AddPointDateFloat(dailyData.ReadDate, dailyData.Close);
            }
            graphDateToFloatSymbolClose.RedrawGraph();
        }

		#endregion (------  Private Methods  ------)

        private void buttonNotes_Click(object sender, EventArgs e)
        {
            FormNotes f=new FormNotes();
            f.ShowDialog();
        }
    }
}
