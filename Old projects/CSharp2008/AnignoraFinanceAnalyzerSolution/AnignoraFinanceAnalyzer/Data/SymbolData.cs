using System.Collections.Generic;

namespace AnignoraFinanceAnalyzer.Data
{
    public class SymbolData
    {
        public string Descriptor { get; set; }
        public List<DayChangeDataAnalyzed> DaysChangesList { get; set; }
    }
}
