using System.Windows.Forms;

namespace AnignoraFinanceAnalyzer5.UI.Controls
{
    public partial class ucNumPer : UserControl
    {
        public ucNumPer()
        {
            InitializeComponent();
        }

        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                labelNumber.Text = value.ToString();
            }
        }

        private float percentage;
        public float Percentage
        {
            get { return percentage; }
            set
            {
                percentage = value;
                labelPer.Text = (value * 100).ToString("0.00");
            }
        }
    }
}