using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Analyzers;
using Analyzers.First;
using FinanceAnalyzerData.Data;
using LoggingProvider;
using System.Text;

namespace FinanceAnalizer3.Data
{
    public class DataManager
    {
		#region (------------------  Const Fields  ------------------)
        private const string APPLICATION_DATA_FILE_NAME = "FinanceAnalyzerData.bin";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Static Fields  ------------------)
        private static DataManager instance;
		#endregion (------------------  Static Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private readonly AnalizeBase analyzer = new FirstStockAnalize();
        private ApplicationData applicationData = new ApplicationData();
        private readonly BinaryFormatter binaryFormatter = new BinaryFormatter();
        private readonly object syncRoot = new object();
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        private DataManager()
        {
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Properties  ------------------)
        public static DataManager Instance
        {
            get
            {
                if (instance == null) instance = new DataManager();
                return instance;
            }
        }

        public string LoginPassword
        {
            get
            {
                lock (syncRoot)
                {
                    return applicationData.LoginPassword;
                }
            }
            set
            {
                lock (syncRoot)
                {
                    applicationData.LoginPassword = value;
                }
            }
        }



        public int PositionsSum
        {
            get
            {
                lock (syncRoot)
                {
                    return applicationData.PositionsSum;
                }
            }
            set
            {
                lock (syncRoot)
                {
                    applicationData.PositionsSum = value;
                }
            }
        }

        public int PositionsDevider
        {
            get
            {
                lock (syncRoot)
                {
                    return applicationData.PositionsDevider;
                }
            }
            set
            {
                lock (syncRoot)
                {
                    applicationData.PositionsDevider = value;
                }
            }
        }

        public string BrowserAHomePage
        {
            get
            {
                lock (syncRoot)
                {
                    return applicationData.BrowserAHomePage;
                }
            }
            set
            {
                lock (syncRoot)
                {
                    applicationData.BrowserAHomePage = value;
                }
            }
        }

        public string BrowserBHomePage
        {
            get
            {
                lock (syncRoot)
                {
                    return applicationData.BrowserBHomePage;
                }
            }
            set
            {
                lock (syncRoot)
                {
                    applicationData.BrowserBHomePage = value;
                }
            }
        }

		#endregion (------------------  Properties  ------------------)


		#region (------------------  Events  ------------------)
        public event StocksNamesUpdatedDelegate StocksNamesUpdated;

        public event StockUpdatedDelegate StockUpdated;
		#endregion (------------------  Events  ------------------)


		#region (------------------  Delegates  ------------------)
        public delegate void StocksNamesUpdatedDelegate();
        public delegate void StockUpdatedDelegate(string stockName);
		#endregion (------------------  Delegates  ------------------)


		#region (------------------  Private Methods  ------------------)
        private DayChangeDataAnalyzed GetDayChangeData(string stockName, DateTime date)
        {
            foreach (DayChangeDataAnalyzed dayChange in applicationData.stocksData[stockName])
            {
                if (dayChange.Date.Date == date.Date) return dayChange;
            }
            return null;
        }

        private void RaiseStocksNamesUpdatedEvent()
        {
            Logger.Log();
            if (StocksNamesUpdated != null) StocksNamesUpdated();
        }

        private void RaiseStockUpdatedEvent(string stockName)
        {
            Logger.Log();
            if (StockUpdated != null) StockUpdated(stockName);
        }
		#endregion (------------------  Private Methods  ------------------)


		#region (------------------  Public Methods  ------------------)
        public Result AddStockName(string stockName)
        {
            Logger.LogDebug(stockName);
            lock (syncRoot)
            {
                if (applicationData.IsStockExists(stockName))
                {
                    Logger.LogWarning("Stock: {0} already exists", stockName);
                    return new Result(false);
                }
                applicationData.stocksData.Add(stockName, new List<DayChangeDataAnalyzed>());
            }
            RaiseStocksNamesUpdatedEvent();
            return new Result(true);
        }

        /// <summary>
        /// Add new data or update existing date's data. removes days with no trade
        /// </summary>
        public Result AddUpdateStockData(string stockName, DayChangeData[] dayChangeDataArray)
        {
            Logger.LogDebug(stockName);
            lock (syncRoot)
            {
                if (!applicationData.IsStockExists(stockName)) return new Result(false);
                //From the oldest data to the newest
                for (int a = dayChangeDataArray.Length - 1; a >= 0; a--)
                {
                    //Gets the existing date to update, if null it is a new date, add it's data
                    DayChangeDataAnalyzed dayChange = GetDayChangeData(stockName, dayChangeDataArray[a].Date);
                    if (dayChange != null)
                    {
                        //Update
                        dayChange.Open = dayChangeDataArray[a].Open;
                        dayChange.Close = dayChangeDataArray[a].Close;
                        dayChange.High = dayChangeDataArray[a].High;
                        dayChange.Low = dayChangeDataArray[a].Low;
                        dayChange.Volume = dayChangeDataArray[a].Volume;
                        dayChange.Open = dayChangeDataArray[a].Open;
                        dayChange.TimeAnalyzed = CommonParams.NEVER_UPDATED_DATETIME;
                    }
                    else
                    {
                        //Add
                        applicationData.stocksData[stockName].Insert(0, new DayChangeDataAnalyzed(dayChangeDataArray[a]));
                        if (applicationData.stocksData[stockName].Count > 2)
                        {
                            //Check if newly inserted data is the same as previous date, no trade checking
                            if (AnalizeBase.IsNoTrade(applicationData.stocksData[stockName][0], applicationData.stocksData[stockName][1]))
                            {
                                applicationData.stocksData[stockName].RemoveAt(0);
                            }
                        }
                    }
                }
            }
            return new Result(true);
        }

        public void AnalyzeAllDefault(string stockName)
        {
            //If last stock was deleted after already getting stock to update
            if (!applicationData.stocksData.ContainsKey(stockName)) return;
            DayChangeDataAnalyzed[] dayChanges = applicationData.stocksData[stockName].ToArray();
            //If stockName does not exists, array length will be zero or one (added empty data on first addition
            if (dayChanges.Length <= analyzer.MinimumDatesForAnalyze)
            {
                Logger.LogWarning("Cannot analyze stock: {0}, missing data", stockName);
                dayChanges[0].TimeAnalyzed = DateTime.Now;
                return;
            }
            analyzer.AnalyzeAll(dayChanges,applicationData.PositionsSum,applicationData.PositionsDevider);
            RaiseStockUpdatedEvent(stockName);
        }

        public void CalculateAllSignalToDatePer(out float dailySammeryPer, out float fromSignalSammeryPer)
        {
            fromSignalSammeryPer = 0;
            dailySammeryPer = 0;
            foreach (string stockName in applicationData.stocksData.Keys)
            {
                DayChangeDataAnalyzed[] dayChanges = applicationData.stocksData[stockName].ToArray();
                //Verify stock has enough data
                if (dayChanges.Length > analyzer.DaysHoldingPos + 1)
                {
                    for (int a = 1; a < analyzer.DaysHoldingPos + 1; a++)
                    {
                        if (dayChanges[a].SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Long)
                        {
                            fromSignalSammeryPer += dayChanges[a].SignalToDateChangePer;
                            dailySammeryPer += dayChanges[0].DailyChangePer;
                        }
                        if (dayChanges[a].SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Short)
                        {
                            fromSignalSammeryPer -= dayChanges[a].SignalToDateChangePer;
                            dailySammeryPer -= dayChanges[0].DailyChangePer;
                        }
                    }
                }
            }
        }

        public Dictionary<DateTime, CountPerPair> CalculateHistory(string[] stocksNames, DateTime dateFrom, DateTime dateTo, out int hitsLongNum, out  float hitsLongPer, out   int hitsShortNum, out   float hitsShortPer, out   int missesLongNum, out   float missesLongPer, out   int missesShortNum, out   float missesShortPer, bool isReAnalyzeAll, bool isUseSnP)
        {
            hitsLongNum = 0;
            hitsLongPer = 0f;
            hitsShortNum = 0;
            hitsShortPer = 0f;
            missesLongNum = 0;
            missesLongPer = 0f;
            missesShortNum = 0;
            missesShortPer = 0f;
            Dictionary<DateTime, CountPerPair> historyData = new Dictionary<DateTime, CountPerPair>();
            DayChangeData[] snpData=null;
            //Check each stock and update by date
            foreach (string stockName in stocksNames)
            {
                List<SignalCounter> longsCounters = new List<SignalCounter>();
                List<SignalCounter> shortsCounters = new List<SignalCounter>();
                DayChangeDataAnalyzed[] dayChanges = Instance.GetStockData(stockName);
                if (isReAnalyzeAll) analyzer.AnalyzeAll(dayChanges,applicationData.PositionsSum,applicationData.PositionsDevider);
                for (int a = dayChanges.Length - 1; a >= 0; a--)
                {
                    //Check if between requested dates
                    if (dayChanges[a].Date >= dateFrom && dayChanges[a].Date <= dateTo)
                    {
                        //Check if date doesn't exists to add new date
                        if (!historyData.ContainsKey(dayChanges[a].Date))
                        {
                            historyData.Add(dayChanges[a].Date, new CountPerPair());
                        }
                        //Count hits and misses
                        if (dayChanges[a].Hit == DayChangeDataAnalyzed.HitStateEnum.Hit) historyData[dayChanges[a].Date].Hits++;
                        if (dayChanges[a].Hit == DayChangeDataAnalyzed.HitStateEnum.Miss) historyData[dayChanges[a].Date].Misses++;
                        
                        //Count longs and shorts and active signals
                        if (dayChanges[a].SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Long)
                        {
                            historyData[dayChanges[a].Date].DailyLongs++;
                            longsCounters.Add(new SignalCounter(analyzer.DaysHoldingPos + 1));
                            //today signal will be counted from tommorow
                            historyData[dayChanges[a].Date].ActiveLongs += longsCounters.Count-1;
                            //Daily Per for long
                            historyData[dayChanges[a].Date].dailyPer += ((longsCounters.Count-1) * dayChanges[a].DailyChangePer);
                        }
                        else
                        {
                            historyData[dayChanges[a].Date].ActiveLongs += longsCounters.Count;
                            //Daily Per for long
                            historyData[dayChanges[a].Date].dailyPer += (longsCounters.Count * dayChanges[a].DailyChangePer);
                        }

                        if (dayChanges[a].SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Short)
                        {
                            historyData[dayChanges[a].Date].DailyShorts++;
                            shortsCounters.Add(new SignalCounter(analyzer.DaysHoldingPos + 1));
                            //today signal will be counted from tommorow
                            historyData[dayChanges[a].Date].ActiveShorts += shortsCounters.Count - 1;
                            //Daily Per for short
                            historyData[dayChanges[a].Date].dailyPer -= ((shortsCounters.Count-1) * dayChanges[a].DailyChangePer);
                        }
                        else
                        {
                            //Daily Per for short
                            historyData[dayChanges[a].Date].dailyPer -= (shortsCounters.Count * dayChanges[a].DailyChangePer);
                            historyData[dayChanges[a].Date].ActiveShorts += shortsCounters.Count;
                        }

                        //Lists used for removing old counters
                        List<SignalCounter> longsCountersRemoveList = new List<SignalCounter>();
                        List<SignalCounter> shortsCountersRemoveList = new List<SignalCounter>();
                        //Decreasing counters
                        foreach (SignalCounter counter in longsCounters)
                        {
                            counter.Counter--;
                            if (counter.Counter == 0) longsCountersRemoveList.Add(counter);
                        }
                        foreach (SignalCounter counter in shortsCounters)
                        {
                            counter.Counter--;
                            if (counter.Counter == 0) shortsCountersRemoveList.Add(counter);
                        }
                        //Removing old signals counters
                        foreach (SignalCounter cnt in shortsCountersRemoveList)
                        {
                            shortsCounters.Remove(cnt);
                        }
                        foreach (SignalCounter cnt in longsCountersRemoveList)
                        {
                            longsCounters.Remove(cnt);
                        }

                        //count total per
                        float dv = Math.Abs(dayChanges[a].HitMissChangePer);
                        if (dayChanges[a].Hit == DayChangeDataAnalyzed.HitStateEnum.Hit)
                        {
                            historyData[dayChanges[a].Date].Per += dv;
                            historyData[dayChanges[a].Date].Count++;
                            if (dayChanges[a + analyzer.DaysHoldingPos].SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Long)
                            {
                                hitsLongNum++;
                                hitsLongPer += dv;
                            }
                            if (dayChanges[a + analyzer.DaysHoldingPos].SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Short)
                            {
                                hitsShortNum++;
                                hitsShortPer += dv;
                            }
                        }
                        if (dayChanges[a].Hit == DayChangeDataAnalyzed.HitStateEnum.Miss)
                        {
                            historyData[dayChanges[a].Date].Per -= dv;
                            historyData[dayChanges[a].Date].Count++;
                            if (dayChanges[a + analyzer.DaysHoldingPos].SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Long)
                            {
                                missesLongNum++;
                                missesLongPer += dv;
                            }
                            if (dayChanges[a + analyzer.DaysHoldingPos].SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Short)
                            {
                                missesShortNum++;
                                missesShortPer += dv;
                            }
                        }
                    }
                }
            }
            //Add SnP data
            if (isUseSnP)
            {
                snpData = UpdateManager.Instance.ReadUniqueStockData(UpdateManager.SnP_SIMBOL_NAME, dateFrom, dateTo);
                for (int a = snpData.Length - 1; a >= 0; a--)
                {
                    //Check if between requested dates
                    if (snpData[a].Date >= dateFrom && snpData[a].Date <= dateTo)
                    {
                        //Check if date exists to add data
                        if (historyData.ContainsKey(snpData[a].Date))
                        {
                            historyData[snpData[a].Date].SnpCloseValue=snpData[a].Close;
                        }
                    }
                }
            }
            return historyData;
        }

        public string GenerateHitsMissesReport(DateTime dateFrom, DateTime dateTo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Report date: " + DateTime.Now);
            sb.AppendLine("");
            TimeSpan tsDay = new TimeSpan(1, 0, 0, 0);
            for (DateTime dt = dateFrom; dt <= dateTo; dt = dt.Add(tsDay))
            {
                int hits = 0;
                int misses = 0;
                float hitsPer = 0f;
                float missesPer = 0f;
                foreach (string stockName in GetStocksNames())
                {
                    DayChangeDataAnalyzed dayChange = GetDayChangeData(stockName, dt);
                    //Verifies that there is data for stock at date
                    if (dayChange != null)
                    {
                        if (dayChange.Hit == DayChangeDataAnalyzed.HitStateEnum.Hit)
                        {
                            hits++;
                            hitsPer += Math.Abs(dayChange.HitMissChangePer);
                            sb.AppendLine(string.Format("Hit for {0}. ChangePer: {1:0.00}%", stockName, dayChange.HitMissChangePer));
                        }
                        if (dayChange.Hit == DayChangeDataAnalyzed.HitStateEnum.Miss)
                        {
                            misses++;
                            missesPer += Math.Abs(dayChange.HitMissChangePer);
                            sb.AppendLine(string.Format("Miss for {0}. ChangePer: {1:0.00}%", stockName, dayChange.HitMissChangePer));
                        }
                    }
                }
                if (hits > 0 || misses > 0)
                {
                    sb.AppendLine(string.Format("Total for: {0} Hits: {1} : {2:0.00}%   Misses: {3} : {4:0.00}%   Total: {5:0.00}%", dt.ToShortDateString(), hits, hitsPer, misses, missesPer, hitsPer - missesPer));
                    sb.AppendLine("----------------------------------------");
                }
            }
            return sb.ToString();
        }

        public void GetLastHitMiss(out int hits, out float hitsPer, out int misses, out float missesPer)
        {
            hits = misses = 0;
            hitsPer = missesPer = 0f;
            foreach (string stockName in applicationData.stocksData.Keys)
            {
                //Verify that stock has any data
                if (applicationData.stocksData[stockName].Count > 0)
                {
                    DayChangeDataAnalyzed.HitStateEnum currentHitState = applicationData.stocksData[stockName][0].Hit;
                    if (currentHitState != DayChangeDataAnalyzed.HitStateEnum.None)
                    {
                        if (currentHitState == DayChangeDataAnalyzed.HitStateEnum.Hit)
                        {
                            hits++;
                            hitsPer += Math.Abs(applicationData.stocksData[stockName][0].HitMissChangePer);
                        }
                        if (currentHitState == DayChangeDataAnalyzed.HitStateEnum.Miss)
                        {
                            misses++;
                            missesPer -= Math.Abs(applicationData.stocksData[stockName][0].HitMissChangePer);
                        }
                    }
                }
            }
        }

        public DayChangeDataAnalyzed[] GetLastStocksData()
        {
            Logger.Log();
            lock (syncRoot)
            {
                List<DayChangeDataAnalyzed> lRet = new List<DayChangeDataAnalyzed>();
                foreach (string stockName in GetStocksNames())
                {
                    DayChangeDataAnalyzed dayChange;
                    if (applicationData.stocksData[stockName].Count == 0)
                    {
                        //Add new data with minimum values
                        dayChange = new DayChangeDataAnalyzed(stockName);
                        applicationData.stocksData[stockName].Add(dayChange);
                    }
                    else
                    {
                        dayChange = applicationData.stocksData[stockName][0];
                    }
                    lRet.Add(dayChange);
                }
                return (DayChangeDataAnalyzed[])lRet.ToArray().Clone();
            }
        }

        public DayChangeDataAnalyzed GetNextStockToUpdate()
        {
            DayChangeDataAnalyzed[] stocksLastDates = GetLastStocksData();
            DateTime minDate = DateTime.Now;
            DayChangeDataAnalyzed dRet = null;
            foreach (DayChangeDataAnalyzed dayChange in stocksLastDates)
            {
                if (dayChange.TimeAnalyzed <= minDate)
                {
                    minDate = dayChange.TimeAnalyzed;
                    dRet = dayChange;
                }
            }
            if (dRet == null)
            {
            }
            return dRet;
        }

        public DayChangeDataAnalyzed[] GetStockData(string stockName)
        {
            Logger.LogDebug(stockName);
            lock (syncRoot)
            {
                if (!applicationData.IsStockExists(stockName)) return null;
                return applicationData.stocksData[stockName].ToArray();
            }
        }

        public string[] GetStockesInHeader()
        {
            lock (syncRoot)
            {
                return applicationData.stocksInHeader.ToArray();
            }
        }

        public string[] GetStocksNames()
        {
            lock (syncRoot)
            {
                return applicationData.GetStocksNamesArray();
            }
        }

        public Result Load()
        {
            Logger.LogInfo("Start");
            lock (Instance)
            {
                FileStream fs = null;
                try
                {
                    if (!File.Exists(APPLICATION_DATA_FILE_NAME)) Save();
                    fs = new FileStream(APPLICATION_DATA_FILE_NAME, FileMode.Open);
                    applicationData = (ApplicationData)binaryFormatter.Deserialize(fs);
                    return new Result(true);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    return new Result(ex);
                }
                finally
                {
                    fs.Close();
                    Logger.LogInfo("End");
                }
            }
        }

        public Result RemoveStockName(string stockName)
        {
            Logger.LogDebug(stockName);
            lock (syncRoot)
            {
                if (!applicationData.IsStockExists(stockName)) return new Result(false);
                applicationData.stocksData.Remove(stockName);
            }
            RaiseStocksNamesUpdatedEvent();
            return new Result(true);
        }

        public Result Save()
        {
            Logger.LogInfo("Start");
            lock (Instance)
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(APPLICATION_DATA_FILE_NAME, FileMode.Create);
                    binaryFormatter.Serialize(fs, applicationData);
                    return new Result(true);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    return new Result(ex);
                }
                finally
                {
                    fs.Close();
                    Logger.LogInfo("End");
                }
            }
        }

        public void SetStocksInHeader(string text)
        {
            lock (syncRoot)
            {
                string[] splitter = { " ", "\n" };
                string[] parts = text.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                applicationData.stocksInHeader.Clear();
                applicationData.stocksInHeader.AddRange(parts);
            }
        }
		#endregion (------------------  Public Methods  ------------------)
    }

    internal class SignalCounter
    {
        public int Counter;

        public SignalCounter(int value)
        {
            Counter = value;
        }
    }
}