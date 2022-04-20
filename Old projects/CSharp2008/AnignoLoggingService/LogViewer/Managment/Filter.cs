using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using LoggingProvider;

namespace LogViewer.Managment
{
    public class Filter
    {
        public FilterTypeEnum FilterType = FilterTypeEnum.Text;
        public string FilterWildCard = string.Empty;
        public bool Active = false;

        private Regex _regex = null;

        public bool FilteredIn(string s)
        {
            if (_regex == null)
            {
                string regexPattern = FilterWildCard.Replace("*", ".*");
                _regex = new Regex(regexPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            }
            return _regex.IsMatch(s);
        }
    }
}
