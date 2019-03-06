using System;
using System.IO;
using System.Linq;
using AnignoraDataTypes;
using AnignoraDataTypes.Configurations;
using AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew;
using AnignoraFinanceAnalyzer5.MainManagement;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using AnignoraFinanceAnalyzer5.Systems.SystemOptions;

namespace AnignoraFinanceAnalyzer5.Systems.SystemsExtended
{
    public class AfaSystemManyToSymbolNew<T> : AfaSystemFirstBase<T> where T : AfaSystemFirstManyToSymbolNewConfigurationBase, new()
    {
        private readonly ContangoManager m_contangoManager;

        public AfaSystemManyToSymbolNew(string p_username, int p_key, string p_filename, ContangoManager p_contangoManager,bool p_useR1)
            : base(p_username, p_key, p_filename, p_useR1, false)
        {
            m_contangoManager = p_contangoManager;
            m_configurator = new ConfiguratorXml<T>(p_filename);
            m_configurator.Load();
        }
        private readonly ConfiguratorXml<T> m_configurator;

        protected override FirstCalculatorResult[] StartProcessingSpecific(string p_symbolName, AfaDataExtraction.SymbolExtractedData[] p_symbolExtractedDataArray)
        {
            if (p_symbolName.ToUpper() == "VIX")
            {
            }

            //Lower indexes are latest dates
            FirstCalculatorResult[] calculatedResults = base.StartProcessingSpecific(p_symbolName, p_symbolExtractedDataArray);

            T config = m_configurator.Configuration;
            //Verify contangoManager was initialized already at startUp
            if (m_contangoManager != null)
            {
                SystemManyToSymbolHelper.WriteContangoAverageValues(calculatedResults, m_contangoManager.ContangoAverageDictionary);
            }
            if (!config.ProfitSymbol.Contains(p_symbolName)) return calculatedResults;

            //Extra calculation for profit symbol
            SystemManyToSymbolHelper.ResetNewlyProfitSymbolData(calculatedResults);
            SignalOpenCloseData[] triggersOpenClose = SystemManyToSymbolHelper.CollectAllTriggersOpenClose(this, config.SignalTypeCalculated, p_symbolName, config.NoneTriggerSymbols);
            //SignalOpenCloseData[] eliminatedReadDates = SystemManyToSymbolHelper.EliminatMultipleReadDates(triggersOpenClose);
            //SignalOpenCloseData[] elliminatedTriggersIntersections = SystemManyToSymbolHelper.ElliminateTriggersIntersections(eliminatedReadDates);
            SystemManyToSymbolHelper.InsertTriggersSignalsToProfitSymbolData(calculatedResults, triggersOpenClose, config.SignalTypeProfit);
            SystemManyToSymbolHelper.CalculateProfitSymbolData(calculatedResults, config.RegularProfitCut, config.RegularLossCut, config.MaxDaysHoldingPos, m_contangoManager, config.ContangoLossCutA, config.ContangoLossCutB, config.ContangoLossCutB2,  config.ContangoLossCutStepTrigger);
            SystemManyToSymbolHelper.RemoveProfitSymbolIntersections(calculatedResults);
            SystemManyToSymbolHelper.FilterByContangoAverage(calculatedResults, config.MinimumEnableContangoAverage, config.MaximumEnableContangoAverage);
            SystemManyToSymbolHelper.FilterByR2(calculatedResults, config.MinimumR2, config.MaximumR2);

            FirstCalculatorResult[] vixResults = GetSymbolCalculatedResults("VIX");

            if (config.UseOptionCalculation)
            {
                bool isVxx = config.ProfitSymbol.Any(p_s => p_s.ToUpper().Contains("VXX"));
                bool isSpy = config.ProfitSymbol.Any(p_s => p_s.ToUpper().Contains("SPY"));
                if (isVxx) SystemOptionsHelper.CalculateOptionsDataShortIv(calculatedResults, config.VolatilityConstant, config.DaysToOptionMaturity, config.OptionsChangePut, config.OptionsWeightPut, config.OptionsChangeCall, config.OptionsWeightCall);
                if (isSpy && vixResults.Length > 50) SystemOptionsHelper.CalculateOptionsDataVix(calculatedResults, vixResults, config.DaysToOptionMaturity, config.OptionsChangePut, config.OptionsWeightPut, config.OptionsChangeCall, config.OptionsWeightCall);
            }

            SystemCalculationHelper.CalculateDrawDowns(calculatedResults);

            return calculatedResults;
        }

        public override void CreateProfitSignalsReport(string p_reportPath)
        {
            //return;
            if (!Directory.Exists(p_reportPath)) Directory.CreateDirectory(p_reportPath);
            string[] profitSymbol = m_configurator.Configuration.ProfitSymbol;
            FirstCalculatorResult[] calculatorResults = GetSymbolCalculatedResults(profitSymbol[0]);
            //calculatorResults = calculatorResults.Where(p => p.SignalType != SignalTypeEnum.None).ToArray();

            string reportFilename = p_reportPath + "\\" + SystemName + ".csv";
            File.WriteAllText(reportFilename, "");
            File.AppendAllText(reportFilename, "DateRead,SignalType,SignalResult,ProfitPer,ProfitCut,LossCut,Close,High,Low,closeDate,ContangoAverage,DrawDownLocal,MaxLossLocal,MaxProfit,MovAvgDiff" + Environment.NewLine);
            calculatorResults.DoForAll(p_result =>
            {
                File.AppendAllText(reportFilename, p_result.ToReportString());
            });
        }


        public override string[] ProfitSymbol
        {
            get { return m_configurator.Configuration.ProfitSymbol; }
        }

        public override bool IsSystemActive
        {
            get { return m_configurator.Configuration.IsSystemActive; }
        }

        public override float GetSignalWeight(FirstCalculatorResult p_result)
        {
            //For all trigger symbols return 0f, profit symbol weight is set elsewhere
            return 0f;
        }
    }
}