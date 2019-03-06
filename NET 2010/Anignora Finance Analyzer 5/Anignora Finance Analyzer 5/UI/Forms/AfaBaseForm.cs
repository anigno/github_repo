using System.Windows.Forms;

namespace AnignoraFinanceAnalyzer5.UI.Forms
{
    public class AfaBaseForm:Form
    {

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AfaBaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Name = "AfaBaseForm";
            this.ResumeLayout(false);

        }
    }
}
