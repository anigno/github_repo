using System.Collections.Generic;
using System.Data;
using System.Threading;
using Timer=System.Timers.Timer;
using FinanceAnalizer2.DAL;
using LoggingProvider;
using System;
using FinanceAnalizer2.Web;
namespace FinanceAnalizer2.Data
{
    public class UpdateManager
    {
        public const double UPDATING_TIMER_INTERVAL_ms = 1000;
        public const double UPDATE_REQUESTING_INTERVAL_sec = 1800;
        private readonly ExtractorFromGoogleFinance extractor=new ExtractorFromGoogleFinance();

        private readonly Timer timer=new Timer(UPDATING_TIMER_INTERVAL_ms);

        public UpdateManager()
        {
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            DataTable table=DalFa.GetStocksNamesByDate();
            string stockToUpdate = table.Rows[0][DalFa.STOCK_NAME_FIELD].ToString();
            DateTime updatedDate = ReadDateTime(table.Rows[0][DalFa.STOCK_DATE_FIELD].ToString());
            if (DateTime.Now - updatedDate > TimeSpan.FromSeconds(UPDATE_REQUESTING_INTERVAL_sec))
            {
                UpdateStock(stockToUpdate, updatedDate);
            }
            timer.Start();
        }

        private void UpdateStock(string stockName,DateTime lastUpdate)
        {
            Logger.LogDebug("StockName={0} lastUpdated={1}",stockName,lastUpdate);
            List<DayChangeData> data= extractor.ReadDaysChageData(stockName, lastUpdate, DateTime.Now);
            DalResult result = DalFa.InsertStockData(stockName, data);
        }

        public static DateTime ReadDateTime(string dateTimeString)
        {
            if (dateTimeString == "") return new DateTime(1990,1,1);
            return DateTime.Parse(dateTimeString);
        }



    }
}
