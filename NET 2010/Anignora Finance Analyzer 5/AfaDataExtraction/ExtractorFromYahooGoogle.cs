using System;
using System.Linq;

namespace AfaDataExtraction
{
    public class ExtractorFromYahooGoogle : ExtractorBase
    {
        private readonly ExtractorFromGoogleOnly m_extractorGoogle;
        private readonly ExtractorFromYahooOnly m_extractorYahoo ;

        public ExtractorFromYahooGoogle(int p_extractionRtStartHour) : base(p_extractionRtStartHour)
        {
            m_extractorGoogle=new ExtractorFromGoogleOnly(ExtractionRtStartHour);
            m_extractorYahoo=new ExtractorFromYahooOnly(ExtractionRtStartHour);
        }

        public override SymbolExtractedData[] GetHistoryData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            SymbolExtractedData[] googleData = m_extractorGoogle.GetHistoryData(p_symbolWebName, p_dateFrom, p_dateTo);
            SymbolExtractedData[] yahooData = m_extractorYahoo.GetHistoryData(p_symbolWebName, p_dateFrom, p_dateTo);
            SymbolExtractedDataEqualityComparerByReadDate comparer = new SymbolExtractedDataEqualityComparerByReadDate();
            SymbolExtractedData[] ret = yahooData.Union(googleData, comparer).ToArray();
            return ret;
        }

        public override SymbolExtractedData GetRealTimeData(string p_symbolWebName)
        {
            SymbolExtractedData rtDailyData= m_extractorYahoo.GetRealTimeData(p_symbolWebName);
            if (rtDailyData == null)
            {
                rtDailyData = m_extractorGoogle.GetRealTimeData(p_symbolWebName);
            }
            return rtDailyData;
        }


    }
}
