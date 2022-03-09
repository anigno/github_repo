using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnignoraCommonAndHelpers;
using AnignoraDataTypes;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using AnignoraFinanceAnalyzer4.Data;
using LoggingProvider;


namespace AnignoraFinanceAnalyzer4.UI.Forms
{
    public partial class FormHistory : Form
    {
        private HistoryCalculator historyCalc=new HistoryCalculator();

        public FormHistory()
        {
            Logger.Log();
            InitializeComponent();
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            Logger.Log();
            string[] descriptors = DataManager.Instance.GetSymbolsDescriptors();
            descriptors.Where(n=>n!=DataManager.INDEX_SYMBOL).OrderBy(n=>n).DoForAll(item => listViewSymbols.Items.Add(item));
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            Logger.Log();
            foreach (ListViewItem item in listViewSymbols.Items)
            {
                item.Checked = true;
            }
        }

        private void buttonSelectNone_Click(object sender, EventArgs e)
        {
            Logger.Log();
            foreach (ListViewItem item in listViewSymbols.Items)
            {
                item.Checked = false;
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            Logger.Log();
            string[] checkedSymbols=new string[listViewSymbols.CheckedItems.Count];
            for(int a=0;a<listViewSymbols.CheckedItems.Count;a++)
            {
                checkedSymbols[a] = listViewSymbols.CheckedItems[a].SubItems[0].Text;
            }
            SortedDictionary<DateTime, DailyCalculatedData> historyData = historyCalc.CalculateHistory(checkedSymbols, dateTimePickerFrom.Value.Date, dateTimePickerTo.Value.Date);
            ucResultHits.Longs.Number = historyCalc.HitsLongsNumber;
            ucResultHits.Longs.Percentage = historyCalc.HitsLongsPer;
            ucResultHits.Shorts.Number = historyCalc.HitsShortsNumber;
            ucResultHits.Shorts.Percentage = historyCalc.HitsShortsPer;
            ucResultMisses.Longs.Number = historyCalc.MissesLongsNumber;
            ucResultMisses.Longs.Percentage = historyCalc.MissesLongsPer;
            ucResultMisses.Shorts.Number = historyCalc.MissesShortsNumber;
            ucResultMisses.Shorts.Percentage = historyCalc.MissesShortsPer;
            ucResultTotal.Longs.Number = ucResultHits.Longs.Number + ucResultMisses.Longs.Number;
            ucResultTotal.Longs.Percentage = ucResultHits.Longs.Percentage + ucResultMisses.Longs.Percentage;
            ucResultTotal.Shorts.Number = ucResultHits.Shorts.Number + ucResultMisses.Shorts.Number;
            ucResultTotal.Shorts.Percentage = ucResultHits.Shorts.Percentage + ucResultMisses.Shorts.Percentage;
            ucResultTotal.Total.Number = ucResultTotal.Longs.Number + ucResultTotal.Shorts.Number;
            ucResultTotal.Total.Percentage = ucResultTotal.Longs.Percentage + ucResultTotal.Shorts.Percentage;

            ucResultHits.Total.Number = ucResultHits.Longs.Number + ucResultHits.Shorts.Number;
            ucResultHits.Total.Percentage = ucResultHits.Longs.Percentage + ucResultHits.Shorts.Percentage;
            ucResultMisses.Total.Number = ucResultMisses.Longs.Number + ucResultMisses.Shorts.Number;
            ucResultMisses.Total.Percentage = ucResultMisses.Longs.Percentage + ucResultMisses.Shorts.Percentage;

            graphDateToFloatPer.ClearAllPoints();
            float totalPer = 0;
            TextWriter tw=null;
            if (checkBoxExportCsv.Checked)
            {
                tw=new StreamWriter("Data\\"+DateTime.Now.ToFileTime()+".csv");
                tw.WriteLine("Date,totalPer,dailyChangePer");
            }
            foreach (KeyValuePair<DateTime, DailyCalculatedData> d in historyData)
            {
                totalPer += d.Value.DailyChangePer;
                graphDateToFloatPer.AddPointDateFloat(d.Key,totalPer*100);
                if(checkBoxExportCsv.Checked)
                {
                    tw.WriteLine("{0},{1},{2}",d.Key.ToShortDateString(),totalPer,d.Value.DailyChangePer);
                }
            }
            if (checkBoxExportCsv.Checked)
            {
                tw.Close();
            }
            graphDateToFloatPer.RedrawGraph();


            if (checkBoxExportCsv.Checked)
            {
                tw = new StreamWriter("Data\\" + DateTime.Now.ToFileTime() + ".new.csv");
                tw.WriteLine("Date,totalPer,dailyChangePer");
                foreach (KeyValuePair<DateTime, DailyCalculatedData> pair in historyData)
                {
                    totalPer += pair.Value.DailyChangePer;
                    tw.WriteLine("{0},{1},{2},{3}", pair.Key.ToShortDateString(), totalPer, pair.Value.DailyChangePer,pair.Value.DailyDeltaPer);
                }
                tw.Close();

            }
        }

       
    }
}
