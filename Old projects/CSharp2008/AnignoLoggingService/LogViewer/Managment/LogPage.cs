using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoggingProvider;
using System.IO;
using System.Threading;

namespace LogViewer.Managment
{
    public class LogPage
    {
        private string _logFilePath = string.Empty;
        private long _lastFileLength = 0;
        private int _linesRead = 0;
        private int _errorsCount = 0;
        private int _warningCount = 0;
        private DateTime _startTime;
        private DateTime _endTime;
        private List<LogMessage> _logMessages = new List<LogMessage>();

        public LogMessage[] CurrentLogMessages
        {
            get { return _logMessages.ToArray(); }
        }

        public int WarningCount
        {
            get { return _warningCount; }
        }

        public int ErrorsCount
        {
            get { return _errorsCount; }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
        }

        public DateTime EndTime
        {
            get { return _endTime; }
        }

        public LogPage(string logFilePath)
        {
            _logFilePath = logFilePath;
            LogMessage[] newMessages = GetNewLogMessages();
        }

        internal LogMessage[] GetNewLogMessages()
        {
            List<LogMessage> newMessages = new List<LogMessage>();
            //If file hasn't changed since last read return
            FileInfo fi = new FileInfo(_logFilePath);
            if (fi.Length == _lastFileLength) return newMessages.ToArray();
            //tries to read from the log file
            try
            {
                using (TextReader tr = new StreamReader(_logFilePath))
                {
                    int lineNumber = 0;
                    while (tr.Peek() >= 0)
                    {
                        string logLine = tr.ReadLine();
                        lineNumber++;
                        if (lineNumber > _linesRead)
                        {
                            LogMessage newMessage = LogMessage.FromString(logLine);
                            if (lineNumber == 1) _startTime = newMessage.Time;
                            //newMessage.Number = lineNumber;
                            newMessages.Add(newMessage);
                            _logMessages.Add(newMessage);
                            if (newMessage.Severity == SeverityEnum.Error) _errorsCount++;
                            if (newMessage.Severity == SeverityEnum.Warning) _errorsCount++;
                            _endTime = newMessage.Time;
                        }
                    }
                    _linesRead = lineNumber;
                    _lastFileLength = fi.Length;
                }
                return newMessages.ToArray();
            }
            catch
            {
                //possible file is open for writing at the provider,
                Thread.Sleep(Common.DEFAULT_LOG_VIEWER_TIMER_INTERVAL / 2);
                return newMessages.ToArray();
            }
        }
    }
}