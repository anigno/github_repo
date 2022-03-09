using System;
using System.Collections.Generic;
using System.Linq;
using AnignoraDataTypes;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using log4net;

namespace AnignoraFinanceAnalyzer5.Systems
{
    public class ActiveSymbolsManager : IActiveSymbolsManager
    {
		#region (------  Fields  ------)
        private readonly Dictionary<string, FirstCalculatorResult> m_activeSymbols = new Dictionary<string, FirstCalculatorResult>();
        protected static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion (------  Fields  ------)

		#region (------  Delegates  ------)
        public delegate void ActiveSymbolChangedDelegate(FirstCalculatorResult p_result);
		#endregion (------  Delegates  ------)

		#region (------  Events  ------)
        public event ActiveSymbolChangedDelegate ActiveSymbolAdded = delegate { };

        public event ActiveSymbolChangedDelegate ActiveSymbolRemoved = delegate { };
        
        public event ActiveSymbolChangedDelegate ActiveSymbolUpdated = delegate { };
		#endregion (------  Events  ------)

		#region (------  Public Methods  ------)
        public FirstCalculatorResult[] GetCurrentActiveSymbols()
        {
            FirstCalculatorResult[] firstCalculatorResultsArray;
            lock (m_activeSymbols)
            {
                firstCalculatorResultsArray = m_activeSymbols.Values.ToArray();
            }
            return firstCalculatorResultsArray;
        }

       

        public void UpdateActiveSymbols(string p_symbolnName, FirstCalculatorResult[] p_results, int p_maxDays,string p_systemName)
        {
            //if (p_systemName != "ContangoVix")return;
            s_logger.DebugFormat("[{0}] [{1}] resultsLength:{2} maxDays:{3}", p_systemName, p_symbolnName, p_results.Length, p_maxDays);
            //Build an only maxDays last results dictionary
            Dictionary<string, FirstCalculatorResult> testedResultDictionary = new Dictionary<string, FirstCalculatorResult>();
            if (p_maxDays >= p_results.Length)
            {
                //Problem with maxDays or data
                s_logger.ErrorFormat("Problem with symbol: {0} and maxDays:{1} or resultsLength:{2}",p_symbolnName,p_maxDays,p_results.Length);
                return;
            }
            for (int a = 0; a <= p_maxDays; a++)
            {
                string sKey = getSKey(p_results[a]);
                testedResultDictionary.Add(sKey, p_results[a]);
            }
            //Leave only signaled results
            testedResultDictionary = testedResultDictionary.Where(p => p.Value.SignalType != SignalTypeEnum.None).ToDictionary(p => p.Key, p => p.Value);
            //Leave only not closed today
            testedResultDictionary = testedResultDictionary.Where(
                delegate(KeyValuePair<string, FirstCalculatorResult> p)
                {
                    bool bNoCloseNoToday = p.Value.SignalResult == SignalResultEnum.None && p.Value.DateClose.Date != DateTime.Now.Date;
                    bool bCloseToday = p.Value.SignalResult != SignalResultEnum.None && p.Value.DateClose.Date == DateTime.Now.Date;
                    return bNoCloseNoToday || bCloseToday;
                }).ToDictionary(p => p.Key, p => p.Value);
            testedResultDictionary.DoForAll(p_pair =>
            {
                s_logger.DebugFormat("Active key: [{0}]", p_pair.Key);
            });
            lock (m_activeSymbols)
            {
                Dictionary<string, FirstCalculatorResult> addition=new Dictionary<string, FirstCalculatorResult>();
                //Dictionary<string, FirstCalculatorResult> updating=new Dictionary<string, FirstCalculatorResult>();
                List<string> removeList=new List<string>();
                //Check for new active symbol_date
                testedResultDictionary.DoForAll(p_testedPair =>
                                                    {
                                                        string sKey = getSKey(p_testedPair.Value);
                                                        if (!m_activeSymbols.ContainsKey(sKey))
                                                        {
                                                            addition.Add(sKey, p_testedPair.Value);
                                                            s_logger.DebugFormat("SystemActiveSymbol Add, {0}", p_testedPair.Value);
                                                            ActiveSymbolAdded(p_testedPair.Value);
                                                        }
                                                        else
                                                        {
                                                            //Update
                                                            m_activeSymbols[sKey] = p_testedPair.Value;
                                                            s_logger.DebugFormat("SystemActiveSymbol Update, {0}", p_testedPair.Value);
                                                            ActiveSymbolUpdated(p_testedPair.Value);
                                                        }
                                                    });
                //Remove not active symbols for symbol_date for current symbolName only
                m_activeSymbols.DoForAll(p_activePair =>
                                             {
                                                 if (p_activePair.Key.StartsWith(p_symbolnName))
                                                 {
                                                     string sKey = getSKey(p_activePair.Value);
                                                     if (!testedResultDictionary.ContainsKey(sKey))
                                                     {
                                                         s_logger.DebugFormat("SystemActiveSymbol Removed, {0}", m_activeSymbols[sKey]);
                                                         ActiveSymbolRemoved(m_activeSymbols[sKey]);
                                                         removeList.Add(sKey);
                                                     }
                                                 }
                                             });
                //Add remove active symbols
                addition.DoForAll(p_pair =>
                {
                    m_activeSymbols.Add(p_pair.Key, p_pair.Value);
                });
                removeList.DoForAll(p_key =>
                {
                    m_activeSymbols.Remove(p_key);
                });
            }
        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        private string getSKey(FirstCalculatorResult p_result)
        {
            string symbolName = p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName;
            string sKey = symbolName + p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead.ToString("yyy_MM_dd");
            return sKey;
        }
		#endregion (------  Private Methods  ------)
    }
}