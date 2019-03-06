using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoraFinanceAnalyzer4.UI.Controls
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