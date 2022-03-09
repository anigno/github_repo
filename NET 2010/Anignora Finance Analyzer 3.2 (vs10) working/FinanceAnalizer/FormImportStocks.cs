using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnignoLibrary.DataTypes.DataManager;
using FinanceAnalizer.Data;
using LoggingProvider;

namespace FinanceAnalizer
{
    public partial class FormImportStocks : Form
    {
        private readonly ApplicationData data = DataManagerContractBased<ApplicationData>.DataItem;

        public FormImportStocks()
        {
            InitializeComponent();
        }

        private void buttonStartImport_Click(object sender, EventArgs e)
        {
            foreach (string newStockName in listBoxStocks.Items)
            {
                if (!data.ContainsStockName(newStockName))
                {
                    StockData newStockData = new StockData();
                    newStockData.Name = newStockName;
                    data.StockDataListAdd(newStockData);
                    Logger.LogDebug("Added new stock: {0}", newStockName);
                }
                else
                {
                    Logger.LogWarning("Trying to add an existing stock: {0}", newStockName);
                }
            }
            DataManagerContractBased<ApplicationData>.UpdateSavedData();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            string[] stocks = RtfStockList.Text.Split(new string[] { "\t\n" }, StringSplitOptions.RemoveEmptyEntries);
            listBoxStocks.Items.Clear();
            foreach (string stock in stocks)
            {
                listBoxStocks.Items.Add(stock);
            }

        }
    }
}
