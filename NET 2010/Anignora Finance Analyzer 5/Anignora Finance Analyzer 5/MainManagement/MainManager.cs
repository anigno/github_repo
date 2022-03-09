using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AfaDataExtraction;
using AnignoraCommunication.Email;
using AnignoraFinanceAnalyzer5.Configurators;
using AnignoraFinanceAnalyzer5.Configurators.Configuration;
using AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstConfigurations;
using AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew;
using AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstOptions;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using AnignoraFinanceAnalyzer5.Systems.SystemOptions;
using AnignoraFinanceAnalyzer5.Systems.SystemsExtended;
using log4net;

namespace AnignoraFinanceAnalyzer5.MainManagement
{
    public class MainManager
    {
        #region (------  Fields  ------)
        private AfaWebSiteUpdater m_afaWebSiteUpdaterAll;
        //private AfaWebSiteUpdater m_afaWebSiteUpdaterLimited;
        private CommonConfigurator m_commonConfigurator;
        private ContangoManager m_contangoManager;
        private readonly EmailSendingService m_emailSendingService = new EmailSendingService();
        private ExtractionManager m_extractionManager;
        private ReportsCreator m_reportsCreator;
        private readonly System.Threading.Timer m_securityTimer;
        private readonly SmtpClientByGmail m_smtpClientSecurityEMail = new SmtpClientByGmail(@"anignora.sec@gmail.com", @"anignora", 30);
        private readonly List<AfaSystemBase> m_systems = new List<AfaSystemBase>();
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion (------  Fields  ------)

        #region (------  Delegates  ------)
        public delegate void SymbolCalculatedDelegate(string p_symbolWebName, FirstCalculatorResult[] p_calculatedData, bool p_succeeded);
        public delegate void SystemAddedDelegate(AfaSystemBase p_system);
        #endregion (------  Delegates  ------)

        #region (------  Events  ------)
        public event SymbolCalculatedDelegate SymbolCalculated = delegate { };

        public event SystemAddedDelegate SystemAdded = delegate { };
        #endregion (------  Events  ------)

        #region (------  Constructors  ------)
        public MainManager(string p_username, int p_key)
        {
            Username = p_username;
            Key = p_key;
            m_securityTimer = new System.Threading.Timer(securityFunction, null, 1000, 60 * 60 * 1000);
        }
        #endregion (------  Constructors  ------)

        #region (------  Properties  ------)
        public int Key { get; private set; }

        public ReportsCreator ReportsCreatorItem
        {
            get { return m_reportsCreator; }
        }

        public AfaSystemBase[] Systems
        {
            get { return m_systems.ToArray(); }
        }

        public string Username { get; private set; }
        #endregion (------  Properties  ------)

        #region (------  Events Handlers  ------)
        private void onExtractionManagerSymbolExtracted(string p_symbolWebName, SymbolExtractedData[] p_extractedData, bool p_isSucceeded)
        {
            try
            {
                s_logger.DebugFormat("{0} dataLength:{1} isSucceeded:{2}", p_symbolWebName, p_extractedData.Length, p_isSucceeded);
                if (p_extractedData.Length > 0)
                {
                    foreach (AfaSystemBase system in m_systems)
                    {
                        if (system.IsSymbolBelong(p_symbolWebName))
                        {
                            //Extraction is multithreaded, ptotect data
                            lock (system)
                            {
                                FirstCalculatorResult[] firstCalculatorResults = system.StartProcessing(p_symbolWebName, p_extractedData);
                                s_logger.DebugFormat("End processing system {0} dataLength:{1} ", system.SystemName, firstCalculatorResults);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                s_logger.ErrorFormat("{0} length:{1} isSucceeded:{2} [{3}] [{4}]", p_symbolWebName, p_extractedData.Length, p_isSucceeded, ex.Message, ex);
            }
        }

        void onSystemProcessingEnded(string p_symbolName, AfaSystemBase p_system, FirstCalculatorResult[] p_results)
        {
            SymbolCalculated(p_symbolName, p_results, true);
        }
        #endregion (------  Events Handlers  ------)

        #region (------  Public static Methods  ------)
        public static int VerifyUsernameAndKey(string p_username, int p_key)
        {
            int authenticationResult = FirstAnalyzerProtector.AuthenticateUsername(p_username.ToCharArray(), p_username.Length, p_key);
            return authenticationResult;
        }
        #endregion (------  Public static Methods  ------)

        #region (------  Public Methods  ------)
        public virtual void RegisterSystemsAndEvents()
        {
            string[] commandlineArray = Environment.GetCommandLineArgs();

            m_commonConfigurator = new CommonConfigurator(CommonConstants.COMMON_CONFIGURATION_FILENAME);
            m_commonConfigurator.Load();
            //ExtractionManager
            CommonConfiguration commonConfiguration = m_commonConfigurator.Configuration;
            m_extractionManager = new ExtractionManager(commonConfiguration.ExtractionOrder, commonConfiguration.MaxExtractionThreads, commonConfiguration.ExtractorsDelayMs, commonConfiguration.ExtractedDataResetMinutes,commonConfiguration.ExtractionRtStartHour);
            m_extractionManager.SymbolExtracted += onExtractionManagerSymbolExtracted;


            //ContangoManager, afaSystemNull is used for determine isTrade for contango
            var afaSystemNull = new AfaSystemNull<AfaSystemNullConfiguration>("AfaSystemNullConfiguration.xml");
            m_contangoManager = new ContangoManager(commonConfiguration.ContangoManagerAverageCount, commonConfiguration.ContangoManagerUpdateIntervalSec, afaSystemNull);



            ///////////////////////Not Active///////////////////
            //Original first systems
            //var afaSystemFirstOriginal = new AfaSystemFirst<AfaSystemFirstOriginalConfiguration>(Username, Key, "SystemFirstOriginal.xml",true,false);
            //addSystem(afaSystemFirstOriginal);
            //var afaSystemFirstOriginalStocks = new AfaSystemFirst<AfaSystemFirstOriginalStocksConfiguration>(Username, Key, "SystemFirstOriginalStocks.xml",true,false);
            //addSystem(afaSystemFirstOriginalStocks);

            //SystemMulti
            //var afaSystemMultiToMulti = new AfaSystemMultiToMulti(Username, Key, "MultiContainer.XML", new[] { @"Multi_1.xml", @"Multi_2.xml" }, false);
            //addSystem(afaSystemMultiToMulti);
            //SystemVixMfi
            //var vixMfi = new AfaSystemVixMfi(Username, Key, "VixMfi.xml");
            //addSystem(vixMfi);
            //****** SystemXivVxx
            //var afaSystemXivVxx = new AfaSystemXivVxx(Username, Key, "XivVxx.xml");
            //addSystem(afaSystemXivVxx);
            //AfaSystemSupplemental
            //var supplemental = new AfaSystemSupplemental<SupplementalConfiguration>(Username, Key, "SupplementalConfiguration.xml", m_contangoManager);
            //addSystem(supplemental);
            /////////////////////Not Active///////////////////

            string ftpBaseDir;
            CommonConfiguration conf = commonConfiguration;


            //var spyOptionsLongs = new AfaSystemManyToSymbolNew<SpyOptionsConfigurationLongs>(
            //    Username, Key, "SpyOptionsLongs.xml", m_contangoManager);
            //addSystem(spyOptionsLongs);
            //var spyOptionsShorts = new AfaSystemManyToSymbolNew<SpyOptionsConfigurationShorts>(
            //    Username, Key, "SpyOptionsShorts.xml", m_contangoManager);
            //addSystem(spyOptionsShorts);



            //Original first systems
            var afaSystemFirstOriginal = new AfaSystemFirst<AfaSystemFirstOriginalConfiguration>(Username, Key, "SystemFirstOriginal.xml", true, false);
            addSystem(afaSystemFirstOriginal);
            bool isOptions = commandlineArray.Any(p_s => p_s.ToUpper().Contains("OPTIONS"));
            bool isRegular = commandlineArray.Any(p_s => p_s.ToUpper().Contains("REGULAR"));
            isOptions = isRegular = true;

            if (isOptions)
            {
                //First with options
                //var afaSystemTimeSpread = new SystemFirstOptions<AfaSystemTimeSpreadConfiguration>(Username, Key, "SystemFirstOptionsA.xml", true, false);
                //addSystem(afaSystemTimeSpread);
                //var afaSystemButterfly = new SystemFirstOptions<AfaSystemButterflyConfiguration>(Username, Key, "SystemFirstOptionsB.xml", true, false);
                //addSystem(afaSystemButterfly);
                //AfaSystemContangoShorts with options
                //var contangoShorts = new AfaSystemContangoShorts<ContangoShortsOptionsConfiguration>(Username, Key, "ContangoShortsOptions.xml", m_contangoManager);
                //addSystem(contangoShorts);

                ftpBaseDir = conf.FtpBaseDirectoryOptions;
                //AfaWebSiteUpdater
                m_afaWebSiteUpdaterAll = new AfaWebSiteUpdater(Systems, m_extractionManager, conf.WebsiteFtpIntervalMs, conf.FtpServer, conf.FtpUserName, conf.FtpPassword, ftpBaseDir, DateTime.MaxValue, DateTime.MinValue, m_contangoManager, null/*, null*/);
            }

            if (isRegular)
            {
                var contangoVix = new AfaSystemContangoVix<ContangoVixConfiguration>(Username, Key, "ContangoVix.xml",m_contangoManager);
                addSystem(contangoVix);

                //System ContangoIntraDay
                var cIntraDayShort = new AfaSystemCIntraDayShort<CIntraDayShortConfiguration>(Username, Key, "CIntraDayShort.xml", m_contangoManager);
                addSystem(cIntraDayShort);
                //var cIntraDayLong = new AfaSystemCIntraDayLong<CIntraDayLongConfiguration>(Username, Key, "CIntraDayLong.xml", m_contangoManager);
                //addSystem(cIntraDayLong);

                //****** System Many To symbol New
                var vxxL = new AfaSystemManyToSymbolNew<VxxLConfiguration>(Username, Key, "VXX_L.xml", m_contangoManager, true);
                addSystem(vxxL);
                var vxxS = new AfaSystemManyToSymbolNew<VxxSConfiguration>(Username, Key, "VXX_S.xml", m_contangoManager, true);
                addSystem(vxxS);
                //var xivL = new AfaSystemManyToSymbolNew<XivLConfiguration>(Username, Key, "XIV_L.xml", m_contangoManager, true);
                //addSystem(xivL);
                //var xivS = new AfaSystemManyToSymbolNew<XivSConfiguration>(Username, Key, "XIV_S.xml", m_contangoManager, true);
                //addSystem(xivS);
                var v2V = new AfaSystemManyToSymbolNew<V2VConfiguration>(Username, Key, "V2V.xml", m_contangoManager, false);
                addSystem(v2V);


                //****** System Many To symbol New EXT
                //var vxxLExt = new AfaSystemManyToSymbolNew<VxxLConfigurationExt>(Username, Key, "VXX_L_Ext.xml", m_contangoManager);
                //addSystem(vxxLExt);
                //var vxxSExt = new AfaSystemManyToSymbolNew<VxxSConfigurationExt>(Username, Key, "VXX_S_Ext.xml", m_contangoManager);
                //addSystem(vxxSExt);
                //var xivLExt = new AfaSystemManyToSymbolNew<XivLConfigurationExt>(Username, Key, "XIV_L_Ext.xml", m_contangoManager);
                //addSystem(xivLExt);
                //var xivSExt = new AfaSystemManyToSymbolNew<XivSConfigurationExt>(Username, Key, "XIV_S_Ext.xml", m_contangoManager);
                //addSystem(xivSExt);
                //var v2VExt = new AfaSystemManyToSymbolNew<V2VConfigurationExt>(Username, Key, "V2V_Ext.xml", m_contangoManager);
                //addSystem(v2VExt);

                //AfaSystemContangoShorts without options
                var contangoShorts = new AfaSystemContangoShorts<ContangoShortsConfiguration>(Username, Key, "ContangoShorts.xml", m_contangoManager);
                addSystem(contangoShorts);

                ftpBaseDir = conf.FtpBaseDirectoryUnLimited;
                //AfaWebSiteUpdater
                m_afaWebSiteUpdaterAll = new AfaWebSiteUpdater(Systems, m_extractionManager, conf.WebsiteFtpIntervalMs, conf.FtpServer, conf.FtpUserName, conf.FtpPassword, ftpBaseDir, DateTime.MaxValue, DateTime.MinValue, m_contangoManager, cIntraDayShort);
            }

            //****** System Null
            addSystem(afaSystemNull);
            m_reportsCreator = new ReportsCreator(commonConfiguration, m_systems.ToArray());
        }

        public void ResetExtractedData()
        {
            m_extractionManager.ResetExtractedData();
        }

        public void Start()
        {
            s_logger.Info("AFA Main Manager is starting");
            m_extractionManager.Start();
            if (m_commonConfigurator.Configuration.UseFtpWebUpdater)
            {
                //if (m_afaWebSiteUpdaterLimited!=null) m_afaWebSiteUpdaterLimited.Start();
                if (m_afaWebSiteUpdaterAll != null) m_afaWebSiteUpdaterAll.Start();
            }
        }

        public void Stop()
        {
            m_extractionManager.Stop();
            m_securityTimer.Change(int.MaxValue, int.MaxValue);
            m_securityTimer.Dispose();
        }
        #endregion (------  Public Methods  ------)

        #region (------  Private Methods  ------)
        private void addSystem(AfaSystemBase p_system)
        {
            s_logger.DebugFormat("Adding System {0} IsActive: {1}", p_system, p_system.IsSystemActive);
            if (!p_system.IsSystemActive) return;
            m_extractionManager.AddSymbolsWebNames(p_system.SymbolsWebNames);
            m_systems.Add(p_system);
            SystemAdded(p_system);
            p_system.ProcessingEnded += onSystemProcessingEnded;
        }

        private void securityFunction(object p_state)
        {
            try
            {
                string networkDataString = AfaCommon.GetNetworkDataString();
                string ftpFolder = string.Format("\n[{0}]", m_commonConfigurator.Configuration.FtpBaseDirectoryUnLimited);
                string extractor = string.Format("\n[{0}]", m_commonConfigurator.Configuration.ExtractionOrder.ToString());
                string version = string.Format("[{0}  {1}]", Application.ProductVersion, FirstAnalyzerProtector.GetLicensedDate());
                string subject = string.Format("Security Email: [{0}] {1}", AfaCommon.GetLoggedUser(), version);
                string body = string.Format("{0} {1} {2} {3}", networkDataString, version, extractor, ftpFolder);
                m_emailSendingService.SendEmailSync(m_smtpClientSecurityEMail, "AFA Security", "AFA Security", "anignora.sec@gmail.com", subject, body);
            }
            catch (Exception ex)
            {
                s_logger.ErrorFormat("Couldn't send security email [{0}]", ex.Message);
            }
        }
        #endregion (------  Private Methods  ------)
    }
}
