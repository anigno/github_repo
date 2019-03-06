using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer.Managment
{
    [Serializable]
    public class LogViewerConfig
    {
        public List<string> ApplicationLogPath = new List<string>();
        public List<Filter> Filters = new List<Filter>();

        public LogViewerConfig()
        {
        }
    }
}
