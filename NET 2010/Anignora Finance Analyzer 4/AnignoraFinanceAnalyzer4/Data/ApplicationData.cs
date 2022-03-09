using System;

namespace AnignoraFinanceAnalyzer4.Data
{
    public enum ExtractingOrderEnum
    {
        GoogleOnly,
        GoogleYahoo,
        YahooOnly,
        YahooGoogle
    }

    public class ApplicationData
    {
        internal const string APPLICATION_NAME = "Anignora Finance Analyzer";
        //Calculation
        public float ProfitCut { get; set; }            //Profit cut if no doubler currently exists for position
        public float ProfitCutDoubler { get; set; }     //Profit cut when using doubler
        public float LossCut { get; set; }
        public int MaxDaysHoldingPosition { get; set; }
        public bool UseDoubler { get; set; }            //Should calculation use doubler when SignalToDate change<DoublerStart
        public float DoublerMultiplier { get; set; }    //Multiplier is doubler exists
        public float RegularMultiplier { get; set; }    //Multiplier is doubler doesn't exist
        public float DoublerStart { get; set; }         //When doubler is opened (e.g. -4.0)
        public int MinDaysBetweenPosition { get; set; }
        public float PositiveParam { get; set; }
        public float NegativeParam { get; set; }
        public int FormulaOneParam { get; set; }
        public int SmallAverage { get; set; }
        public int LargeAverage { get; set; }
        public int OtherAvg { get; set; }
        public int mfiA { get; set; }
        public int mfiB { get; set; }
        public float mfiALow { get; set; }
        public float mfiAHigh { get; set; }
        public bool UseMfi { get; set; }

        //Email
        public string SenderEmail { get; set; }
        public string SenderEmailPassword { get; set; }
        public string[] ReceiversEmailList { get; set; }
        public bool IsSendEmails { get; set; }
        public int DailySendHour { get; set; }
        public int DailySendMinute { get; set; }
        public DateTime UpdatedLastSentDate { get; set; }
        public string Username { get; set; }
        //Traders
        public int TradeSum { get; set; }
        public int TradeDevider { get; set; }
        //Browsers
        public string BrowserA { get; set; }
        public string BrowserB { get; set; }
        public string BrowserC { get; set; }
        //Extractors
        public ExtractingOrderEnum ExtractionOrder { get; set; }
        public int MaxExtractionThreads { get; set; }
        //FTP
        public bool FtpUpdate { get; set; }
        public string FtpServerName { get; set; }
        public string FtpUsername { get; set; }
        public string FtpPassword { get; set; }
        public int FtpUpdateIntervalSec { get; set; }
    }
}
