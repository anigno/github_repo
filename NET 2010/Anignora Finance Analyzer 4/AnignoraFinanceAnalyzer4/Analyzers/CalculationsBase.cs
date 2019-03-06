using AnignoraFinanceAnalyzer4.Data;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;

namespace AnignoraFinanceAnalyzer4.Analyzers
{
    public abstract class CalculationsBase
    {
		#region (------  Public Methods  ------)

        public abstract void CalculateAll(string descriptor,SymbolDailyDataAnalyzed[] dayChanges);

		#endregion (------  Public Methods  ------)
    }
}