using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AfaDataExtraction.Contango;
using AnignoraDataTypes;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using log4net;

namespace AnignoraFinanceAnalyzer5.MainManagement
{
    public class ContangoManager
    {
        #region Constructors

        public ContangoManager(int p_averageLength, int p_extractionIntervalSec, AfaSystemBase p_anyActiveSystem)
        {
            s_log.InfoFormat("averageLength={0} extractionIntervalSec={1}", p_averageLength, p_extractionIntervalSec);
            m_averageLength = p_averageLength;
            m_anyActiveSystem = p_anyActiveSystem;
            m_extractionTimer = new Timer(extractionTimerCallback);
            int period = p_extractionIntervalSec*1000;
            m_extractionTimer.Change(period/5, period);
        }

        #endregion

        #region Public Methods

        public float GetContangoValue(DateTime p_date)
        {
            ContangoExtractedData contangoExtractedData = m_contangoExtractor.ContangoExtractedData.SingleOrDefault(p_data => p_data.ReadDate.Date == p_date.Date);
            return contangoExtractedData != null ? contangoExtractedData.ContangoValue : 0;
        }

        public static float GetAverageContango(ContangoExtractedData[] p_items, int p_startIndex, int p_nItems)
        {
            float sum = default(float);
            for (int a = p_startIndex; a < p_startIndex + p_nItems; a++)
            {
                sum += p_items[a].ContangoValue;
            }
            return sum/p_nItems;
        }

        public ContangoExtractedData GetLastContangoData()
        {
            ContangoExtractedData data = m_contangoExtractor.ContangoExtractedData.LastOrDefault();
            return data;
        }

        public ContangoExtractedData GetPreviousToLastContangoData()
        {
            if (m_contangoExtractor.ContangoExtractedData.Length < 2) return null;
            ContangoExtractedData data = m_contangoExtractor.ContangoExtractedData[m_contangoExtractor.ContangoExtractedData.Length - 2];
            return data;
        }

        public ContangoExtractedData GetContangoExtractedData(DateTime p_date)
        {
            return m_contangoExtractor.ContangoExtractedData.SingleOrDefault(p_data => p_data.ReadDate.Date == p_date.Date);
        }

        #endregion

        #region Public Properties

        public Dictionary<DateTime, float> ContangoAverageDictionary
        {
            get
            {
                lock (m_contangoAverageDictionary)
                {
                    return m_contangoAverageDictionary;
                }
            }
        }

        public ContangoExtractedData[] ContangoExtractedData
        {
            get { return m_contangoExtractor.ContangoExtractedData; }
        }

        #endregion

        #region Private Methods

        private void calculateContangoAverage()
        {
            lock (m_contangoAverageDictionary)
            {
                ContangoExtractedData[] contangoExtractedDatas = m_contangoExtractor.ContangoExtractedData;
                if (m_contangoAverageDictionary.Count == 0)
                {
                    s_log.Debug("Calculate all contango averages");
                    for (int a = m_averageLength; a < contangoExtractedDatas.Length; a++)
                    {
                        float average = GetAverageContango(contangoExtractedDatas, a - m_averageLength, m_averageLength);
                        m_contangoAverageDictionary.AddReplace(contangoExtractedDatas[a].ReadDate, average);
                    }
                }
                int lastIndex = contangoExtractedDatas.Length - 1;
                s_log.DebugFormat("Calculate Last contango average lastIndex={0}", lastIndex);
                float lastAverage = GetAverageContango(contangoExtractedDatas, lastIndex - m_averageLength, m_averageLength);
                m_contangoAverageDictionary.AddReplace(contangoExtractedDatas[lastIndex].ReadDate, lastAverage);
            }
        }

        private void extractionTimerCallback(object p_state)
        {
            ContangoExtractedData lastExtractedContango = m_contangoExtractor.ExtractLastContangoData();
            if (lastExtractedContango == null)
            {
                s_log.WarnFormat("Couldn't extract last contango data");
                return;
            }
            //If no trade , will not add or update known data
            FirstCalculatorResult[] results = m_anyActiveSystem.GetSymbolCalculatedResults(m_anyActiveSystem.SymbolsWebNames[0]);
            FirstCalculatorResult firstCalculatorResultForDate = m_anyActiveSystem.GetResultByDate(results, lastExtractedContango.ReadDate.Date);
            if (results.Length > 10 && firstCalculatorResultForDate == null)
            {
                s_log.DebugFormat("No trade for date: {0}", lastExtractedContango.ReadDate);
                //Will check redundent data that might have been added by mistake
                m_contangoExtractor.Remove(lastExtractedContango.ReadDate);
            }
            else
            {
                s_log.DebugFormat("Updating contango for date: {0}", lastExtractedContango.ReadDate);
                m_contangoExtractor.AddUpdate(lastExtractedContango);
            }

            calculateContangoAverage();
        }

        #endregion

        #region Fields

        private readonly int m_averageLength;
        private readonly AfaSystemBase m_anyActiveSystem;
        private readonly Dictionary<DateTime, float> m_contangoAverageDictionary = new Dictionary<DateTime, float>();
        private readonly ContangoExtractor m_contangoExtractor = new ContangoExtractor();
        private readonly Timer m_extractionTimer;
        private static readonly ILog s_log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
    }
}