using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using FinanceAnalizer2.Data;
using LoggingProvider;

namespace FinanceAnalizer2.Web
{
    public class ExtractorFromGoogleFinance : ExtractorBase
    {
		#region (------------------  Enums  ------------------)
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
		#endregion (------------------  Enums  ------------------)


		#region (------------------  Const Fields  ------------------)
        private const string URL_CSV_FORMAT_STRING = @"http://www.google.com/finance/historical?q={0}&startdate={1}+{2}%2C+{3}&enddate={4}+{5}%2C+{6}&output=csv";
        private const string URL_FORMAT_STRING_CURRENT = "http://www.google.com/finance?q={0}";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private readonly Regex regexCurrentClose = new Regex("<span id[^\"]\"[^\"]*\">(?<DATA>[0-9.]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex regexCurrentRange = new Regex("<span[^>]*>Range<[^>]*>[^<]*<span[^>]*>(?<DATA>[0-9. -]*)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly UTF8Encoding utf8Encoder = new UTF8Encoding();
        private readonly WebClient client = new WebClient();
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public ExtractorFromGoogleFinance()
        {

        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Overridden Methods  ------------------)
        public override List<DayChangeData> ReadDaysChageData(string stockName, DateTime dateFrom, DateTime dateTo)
        {
            //clear time data
            dateFrom = GetDateOnly(dateFrom);
            dateTo = GetDateOnly(dateTo);
            Logger.LogDebug("StockName: {0} from:{1} to:{2}", stockName, dateFrom, dateTo);
            List<DayChangeData> dataRet = new List<DayChangeData>();
            try
            {
                //If requested dateTo is today try to get real time data
                if (dateTo.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    DayChangeData realTimeData = GetRealTimeData(stockName);
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
                    List<DayChangeData> historyData = GetHistoryData(stockName, dateFrom, dateTo);
                    dataRet.AddRange(historyData);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return dataRet;
        }
		#endregion (------------------  Overridden Methods  ------------------)


		#region (------------------  Private Methods  ------------------)
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
                Logger.LogError(ex);
                return null;
            }
        }

        private List<DayChangeData> GetHistoryData(string stockName, DateTime dateFrom, DateTime dateTo)
        {
            Logger.LogDebug("StockName: {0} from:{1} to:{2}", stockName, dateFrom, dateTo);
            List<DayChangeData> data = new List<DayChangeData>();
            try
            {
                string urlFormated = string.Format(URL_CSV_FORMAT_STRING, stockName, (MonthShortNamesEnum) dateFrom.Month, dateFrom.Day, dateFrom.Year, (MonthShortNamesEnum) dateTo.Month, dateTo.Day, dateTo.Year);
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
                        DayChangeData newDayChangeData = new DayChangeData()
                                                             {
                                                                 Date = DateTime.Parse(parts[0]),
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
            return data;
        }

        private DayChangeData GetRealTimeData(string stockName)
        {
            Logger.LogDebug("StockName: {0}", stockName);
            try
            {
                DayChangeData singleData = new DayChangeData();
                string sPage = GetGoogleFinanceStockCurrentPageString(stockName);
                string sCurrentClose = regexCurrentClose.Match(sPage).Result("${DATA}");
                string sCurrentRange = regexCurrentRange.Match(sPage).Result("${DATA}");
                string[] parts = sCurrentRange.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //Check if received two parts of range, if not, no real time data avaliable
                if (parts.Length == 2)
                {
                    float currentLow = float.Parse(parts[0]);
                    float currentHigh = float.Parse(parts[1]);
                    float currentClose = float.Parse(sCurrentClose);
                    singleData.Date = DateTime.Now;
                    singleData.Close = currentClose;
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
            return null;
        }
		#endregion (------------------  Private Methods  ------------------)
    }
}
