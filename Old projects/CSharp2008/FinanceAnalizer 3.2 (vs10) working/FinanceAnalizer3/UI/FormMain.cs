using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FinanceAnalyzerData.Data;
using LoggingProvider;
using FinanceAnalizer3.Data;
using AnignoLibrary.Helpers.InvokationHelpers;

namespace FinanceAnalizer3.UI
{
    public partial class FormMain : FormBase
    {
		#region (------------------  Const Fields  ------------------)
        public const int HISTORY_TO_UPDATE_DAYS = 7;
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private int stocksUpdateLeft;
        private string selectedStockFromBothGrids;
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public FormMain()
        {
            Logger.Log();
            InitializeComponent();
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Delegates  ------------------)
        private delegate void UpdateStockDataGridDelegate(string stockName);
		#endregion (------------------  Delegates  ------------------)


		#region (------------------  Event Handlers  ------------------)
        private void buttonAddStocks_Click(object sender, EventArgs e)
        {
            using (FormAddStocks f = new FormAddStocks())
            {
                f.ShowDialog();
            }
        }

        private void buttonRemoveStock_Click(object sender, EventArgs e)
        {
            string selectedStock = selectedStockFromBothGrids;
            if (selectedStock == null) return;
            if (MessageBox.Show("Are you sure you want to remove stock name: " + selectedStock, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            DataManager.Instance.RemoveStockName(selectedStock);
            int rowIndex = ucStocksDataGridViewActiveStocks.GetRowIndex("ColumnName", selectedStock);
            if(rowIndex<0)return;
            GenericInvoker.GenericInvoke(ucStocksDataGridViewActiveStocks, c => c.RemoveRow(rowIndex));

        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            using (FormReports f = new FormReports())
            {
                f.ShowDialog();
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            using (FormSettings f=new FormSettings())
            {
                f.ShowDialog();
            }
            ucBrowserSimple_A.HomePage = DataManager.Instance.BrowserAHomePage;
            ucBrowserSimple_B.HomePage = DataManager.Instance.BrowserBHomePage;
        }

        private void buttonSimulate_Click(object sender, EventArgs e)
        {
            FormSimulate f=new FormSimulate();
            f.Show();
        }

        private void buttonTestStocks_Click(object sender, EventArgs e)
        {
            FormTestStocks f = new FormTestStocks();
            
            f.Show();
            
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Stop and save
            UpdateManager.Instance.Stop();
            DataManager.Instance.Save();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Load data
            DataManager.Instance.Load();
            SetFormHeaderText("");
            StartSecurityCheck();
            DataManager.Instance.StocksNamesUpdated += Instance_StocksNamesUpdated;
            DataManager.Instance.StockUpdated += Instance_StockUpdated;
            InitTables();
            ucBrowserSimple_A.HomePage = DataManager.Instance.BrowserAHomePage;
            ucBrowserSimple_B.HomePage = DataManager.Instance.BrowserBHomePage;
            ucBrowserSimple_A.Navigate(ucBrowserSimple_A.HomePage);
            ucBrowserSimple_B.Navigate(ucBrowserSimple_B.HomePage);
            //Start the update manager
            UpdateManager.Instance.StocksInHeaderUpdated += Instance_StocksInHeaderUpdated;
            UpdateManager.Instance.Start();
        }

        void Instance_StocksInHeaderUpdated(List<KeyValuePair<string, float>> stocksData)
        {
            string text = "";
            foreach (KeyValuePair<string, float> pair in stocksData)
            {
                text += pair.Key + " " + pair.Value.ToString("0.00%") + "   |   ";
            }
            SetFormHeaderText(text);
        }

        void Instance_StocksNamesUpdated()
        {
            InitTables();
        }

        void Instance_StockUpdated(string stockName)
        {
            //Update stocks updated counter
            int totalStocks = DataManager.Instance.GetStocksNames().Length;
            stocksUpdateLeft--;
            if (stocksUpdateLeft < 1) stocksUpdateLeft = totalStocks;
            GenericInvoker.GenericInvoke(labelStocksUpdateCounter, l => l.Text = stocksUpdateLeft+"/"+totalStocks);

            DayChangeDataAnalyzed[] dayChanges = DataManager.Instance.GetStockData(stockName);
            int rowIndex = ucStocksDataGridViewStocksNames.GetRowIndex("ColumnName", stockName);
            GenericInvoker.GenericInvoke(ucStocksDataGridViewStocksNames, c => c.UpdateRow(rowIndex, dayChanges[0]));
            string selectedStock = selectedStockFromBothGrids;
            //Will update stock data table if displaying updated stock
            if (selectedStock != null)
            {
                if (selectedStock == stockName && dayChanges.Length >= HISTORY_TO_UPDATE_DAYS)
                {
                    for (int i = 0; i < HISTORY_TO_UPDATE_DAYS ; i++)
                    {
                        GenericInvoker.GenericInvoke(ucStocksDataGridViewStockHistory, c => c.UpdateRow(i, dayChanges[i]));
                    }
                }
            }
            CheckActiveStockAddUpdate(stockName, dayChanges[0]);
            GenericInvoker.GenericInvoke(labelStockUpdated, c => c.Text = stockName);
            float dailySammeryPer;
            float fromSignalSammeryPer;
            DataManager.Instance.CalculateAllSignalToDatePer(out  dailySammeryPer,out  fromSignalSammeryPer);
            GenericInvoker.GenericInvoke(labelFomSignalSammeryPer, c => c.Text = fromSignalSammeryPer.ToString("0.00") + " %");
            GenericInvoker.GenericInvoke(labelDailySammeryPer, c => c.Text = dailySammeryPer.ToString("0.00") + " %");
        }

        private void numericUpDownHistoryLength_ValueChanged(object sender, EventArgs e)
        {
            string stockName = selectedStockFromBothGrids;
            if (stockName == null) return;
            UpdateStockDataGridInvoked(stockName);
        }

        private void timerTimeDisplay_Tick(object sender, EventArgs e)
        {
            labelTime.Text =DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void ucStocksDataGridViewActiveStocks_SelectionChanged(object sender, EventArgs e)
        {
            string stockName = ucStocksDataGridViewActiveStocks.GetSelectedStock();
            selectedStockFromBothGrids = stockName;
            if (stockName == null)
            {
                ucStocksDataGridViewStockHistory.ClearRows();
                return;
            }
            UpdateStockDataGridInvoked(stockName);
        }

        private void ucStocksDataGridViewStocksNames_SelectionChanged(object sender, EventArgs e)
        {
            string stockName=ucStocksDataGridViewStocksNames.GetSelectedStock();
            selectedStockFromBothGrids = stockName;
            if (stockName == null)
            {
                ucStocksDataGridViewStockHistory.ClearRows();
                return;
            }
            UpdateStockDataGridInvoked(stockName);
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Private Methods  ------------------)
        private void CheckActiveStockAddUpdate(string stockName,DayChangeDataAnalyzed dayChange)
        {
            if (dayChange.StockActiveSignal!=DayChangeDataAnalyzed.SignalTypeEnum.None)
            {
                //Stock is active
                if (ucStocksDataGridViewActiveStocks.GetRowIndex("ColumnName", stockName) ==-1)
                {
                    //Add
                    GenericInvoker.GenericInvoke(ucStocksDataGridViewActiveStocks, c => c.AddRow(dayChange));
                }
                else
                {
                    //update
                    int rowIndex = ucStocksDataGridViewActiveStocks.GetRowIndex("ColumnName", stockName);
                    GenericInvoker.GenericInvoke(ucStocksDataGridViewActiveStocks, c => c.UpdateRow(rowIndex, dayChange));
                }
            }
            else
            {
                //Stock not active, remove it from active stocks table if exists
                int rowIndex = ucStocksDataGridViewActiveStocks.GetRowIndex("ColumnName", stockName);
                if (rowIndex > -1)
                {
                    GenericInvoker.GenericInvoke(ucStocksDataGridViewActiveStocks, c => c.RemoveRow(rowIndex));
                }
            }
        }

        private void InitTables()
        {
            ucStocksDataGridViewStocksNames.SetColumnsVisible(false, "ColumnHigh", "ColumnLow", "ColumnTwo", "ColumnTest");
            ucStocksDataGridViewStockHistory.SetColumnsVisible(false, "ColumnTest", "ColumnQualtityForPosition");
            ucStocksDataGridViewActiveStocks.SetColumnsVisible(false, "ColumnTest");
            DayChangeDataAnalyzed[] dayChangesLast = DataManager.Instance.GetLastStocksData();
            ucStocksDataGridViewStocksNames.ClearRows();
            foreach (DayChangeDataAnalyzed dayChange in dayChangesLast)
            {
                GenericInvoker.GenericInvoke(ucStocksDataGridViewStocksNames, c => c.AddRow(dayChange));
                CheckActiveStockAddUpdate(dayChange.StockDescriptor,dayChange);
            }
        }

        private void SetFormHeaderText(string stocksInHeaderText)
        {
            GenericInvoker.GenericInvokeTryCached(this, f => f.Text = "Anignora Finance Analyzer [" + Application.ProductVersion + "]       " + stocksInHeaderText);
        }

        private void StartSecurityCheck()
        {
            Visible = false;
            using (FormLogin f = new FormLogin())
            {
                DialogResult result = f.ShowDialog();
                if (result != DialogResult.OK)
                {
                    Environment.Exit(2);
                    Close();
                }
            }
            Visible = true;

        }

        private void UpdateStockDataGridInvoked(string stockName)
        {
            if (InvokeRequired)
            {
                Invoke(new UpdateStockDataGridDelegate(UpdateStockDataGridInvoked), stockName);
            }
            else
            {
                DayChangeDataAnalyzed[] dayChanges = DataManager.Instance.GetStockData(stockName);
                if(dayChanges==null)return;
                //Replace all StockData
                ucStocksDataGridViewStockHistory.ClearRows();
                anignoGraphDisplay.ClearPointsAndGraph();
                int numberOfRows = (int) numericUpDownHistoryLength.Value;
                for (int a = 0; a < numberOfRows; a++)
                {
                    if (a >= dayChanges.Length) return;
                    ucStocksDataGridViewStockHistory.AddRow(dayChanges[a]);
                    anignoGraphDisplay.AddPoint((float) dayChanges[a].Date.ToOADate(), dayChanges[a].Close);
                }
                anignoGraphDisplay.DrawGraph();
            }
        }
		#endregion (------------------  Private Methods  ------------------)
    }
}