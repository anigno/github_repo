using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLibrary.Helpers
{
    public class StringHelper
    {
        public static string GetDateString(DateTime date)
        {
            return string.Format("{0}/{1}/{2}", date.Day, date.Month, date.Year);
        }

        public static DateTime GetDateFromString(string dateString)
        {
            string[] splitter = new string[] { "/" };
            string[] parts = dateString.Split(splitter, 3, StringSplitOptions.RemoveEmptyEntries);
            int day = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int year = int.Parse(parts[2]);
            return new DateTime(year, month, day);
        }
    }
}
