using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using AnignoraCommonAndHelpers;
using AnignoraCommonAndHelpers.Tracers;
using AnignoraProcesses;
using Anignora_LogViewer.BL.EventArgs;
using log4net;

namespace Anignora_LogViewer.BL
{

    public class LogReader : IStartable
    {
		#region (------  Fields  ------)
        private long m_continueFlag;
        private readonly ThreadSafeProperty<string> m_currentPath = new ThreadSafeProperty<string>();
        private readonly ThreadSafeProperty<OperationalModeEnum> m_operationalMode = new ThreadSafeProperty<OperationalModeEnum>(OperationalModeEnum.PassiveMode);
        private Thread m_readerThread;
        private readonly ThreadSafeProperty<int> m_readIntervalMs = new ThreadSafeProperty<int>(s_defaultInterval);
        private readonly ITracer m_tracer;
        public static readonly int s_defaultInterval = 3000;
        private static readonly string[] s_logColumnSplitter = new[] {"[#]"};
        private static readonly ILog s_logger = LogManager.GetLogger(typeof(LogHistoryReader));
        private static readonly string[] s_logLineSplitter = new[] {s_logColumnSplitter[0] + Environment.NewLine};
		#endregion (------  Fields  ------)

		#region (------  Events  ------)
        public event EventHandler<LogFileChangedEventArgs> LogFileChanged = delegate { };

        public event EventHandler<LogLinesChangesEventArgs> LogLinesRead = delegate { };
		#endregion (------  Events  ------)

		#region (------  Constructors  ------)
        public LogReader(ITracer p_tracer)
        {
            m_tracer = p_tracer;
        }
		#endregion (------  Constructors  ------)

		#region (------  Public static Methods  ------)
        public static string ExtractPatternFormFilePath(string p_filePath)
        {
            string pattern = Path.GetFileNameWithoutExtension(p_filePath);
            return pattern;
        }

        public static string GetLastLogFile(string p_path)
        {
            if (!Directory.Exists(p_path))
            {
                return null;
            }
            string filename = Directory.GetFiles(p_path).OrderBy(File.GetCreationTime).LastOrDefault();
            return filename;
        }

        public static StreamReader GetNewStreamReader(string p_filename)
        {
            if (p_filename == null) return null;
            FileStream fileStream = new FileStream(p_filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream);
            return streamReader;
        }

        public static string[][] SplitLogFileText(string p_logString)
        {
            List<string[]> linesList = new List<string[]>();
            string[] lines = p_logString.Split(s_logLineSplitter, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] columns = line.Split(s_logColumnSplitter, StringSplitOptions.RemoveEmptyEntries);
                string[] columnsNew = new string[8];
                columnsNew[0] = columns[0];
                columnsNew[1] = columns[1];
                columnsNew[2] = columns[2];
                columnsNew[3] = columns[3];
                columnsNew[4] = columns[4];
                if (columns.Length > 5) columnsNew[5] = columns[5];
                if (columns.Length > 6) columnsNew[6] = columns[6];
                columnsNew[7] = ""; //Will be filled with line number by UI
                linesList.Add(columnsNew);
            }
            return linesList.ToArray();
        }

        #endregion (------  Public static Methods  ------)

		#region (------  Public Methods  ------)
        public void SetLogFilesPath(string p_path)
        {
            m_currentPath.Value = p_path;
        }

        public void SetMode(OperationalModeEnum p_operationalMode)
        {
            s_logger.DebugFormat("mode: {0}", p_operationalMode);
            m_operationalMode.Value = p_operationalMode;
        }

        public void SetReadInterval(int p_intervalMs)
        {
            s_logger.DebugFormat("interval: {0}", p_intervalMs);
            m_readIntervalMs.Value = p_intervalMs;
        }

        public void Start()
        {
            s_logger.DebugFormat("Starting");
            m_readerThread = new Thread(readerThreadStart);
            m_readerThread.IsBackground = true;
            Interlocked.Exchange(ref m_continueFlag, 1);
            m_readerThread.Start();
        }

        public void Stop()
        {
            Interlocked.Exchange(ref m_continueFlag, 0);
            s_logger.DebugFormat("Stopped");
        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        private void readerThreadStart()
        {
            m_tracer.Trace("readerThreadStart started");
            StreamReader streamReader = null;
            string currentFilename = null;
            string filename = null;
            while (Interlocked.Read(ref m_continueFlag) == 1)
            {
                if (filename == null)
                {
                    //Filename is null
                    filename = GetLastLogFile(m_currentPath);
                    m_tracer.Trace("got LastLogFile={0}",filename);
                }
                else
                {
                    if (filename != currentFilename)
                    {
                        if (streamReader != null) streamReader.Close();
                        streamReader = GetNewStreamReader(filename);
                        currentFilename = filename;
                        m_tracer.Trace("new current filename={0}", filename);
                        LogFileChanged(this, new LogFileChangedEventArgs {LogFilename = currentFilename});
                    }
                    string readToEnd = streamReader.ReadToEnd();
                    string[][] logLines = SplitLogFileText(readToEnd);
                    m_tracer.Trace("lines read={0}", logLines.Length);
                    LogLinesRead(this, new LogLinesChangesEventArgs { Filename = currentFilename, LogLines = logLines });
                    if (logLines.Length == 0)
                    {
                        filename = GetLastLogFile(m_currentPath);
                        m_tracer.Trace("no lines read, new lastfile={0}", filename);
                    }
                }
                Thread.Sleep(m_readIntervalMs);
            }
        }
		#endregion (------  Private Methods  ------)
    }
}