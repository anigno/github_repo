using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AnignoraProcesses;
using AnignoraDataTypes;
using log4net;


namespace AfaDataExtraction
{
    public class ExtractionManager : IExtractionManager
    {
        #region (------  Enums  ------)

        public enum ExtractingOrderEnum
        {
            GoogleOnly,
            GoogleYahoo,
            YahooOnly,
            YahooGoogle,
            CboeRtYahoo,
            ExtractorFromMsnYahooGoogle,
            ExtractorFromMsnGoogleYahoo,
            ExtractorFromYahooGoogleAndHistory
        }

        #endregion (------  Enums  ------)

        #region (------  Constants  ------)


        #endregion (------  Constants  ------)

        #region (------  Fields  ------)

        private readonly ExtractingOrderEnum m_extractingOrder;
        private readonly int m_extractionRtStartHour;
        DateTime m_lastResetDataTime = DateTime.Now;
        private readonly Dictionary<string, SortedDictionary<DateTime, SymbolExtractedData>> m_allSymbolsExtractedData = new Dictionary<string, SortedDictionary<DateTime, SymbolExtractedData>>();
        private readonly object m_syncRoot = new object();
        private readonly ThreadInterlocked[] m_threadInterlockeds;
        public DateTime MinimumExtractionDate = ExtractionCommon.DATE_MINIMUM;
        private readonly TimeSpan m_knownExtractedDataResetTimeSpan;
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion (------  Fields  ------)

        #region (------  Delegates  ------)

        public delegate void SymbolExtractedDelegate(string p_symbolWebName, SymbolExtractedData[] p_extractedData, bool p_isSucceeded);

        #endregion (------  Delegates  ------)

        #region (------  Events  ------)

        public event SymbolExtractedDelegate SymbolExtracted = delegate { };

        #endregion (------  Events  ------)

        #region (------  Constructors  ------)

        public ExtractionManager(ExtractingOrderEnum p_extractingOrder, uint p_maxExtractors, int p_extractionDelayMs, int p_extractedDataResetMinutes,int p_extractionRtStartHour)
        {
            s_logger.InfoFormat("ExtractionOrder: {0} MaxExtractors: {1}", p_extractingOrder, p_maxExtractors);
            m_extractingOrder = p_extractingOrder;
            m_extractionRtStartHour = p_extractionRtStartHour;
            m_threadInterlockeds = new ThreadInterlocked[p_maxExtractors];
            m_extractionDelaySleepMs = new ThreadSafeProperty<int>(p_extractionDelayMs);
            m_knownExtractedDataResetTimeSpan=TimeSpan.FromMinutes(p_extractedDataResetMinutes);
        }

        #endregion (------  Constructors  ------)

        #region (------  Public Methods  ------)

        public void AddSymbolsWebNames(params string[] p_symbolsWebName)
        {
            lock (m_allSymbolsExtractedData)
            {
                foreach (string symbolWebName in p_symbolsWebName)
                {
                    DateReverseComparer dateReverseComparer = new DateReverseComparer();
                    SortedDictionary<DateTime, SymbolExtractedData> symbolExtractedDatas = new SortedDictionary<DateTime, SymbolExtractedData>(dateReverseComparer);
                    m_allSymbolsExtractedData.AddDistinct(symbolWebName, symbolExtractedDatas);
                }
            }
        }

        public Dictionary<string, SymbolExtractedData> GetSymbolsRecentData()
        {
            Dictionary<string, SymbolExtractedData> ret = new Dictionary<string, SymbolExtractedData>();
            lock (m_allSymbolsExtractedData)
            {
                foreach (KeyValuePair<string, SortedDictionary<DateTime, SymbolExtractedData>> pair in m_allSymbolsExtractedData)
                {
                    if (pair.Value.Count > 0)
                    {
                        KeyValuePair<DateTime, SymbolExtractedData> first = pair.Value.First();
                        ret.Add(pair.Key, first.Value);
                    }
                }
            }
            return ret;
        }

        public void Start()
        {
            s_logger.DebugFormat("Starting");
            for (int a = 0; a < m_threadInterlockeds.Length; a++)
            {
                m_threadInterlockeds[a] = new ThreadInterlocked("Extractor_" + a, extractionAction, true, 500);
                m_threadInterlockeds[a].Start();
            }
            s_logger.DebugFormat("Started");
        }

        public void Stop()
        {
            s_logger.DebugFormat("Stoping");
            foreach (ThreadInterlocked threadInterlocked in m_threadInterlockeds)
            {
                if (threadInterlocked == null) continue;
                threadInterlocked.Stop(true, 1000);
            }
            s_logger.DebugFormat("Stoped");
        }

        #endregion (------  Public Methods  ------)

        #region (------  Private Methods  ------)
        public void ResetExtractedData()
        {
            m_lastResetDataTime = DateTime.MinValue;
        }

        private ThreadSafeProperty<int> m_nextSymbolIndex=new ThreadSafeProperty<int>(0);

        private void extractionAction()
        {
            //Reset data every known interval
            if (DateTime.Now - m_lastResetDataTime > m_knownExtractedDataResetTimeSpan)
            {
                lock (m_allSymbolsExtractedData)
                {
                    m_allSymbolsExtractedData.DoForAll(p_pair =>
                                                        {
                                                            s_logger.DebugFormat("Cleared and reset known extracted data for :{0}", p_pair.Key);
                                                            p_pair.Value.Clear();
                                                        });
                    m_lastResetDataTime = DateTime.Now;
                }
            }
            KeyValuePair<string, SortedDictionary<DateTime, SymbolExtractedData>> nextSymbolExtractedDataPair;
            DateTime fromDate = MinimumExtractionDate;
            DateTime toDate = DateTime.Now.Date;
            lock (m_syncRoot)
            {
                if (m_allSymbolsExtractedData.Count == 0) return;
                nextSymbolExtractedDataPair = m_allSymbolsExtractedData.ElementAt(m_nextSymbolIndex);
                m_nextSymbolIndex.Value++;
                if (m_nextSymbolIndex > m_allSymbolsExtractedData.Count - 1) m_nextSymbolIndex.Value = 0;

                //If exist known data, extract from last known data
                if (nextSymbolExtractedDataPair.Value.Count > 0)
                {
                    fromDate = nextSymbolExtractedDataPair.Value.Values.First().DateRead.Date;
                }
            }
            string symbolWebName = nextSymbolExtractedDataPair.Key;
            s_logger.DebugFormat("extractionAction(), Extracting: {0} from: {1} To: {2}", symbolWebName, fromDate.ToShortDateString(), toDate.ToShortDateString());
            ExtractorBase extractorToUse = selectNewExtractor();
            SymbolExtractedData[] newExtractedDataArray = extractorToUse.ExtractData(symbolWebName, fromDate, toDate);
            
            int newExtractedItemsCount = newExtractedDataArray.Length;
            //Update known extracted data with new extracted data received
            newExtractedDataArray.DoForAll(p_newSymbolExtractedData =>
                                               {
                                                   DateTime newDateRead = p_newSymbolExtractedData.DateRead;
                                                   nextSymbolExtractedDataPair.Value.AddReplace(newDateRead, p_newSymbolExtractedData);
                                               });
            //Calculate daily change per
            SymbolExtractedData[] symbolExtractedDataArray = nextSymbolExtractedDataPair.Value.Values.ToArray();
            for (int a = symbolExtractedDataArray.Length - 2; a >= 0; a--)
            {
                symbolExtractedDataArray[a].DailyChangePerSignaled = symbolExtractedDataArray[a].Close/symbolExtractedDataArray[a + 1].Close - 1;
                symbolExtractedDataArray[a].DailyChangePerRecent = symbolExtractedDataArray[0].Close/symbolExtractedDataArray[1].Close - 1;
            }
            //Raise extraction event
            bool isSucceeded = newExtractedItemsCount > 0;
            SymbolExtracted(symbolWebName, symbolExtractedDataArray, isSucceeded);
            s_logger.DebugFormat("Extracted: {0} NewDataCount:{1} TotalDataCount:{2}", symbolWebName, newExtractedDataArray.Length, nextSymbolExtractedDataPair.Value.Count);
            Thread.Sleep(m_extractionDelaySleepMs);
          

        }
        private Random m_random=new Random(DateTime.Now.Millisecond);
        private readonly ThreadSafeProperty<int> m_extractionDelaySleepMs;

        private ExtractorBase selectNewExtractor()
        {
            switch (m_extractingOrder)
            {
                case ExtractingOrderEnum.GoogleOnly:
                    return new ExtractorFromGoogleOnly(m_extractionRtStartHour);
                case ExtractingOrderEnum.GoogleYahoo:
                    return new ExtractorFromGoogleYahoo(m_extractionRtStartHour);
                case ExtractingOrderEnum.YahooOnly:
                    return new ExtractorFromYahooOnly(m_extractionRtStartHour);
                case ExtractingOrderEnum.YahooGoogle:
                    return new ExtractorFromYahooGoogle(m_extractionRtStartHour);
                case ExtractingOrderEnum.CboeRtYahoo:
                    return new ExtractorFromCboeRtYahooHistory(m_extractionRtStartHour);
                case ExtractingOrderEnum.ExtractorFromMsnYahooGoogle:
                    return new ExtractorFromMsnYahooGoogle(m_extractionRtStartHour);
                case ExtractingOrderEnum.ExtractorFromMsnGoogleYahoo:
                    return new ExtractorFromMsnGoogleYahoo(m_extractionRtStartHour);
                //case ExtractingOrderEnum.ExtractorFromYahooGoogleAndHistory:
                //    return new ExtractorFromYahooGoogleAndHistory();
            }
            //Should never get here
            throw new ArgumentException("Could not determine extractor type, check configuration value");
        }

        #endregion (------  Private Methods  ------)
    }
}