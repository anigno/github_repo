using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using LoggingProvider;
using System.Linq;

namespace AnignoraFinanceAnalyzer4.WebExtractors
{
    public abstract class ExtractorBase
    {
		#region (------  Fields  ------)

        protected readonly object _syncRoot = new object();
        protected readonly WebClient client = new WebClient();
        protected readonly UTF8Encoding utf8Encoder = new UTF8Encoding();

		#endregion (------  Fields  ------)

		#region (------  Public Methods  ------)

        public static Dictionary<DateTime, SymbolDailyData> ConvertToDictionary(List<SymbolDailyData> list)
        {
            Dictionary<DateTime, SymbolDailyData> retDictionary = new Dictionary<DateTime, SymbolDailyData>();
            foreach (SymbolDailyData dailyData in list)
            {
                retDictionary.Add(dailyData.ReadDate, dailyData);
            }
            return retDictionary;
        }

        public SymbolDailyData[] ExtractData(string p_symbolName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            //clear time data
            p_dateFrom = p_dateFrom.Date;
            p_dateTo = p_dateTo.Date;
            //Verify dates
            if (p_dateFrom < SymbolDailyData.MINIMUM_DATE) p_dateFrom = SymbolDailyData.MINIMUM_DATE;
            if (p_dateFrom > p_dateTo) p_dateFrom = p_dateTo;
            //lock (_syncRoot)
            {
                SymbolDailyData[] ret=extractDataSpecific(p_symbolName, p_dateFrom, p_dateTo);
                Logger.LogDebug("Extracted for {0} length={1} dateFrom={2} dateTo={3}", p_symbolName, ret.Length, p_dateFrom.ToShortDateString(), p_dateTo.ToShortDateString());
                return ret;
            }
        }

        public abstract List<SymbolDailyData> GetHistoryData(string p_symbolName, DateTime p_dateFrom, DateTime p_dateTo);

        public abstract SymbolDailyData GetRealTimeData(string p_symbolName);

        public static int SymbolDailyDataComparison(SymbolDailyData s1,SymbolDailyData s2)
        {
            if (s1.ReadDate > s2.ReadDate) return -1;
            if (s1.ReadDate < s2.ReadDate) return 1;
            return 0;
        }

		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)

        private SymbolDailyData[] extractDataSpecific(string p_symbolName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            List<SymbolDailyData> dataRet = new List<SymbolDailyData>();
            try
            {
                //If requested dateTo is today try to get real time data
                if (p_dateTo.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    SymbolDailyData realTimeData = GetRealTimeData(p_symbolName);
                    //Check if real data exists, if is modify dateTo to day before
                    if (realTimeData != null)
                    {
                        p_dateTo = p_dateTo.Subtract(new TimeSpan(1, 0, 0, 0));
                        dataRet.Add(realTimeData);
                    }
                }
                //Get history data if needed
                if (p_dateFrom <= p_dateTo)
                {
                    List<SymbolDailyData> historyData = GetHistoryData(p_symbolName, p_dateFrom, p_dateTo);
                    dataRet.AddRange(historyData);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex,"descriptor:{0} from: {1} to: {2}",p_symbolName,p_dateFrom.Date.ToShortDateString(),p_dateTo.Date.ToShortDateString());
            }
            return dataRet.ToArray();
        }

        #endregion (------  Private Methods  ------)

		#region (------  Nested Classes  ------)


        protected class SymbolDailyDataEqualityComparerByReadDate : IEqualityComparer<SymbolDailyData>
        {
		#region (------  Public Methods  ------)

            public bool Equals(SymbolDailyData p_x, SymbolDailyData p_y)
            {
                return p_x.ReadDate == p_y.ReadDate;
            }

            public int GetHashCode(SymbolDailyData p_obj)
            {
                return p_obj.ReadDate.GetHashCode();
            }

		#endregion (------  Public Methods  ------)
        }
		#endregion (------  Nested Classes  ------)
    }
}