using System;
using System.Collections.Generic;
using FinanceAnalyzerData.Data;

namespace FinanceAnalizer3.Web
{
    public abstract class ExtractorBase
    {
        protected readonly object _syncRoot = new object();
        public abstract DayChangeData[] ReadDaysChangeData(string stockName, DateTime dateFrom, DateTime dateTo);
    }
}