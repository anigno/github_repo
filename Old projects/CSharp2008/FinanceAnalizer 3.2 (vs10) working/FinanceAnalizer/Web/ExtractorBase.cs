using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinanceAnalizer.Data;

namespace FinanceAnalizer.Web
{
    public abstract class ExtractorBase
    {


		#region (------------------  Public Methods  ------------------)
        public abstract List<DayChangeData> ExtractStockData(string stockName, DateTime fromDate, DateTime toDate);

        public abstract string DownloadHistoryCsv(string stockName, string downloadDirectory);
		#endregion (------------------  Public Methods  ------------------)
    }
}
