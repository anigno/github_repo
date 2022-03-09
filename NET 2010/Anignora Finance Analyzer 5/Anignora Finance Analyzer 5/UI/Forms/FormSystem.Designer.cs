using AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific;

namespace AnignoraFinanceAnalyzer5.UI.Forms
{
    partial class FormSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSystem));
            this.userControlSystemMain = new UserControlSystem();
            this.SuspendLayout();
            // 
            // userControlSystemMain
            // 
            this.userControlSystemMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userControlSystemMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSystemMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.userControlSystemMain.Location = new System.Drawing.Point(0, 0);
            this.userControlSystemMain.Margin = new System.Windows.Forms.Padding(4);
            this.userControlSystemMain.Name = "userControlSystemMain";
            this.userControlSystemMain.Size = new System.Drawing.Size(884, 578);
            this.userControlSystemMain.TabIndex = 0;
            // 
            // FormSystem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 578);
            this.ControlBox = false;
            this.Controls.Add(this.userControlSystemMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSystem";
            this.Text = "FormSystem";
            this.SizeChanged += new System.EventHandler(this.onFormSystemSizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlSystem userControlSystemMain;
    }
}