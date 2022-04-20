using System;

namespace AnignoraFinanceAnalyzer.Data
{
    /// <summary>
    /// Holds data that could be extracted from data providers (e.g. Web pages, csv downloads )
    /// </summary>
    [Serializable]
    public class DayChangeData
    {
        #region (------------------  Constructors  ------------------)
        public DayChangeData(string stockDescriptor)
        {
            StockDescriptor = stockDescriptor;
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
        
        public string StockDescriptor { get; private set; }

        public DateTime Date { get; set; }

        public float Open { get; set; }

        public float High { get; set; }

        public float Low { get; set; }

        public float Close { get; set; }

        public float Volume { get; set; }

        #endregion (------------------  Properties  ------------------)


        #region (------------------  Overridden Methods  ------------------)
        public override string ToString()
        {
            return string.Format("StockName: {6} Date:{0} Open:{1} Close:{2} High:{3} Low:{4} Volume:{5}", Date.ToShortDateString(), Open, Close, High, Low, Volume, StockDescriptor);
        }
        #endregion (------------------  Overridden Methods  ------------------)
    }
}