using System;
using System.Text.RegularExpressions;
using log4net;


namespace AfaDataExtraction
{
    public class ExtractorFromMsnRt : ExtractorBase
    {
		#region (------  Constants  ------)
        private const string URL_FORMAT_STRING_CURRENT = "http://investing.money.msn.com/investments/market-index/?symbol={0}";
		#endregion (------  Constants  ------)

        public ExtractorFromMsnRt(int p_extractionRtStartHour) : base(p_extractionRtStartHour)
        {
        }

        protected override string FixSymbolName(string p_symbolName)
        {
            if (p_symbolName.ToUpper() == "VIX")
            {
                string newName= "$" + p_symbolName;
                s_logger.DebugFormat("Changed symbolName to: {0}", newName);
                return newName;
            }
            return p_symbolName;
        } 
		#region (------  Fields  ------)
        private readonly Regex m_regexCurrentClose = new Regex("'Last'[^>]*>(?<DATA>[ 0-9.,]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentHigh = new Regex("Day's High([^>]*>){4}\\r\\n(?<DATA>[ 0-9.,]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentLow = new Regex("Day's Low([^>]*>){4}\\r\\n(?<DATA>[ 0-9.,]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentOpen = new Regex("Open\\r\\n([^>]*>){4}\\r\\n(?<DATA>[ 0-9.,]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion (------  Fields  ------)

		#region (------  Public Methods  ------)
        public override SymbolExtractedData[] GetHistoryData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            return new SymbolExtractedData[0];
        }

        public override SymbolExtractedData GetRealTimeData(string p_symbolWebName)
        {
            if(p_symbolWebName!="VIX")
            {
                s_logger.WarnFormat("MsnRt extractor can extract only VIX, but given symbol: {0}",p_symbolWebName);
                return new SymbolExtractedData(p_symbolWebName);
            }
            string newWebName=FixSymbolName(p_symbolWebName);
            try
            {
                SymbolExtractedData singleData = new SymbolExtractedData(p_symbolWebName);
                string sPage = GetStockCurrentPageString(URL_FORMAT_STRING_CURRENT, newWebName);
                Match mCurrentClose = m_regexCurrentClose.Match(sPage);
                Match mCurrentOpen = m_regexCurrentOpen.Match(sPage);
                Match mCurrentHigh = m_regexCurrentHigh.Match(sPage);
                Match mCurrentLow = m_regexCurrentLow.Match(sPage);
                //If could not find matches, no RT data
                if (!mCurrentClose.Success || !mCurrentOpen.Success)
                {
                    return null;
                }
                string sCurrentClose = mCurrentClose.Result("${DATA}");
                string sCurrentOpen = mCurrentOpen.Result("${DATA}");
                string sCurrentHigh = mCurrentHigh.Result("${DATA}");
                string sCurrentLow = mCurrentLow.Result("${DATA}");

                float currentLow = float.Parse(sCurrentLow);
                float currentHigh = float.Parse(sCurrentHigh);
                float currentClose = float.Parse(sCurrentClose);
                float currentOpen = float.Parse(sCurrentOpen);
                singleData.DateRead = DateTime.Now.Date;
                singleData.Close = currentClose;
                singleData.Open = currentOpen;
                singleData.High = currentHigh;
                singleData.Low = currentLow;
                return singleData;
            }
            catch (Exception ex)
            {
                s_logger.WarnFormat("{0} {1}", ex.Message, ex);
            }
            //No real time avaliable or exception
            s_logger.WarnFormat("{0} no RT data",p_symbolWebName);
            return null;
        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
		#endregion (------  Private Methods  ------)
    }
}