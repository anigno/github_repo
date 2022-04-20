using System;

namespace FinanceAnalizer2.Data
{
    /// <summary>
    /// Holds data that could be extracted from data providers (e.g. Web pages, csv downloads )
    /// </summary>
    public class DayChangeData
    {
		#region (------------------  Properties  ------------------)
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
            return string.Format("Date:{0} Open:{1} Close:{2} High:{3} Low:{4} Volume:{5}", Date.ToShortDateString(), Open, Close, High, Low, Volume);
        }
		#endregion (------------------  Overridden Methods  ------------------)
    }
}