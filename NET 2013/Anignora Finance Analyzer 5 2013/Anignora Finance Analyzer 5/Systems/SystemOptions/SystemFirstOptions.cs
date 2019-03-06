using System;
using AfaDataExtraction;
using AnignoraDataTypes;
using AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstOptions;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;

namespace AnignoraFinanceAnalyzer5.Systems.SystemOptions
{
    public class SystemFirstOptions<T> : AfaSystemFirst<T> where T : AfaSystemFirstOptionsConfigurationBase, new()
    {
        #region (------  Fields  ------)
        private readonly BlackAndScholes m_blackAndScholes = new BlackAndScholes();
        #endregion (------  Fields  ------)

        #region (------  Constructors  ------)
        public SystemFirstOptions(string p_username, int p_key, string p_filename, bool p_useR1, bool p_useCalendaricMaxDays)
            : base(p_username, p_key, p_filename, p_useR1, p_useCalendaricMaxDays)
        {
        }
        #endregion (------  Constructors  ------)

        #region (------  Properties  ------)
        public override string[] ProfitSymbol
        {
            get
            {
                return m_configurator.Configuration.ProfitSymbol;
            }
        }
        #endregion (------  Properties  ------)

        #region (------  Public static Methods  ------)
        public static void EliminateSignalIntersection(FirstCalculatorResult[] p_results)
        {
            FirstCalculatorResult[] signaledResults = SystemOptionsHelper.GetSignaledResults(p_results);
            DateTime nextDate = ExtractionCommon.DATE_MINIMUM;
            for (int a = signaledResults.Length - 1; a >= 0; a--)
            {
                FirstCalculatorResult result = signaledResults[a];
                if (result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead < nextDate)
                {
                    //Clear signal
                    result.SignalType = SignalTypeEnum.None;
                    result.ProfitPer = 0;
                    result.SignalResult = SignalResultEnum.None;
                    result.DateClose = ExtractionCommon.DATE_MINIMUM;
                }
                else if (result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead >= nextDate)
                {
                    nextDate = result.DateClose;
                    if (nextDate <= ExtractionCommon.DATE_MINIMUM) nextDate = DateTime.Today.Date;
                }
            }
        }

        #endregion (------  Public static Methods  ------)

        #region (------  Protected Methods  ------)
        protected override FirstCalculatorResult[] StartProcessingSpecific(string p_symbolName, SymbolExtractedData[] p_symbolExtractedDataArray)
        {
            FirstCalculatorResult[] results = base.StartProcessingSpecific(p_symbolName, p_symbolExtractedDataArray);
            if (p_symbolName.ToUpper() == ("VIX"))
            {
                results.DoForAll(p_result => p_result.ProfitPer = 0);
                return results;
            }
            FirstCalculatorResult[] vixResults = GetSymbolCalculatedResults("VIX");
            if (vixResults.Length < 50)
            {
                s_logger.Warn("No Vix data");
                return new FirstCalculatorResult[0];
            }
            EliminateSignalIntersection(results);
            SystemOptionsHelper.CalculateOptionsDataVix(
                results,
                vixResults,
                m_configurator.Configuration.DaysToOptionMaturity,
                m_configurator.Configuration.OptionsChangeCall,
                m_configurator.Configuration.OptionsChangePut,
                m_configurator.Configuration.OptionsWeightCall,
                m_configurator.Configuration.OptionsWeightPut);
            return results;
        }
        #endregion (------  Protected Methods  ------)

        #region (------  Private Methods  ------)
        #endregion (------  Private Methods  ------)
    }
}
