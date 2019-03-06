using System;
using AnignoraCommonAndHelpers;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraUI.Grids.DataGridViewAuto;
using AnignoraUI.Grids.DataGridViewAuto.Attributes;

namespace AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.ActiveSymbols
{
    public class ActiveSymbolItem :IDataGridViewAutoRowItem
    {
        [Header("Symbol", 55)]
        [StringColor("XIV", KnownColorsArgb.White_Argb, CommonUi.Afa5_VixVxx_Background_Argb , true)]
        [StringColor("VXX", KnownColorsArgb.White_Argb, CommonUi.Afa5_VixVxx_Background_Argb, true)]
        public string SymbolName { get; set; }
        [Header("Daily Change", 55)]
        [StringFormat("0.00%")]
        [RangeColor(-100, 0, KnownColorsArgb.Pink_Argb, CommonUi.Afa5_Background_Argb)]
        [RangeColor(0, 100, KnownColorsArgb.LightGreen_Argb, CommonUi.Afa5_Background_Argb)]
        public float DailyChangeRecent { get; set; }
        [Header("Profit", 58)]
        [StringFormat("0.00%")]
        [StringHide("0.00%")]
        [RangeColor(-100, 0, KnownColorsArgb.Pink_Argb, CommonUi.Afa5_Background_Argb)]
        [RangeColor(0, 100, KnownColorsArgb.LightGreen_Argb, CommonUi.Afa5_Background_Argb)]
        public float Profit { get; set; }
        [Header("Signal Type", 45)]
        public SignalTypeEnum SignalType { get; set; }
        [Header("Signal Weight", 50)]
        [StringFormat("0.%")]
        public float SignalWeight { get; set; }
        [Header("Signal Date", 45)]
        [StringFormat("dd/MM")]
        public DateTime SignalDate { get; set; }
        [Header("Signal Result", 47)]
        [StringHide("None")]
        public SignalResultEnum SignalResult { get; set; }
        [Header("Closed Date", 50)]
        [StringFormat("dd/MM")]
        [StringHide("01/01")]
        public DateTime ClosedDate { get; set; }
        [Header("PCut", 45)]
        [StringFormat("0.00")]
        [StringHide("0.00")]
        public float ProfitCut { get; set; }
        [Header("TSCut", 45)]
        [StringFormat("0.00")]
        [StringHide("0.00")]
        public float LossCut { get; set; }

        [Header("Ctg", 60)]
        [StringFormat("0.00")]
        [StringHide("0.00")]
        public float Contango { get; set; }
        //[Header("I%", 60)]
        //[StringFormat("0.00")]
        //[StringHide("0.00")]
        //public float IPER { get; set; }

        [Header("DTC", 60)]
        public float DaysToClose { get; set; }

        public virtual object[] GetValuesArray()
        {
            return new object[] { SymbolName, DailyChangeRecent, Profit, SignalType, SignalWeight, SignalDate, SignalResult, ClosedDate, ProfitCut, LossCut, Contango,/* IPER,*/ DaysToClose };
        }
    }
}
