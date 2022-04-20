using System;

namespace AnignoraFinanceAnalyzer.Data
{
    public class DayChangeDataAnalyzed : DayChangeData
    {
        #region (------------------  Fields  ------------------)
        public DateTime TimeAnalyzed { get; set; }
        public int AnalizedOne { get; set; }
        public int AnalizedTwo { get; set; }
        public float AnalyzedTwoPer { get; set; }

        public CommonParams.SignalEnum Signal { get; set; }
        public int DaysHoldingPos { get; set; }
        public int ActiveLongs { get; set; }
        public int ActiveShorts { get; set; }
        public CommonParams.SignalResultEnum SignalResult { get; set; }
        public float OpenSignalsPer { get; set; }
        public float DailyChangePer { get; set; }

        public int QuantityForPos { get; set; }


        #endregion

        #region (------------------  Constructors  ------------------)
        public DayChangeDataAnalyzed(string stockDescriptor)
            : base(stockDescriptor)
        {
        }

        public DayChangeDataAnalyzed(DayChangeData dayChange)
            : base(dayChange)
        {
        }
        #endregion

        #region (------------------  Overridden Methods  ------------------)
        public override string ToString()
        {
            return string.Format("{0} DateUpdated:{1} AnalyzeOne:{2} AnalyzeTwo:{3} AnalyzeTwoPer:{4}", base.ToString(), TimeAnalyzed.ToString(@"dd/MM/yyyy hh:mm:ss"), AnalizedOne, AnalizedTwo, AnalyzedTwoPer);
        }
        #endregion

    }
}