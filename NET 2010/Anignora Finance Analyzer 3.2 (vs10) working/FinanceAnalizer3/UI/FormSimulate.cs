using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using FinanceAnalizer3.Data;
using AnignoLibrary.Helpers.InvokationHelpers;
using Analyzers;
using System.IO;
using FinanceAnalyzerData.Data;
using LoggingProvider;

namespace FinanceAnalizer3.UI
{
    public partial class FormSimulate : FormBase
    {
		#region (------------------  Const Fields  ------------------)
        public const int NORMAL_N_DATES = 248;
        public const string SIMULATED_REPORT_FILE_NAME="SimulatedReport_{0}_.csv";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Fields  ------------------)
        readonly RowComparerByColumnName rowComparerByProfitNormal = new RowComparerByColumnName("ColumnProfitNormal", true);
        readonly RowComparerByColumnName rowComparerByHitsMisses = new RowComparerByColumnName("ColumnHitsMisses", true);
        readonly RowComparerByColumnName rowComparerByBetaResults = new RowComparerByColumnName("ColumnBeta", true);
        private Thread ThreadCalculation;
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public FormSimulate()
        {
            InitializeComponent();
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Event Handlers  ------------------)
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            buttonCalculate.Enabled=false;
            dataGridViewAsListStocksSimulated.Rows.Clear();
            if (ThreadCalculation != null && ThreadCalculation.IsAlive)
            {
                ThreadCalculation.Abort();
            }
            ThreadCalculation=new Thread(ThreadCalculationStart);
            int tradeDates = (int)numericUpDownTradeDates.Value;
            ThreadCalculation.Start(tradeDates);
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            string filename = string.Format(SIMULATED_REPORT_FILE_NAME,DateTime.Now.ToFileTime());
            try
            {
                TextWriter tw = new StreamWriter(filename, false);
                foreach (DataGridViewColumn c in dataGridViewAsListStocksSimulated.Columns)
                {
                    tw.Write(c.HeaderText + ",");
                }
                tw.WriteLine();
                foreach (DataGridViewRow row in dataGridViewAsListStocksSimulated.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        tw.Write(cell.Value + ",");
                    }
                    tw.WriteLine();
                }
                tw.Close();
                MessageBox.Show(filename + "  file was created", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSortByBeta_Click(object sender, EventArgs e)
        {
            dataGridViewAsListStocksSimulated.Sort(rowComparerByBetaResults);
        }

        private void buttonSortByHitsMisses_Click(object sender, EventArgs e)
        {
            dataGridViewAsListStocksSimulated.Sort(rowComparerByHitsMisses);
        }

        private void buttonSortByProfitNormal_Click(object sender, EventArgs e)
        {
            dataGridViewAsListStocksSimulated.Sort(rowComparerByProfitNormal);
        }

        private void buttonSortByStdDev_Click(object sender, EventArgs e)
        {
            dataGridViewAsListStocksSimulated.Sort(dataGridViewAsListStocksSimulated.Columns["ColumnStDev"], ListSortDirection.Ascending);
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Overridden Methods  ------------------)
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (ThreadCalculation != null && ThreadCalculation.IsAlive)
            {
                ThreadCalculation.Abort();
            }
        }
		#endregion (------------------  Overridden Methods  ------------------)


		#region (------------------  Private Methods  ------------------)
        private void ThreadCalculationStart(object o)
        {
            int requestedNDates=(int)o;
            string[] stocksNames = DataManager.Instance.GetStocksNames();
            for (int a = 0; a < stocksNames.Length; a++)
            {
                GenericInvoker.GenericInvoke(labelStocks, l => l.Text = (stocksNames.Length - a - 1).ToString() + "/" + stocksNames.Length);
                DayChangeDataAnalyzed[] dayChanges = DataManager.Instance.GetStockData(stocksNames[a]);
                //Verifies nDates is not more then avaliable stock data
                int nDates = requestedNDates;
                if (nDates > dayChanges.Length) nDates = dayChanges.Length;
                float[] hitMissPerValues = AnalizeBase.GetHitMissChangePerArray(dayChanges, 0, nDates);
                float tProfit=AnalizeBase.GetTotalHitMissProfitPer(dayChanges,0,nDates);
                float hitsMissesRatio = AnalizeBase.GetTotalHitsMissesRatio(dayChanges, 0, nDates)*100;
                float stdDev = AnalizeBase.StandardDeviation(hitMissPerValues);
                float profitNormal=tProfit / nDates * NORMAL_N_DATES;
                float BetaResult = profitNormal / stdDev;
                Logger.LogDebug("Adding value for {0} nDates={1}", stocksNames[a], nDates);
                GenericInvoker.GenericInvoke(dataGridViewAsListStocksSimulated, g => g.Rows.Add(stocksNames[a], stdDev.ToString("0.00"), nDates, tProfit.ToString("0.00") + "%", profitNormal.ToString("0.00") + "%", hitsMissesRatio.ToString("0.00") + "%", BetaResult.ToString("0.00")));
            }
            GenericInvoker.GenericInvoke(buttonCalculate,b=>b.Enabled=true);
        }
		#endregion (------------------  Private Methods  ------------------)
    }

    class RowComparerByColumnName : IComparer
    {
		#region (------------------  Fields  ------------------)
        private readonly bool asc;
        private readonly string columnName;
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public RowComparerByColumnName(string columnName,bool asc)
        {
            this.columnName = columnName;
            this.asc=asc;
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Public Methods  ------------------)
        public int Compare(object x, object y)
        {
            string s1 = ((DataGridViewRow) x).Cells[columnName].Value.ToString();
            string s2 = ((DataGridViewRow) y).Cells[columnName].Value.ToString();
            s1 = s1.Replace("%", "");
            s2 = s2.Replace("%", "");
            float f1 = float.Parse(s1);
            float f2 = float.Parse(s2);
            int ret;
            if (asc)
            {
                ret = f1 > f2 ? -1 : 1;
            }
            else
            {
                ret = f1 < f2 ? -1 : 1;
            }
            return ret;
        }
		#endregion (------------------  Public Methods  ------------------)
    }


 
 
}
