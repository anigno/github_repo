using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinanceAnalizer3.Data;

namespace FinanceAnalizer3.UI
{
    public partial class FormReports : FormBase
    {
        public FormReports()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            richTextBoxResults.Text = DataManager.Instance.GenerateHitsMissesReport(dateTimePickerFrom.Value, dateTimePickerTo.Value);
        }
    }
}
