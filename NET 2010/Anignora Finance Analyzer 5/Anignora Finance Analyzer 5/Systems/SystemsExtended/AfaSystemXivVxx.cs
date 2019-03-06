using System;
using System.Linq;
using AfaDataExtraction;
using AnignoraDataTypes.Configurations;
using AnignoraFinanceAnalyzer5.Configurators.Configuration;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;

namespace AnignoraFinanceAnalyzer5.Systems.SystemsExtended
{
    [Obsolete]
    public class AfaSystemXivVxx : AfaSystemFirstBase<AfaSystemXivVxxConfiguration>
    {
        private readonly ConfiguratorXml<AfaSystemXivVxxConfiguration> m_configurator;

        public AfaSystemXivVxx(string p_username, int p_key, string p_filename)
            : base(p_username, p_key, p_filename, true, false)
        {
            m_configurator = new ConfiguratorXml<AfaSystemXivVxxConfiguration>(p_filename);
            m_configurator.Load();
        }

        public override int MaxDaysHoldingPos
        {
            get { return m_configurator.Configuration.MaxDaysHoldingPos; }
        }

        public override float RegularMultiplier
        {
            get { return m_configurator.Configuration.RegularMultiplier ; }
        }

        public override string[] SymbolsWebNames
        {
            get { return m_configurator.Configuration.SymbolsNames; }
        }

        public override string SystemName
        {
            get { return m_configurator.Configuration.SystemName; }
        }

        public override string[] ProfitSymbol
        {
            get { return new string[0]; }
        }

        public override bool IsSystemActive
        {
            get { return m_configurator.Configuration.IsSystemActive; }
        }

        public override float GetSignalWeight(FirstCalculatorResult p_result)
        {
            throw new NotImplementedException();
        }

        private bool isAllSymbolsHasData()
        {
            foreach (string symbolName in SymbolsWebNames)
            {
                var results = GetSymbolCalculatedResults(symbolName);
                if (results == null || results.Length < 20) return false;
            }
            return true;
        }

        protected override FirstCalculatorResult[] StartProcessingSpecific(string p_symbolName, SymbolExtractedData[] p_symbolExtractedDataArray)
        {
            //Create results from extracted data
            FirstAnalyzeResult[] firstAnalyzeResults = p_symbolExtractedDataArray.Select(p => new FirstAnalyzeResult(p)).ToArray();
            FirstCalculatorResult[] firstCalculatorResults = firstAnalyzeResults.Select(p => new FirstCalculatorResult(p)).ToArray();
            if (!isAllSymbolsHasData()) return firstCalculatorResults;
            //not all symbols has data
            return new FirstCalculatorResult[0];
        }

        public override void CreateProfitSignalsReport(string p_reportsPath)
        {
            throw new NotImplementedException();
        }
    }
}
