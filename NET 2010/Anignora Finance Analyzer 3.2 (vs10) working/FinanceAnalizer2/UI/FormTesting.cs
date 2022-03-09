using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoggingProvider;

namespace FinanceAnalizer2.UI
{
    public partial class FormTesting : Form
    {

        public const string CONNECTION_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"DAL\\FA2DB.mdb\"";
        private static readonly OleDbConnection connection = new OleDbConnection(CONNECTION_STRING);

        public FormTesting()
        {
            InitializeComponent();
        }

        private void FormTesting_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                //OleDbDataAdapter a = new OleDbDataAdapter(SELECT_STOCKS_NAMES_JOIN_BY_NAME, connection);
                //string s = "SELECT MAX(fldDate) from tblStocksData AS MAX_DATE";
                string s;
                s = "SELECT fldStockName,fldDate FROM tblStocksData,(SELECT MAX(fldDate) AS LastDate FROM (tblStocks LEFT JOIN tblStocksData ON tblStocks.fldStockName=tblStocksData.fldStockName) Group by tblStocks.fldStockName) AS subQ WHERE tblStocksData.fldDate=subQ.LastDate";
                s = "SELECT tblStocksData.fldStockName,tblStocksData.fldDate FROM tblStocksData,(SELECT tblStocks.fldStockName, MAX(fldDate) AS MaxDate from (tblStocks LEFT JOIN tblStocksData ON tblStocks.fldStockName=tblStocksData.fldStockName) group by tblStocks.fldStockName) AS SubQ WHERE tblStocksData.fldStockName=SubQ.fldStockName AND tblStocksData.fldDate=SubQ.MaxDate OR SubQ.MaxDate='12/30/1899'";
                OleDbDataAdapter a = new OleDbDataAdapter(s, connection);
                DataTable ret = new DataTable();
                a.Fill(ret);
                dataGridViewStockData.DataSource=ret;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }
    }
}
