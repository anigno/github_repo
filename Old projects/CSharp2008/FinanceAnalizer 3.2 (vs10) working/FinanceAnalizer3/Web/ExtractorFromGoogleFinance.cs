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


		#region (------------------  Overridden Methods  ------------------)
        /// <summary>
        /// Read, extract and return all trade data between dates. includes none trade dates!
        /// </summary>
        public override DayChangeData[] ReadDaysChangeData(string stockDescriptor, DateTime dateFrom, DateTime dateTo)
        {
            lock (_syncRoot)
            {
                //clear time data
                dateFrom = dateFrom.Date;
                dateTo = dateTo.Date;
                if (dateFrom < CommonParams.MINIMUM_DATE) throw new Exception("Could not extract data before minimum date " + CommonParams.MINIMUM_DATE);
                if (dateFrom > dateTo) throw new Exception("DateFrom could not be after DateTo");
                Logger.LogDebug("Start StockName: {0} from:{1} to:{2}", stockDescriptor, dateFrom, dateTo);
                List<DayChangeData> dataRet = new List<DayChangeData>();
                try
                {
                    //If requested dateTo is today try to get real time data
                    if (dateTo.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        DayChangeData realTimeData = GetRealTimeData(stockDescriptor);
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
                        List<DayChangeData> historyData = GetHistoryData(stockDescriptor, dateFrom, dateTo);
                        dataRet.AddRange(historyData);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
                Logger.LogDebug("End StockName: {0} from:{1} to:{2}", stockDescriptor, dateFrom, dateTo);
                return dataRet.ToArray();
            }
        }
		#endregion (------------------  Overridden Methods  ------------------)


		#region (------------------  Private Methods  ------------------)
        private string GetGoogleFinanceStockCurrentPageString(string stockName)
        {
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

        private List<DayChangeData> GetHistoryData(string stockDescriptor, DateTime dateFrom, DateTime dateTo)
        {
            List<DayChangeData> data = new List<DayChangeData>();
            try
            {
                string urlFormated = string.Format(URL_CSV_FORMAT_STRING,DayChangeData.GetStockName(stockDescriptor), (MonthShortNamesEnum) dateFrom.Month, dateFrom.Day, dateFrom.Year, (MonthShortNamesEnum) dateTo.Month, dateTo.Day, dateTo.Year);
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
                        DayChangeData newDayChangeData = new DayChangeData(stockDescriptor)
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
                Logger.LogError(ex,"Probably bad stock name: {0}",stockDescriptor);
            }
            return data;
        }

        private DayChangeData GetRealTimeData(string stockDescriptor)
        {
            try
            {
                DayChangeData singleData = new DayChangeData(stockDescriptor);
                string sPage = GetGoogleFinanceStockCurrentPageString(DayChangeData.GetStockName(stockDescriptor));
                Match mCurrentClose= regexCurrentClose.Match(sPage);
                Match mCurrentRange=regexCurrentRange.Match(sPage);
                //If could not find matches, no RT data
                if (!mCurrentClose.Success || !mCurrentRange.Success)
                {
                    Logger.LogWarning("No RT data for: {0}", stockDescriptor);
                    return null;
                }
                string sCurrentClose = mCurrentClose.Result("${DATA}");
                string sCurrentRange = mCurrentRange.Result("${DATA}");
                string[] parts = sCurrentRange.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //Check if received two parts of range, if not, no real time data avaliable
                if (parts.Length == 2)
                {
                    float currentLow = float.Parse(parts[0]);
                    float currentHigh = float.Parse(parts[1]);
                    float currentClose = float.Parse(sCurrentClose);
                    singleData.Date = DateTime.Now.Date;
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