using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace AnignoLibrary.Helpers.Debuging
{
    public enum LogMessageSeverityEnum
    {
        Debug,
        Error,
        Warning
    }
    public class LogMessage
    {
        DateTime _time=DateTime.Now;
        private string _methodName = "";
        private LogMessageSeverityEnum _severity = LogMessageSeverityEnum.Debug;
        private string _text = "";
        private int _threadId;

        public LogMessage(LogMessageSeverityEnum severity,string format, params object[] objects)
        {
            _text = string.Format(format, objects);
            _severity = severity;
            SetVars();
        }

        public void SetVars()
        {
            StackTrace st = new StackTrace(true);
            string stackTraceString = st.ToString();
            string[] seperators={"at ","in "};
            string[] sa = stackTraceString.Split(seperators, 10, StringSplitOptions.RemoveEmptyEntries);
            _methodName = sa[7];
            int a = _methodName.LastIndexOf(".");
            if (a < 0) a = _methodName.Length;
            int b = _methodName.LastIndexOf(".", a - 1);
            if (b == a - 1) b = _methodName.LastIndexOf(".", a - 2);
            _methodName = _methodName.Substring(b);
            _threadId = Thread.CurrentThread.ManagedThreadId;
        }

        public override string ToString()
        {

            return string.Format("[{0}][{1}.{2:000}][{3}][{4}][{5}]", _threadId, _time, _time.Millisecond, _severity.ToString(), _methodName, _text);
        }
    }
}