using System;

namespace TalentCalc.Data
{
    public class RawData
    {
        #region Constructors

        public RawData(DateTime p_date)
        {
            Date = p_date;
        }

        public RawData(DateTime p_date, double p_close, double p_open, double p_high, double p_low, double p_volume)
        {
            Date = p_date;
            Close = p_close;
            Open = p_open;
            High = p_high;
            Low = p_low;
            Volume = p_volume;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("O={0:0.000} C={1:0.000} H={2:0.000} L={3:0.000} V={4:0.000} [{5}]", Open, Close, High, Low, Volume, Date.ToShortDateString());
        }

        #endregion

        #region Public Properties

        public DateTime Date { get; set; }
        public double Close { get; set; }
        public double Change { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Volume { get; set; }
        public double Money { get; set; }

        #endregion
    }
}