using System;

namespace FinanceAnalyzerData.Data
{
    /// <summary>
    /// Holds data that could be extracted from data providers (e.g. Web pages, csv downloads )
    /// </summary>
    [Serializable]
    public class DayChangeData
    {
        #region (------------------  Constructors  ------------------)
        public DayChangeData(string stockName)
        {
            StockDescriptor = stockName;
            Date = CommonParams.MINIMUM_DATE;
        }

        public DayChangeData(DayChangeData dayChange)
            : this(dayChange.StockDescriptor)
        {
            Date = dayChange.Date.Date;
            Open = dayChange.Open;
            High = dayChange.High;
            Low = dayChange.Low;
            Close = dayChange.Close;
            Volume = dayChange.Volume;
        }
        #endregion (------------------  Constructors  ------------------)


        #region (------------------  Properties  ------------------)
        /// <summary>
        /// Id stock used for real analysis
        /// </summary>
        public bool IsWorkingStock { get; set; }

        public DateTime Date { get; set; }

        public float Open { get; set; }

        public float High { get; set; }

        public float Low { get; set; }

        public float Close { get; set; }

        public float Volume { get; set; }

        public string StockDescriptor { get; private set; }
        #endregion (------------------  Properties  ------------------)


        #region (------------------  Static Methods  ------------------)
        public static float GetStockMultiplier(string stockDescriptor)
        {
            int a = stockDescriptor.IndexOf(" ");
            if (a < 0) return 1.0f;
            return float.Parse(stockDescriptor.Substring(a)); 
        }

        public static string GetStockName(string stockDescriptor)
        {
            int a = stockDescriptor.IndexOf(" ");
            if (a < 0) return stockDescriptor;
            return stockDescriptor.Substring(0, a);
        }
        #endregion (------------------  Static Methods  ------------------)


        #region (------------------  Overridden Methods  ------------------)
        public override string ToString()
        {
            return string.Format("StockName: {6} Date:{0} Open:{1} Close:{2} High:{3} Low:{4} Volume:{5}", Date.ToShortDateString(), Open, Close, High, Low, Volume, StockDescriptor);
        }
        #endregion (------------------  Overridden Methods  ------------------)
    }
}