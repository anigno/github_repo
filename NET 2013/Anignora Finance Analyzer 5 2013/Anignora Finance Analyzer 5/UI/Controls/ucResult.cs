using System.Windows.Forms;

namespace AnignoraFinanceAnalyzer5.UI.Controls
{
    public partial class ucResult : UserControl
    {
        public ucResult()
        {
            InitializeComponent();
        }

        public ucNumPer Longs
        {
            get { return ucNumPerLongs; }
        }
        public ucNumPer Shorts
        {
            get { return ucNumPerShorts; }
        }
        public ucNumPer Total
        {
            get { return ucNumPerTotal; }
        }

    }
}