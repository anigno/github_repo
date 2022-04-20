namespace AnignoraFinanceAnalyzer.UI.Forms
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucBrowserSimple1 = new AnignoraFinanceAnalyzer.UI.Controls.ucBrowserSimple();
            this.SuspendLayout();
            // 
            // ucBrowserSimple1
            // 
            this.ucBrowserSimple1.HomePage = "www.google.com";
            this.ucBrowserSimple1.Location = new System.Drawing.Point(37, 119);
            this.ucBrowserSimple1.Name = "ucBrowserSimple1";
            this.ucBrowserSimple1.Size = new System.Drawing.Size(505, 216);
            this.ucBrowserSimple1.TabIndex = 0;
            this.ucBrowserSimple1.Url = "www.google.com";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 572);
            this.Controls.Add(this.ucBrowserSimple1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AnignoraFinanceAnalyzer.UI.Controls.ucBrowserSimple ucBrowserSimple1;
    }
}

