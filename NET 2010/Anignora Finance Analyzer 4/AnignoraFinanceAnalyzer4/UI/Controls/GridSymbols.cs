using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnignoraDataTypes;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using System;
using AnignoraUI.Grids.GridLists;

namespace AnignoraFinanceAnalyzer4.UI.Controls
{
    public class GridSymbols : GridListView
    {
		#region (------  Fields  ------)

        private static readonly Color COLOR_BACKGROUND = Color.FromArgb(64, 64, 64);
        private static readonly Color COLOR_BACKGROUND_SELECTED = Color.FromArgb(120, 120, 120);
        private static readonly Color COLOR_FOREGROUND = Color.White;
        private static readonly Color COLOR_HIT = Color.DarkBlue;
        private static readonly Color COLOR_HIT_BACKGROUND = Color.FromArgb(192, 255, 255);
        private static readonly Color COLOR_MISS = Color.DarkBlue;
        private static readonly Color COLOR_MISS_BACKGROUND = Color.FromArgb(255, 255, 192);
        private static readonly Color COLOR_NEGATIVE = Color.Pink;
        private static readonly Color COLOR_POSITIVE = Color.LightGreen;
        private static readonly Color COLOR_SIGNALED_LONG = Color.Green;
        private static readonly Color COLOR_SIGNALED_LONG_BACKGROUND = Color.LightGreen;
        private static readonly Color COLOR_SIGNALED_SHORT = Color.Red;
        private static readonly Color COLOR_SIGNALED_SHORT_BACKGROUND = Color.Pink;
        private static readonly Color COLOR_STATE = Color.DarkBlue;
        private static readonly Color COLOR_STATE_BACKGROUND = Color.AliceBlue;
        private static readonly Color COLOR_STATE_NEGATIVE = Color.Red;
        private static readonly Color COLOR_STATE_POSITIVE = Color.Green;

		#endregion (------  Fields  ------)

		#region (------  Public Methods  ------)

        /// <summary>
        /// Update if Symbol's Date exists, else add
        /// </summary>
        public void AddUpdateSymbolRow(SymbolDailyDataAnalyzed p_dailyData,bool p_isMatchDate)
        {
            string[] sa = getUpdateStringArray(p_dailyData.Descriptor, p_dailyData);
            foreach(DataGridViewRow row in Rows)
            {
                SymbolDailyDataAnalyzed data = (SymbolDailyDataAnalyzed) row.Tag;
                if (data.Descriptor == p_dailyData.Descriptor && (data.ReadDate.Date == p_dailyData.ReadDate.Date || !p_isMatchDate))
                {
                    UpdateRow(row,sa);
                    SetColors(row);
                    row.Tag = p_dailyData;
                    return;
                }
            }
            DataGridViewRow newRow= AddRow(sa);
            newRow.Tag = p_dailyData;
            SetColors(newRow);
            Sort(Columns[0],ListSortDirection.Ascending);
        }

        public void RemoveIfExistDescriptorAndDate(SymbolDailyDataAnalyzed p_symbolData)
        {
            DataGridViewRow rowToRemove = null;
            foreach (DataGridViewRow row in Rows)
            {
                SymbolDailyDataAnalyzed data = (SymbolDailyDataAnalyzed)row.Tag;
                if (p_symbolData.Descriptor == data.Descriptor && p_symbolData.ReadDate.Date == data.ReadDate.Date)
                {
                    rowToRemove = row;
                    break;
                }
            }
            if(rowToRemove!=null)Rows.Remove(rowToRemove);
        }

        public void SetColumnsVisible(bool p_visible, params string[] p_columnsNames)
        {
            p_columnsNames.DoForAll(c => Columns[c].Visible = p_visible);
        }

        public void SetSelected(string p_descriptor)
        {
            ClearSelection();
            foreach (DataGridViewRow row in Rows)
            {
                SymbolDailyDataAnalyzed symbolData = row.Tag as SymbolDailyDataAnalyzed;
                if (symbolData == null) return;
                if (symbolData.Descriptor == p_descriptor)
                {
                    row.Selected = true;
                }
            }
        }

		#endregion (------  Public Methods  ------)

		#region (------  Protected Methods  ------)

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (DesignMode) return;
            DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dictionary<string, int> columnsDescriptors = new Dictionary<string, int>
                                                             {
                                                                 {"Symbol", 50},
                                                                 {"QFP", 40},
                                                                 {"Date", 70},
                                                                 {"Daily%", 50},
                                                                 {"DailyR%", 50},
                                                                 {"Total%", 70},
                                                                 {"Signal", 60},
                                                                 {"State", 100},
                                                                 {"DoublerDate", 100},
                                                                 {"High", 50},
                                                                 {"Low", 50},
                                                                 {"Close", 50},
                                                                 {"One", 40},
                                                                 {"Two", 40},
                                                                 {"Two%", 40},
                                                                 {"LastUpdate", 120},
                                                                 {"Id",50},
                                                                 {"MFI_A",100},
                                                                 {"MFI_B",100}
                                                             };

            AddColumns(columnsDescriptors);
            //foreach(DataGridViewColumn c in Columns)
            //{
            //    Debug.WriteLine(c.Index+","+ c.Name);
            //}
        }

		#endregion (------  Protected Methods  ------)

		#region (------  Private Methods  ------)

        private string[] getUpdateStringArray(string descriptor, SymbolDailyDataAnalyzed dailyData)
        {
            string sSignalToDatePer=(dailyData.SignalToDateChangePer*100).ToString("0.00");
            if (dailyData.SignalToDateChangePer == 0) sSignalToDatePer = "";
            if(dailyData.SignalType==SymbolDailyDataAnalyzed.SignalTypeEnum.None)
            {
                sSignalToDatePer = "";
            }
            else if (dailyData.SignalHitMiss != SymbolDailyDataAnalyzed.SignalHitMissEnum.None)
            {
                if (dailyData.SignalToDateChangePer == 0) sSignalToDatePer = "0.00";
                sSignalToDatePer += " " + dailyData.SignalHitMiss;
            }


            string[] sa = {
                             SymbolData.RemovePreSymbol(descriptor),
                             dailyData.QFP.ToString(),
                             dailyData.ReadDate.ToShortDateString(),
                             (dailyData.DailyChangePer*100).ToString("0.00"),
                             (dailyData.DailyChangePerRecent*100).ToString("0.00"),
                             sSignalToDatePer,
                             dailyData.SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.None ? "" : dailyData.SignalType.ToString(),
                             dailyData.SignalState == SymbolDailyDataAnalyzed.SignalStateEnum.Waiting ? "" : dailyData.SignalState + " " + dailyData.ConditionedDate.ToShortDateString(),
                             dailyData.DoublerFirstDate==DateTime.MinValue?"":dailyData.DoublerFirstDate.ToShortDateString(),
                             dailyData.High.ToString(),
                             dailyData.Low.ToString(),
                             dailyData.Close.ToString(),
                             dailyData.AnalizedOne.ToString(),
                             dailyData.AnalizedTwo.ToString(),
                             dailyData.AnalyzedTwoPer.ToString("0.00"),
                             dailyData.TimeAnalyzed.ToString(),
                             dailyData.UniqueId.ToString(),
                             dailyData.MoneyFlowIndexA.ToString("0.00"),
                             dailyData.MoneyFlowIndexB.ToString("0.00")
                         };
            return sa;
        }

        private void SetColors(DataGridViewRow p_row)
        {
            SymbolDailyDataAnalyzed d = (SymbolDailyDataAnalyzed) p_row.Tag;
            p_row.DefaultCellStyle.BackColor = COLOR_BACKGROUND;
            p_row.DefaultCellStyle.SelectionBackColor = COLOR_BACKGROUND_SELECTED;

            p_row.Cells["Signal"].Style.BackColor = COLOR_BACKGROUND;
            p_row.Cells["Signal"].Style.SelectionBackColor = COLOR_BACKGROUND_SELECTED;
            if (d.SignalType==SymbolDailyDataAnalyzed.SignalTypeEnum.Long)
            {
                p_row.Cells["Signal"].Style.BackColor = COLOR_SIGNALED_LONG_BACKGROUND;
                p_row.Cells["Signal"].Style.ForeColor = COLOR_SIGNALED_LONG;
                p_row.Cells["Signal"].Style.SelectionBackColor = COLOR_SIGNALED_LONG_BACKGROUND;
                p_row.Cells["Signal"].Style.SelectionForeColor = COLOR_SIGNALED_LONG;
            }
            if (d.SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.Short)
            {
                p_row.Cells["Signal"].Style.BackColor = COLOR_SIGNALED_SHORT_BACKGROUND;
                p_row.Cells["Signal"].Style.ForeColor = COLOR_SIGNALED_SHORT;
                p_row.Cells["Signal"].Style.SelectionBackColor = COLOR_SIGNALED_SHORT_BACKGROUND;
                p_row.Cells["Signal"].Style.SelectionForeColor = COLOR_SIGNALED_SHORT;
            }

            p_row.Cells["DoublerDate"].Style.BackColor = COLOR_BACKGROUND;
            p_row.Cells["DoublerDate"].Style.SelectionBackColor = COLOR_BACKGROUND_SELECTED;
            p_row.Cells["DoublerDate"].Style.ForeColor = COLOR_FOREGROUND;
            p_row.Cells["DoublerDate"].Style.SelectionForeColor = COLOR_FOREGROUND;
            if (d.DoublerFirstDate.Date == DateTime.Now.Date)
            {
                p_row.Cells["DoublerDate"].Style.BackColor = p_row.Cells["Signal"].Style.BackColor;
                p_row.Cells["DoublerDate"].Style.SelectionBackColor = p_row.Cells["Signal"].Style.SelectionBackColor;
                p_row.Cells["DoublerDate"].Style.ForeColor = p_row.Cells["Signal"].Style.ForeColor;
                p_row.Cells["DoublerDate"].Style.SelectionForeColor = p_row.Cells["Signal"].Style.SelectionForeColor;
            }


            if (d.DailyChangePerRecent >= 0)
            {
                p_row.Cells["DailyR%"].Style.ForeColor = COLOR_POSITIVE;
                p_row.Cells["DailyR%"].Style.SelectionForeColor = COLOR_POSITIVE;
            }
            else
            {
                p_row.Cells["DailyR%"].Style.ForeColor = COLOR_NEGATIVE;
                p_row.Cells["DailyR%"].Style.SelectionForeColor = COLOR_NEGATIVE;
            }
            

            if(d.DailyChangePer>=0)
            {
                p_row.Cells["Daily%"].Style.ForeColor = COLOR_POSITIVE;
                p_row.Cells["Daily%"].Style.SelectionForeColor = COLOR_POSITIVE;
            }
            else
            {
                p_row.Cells["Daily%"].Style.ForeColor = COLOR_NEGATIVE;
                p_row.Cells["Daily%"].Style.SelectionForeColor = COLOR_NEGATIVE;
            }
            if (d.SignalHitMiss==SymbolDailyDataAnalyzed.SignalHitMissEnum.Hit)
            {
                p_row.Cells["Total%"].Style.BackColor = COLOR_HIT_BACKGROUND;
                p_row.Cells["Total%"].Style.ForeColor = COLOR_HIT;
                p_row.Cells["Total%"].Style.SelectionBackColor = COLOR_HIT_BACKGROUND;
                p_row.Cells["Total%"].Style.SelectionForeColor = COLOR_HIT;
            }
            if (d.SignalHitMiss == SymbolDailyDataAnalyzed.SignalHitMissEnum.Miss)
            {
                p_row.Cells["Total%"].Style.BackColor = COLOR_MISS_BACKGROUND;
                p_row.Cells["Total%"].Style.ForeColor = COLOR_MISS;
                p_row.Cells["Total%"].Style.SelectionBackColor = COLOR_MISS_BACKGROUND;
                p_row.Cells["Total%"].Style.SelectionForeColor = COLOR_MISS;
            }
            if (d.SignalHitMiss == SymbolDailyDataAnalyzed.SignalHitMissEnum.None)
            {
                if (d.SignalToDateChangePer > 0)
                {
                    p_row.Cells["Total%"].Style.ForeColor = COLOR_STATE_POSITIVE;
                    p_row.Cells["Total%"].Style.SelectionForeColor = COLOR_STATE_POSITIVE;
                    p_row.Cells["Total%"].Style.BackColor = COLOR_STATE_BACKGROUND;
                    p_row.Cells["Total%"].Style.SelectionBackColor = COLOR_STATE_BACKGROUND;
                }
                if (d.SignalToDateChangePer < 0)
                {
                    p_row.Cells["Total%"].Style.ForeColor = COLOR_STATE_NEGATIVE;
                    p_row.Cells["Total%"].Style.SelectionForeColor = COLOR_STATE_NEGATIVE;
                    p_row.Cells["Total%"].Style.BackColor = COLOR_STATE_BACKGROUND;
                    p_row.Cells["Total%"].Style.SelectionBackColor = COLOR_STATE_BACKGROUND;
                }
            }
            p_row.Cells["State"].Style.BackColor = COLOR_BACKGROUND;
            p_row.Cells["State"].Style.SelectionBackColor = COLOR_BACKGROUND_SELECTED;

            if(d.SignalState!=SymbolDailyDataAnalyzed.SignalStateEnum.Waiting)
            {
                p_row.Cells["State"].Style.SelectionBackColor = COLOR_STATE_BACKGROUND;
                p_row.Cells["State"].Style.BackColor = COLOR_STATE_BACKGROUND;
                p_row.Cells["State"].Style.SelectionForeColor = COLOR_STATE;
                p_row.Cells["State"].Style.ForeColor = COLOR_STATE;
            }

        }

		#endregion (------  Private Methods  ------)
    }
}
