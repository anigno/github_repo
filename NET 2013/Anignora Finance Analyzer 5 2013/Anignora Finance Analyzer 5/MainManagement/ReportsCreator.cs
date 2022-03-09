using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AnignoraFinanceAnalyzer5.Configurators.Configuration;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using log4net;

namespace AnignoraFinanceAnalyzer5.MainManagement
{
    public class ReportsCreator
    {

        public void CreateDebugReport(SystemSymbolPair p_pair)
        {
            FirstCalculatorResult[] results=p_pair.SystemBase.GetSymbolCalculatedResults(p_pair.SymbolName);
            StringBuilder sb=new StringBuilder();
            //FirstCalculatorResult[] activeResults = p_pair.SystemBase.GetRecentActiveResultsForWeb();
            //sb.Append("{WebName},{DateRead},{open},{close},{high},{low},{AnalyzedOne},{AnalyzedTwo},{AnalyzedTwoPer}\n");
            sb.Append("{WebName},{DateRead},{open},{close},{high},{low},{AnalyzedOne},{AnalyzedTwo},{AnalyzedTwoPer},{signalType},{signalResult},{profitPer},{dateClose},{lossCut},{profitCut}\n");
            foreach (FirstCalculatorResult result in results)
            {
                if(result.SignalType==SignalTypeEnum.None)continue;
                sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}\n",
                //sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8}\n",
                    result.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName,
                    result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead.ToString("d/M/yyyy"),
                    result.FirstAnalyzeResultItem.SymbolExtractedDataItem.Open,
                    result.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close,
                    result.FirstAnalyzeResultItem.SymbolExtractedDataItem.High,
                    result.FirstAnalyzeResultItem.SymbolExtractedDataItem.Low,
                    result.FirstAnalyzeResultItem.AnalyzedOne,
                    result.FirstAnalyzeResultItem.AnalyzedTwo,
                    result.FirstAnalyzeResultItem.AnalyzedTwoPer,
                    result.SignalType,
                    result.SignalResult,
                    result.ProfitPer,
                    result.DateClose.ToString("d/M/yyyy"),
                    result.LossCut,
                    result.ProfitCut
                    );
            }
            string reportsPath = m_commonConfiguration.ReportsPath;
            if (!Directory.Exists(reportsPath)) Directory.CreateDirectory(reportsPath);
            string filePath=string.Format(@"{0}\{1}_{2}.csv",reportsPath,p_pair.SystemBase.SystemName,p_pair.SymbolName);
            File.WriteAllText(filePath, sb.ToString());
        }

        #region (------  Fields  ------)
        private readonly CommonConfiguration m_commonConfiguration;
        private readonly AfaSystemBase[] m_systems;
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public ReportsCreator(CommonConfiguration p_commonConfiguration,AfaSystemBase[] p_systems)
        {
            m_commonConfiguration = p_commonConfiguration;
            m_systems = p_systems;
        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public AfaSystemBase[] Systems
        {
            get { return m_systems; }
        }
		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)
        public ProfitCalculationItem[] CalculateProfit(SystemSymbolPair[] p_systemSymbolPairs,bool p_generateSymbolsReports)
        {
            Dictionary<DateTime,ProfitCalculationItem> profitDictionary=new Dictionary<DateTime, ProfitCalculationItem>();
            foreach (SystemSymbolPair systemSymbolPair in p_systemSymbolPairs)
            {
                UpdateProfitDataForSymbol(profitDictionary, systemSymbolPair.SystemBase,systemSymbolPair.SymbolName);
                if (p_generateSymbolsReports)
                {
                    systemSymbolPair.SystemBase.CreateProfitSignalsReport(m_commonConfiguration.ReportsPath);
                }
            }
            ProfitCalculationItem[] orderedCalculationItems = profitDictionary.Values.OrderBy(p_item => { return p_item.DateRead; }).ToArray();
            return orderedCalculationItems;
        }

        public void CreateTotalProfitReport(ProfitCalculationItem[] p_orderedCalculationItems)
        {
            string reportsPath = m_commonConfiguration.ReportsPath;
            if (!Directory.Exists(reportsPath)) Directory.CreateDirectory(reportsPath);
            string filePath = string.Format("{0}\\Report_{1}.csv", reportsPath, DateTime.Now.ToString("yy.MM.dd.hh.mm.ss"));
            File.AppendAllText(filePath, "Date,DailyProfit,ActiveSignals\n");
            foreach (ProfitCalculationItem item in p_orderedCalculationItems)
            {
                int nActives = item.ShortHits + item.ShortMisses + item.LongHits + item.LongMisses;
                string s = string.Format("{0},{1},{2}\n", item.DateRead, item.ProfitDaily,nActives);
                File.AppendAllText(filePath, s);
            }
        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        private void UpdateProfitDataForSymbol(Dictionary<DateTime, ProfitCalculationItem> p_profitDictionary, AfaSystemBase p_system, string p_symbolName)
        {
            s_logger.DebugFormat("system:{0} symbol:{1}", p_system, p_symbolName);
            FirstCalculatorResult[] symbolResultData = p_system.GetSymbolCalculatedResults(p_symbolName);
            float regularMultiplier = p_system.RegularMultiplier;
            foreach (FirstCalculatorResult calculatorResult in symbolResultData)
            {
                DateTime dateRead = calculatorResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                if (Math.Abs(calculatorResult.ProfitPer - 0) < 0.0001f) continue;
                if (!p_profitDictionary.ContainsKey(dateRead))
                {
                    p_profitDictionary.Add(dateRead, new ProfitCalculationItem(dateRead));
                }
                ProfitCalculationItem pi = p_profitDictionary[dateRead];

                pi.ProfitDaily += calculatorResult.ProfitPer * 100 * calculatorResult.SignalWeight * regularMultiplier;
                if (calculatorResult.SignalType == SignalTypeEnum.Long)
                {
                    if (calculatorResult.SignalResult == SignalResultEnum.Hit)
                    {
                        pi.LongHits++;
                        pi.LongHitsProfit += calculatorResult.ProfitPer * calculatorResult.SignalWeight * regularMultiplier;
                    }
                    if (calculatorResult.SignalResult == SignalResultEnum.Miss)
                    {
                        pi.LongMisses++;
                        pi.LongMissesProfit += calculatorResult.ProfitPer * calculatorResult.SignalWeight * regularMultiplier;
                    }
                }
                if (calculatorResult.SignalType == SignalTypeEnum.Short)
                {
                    if (calculatorResult.SignalResult == SignalResultEnum.Hit)
                    {
                        pi.ShortHits++;
                        pi.ShortHitsProfit += calculatorResult.ProfitPer * calculatorResult.SignalWeight * regularMultiplier;
                    }
                    if (calculatorResult.SignalResult == SignalResultEnum.Miss)
                    {
                        pi.ShortMisses++;
                        pi.ShortMissesProfit += calculatorResult.ProfitPer * calculatorResult.SignalWeight * regularMultiplier;
                    }
                }
            }
        }
		#endregion (------  Private Methods  ------)
    }
}