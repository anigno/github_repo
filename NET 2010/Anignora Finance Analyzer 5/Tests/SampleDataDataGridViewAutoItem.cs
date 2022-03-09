using System;
using System.Windows.Forms;
using AnignoraCommonAndHelpers;
using AnignoraUI.Grids.DataGridViewAuto;
using AnignoraUI.Grids.DataGridViewAuto.Attributes;

namespace Tests
{
    public class SampleDataDataGridViewAutoItem : IDataGridViewAutoRowItem
    {
        [Header("String Value",100)]
        [StringColor("Second", KnownColorsArgb.Yellow_Argb, KnownColorsArgb.Blue_Argb, true)]
        [StringColor("Second", KnownColorsArgb.LightGreen_Argb, KnownColorsArgb.DarkBlue_Argb, false)]
        public string StringValue { get; set; }

        [Header("Integer Value", 70)]
        [RangeColor(2, 4, KnownColorsArgb.Green_Argb, KnownColorsArgb.Gray_Argb)]
        [RangeColor(4, 7, KnownColorsArgb.LightGreen_Argb, KnownColorsArgb.Gray_Argb)]
        public int IntValue { get; set; }

        [Header("Float Value", 80)]
        [StringFormat("0.00")]
        [CellAlignment(DataGridViewContentAlignment.TopLeft)]
        public float FloatValue { get; set; }

        [Header("DateTime Value", 200)]
        [CellAlignment(DataGridViewContentAlignment.BottomRight)]
        public DateTime DateTimeValue { get; set; }

        public object[] GetValuesArray()
        {
            return new object[]{StringValue,IntValue,FloatValue,DateTimeValue};
        }
    }
}
