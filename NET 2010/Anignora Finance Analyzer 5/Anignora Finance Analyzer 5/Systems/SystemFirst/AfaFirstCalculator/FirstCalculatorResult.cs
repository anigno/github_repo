using System;
using AfaDataExtraction;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;

namespace AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator
{
    public class FirstCalculatorResult
    {
        #region (------  Constructors  ------)
        public FirstCalculatorResult(FirstAnalyzeResult p_firstAnalyzeResult)
            : this()
        {
            if (p_firstAnalyzeResult == null) throw new NullReferenceException("parameter p_firstAnalyzeResult cannot be null");
            FirstAnalyzeResultItem = p_firstAnalyzeResult;
        }

        public FirstCalculatorResult()
        {
            DateClose = ExtractionCommon.DATE_MINIMUM;
        }
        #endregion (------  Constructors  ------)

        #region (------  Properties  ------)

        public float PositionEndValue { get; set; }
        public float PositionStartValue { get; set; }

        //public SignalResultTypeEnum SignalResultType { get; set; }

        //public int DeltaDaysMarket { get; set; }

        public string ExtraData { get; set; }

        public float IntraPer { get; set; }

        public float Contango { get; set; }

        public float ContangoAverage { get; set; }

        public DateTime DateClose { get; set; }

        public FirstAnalyzeResult FirstAnalyzeResultItem { get; private set; }

        public float LossCut { get; set; }

        public float ProfitCut { get; set; }

        public float ProfitPer { get; set; }

        public SignalResultEnum SignalResult { get; set; }

        public SignalTypeEnum SignalType { get; set; }

        public float SignalWeight { get; set; }

        public float CIntraStart { get; set; }

        public float DrawDownLocal { get; set; }
        public float MaxLossLocal { get; set; }
        public float MaxProfit { get; set; }
        public int DaysToClose { get; set; }

        #endregion (------  Properties  ------)

        #region (------  Public Methods  ------)
        public string ToReportString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}" + Environment.NewLine,
                                 FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead.ToShortDateString(),
                                 SignalType,
                                 SignalResult,
                                 ProfitPer,
                                 ProfitCut,
                                 LossCut,
                                 FirstAnalyzeResultItem.SymbolExtractedDataItem.Close,
                                 FirstAnalyzeResultItem.SymbolExtractedDataItem.High,
                                 FirstAnalyzeResultItem.SymbolExtractedDataItem.Low,
                                 DateClose,
                                 ContangoAverage,
                                 DrawDownLocal,
                                 MaxLossLocal,
                                 MaxProfit,
                                 FirstAnalyzeResultItem.SymbolExtractedDataItem.MovAvgDiff
                );
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1} {2} {3}", FirstAnalyzeResultItem, SignalType, SignalResult, ProfitPer);
        }
        #endregion (------  Public Methods  ------)
    }
}