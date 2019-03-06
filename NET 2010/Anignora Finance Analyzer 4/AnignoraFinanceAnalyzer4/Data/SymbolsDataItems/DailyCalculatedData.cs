using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnignoraFinanceAnalyzer4.Data.SymbolsDataItems
{
    /// <summary>
    /// Used when calculating history
    /// </summary>
    public class DailyCalculatedData
    {
        public int Longs;
        public int Shorts;
        public float DailyChangePer;
        public float DailyDeltaPer;
    }
}
