using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AnignoLibrary.DataTypes.DataManager;
using FinanceAnalizer.Data;
using FinanceAnalizer.Web;
using System.Threading;
using LoggingProvider;
using System.Drawing;

namespace FinanceAnalizer
{
    public partial class FormMain : Form
    {
		#region (------------------  Const Fields  ------------------)
        private const int MAX_UPDATE_THREADS = 4;
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private readonly ApplicationData data = DataManagerContractBased<ApplicationData>.DataItem;
        private bool updateBreak;
        private readonly Color COLOR_GOOD = Color.FromArgb(192, 255, 192);
        private readonly Color COLOR_BAD = Color.FromArgb(255, 192, 192);
        private readonly StockAnalizeFirst stockAnalizerFirst = new StockAnalizeFirst();
        private readonly Thread[] stockUpdateThreads = new Thread[MAX_UPDATE_THREADS];
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public FormMain()
        {
            Logger.Log();
            Thread.CurrentThread.Name = "UI Thread";
            InitializeComponent();
            RefreshFormData();
            for (int a = 0; a < stockUpdateThreads.Length; a++)
            {
                stockUpdateThreads[a] = new Thread(StockUpdateThreadStart);
                stockUpdateThreads[a].Name = "StockUpdate Thread" + a;
                stockUpdateThreads[a].Start();
            }
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Delegates  ------------------)
        private delegate void UpdateStockNameDataDelegate(StockData stockData);
		#endregion (------------------  Delegates  ------------------)


		#region (------------------  Event Handlers  ------------------)
        private void buttonAddStock_Click(object sender, EventArgs e)
        {
            Logger.Log();
            string newStockName = textBoxAddStock.Text;
            if (textBoxAddStock.Text == "")
            {
                MessageBox.Show("Empty stock name", "");
                return;
            }
            if (data.ContainsStockName(newStockName))
            {
                MessageBox.Show("Stock: " + newStockName + " already exist.", "");
                return;
            }
            StockData newStockData = new StockData();
            newStockData.Name = newStockName;
            data.StockDataListAdd(newStockData);
            Logger.LogDebug("Added new stock: {0}", newStockName);
            textBoxAddStock.Text = "";
            RefreshFormData();
            DataManagerContractBased<ApplicationData>.UpdateSavedData();
        }

        private void buttonDownloadCsvData_Click(object sender, EventArgs e)
        {
            FormLoadCsv f = new FormLoadCsv(data.StockDataList);
            f.ShowDialog(this);
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            FormReport f=new FormReport();
            f.ShowDialog(this);
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            FormImportStocks f = new FormImportStocks();
            f.TopMost = true;
            f.ShowDialog(this);
            RefreshFormData();
        }

        private void buttonRemoveStock_Click(object sender, EventArgs e)
        {
            Logger.Log();
            if (listViewStoksNames.SelectedItems.Count == 0) return;
            string selectedStock = listViewStoksNames.SelectedItems[0].Text;
            if (MessageBox.Show("Are you sure you want to remove stock: " + selectedStock + " ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StockData removedStockData = data.GetStockData(selectedStock);
                if (removedStockData == null) return;
                data.StockDataListRemove(removedStockData);
                Logger.LogDebug("Removed stock: {0}", selectedStock);
                RefreshFormData();
                DataManagerContractBased<ApplicationData>.UpdateSavedData();
            }
        }

        private void buttonTester_Click(object sender, EventArgs e)
        {
            FormTestStock f = new FormTestStock();
            f.ShowDialog(this);
            
            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Text = Text + " V" + Program.VERSION;
            labelStockName.Text = labelDate.Text = "";
        }

        private void listViewStoksNames_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateStockDaysListView();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString();

        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Overridden Methods  ------------------)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Logger.Log();
            updateBreak = true;
            Thread.Sleep(1000*MAX_UPDATE_THREADS);
            base.OnFormClosing(e);
        }
		#endregion (------------------  Overridden Methods  ------------------)


		#region (------------------  Private Methods  ------------------)
        private void AnalizeStock(StockData stockData, int prevSkip, out int res1, out int res2)
        {
            Logger.LogDebug("Analizing {0} prevSkip={1}", stockData.Name, prevSkip);
            if (stockData.DayChanges.Count < data.MaxStockUpdateList)
            {
                Logger.LogError("StockData missing data, length={0} instead of {1}", stockData.DayChanges.Count, data.MaxStockUpdateList);
                res1 = res2 = 0;
                return;
            }
            stockAnalizerFirst.Analize(stockData.DayChanges, out res1, out res2, prevSkip);
            stockData.AnalizeValue1 = res1;
            stockData.AnalizeValue2 = res2;
        }

        private ListViewItem GetStockItem(string stockName)
        {
            foreach (ListViewItem item in listViewStoksNames.Items)
            {
                StockData stockData = (StockData)item.Tag;
                if (stockData.Name == stockName) return item;
            }
            return null;
        }

        private void RefreshFormData()
        {
            Logger.Log();
            listViewStoksNames.Items.Clear();
            foreach (StockData stockData in data.StockDataList)
            {
                ListViewItem item = new ListViewItem(new[] { stockData.Name, stockData.AnalizeValue1.ToString(), stockData.AnalizeValue2.ToString(), stockData.LastUpdated.ToString() });
                item.Tag = stockData;
                item.BackColor = stockData.DayChanges.Count < data.MaxStockUpdateList ? COLOR_BAD : COLOR_GOOD;
                listViewStoksNames.Items.Add(item);
                listViewStoksNames.Sort();
            }
        }

        private void StockUpdateThreadStart()
        {
            Logger.Log();
            while (!updateBreak)
            {
                StockData stockToUpdate = data.GetNextStockToUpdate();
                if (stockToUpdate != null)
                {
                    if (DateTime.Now - stockToUpdate.LastUpdated > TimeSpan.FromMinutes(data.UpdatesIntervalInMinutes) && DateTime.Now<Program.VerifiedDate)
                    {
                        Logger.LogDebug("Updating stock: {0}", stockToUpdate.Name);
                        DateTime fromDate = new DateTime(DateTime.Now.Year - 2, DateTime.Now.Month, DateTime.Now.Day);
                        DateTime toDate = DateTime.Now;
                        stockToUpdate.LastUpdated = toDate;
                        ExtractorBase extractor = new GoogleFinanceExtractor();
                        List<DayChangeData> results = extractor.ExtractStockData(stockToUpdate.Name, fromDate, toDate);
                        stockToUpdate.DayChanges = results;
                        int res1;
                        int res2;
                        AnalizeStock(stockToUpdate, 0, out res1, out res2);
                        UpdateStockNameData(stockToUpdate);
                        Logger.LogDebug("Stock: {0} was updated", stockToUpdate.Name);
                    }
                }
                Thread.Sleep(10);
            }
        }

        private void UpdateStockDaysListView()
        {
            anignoGraphDisplayClose.ClearPointsAndGraph();
            listViewStockData.Items.Clear();
            labelDate.Text = "";
            labelStockName.Text = "";
            if (listViewStoksNames.SelectedItems.Count == 0) return;
            StockData currentStockData = (StockData)listViewStoksNames.SelectedItems[0].Tag;
            Logger.LogDebug("Selected stock: {0}", currentStockData.Name);
            labelStockName.Text = currentStockData.Name;
            labelDate.Text = currentStockData.LastUpdated.ToString();
            for (int a = 0; a < currentStockData.DayChanges.Count; a++)
            {
                DayChangeData change = currentStockData.DayChanges[a];
                string s1 = "";
                string s2 = "";
                if (a < 20)
                {
                    try
                    {
                        int res1;
                        int res2;
                        AnalizeStock(currentStockData, a, out res1, out res2);
                        s1 = res1.ToString();
                        s2 = res2.ToString();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                    }
                }
                ListViewItem item = new ListViewItem(new[] { change.Date.ToShortDateString(), change.Open.ToString("0.00"), change.High.ToString("0.00"), change.Low.ToString("0.00"), change.Close.ToString("0.00"), change.Volume.ToString("n0"), s1, s2 });
                anignoGraphDisplayClose.AddPoint(10000 - a, change.Close);
                listViewStockData.Items.Add(item);
            }
            anignoGraphDisplayClose.DrawGraph();
        }

        private void UpdateStockNameData(StockData stockData)
        {
            try
            {
                if (InvokeRequired)
                {
                    Logger.Log();
                    Invoke(new UpdateStockNameDataDelegate(UpdateStockNameData), stockData);
                }
                else
                {
                    Logger.LogDebug("Updating stock name data: {0}", stockData.Name);
                    labelUpdating.Text = "Updated: " + stockData.Name;
                    ListViewItem item = GetStockItem(stockData.Name);
                    if (item == null)
                    {
                        Logger.LogError("GetStockItem() for stock: {0} returned null", stockData.Name);
                        return;
                    }
                    item.SubItems[3].Text = stockData.LastUpdated.ToString();
                    item.SubItems[1].Text = stockData.AnalizeValue1.ToString();
                    item.SubItems[2].Text = stockData.AnalizeValue2.ToString();
                    item.BackColor = stockData.DayChanges.Count < data.MaxStockUpdateList ? COLOR_BAD : COLOR_GOOD;
                    UpdateStockDaysListView();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
		#endregion (------------------  Private Methods  ------------------)
    }
}