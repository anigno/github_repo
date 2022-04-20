using System.Windows.Forms;
using System.Drawing;

namespace FinanceAnalizer3.UI
{
    public class DataGridViewAsList : DataGridView
    {
		#region (------------------  Constructors  ------------------)
        public DataGridViewAsList()
        {
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToOrderColumns = true;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EditMode = DataGridViewEditMode.EditProgrammatically;
            Location = new Point(12, 359);
            ReadOnly = true;
            RowHeadersVisible = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MultiSelect=false;
            DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Overridden Methods  ------------------)
        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);
            e.Column.SortMode = DataGridViewColumnSortMode.Programmatic;
            e.Column.Resizable = DataGridViewTriState.True;
        }
		#endregion (------------------  Overridden Methods  ------------------)


		#region (------------------  Public Methods  ------------------)
        /// <summary>
        /// Returns the row containing the value in the column
        /// </summary>
        public int GetRowIndex(string columnName, object value)
        {
            foreach (DataGridViewRow row in Rows)
            {
                if (row.Cells[columnName].Value == value) return row.Index;
            }
            return -1;
        }

        public void SetRowBackColor(int i, Color color)
        {
            Rows[i].DefaultCellStyle.BackColor=color;
        }
		#endregion (------------------  Public Methods  ------------------)
    }
}
