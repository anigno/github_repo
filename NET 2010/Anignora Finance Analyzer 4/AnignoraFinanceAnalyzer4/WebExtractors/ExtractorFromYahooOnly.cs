using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using AnignoraFinanceAnalyzer4.Data;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using LoggingProvider;

namespace AnignoraFinanceAnalyzer4.WebExtractors
{
    public class ExtractorFromYahooOnly : ExtractorBase
    {


		#region (------------------  Const Fields  ------------------)
        private const string URL_CSV_FORMAT_STRING_YAHOO = @"http://ichart.finance.yahoo.com/table.csv?s={0}&a={1}&b={2}&c={3}&d={4}&e={5}&f={6}&g=d&ignore=.csv";
        private const string URL_FORMAT_STRING_CURRENT_YAHOO = "http://finance.yahoo.com/q?s={0}";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_OPEN = "Open:([^>]*>){2}(?<DATA>[0-9.,]*)";
        //private const string YAHOO_COMPOSITE_REGX_CURRENT_CLOSE = "Last Trade:([^>]*>){5}(?<DATA>[0-9.,]*)";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_CLOSE = "quote_summary_rt_top([^>]*>){4}(?<DATA>[0-9.,]*)";

        private const string YAHOO_COMPOSITE_REGX_CURRENT_RANGE_HIGH = "Day's Range:([^>]*>){8}(?<DATA>[0-9.,]*)";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_RANGE_LOW = "Day's Range:([^>]*>){4}(?<DATA>[0-9.,]*)";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_VOL = "Volume:([^>]*>){3}(?<DATA>[0-9.,]*)";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private readonly Regex regexCurrentClose = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_CLOSE, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex regexCurrentRangeLow = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_RANGE_LOW, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex regexCurrentRangeHigh = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_RANGE_HIGH, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex regexCurrentOpen = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_OPEN, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex regexCurrentVolume = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_VOL, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        #endregion (------------------  Fields  ------------------)


		#region (------------------  Overridden Methods  ------------------)
  
		#endregion (------------------  Overridden Methods  ------------------)


		#region (------------------  Private Methods  ------------------)

        public override List<SymbolDailyData> GetHistoryData(string descriptor, DateTime dateFrom, DateTime dateTo)
        {
            List<SymbolDailyData> data = new List<SymbolDailyData>();
            try
            {
                string searchDescriptor =SymbolData.RemovePreSymbol(descriptor);   //Yahoo doesn't need the preSymbol etc' NASDAQ:
                string urlFormated = string.Format(URL_CSV_FORMAT_STRING_YAHOO, SymbolDailyData.GetStockNameWithoutMultiplier(searchDescriptor), dateFrom.Month - 1, dateFrom.Day, dateFrom.Year, dateTo.Month - 1, dateTo.Day, dateTo.Year);
                Logger.LogDebug("urlFormated: {0}", urlFormated);
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
                        string[] parts = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        SymbolDailyData newDayChangeData = new SymbolDailyData(descriptor)
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
            if (data.Count < 1) Logger.LogWarning("{0} data length={1}", descriptor,data.Count);
            return data;
        }

        public override SymbolDailyData GetRealTimeData(string descriptor)
        {
            try
            {
                string searchDescriptor = SymbolData.RemovePreSymbol(descriptor);   //Yahoo doesn't need the preSymbol etc' NASDAQ:
                SymbolDailyData singleData = new SymbolDailyData(descriptor);
                string sPage = GetYahooFinanceStockCurrentPageString(searchDescriptor);
                Match mCurrentClose = regexCurrentClose.Match(sPage);
                Match mCurrentRangeMin = regexCurrentRangeLow.Match(sPage);
                Match mCurrentRangeMax = regexCurrentRangeHigh.Match(sPage);
                Match mCurrentOpen = regexCurrentOpen.Match(sPage);
                Match mCurrentVol = regexCurrentVolume.Match(sPage);
                //If could not find matches, no RT data
                if (!mCurrentClose.Success || !mCurrentRangeMin.Success || !mCurrentRangeMax.Success)
                {
                    return null;
                }
                string sCurrentClose = mCurrentClose.Result("${DATA}");
                string sCurrentRangeMin = mCurrentRangeMin.Result("${DATA}");
                string sCurrentRangeMax = mCurrentRangeMax.Result("${DATA}");
                string sCurrentOpen = mCurrentOpen.Result("${DATA}");
                string sCurrentVol = mCurrentVol.Result("${DATA}");

                if (sCurrentClose.Length < 1 || sCurrentRangeMin.Length < 1 || sCurrentRangeMax.Length < 1||sCurrentOpen.Length<1)
                {
                    return null;
                }
                float currentLow = float.Parse(sCurrentRangeMin);
                float currentHigh = float.Parse(sCurrentRangeMax);
                float currentClose = float.Parse(sCurrentClose);
                float currentOpen = float.Parse(sCurrentOpen);
                float currentVol = float.Parse(sCurrentVol);
                singleData.ReadDate = DateTime.Now.Date;
                singleData.Close = currentClose;
                singleData.High = currentHigh;
                singleData.Low = currentLow;
                singleData.Open = currentOpen;
                singleData.Volume = currentVol;
                return singleData;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            //No real time avaliable or exception
            Logger.LogWarning("{0} no RT data", descriptor);
            return null;
        }

        private string GetYahooFinanceStockCurrentPageString(string descriptor)
        {
            try
            {
                string sUrl = string.Format(URL_FORMAT_STRING_CURRENT_YAHOO, SymbolDailyData.GetStockNameWithoutMultiplier(descriptor));
                byte[] bytes = client.DownloadData(sUrl);
                return utf8Encoder.GetString(bytes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }
		#endregion (------------------  Private Methods  ------------------)
    }
}
