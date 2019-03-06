using System.Collections.Generic;
using AnignoraDataTypes;

namespace Anignora_LogViewer.BL.Filtering
{
    public class FilterData
    {
		#region (------  Constructors  ------)
        public FilterData()
        {
            LoggerText = "";
            TypeText = "";
            MethodText = "";
            MessageText = "";
            ThreadText = "";

            Debug = true;
            Info = true;
            Warn = true;
            Error = true;
            Fatal = true;
        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public bool Debug { get; set; }

        public bool Error { get; set; }

        public bool Fatal { get; set; }

        public string FilterName { get; set; }

        public bool FilterNegative { get; set; }

        public bool Info { get; set; }

        public bool IsEnabled { get; set; }

        public bool LoggerNegative { get; set; }

        public string LoggerText { get; set; }

        public bool MessageNegative { get; set; }

        public string MessageText { get; set; }

        public bool MethodNegative { get; set; }

        public string MethodText { get; set; }

        public bool ThreadNegative { get; set; }

        public string ThreadText { get; set; }

        public bool TypeNegative { get; set; }

        public string TypeText { get; set; }

        public bool Warn { get; set; }
		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)
        /// <summary>
        /// Filter log lines, returning only filtered in log lines
        /// </summary>
        /// <param name="p_logLines"></param>
        /// <returns></returns>
        public string[][] FilterOutLogLines(string[][] p_logLines)
        {
            List<string[]> filteredlnLogLines = new List<string[]>();
            lock (p_logLines)
            {
                p_logLines.DoForAll(p_logLine =>
                                        {
                                            bool filterResult = IsFilteredln(p_logLine);
                                            if (filterResult)
                                                filteredlnLogLines.Add(p_logLine);
                                        });
            }
            return filteredlnLogLines.ToArray();
        }

        public bool IsFilteredln(string[] p_logLine)
        {
            for (int a = 0; a < p_logLine.Length; a++)
            {
                if (p_logLine[a] == null) p_logLine[a] = "!!NULL!!";
            }
            string logLineLevel = p_logLine[1];
            string logLineLogger = p_logLine[2];
            string logLineType = p_logLine[3];
            string logLineMethod = p_logLine[4];
            string logLineMessage = p_logLine[5];
            string logLineThread = p_logLine[6];
            
            bool bLevel = filterInLevel(logLineLevel);
            bool bLogger = logLineLogger.ToLower().Contains(LoggerText.ToLower())^ LoggerNegative;
            bool bType = logLineType.ToLower().Contains(TypeText.ToLower())^TypeNegative;
            bool bMethod = logLineMethod.ToLower().Contains(MethodText.ToLower())^MethodNegative;
            bool bMessage = logLineMessage.ToLower().Contains(MessageText.ToLower())^MessageNegative;
            bool bThread = logLineThread.ToLower().Contains(ThreadText.ToLower())^ ThreadNegative;
            bool filterResult = (bLevel && bLogger && bType && bMethod && bMessage && bThread)^ FilterNegative;
            return filterResult;
        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        private bool filterInLevel(string p_level)
        {
            if (Debug && p_level == Common.DEBUG_STRING) return true;
            if (Info && p_level == Common.INFO_STRING) return true;
            if (Warn && p_level == Common.WARN_STRING) return true;
            if (Error && p_level == Common.ERROR_STRING) return true;
            if (Fatal && p_level == Common.FATAL_STRING) return true;
            return false;
        }
		#endregion (------  Private Methods  ------)
    }
}
