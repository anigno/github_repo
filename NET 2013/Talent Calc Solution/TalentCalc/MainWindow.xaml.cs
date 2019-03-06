using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using log4net;
using TalentCalc.BL;
using TalentCalc.Systems;

namespace TalentCalc
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        #region Constructors

        public MainWindow()
        {
            new ApplicationInitializer().Initialize();
            InitializeComponent();
            DataContext = this;
            s_logger.Debug("MainWindow(), created");
            ResultsList = new ObservableCollection<ResultsItem>();
            AppContainer.Instance.MainManager.OnAnyBestScoreCalculated.ObserveOnDispatcher().Subscribe(onAnyBestScoreCalculated);
            AppContainer.Instance.MainManager.OnAnyProfitCalculated.ObserveOnDispatcher().Subscribe(onAnyProfitCalculated);
            AppContainer.Instance.MainManager.OnAnyParameterDone.Subscribe(onAnyParameterDone);
            AppContainer.Instance.MainManager.OnSystemsRunCountUpdated += MainManager_OnSystemsRunCountUpdated;
            AppContainer.Instance.MainManager.Start();
        }

        private void MainManager_OnSystemsRunCountUpdated(int p_started, int p_finished)
        {
            LabelSystemsStartedCount = p_started.ToString();
            LabelSystemsFinishedCount = p_finished.ToString();
        }

        #endregion

        public string LabelSystemsStartedCount
        {
            get { return m_labelSystemsStartedCount; }
            set
            {
                m_labelSystemsStartedCount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LabelSystemsStartedCount"));
            }
        }

        public string LabelSystemsFinishedCount
        {
            get { return m_labelSystemsFinishedCount; }
            set
            {
                m_labelSystemsFinishedCount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LabelSystemsFinishedCount"));
            }
        }

        #region Public Properties

        public ObservableCollection<ResultsItem> ResultsList { get; set; }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion

        #region Private Methods

        private void onAnyParameterDone(SystemBase p_systemBase)
        {
            ResultsItem item = ResultsList.SingleOrDefault(p_item => p_item.SystemName == p_systemBase.Name);
            if (item == null)
            {
                item = new ResultsItem();
                item.SystemName = p_systemBase.Name;
                ResultsList.Add(item);
            }
            item.IsRunning = false;
        }

        private void onAnyBestScoreCalculated(SystemBase p_systemBase)
        {
            ResultsItem item = ResultsList.SingleOrDefault(p_item => p_item.SystemName == p_systemBase.Name);
            if (item == null)
            {
                item = new ResultsItem();
                item.SystemName = p_systemBase.Name;
                ResultsList.Add(item);
            }
            item.Best = (p_systemBase.BestScore).ToString("0.00000");
            item.ResultMaxParameterItems = p_systemBase.ParametersList.Select(p_parameterConfig => new ResultParameterItem() { ParameterName = p_parameterConfig.Name, ParameterValue = p_parameterConfig.Last.ToString() }).ToArray();
            PropertyChanged(this, new PropertyChangedEventArgs("ResultsList"));
        }

        private void onAnyProfitCalculated(SystemBase p_systemBase)
        {
            ResultsItem item = ResultsList.SingleOrDefault(p_item => p_item.SystemName == p_systemBase.Name);
            if (item == null)
            {
                item = new ResultsItem();
                item.SystemName = p_systemBase.Name;
                ResultsList.Add(item);
            }
            item.ResultParameterItems = p_systemBase.ParametersList.Select(p_parameterConfig => new ResultParameterItem() { ParameterName = p_parameterConfig.Name, ParameterValue = p_parameterConfig.Last.ToString() }).ToArray();
            PropertyChanged(this, new PropertyChangedEventArgs("ResultsList"));
        }

        #endregion

        #region Fields

        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string m_labelSystemsStartedCount;
        private string m_labelSystemsFinishedCount;

        #endregion
    }
}