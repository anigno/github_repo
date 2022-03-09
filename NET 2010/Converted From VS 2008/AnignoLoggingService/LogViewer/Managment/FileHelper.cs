using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace LogViewer.Managment
{
    public class FileHelper
    {

		#region (------  Static Fields  ------)

        private static readonly string FIRST_LOG_FILES_PREFIX = "*0001.log";

		#endregion (------  Static Fields  ------)

		#region (------  Static Methods  ------)

        public static string GetLastPageFile(string logPath,string logPrefix)
        {
            string[] filesWithPrefix = Directory.GetFiles(logPath, logPrefix + "*");
            if (filesWithPrefix.Length == 0) return null;
            return filesWithPrefix[filesWithPrefix.Length - 1];
        }

        public static string GetNewestFirstPage(string logPath)
        {
            if(!Directory.Exists(logPath))return null;
            string[] firstLogFiles = Directory.GetFiles(logPath, FIRST_LOG_FILES_PREFIX);
            if (firstLogFiles.Length == 0) return null;
            return firstLogFiles[firstLogFiles.Length - 1];
        }

        public static string GetPrefix(string logFileName)
        {
            int a = logFileName.LastIndexOf(".");
            int b = logFileName.LastIndexOf("-", a - 1);
            return logFileName.Substring(0, b + 1);
        }

        public static LogViewerConfig LoadConfig(string  configFileName)
        {
            LogViewerConfig retConfig = null;
            if (!File.Exists(configFileName))
            {
                retConfig = new LogViewerConfig();
                return retConfig;
            }
            XmlSerializer xs = new XmlSerializer(typeof(LogViewerConfig));
            FileStream fs = new FileStream(configFileName, FileMode.Open);
            retConfig = (LogViewerConfig)xs.Deserialize(fs);
            fs.Close();
            return retConfig;
        }

        public static void SaveConfig(string  configFileName, LogViewerConfig config)
        {
            XmlSerializer xs = new XmlSerializer(typeof(LogViewerConfig));
            if (!Directory.Exists(Path.GetDirectoryName(configFileName))) Directory.CreateDirectory(Path.GetDirectoryName(configFileName));
            FileStream fs = new FileStream(configFileName, FileMode.Create);
            xs.Serialize(fs, config);
            fs.Close();
        }

		#endregion (------  Static Methods  ------)

    }
}
