using System;

namespace AnignoraFinanceAnalyzer5.Systems
{
    public class ProfitCalculationItem
    {
        public DateTime DateRead { get; set; }
        public float ProfitDaily { get; set; }
        
        public int LongHits { get; set; }
        public float LongHitsProfit { get; set; }
        public int LongMisses { get; set; }
        public float LongMissesProfit { get; set; }

        public int ShortHits { get; set; }
        public float ShortHitsProfit { get; set; }
        public int ShortMisses { get; set; }
        public float ShortMissesProfit { get; set; }

        //public int ActiveSignals { get; set; }

        public ProfitCalculationItem(DateTime p_dateRead)
        {
            DateRead = p_dateRead;
        }
    }
}
