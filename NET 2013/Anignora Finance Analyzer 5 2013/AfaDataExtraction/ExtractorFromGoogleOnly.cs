using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using log4net;


namespace AfaDataExtraction
{
    public class ExtractorFromGoogleOnly : ExtractorBase
    {
        #region (------  Enums  ------)

        public enum MonthShortNamesEnum
        {
            Jan = 1,
            Feb,
            Mar,
            Apr,
            May,
            Jun,
            Jul,
            Aug,
            Sep,
            Oct,
            Nov,
            Dec
        }

        #endregion (------  Enums  ------)

        #region (------  Constants  ------)

        private const string URL_CSV_FORMAT_STRING = @"http://www.google.com/finance/historical?q={0}&startdate={1}+{2}%2C+{3}&enddate={4}+{5}%2C+{6}&num=30&num=30&output=csv";
        private const string URL_FORMAT_STRING_CURRENT = "http://www.google.com/finance?q={0}";

        #endregion (------  Constants  ------)

        #region (------  Fields  ------)

        private readonly Regex m_regexCurrentClose = new Regex("<span id[^\"]\"[^\"]*\">(?<DATA>[0-9.]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentOpen = new Regex("data-snapfield=\"open\">([^>]*>){2}(?<DATA>[0-9.,]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentRange = new Regex("data-snapfield=\"range\">([^>]*>){2}(?<DATA>[0-9. -]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regexCurrentVolAvg = new Regex("data-snapfield=\"vol_and_avg\">([^>]*>){2}(?<DATA>[0-9.,]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion (------  Fields  ------)

        #region (------  Public Methods  ------)

        public ExtractorFromGoogleOnly(int p_extractionRtStartHour) : base(p_extractionRtStartHour)
        {
        }

        protected override string FixSymbolName(string p_symbolName)
        {
            if (p_symbolName.ToUpper() == "VXX")
            {
                return "NYSEARCA:VXX";
            }
            if (p_symbolName.ToUpper() == "VIX")
            {
                s_logger.DebugFormat("No Google VIX symbol, will return empty string");
                return "";
            }
            return p_symbolName;
        }

        public override SymbolExtractedData[] GetHistoryData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
        {
            if (p_symbolWebName.ToUpper() == "VXX")
            {
            }
            string newWebName = FixSymbolName(p_symbolWebName);
            List<SymbolExtractedData> data = new List<SymbolExtractedData>();
            string[] parts;
            try
            {
                string urlFormated = string.Format(URL_CSV_FORMAT_STRING, newWebName, (MonthShortNamesEnum)p_dateFrom.Month, p_dateFrom.Day, p_dateFrom.Year, (MonthShortNamesEnum)p_dateTo.Month, p_dateTo.Day, p_dateTo.Year);
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
                        try
                        {
                            parts = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            SymbolExtractedData newDayChangeData = new SymbolExtractedData(p_symbolWebName);
                            newDayChangeData.DateRead = DateTime.Parse(parts[0]).Date;
                            newDayChangeData.Close = float.Parse(parts[4]);
                            newDayChangeData.Low = float.Parse(parts[3]);
                            newDayChangeData.High = float.Parse(parts[2]);
                            newDayChangeData.Open = float.Parse(parts[1]);
                            data.Add(newDayChangeData);
                        }
                        catch (Exception ex)
                        {
                            s_logger.WarnFormat("Google data is corrupted and will be ignored, {0} [{1}] {2} {3}", p_symbolWebName,line, ex.Message, ex);
                        }
                    }
                } while (line != null);
                strm.Close();
                sr.Close();
            }
            catch (Exception ex)
            {
                s_logger.WarnFormat("{0} [{1} {2}]",p_symbolWebName, ex.Message, ex);
            }
            if (data.Count < 1) s_logger.WarnFormat("{0} data length={1}", p_symbolWebName, data.Count);
            SymbolExtractedData[] extractedDataArray= data.ToArray();
            return extractedDataArray;
        }

        public override SymbolExtractedData GetRealTimeData(string p_symbolWebName)
        {
            string newWebName = FixSymbolName(p_symbolWebName);
            try
            {
                SymbolExtractedData singleData = new SymbolExtractedData(p_symbolWebName);
                string sPage = getGoogleFinanceStockCurrentPageString(newWebName);
                Match mCurrentClose = m_regexCurrentClose.Match(sPage);
                Match mCurrentOpen = m_regexCurrentOpen.Match(sPage);
                Match mCurrentVol = m_regexCurrentVolAvg.Match(sPage);
                Match mCurrentRange = m_regexCurrentRange.Match(sPage);
                //If could not find matches, no RT data
                if (!mCurrentClose.Success || !mCurrentRange.Success)
                {
                    return null;
                }
                string sCurrentClose = mCurrentClose.Result("${DATA}");
                string sCurrentOpen = mCurrentOpen.Result("${DATA}");
                string sCurrentVol = mCurrentVol.Result("${DATA}");
                sCurrentVol = sCurrentVol.Replace("M", "000000").Replace(".", "").Replace(",", "");
                string sCurrentRange = mCurrentRange.Result("${DATA}");
                string[] rangeParts = sCurrentRange.Split(new[] {"-"}, StringSplitOptions.RemoveEmptyEntries);
                //Check if received two parts of range, if not, no real time data avaliable
                if (rangeParts.Length == 2)
                {
                    float currentLow = float.Parse(rangeParts[0]);
                    float currentHigh = float.Parse(rangeParts[1]);
                    float currentClose = float.Parse(sCurrentClose);
                    float currentOpen = float.Parse(sCurrentOpen);
                    float currentVol = float.Parse(sCurrentVol);
                    singleData.DateRead = DateTime.Now.Date;
                    singleData.Close = currentClose;
                    singleData.Open = currentOpen;
                    singleData.High = currentHigh;
                    singleData.Low = currentLow;
                    return singleData;
                }
            }
            catch (Exception ex)
            {
                s_logger.WarnFormat("{0} {1}", ex.Message, ex);
            }
            //No real time avaliable or exception
            s_logger.WarnFormat("{0} no RT data", p_symbolWebName);
            return null;
        }

        #endregion (------  Public Methods  ------)

        #region (------  Private Methods  ------)

        private string getGoogleFinanceStockCurrentPageString(string p_symbolWebName)
        {
            try
            {
                string sUrl = string.Format(URL_FORMAT_STRING_CURRENT, p_symbolWebName);
                byte[] bytes = Client.DownloadData(sUrl);
                return Utf8Encoder.GetString(bytes);
            }
            catch (Exception ex)
            {
                s_logger.WarnFormat("{0} {1}", ex.Message, ex);
                return null;
            }
        }

        #endregion (------  Private Methods  ------)
    }
}