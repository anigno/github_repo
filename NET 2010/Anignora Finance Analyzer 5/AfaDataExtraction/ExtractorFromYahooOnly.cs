using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using log4net;


namespace AfaDataExtraction
{
    public class ExtractorFromYahooOnly : ExtractorBase
    {
		#region (------  Fields  ------)

        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#endregion (------  Fields  ------)

		#region (------------------  Const Fields  ------------------)
        private const string URL_CSV_FORMAT_STRING_YAHOO = @"http://ichart.finance.yahoo.com/table.csv?s={0}&a={1}&b={2}&c={3}&d={4}&e={5}&f={6}&g=d&ignore=.csv";
        private const string URL_FORMAT_STRING_CURRENT_YAHOO = "http://finance.yahoo.com/q?s={0}";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_CLOSE_LAST_TRADE = "Last Trade:([^>]*>){5}(?<DATA>[0-9.,]*)";

        private const string YAHOO_COMPOSITE_REGX_CURRENT_OPEN = "Open:([^>]*>){2}(?<DATA>[0-9.,]*)";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_CLOSE_RT = "quote_summary_rt_top([^>]*>){4}(?<DATA>[0-9.,]*)";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_RANGE_HIGH = "Day's Range:([^>]*>){8}(?<DATA>[0-9.,]*)";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_RANGE_LOW = "Day's Range:([^>]*>){4}(?<DATA>[0-9.,]*)";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_VOL = "Volume:([^>]*>){3}(?<DATA>[0-9.,]*)";

        #endregion (------------------  Const Fields  ------------------)

		#region (------------------  Fields  ------------------)
        private readonly Regex m_regexCurrentCloseRt = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_CLOSE_RT, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentCloseLastTrade = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_CLOSE_LAST_TRADE, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentRangeLow = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_RANGE_LOW, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentRangeHigh = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_RANGE_HIGH, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentOpen = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_OPEN, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentVolume = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_VOL, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        #endregion (------------------  Fields  ------------------)

		#region (------------------  Overridden Methods  ------------------)
  
		#endregion (------------------  Overridden Methods  ------------------)

		#region (------------------  Private Methods  ------------------)
        //public static string MarketName(string p_descriptor)
        //{
        //    int a = p_descriptor.IndexOf(":");
        //    if (a < 0) return p_descriptor;
        //    return p_descriptor.Substring(a + 1);
        //}
        public ExtractorFromYahooOnly(int p_extractionRtStartHour) : base(p_extractionRtStartHour)
        {
        }

        protected override string FixSymbolName(string p_symbolName)
        {
            if (p_symbolName.ToUpper() == "VIX")
            {
                string newName = "^" + p_symbolName;
                s_logger.DebugFormat("Changed symbolName to: {0}", newName);
                return newName;
            }
            return p_symbolName;
        } 
        public override SymbolExtractedData[] GetHistoryData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            string newWebName = FixSymbolName(p_symbolWebName);
            List<SymbolExtractedData> data = new List<SymbolExtractedData>();
            try
            {
                string urlFormated = string.Format(URL_CSV_FORMAT_STRING_YAHOO, newWebName, p_dateFrom.Month - 1, p_dateFrom.Day, p_dateFrom.Year, p_dateTo.Month - 1, p_dateTo.Day, p_dateTo.Year);
                s_logger.DebugFormat("urlFormated: {0}", urlFormated);
                //If bad stockName, exception will be thrown here
                Stream strm = Client.OpenRead(urlFormated);
                StreamReader sr = new StreamReader(strm);
                sr.ReadLine(); //First line read is headers ("Date,Open,High,Low,Close,Volume")
                string line;
                do
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        string[] parts = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        SymbolExtractedData newDayChangeData = new SymbolExtractedData(p_symbolWebName)
                                                               {
                            DateRead = DateTime.Parse(parts[0]).Date,
                            Open = float.Parse(parts[1]),
                            High = float.Parse(parts[2]),
                            Low = float.Parse(parts[3]),
                            Close = float.Parse(parts[4]),
                        };
                        data.Add(newDayChangeData);
                    }
                } while (line != null);
                strm.Close();
                sr.Close();
            }
            catch (Exception ex)
            {
                s_logger.WarnFormat("{0} {1}", ex.Message, ex);
            }
            if (data.Count < 1) s_logger.WarnFormat("{0} data length={1}", p_symbolWebName,data.Count);
            return data.ToArray();
        }

        public override SymbolExtractedData GetRealTimeData(string p_symbolWebName)
        {
            string newWebName = FixSymbolName(p_symbolWebName);

            try
            {
                SymbolExtractedData singleData = new SymbolExtractedData(p_symbolWebName);
                string sPage = getYahooFinanceStockCurrentPageString(newWebName);
                //yahoo could have RealTime or Last Trade
                Match mCurrentCloseRt = m_regexCurrentCloseRt.Match(sPage);
                Match mCurrentCloseLastTrade = m_regexCurrentCloseLastTrade.Match(sPage);
                Match mCurrentRangeMin = m_regexCurrentRangeLow.Match(sPage);
                Match mCurrentRangeMax = m_regexCurrentRangeHigh.Match(sPage);
                Match mCurrentOpen = m_regexCurrentOpen.Match(sPage);
                Match mCurrentVol = m_regexCurrentVolume.Match(sPage);
                //If could not find matches, no RT data
                if (!mCurrentCloseLastTrade.Success && !mCurrentCloseRt.Success) return null;
                if (!mCurrentRangeMin.Success || !mCurrentRangeMax.Success)
                {
                    return null;
                }
                //yahoo could have RealTime or Last Trade
                string sCurrentClose=string.Empty;
                if (mCurrentCloseLastTrade.Success) sCurrentClose = mCurrentCloseLastTrade.Result("${DATA}");
                if (mCurrentCloseRt.Success) sCurrentClose = mCurrentCloseRt.Result("${DATA}");
                 
                string sCurrentRangeMin = mCurrentRangeMin.Result("${DATA}");
                string sCurrentRangeMax = mCurrentRangeMax.Result("${DATA}");
                string sCurrentOpen = mCurrentOpen.Result("${DATA}");
                string sCurrentVol = mCurrentVol.Success ? mCurrentVol.Result("${DATA}") : "0";

                if (sCurrentClose.Length < 1 || sCurrentRangeMin.Length < 1 || sCurrentRangeMax.Length < 1||sCurrentOpen.Length<1)
                {
                    return null;
                }
                float currentLow = float.Parse(sCurrentRangeMin);
                float currentHigh = float.Parse(sCurrentRangeMax);
                float currentClose = float.Parse(sCurrentClose);
                float currentOpen = float.Parse(sCurrentOpen);
                singleData.DateRead = DateTime.Now.Date;
                singleData.Close = currentClose;
                singleData.High = currentHigh;
                singleData.Low = currentLow;
                singleData.Open = currentOpen;
                return singleData;

            }
            catch (Exception ex)
            {
                s_logger.WarnFormat("Symbol: {0} {1} {2}",p_symbolWebName, ex.Message, ex);
            }
            //No real time avaliable or exception
            s_logger.WarnFormat("{0} no RT data", p_symbolWebName);
            return null;
        }

        private string getYahooFinanceStockCurrentPageString(string p_symbolWebName)
        {
            try
            {
                string sUrl = string.Format(URL_FORMAT_STRING_CURRENT_YAHOO, p_symbolWebName);
                byte[] bytes = Client.DownloadData(sUrl);
                return Utf8Encoder.GetString(bytes);
            }
            catch (Exception ex)
            {
                s_logger.WarnFormat("{0} {1} {2} ",p_symbolWebName, ex.Message, ex);
                return null;
            }
        }
		#endregion (------------------  Private Methods  ------------------)
    }
}
