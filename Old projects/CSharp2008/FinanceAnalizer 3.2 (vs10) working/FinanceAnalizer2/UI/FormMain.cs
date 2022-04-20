using System;
using System.Data;
using System.Windows.Forms;
using AnignoLibrary.UI.Forms;
using FinanceAnalizer2.DAL;
using FinanceAnalizer2.Data;
using LoggingProvider;

namespace FinanceAnalizer2.UI
{
    public partial class FormMain : formGradientBase
    {
        private UpdateManager updater=new UpdateManager();

        public FormMain()
        {
            InitializeComponent();
            DalFa.StockNamesTabelChanged += DalFa_StockNamesTabelChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text += " V"+Program.APPLICATION_VERSION;
            new FormTesting().ShowDialog();
            Close();
        }

        void DalFa_StockNamesTabelChanged(string change)
        {
            dataGridViewStocks.DataSource = DalFa.GetStocksNames();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Logger.Log();
            dataGridViewStocks.DataSource = DalFa.GetStocksNames();
            FixDataGridColumnsHeaders(dataGridViewStocks);
        }

        private void dataGridViewStocks_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridViewStocks.SelectedRows.Count==0)return;
            DataGridViewRow row = dataGridViewStocks.SelectedRows[0];
            string stockName = row.Cells[DalFa.STOCK_NAME_FIELD].Value.ToString();
            Logger.LogDebug(stockName);
            dataGridViewStockData.DataSource = DalFa.GetStockData(stockName);
            FixDataGridColumnsHeaders(dataGridViewStockData);
        }

        private static void FixDataGridColumnsHeaders(DataGridView gridView)
        {
            foreach (DataGridViewColumn c in gridView.Columns)
            {
                c.HeaderText = c.HeaderText.Replace("fld", "");
            }
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddStocks_Click(object sender, EventArgs e)
        {
            using (FormAddStocks f = new FormAddStocks())
            {
                f.ShowDialog();
            }
        }

        private void buttonRemoveStock_Click(object sender, EventArgs e)
        {
            if (dataGridViewStocks.SelectedRows.Count == 0) return;
            DataGridViewRow row = dataGridViewStocks.SelectedRows[0];
            string stockName = row.Cells[DalFa.STOCK_NAME_FIELD].Value.ToString();
            if (MessageBox.Show("Are you sure you want to remove "+stockName, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DalResult result = DalFa.DeleteStockName(stockName);
                if(!result.IsSucceeded)
                {
                    MessageBox.Show(stockName + " Could not be deleted. " + result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}