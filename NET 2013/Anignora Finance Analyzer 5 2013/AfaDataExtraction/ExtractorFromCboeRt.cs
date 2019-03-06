using System;
using System.Text.RegularExpressions;
using log4net;


namespace AfaDataExtraction
{
    public class ExtractorFromCboeRt : ExtractorBase
    {
		#region (------  Constants  ------)
        private const string URL_FORMAT_STRING_CURRENT = "http://www.cboe.com/delayedquote/simplequote.aspx?ticker={0}";
		#endregion (------  Constants  ------)

		#region (------  Fields  ------)
        private readonly Regex m_regexCurrentClose = new Regex("                        Last Sale([^>]*>\r\n){2}(?<DATA>[ 0-9.,]*)<", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentHigh = new Regex("  High([^>]*>\r\n){2}(?<DATA>[ 0-9.,]*)<", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentLow = new Regex("   low([^>]*>\r\n){2}(?<DATA>[ 0-9.,]*)<", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentOpen = new Regex("                  open([^>]*>\r\n){2}(?<DATA>[ 0-9.,]*)<", RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion (------  Fields  ------)

		#region (------  Public Methods  ------)

        public ExtractorFromCboeRt(int p_extractionRtStartHour) : base(p_extractionRtStartHour)
        {
        }

        public override SymbolExtractedData[] GetHistoryData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            p_symbolWebName = p_symbolWebName.Replace("^", "");
            //No history for CBOE extractor
            return new SymbolExtractedData[0];
        }

        public override SymbolExtractedData GetRealTimeData(string p_symbolWebName)
        {
            try
            {
                SymbolExtractedData singleData = new SymbolExtractedData(p_symbolWebName);
                string webNameToUse = p_symbolWebName.Replace("^", "");
                string sPage = getStockCurrentPageString(webNameToUse);
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
        private string getStockCurrentPageString(string p_symbolWebName)
        {
            try
            {
                string sUrl = string.Format(URL_FORMAT_STRING_CURRENT, p_symbolWebName);
                byte[] bytes = Client.DownloadData(sUrl);
                return Utf8Encoder.GetString(bytes);
            }
            catch (Exception ex)
            {
                s_logger.WarnFormat("{0} {1}",ex.Message,ex);
                return null;
            }
        }
		#endregion (------  Private Methods  ------)
    }
}