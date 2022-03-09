using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using AnignoraIO;
using log4net;


namespace AfaDataExtraction
{
    public abstract class ExtractorBase
    {
        protected int ExtractionRtStartHour { get; private set; }

        #region (------  Fields  ------)
        protected readonly WebClient Client = new WebClient();
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected readonly object SyncRoot = new object();
        protected readonly UTF8Encoding Utf8Encoder = new UTF8Encoding();
        #endregion (------  Fields  ------)

        private static readonly Dictionary<string, SymbolExtractedData[]> s_knownSymbolsHistory = new Dictionary<string, SymbolExtractedData[]>();
        public const string KNOWN_SYMBOLS_HISTORY = @"HistoryData\SymbolsHistory";
        private static readonly object s_syncRoot = new object();

        private void loadKnownSymbolsHistory()
        {
            lock (s_syncRoot)
            {
                s_logger.DebugFormat("loadKnownSymbolsHistory()");
                lock (s_syncRoot)
                {
                    string[] symbolsCsvFiles = Directory.GetFiles(KNOWN_SYMBOLS_HISTORY, "*.his.csv");
                    foreach (string symbolsCsvFile in symbolsCsvFiles)
                    {
                        string symbolWebName = Path.GetFileNameWithoutExtension(symbolsCsvFile).ToUpper();
                        string[][] csvLines = CsvFileReaderWriter.ReadCsvFile(symbolsCsvFile);
                        List<SymbolExtractedData> extractedDataList = new List<SymbolExtractedData>();
                        foreach (string[] line in csvLines)
                        {
                            SymbolExtractedData data = new SymbolExtractedData(symbolWebName);
                            data.DateRead = ParseDateTime(line[0]);
                            data.Open = float.Parse(line[1]);
                            data.High = float.Parse(line[2]);
                            data.Low = float.Parse(line[3]);
                            data.Close = float.Parse(line[4]);
                            data.Volume = float.Parse(line[5]);
                            extractedDataList.Add(data);
                        }
                        s_knownSymbolsHistory.Add(symbolWebName, extractedDataList.ToArray());
                        s_logger.DebugFormat("loadKnownSymbolsHistory(), Added symbol: {0} Lines: {1} [{2}-{3}]", symbolWebName, extractedDataList.Count,extractedDataList.Last().DateRead.ToShortDateString(),extractedDataList.First().DateRead.ToShortDateString());
                    }
                }
            }
        }

        public static DateTime ParseDateTime(string p_sDateTime)
        {
            string[] formats = { "d/M/yyyy", "yyyy-M-d" };

            DateTime dateValue;
            bool bResult = DateTime.TryParseExact(p_sDateTime, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
            if (bResult == false)
            {
                s_logger.ErrorFormat("Error converting: {0}", p_sDateTime);
            }
            return dateValue;
        }

        protected ExtractorBase(int p_extractionRtStartHour)
        {
            ExtractionRtStartHour = p_extractionRtStartHour;
            lock (s_syncRoot)
            {
                if (s_knownSymbolsHistory.Count > 0) return;
                loadKnownSymbolsHistory();
            }
        }

        #region (------  Public static Methods  ------)
        public static Dictionary<DateTime, SymbolExtractedData> ConvertToDictionary(List<SymbolExtractedData> p_list)
        {
            Dictionary<DateTime, SymbolExtractedData> retDictionary = new Dictionary<DateTime, SymbolExtractedData>();
            foreach (SymbolExtractedData symbolExtractedData in p_list)
            {
                retDictionary.Add(symbolExtractedData.DateRead, symbolExtractedData);
            }
            return retDictionary;
        }

        /// <summary>
        /// Returns true if there is no trade for current date from previous date, else returns false.
        /// </summary>
        public static bool IsNoTrade(SymbolExtractedData p_currentDay, SymbolExtractedData p_previousDay)
        {
            //Check that all data in current date are the same
            if (Math.Abs(p_currentDay.Close - p_currentDay.Low) < 0.001 && Math.Abs(p_currentDay.Close - p_currentDay.High) < 0.001) return true;
            //Check that 2 of 3 data from previous date are equal in current date 
            float h0 = p_currentDay.High;
            float h1 = p_previousDay.High;
            float l0 = p_currentDay.Low;
            float l1 = p_previousDay.Low;
            float c0 = p_currentDay.Close;
            float c1 = p_previousDay.Close;
            int i = (Math.Abs(h0 - h1) < 0.001 ? 1 : 0) + (Math.Abs(l0 - l1) < 0.001 ? 1 : 0) + (Math.Abs(c0 - c1) < 0.001 ? 1 : 0);
            if (i >= 2)
            {
                return true;
            }
            return false;
        }

        public static int SymbolExtractedDataComparison(SymbolExtractedData p_s1, SymbolExtractedData p_s2)
        {
            if (p_s1.DateRead > p_s2.DateRead) return -1;
            if (p_s1.DateRead < p_s2.DateRead) return 1;
            return 0;
        }
        #endregion (------  Public static Methods  ------)

        #region (------  Public Methods  ------)
        public SymbolExtractedData[] ExtractData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            //clear time data
            p_dateFrom = p_dateFrom.Date;
            p_dateTo = p_dateTo.Date;
            //Verify dates
            if (p_dateFrom < ExtractionCommon.DATE_MINIMUM) p_dateFrom = ExtractionCommon.DATE_MINIMUM;
            if (p_dateFrom > p_dateTo) p_dateFrom = p_dateTo;
            //lock (_syncRoot)
            {
                SymbolExtractedData[] ret = extractDataSpecific(p_symbolWebName, p_dateFrom, p_dateTo);
                s_logger.DebugFormat("Extracted for {0} length={1} dateFrom={2} dateTo={3}", p_symbolWebName, ret.Length, p_dateFrom.ToShortDateString(), p_dateTo.ToShortDateString());
                return ret;
            }
        }

        public abstract SymbolExtractedData[] GetHistoryData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo);

        public abstract SymbolExtractedData GetRealTimeData(string p_symbolWebName);
        #endregion (------  Public Methods  ------)

        #region (------  Protected Methods  ------)
        protected virtual string FixSymbolName(string p_symbolName)
        {
            return p_symbolName;
        }

        protected string GetStockCurrentPageString(string p_urlFormatStringCurrent, string p_symbolWebName)
        {
            try
            {
                string sUrl = string.Format(p_urlFormatStringCurrent, p_symbolWebName);
                byte[] bytes = Client.DownloadData(sUrl);
                return Utf8Encoder.GetString(bytes);
            }
            catch (Exception ex)
            {
                s_logger.WarnFormat("{0} {1}", ex.Message, ex);
                return null;
            }
        }
        #endregion (------  Protected Methods  ------)

        #region (------  Private Methods  ------)
        private SymbolExtractedData[] extractDataSpecific(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            List<SymbolExtractedData> dataRet = new List<SymbolExtractedData>();
            try
            {
                //If requested dateTo is today try to get real time data
                if (p_dateTo.Date.ToShortDateString() == DateTime.Now.Date.ToShortDateString())
                {
                    SymbolExtractedData realTimeData = new SymbolExtractedData(p_symbolWebName);
                    if (DateTime.Now.Hour >= ExtractionRtStartHour)
                    {
                        realTimeData = GetRealTimeData(p_symbolWebName);
                    }
                    //Check if real data exists, if is modify dateTo to day before
                    if (realTimeData != null)
                    {
                        p_dateTo = p_dateTo.AddDays(-1);
                        dataRet.Add(realTimeData);
                        s_logger.DebugFormat("extractDataSpecific(), {0} Realtime data {1}", p_symbolWebName, realTimeData);
                    }
                }
                //Get history data if needed
                if (p_dateFrom <= p_dateTo)
                {
                    string upperTrimmedSymbolName = p_symbolWebName.ToUpper().Trim();
                    DateTime lastKnownDate = p_dateFrom;
                    SymbolExtractedData[] knownHistoryData = new SymbolExtractedData[0];
                    if (s_knownSymbolsHistory.ContainsKey(upperTrimmedSymbolName))
                    {
                        knownHistoryData = s_knownSymbolsHistory[upperTrimmedSymbolName].Where(p_extractedData => { return p_extractedData.DateRead >= p_dateFrom && p_extractedData.DateRead <= p_dateTo; }).ToArray();
                        lastKnownDate = knownHistoryData.First().DateRead;
                        lastKnownDate = lastKnownDate.AddDays(1);
                    }
                    SymbolExtractedData[] newHistoryData = GetHistoryData(p_symbolWebName, lastKnownDate, p_dateTo);
                    dataRet.AddRange(newHistoryData);
                    dataRet.AddRange(knownHistoryData);
                }
            }
            catch (Exception ex)
            {
                s_logger.WarnFormat("extractDataSpecific(), descriptor:{0} from: {1} to: {2} Exception:{3}", p_symbolWebName, p_dateFrom.Date.ToShortDateString(), p_dateTo.Date.ToShortDateString(), ex.Message);
            }
            //Order extracted data by date
            List<SymbolExtractedData> symbolExtractedDataOrderedList = dataRet.OrderByDescending(p_symbolExtractedData => p_symbolExtractedData.DateRead).ToList();
            //Build return list without non trade dates
            if (symbolExtractedDataOrderedList.Count == 1) return symbolExtractedDataOrderedList.ToArray();
            List<SymbolExtractedData> tradeOnlyList = new List<SymbolExtractedData>();
            for (int a = 0; a < symbolExtractedDataOrderedList.Count - 1; a++)
            {
                bool isNoTrade = IsNoTrade(symbolExtractedDataOrderedList[a], symbolExtractedDataOrderedList[a + 1]);
                if (!isNoTrade)
                {
                    tradeOnlyList.Add(symbolExtractedDataOrderedList[a]);
                }
            }
            //Add last because there is nothing to compare it with
            if (tradeOnlyList.Count > 0) tradeOnlyList.Add(symbolExtractedDataOrderedList.Last());
            s_logger.DebugFormat("Extracted: {0} From: {1} To: {2} FullDataLength: {3} TradeOnlyLength: {4}", p_symbolWebName, p_dateFrom, p_dateTo, symbolExtractedDataOrderedList.Count, tradeOnlyList.Count);
            return tradeOnlyList.ToArray();
        }
        #endregion (------  Private Methods  ------)
    }
}