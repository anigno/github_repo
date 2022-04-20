using log4net.Util;
using System.Xml;

namespace Log4NetTest
{
    public static class Logger
    {
        public static log4net.ILog Log = log4net.LogManager.GetLogger(SystemInfo.ApplicationFriendlyName);
        public const string APPENDER_STRING = "%logger [#] %date% [#] %thread [#] %-5level [#] %type [#] %method [#] %message [#] %newline";
        public const string LOG_FILES_FOLDER = "_Logs";
        public const string LOG_FILE_PREFIX = "_Log";
        static Logger()
        {

            init();
            //For configuration using App.Config file
            //log4net.Config.XmlConfigurator.Configure();
        }


        static void init()
        {
            XmlDocument xmlDoc=new XmlDocument();
            XmlElement logNode=xmlDoc.CreateElement("log4net");
            string s="";
            //Appender name
            s+="<root>";
            s+="<level value=\"ALL\" />";
            s+="<appender-ref ref=\"RollingFileAppender\" />";
            s+="</root>";
            //Appender details
            s+="<appender name=\"RollingFileAppender\" type=\"log4net.Appender.RollingFileAppender\">";
            s+="<countDirection value=\"1\"/>";
            s+="<staticLogFileName value=\"false\" />";
            s+="<encoding value=\"utf-8\" />";
            s+="<file type=\"log4net.Util.PatternString\" value=\""+LOG_FILES_FOLDER+"\\"+LOG_FILE_PREFIX+".%date{yyyy-MM-dd-hh-mm-ss}\" />";
            s+="<appendToFile value=\"true\" />";
            s+="<rollingStyle value=\"Size\" />";
            s+="<maxSizeRollBackups value=\"2000\" />";
            s+="<maximumFileSize value=\"1MB\" />";
            s+="<layout type=\"log4net.Layout.PatternLayout\">";
            s+="<conversionPattern value=\""+APPENDER_STRING+"\" />";
            s+="</layout>";
            s+="</appender>";
            logNode.InnerXml = s;
            log4net.Config.XmlConfigurator.Configure(logNode);
        }



    }
}
