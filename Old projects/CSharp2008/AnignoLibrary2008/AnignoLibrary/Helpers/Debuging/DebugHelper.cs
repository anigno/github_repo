using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AnignoLibrary.Helpers.Debuging
{
    public class DebugHelper
    {
        private static object _fileSync = new object();
        public static void DebugConsole(bool showDebug, string format, params object[] objects)
        {
            if (showDebug)
            {
                LogMessage message = new LogMessage(LogMessageSeverityEnum.Debug, format, objects);
                Console.WriteLine(message);
            }
        }

        public static void DebugConsole(bool showDebug)
        {
            DebugConsole(showDebug, "");
        }

        public static void DebugToFile(bool showDebug, string format, params object[] objects)
        {
            if (showDebug)
            {
                LogMessage message = new LogMessage(LogMessageSeverityEnum.Debug, format, objects);
                AppendToFile(message);
            }
        }

        public static void DebugToFile(bool showDebug)
        {
            DebugToFile(showDebug, "");
        }

        private static void AppendToFile(LogMessage message)
        {
            lock (_fileSync)
            {
                TextWriter tw = new StreamWriter("log.txt", true);
                tw.WriteLine(message);
                tw.Close();
            }
            
            
        }

    }
}