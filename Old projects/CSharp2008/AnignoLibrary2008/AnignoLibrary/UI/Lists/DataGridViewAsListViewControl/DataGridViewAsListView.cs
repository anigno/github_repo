using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AnignoLibrary.UI.Lists.DataGridViewAsListViewControl
{
    public class DataGridViewAsListView : DataGridView
    {
        private const string CATEGORY_STRING = " DataGridViewAsListView";
        public DataGridViewAsListView()
        {
            RowHeadersVisible = false;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows=false;
        }

        #region Properties
        [Browsable(false)]
        public new bool AllowUserToAddRows
        {
            get { return false; }
            set { base.AllowUserToAddRows=false; }
        }

        [Browsable(false)]
        public new bool AllowUserToDeleteRows
        {
            get { return false; }
            set { base.AllowUserToDeleteRows = false; }
        }

        [Category(CATEGORY_STRING)]
        [Browsable(false)]
        public new bool RowHeadersVisible
        {
            get { return false; }
            set { base.RowHeadersVisible = false; }
        }

        #endregion

        #region Public

        public void SetRowColor(DataGridViewRow row, Color backColor, Color foreColor)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.BackColor = backColor;
                cell.Style.ForeColor = foreColor;
            }
        }

        #endregion

    }
}
