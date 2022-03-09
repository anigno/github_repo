using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Analyzers.First;
using FinanceAnalizer3.Data;
using LoggingProvider;

namespace FinanceAnalizer3.UI
{
    public partial class FormTestStocks : FormBase
    {
		#region (------------------  Const Fields  ------------------)
        public const string PROFITS_REPORT_FILE_NAME = "ProfitsReport_{0}_.csv";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private readonly Analyzers.AnalizeBase analyzer = new FirstStockAnalize();
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public FormTestStocks()
        {
            InitializeComponent();
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Event Handlers  ------------------)
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int hitsLongNum;
            float hitsLongPer;
            int hitsShortNum;
            float hitsShortPer;
            int missesLongNum;
            float missesLongPer;
            int missesShortNum;
            float missesShortPer;
            string[] stocksNames = GetCheckedStocksNames();
            Dictionary<DateTime, CountPerPair> changesPerDays = DataManager.Instance.CalculateHistory(stocksNames, dateTimePickerFrom.Value, dateTimePickerTo.Value, out hitsLongNum, out hitsLongPer, out hitsShortNum, out hitsShortPer, out missesLongNum, out missesLongPer, out missesShortNum, out missesShortPer,false,checkBoxAddSnP.Checked);
            UpdateDisplayAndCreateCsv(changesPerDays, hitsLongNum, hitsLongPer, hitsShortNum, hitsShortPer, missesLongNum, missesLongPer, missesShortNum, missesShortPer,checkBoxCsv.Checked);
        }

        private void buttonCheckAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewStocksNames.Items)
            {
                item.Checked = true;
            }
        }

        private void buttonCheckNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewStocksNames.Items)
            {
                item.Checked = false;
            }
        }

        private void FormTestStocks_Load(object sender, EventArgs e)
        {
            InitTables();
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Private Methods  ------------------)
        private string[] GetCheckedStocksNames()
        {
            List<string> ret=new List<string>();
            foreach (ListViewItem item in listViewStocksNames.CheckedItems)
            {
                ret.Add(item.Text);
            }
            return ret.ToArray();
        }

        private float GetDateFloat(DateTime date)
        {
            return date.Year * 13f * 32f + date.Month * 32f + date.Day;
        }

        private void InitTables()
        {
            string[] stocksNames = DataManager.Instance.GetStocksNames();
            foreach (string stockName in stocksNames)
            {
                listViewStocksNames.Items.Add(stockName);
            }
        }

        private void UpdateDisplayAndCreateCsv(Dictionary<DateTime, CountPerPair> changesPerDays, int hitsLongNum, float hitsLongPer, int hitsShortNum, float hitsShortPer, int missesLongNum, float missesLongPer, int missesShortNum, float missesShortPer,bool generateCsv)
        {
            try
            {
                labelHitsLongNum.Text = hitsLongNum.ToString();
                labelHitsLongPer.Text = hitsLongPer.ToString("0.00");
                labelHitsShortNum.Text = hitsShortNum.ToString();
                labelHitsShortPer.Text = hitsShortPer.ToString("0.00");

                labelMissesLongNum.Text = missesLongNum.ToString();
                labelMissesLongPer.Text = missesLongPer.ToString("0.00");
                labelMissesShortNum.Text = missesShortNum.ToString();
                labelMissesShortPer.Text = missesShortPer.ToString("0.00");

                labelTotalLongNum.Text = (hitsLongNum + missesLongNum).ToString();
                labelTotalLongPer.Text = (hitsLongPer - missesLongPer).ToString("0.00");

                labelTotalShortNum.Text = (hitsShortNum + missesShortNum).ToString();
                labelTotalShortPer.Text = (hitsShortPer - missesShortPer).ToString("0.00");

                labelHitsTotalNum.Text = (hitsLongNum + hitsShortNum).ToString();
                labelHitsTotalPer.Text = (hitsLongPer + hitsShortPer).ToString("0.00");

                labelMissesTotalNum.Text = (missesLongNum + missesShortNum).ToString();
                labelMissesTotalPer.Text = (missesLongPer + missesShortPer).ToString("0.00");

                labelTotalTotalNum.Text = ((hitsLongNum + hitsShortNum) + (missesLongNum + missesShortNum)).ToString();
                labelTotalTotalPer.Text = ((hitsLongPer + hitsShortPer) - (missesLongPer + missesShortPer)).ToString("0.00");

                TextWriter tw = null;
                if (generateCsv)
                {
                    string filename = string.Format(PROFITS_REPORT_FILE_NAME, DateTime.Now.ToFileTime());
                    tw = new StreamWriter(filename, false);
                    tw.Write("Date" + "," + "Total Per" + "," + "Daily Longs" + "," + "Daily Shorts" + "," + "Active Longs" + "," + "Active Shorts" + "," + "Daily Hits" + "," + "Daily Misses" + "," +"DailyActivePer"+ "," + "S&P Close" + "\n");
                }
                //Draw graph and generate CSV file
                anignoGraphDisplay.ClearPointsAndGraph();
                float acc = 0f;
                foreach (KeyValuePair<DateTime, CountPerPair> pair in changesPerDays)
                {
                    float x = GetDateFloat(pair.Key);
                    acc += pair.Value.Per;
                    float y = acc;
                    anignoGraphDisplay.AddPoint(x, y);
                    //write to csv
                    if (generateCsv)
                    {
                        tw.Write(pair.Key.ToShortDateString() + "," + acc + "," + pair.Value.DailyLongs + "," + pair.Value.DailyShorts + "," + pair.Value.ActiveLongs + "," + pair.Value.ActiveShorts + "," + pair.Value.Hits + "," + pair.Value.Misses + "," + pair.Value.dailyPer + "," + pair.Value.SnpCloseValue + "\n");
                    }
                }
                //Update display
                anignoGraphDisplay.DrawGraph();
                //Close csv
                if (generateCsv)
                {
                    tw.Close();
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