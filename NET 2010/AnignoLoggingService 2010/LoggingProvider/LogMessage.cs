using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggingProvider
{
    public enum SeverityEnum
    {
        DEBUG,
        INFO,
        WARN,
        ERROR,
        FATAL
    }

    [Serializable]
    public class LogMessage
    {
        private const string DEVIDER = "[#]";
        public static readonly string[] _logMessageSplitters = { DEVIDER };
        public DateTime Time = DateTime.Now;
        public SeverityEnum Severity = SeverityEnum.DEBUG;
        public string AssemblyName = string.Empty;
        public string ClassName = string.Empty;
        public string MethodName = string.Empty;
        public string Text = string.Empty;
        public string ThreadId = string.Empty;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Time.ToString());
            sb.Append(DEVIDER);
            sb.Append(Time.Millisecond.ToString());
            sb.Append(DEVIDER);
            sb.Append(Severity.ToString());
            sb.Append(DEVIDER);
            sb.Append(AssemblyName);
            sb.Append(DEVIDER);
            sb.Append(ClassName);
            sb.Append(DEVIDER);
            sb.Append(MethodName);
            sb.Append(DEVIDER);
            sb.Append(Text);
            sb.Append(DEVIDER);
            sb.Append(ThreadId);
            return sb.ToString();
        }

        public static LogMessage FromString(string logMessageString)
        {
            LogMessage message = new LogMessage();
            try
            {
                string[] sa = logMessageString.Split(_logMessageSplitters, StringSplitOptions.None);
                message.Time = DateTime.Parse(sa[0]);
                //TimeSpan milliseconds = TimeSpan.FromMilliseconds(int.Parse(sa[1]));
                //message.Time = message.Time.Add(milliseconds);
                message.Severity = (SeverityEnum)Enum.Parse(typeof(SeverityEnum), sa[1]);
                message.AssemblyName = sa[2];
                message.ClassName = sa[3];
                message.MethodName = sa[4];
                message.Text = sa[5];// +"RawData:[" + logMessageString + "]";
                message.ThreadId = sa[6];
            }
            catch (Exception ex)
            {
                message.Text += ex.Message + " "  + logMessageString;
                message.Severity = SeverityEnum.ERROR;
                message.ClassName = "LogMessage";
            }
            return message;
        }
    }
}