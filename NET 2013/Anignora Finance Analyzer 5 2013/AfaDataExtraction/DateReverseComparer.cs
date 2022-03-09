using System;
using System.Collections.Generic;

namespace AfaDataExtraction
{
    public class DateReverseComparer : IComparer<DateTime>
    {
        public int Compare(DateTime p_date1, DateTime p_date2)
        {
            if (p_date1.Date == p_date2.Date) return 0;
            return (p_date1 < p_date2) ? 1 : -1;
        }
    }
}
