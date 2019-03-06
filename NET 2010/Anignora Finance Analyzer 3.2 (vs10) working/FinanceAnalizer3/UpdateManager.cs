using System;
using System.Collections.Generic;
using System.Timers;
using FinanceAnalizer3.Data;
using FinanceAnalyzerData.Data;
using LoggingProvider;
using FinanceAnalizer3.Web;

namespace FinanceAnalizer3
{
    public class UpdateManager
    {
		#region (------------------  Const Fields  ------------------)
        public const string SnP_SIMBOL_NAME = "^gspc";
        public const double TIMER_UPDATE_INTERVAL = 1000;
        public const double TIMER_UPDATE_INTERVAL_STOCKS_IN_HEADER = 5000;
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Static Fields  ------------------)
        private static UpdateManager instance;
		#endregion (------------------  Static Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private readonly ExtractorBase extractorGoogle = new ExtractorFromGoogleFinance();
        private readonly ExtractorBase extractorYahoo = new ExtractorFromYahooFinance();
        private readonly Timer timerUpdate = new Timer(TIMER_UPDATE_INTERVAL);
        private readonly Timer timerUpdateStocksInHeader = new Timer(TIMER_UPDATE_INTERVAL_STOCKS_IN_HEADER);
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        private UpdateManager()
        {
            timerUpdate.Elapsed += timerUpdate_Elapsed;
            timerUpdateStocksInHeader.Elapsed += timerUpdateStocksInHeader_Elapsed;
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Properties  ------------------)
        public static UpdateManager Instance
        {
            get
            {
                if(instance==null)instance=new UpdateManager();
                return instance;
            }
        }
		#endregion (------------------  Properties  ------------------)


		#region (------------------  Events  ------------------)
        public event StocksInHeaderUpdatedDelegate StocksInHeaderUpdated;
		#endregion (------------------  Events  ------------------)


		#region (------------------  Delegates  ------------------)
        public delegate void StocksInHeaderUpdatedDelegate(List<KeyValuePair<string, float>> stocksData);
		#endregion (------------------  Delegates  ------------------)


		#region (------------------  Event Handlers  ------------------)
        void timerUpdate_Elapsed(object sender, ElapsedEventArgs e)
        {
            timerUpdate.Stop();
            if (DataManager.Instance.GetStocksNames().Length > 0)
            {
                //Gets the next stock to update, dateFrom is set to the last known date
                DayChangeDataAnalyzed stockToUpdateDayChange = DataManager.Instance.GetNextStockToUpdate();
                DateTime dateFrom = stockToUpdateDayChange.Date;
                //if different date from today, ask for all data
                if (DateTime.Now.Date != dateFrom && dateFrom!=CommonParams.MINIMUM_DATE)
                {
                    dateFrom = dateFrom.Subtract(new TimeSpan(7, 0, 0, 0));
                    Logger.LogDebug("Requesting all data from: {0} because date has changed",dateFrom);
                }
                DayChangeData[] receivedDayChangeData = ReadDaysChangeData(stockToUpdateDayChange.StockDescriptor, dateFrom, DateTime.Now.Date);
                DataManager.Instance.AddUpdateStockData(stockToUpdateDayChange.StockDescriptor, receivedDayChangeData);
                DataManager.Instance.AnalyzeAllDefault(stockToUpdateDayChange.StockDescriptor);
            }
            timerUpdate.Start();
        }

        void timerUpdateStocksInHeader_Elapsed(object sender, ElapsedEventArgs e)
        {
            timerUpdateStocksInHeader.Stop();
            string[] stocksInHeader = DataManager.Instance.GetStockesInHeader();
            List<KeyValuePair<string,float>> stocksInHeaderData=new List<KeyValuePair<string, float>>();
            foreach (string stockName in stocksInHeader)
            {
                DateTime yesterday = DateTime.Now.AddDays(-7);
                DayChangeData[] dayChanges= ReadDaysChangeData(stockName, yesterday, DateTime.Now);
                if (dayChanges.Length > 1)
                {
                    stocksInHeaderData.Add(new KeyValuePair<string, float>(stockName, dayChanges[0].Close/dayChanges[1].Close-1));
                }
                else
                {
                    stocksInHeaderData.Add(new KeyValuePair<string, float>(stockName, 0f));
                }
            }
            RaiseStocksInHeaderUpdatedEvent(stocksInHeaderData);
            timerUpdateStocksInHeader.Start();
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Private Methods  ------------------)
        private ExtractorBase ChooseExtractor(string stockName)
        {
            if (stockName.Substring(0, 1) == "^")
            {
                //Used for composites, flaged by '^' prefix for stock name
                Logger.LogDebug("Using {0} extractor for {1}","Yahoo",stockName);
                return extractorYahoo;
            }
            //Default extractor for all stocks
            Logger.LogDebug("Using {0} extractor for {1}", "Google", stockName);
            return extractorGoogle;
        }

        private void RaiseStocksInHeaderUpdatedEvent(List<KeyValuePair<string,float>> stocksData)
        {
            Logger.Log();
            if (StocksInHeaderUpdated != null) StocksInHeaderUpdated(stocksData);
        }

        private DayChangeData[] ReadDaysChangeData(string stockName, DateTime dateFrom, DateTime dateTo)
        {
            ExtractorBase extractorToUse = ChooseExtractor(stockName);
            DayChangeData[] dayChanges = extractorToUse.ReadDaysChangeData(stockName, dateFrom, dateTo);
            return dayChanges;
        }
		#endregion (------------------  Private Methods  ------------------)


		#region (------------------  Public Methods  ------------------)
        public DayChangeData[] ReadUniqueStockData(string stockName,DateTime dateFrom, DateTime dateTo)
        {
            DayChangeData[] dayChanges = ReadDaysChangeData(stockName, dateFrom, dateTo);
            return dayChanges;
        }

        public void Start()
        {
            Logger.Log();
            lock (Instance)
            {
                timerUpdate.Start();
                timerUpdateStocksInHeader.Start();
            }
        }

        public void Stop()
        {
            Logger.Log();
            lock (Instance)
            {
                timerUpdate.Stop();
                timerUpdateStocksInHeader.Stop();
            }
        }
		#endregion (------------------  Public Methods  ------------------)
    }
}