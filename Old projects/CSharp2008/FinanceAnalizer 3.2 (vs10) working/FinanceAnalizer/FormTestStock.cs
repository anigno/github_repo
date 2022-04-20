using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using AnignoLibrary.DataTypes.DataManager;
using FinanceAnalizer.Data;
using LoggingProvider;
using System.ComponentModel;

namespace FinanceAnalizer
{
    public partial class FormTestStock : Form
    {
        private readonly ApplicationData data = DataManagerContractBased<ApplicationData>.DataItem;
        private const string SQL_SELECT_STOCK = "SELECT fldDate,fldClose,fldHigh,fldLow FROM tableStocks WHERE fldStockName='{0}' ORDER BY fldDate DESC";
        readonly StockAnalizeFirst analizer = new StockAnalizeFirst();
        DataTable table = new DataTable();


        public FormTestStock()
        {
            Logger.Log();
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            Logger.Log();
            foreach (StockData stock in data.StockDataList)
            {
                listBoxStocks.Items.Add(stock.Name);
            }
            numericUpDownLargeAvg.Value = analizer.LargeAvg;
            numericUpDownSmallAvg.Value = analizer.SmallAvg;
            numericUpDownNegRes.Value = analizer.NegativeResult;
            numericUpDownPosRes.Value = analizer.PositiveResult;
            numericUpDownDaysForTrans.Value = analizer.DaysForTrans;
            dateTimePickerStart.Value = analizer.StartDate;
        }

        private void listBoxStocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.Log();
            if (listBoxStocks.SelectedIndex < 0) return;
            StartAnalizeHistory(listBoxStocks.SelectedItem.ToString());
        }

        private List<DayChangeData> ReadStockDataFromDB(string stockName)
        {
            Logger.Log();
            table.Columns.Clear();
            table.Clear();
            table = new DataTable();

            string commandString = string.Format(SQL_SELECT_STOCK, stockName);
            OleDbConnection conn = new OleDbConnection(ApplicationData.CONNECTION_STRING);
            conn.Open();
            List<DayChangeData> lRet = new List<DayChangeData>();
            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(commandString, conn);
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    DayChangeData d = new DayChangeData();
                    d.Date = (DateTime)row["fldDate"];
                    d.High = float.Parse(row["fldHigh"].ToString());
                    d.Low = float.Parse(row["fldLow"].ToString());
                    d.Close = float.Parse(row["fldClose"].ToString());
                    lRet.Add(d);
                }
                table.Columns.Add("Res1", typeof(int));
                table.Columns.Add("Res2", typeof(int));
                table.Columns.Add("Calc", typeof(string));
                dataGridViewMain.DataSource = table;
                dataGridViewMain.Sort(dataGridViewMain.Columns["fldDate"], ListSortDirection.Descending);
                dataGridViewMain.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
            conn.Close();
            return lRet;
        }

        private void StartAnalizeHistory(string stockName)
        {
            Logger.LogDebug("StockName: {0}", stockName);
            List<DayChangeData> stockDataList = ReadStockDataFromDB(stockName);
            analizer.LargeAvg = (int)numericUpDownLargeAvg.Value;
            analizer.SmallAvg = (int)numericUpDownSmallAvg.Value;
            analizer.NegativeResult = (int)numericUpDownNegRes.Value;
            analizer.PositiveResult = (int)numericUpDownPosRes.Value;
            analizer.DaysForTrans = (int)numericUpDownDaysForTrans.Value;
            analizer.StartDate = dateTimePickerStart.Value;
            anignoGraphDisplayClose.ClearPointsAndGraph();
            if (stockDataList.Count < analizer.LargeAvg)
            {
                MessageBox.Show("Could not find enough data for this stoke, try to download data again", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int prevSignal = 0;
            int longHits = 0;
            int longMiss = 0;
            int shortHits = 0;
            int shortMiss = 0;
            float longHitsPer = 0;
            float longMissPer = 0;
            float shortHitsPer = 0;
            float shortMissPer = 0;
            float totalPer = 0;
            for (int prevSkip = stockDataList.Count - analizer.LargeAvg; prevSkip >= 0; prevSkip--)
            {
                int res1;
                int res2;
                analizer.Analize(stockDataList, out res1, out res2, prevSkip);
                table.Rows[prevSkip]["Res1"] = res1;
                table.Rows[prevSkip]["Res2"] = res2;
                int currentSignal = res2;
                if (prevSignal == 0 && currentSignal != 0)
                {
                    table.Rows[prevSkip]["Calc"] += "S "+currentSignal;
                    if (prevSkip - analizer.DaysForTrans >= 0)
                    {
                        float fS = (float)table.Rows[prevSkip]["fldClose"];
                        float fE = (float)table.Rows[prevSkip - analizer.DaysForTrans]["fldClose"];
                        float fEfS = fE - fS;
                        table.Rows[prevSkip - analizer.DaysForTrans]["Calc"] = fEfS.ToString("#.00");
                        DateTime rowDate = (DateTime)table.Rows[prevSkip]["fldDate"];
                        if (rowDate >= analizer.StartDate)
                        {
                            if (currentSignal == 1)
                            {
                                if (fE >= fS)
                                {
                                    longHits++;
                                    longHitsPer += fEfS / fS*100f;
                                }
                                else
                                {
                                    longMiss++;
                                    longMissPer += fEfS / fS*100f;
                                }
                            }
                            if (currentSignal == -1)
                            {
                                if (fE <= fS)
                                {
                                    shortHits++;
                                    shortHitsPer -= fEfS / fS * 100;
                                }
                                else
                                {
                                    shortMiss++;
                                    shortMissPer -= fEfS / fS * 100;
                                }
                            }
                            totalPer = longHitsPer + longMissPer + shortHitsPer + shortMissPer;
                            anignoGraphDisplayClose.AddPoint(stockDataList.Count - analizer.LargeAvg-prevSkip, totalPer);
                        }
                    }
                }
                prevSignal = currentSignal;
            }
            anignoGraphDisplayClose.DrawGraph();
            labelLongHitCount.Text = longHits.ToString();
            labelLongMissCount.Text = longMiss.ToString();
            labelShortHitCount.Text = shortHits.ToString();
            labelShortMissCount.Text = shortMiss.ToString();
            labelTotalHitsCount.Text = (longHits + shortHits).ToString();
            labelTotalMissCount.Text = (longMiss + shortMiss).ToString();
            labelLongHitPer.Text = longHitsPer.ToString();
            labelLongMissPer.Text = longMissPer.ToString();
            labelShortHitPer.Text = shortHitsPer.ToString();
            labelShortMissPer.Text = shortMissPer.ToString();
            labelTotalHitsPer.Text = (longHitsPer + shortHitsPer).ToString();
            labelTotalMissPer.Text = (longMissPer + shortMissPer).ToString();
            labelTotalPer.Text = totalPer.ToString();
        }

        private void numericUpDownSmallAvg_ValueChanged(object sender, EventArgs e)
        {
            Logger.Log();
            listBoxStocks_SelectedIndexChanged(null, null);
        }


    }
}