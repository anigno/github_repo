using AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.ActiveSymbols;
using AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.GeneralSymbols;
using AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.HistorySymbols;

namespace AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific
{
    partial class UserControlSystem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.userControlGeneralSymbols = new UserControlGeneralSymbols();
            this.userControlActiveSymbols = new UserControlActiveSymbols();
            this.userControlHystorySymbols = new UserControlHystorySymbols();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.userControlGeneralSymbols);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.userControlActiveSymbols);
            this.splitContainer1.Size = new System.Drawing.Size(1015, 257);
            this.splitContainer1.SplitterDistance = 417;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.userControlHystorySymbols);
            this.splitContainer2.Size = new System.Drawing.Size(1015, 640);
            this.splitContainer2.SplitterDistance = 257;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 4;
            // 
            // userControlGeneralSymbols
            // 
            this.userControlGeneralSymbols.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userControlGeneralSymbols.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlGeneralSymbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlGeneralSymbols.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.userControlGeneralSymbols.Location = new System.Drawing.Point(0, 0);
            this.userControlGeneralSymbols.Margin = new System.Windows.Forms.Padding(5);
            this.userControlGeneralSymbols.Name = "userControlGeneralSymbols";
            this.userControlGeneralSymbols.Size = new System.Drawing.Size(413, 253);
            this.userControlGeneralSymbols.TabIndex = 1;
            // 
            // userControlActiveSymbols
            // 
            this.userControlActiveSymbols.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userControlActiveSymbols.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlActiveSymbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlActiveSymbols.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.userControlActiveSymbols.Location = new System.Drawing.Point(0, 0);
            this.userControlActiveSymbols.Margin = new System.Windows.Forms.Padding(5);
            this.userControlActiveSymbols.Name = "userControlActiveSymbols";
            this.userControlActiveSymbols.Size = new System.Drawing.Size(589, 253);
            this.userControlActiveSymbols.TabIndex = 0;
            // 
            // userControlHystorySymbols
            // 
            this.userControlHystorySymbols.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userControlHystorySymbols.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userControlHystorySymbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlHystorySymbols.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.userControlHystorySymbols.Location = new System.Drawing.Point(0, 0);
            this.userControlHystorySymbols.Margin = new System.Windows.Forms.Padding(5);
            this.userControlHystorySymbols.Name = "userControlHystorySymbols";
            this.userControlHystorySymbols.Size = new System.Drawing.Size(1011, 374);
            this.userControlHystorySymbols.TabIndex = 2;
            // 
            // UserControlSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlSystem";
            this.Size = new System.Drawing.Size(1015, 640);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ActiveSymbols.UserControlActiveSymbols userControlActiveSymbols;
        private GeneralSymbols.UserControlGeneralSymbols userControlGeneralSymbols;
        private HistorySymbols.UserControlHystorySymbols userControlHystorySymbols;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}
