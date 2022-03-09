using System;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using AnignoraUI.Grids.DataGridViewAuto;

namespace AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.HistorySymbols
{
    public interface IHistoryGridRowItem :IDataGridViewAutoRowItem
    {

        string SymbolName { get; set; }

        DateTime ReadDate { get; set; }

        float Close { get; set; }

        void SetValuesFromCalculatorResult(FirstCalculatorResult p_calculatorResult);

    }
}
