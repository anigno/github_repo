using System;
using AnignoraCommonAndHelpers;

namespace AfaDataExtraction
{
    public class SymbolExtractedData : UniqueIdBase
    {
		#region (------  Constructors  ------)
        public SymbolExtractedData(string p_symbolWebName)
        {
            WebName = p_symbolWebName;
            TimeExtracted = DateRead = ExtractionCommon.DATE_MINIMUM;
        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public float Close { get; set; }

        public DateTime DateRead { get; set; }

        public float High { get; set; }

        public float Low { get; set; }

        public float Open { get; set; }

        public DateTime TimeExtracted { get; set; }

        public string WebName { get; set; }

        public float DailyChangePerSignaled { get; set; }

        public float DailyChangePerRecent { get; set; }

        public float Volume { get; set; }

        public float MovAvgDiff { get; set; }

        #endregion (------  Properties  ------)

		#region (------  Public Methods  ------)
        public override string ToString()
        {
            return string.Format("{0} {1} close:{2} DailyChangePerRecent:{3} [H:{4} L:{5} O:{6}]", WebName, DateRead.ToShortDateString(), Close, DailyChangePerRecent,High,Low,Open);
        }
		#endregion (------  Public Methods  ------)
    }
}
