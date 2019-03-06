using System.Linq;
using AnignoraDataTypes.Configurations;
using AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew;
using AnignoraFinanceAnalyzer5.MainManagement;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;

namespace AnignoraFinanceAnalyzer5.Systems.SystemsExtended
{
    public class AfaSystemCIntraDayShort<T> : AfaSystemFirstBase<T> where T : CIntraDayShortConfiguration, new()
    {
		#region (------  Fields  ------)
        private readonly ConfiguratorXml<T> m_configurator;
        private readonly ContangoManager m_contangoManager;
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public AfaSystemCIntraDayShort(string p_username, int p_key, string p_filename, ContangoManager p_contangoManager)
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
            get { return m_configurator.Configuration.ProfitSymbol;  }
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
            FirstCalculatorResult[] results = p_symbolExtractedDataArray.Select(p_exData => new FirstCalculatorResult(new FirstAnalyzeResult(p_exData))).ToArray();
            //Calculate signals and profits
            for (int index = 0; index < results.Length - 1; index++)
            {
                FirstCalculatorResult current = results[index];
                FirstCalculatorResult previous = results[index + 1];
                previous.Contango = m_contangoManager.GetContangoValue(previous.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead);
                current.Contango = m_contangoManager.GetContangoValue(current.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead);

                float startValue = AfaSystemContangoHelper.SetSignalContangoShorts(current, previous, config);

                if (current.SignalType != SignalTypeEnum.None)
                {
                    current.ProfitCut = startValue*(1 - config.RegularProfitCut);
                    current.LossCut = startValue*(1 - config.RegularLossCut);
                    current.SignalWeight = 1f;
                    current.DateClose = current.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                    //Check miss
                    current.ProfitPer = 1 - current.FirstAnalyzeResultItem.SymbolExtractedDataItem.High / startValue;
                    if (current.ProfitPer < config.RegularLossCut)
                    {
                        //lossCut
                        current.ProfitPer = config.RegularLossCut;
                    }
                    else
                    {
                        //Check hit
                        current.ProfitPer = 1 - current.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close/startValue;
                        if (current.ProfitPer > config.RegularProfitCut)
                        {
                            //ProfitCut
                            current.ProfitPer = config.RegularProfitCut;
                        }
                    }
                    current.SignalResult = current.ProfitPer < 0 ? SignalResultEnum.Miss : SignalResultEnum.Hit;
                }
            }
            return results;
        }


        #endregion (------  Protected Methods  ------)
    }
}
