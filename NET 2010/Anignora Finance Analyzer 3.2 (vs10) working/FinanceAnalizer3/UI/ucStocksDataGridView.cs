using System;
using System.Drawing;
using System.Windows.Forms;
using FinanceAnalyzerData.Data;

namespace FinanceAnalizer3.UI
{
    public partial class ucStocksDataGridView : UserControl
    {
		#region (------------------  Const Fields  ------------------)
        const string CATEGORY_STRING = " ucStocksDataGridView";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private readonly Color COLOR_ONE_POS = Color.Green;
        private readonly Color COLOR_ONE_NEG = Color.Red;
        private readonly Color COLOR_ONE_NAT = Color.Black;
        private readonly Color COLOR_SIGNALED_LONG_BACKGROUND = Color.LightGreen;
        private readonly Color COLOR_SIGNALED_SHORT_BACKGROUND = Color.Pink;
        private readonly Color COLOR_SIGNALED_NAT_BACKGROUND = Color.WhiteSmoke;
        private readonly Color COLOR_HIT = Color.Yellow;
        private readonly Color COLOR_MISS = Color.Gold;
        private readonly Color COLOR_SIGNALED_LONG = Color.YellowGreen;
        private readonly Color COLOR_SIGNALED_SHORT = Color.Salmon;
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public ucStocksDataGridView()
        {
            InitializeComponent();
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Events  ------------------)
        public event EventHandler SelectionChanged;
		#endregion (------------------  Events  ------------------)


		#region (------------------  Event Handlers  ------------------)
        private void dataGridViewAsListStocks_Click(object sender, EventArgs e)
        {
            if (SelectionChanged != null) SelectionChanged(sender, e);
        }

        private void dataGridViewAsListStocks_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectionChanged != null) SelectionChanged(sender, e);
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Private Methods  ------------------)
        private Color GetModifiedColor(Color color,int change)
        {
            return Color.FromArgb((color.R + change) % 256, (color.G + change) % 256, (color.B + change) % 256);
        }

        private void SetColors(DayChangeDataAnalyzed dayChange,DataGridViewRow row )
        {
            //AnalizedOne
            if (dayChange.AnalizedOne == 1)
            {
                row.Cells["ColumnOne"].Style.SelectionForeColor = row.Cells["ColumnOne"].Style.ForeColor = COLOR_ONE_POS;
            }
            if (dayChange.AnalizedOne == -1)
            {
                row.Cells["ColumnOne"].Style.SelectionForeColor = row.Cells["ColumnOne"].Style.ForeColor = COLOR_ONE_NEG;
            }
            if (dayChange.AnalizedOne == 0)
            {
                row.Cells["ColumnOne"].Style.SelectionForeColor = row.Cells["ColumnOne"].Style.ForeColor = COLOR_ONE_NAT;
            }
            //AnalizedTwo
            if (dayChange.AnalizedTwo == 1)
            {
                row.Cells["ColumnTwo"].Style.SelectionForeColor = row.Cells["ColumnTwo"].Style.ForeColor = COLOR_ONE_POS;
            }
            if (dayChange.AnalizedTwo == -1)
            {
                row.Cells["ColumnTwo"].Style.SelectionForeColor = row.Cells["ColumnTwo"].Style.ForeColor = COLOR_ONE_NEG;
            }
            if (dayChange.AnalizedTwo == 0)
            {
                row.Cells["ColumnTwo"].Style.SelectionForeColor = row.Cells["ColumnTwo"].Style.ForeColor = COLOR_ONE_NAT;
            }
            //Hit
            if (dayChange.Hit == DayChangeDataAnalyzed.HitStateEnum.Hit)
            {
                row.Cells["ColumnHit"].Style.SelectionBackColor = row.Cells["ColumnHit"].Style.BackColor = COLOR_HIT;
            }
            if (dayChange.Hit == DayChangeDataAnalyzed.HitStateEnum.Miss)
            {
                row.Cells["ColumnHit"].Style.SelectionBackColor = row.Cells["ColumnHit"].Style.BackColor = COLOR_MISS;
            }
            if (dayChange.Hit == DayChangeDataAnalyzed.HitStateEnum.None)
            {
                row.Cells["ColumnHit"].Style.SelectionBackColor = row.Cells["ColumnHit"].Style.BackColor = row.Cells["ColumnName"].Style.BackColor;
            }
            //SignalType
            if (dayChange.SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Long)
            {
                row.Cells["ColumnSignaled"].Style.SelectionBackColor=row.Cells["ColumnSignaled"].Style.BackColor = COLOR_SIGNALED_LONG;
                row.DefaultCellStyle.BackColor = COLOR_SIGNALED_LONG_BACKGROUND;
                row.DefaultCellStyle.SelectionBackColor = GetModifiedColor(row.DefaultCellStyle.BackColor, -30);
            }
            if (dayChange.SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Short)
            {
                row.Cells["ColumnSignaled"].Style.SelectionBackColor = row.Cells["ColumnSignaled"].Style.BackColor = COLOR_SIGNALED_SHORT;
                row.DefaultCellStyle.BackColor = COLOR_SIGNALED_SHORT_BACKGROUND;
                row.DefaultCellStyle.SelectionBackColor = GetModifiedColor(row.DefaultCellStyle.BackColor, -30);
            }
            if (dayChange.SignalType == DayChangeDataAnalyzed.SignalTypeEnum.None)
            {
                row.Cells["ColumnSignaled"].Style.SelectionBackColor = row.Cells["ColumnSignaled"].Style.BackColor = row.Cells["ColumnName"].Style.BackColor;
                row.DefaultCellStyle.BackColor = COLOR_SIGNALED_NAT_BACKGROUND;
                row.DefaultCellStyle.SelectionBackColor = GetModifiedColor(row.DefaultCellStyle.BackColor, -30);
            }
            //DailyChangePer
            if (dayChange.DailyChangePer < 0)
            {
                row.Cells["ColumnDailyChangePer"].Style.SelectionForeColor = row.Cells["ColumnDailyChangePer"].Style.ForeColor = COLOR_ONE_NEG;
            }
            if (dayChange.DailyChangePer >= 0)
            {
                row.Cells["ColumnDailyChangePer"].Style.SelectionForeColor = row.Cells["ColumnDailyChangePer"].Style.ForeColor = COLOR_ONE_POS;
            }


        }
		#endregion (------------------  Private Methods  ------------------)


		#region (------------------  Public Methods  ------------------)
        public int AddRow(DayChangeDataAnalyzed dayChange)
        {
            //Protect from closing issue
            if(dataGridViewAsListStocks.Columns.Count==0)return -1;
            int rowIndex = dataGridViewAsListStocks.Rows.Add(
                dayChange.StockDescriptor,
                dayChange.Date.ToShortDateString(),
                dayChange.High,
                dayChange.Low,
                dayChange.Close,
                dayChange.DailyChangePer.ToString("0.##") + "%",
                dayChange.AnalizedOne,
                dayChange.AnalizedTwo,
                dayChange.AnalyzedTwoPer.ToString("0.##") + "%",
                dayChange.QuantityForPos,
                dayChange.SignalType == DayChangeDataAnalyzed.SignalTypeEnum.None ? "" : dayChange.SignalType + " " + dayChange.SignalToDateChangePer.ToString("0.##") + "%",
                dayChange.Hit == DayChangeDataAnalyzed.HitStateEnum.None ? "" : dayChange.Hit+" "+dayChange.HitMissChangePer.ToString("0.##") + "%",
                dayChange.TimeAnalyzed,
                dayChange.fTest
                );
            SetColors(dayChange, dataGridViewAsListStocks.Rows[rowIndex]);
            return rowIndex;
        }

        public void ClearRows()
        {
            dataGridViewAsListStocks.Rows.Clear();
        }

        /// <summary>
        /// Returns the row containing the value in the column
        /// </summary>
        public int GetRowIndex(string columnName, object value)
        {
            return dataGridViewAsListStocks.GetRowIndex(columnName, value);
        }

        /// <summary>
        /// Returns the selected stock name if found, else returns null
        /// </summary>
        public string GetSelectedStock()
        {
            if(dataGridViewAsListStocks.SelectedRows.Count==0)return null;
            return dataGridViewAsListStocks.SelectedRows[0].Cells["ColumnName"].Value.ToString();
        }

        public void RemoveRow(int rowIndex)
        {
            dataGridViewAsListStocks.Rows.RemoveAt(rowIndex);
        }

        public void SetColumnsVisible(bool visible, params string[] columnsNames)
        {
            foreach (string columnName in columnsNames)
            {
                dataGridViewAsListStocks.Columns[columnName].Visible = visible;
            }
        }

        public void UpdateRow(int rowIndex,DayChangeDataAnalyzed dayChange)
        {
            if(rowIndex>=dataGridViewAsListStocks.Rows.Count)return;
            if (rowIndex < 0) return;
            DataGridViewRow row = dataGridViewAsListStocks.Rows[rowIndex];
            UpdateRow(row, dayChange);
            SetColors(dayChange, row);
        }

        public void UpdateRow(DataGridViewRow row, DayChangeDataAnalyzed dayChange)
        {
            row.Cells["ColumnName"].Value = dayChange.StockDescriptor;
            row.Cells["ColumnDate"].Value = dayChange.Date.ToShortDateString();
            row.Cells["ColumnHigh"].Value = dayChange.High;
            row.Cells["ColumnLow"].Value = dayChange.Low;
            row.Cells["ColumnClose"].Value = dayChange.Close;
            row.Cells["ColumnDailyChangePer"].Value = dayChange.DailyChangePer.ToString("0.##") + "%";
            row.Cells["ColumnOne"].Value = dayChange.AnalizedOne;
            row.Cells["ColumnTwo"].Value = dayChange.AnalizedTwo;
            row.Cells["ColumnTwoPer"].Value = dayChange.AnalyzedTwoPer.ToString("0.##") + "%";
            row.Cells["ColumnQualtityForPosition"].Value = dayChange.QuantityForPos ;
            row.Cells["ColumnSignaled"].Value = dayChange.SignalType == DayChangeDataAnalyzed.SignalTypeEnum.None ?  "" : dayChange.SignalType + " " + dayChange.SignalToDateChangePer.ToString("0.##") + "%"; 
            row.Cells["ColumnHit"].Value = dayChange.Hit == DayChangeDataAnalyzed.HitStateEnum.None ? "" : dayChange.Hit+" "+ dayChange.HitMissChangePer.ToString("0.##") + "%";
            row.Cells["ColumnTimeAnalyzed"].Value = dayChange.TimeAnalyzed;
            row.Cells["ColumnTest"].Value = dayChange.fTest;
        }
		#endregion (------------------  Public Methods  ------------------)
    }
}
