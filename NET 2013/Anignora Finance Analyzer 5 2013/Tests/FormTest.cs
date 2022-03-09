using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tests
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();

          
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(64, 64, 64);
            int i = c.ToArgb();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
