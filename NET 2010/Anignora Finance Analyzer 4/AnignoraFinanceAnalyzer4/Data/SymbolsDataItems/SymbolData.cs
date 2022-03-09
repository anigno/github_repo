using System;
using System.Collections.Generic;

namespace AnignoraFinanceAnalyzer4.Data.SymbolsDataItems
{
    public class SymbolData
    {
		#region (------  Constructors  ------)

        public SymbolData(string p_descriptor)
        {
            DailyDataList = new List<SymbolDailyDataAnalyzed>();
            LastUpdateTryTime = DateTime.MinValue;
            Descriptor = p_descriptor;
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        /// <summary>
        /// Analyzed data for each date
        /// </summary>
        public List<SymbolDailyDataAnalyzed> DailyDataList { get; set; }

        public string Descriptor{ get; private set;}

        /// <summary>
        /// Local time, last try to extract data
        /// </summary>
        public DateTime LastUpdateTryTime { get; set; }

		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)

        public static string RemovePreSymbol(string p_descriptor)
        {
            int a = p_descriptor.IndexOf(":");
            if (a < 0) return p_descriptor;
            return p_descriptor.Substring(a + 1);
        }

		#endregion (------  Public Methods  ------)
    }
}
