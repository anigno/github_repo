using System;

namespace FinanceAnalyzerData.Data
{
    public class CommonParams
    {
        public static readonly DateTime MINIMUM_DATE = new DateTime(1990, 1, 1).Date;
        public static readonly DateTime NEVER_UPDATED_DATETIME = DateTime.MinValue;

    }
}