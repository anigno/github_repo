using System;
using FinanceAnalizer3.Data;
using System.Windows.Forms;

namespace FinanceAnalizer3.UI
{
    public partial class FormSettings : FormBase
    {
        #region (------------------  Constructors  ------------------)
        public FormSettings()
        {
            InitializeComponent();
        }
        #endregion (------------------  Constructors  ------------------)


        #region (------------------  Event Handlers  ------------------)
        private void buttonOK_Click(object sender, EventArgs e)
        {
            DataManager.Instance.LoginPassword = textBoxPassword.Text;
            DataManager.Instance.SetStocksInHeader(richTextBoxHeaderSymbols.Text);
            DataManager.Instance.PositionsSum = (int)numericUpDownPositionSumK.Value * 1000;
            DataManager.Instance.PositionsDevider = (int)numericUpDownPositionDevider.Value;
            DataManager.Instance.BrowserAHomePage = textBoxBrowserAHomePage.Text;
            DataManager.Instance.BrowserBHomePage = textBoxBrowserBHomePage.Text;
            Close();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            textBoxPassword.Text = DataManager.Instance.LoginPassword;
            richTextBoxChangeSet.LoadFile("ChangeSet.txt", RichTextBoxStreamType.PlainText);
            richTextBoxHeaderSymbols.Text = "";
            string[] stockesInHeader = DataManager.Instance.GetStockesInHeader();
            foreach (string stockName in stockesInHeader)
            {
                richTextBoxHeaderSymbols.Text += stockName + "\n";
            }
            numericUpDownPositionSumK.Value = (decimal)DataManager.Instance.PositionsSum / 1000;
            numericUpDownPositionDevider.Value = (decimal)DataManager.Instance.PositionsDevider;
            textBoxBrowserAHomePage.Text = DataManager.Instance.BrowserAHomePage;
            textBoxBrowserBHomePage.Text = DataManager.Instance.BrowserBHomePage;
        }
        #endregion (------------------  Event Handlers  ------------------)
    }
}