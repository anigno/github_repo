using System.Windows.Forms;
using AnignoraUI.Grids.DataGridViewAuto.Attributes;

namespace AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.ActiveSymbols
{
    public class ActiveSymbolItemMain : ActiveSymbolItem
    {
        [Header("System", 95)]
        public string SystemName { get; set; }

        public override object[] GetValuesArray()
        {
            return new object[] { SystemName, SymbolName, DailyChangeRecent, Profit, SignalType, SignalWeight, SignalDate, SignalResult, ClosedDate, ProfitCut, LossCut, Contango,/* IPER ,*/DaysToClose};
        }

    }
}
