using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinanceAnalizer2.DAL;

namespace FinanceAnalizer2.UI
{
    public partial class FormAddStocks : Form
    {
        public FormAddStocks()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string[] seperator={"\n"};
            string[] sa=richTextBoxStocks.Text.Split(seperator,StringSplitOptions.RemoveEmptyEntries);
            foreach (string stockName in sa)
            {
                DalResult result=DalFa.InsertStockName(stockName);
                if(!result.IsSucceeded)
                {
                    MessageBox.Show(stockName + " Could not be added. " + result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Close();
        }
    }
}
