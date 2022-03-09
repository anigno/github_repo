using AfaDataExtraction;

namespace AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer
{
    public class FirstAnalyzeResult :AnalyzerResultBase
    {
		#region (------  Fields  ------)
        readonly SymbolExtractedData m_symbolExtractedData;
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public FirstAnalyzeResult(SymbolExtractedData p_symbolExtractedData)
        {
            m_symbolExtractedData = p_symbolExtractedData;   
        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public int AnalyzedOne { get; set; }

        public int AnalyzedTwo { get; set; }

        public float AnalyzedTwoPer { get; set; }

        public override SymbolExtractedData SymbolExtractedDataItem
        {
            get { return m_symbolExtractedData; }
        }

        public float TypicalPrice { get; set; }

        public float RawMoneyFlow { get; set; }

        #endregion (------  Properties  ------)

		#region (------  Public Methods  ------)
        public override string ToString()
        {
            return string.Format("[{0}] {1} {2} {3:.00}", SymbolExtractedDataItem, AnalyzedOne, AnalyzedTwo, AnalyzedTwoPer);
        }
		#endregion (------  Public Methods  ------)
    }
}
