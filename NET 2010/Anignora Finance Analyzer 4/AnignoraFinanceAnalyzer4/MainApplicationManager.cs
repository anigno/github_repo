using System;
using System.Threading;
using AnignoraFinanceAnalyzer4.Analyzers;
using AnignoraFinanceAnalyzer4.Analyzers.First;
using AnignoraFinanceAnalyzer4.Data;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using AnignoraFinanceAnalyzer4.WebExtractors;
using LoggingProvider;

namespace AnignoraFinanceAnalyzer4
{
    public class MainApplicationManager
    {
		#region (------  Fields  ------)

        private readonly AnalyzeBase m_analyzer ;
        private readonly CalculationsBase m_calculator;
        private readonly DataExtractionManager m_extractor = new DataExtractionManager();
        private readonly FtpManager m_ftpManager = new FtpManager();
        private int m_ftpThreadCounter;
        private readonly Thread m_ftpUploaderThread;
        private long m_isRunning;
        private readonly Thread m_mainApplicationThread;

		#endregion (------  Fields  ------)

		#region (------  Delegates  ------)

        public delegate void OnSymbolAnalyzedAndUpdatedDelegate(string p_descriptor,DateTime p_recentDate,bool p_isSucceeded);

		#endregion (------  Delegates  ------)

		#region (------  Events  ------)

        public event OnSymbolAnalyzedAndUpdatedDelegate OnSymbolCalculatedAndUpdated;

		#endregion (------  Events  ------)

		#region (------  Constructors  ------)

        public MainApplicationManager(string p_username,int p_key)
        {
            Logger.Log();
            float negRes=DataManager.Instance.ApplicationDataItem.NegativeParam;
            float posRes=DataManager.Instance.ApplicationDataItem.PositiveParam;
            int formoulaOnrParam = DataManager.Instance.ApplicationDataItem.FormulaOneParam;
            int smallAverage = DataManager.Instance.ApplicationDataItem.SmallAverage;
            int largeAverage = DataManager.Instance.ApplicationDataItem.LargeAverage;
            int otherAvg = DataManager.Instance.ApplicationDataItem.OtherAvg;
            m_analyzer = new FirstStockAnalyze(p_username, p_key, negRes, posRes,formoulaOnrParam,smallAverage,largeAverage,otherAvg);
            m_calculator= new FirstCalculations(m_analyzer.MinimumDataLengthForAnalyze);
            m_mainApplicationThread=new Thread(mainApplicationThreadStart);
            m_mainApplicationThread.Name = "MainApplicationThread";
            m_mainApplicationThread.Start();
            m_ftpUploaderThread = new Thread(ftpUploaderThreadStart);
            m_ftpUploaderThread.Name = "ftpUploaderThread";
            m_ftpUploaderThread.Start();
        }

		#endregion (------  Constructors  ------)

		#region (------  Public Methods  ------)

        public void Stop()
        {
            Logger.Log();
            Interlocked.Exchange(ref m_isRunning, 1);
            m_extractor.CloseAll();
            DataManager.Instance.CloseServices();
        }

		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)

        void extractor_OnSymbolDataExtracted(string p_descriptor, DateTime p_startDate, DateTime p_endDate, SymbolDailyData[] p_symbolDailyData)
        {
            //Check if no data received
            if(p_symbolDailyData.Length==0)
            {
                Logger.LogWarning("extractor for {0} failed", p_descriptor);
                if (OnSymbolCalculatedAndUpdated != null) OnSymbolCalculatedAndUpdated(p_descriptor, SymbolDailyData.MINIMUM_DATE, false);
                return;
            }
            //Add received data
            SymbolDailyDataAnalyzed[] analyzedDataArrayConverted = DataManager.ConvertSymbolExtractedDataToEmptyAnalyzedData(p_symbolDailyData);
            DataManager.Instance.AddUpdateSymbolData(p_descriptor,analyzedDataArrayConverted);
            //Analyze all symbol data
            SymbolDailyDataAnalyzed[] allAnalyzedDataArray=DataManager.Instance.GetSymbolDailyDataAnalyzed(p_descriptor);
            m_analyzer.AnalyzeAll(allAnalyzedDataArray);
            m_calculator.CalculateAll(p_descriptor,allAnalyzedDataArray);
            //Check if symbol is for trading or for viewing

            //Raise analyzed and updated event
            DateTime recentDate = DataManager.Instance.GetSymbolRecentDate(p_descriptor);
            if(OnSymbolCalculatedAndUpdated!=null)OnSymbolCalculatedAndUpdated(p_descriptor, recentDate,true);

        }

        private void ftpUploaderThreadStart()
        {
            Logger.LogDebug("Started");
            while (Interlocked.Read(ref m_isRunning) == 0)
            {
                m_ftpThreadCounter++;
                int ftpUpdateIntervalSec = DataManager.Instance.ApplicationDataItem.FtpUpdateIntervalSec;
                if (m_ftpThreadCounter > ftpUpdateIntervalSec)
                {
                    m_ftpThreadCounter = 0;
                    m_ftpManager.FtpUpdate();
                }
                Thread.Sleep(1000);
            }
            Logger.LogDebug("Ended");
        }

        private void mainApplicationThreadStart()
        {
            Logger.LogDebug("Started");
            m_extractor.OnSymbolDataExtracted += extractor_OnSymbolDataExtracted;
            DataManager.Instance.Init();
            while(Interlocked.Read(ref m_isRunning)==0)
            {
                //Extract
                string descriptor = DataManager.Instance.GetMostOffdatedSymbol();
                DateTime startDate = DataManager.Instance.GetSymbolRecentDate(descriptor);
                m_extractor.ExtractWaitSymbolDataAsync(descriptor,startDate,DateTime.Now);
                Thread.Sleep(EXTRACTION_DELAY);
            }
            m_extractor.OnSymbolDataExtracted -= extractor_OnSymbolDataExtracted;
            m_extractor.CloseAll();
            Logger.LogDebug("Ended");
        }

		#endregion (------  Private Methods  ------)
        private const int EXTRACTION_DELAY = 1000;
    }
}
