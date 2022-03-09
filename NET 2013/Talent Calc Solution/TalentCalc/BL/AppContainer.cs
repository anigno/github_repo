using System;
using AnignoraDataTypes.Configurations;
using log4net;
using TalentCalc.Configuration;
using TalentCalc.Data;

namespace TalentCalc.BL
{
    public class AppContainer
    {
        #region Public Methods

        public void Init()
        {
            s_logger.Info("Initialized");
            SystemCounters = new SystemCounters();
            m_configurator = new ConfiguratorXml<MainConfiguration>(@"MainConfiguration.XML");
            m_configurator.Load();
            MainConfig = m_configurator.Configuration;
            MainManager = new MainManager(MainConfig);
            //MainManager.Start();
        }

        #endregion

        #region Public Properties

        public static AppContainer Instance
        {
            get { return s_instance ?? (s_instance = new AppContainer()); }
        }

        public SystemCounters SystemCounters { get; set; }
        public MainConfiguration MainConfig { get; private set; }
        public MainManager MainManager { get; private set; }
        public RawDataProvider RawDataProvider { get; set; }

        #endregion

        #region Fields

        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static AppContainer s_instance;
        private ConfiguratorXml<MainConfiguration> m_configurator;

        #endregion
    }
}