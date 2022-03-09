using System;
using System.Collections.Generic;
using System.Linq;
using AfaDataExtraction;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using log4net;

namespace AnignoraFinanceAnalyzer5.Systems
{
    public abstract class AfaSystemBase
    {
        public override string ToString()
        {
            return string.Format("{0}",SystemName);
        }
		#region (------  Fields  ------)
        protected Dictionary<DateTime, Dictionary<string, FirstCalculatorResult>> ActiveSymbolsHistoryDictionary = new Dictionary<DateTime, Dictionary<string, FirstCalculatorResult>>();
        protected ActiveSymbolsManager ActiveSymbolsManager=new ActiveSymbolsManager();
        private readonly Dictionary<string, FirstCalculatorResult[]> m_symbolsCalculatedData = new Dictionary<string, FirstCalculatorResult[]>();
        protected static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion (------  Fields  ------)

		#region (------  Delegates  ------)
        public delegate void SystemActiveSymbolChangeDelegate(AfaSystemBase p_system, FirstCalculatorResult p_result);
        public delegate void ProcessingEndedDelegate(string p_symbolName, AfaSystemBase p_system, FirstCalculatorResult[] p_results);
		#endregion (------  Delegates  ------)

		#region (------  Events  ------)
        public event SystemActiveSymbolChangeDelegate SystemActiveSymbolAdded = delegate { };
        public event SystemActiveSymbolChangeDelegate SystemActiveSymbolRemoved = delegate { };
        public event SystemActiveSymbolChangeDelegate SystemActiveSymbolUpdated = delegate { };
        public event ProcessingEndedDelegate ProcessingEnded = delegate { };
		#endregion (------  Events  ------)

		#region (------  Constructors  ------)
        protected AfaSystemBase()
        {
            ActiveSymbolsManager.ActiveSymbolAdded += onActiveSymbolsManagerActiveSymbolAdded;
            ActiveSymbolsManager.ActiveSymbolRemoved += onActiveSymbolsManagerActiveSymbolRemoved;
            ActiveSymbolsManager.ActiveSymbolUpdated += onActiveSymbolsManagerActiveSymbolUpdated;
        }

        void onActiveSymbolsManagerActiveSymbolUpdated(FirstCalculatorResult p_result)
        {
            SystemActiveSymbolUpdated(this,p_result);
        }

        void onActiveSymbolsManagerActiveSymbolRemoved(FirstCalculatorResult p_result)
        {
            SystemActiveSymbolRemoved(this, p_result);
        }

        void onActiveSymbolsManagerActiveSymbolAdded(FirstCalculatorResult p_result)
        {
            SystemActiveSymbolAdded(this, p_result);
        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public abstract int MaxDaysHoldingPos { get; }
        public abstract float RegularMultiplier { get; }

        public abstract string[] SymbolsWebNames { get; }

        public abstract string SystemName { get; }

        public abstract string[] ProfitSymbol { get; }

        public abstract bool IsSystemActive { get; }

        #endregion (------  Properties  ------)

		#region (------  Public Methods  ------)
        public FirstCalculatorResult[] GetRecentActiveResultsForWeb()
        {
            FirstCalculatorResult[] currentActiveSymbols=ActiveSymbolsManager.GetCurrentActiveSymbols();
            return currentActiveSymbols;
        }

        public FirstCalculatorResult GetResultByDate(FirstCalculatorResult[] p_calculatorResults, DateTime p_date)
        {
            FirstCalculatorResult resultByDate = p_calculatorResults.FirstOrDefault(p_result => p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead == p_date);
            return resultByDate;
        }

        public abstract float GetSignalWeight(FirstCalculatorResult p_result);

        public FirstCalculatorResult[] GetSymbolCalculatedResults(string p_symbolName)
        {
            lock (m_symbolsCalculatedData)
            {
                if (m_symbolsCalculatedData.ContainsKey(p_symbolName)) return (FirstCalculatorResult[]) m_symbolsCalculatedData[p_symbolName].Clone();
                return new FirstCalculatorResult[0];
            }
        }

        public bool IsSymbolBelong(string p_symbolWebName)
        {
            bool isSymbolBelog = SymbolsWebNames.Contains(p_symbolWebName);
            return isSymbolBelog;
        }

        public FirstCalculatorResult[] StartProcessing(string p_symbolName, SymbolExtractedData[] p_symbolExtractedDataArray)
        {
            FirstCalculatorResult[] results=StartProcessingSpecific(p_symbolName,p_symbolExtractedDataArray);
            PostProcessingCommonActivities(p_symbolName, results);
            if (results.Length < 2)
            {
                s_logger.ErrorFormat("Symbol:{0}  ResultsLength:{1} ExtractedDataLength:{2}",p_symbolName,results.Length,p_symbolExtractedDataArray.Length);
                return new FirstCalculatorResult[0];
            }
            ProcessingEnded(p_symbolName, this, results);
            return results;
        }
		#endregion (------  Public Methods  ------)

		#region (------  Protected Methods  ------)
        protected void PostProcessingCommonActivities(string p_symbolName, FirstCalculatorResult[] p_results)
        {
            addUpdateSymbolCalculatedData(p_symbolName, p_results);

            ActiveSymbolsManager.UpdateActiveSymbols(p_symbolName,p_results,MaxDaysHoldingPos,SystemName);
        }

        protected abstract FirstCalculatorResult[] StartProcessingSpecific(string p_symbolName, SymbolExtractedData[] p_symbolExtractedDataArray);

       
		#endregion (------  Protected Methods  ------)

		#region (------  Private Methods  ------)
        private void addUpdateSymbolCalculatedData(string p_symbolName, FirstCalculatorResult[] p_results)
        {
            lock (m_symbolsCalculatedData)
            {
                if (!m_symbolsCalculatedData.ContainsKey(p_symbolName))
                {
                    m_symbolsCalculatedData.Add(p_symbolName, new FirstCalculatorResult[0]);
                }
                m_symbolsCalculatedData[p_symbolName] = p_results;
            }
        }

     
		#endregion (------  Private Methods  ------)

        public abstract void CreateProfitSignalsReport(string p_reportsPath);
    }
}