using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using AnignoLibrary.DataTypes.DataManager;
using FinanceAnalizer.Data;
using System.Text.RegularExpressions;
using LoggingProvider;
using System.IO;

namespace FinanceAnalizer.Web
{
    public class GoogleFinanceExtractor : ExtractorBase
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

		#region (------  Const Fields  ------)

        private const string URL_FORMAT_STRING = "http://www.google.com/finance/historical?q={0}&startdate={1}&enddate={2}&num={3}&start={4}";
        private const string URL_FORMAT_STRING_CURRENT = "http://www.google.com/finance?q={0}";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private readonly ApplicationData data = DataManagerContractBased<ApplicationData>.DataItem;
        private readonly Regex regexHistoricalTable = new Regex(@"<table\s+id=historical_price[^>]*>(?<DATA>.*)</table>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex regexTd = new Regex("<td[^>]*>(?<DATA>[a-z0-9., ]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex regexCurrentClose = new Regex("<span id[^\"]\"[^\"]*\">(?<DATA>[0-9.]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex regexCurrentRange = new Regex("<span[^>]*>Range<[^>]*>[^<]*<span[^>]*>(?<DATA>[0-9. -]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly UTF8Encoding utf8Encoder = new UTF8Encoding();
        private readonly WebClient client = new WebClient();

		#endregion (------  Fields  ------)

		#region (------  Overridden Methods  ------)

        public override string DownloadHistoryCsv(string stockName, string downloadDirectory)
        {
            string destFileName = downloadDirectory + @"\" + stockName + ".csv";
            try
            {
                WebClient wc = new WebClient();
                if (!Directory.Exists(downloadDirectory)) Directory.CreateDirectory(downloadDirectory);
                wc.DownloadFile(@"http://www.google.com/finance/historical?q=" + stockName + @"&startdate=Dec+20%2C+1995&enddate=Dec+19%2C+2099&output=csv", destFileName);
                wc.Dispose();
                return destFileName;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "StockName: {0} downloadDir: {1}", stockName, downloadDirectory);
            }
            return null;
        }

        /// <summary>
        /// Will Add DayChangeData only if there was a transaction in this day (No holidays etc)
        /// </summary>
        private bool AddStockDataIfChanged(List<DayChangeData> dayChangeList, DayChangeData dayData)
        {
            if (dayData.Close == dayData.Low && dayData.Low == dayData.High)
            {
                return false;
            }
            dayChangeList.Add(dayData);
            return true;
        }

        public override List<DayChangeData> ExtractStockData(string stockName, DateTime fromDate, DateTime toDate)
        {
            Logger.LogDebug("StockName: {0}: fromDate: {1} toDate: {2}", stockName, fromDate, toDate);
            List<DayChangeData> stockDataList = new List<DayChangeData>();
            try
            {
                //Get realtime value
                string sPage = GetGoogleFinanceStockCurrentPageString(stockName);
                string sCurrentClose = regexCurrentClose.Match(sPage).Result("${DATA}");
                string sCurrentRange = regexCurrentRange.Match(sPage).Result("${DATA}");
                string[] parts = sCurrentRange.Split(new [] {"-" }, StringSplitOptions.RemoveEmptyEntries);
                DayChangeData singleData = new DayChangeData();
                int includeYesterday = 0;   //should include today, no realtime
                if (parts.Length == 2)
                {
                    includeYesterday = 1;   //do not include today, it's realtime
                    float currentLow = float.Parse(parts[0]);
                    float currentHigh = float.Parse(parts[1]);
                    float currentClose = float.Parse(sCurrentClose);
                    singleData.Date = DateTime.Now;
                    singleData.Close = currentClose;
                    singleData.High = currentHigh;
                    singleData.Low = currentLow;
                    AddStockDataIfChanged(stockDataList, singleData);
                }
                //Get history from maybe yesterday
                toDate = new DateTime(toDate.Year, toDate.Month, toDate.Day );
                if (includeYesterday > 0)
                {
                    toDate = toDate - TimeSpan.FromDays(1);
                }
                for (int p = 0; p < 2; p++)
                {
                    sPage = GetGoogleFinanceStockHistoryPageString(stockName, fromDate, toDate, p);
                    string sTable = regexHistoricalTable.Match(sPage).Result("${DATA}");
                    singleData = new DayChangeData();
                    int a = 0;
                    foreach (Match m in regexTd.Matches(sTable))
                    {
                        string s = m.Result("${DATA}");
                        switch (a++)
                        {
                            case 0:
                                singleData.Date = GetDateTime(s);
                                break;
                            case 1:
                                singleData.Open = float.Parse(s);
                                break;
                            case 2:
                                singleData.High = float.Parse(s);
                                break;
                            case 3:
                                singleData.Low = float.Parse(s);
                                break;
                            case 4:
                                singleData.Close = float.Parse(s);
                                break;
                            case 5:
                                singleData.Volume = float.Parse(s);
                                AddStockDataIfChanged(stockDataList, singleData);
                                singleData = new DayChangeData();
                                a = 0;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "StockName: {0}: fromDate: {1} toDate: {2}", stockName, fromDate, toDate);
            }
            Logger.LogDebug("StockName: {0}: fromDate: {1} toDate: {2} returned data size={3}", stockName, fromDate, toDate, stockDataList.Count);
            return stockDataList;
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private DateTime GetDateTime(string googleDateTimeString)
        {
            string[] parts = googleDateTimeString.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
            int month = (int)Enum.Parse(typeof(MonthShortNamesEnum), parts[0]);
            int day = int.Parse(parts[1]);
            int year = int.Parse(parts[2]);
            DateTime date = new DateTime(year, month, day); ;
            return date;
        }

        private string GetGoogleDateString(DateTime date)
        {
            MonthShortNamesEnum mpnthString = (MonthShortNamesEnum)date.Month;
            int day = date.Day;
            int year = date.Year;
            return string.Format("{0}+{1},+{2}", mpnthString, day, year);
        }

        private string GetGoogleFinanceStockCurrentPageString(string stockName)
        {
            Logger.LogDebug("StockName: {0}", stockName);
            try
            {
                string sUrl = string.Format(URL_FORMAT_STRING_CURRENT, stockName);
                byte[] bytes = client.DownloadData(sUrl);
                return utf8Encoder.GetString(bytes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "StockName: {0}:", stockName);
                return null;
            }
        }

        private string GetGoogleFinanceStockHistoryPageString(string stockName, DateTime fromDate, DateTime toDate,int pageNumber)
        {
            Logger.LogDebug("StockName: {0}: fromDate: {1} toDate: {2}", stockName, fromDate, toDate);
            try
            {
                pageNumber *= 200;
                string sUrl = string.Format(URL_FORMAT_STRING, stockName, GetGoogleDateString(fromDate), GetGoogleDateString(toDate), data.MaxStockUpdateList,pageNumber);
                byte[] bytes = client.DownloadData(sUrl);
                return utf8Encoder.GetString(bytes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "StockName: {0}: fromDate: {1} toDate: {2}", stockName, fromDate, toDate);
                return null;
            }
        }

		#endregion (------  Private Methods  ------)

    }
}