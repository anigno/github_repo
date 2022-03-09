using System;
using System.Windows.Forms;
using AnignoLibrary.DataTypes.DataManager;
using FinanceAnalizer.Data;
using System.IO;
using LoggingProvider;

namespace FinanceAnalizer
{
    public partial class FormReport : Form
    {
        private readonly ApplicationData data = DataManagerContractBased<ApplicationData>.DataItem;

        public FormReport()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            TextWriter tw = null;
            try
            {
                tw = new StreamWriter("FinanceAnalizerReport_" + DateTime.Now.ToString("yyy-MM-dd") + ".csv", false);
                listViewReport.Items.Clear();
                foreach (StockData stockData in data.StockDataList)
                {
                    if (stockData.LastUpdated.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        if (stockData.AnalizeValue1 != 0 && stockData.AnalizeValue2 != 0)
                        {
                            ListViewItem item = new ListViewItem(new[] {stockData.Name, stockData.AnalizeValue1.ToString(), stockData.AnalizeValue2.ToString()});
                            listViewReport.Items.Add(item);
                            listViewReport.Sort();
                            tw.WriteLine(string.Format("{0,-10},{1,2},{2,2}", stockData.Name, stockData.AnalizeValue1, stockData.AnalizeValue2));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (tw != null) tw.Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            Text = "Report for: " + DateTime.Now.ToShortDateString();
        }
    }
}
