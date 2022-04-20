using AnignoLibrary.UI.Forms;
using System.Windows.Forms;

namespace FinanceAnalizer3.UI
{
    public class FormBase : formGradientBase
    {
        public FormBase()
        {
            base.Text = Application.ProductName;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(400, 392);
            this.Color1 = System.Drawing.SystemColors.Control;
            this.Color2 = System.Drawing.SystemColors.ControlDark;
            this.Name = "FormBase";
            this.ResumeLayout(false);

        }
    }
}
