using System;

namespace AfaDataExtraction
{
    public class ExtractorFromCboeRtYahooHistory:ExtractorBase
    {

        private readonly ExtractorBase m_extractorCboeForVix;
        private readonly ExtractorBase m_extractorFromYahoo;

        public ExtractorFromCboeRtYahooHistory(int p_extractionRtStartHour) : base(p_extractionRtStartHour)
        {
            m_extractorCboeForVix=new ExtractorFromCboeRt(ExtractionRtStartHour);
            m_extractorFromYahoo=new ExtractorFromCboeRt(ExtractionRtStartHour);
        }

        public override SymbolExtractedData[] GetHistoryData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            return m_extractorFromYahoo.GetHistoryData(p_symbolWebName, p_dateFrom, p_dateTo);
        }

        public override SymbolExtractedData GetRealTimeData(string p_symbolWebName)
        {
            p_symbolWebName = p_symbolWebName.Replace("^", "");
            if (p_symbolWebName.ToUpper() == "VIX") return m_extractorCboeForVix.GetRealTimeData(p_symbolWebName);
            return m_extractorFromYahoo.GetRealTimeData(p_symbolWebName);
        }
    }
}