using System;

namespace AfaDataExtraction
{
    public static class ExtractionCommon
    {
        //public static readonly DateTime s_dateTimeNone = new DateTime(1901, 1, 1);
        public static readonly DateTime DATE_MINIMUM = new DateTime(2001, 1, 1).Date;
        public const string HISTORY_DATA_DIR = "HistoryData";
        public const string VOLATILITY_HISTORY_DATA_DIR = @"HistoryData\SymbolsHistory\VolatilityHistory";

    }
}
