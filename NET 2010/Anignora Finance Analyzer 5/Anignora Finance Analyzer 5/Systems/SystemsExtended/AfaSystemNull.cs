using System.Linq;
using AfaDataExtraction;
using AnignoraDataTypes.Configurations;
using AnignoraFinanceAnalyzer5.Configurators.Configuration;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;

namespace AnignoraFinanceAnalyzer5.Systems.SystemsExtended
{
    public class AfaSystemNull<T> : AfaSystemBase where T : AfaSystemConfigurationBase, new()
    {
        private readonly ConfiguratorXml<AfaSystemNullConfiguration> m_afaSystemNullConfigurator;

        public AfaSystemNull(string p_filename)
        {
            m_afaSystemNullConfigurator = new ConfiguratorXml<AfaSystemNullConfiguration>(p_filename);
            m_afaSystemNullConfigurator.Load();
        }


        public override int MaxDaysHoldingPos
        {
            get { return 0; }
        }

        public override float RegularMultiplier
        {
            get { return 1f; }
        }


        public override string[] SymbolsWebNames
        {
            get { return m_afaSystemNullConfigurator.Configuration.SymbolsNames; }
        }

        public override string SystemName
        {
            get { return m_afaSystemNullConfigurator.Configuration.SystemName; }
        }

        public override string[] ProfitSymbol
        {
            get { return new string[0]; }
        }

        public override bool IsSystemActive
        {
            get { return true; }
        }

        public override float GetSignalWeight(FirstCalculatorResult p_result)
        {
            return 0;
        }

      

        protected override FirstCalculatorResult[] StartProcessingSpecific(string p_symbolName, SymbolExtractedData[] p_symbolExtractedDataArray)
        {
            FirstCalculatorResult[] firstCalculatorResults = p_symbolExtractedDataArray.
                Select(p =>
                           {
                               FirstAnalyzeResult firstAnalyzeResult = new FirstAnalyzeResult(p);
                               FirstCalculatorResult firstCalculatorResult = new FirstCalculatorResult(firstAnalyzeResult);
                               return firstCalculatorResult;
                           }

                ).ToArray();
            return firstCalculatorResults;
        }

        public override void CreateProfitSignalsReport(string p_reportPath)
        {
            
        }
    }
}