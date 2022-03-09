using System;
using System.Windows.Forms;
using FinanceAnalizer3.Data;
using LoggingProvider;

namespace FinanceAnalizer3.UI
{
    public partial class FormAddStocks : FormBase
    {
		#region (------------------  Constructors  ------------------)
        public FormAddStocks()
        {
            Logger.Log();
            InitializeComponent();
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Event Handlers  ------------------)
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Logger.Log();
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Logger.Log();
            string[] seperator={"\n","\t"};
            string[] sa=richTextBoxStocks.Text.Split(seperator,StringSplitOptions.RemoveEmptyEntries);
            foreach (string stockDescriptor in sa)
            {
                Result result = DataManager.Instance.AddStockName(stockDescriptor);
                if (!result.Succeeded)
                {
                    Logger.LogWarning("Could not add stock name: {0}", stockDescriptor);
                }
                else
                {
                    Logger.LogDebug("Added stock name: {0}", stockDescriptor);
                }
            }
            Close();
        }
		#endregion (------------------  Event Handlers  ------------------)
    }
}