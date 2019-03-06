using System.ComponentModel;
using TalentCalc.Data;

namespace TalentCalc
{
    public class ResultsItem : INotifyPropertyChanged
    {
        #region Public Properties

        public string SystemName
        {
            get { return m_systemName; }
            set
            {
                m_systemName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SystemName"));
            }
        }

        public ActionData[] ActionDataArray
        {
            get { return m_actionDataArray; }
            set
            {
                m_actionDataArray = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ActionDataArray"));
            }
        }

        public string Best
        {
            get { return m_best; }
            set
            {
                m_best = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Best"));
            }
        }

        public bool IsRunning
        {
            get { return m_isRunning; }
            set
            {
                m_isRunning = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsRunning"));
            }
        }

        public ResultParameterItem[] ResultParameterItems
        {
            get { return m_resultParameterItems; }
            set
            {
                m_resultParameterItems = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ResultParameterItems"));
            }
        }

        public ResultParameterItem[] ResultMaxParameterItems
        {
            get { return m_resultParameterItems; }
            set
            {
                m_resultParameterItems = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ResultMaxParameterItems"));
            }
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion

        #region Fields

        private string m_best;
        private string m_systemName;
        private ResultParameterItem[] m_resultParameterItems;
        private ActionData[] m_actionDataArray;
        private bool m_isRunning = true;

        #endregion
    }
}