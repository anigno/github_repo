using System;

namespace FinanceAnalyzerData.Data
{
    /// <summary>
    /// Holds data that could be calculated
    /// </summary>
    [Serializable]
    public class DayChangeDataAnalyzed: DayChangeData
    {
        #region (------------------  Enums  ------------------)
        public enum HitStateEnum
        {
            None,
            Hit,
            Miss,
        }
        public enum SignalTypeEnum
        {
            None,
            Short,
            Long
        }

        public enum SignalStateEnum
        {
            None,
            Waiting,
            Conditioned,
            Closed
        }

        public enum SignalActionEnum
        {
            None,
            Alive,
            Close
        }
        #endregion (------------------  Enums  ------------------)


        #region (------------------  Constructors  ------------------)
        public DayChangeDataAnalyzed(string stockName)
            : base(stockName)
        {
            TimeAnalyzed = CommonParams.NEVER_UPDATED_DATETIME;
        }

        public DayChangeDataAnalyzed(DayChangeData dayChange)
            : base(dayChange)
        {
            TimeAnalyzed = CommonParams.NEVER_UPDATED_DATETIME;
        }
        #endregion (------------------  Constructors  ------------------)


        #region (------------------  Properties  ------------------)
        public DateTime TimeAnalyzed { get; set; }

        public float AnalyzedTwoPer { get; set; }

        //Change for hit or miss from signaled date
        public float HitMissChangePer { get; set; }

        public float DailyChangePer { get; set; }

        //Change from signal to current date (date before hit/miss)
        public float SignalToDateChangePer { get; set; }

        public HitStateEnum Hit { get; set; }

        public int AnalizedOne { get; set; }

        public int AnalizedTwo { get; set; }

        public SignalTypeEnum SignalType { get; set; }

        public SignalTypeEnum StockActiveSignal { get; set; }

        public string fTest { get; set; }
        public int QuantityForPos { get; set; }

        public SignalStateEnum SignalState { get; set; }

        public int ClosingIndex { get; set; }

        public SignalActionEnum SignalAction { get; set; }

        //At the signal date
        public float SignalToClosePer { get; set; }

        //At the result date
        public float SignalToCloseTotalPer { get; set; }

        #endregion (------------------  Properties  ------------------)


        #region (------------------  Overridden Methods  ------------------)
        public override string ToString()
        {
            return string.Format("{0} DateUpdated:{1} AnalyzeOne:{2} AnalyzeTwo:{3} AnalyzeTwoPer:{4}", base.ToString(), TimeAnalyzed.ToString(@"dd/MM/yyyy hh:mm:ss"),AnalizedOne,AnalizedTwo,AnalyzedTwoPer);
        }
        #endregion (------------------  Overridden Methods  ------------------)
    }
}