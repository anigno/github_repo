using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AnignoraCommonAndHelpers;
using AnignoraDataTypes;
using System.Threading;
using AnignoraProcesses;
using Anignora_LogViewer.BL.EventArgs;
using log4net;

namespace Anignora_LogViewer.BL
{
    public class LogHistoryReader:IStartable
    {
		#region (------  Fields  ------)
        public ThreadSafeProperty<string> HistoryPath = new ThreadSafeProperty<string>();
        public ThreadSafeProperty<string> HistoryPattern = new ThreadSafeProperty<string>();
        private long m_continueFlag;
        private Thread m_historyCheckThread;
        private readonly List<HistoryFileData> m_historyFiles = new List<HistoryFileData>();
        private readonly ThreadSafeProperty<int> m_threadInterval = new ThreadSafeProperty<int>(1000);
        private static readonly ILog s_logger = LogManager.GetLogger(typeof(LogHistoryReader));
		#endregion (------  Fields  ------)

		#region (------  Events  ------)
        public event EventHandler<HistoryFileEventArgs> HistoryFileRead = delegate { };

        public event EventHandler<PatternEventArgs> PatternChanged = delegate { };
		#endregion (------  Events  ------)

		#region (------  Public static Methods  ------)
        public static HistoryFileData AnalyzeLogLinesData(string[][] p_logLines,string p_filePath)
        {
            HistoryFileData historyFileData=new HistoryFileData();
            historyFileData.FilePath = p_filePath;
            historyFileData.SIndex = Path.GetExtension(p_filePath);
            if (p_logLines.Length == 0) return historyFileData;
            p_logLines.DoForAll(p_line =>
            {
                switch (p_line[1])
                {
                    case "WARN ":
                        historyFileData.Warnings++;
                        break;
                    case "ERROR":
                        historyFileData.Errors++;
                        break;
                    case "FATAL":
                        historyFileData.Fatals++;
                        break;
                }
            });
            historyFileData.SStartTime = p_logLines.First()[0];
            historyFileData.SEndTime = p_logLines.Last()[0];
            return historyFileData;
        }
		#endregion (------  Public static Methods  ------)

		#region (------  Public Methods  ------)
        public string[][] GetHistoryLogFile(string p_filePath)
        {
            StreamReader reader = LogReader.GetNewStreamReader(p_filePath);
            string readToEnd = reader.ReadToEnd();
            reader.Close();
            string[][] lines = LogReader.SplitLogFileText(readToEnd);
            return lines;
        }

        public void SetHistoryPath(string p_path,bool p_resetTable)
        {
            string filePath=LogReader.GetLastLogFile(p_path);
            string pattern = LogReader.ExtractPatternFormFilePath(filePath);
            SetHistoryPattern(p_path, pattern,p_resetTable);
            s_logger.DebugFormat("HistoryPath set {0} {1}",p_path,pattern);

        }

        public void SetHistoryPattern(string p_path, string p_pattern, bool p_forceResetTable)
        {
            if (p_pattern != HistoryPattern || p_forceResetTable)
            {
                lock (m_historyFiles)
                {
                    m_historyFiles.Clear();
                    PatternChanged(this, new PatternEventArgs {Path = p_path, Pattern = p_pattern});
                }
            }
            HistoryPath.Value = p_path;
            HistoryPattern.Value = p_pattern;
        }

        public void Start()
        {
            m_historyFiles.Clear();
            m_historyCheckThread = new Thread(historyFileCheckThreadStart);
            m_historyCheckThread.IsBackground = true;
            m_historyCheckThread.Start();
            Interlocked.Exchange(ref m_continueFlag, 1);
            s_logger.DebugFormat("Started");
        }

        public void Stop()
        {
            Interlocked.Exchange(ref m_continueFlag,0);
            s_logger.DebugFormat("Stopped");
        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        private HistoryFileData analyzeHistoryFile(string p_filePath)
        {
            string[][] lines = GetHistoryLogFile(p_filePath);
            HistoryFileData fileData = AnalyzeLogLinesData(lines, p_filePath);
            return fileData;
        }

        private void historyFileCheckThreadStart()
        {
            s_logger.DebugFormat("Thread Starting");
            while (Interlocked.Read(ref m_continueFlag) == 1)
            {
                if (HistoryPath.Value != null)
                {
                    if (Directory.Exists(HistoryPath))
                    {
                        string[] files = Directory.GetFiles(HistoryPath, HistoryPattern + ".*");
                        string[] orderedFiles = files.OrderBy(File.GetCreationTime).ToArray();
                        orderedFiles.DoForAll(p_filePath =>
                                                  {
                                                      lock (m_historyFiles)
                                                      {
                                                          bool isExist = m_historyFiles.Exists(p_fileData => p_fileData.FilePath == p_filePath);
                                                          if (!isExist)
                                                          {
                                                              HistoryFileData fileData = analyzeHistoryFile(p_filePath);
                                                              m_historyFiles.Add(fileData);
                                                              HistoryFileRead(this, new HistoryFileEventArgs {FileData = fileData});
                                                          }
                                                      }
                                                  });
                    }
                }
                Thread.Sleep(m_threadInterval);
            }
        }
		#endregion (------  Private Methods  ------)
    }
}


