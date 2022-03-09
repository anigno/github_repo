using System;
using System.Collections.Generic;

namespace AnignoraFinanceAnalyzer4.WebExtractors
{
    /// <summary>
    /// History will be extracted from yahoo, realtime from google
    /// </summary>
    public class ExtractorFromGoogleRtYahooHistory : ExtractorBase
    {
        private readonly ExtractorFromGoogleOnly extractorGoogle=new ExtractorFromGoogleOnly();
        private readonly ExtractorFromYahooOnly extractorYahho=new ExtractorFromYahooOnly();

        public override List<Data.SymbolsDataItems.SymbolDailyData> GetHistoryData(string symbolName, DateTime dateFrom, DateTime dateTo)
        {
            return extractorYahho.GetHistoryData(symbolName, dateFrom, dateTo);
        }

        public override Data.SymbolsDataItems.SymbolDailyData GetRealTimeData(string symbolName)
        {
            return extractorGoogle.GetRealTimeData(symbolName);
        }
    }
}
