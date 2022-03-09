using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FinanceAnalizer.Data;
using System.Data.OleDb;
using System.Threading;
using FinanceAnalizer.Web;
using LoggingProvider;
using AnignoLibrary.Helpers.InvokationHelpers;
using AnignoLibrary.Helpers;

namespace FinanceAnalizer
{
    public partial class FormLoadCsv : Form
    {
		#region (------------------  Const Fields  ------------------)
        private const string CSV_FILES_DIR = "StocksCsvFiles";
        private const string SQL_SELECT_EXIST = "SELECT * FROM tableStocks WHERE fldStockName='{0}' AND fldDate={1}";
        private const string SQL_INSERT = "INSERT INTO tableStocks (fldStockName, fldDate, fldLow, fldHigh, fldClose) VALUES ('{0}',{1},{2},{3},{4})";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private readonly GoogleFinanceExtractor extractor = new GoogleFinanceExtractor();
        private OleDbConnection conn;
        private Thread UpdaterThread;
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public FormLoadCsv(List<StockData> stockList)
            : this()
        {
            foreach (StockData sd in stockList)
            {
                listViewStocks.Items.Add(sd.Name);
            }
        }

        public FormLoadCsv()
        {
            Logger.Log();
            InitializeComponent();
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Event Handlers  ------------------)
        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            Logger.Log();
            foreach (ListViewItem item in listViewStocks.Items)
            {
                item.Checked = true;
            }
        }

        private void buttonSelectNone_Click(object sender, EventArgs e)
        {
            Logger.Log();
            foreach (ListViewItem item in listViewStocks.Items)
            {
                item.Checked = false;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Logger.Log();
            conn = new OleDbConnection(ApplicationData.CONNECTION_STRING);
            string[] stocksToDownload = new string[listViewStocks.CheckedItems.Count];
            int a = 0;
            foreach (ListViewItem item in listViewStocks.CheckedItems)
            {
                stocksToDownload[a++] = item.Text;
            }
            UpdaterThread = new Thread(UpdaterThreadStart);
            UpdaterThread.Start(stocksToDownload);
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Overridden Methods  ------------------)
        protected override void OnClosing(CancelEventArgs e)
        {
            Logger.Log();
            base.OnClosing(e);
            if (UpdaterThread != null)
            {
                UpdaterThread.Abort();
            }
        }
		#endregion (------------------  Overridden Methods  ------------------)


		#region (------------------  Private Methods  ------------------)
        private void ExtractData(string csvFile,string stockName)
        {
            Logger.LogDebug("Csv file: {0}", csvFile);
            string[][] file = FilesAndFoldersHelper.ReadCsvFile(csvFile);
            for(int a=1;a<file.Length;a++)
            {
                DateTime aDate = DateTime.Parse(file[a][0]);
                string sqlCommandString = string.Format(SQL_INSERT, stockName, aDate.ToOADate(), file[a][3], file[a][2], file[a][4]);
                string sqlSelectExistString=string.Format(SQL_SELECT_EXIST, stockName, aDate.ToOADate());
                OleDbCommand selectExistCommand = new OleDbCommand(sqlSelectExistString, conn);
                try
                {
                    OleDbDataReader selectReader = selectExistCommand.ExecuteReader();
                    if (!selectReader.HasRows)
                    {
                        OleDbCommand command = new OleDbCommand(sqlCommandString, conn);
                        command.ExecuteNonQuery();
                    }
                    selectReader.Close();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "stockName: {0}", stockName);
                }
            }
        }

        private void UpdaterThreadStart(object o)
        {
            Logger.LogDebug("Started");
            GenericInvoker.GenericInvoke(buttonStart, c => c.Enabled = false);
            conn.Open();
            string[] stocksToDownload = (string[])o;
            for (int a = 0; a < stocksToDownload.Length; a++)
            {
                int index = a;
                string stockName = stocksToDownload[a];
                Logger.LogDebug("Downloading data for stock: {0}", stockName);
                string csvFileName = extractor.DownloadHistoryCsv(stockName, CSV_FILES_DIR);
                if (csvFileName != null)
                {
                    ExtractData(csvFileName, stockName);
                }
                GenericInvoker.GenericInvoke(labelData, c => c.Text = "Remain: " + (stocksToDownload.Length - index - 1));
            }
            conn.Close();
            GenericInvoker.GenericInvoke(buttonStart, c => c.Enabled = true);
            Logger.LogDebug("Ended");
        }
		#endregion (------------------  Private Methods  ------------------)
    }
}