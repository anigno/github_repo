using System;
using System.Collections.Generic;
using System.Linq;
using Anignora_LogViewer.BL.EventArgs;
using log4net;

namespace Anignora_LogViewer.BL.Filtering
{
    public class FilteringManager
    {
		#region (------  Fields  ------)
        private readonly List<FilterData> m_filtersList = new List<FilterData>();
        private static readonly ILog s_logger = LogManager.GetLogger(typeof(FilteringManager));
		#endregion (------  Fields  ------)

		#region (------  Events  ------)
        public event EventHandler<FilterChangedEventArgs> FilterAdded = delegate { };

        public event EventHandler<FilterChangedEventArgs> FilterChanged = delegate { };

        public event EventHandler<FilterChangedEventArgs> FilterRemoved = delegate { };
		#endregion (------  Events  ------)

		#region (------  Properties  ------)
        public string[] FiltersNames
        {
            get
            {
                lock (m_filtersList)
                {
                    string[] filterNames= m_filtersList.Select(p_filterData => p_filterData.FilterName).ToArray();
                    return filterNames;
                }
            }
        }
		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)
        public void AddFilter(FilterData p_filter)
        {
            lock (m_filtersList)
            {
                m_filtersList.Add(p_filter);
            }
            FilterAdded(this,new FilterChangedEventArgs(p_filter.FilterName));
            s_logger.DebugFormat("Filter Added {0}",p_filter.FilterName);
        }

        public FilterData GetFilterData(string p_filterName)
        {
            lock (m_filtersList)
            {
                return m_filtersList.Single(p_filterData => p_filterData.FilterName == p_filterName);
            }
        }

        public string[][] GetFilteredLogLines(string[][] p_logLines)
        {
            string[][] logLines = p_logLines;
            lock (m_filtersList)
            {
                foreach (FilterData filterData in m_filtersList)
                {
                    if (!filterData.IsEnabled) continue;
                    logLines = filterData.FilterOutLogLines(logLines);
                }
            }
            return logLines;
        }

        public bool IsFilteredln(string[] p_logLine)
        {
            bool bRet = true; lock (m_filtersList)
            {
                foreach (FilterData filterData in m_filtersList)
                {
                    if (!filterData.IsEnabled) continue;
                    bRet = bRet & filterData.IsFilteredln(p_logLine);
                }
            }
            return bRet;
        }

        public void RemoveFilter(int p_index)
        {
            string filterName;
            lock (m_filtersList)
            {
                filterName = m_filtersList[p_index].FilterName;
                m_filtersList.RemoveAt(p_index);
            }
            FilterRemoved(this, new FilterChangedEventArgs(filterName));
            s_logger.DebugFormat("Filter Removed {0}", filterName);
        }

        public void SetFilterEnable(int p_filterIndex, bool p_isEnable)
        {
            string filterName;
            lock (m_filtersList)
            {
                m_filtersList[p_filterIndex].IsEnabled = p_isEnable;
                filterName = m_filtersList[p_filterIndex].FilterName;
            }
            FilterChanged(this, new FilterChangedEventArgs(filterName));
            s_logger.DebugFormat("Filter Set Enable {0} {1}", filterName,p_isEnable);
        }
		#endregion (------  Public Methods  ------)
    }
}
