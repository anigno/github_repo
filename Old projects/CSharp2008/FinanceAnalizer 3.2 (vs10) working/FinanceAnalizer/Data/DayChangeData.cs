using System;

namespace FinanceAnalizer.Data
{
    public class DayChangeData
    {
		#region (------------------  Fields  ------------------)
        public DateTime Date;
        public float Open;
        public float High;
        public float Low;
        public float Close;
        public float Volume;
		#endregion (------------------  Fields  ------------------)

        public override string ToString()
        {
            return Date.ToShortDateString() + " " + Close;
        }
    }
}