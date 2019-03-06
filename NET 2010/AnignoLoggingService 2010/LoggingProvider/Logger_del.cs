using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Timers;

namespace LoggingProvider
{
    public static class Logger_del
    {

		#region (------  Static Fields  ------)

        private static bool _isWriteToLogActive = true;
        private static DateTime _logCreationTime = DateTime.Now;
        private static int _messageNumber = 1;
        private static int _pageNumber = 1;
        private static readonly Queue<LogMessage> _sendQueue = new Queue<LogMessage>(MAX_MESSEGES_PER_PAGE);
        private static readonly System.Timers.Timer _SendTimer;
        private static readonly object _syncObject = new object();
        public static readonly int MAX_MESSEGES_PER_PAGE = 1000;
        private static readonly string[] METHOD_SPLIT_STRING_ARRAY = { "." };
        private static readonly string[] STACK_SPLIT_STRING_ARRAY = { " at " };

		#endregion (------  Static Fields  ------)

		#region (------  Static Constructor  ------)

        static Logger_del()
        {
            lock (_syncObject)
            {
                
                if (!Directory.Exists(Environment.CurrentDirectory + @"\Log")) Directory.CreateDirectory(Environment.CurrentDirectory + @"\Log");
                _SendTimer = new System.Timers.Timer(Common.DEFAULT_LOG_VIEWER_TIMER_INTERVAL);
                _SendTimer.Elapsed += _SendQueueTimer_Elapsed;
                _SendTimer.Start();
            }
        }

		#endregion (------  Static Constructor  ------)

		#region (------  Event Handlers  ------)

        private static void _SendQueueTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _SendTimer.Stop();
            lock (_syncObject)
            {
                //Write queued messeges to log file
                lock (_syncObject)
                {
                    try
                    {
                        if (_sendQueue.Count > 0)
                        {
                            //possible fail in next statment
                            TextWriter tw = new StreamWriter(GetCurrentLogFileName(), true, Encoding.GetEncoding("windows-1255"));
                            while (_sendQueue.Count > 0)
                            {
                                LogMessage message = _sendQueue.Dequeue();
                                tw.WriteLine(message);
                                _messageNumber++;
                                if (_messageNumber > MAX_MESSEGES_PER_PAGE) break;
                            }
                            if (_messageNumber > MAX_MESSEGES_PER_PAGE)
                            {
                                //TODO: managed a file with closed paged data
                                _messageNumber = 1;
                                _pageNumber++;  //will be used in GetCurrentLogFileName() next call
                            }
                            tw.Close();
                        }
                    }
                    catch (IOException ex)
                    {
                        //Couldn't open the log file for writing, possible cause is that the LogViewer is currently reading the file.
                        Thread.Sleep(Common.DEFAULT_LOG_VIEWER_TIMER_INTERVAL / 3);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            _SendTimer.Start();
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Static Methods  ------)

        public static void Activate()
        {
            lock (_syncObject)
            {
                _isWriteToLogActive = true;
            }
        }

        private static void AddLogMessage(SeverityEnum severity, string format, params object[] objects)
        {
            lock (_syncObject)
            {
                LogMessage message = new LogMessage();
                try
                {
                    if (_isWriteToLogActive)
                    {
                        message.Severity = severity;
                        message.Time = DateTime.Now;
                        string stackTraceString = new StackTrace().ToString();
                        SetMethodData(stackTraceString, out message.AssemblyName, out message.ClassName, out message.MethodName);
                        try
                        {
                            message.Text = string.Format(format, objects);
                            message.Text = message.Text.Replace('\n', ' ');
                        }
                        catch (Exception ex)
                        {
                            message.Text = format + " " + ex.Message;
                        }
                        message.ThreadId = Thread.CurrentThread.Name;
                        if (message.ThreadId == null) message.ThreadId = Thread.CurrentThread.ManagedThreadId.ToString();
                        _sendQueue.Enqueue(message);
                    }
                }
                catch (Exception ex)
                {
                    message.Text += "!!! Error occured when creating message !!! "+ex.Message;
                    _sendQueue.Enqueue(message);
                }
            }
        }

        public static void Deactivate()
        {
            lock (_syncObject)
            {
                _isWriteToLogActive = false;
            }
        }

        private static string GetCurrentLogFileName()
        {
            return string.Format(@"Log\Log-{0:d4}-{1:d2}-{2:d2}-{3:d2}-{4:d2}-{5:d2}-{6:d3}-{7:d4}.txt",
                _logCreationTime.Year,
                _logCreationTime.Month,
                _logCreationTime.Day,
                _logCreationTime.Hour,
                _logCreationTime.Minute,
                _logCreationTime.Second,
                _logCreationTime.Millisecond,
                _pageNumber
                );
        }

        public static void LogUIAction(string format, params object[] objects)
        {
            AddLogMessage(SeverityEnum.DEBUG, "UI Action: " + format, objects);
        }

        public static void Log(SeverityEnum severity, string format, params object[] objects)
        {
            AddLogMessage(severity, format, objects);
        }

        public static void Log()
        {
            AddLogMessage(SeverityEnum.DEBUG, "");
        }

        public static void LogDebug(string format, params object[] objects)
        {
            AddLogMessage(SeverityEnum.DEBUG, format, objects);
        }

        public static void LogError(Exception ex)
        {
            AddLogMessage(SeverityEnum.ERROR, ex.Message);
        }

        public static void LogError(string format, params object[] objects)
        {
            AddLogMessage(SeverityEnum.ERROR, format, objects);
        }

        public static void LogError(Exception ex,string format, params object[] objects)
        {
            AddLogMessage(SeverityEnum.ERROR, format+"   ["+ex.Message+"]", objects);
        }

        public static void LogInfo(string format, params object[] objects)
        {
            AddLogMessage(SeverityEnum.INFO, format, objects);
        }

        public static void LogWarning(string format, params object[] objects)
        {
            AddLogMessage(SeverityEnum.WARN, format, objects);
        }

        private static void SetMethodData(string stackTraceString, out string assemblyName, out string className, out string methodName)
        {
            try
            {
                string[] sa = stackTraceString.Split(STACK_SPLIT_STRING_ARRAY, 5, StringSplitOptions.RemoveEmptyEntries);
                string methodLine = sa[3].Trim();
                string[] methodSa = methodLine.Split(METHOD_SPLIT_STRING_ARRAY, 30, StringSplitOptions.RemoveEmptyEntries);
                assemblyName = methodSa[methodSa.Length - 3];
                className = methodSa[methodSa.Length - 2];
                methodName = methodSa[methodSa.Length - 1];
            }
            catch (Exception ex)
            {
                assemblyName = className = methodName = "Error! "+ ex.Message;
            }
        }

		#endregion (------  Static Methods  ------)

    }
}