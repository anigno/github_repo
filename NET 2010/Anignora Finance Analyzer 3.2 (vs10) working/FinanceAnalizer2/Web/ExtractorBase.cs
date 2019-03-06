using System;
using System.Collections.Generic;
using FinanceAnalizer2.Data;

namespace FinanceAnalizer2.Web
{
    public abstract class ExtractorBase
    {
        public abstract List<DayChangeData> ReadDaysChageData(string stockName, DateTime dateFrom, DateTime dateTo);

        /// <summary>
        /// Returns a new DateTime struct with all time properties cleared
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetDateOnly(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}