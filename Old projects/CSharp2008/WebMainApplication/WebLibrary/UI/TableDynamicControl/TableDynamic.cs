using System.Web.UI.WebControls;
using System.Web.UI;

namespace WebLibrary.UI.TableDynamicControl
{
    public class TableDynamic : Table
    {

		#region Fields (1) 


        private int mCount;

		#endregion Fields 

		#region Properties (1) 


        /// <summary>
        /// Gets the number of rows
        /// </summary>
        public int Count
        {
            get { return mCount;}
        }


		#endregion Properties 

		#region Public Methods (5) 

        /// <summary>
        /// Adds new TableRowDynamic to TableDynamic
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(TableRowDynamic row)
        {
            Rows.Add(row);
            mCount++;
        }

        /// <summary>
        /// Adds new TableRowDynamic from parameters to TableDynamic
        /// </summary>
        /// <param name="tag">Any additional data for current row</param>
        /// <param name="rowKey">Search string key </param>
        /// <param name="objs">row displayed objects or strings</param>
        public void AddRow(object tag,string rowKey,params object[] objs)
        {
            TableRowDynamic row = new TableRowDynamic();
            row.Tag=tag;
            row.RowKey = rowKey;
            foreach (object obj in objs)
            {
                TableCell cell = GetDefaultCell();
                if (obj is Control)
                {
                    cell.Controls.Add((Control)obj);
                }
                else
                {
                    cell.Text = obj.ToString();
                }
                row.Cells.Add(cell);
            }
            Rows.Add(row);
            mCount++;
        }

        /// <summary>
        /// Removes a TableRowDynamic by index
        /// </summary>
        /// <param name="rowIndex">row's index</param>
        public void RemoveRow(int rowIndex)
        {
            if(rowIndex<0)return;
            rowIndex++;
            Rows.RemoveAt(rowIndex);
            mCount--;
        }

        /// <summary>
        /// Searce all RowKeys for given keyText
        /// </summary>
        /// <param name="keyText">string to search</param>
        /// <returns>True if found, else false</returns>
        public bool SearchKeyString(string keyText)
        {
            foreach (TableRowDynamic row in Rows)
            {
                if(row.RowKey==keyText)return true;
            }
            return false;
        }

        /// <summary>
        /// Sets TableDynamic's first row as header
        /// </summary>
        /// <param name="headersText">string array of headers</param>
        /// <param name="headersWidth">int array of header's widths</param>
        public void SetHeaders(string[] headersText, int[] headersWidth)
        {
            TableRowDynamic headerRow = new TableRowDynamic();
            headerRow.RowKey=null;
            for (int a = 0; a < headersText.Length; a++)
            {
                TableCell cell = GetDefaultHeaderCell();
                cell.Text = headersText[a];
                if(headersWidth.Length>a)cell.Width = headersWidth[a];
                headerRow.Cells.Add(cell);
            }
            Rows.Add(headerRow);
        }

		#endregion Public Methods 

		#region Protected Methods (2) 

        /// <summary>
        /// Gets a new TableCell with default appearance
        /// </summary>
        /// <returns>New TableCell</returns>
        protected TableCell GetDefaultCell()
        {
            TableCell cell = new TableCell();
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.BorderWidth = 1;
            return cell;
        }

        /// <summary>
        /// Gets a new TableCell with header's default appearance
        /// </summary>
        /// <returns>New TableCell</returns>
        protected TableCell GetDefaultHeaderCell()
        {
            TableCell cell = new TableCell();
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.BorderWidth = 1;
            cell.Font.Bold = true;
            return cell;
        }

		#endregion Protected Methods 

    }
}
