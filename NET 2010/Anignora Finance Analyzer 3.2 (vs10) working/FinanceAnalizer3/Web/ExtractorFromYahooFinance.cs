using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using FinanceAnalyzerData.Data;
using LoggingProvider;

namespace FinanceAnalizer3.Web
{
    public class ExtractorFromYahooFinance : ExtractorBase
    {
		#region (------------------  Const Fields  ------------------)
        private const string URL_CSV_FORMAT_STRING_YAHOO = @"http://ichart.finance.yahoo.com/table.csv?s={0}&a={1}&b={2}&c={3}&d={4}&e={5}&f={6}&g=d&ignore=.csv";
        private const string URL_FORMAT_STRING_CURRENT_YAHOO = "http://finance.yahoo.com/q?s={0}";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_CLOSE = "Index Value:([^>]*>){5}(?<DATA>[0-9.,]*)";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_RANGE_HIGH = "Day's Range:([^>]*>){8}(?<DATA>[0-9.,]*)";
        private const string YAHOO_COMPOSITE_REGX_CURRENT_RANGE_LOW = "Day's Range:([^>]*>){4}(?<DATA>[0-9.,]*)";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private readonly Regex regexCurrentClose = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_CLOSE, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex regexCurrentRangeLow = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_RANGE_LOW, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex regexCurrentRangeHigh = new Regex(YAHOO_COMPOSITE_REGX_CURRENT_RANGE_HIGH, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly UTF8Encoding utf8Encoder = new UTF8Encoding();
        private readonly WebClient client = new WebClient();
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Overridden Methods  ------------------)
        public override DayChangeData[] ReadDaysChangeData(string stockDesctiptor, DateTime dateFrom, DateTime dateTo)
        {
            lock (_syncRoot)
            {
                //clear time data
                dateFrom = dateFrom.Date;
                dateTo = dateTo.Date;
                if (dateFrom < CommonParams.MINIMUM_DATE) throw new Exception("Could not extract data before minimum date " + CommonParams.MINIMUM_DATE);
                if (dateFrom > dateTo) throw new Exception("DateFrom could not be after DateTo");
                Logger.LogDebug("Start StockName: {0} from:{1} to:{2}", stockDesctiptor, dateFrom, dateTo);
                List<DayChangeData> dataRet = new List<DayChangeData>();
                try
                {
                    //If requested dateTo is today try to get real time data
                    if (dateTo.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        DayChangeData realTimeData = GetRealTimeData(stockDesctiptor);
                        //Check if real data exists, if is modify dateTo to day before
                        if (realTimeData != null)
                        {
                            dateTo = dateTo.Subtract(new TimeSpan(1, 0, 0, 0));
                            dataRet.Add(realTimeData);
                        }
                    }
                    //Get history data if needed
                    if (dateFrom <= dateTo)
                    {
                        List<DayChangeData> historyData = GetHistoryData(stockDesctiptor, dateFrom, dateTo);
                        dataRet.AddRange(historyData);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
                Logger.LogDebug("End StockName: {0} from:{1} to:{2}", stockDesctiptor, dateFrom, dateTo);
                return dataRet.ToArray();
            }
        }
		#endregion (------------------  Overridden Methods  ------------------)


		#region (------------------  Private Methods  ------------------)
        private List<DayChangeData> GetHistoryData(string stockDesctiptor, DateTime dateFrom, DateTime dateTo)
        {
            List<DayChangeData> data = new List<DayChangeData>();
            try
            {
                string urlFormated = string.Format(URL_CSV_FORMAT_STRING_YAHOO, DayChangeData.GetStockName(stockDesctiptor), dateFrom.Month - 1, dateFrom.Day, dateFrom.Year, dateTo.Month - 1, dateTo.Day, dateTo.Year);
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
                        DayChangeData newDayChangeData = new DayChangeData(stockDesctiptor)
                        {
                            Date = DateTime.Parse(parts[0]).Date,
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
                Logger.LogError(ex, "Probably bad stock name: {0}", stockDesctiptor);
            }
            return data;
        }

        private DayChangeData GetRealTimeData(string stockDesctiptor)
        {
            try
            {
                DayChangeData singleData = new DayChangeData(stockDesctiptor);
                string sPage = GetYahooFinanceStockCurrentPageString(stockDesctiptor);
                Match mCurrentClose = regexCurrentClose.Match(sPage);
                Match mCurrentRangeMin = regexCurrentRangeLow.Match(sPage);
                Match mCurrentRangeMax = regexCurrentRangeHigh.Match(sPage);
                //If could not find matches, no RT data
                if (!mCurrentClose.Success || !mCurrentRangeMin.Success || !mCurrentRangeMax.Success)
                {
                    Logger.LogWarning("No RT data for: {0}", stockDesctiptor);
                    return null;
                }
                string sCurrentClose = mCurrentClose.Result("${DATA}");
                string sCurrentRangeMin = mCurrentRangeMin.Result("${DATA}");
                string sCurrentRangeMax = mCurrentRangeMax.Result("${DATA}");
                if (sCurrentClose.Length < 1 || sCurrentRangeMin.Length < 1 || sCurrentRangeMax.Length < 1)
                {
                    Logger.LogWarning("No RT data for: {0} , Length<1", stockDesctiptor);
                    return null;
                }
                float currentLow = float.Parse(sCurrentRangeMin);
                float currentHigh = float.Parse(sCurrentRangeMax);
                float currentClose = float.Parse(sCurrentClose);
                singleData.Date = DateTime.Now.Date;
                singleData.Close = currentClose;
                singleData.High = currentHigh;
                singleData.Low = currentLow;
                return singleData;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            //No real time avaliable or exception
            return null;
        }

        private string GetYahooFinanceStockCurrentPageString(string stockDesctiptor)
        {
            try
            {
                string sUrl = string.Format(URL_FORMAT_STRING_CURRENT_YAHOO, DayChangeData.GetStockName(stockDesctiptor));
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
