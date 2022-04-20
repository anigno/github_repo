using System.Windows.Forms;
using AnignoraFinanceAnalyzer.Data;

namespace AnignoraFinanceAnalyzer.UI.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            Text = CommonParams.ApplicationHeader;
        }
    }
}
