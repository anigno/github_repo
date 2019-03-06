using System;
using AnignoraCommonAndHelpers;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using AnignoraUI.Grids.DataGridViewAuto.Attributes;

namespace AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.HistorySymbols
{
    internal class AfaSystemFirstHistorySymbolGridRow : IHistoryGridRowItem
    {
        public object[] GetValuesArray()
        {
            return new object[] { SymbolName, ExtraData, ReadDate, Open, Close, High, Low, DailyChange, Profit, SignalType, SignalWeight, SignalResult, ClosedDate,DDL,MovAvgDiff,MaxProfit,MaxLossLocal, One, Two, TwoPer, ProfitCut, LossCut, ContangoAverage, Contango, IntraPer, CStart };
        }

        [Header("Symbol", 50)]
        public string SymbolName { get; set; }

        [Header("EXtra", 60)]
        public string ExtraData { get; set; }

        [Header("Read Date", 70)]
        [StringFormat("dd/MM/yy")]
        public DateTime ReadDate { get; set; }


        [Header("Open", 60)]
        [StringFormat("0.00")]
        public float Open { get; set; }
        [Header("Close", 60)]
        [StringFormat("0.00")]
        public float Close { get; set; }
        [Header("High", 60)]
        [StringFormat("0.00")]
        public float High { get; set; }
        [Header("Low", 60)]
        [StringFormat("0.00")]
        public float Low { get; set; }
        [Header("Daily Change", 60)]
        [StringFormat("0.00%")]
        [RangeColor(-100, 0, KnownColorsArgb.Pink_Argb, CommonUi.Afa5_Background_Argb)]
        [RangeColor(0, 100, KnownColorsArgb.LightGreen_Argb, CommonUi.Afa5_Background_Argb)]
        public float DailyChange { get; set; }
        [Header("Profit", 60)]
        [StringFormat("0.00%")]
        [StringHide("0.00%")]
        [RangeColor(-100, 0, KnownColorsArgb.Pink_Argb, CommonUi.Afa5_Background_Argb)]
        [RangeColor(0, 100, KnownColorsArgb.LightGreen_Argb, CommonUi.Afa5_Background_Argb)]
        public float Profit { get; set; }
        [Header("Signal Type", 45)]
        [StringHide("None")]
        public SignalTypeEnum SignalType { get; set; }
        [Header("Signal Weight", 50)]
        [StringFormat("0.%")]
        [StringHide("0%")]
        public float SignalWeight { get; set; }
        [Header("Signal Result", 60)]
        [StringHide("None")]
        public SignalResultEnum SignalResult { get; set; }
        [Header("Closed Date", 70)]
        [StringFormat("dd/MM/yy")]
        [StringHide("01/01/01")]
        public DateTime ClosedDate { get; set; }



        [Header("DDL", 60)]
        [StringFormat("0.00")]
        [StringHide("0.00")]
        public float DDL { get; set; }
        [Header("MAD", 60)]
        [StringFormat("0.00")]
        [StringHide("0.00")]
        public float MovAvgDiff { get; set; }
        [Header("MaxProfit%", 60)]
        [StringFormat("0.00")]
        [StringHide("0.00")]
        public float MaxProfit { get; set; }
        [Header("MaxLossL%", 60)]
        [StringFormat("0.00")]
        [StringHide("0.00")]
        public float MaxLossLocal { get; set; }





        [Header("One", 60)]
        public int One { get; set; }
        [Header("Two", 60)]
        public int Two { get; set; }
        [Header("TwoPer", 60)]
        [StringFormat("0.00%")]
        [StringHide("0.00%")]
        public float TwoPer { get; set; }
        [Header("PCut", 60)]
        [StringFormat("0.00")]
        [StringHide("0.00")]
        public float ProfitCut { get; set; }
        [Header("LCut", 60)]
        [StringFormat("0.00")]
        [StringHide("0.00")]
        public float LossCut { get; set; }

        [Header("CtgA", 60)]
        [StringFormat("0.00%")]
        [StringHide("0.00%")]
        public float ContangoAverage { get; set; }
        [Header("Ctg", 60)]
        [StringFormat("0.00")]
        //[StringHide("0.00")]
        public float Contango { get; set; }
        [Header("I%", 60)]
        [StringFormat("0.00")]
        //[StringHide("0.00")]
        public float IntraPer { get; set; }
        [Header("CSt", 60)]
        [StringFormat("0.00")]
        [StringHide("0.00")]
        public float CStart { get; set; }

     
      

        public void SetValuesFromCalculatorResult(FirstCalculatorResult p_calculatorResult)
        {
            FirstCalculatorResult r = p_calculatorResult;

            ExtraData = r.ExtraData;

            SymbolName=r.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName;
            ReadDate=r.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
            Open = r.FirstAnalyzeResultItem.SymbolExtractedDataItem.Open;
            Close=r.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;

            High = r.FirstAnalyzeResultItem.SymbolExtractedDataItem.High;
            Low = r.FirstAnalyzeResultItem.SymbolExtractedDataItem.Low;

            DailyChange=r.FirstAnalyzeResultItem.SymbolExtractedDataItem.DailyChangePerSignaled;
            Profit=r.ProfitPer;
            SignalType=r.SignalType;
            SignalWeight=r.SignalWeight;
            SignalResult=r.SignalResult;
            ClosedDate = r.DateClose;

            One = r.FirstAnalyzeResultItem.AnalyzedOne;
            Two = r.FirstAnalyzeResultItem.AnalyzedTwo;
            TwoPer = r.FirstAnalyzeResultItem.AnalyzedTwoPer/100;

            ProfitCut = r.ProfitCut;
            LossCut = r.LossCut;

            ContangoAverage = p_calculatorResult.ContangoAverage;

            Contango = p_calculatorResult.Contango;
            IntraPer = p_calculatorResult.IntraPer;

            CStart = p_calculatorResult.CIntraStart;

            MovAvgDiff = p_calculatorResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.MovAvgDiff;

            DDL = p_calculatorResult.DrawDownLocal;
            MaxProfit = p_calculatorResult.MaxProfit;
            MaxLossLocal = p_calculatorResult.MaxLossLocal;
        }

        public AfaSystemFirstHistorySymbolGridRow(FirstCalculatorResult p_calculatorResult)
        {
            SetValuesFromCalculatorResult(p_calculatorResult);
        }
    
    }
}