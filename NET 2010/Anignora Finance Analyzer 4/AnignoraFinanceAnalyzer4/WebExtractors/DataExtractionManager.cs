using System;
using AnignoraFinanceAnalyzer4.Data;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using AnignoraProcesses;
using LoggingProvider;

namespace AnignoraFinanceAnalyzer4.WebExtractors
{
    public class DataExtractionManager
    {
		#region (------  Const Fields  ------)

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)

        private readonly AThreadPool extractorThreadPool = new AThreadPool("ExtractorThreadPool",DataManager.Instance.ApplicationDataItem.MaxExtractionThreads);

		#endregion (------  Fields  ------)

		#region (------  Delegates  ------)

        public delegate void SymbolDataExtractedDelegate(string descriptor, DateTime startDate, DateTime endDate, SymbolDailyData[] symbolDailyData);

		#endregion (------  Delegates  ------)

		#region (------  Events  ------)

        public event SymbolDataExtractedDelegate OnSymbolDataExtracted;

		#endregion (------  Events  ------)

		#region (------  Public Methods  ------)

        public void CloseAll()
        {
            extractorThreadPool.AbortAll();
        }

        //public SymbolDailyDataAnalyzed[] ExtractSymbolDataSync(string descriptor,DateTime startDate,DateTime endDate)
        //{
        //    ExtractorBase extractor = SelectNewExtractor(descriptor);
        //    if (extractor == null)
        //    {
        //        Logger.LogError("Couldn't select extractor for[{0}]",descriptor);
        //        return new SymbolDailyDataAnalyzed[0];
        //    }
        //    SymbolDailyData[] symbolDailyDataArray = extractor.ExtractData(descriptor, startDate, endDate);
        //    SymbolDailyDataAnalyzed[] ret = DataManager.ConvertSymbolExtractedDataToEmptyAnalyzedData(symbolDailyDataArray);
        //    return ret;
        //}

        private ExtractorBase SelectNewExtractor(string p_descriptor)
        {
            if (p_descriptor.Length < 3)
            {
                Logger.LogError("Descriptor: [{0}] illigal", p_descriptor);
                return null;
            }

            string symbolName = SymbolDailyData.GetStockNameWithoutMultiplier(p_descriptor);
            if (symbolName.Substring(0, 1) == "^")
            {
                //Indexes are extracted from Yahoo
                return new ExtractorFromYahooOnly();
            }
            switch (DataManager.Instance.ApplicationDataItem.ExtractionOrder)
            {
                case ExtractingOrderEnum.GoogleOnly:
                    return new ExtractorFromGoogleOnly();
                case ExtractingOrderEnum.GoogleYahoo:
                    return new ExtractorFromGoogleYahoo();
                case ExtractingOrderEnum.YahooOnly:
                    return new ExtractorFromYahooOnly();
                case ExtractingOrderEnum.YahooGoogle:
                    return new ExtractorFromYahooGoogle();
            }
            //Should never get here
            throw new ArgumentException("Could not determine extractor, allowed values are: GoogleOnly, GoogleYahoo, YahooOnly, YahooGoogle");
        }

        public void ExtractWaitSymbolDataAsync(string descriptor,DateTime startDate,DateTime endDate)
        {
            startDate = startDate.Date;
            endDate = endDate.Date;
            ExtractionRequestData data = new ExtractionRequestData
                                             {
                                                 Descriptor = descriptor,
                                                 StartDate = startDate,
                                                 EndDate = endDate
                                             };
            extractorThreadPool.StartFreeWorkerThreadBlocked(extractorThreadPoolWorker,data);
        }

		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)

        private void extractorThreadPoolWorker(object p_objExtractionRequestData)
        {
            try
            {
                ExtractionRequestData reqData = (ExtractionRequestData)p_objExtractionRequestData;
                ExtractorBase extractor = SelectNewExtractor(reqData.Descriptor);
                if (extractor == null)
                {
                    Logger.LogError("Couldn't select extractor for[{0}]", reqData.Descriptor);
                    return;
                }
                SymbolDailyData[] symbolDailyDataArray = extractor.ExtractData(reqData.Descriptor, reqData.StartDate, reqData.EndDate);
                if (OnSymbolDataExtracted != null) OnSymbolDataExtracted(reqData.Descriptor, reqData.StartDate, reqData.EndDate, symbolDailyDataArray);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

		#endregion (------  Private Methods  ------)
    }
}
