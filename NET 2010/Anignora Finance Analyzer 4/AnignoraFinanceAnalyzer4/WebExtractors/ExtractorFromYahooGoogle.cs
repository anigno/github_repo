using System;
using System.Collections.Generic;
using System.Linq;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;

namespace AnignoraFinanceAnalyzer4.WebExtractors
{
    public class ExtractorFromYahooGoogle : ExtractorBase
    {
		#region (------  Fields  ------)
        private readonly ExtractorFromGoogleOnly m_extractorGoogle = new ExtractorFromGoogleOnly();
        private readonly ExtractorFromYahooOnly m_extractorYahoo = new ExtractorFromYahooOnly();
		#endregion (------  Fields  ------)

		#region (------  Public Methods  ------)
        public override List<SymbolDailyData> GetHistoryData(string p_symbolName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            List<SymbolDailyData> googleData = m_extractorGoogle.GetHistoryData(p_symbolName, p_dateFrom, p_dateTo);
            List<SymbolDailyData> yahooData = m_extractorYahoo.GetHistoryData(p_symbolName, p_dateFrom, p_dateTo);
            IEnumerable<SymbolDailyData> ret = 
                yahooData.Union(googleData, new SymbolDailyDataEqualityComparerByReadDate());
            return new List<SymbolDailyData>(ret);
        }

        public override SymbolDailyData GetRealTimeData(string p_symbolName)
        {
            SymbolDailyData rtDailyData= m_extractorYahoo.GetRealTimeData(p_symbolName);
            if (rtDailyData == null)
            {
                rtDailyData = m_extractorGoogle.GetRealTimeData(p_symbolName);
            }
            return rtDailyData;
        }
		#endregion (------  Public Methods  ------)
    }
}
