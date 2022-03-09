using System;
using AnignoraCommonAndHelpers;
using AnignoraUI.Grids.DataGridViewAuto;
using AnignoraUI.Grids.DataGridViewAuto.Attributes;

namespace AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.GeneralSymbols
{
    public class GeneralSymbolItem : IDataGridViewAutoRowItem
    {
        [Header("Symbol", 50)]
        [StringColor("XIV", KnownColorsArgb.White_Argb, CommonUi.Afa5_VixVxx_Background_Argb, true)]
        [StringColor("VXX", KnownColorsArgb.White_Argb, CommonUi.Afa5_VixVxx_Background_Argb, true)]
        public string SymbolName { get; set; }

        [Header("Daily Change", 52)]
        [StringFormat("0.00%")]
        [RangeColor(-100, 0, KnownColorsArgb.Pink_Argb,CommonUi.Afa5_Background_Argb)]
        [RangeColor(0, 100, KnownColorsArgb.LightGreen_Argb,CommonUi.Afa5_Background_Argb)]
        public float DailyChange { get; set; }

        [Header("Close", 48)]
        [StringFormat("0.00")]
        public float Close { get; set; }
        
        [Header("Date",63)]
        [StringFormat("dd/MM")]
        public DateTime ReadDate { get; set; }

        [Header("R1", 30)]
        public int R1 { get; set; }

        [Header("R2%", 40)]
        [StringFormat("0.00")]
        public float R2Per { get; set; }

        public object[] GetValuesArray()
        {
            return new object[]{SymbolName,DailyChange,Close,ReadDate,R1,R2Per};
        }
    }
}
