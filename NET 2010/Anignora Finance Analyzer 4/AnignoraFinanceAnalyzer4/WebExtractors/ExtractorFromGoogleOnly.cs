using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using LoggingProvider;
using System.Linq;

namespace AnignoraFinanceAnalyzer4.WebExtractors
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
		#endregion (------  Fields  ------)

		#region (------  Public Methods  ------)
        public override List<SymbolDailyData> GetHistoryData(string p_descriptor, DateTime p_dateFrom, DateTime p_dateTo)
        {
            List<SymbolDailyData> data = new List<SymbolDailyData>();
            try
            {
                string urlFormated = string.Format(URL_CSV_FORMAT_STRING, SymbolDailyData.GetStockNameWithoutMultiplier(p_descriptor), (MonthShortNamesEnum)p_dateFrom.Month, p_dateFrom.Day, p_dateFrom.Year, (MonthShortNamesEnum)p_dateTo.Month, p_dateTo.Day, p_dateTo.Year);
                Logger.LogDebug("urlFormated: {0}",urlFormated);
                //If bad stockName, exception will be thrown here
                Stream strm = client.OpenRead(urlFormated);
                StreamReader sr = new StreamReader(strm);
                sr.ReadLine(); //First line read is headers ("Date,Open,High,Low,Close,Volume")
                string line;
                do
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        string[] parts = line.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                        SymbolDailyData newDayChangeData = new SymbolDailyData(p_descriptor)
                                                             {
                                                                 ReadDate = DateTime.Parse(parts[0]).Date,
                                                                 Open = float.Parse(parts[1]),
                                                                 High = float.Parse(parts[2]),
                                                                 Low = float.Parse(parts[3]),
                                                                 Close = float.Parse(parts[4]),
                                                                 Volume = float.Parse(parts[5])
                                                             };
                        data.Add(newDayChangeData);
                    }
                } while (line != null);
                strm.Close();
                sr.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            if (data.Count < 1) Logger.LogWarning("{0} data length={1}", p_descriptor, data.Count);
            return data;
        }

        public override SymbolDailyData GetRealTimeData(string p_descriptor)
        {
            try
            {
                SymbolDailyData singleData = new SymbolDailyData(p_descriptor);
                string sPage = getGoogleFinanceStockCurrentPageString(SymbolDailyData.GetStockNameWithoutMultiplier(p_descriptor));
                Match mCurrentClose= m_regexCurrentClose.Match(sPage);
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
                sCurrentVol= sCurrentVol.Replace("M", "000000").Replace(".","").Replace(",","");
                string sCurrentRange = mCurrentRange.Result("${DATA}");
                string[] rangeParts = sCurrentRange.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //Check if received two parts of range, if not, no real time data avaliable
                if (rangeParts.Length == 2)
                {
                    float currentLow = float.Parse(rangeParts[0]);
                    float currentHigh = float.Parse(rangeParts[1]);
                    float currentClose = float.Parse(sCurrentClose);
                    float currentOpen = float.Parse(sCurrentOpen);
                    float currentVol = float.Parse(sCurrentVol);
                    singleData.ReadDate = DateTime.Now.Date;
                    singleData.Close = currentClose;
                    singleData.Open = currentOpen;
                    singleData.Volume = currentVol;
                    singleData.High = currentHigh;
                    singleData.Low = currentLow;
                    return singleData;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            //No real time avaliable or exception
            Logger.LogWarning("{0} no RT data",p_descriptor);
            return null;
        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        private string getGoogleFinanceStockCurrentPageString(string descriptor)
        {
            try
            {
                string sUrl = string.Format(URL_FORMAT_STRING_CURRENT, descriptor);
                byte[] bytes = client.DownloadData(sUrl);
                return utf8Encoder.GetString(bytes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
		#endregion (------  Private Methods  ------)
    }
}