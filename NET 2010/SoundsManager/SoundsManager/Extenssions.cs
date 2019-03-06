using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundsManager
{
    public static class Extenssions
    {
		#region (------  Public Methods  ------)

        public static DateTime Time(this DateTime p_dateTime)
        {
            TimeSpan ts=new TimeSpan(p_dateTime.Date.Ticks);
            return p_dateTime.Subtract(ts);
        }

        
      

        #endregion (------  Public Methods  ------)
    }
}
