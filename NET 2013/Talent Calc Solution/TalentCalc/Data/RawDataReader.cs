using System;
using System.Collections.Generic;
using System.Globalization;
using AnignoraIO;
using log4net;

namespace TalentCalc.Data
{
    public class RawDataProvider
    {
        #region Constructors

        public RawDataProvider(DateTime p_minDate, DateTime p_maxDate)
        {
            m_minDate = p_minDate;
            m_maxDate = p_maxDate;
        }

        #endregion

        #region Public Methods

        public RawData[][] ReadAndFix(string p_fileA, string p_fileB)
        {
            string[][] fileA = CsvFileReaderWriter.ReadCsvFile(p_fileA, false);
            string[][] fileB = CsvFileReaderWriter.ReadCsvFile(p_fileB, false);
            RawData[] rawDataArrayA = read(fileA);
            RawData[] rawDataArrayB = read(fileB);
            return new[] {rawDataArrayA, rawDataArrayB};
        }

        #endregion

        #region Public Properties


        #endregion

        #region Private Methods

        private DateTime parseDate(string p_dateTimeString)
        {
            string[] formats = {"d/M/yyyy h:m", "d/M/yyyy", "yyyy-M-d"};
            DateTime dateValue;
            bool bResult = DateTime.TryParseExact(p_dateTimeString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
            if (bResult) return dateValue;
            s_logger.ErrorFormat("parseDate() couldn't parse date: {0}", p_dateTimeString);
            return DateTime.MinValue;
        }

        private RawData[] read(IList<string[]> p_lines)
        {
            List<RawData> rawDataList = new List<RawData>();
            foreach (string[] line in p_lines)
            {
                RawData rawData = new RawData(parseDate(line[0]))
                {
                    Close = parseDouble(line[1]),
                    //Open = parseDouble(line[3]),
                    //High = parseDouble(line[4]),
                    //Low = parseDouble(line[5]),
                    //Volume = parseDouble(line[6]),
                };
                //if (Math.Abs(rawData.Close*rawData.Open*rawData.High*rawData.Low) < 0.000001)
                if (Math.Abs(rawData.Close) < 0.000001)
                {
                    s_logger.WarnFormat("read(), No data item could be zero. [{0}]", rawData);
                    continue;
                }
                if (rawData.Date.Date >= m_minDate && rawData.Date.Date <= m_maxDate)
                {
                    rawDataList.Add(rawData);
                }
            }
            RawData[] targetRawDataArray = rawDataList.ToArray();
            return targetRawDataArray;
        }

        private double parseDouble(string p_doubleString)
        {
            double d;
            bool bResult = double.TryParse(p_doubleString, out d);
            if (bResult) return d;
            //s_logger.ErrorFormat("parseDouble() couldn't parse: {0}", p_doubleString);
            return double.NaN;
        }

        #endregion

        #region Fields

        private readonly DateTime m_minDate;
        private readonly DateTime m_maxDate;

        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
    }
}