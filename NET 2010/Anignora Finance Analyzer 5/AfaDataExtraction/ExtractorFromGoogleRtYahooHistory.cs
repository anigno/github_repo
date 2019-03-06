using System;

namespace AfaDataExtraction
{
    /// <summary>
    /// History will be extracted from yahoo, realtime from google
    /// </summary>
    public class ExtractorFromGoogleRtYahooHistory : ExtractorBase
    {
        private readonly ExtractorFromGoogleOnly m_extractorGoogle;
        private readonly ExtractorFromYahooOnly m_extractorYahho;

        public ExtractorFromGoogleRtYahooHistory(int p_extractionRtStartHour) : base(p_extractionRtStartHour)
        {
            m_extractorGoogle=new ExtractorFromGoogleOnly(ExtractionRtStartHour);
            m_extractorYahho=new ExtractorFromYahooOnly(ExtractionRtStartHour);
        }

        public override SymbolExtractedData[] GetHistoryData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            return m_extractorYahho.GetHistoryData(p_symbolWebName, p_dateFrom, p_dateTo);
        }

        public override SymbolExtractedData GetRealTimeData(string p_symbolWebName)
        {
            return m_extractorGoogle.GetRealTimeData(p_symbolWebName);
        }
    }
}
