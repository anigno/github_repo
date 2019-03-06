using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggingProvider
{
    public enum FilterTypeEnum
    {
        Text,
        Class,
        Method,
        Thread,
        Assembly
    }

    public class Common
    {
        public static readonly string CONFIG_FILE_NAME_POSTFIX = "\\Config\\LogViewer.config";
        public static readonly int DEFAULT_LOG_VIEWER_TIMER_INTERVAL = 1000;
        public static string GetdateTimeString(DateTime time)
        {
            return string.Format(
                "{0:d4}/{1:d2}/{2:d2} {3:d2}:{4:d2}:{5:d2}.{6:d3}",
                time.Year,
                time.Month,
                time.Day,
                time.Hour,
                time.Minute,
                time.Second,
                time.Millisecond);
        }
    }

}