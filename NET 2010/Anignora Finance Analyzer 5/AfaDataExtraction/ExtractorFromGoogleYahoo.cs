using System;
using System.Linq;

namespace AfaDataExtraction
{
    public class ExtractorFromGoogleYahoo : ExtractorBase
    {
        private readonly ExtractorFromGoogleOnly m_extractorGoogle;
        private readonly ExtractorFromYahooOnly m_extractorYahoo;

        public ExtractorFromGoogleYahoo(int p_extractionRtStartHour) : base(p_extractionRtStartHour)
        {
            m_extractorGoogle=new ExtractorFromGoogleOnly(ExtractionRtStartHour);
            m_extractorYahoo=new ExtractorFromYahooOnly(ExtractionRtStartHour);
        }

        public override SymbolExtractedData[] GetHistoryData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            SymbolExtractedData[] googleData = m_extractorGoogle.GetHistoryData(p_symbolWebName, p_dateFrom, p_dateTo);
            SymbolExtractedData[] yahooData = m_extractorYahoo.GetHistoryData(p_symbolWebName, p_dateFrom, p_dateTo);
            SymbolExtractedDataEqualityComparerByReadDate comparer = new SymbolExtractedDataEqualityComparerByReadDate();
            SymbolExtractedData[] ret = googleData.Union(yahooData, comparer).ToArray();
            return ret;
        }

        public override SymbolExtractedData GetRealTimeData(string p_symbolWebName)
        {
            SymbolExtractedData realTimeData = m_extractorGoogle.GetRealTimeData(p_symbolWebName);
            if (realTimeData == null)
            {
                realTimeData = m_extractorYahoo.GetRealTimeData(p_symbolWebName);
            }
            return realTimeData;
        }


    }
}
