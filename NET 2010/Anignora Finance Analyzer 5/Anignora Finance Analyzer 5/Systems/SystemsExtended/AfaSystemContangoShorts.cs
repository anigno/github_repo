using System;
using System.Linq;
using AnignoraDataTypes.Configurations;
using AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew;
using AnignoraFinanceAnalyzer5.MainManagement;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using AnignoraFinanceAnalyzer5.Systems.SystemOptions;

namespace AnignoraFinanceAnalyzer5.Systems.SystemsExtended
{
    public class AfaSystemContangoShorts<T> : AfaSystemFirstBase<T> where T : CIntraDayConfigurationBase, new()
    {
        #region (------  Fields  ------)
        private readonly ConfiguratorXml<T> m_configurator;
        private readonly ContangoManager m_contangoManager;
        #endregion (------  Fields  ------)

        #region (------  Constructors  ------)
        public AfaSystemContangoShorts(string p_username, int p_key, string p_filename, ContangoManager p_contangoManager)
            : base(p_username, p_key, p_filename, true, false)
        {
            m_contangoManager = p_contangoManager;
            m_configurator = new ConfiguratorXml<T>(p_filename);
            m_configurator.Load();
        }
        #endregion (------  Constructors  ------)

        #region (------  Properties  ------)
        public override bool IsSystemActive
        {
            get { return m_configurator.Configuration.IsSystemActive; }
        }

        public override string[] ProfitSymbol
        {
            get { return m_configurator.Configuration.ProfitSymbol; }
        }
        #endregion (------  Properties  ------)

        #region (------  Public Methods  ------)
        public override void CreateProfitSignalsReport(string p_reportsPath)
        {
            //Nothing yet
        }
        #endregion (------  Public Methods  ------)

        #region (------  Protected Methods  ------)
        protected override FirstCalculatorResult[] StartProcessingSpecific(string p_symbolName, AfaDataExtraction.SymbolExtractedData[] p_symbolExtractedDataArray)
        {
            //Lower indexes are latest dates
            T config = m_configurator.Configuration;
            //Generate FirstCalculatorResults
            FirstCalculatorResult[] calculatorResults = p_symbolExtractedDataArray.Select(p_exData => new FirstCalculatorResult(new FirstAnalyzeResult(p_exData))).ToArray();
            //Calculate signals and profits
            for (int index = 0; index < calculatorResults.Length - 1; index++)
            {
                FirstCalculatorResult current = calculatorResults[index];
                FirstCalculatorResult previous = calculatorResults[index + 1];
                previous.Contango = m_contangoManager.GetContangoValue(previous.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead);
                current.Contango = m_contangoManager.GetContangoValue(current.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead);

                float startValue = AfaSystemContangoHelper.SetSignalContangoShorts(current, previous, config);

                if (current.SignalType != SignalTypeEnum.None)
                {
                    current.ProfitCut = startValue * (1 - config.RegularProfitCut);
                    current.LossCut = startValue * (1 - config.RegularLossCut);
                    current.SignalWeight = 1f;

                    int maxDaysHoldingPos = m_configurator.Configuration.MaxDaysHoldingPos;
                    current.DaysToClose = maxDaysHoldingPos -( index + 1);

                    //Count MaxDays to close 
                    int countDays = Math.Min(index + 1, maxDaysHoldingPos);
                    FirstCalculatorResult signaledResult = current;
                    signaledResult.DateClose = DateTime.MinValue;
                    signaledResult.PositionStartValue = startValue;

                    for (int a = 0; a < countDays; a++)
                    {
                        FirstCalculatorResult closeResult = calculatorResults[index - a];
                        //Check miss by high to start
                        signaledResult.ProfitPer = 1 - closeResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.High / startValue;
                        float profitFromDaylyOpen = 1 - closeResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Open / startValue;
                        signaledResult.PositionEndValue = (1 - signaledResult.ProfitPer) * startValue;
                        //float profitCheck = 1 - signaledResult.PositionEndValue / startValue;
                        if (signaledResult.ProfitPer < config.RegularLossCut)
                        {
                            //lossCut
                            signaledResult.ProfitPer = config.RegularLossCut;
                            if (profitFromDaylyOpen < config.RegularLossCut)
                            {
                                signaledResult.ProfitPer = profitFromDaylyOpen;
                            }
                            signaledResult.PositionEndValue = (1 - signaledResult.ProfitPer) * startValue;
                            //float profitCheck = 1-signaledResult.PositionEndValue/startValue;
                            signaledResult.DateClose = closeResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                            signaledResult.SignalResult = SignalResultEnum.Miss;
                            break;
                        }
                        //Check hit by close to start
                        signaledResult.ProfitPer = 1 - closeResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close / startValue;
                        signaledResult.PositionEndValue = (1 - signaledResult.ProfitPer) * startValue;
                        if (signaledResult.ProfitPer > config.RegularProfitCut)
                        {
                            //ProfitCut
                            signaledResult.ProfitPer = config.RegularProfitCut;
                            signaledResult.PositionEndValue = (1 - signaledResult.ProfitPer) * startValue;
                            //float profitCheck = 1 - signaledResult.PositionEndValue / startValue;
                            signaledResult.DateClose = closeResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                            signaledResult.SignalResult = SignalResultEnum.Hit;
                            break;
                        }
                    }

                    //Check for maxDays to close position
                    if (countDays >= maxDaysHoldingPos && signaledResult.DateClose == DateTime.MinValue)
                    {
                        signaledResult.SignalResult = signaledResult.ProfitPer < 0 ? SignalResultEnum.Miss : SignalResultEnum.Hit;
                        signaledResult.DateClose = calculatorResults[index - (countDays - 1)].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                    }
                }
            }
            //Remove multiple signals
            SystemManyToSymbolHelper.RemoveProfitSymbolIntersections(calculatorResults);

            //Uses options calculation
            if (config.UseOptionCalculation) SystemOptionsHelper.CalculateOptionsDataIvNoFloorNoCellingShorts(
                  calculatorResults,
                  config.VolatilityConstant,
                  config.DaysToOptionMaturity,
                  config.OptionsChangeCall,
                  config.OptionsChangePut,
                  config.OptionsWeightCall,
                  config.OptionsWeightPut);
            return calculatorResults;
        }
        #endregion (------  Protected Methods  ------)
    }
}
