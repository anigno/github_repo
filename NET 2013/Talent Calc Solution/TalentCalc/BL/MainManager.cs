using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using AnignoraDataTypes.Configurations;
using log4net;
using TalentCalc.Configuration;
using TalentCalc.Data;
using TalentCalc.Systems;

namespace TalentCalc.BL
{
    public class MainManager
    {
        private readonly MainConfiguration m_mainConfiguration;

        #region Constructors

        public MainManager(MainConfiguration p_mainConfiguration)
        {
            m_mainConfiguration = p_mainConfiguration;
            initSystems();
        }

        #endregion

        #region Public Methods

        public void Start()
        {
            s_logger.Debug("Start()");
            foreach (SystemBase system in m_systems)
            {
                system.Start();
                SystemStarted++;
                OnSystemsRunCountUpdated(SystemStarted, SystemFinished);
            }
        }

        public void Stop()
        {
            s_logger.Debug("Stop()");
            foreach (SystemBase system in m_systems)
            {
                system.Stop();
            }
        }

        #endregion

        #region Public Properties

        public IObservable<SystemBase> OnAnyBestScoreCalculated
        {
            get { return m_anyBestScoreCalculatedsSubject; }
        }

        public IObservable<SystemBase> OnAnyProfitCalculated
        {
            get { return m_anyProfitCalculatedsSubject; }
        }

        public IObservable<SystemBase> OnAnyParameterDone
        {
            get { return m_anyParameterDoneSubject; }
        }

        public int SystemStarted { get; set; }
        public int SystemFinished { get; set; }

        #endregion

        #region Events

        public event Action<int, int> OnSystemsRunCountUpdated = delegate { };

        #endregion

        #region Private Methods

        private void initSystems()
        {
            string[] rawDataFiles = Directory.GetFiles(m_mainConfiguration.RawDataFolder);
            RawDataProvider rawDataProvider = new RawDataProvider(AppContainer.Instance.MainConfig.StartDate, AppContainer.Instance.MainConfig.EndDate);
            m_refRawData = rawDataProvider.ReadAndFix(m_mainConfiguration.RefIndexName, m_mainConfiguration.RefIndexName)[0];
            foreach (string fileA in rawDataFiles)
            {
                foreach (string fileB in rawDataFiles)
                {
                    if (fileA == fileB) continue;
                    string systemName = string.Format("[{0}]-[{1}]", Path.GetFileNameWithoutExtension(fileA), Path.GetFileNameWithoutExtension(fileB));
                    string configFileName = "SystemConfig_" + systemName + ".XML";
                    ConfiguratorXml<SystemConfigurationBase> configurator = new ConfiguratorXml<SystemConfigurationBase>(configFileName);
                    configurator.Load();
                    configurator.Configuration.SystemName = systemName;
                    RawData[][] rawDatas = rawDataProvider.ReadAndFix(fileA, fileB);
                    SystemDualMarkets system = new SystemDualMarkets(rawDatas, configurator.Configuration,m_refRawData);
                    m_systems.Add(system);
                }
            }

            foreach (SystemBase system in m_systems)
            {
                system.OnBestScoreCalculated.Subscribe(p_systemBase =>
                {
                    SystemHelper.CreateResultFile(p_systemBase, "Results",m_mainConfiguration);
                    m_anyBestScoreCalculatedsSubject.OnNext(p_systemBase);
                });
                system.OnProfitCalculated.Sample(TimeSpan.FromMilliseconds(3000)).Subscribe(p_base => { m_anyProfitCalculatedsSubject.OnNext(p_base); });
                SystemBase systemBaseLocal = system;
                system.OnParameterValueDone.Subscribe(p_systemBase =>
                {
                    s_logger.DebugFormat("initSystems() OnParameterValueDone {0}", p_systemBase.Name);
                    systemBaseLocal.Stop();
                    m_anyParameterDoneSubject.OnNext(systemBaseLocal);
                    SystemFinished++;
                    OnSystemsRunCountUpdated(SystemStarted, SystemFinished);
                });
            }
        }

        #endregion

        #region Fields

        private readonly Subject<SystemBase> m_anyBestScoreCalculatedsSubject = new Subject<SystemBase>();
        private readonly Subject<SystemBase> m_anyProfitCalculatedsSubject = new Subject<SystemBase>();
        private readonly Subject<SystemBase> m_anyParameterDoneSubject = new Subject<SystemBase>();
        private readonly List<SystemBase> m_systems = new List<SystemBase>();
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private RawData[] m_refRawData;

        #endregion
    }
}