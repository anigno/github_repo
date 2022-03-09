using System;

namespace SoundsManager
{
    public class TimeInterval
    {
		#region (------  Fields  ------)

        public string DateTimeFormat;
        public DateTime TimeEnd;
        public DateTime TimeStart;

		#endregion (------  Fields  ------)

		#region (------  Public Methods  ------)

        public bool IsDateTimeWithin(DateTime p_dateTime)
        {
            return (TimeStart <= p_dateTime && p_dateTime <= TimeEnd);
        }

        public bool IsTimeOnlyWithin(DateTime p_time)
        {
            return (TimeStart.Time() <= p_time.Time() && p_time.Time() <= TimeEnd.Time());
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", TimeStart.ToString(DateTimeFormat), TimeEnd.ToString(DateTimeFormat));
        }

		#endregion (------  Public Methods  ------)
    }
}