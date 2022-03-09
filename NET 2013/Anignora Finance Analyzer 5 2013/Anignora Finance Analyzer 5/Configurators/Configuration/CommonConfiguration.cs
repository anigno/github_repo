using AfaDataExtraction;
using AnignoraDataTypes.Configurations;

namespace AnignoraFinanceAnalyzer5.Configurators.Configuration
{
    public class CommonConfiguration : IConfiguration
    {
        #region Public Methods

        public void SetDefaults()
        {
            EmailSender = "anignorafinanceanalyzer@gmail.com";
            EmailSenderPassword = "anignora";
            ExtractionOrder = ExtractionManager.ExtractingOrderEnum.ExtractorFromMsnGoogleYahoo;
            MaxExtractionThreads = 4;
            ExtractorsDelayMs = 15*1000;
            ExtractedDataResetMinutes = 60*12;
            ExtractionRtStartHour = 8;
            FtpServer = "184.168.152.47";
            FtpUserName = "anignora";
            FtpPassword = "Aa!12345";
            //FtpBaseDirectoryLimited = "AFA5";
            WebsiteFtpIntervalMs = 61000;
            //WebsiteFtpIntervalMs = 61000;
            UseFtpWebUpdater = true;

            FtpBaseDirectoryUnLimited = "AFA5_raluger";
            FtpBaseDirectoryOptions = "AFA5_snoitpo";
            //WebSiteNoUpdateStartTime = "16:33";
            //WebSiteNoUpdateEndTime = "22:58";

            ReportsPath = "_Reports";
            ContangoManagerAverageCount = 5;
            ContangoManagerUpdateIntervalSec = 90;
        }

        #endregion

        #region Public Properties

        public string EmailSender { get; set; }
        public string EmailSenderPassword { get; set; }
        public ExtractionManager.ExtractingOrderEnum ExtractionOrder { get; set; }
        public uint MaxExtractionThreads { get; set; }
        public int ExtractorsDelayMs { get; set; }
        public int ExtractedDataResetMinutes { get; set; }

        public string FtpServer { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
        public bool UseFtpWebUpdater { get; set; }
        public int WebsiteFtpIntervalMs { get; set; }
        public string FtpBaseDirectoryUnLimited { get; set; }
        public string FtpBaseDirectoryOptions { get; set; }

        //public string FtpBaseDirectoryLimited { get; set; }
        //public string WebSiteNoUpdateStartTime { get; set; }
        //public string WebSiteNoUpdateEndTime { get; set; }

        public string[] SymbolsMetaData { get; set; }
        public string ReportsPath { get; set; }
        public int ContangoManagerAverageCount { get; set; }
        public int ContangoManagerUpdateIntervalSec { get; set; }

        public int ExtractionRtStartHour { get; set; }

        #endregion
    }
}