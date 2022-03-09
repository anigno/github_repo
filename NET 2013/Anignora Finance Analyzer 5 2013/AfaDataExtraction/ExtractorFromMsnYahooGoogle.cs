using System;

namespace AfaDataExtraction
{
    public class ExtractorFromMsnYahooGoogle : ExtractorBase
    {
        private readonly ExtractorFromMsnRt m_extractorFromMsnRt;
        private readonly ExtractorFromYahooGoogle m_extractorFromYahooGoogle;

        public ExtractorFromMsnYahooGoogle(int p_extractionRtStartHour) : base(p_extractionRtStartHour)
        {
            m_extractorFromMsnRt=new ExtractorFromMsnRt(ExtractionRtStartHour);
            m_extractorFromYahooGoogle=new ExtractorFromYahooGoogle(ExtractionRtStartHour);
        }

        public override SymbolExtractedData[] GetHistoryData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            return m_extractorFromYahooGoogle.GetHistoryData(p_symbolWebName, p_dateFrom, p_dateTo);
        }

        public override SymbolExtractedData GetRealTimeData(string p_symbolWebName)
        {
            if (p_symbolWebName.ToUpper() == "VIX")
            {
                return m_extractorFromMsnRt.GetRealTimeData(p_symbolWebName);
            }
            return m_extractorFromYahooGoogle.GetRealTimeData(p_symbolWebName);
        }
    }
}