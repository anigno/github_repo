using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;

namespace AnignoraFinanceAnalyzer5.Systems
{
    public interface IActiveSymbolsManager
    {
        event ActiveSymbolsManager.ActiveSymbolChangedDelegate ActiveSymbolAdded;
        event ActiveSymbolsManager.ActiveSymbolChangedDelegate ActiveSymbolRemoved;
        event ActiveSymbolsManager.ActiveSymbolChangedDelegate ActiveSymbolUpdated;
        FirstCalculatorResult[] GetCurrentActiveSymbols();
        void UpdateActiveSymbols(string p_symbolnName, FirstCalculatorResult[] p_results, int p_maxDays, string p_systemName);
    }
}