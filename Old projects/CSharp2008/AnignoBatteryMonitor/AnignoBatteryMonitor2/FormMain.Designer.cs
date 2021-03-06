namespace AnignoBatteryMonitor2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.labelClose = new System.Windows.Forms.Label();
            this.labelCurrentPower = new System.Windows.Forms.Label();
            this.labelRemainingTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "???% ??:??";
            this.notifyIconMain.Visible = true;
            // 
            // labelClose
            // 
            this.labelClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClose.AutoSize = true;
            this.labelClose.Location = new System.Drawing.Point(112, 3);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(14, 13);
            this.labelClose.TabIndex = 0;
            this.labelClose.Text = "X";
            // 
            // labelCurrentPower
            // 
            this.labelCurrentPower.AutoSize = true;
            this.labelCurrentPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelCurrentPower.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelCurrentPower.Location = new System.Drawing.Point(39, 16);
            this.labelCurrentPower.Name = "labelCurrentPower";
            this.labelCurrentPower.Size = new System.Drawing.Size(48, 17);
            this.labelCurrentPower.TabIndex = 1;
            this.labelCurrentPower.Text = "???%";
            // 
            // labelRemainingTime
            // 
            this.labelRemainingTime.AutoSize = true;
            this.labelRemainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelRemainingTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelRemainingTime.Location = new System.Drawing.Point(39, 33);
            this.labelRemainingTime.Name = "labelRemainingTime";
            this.labelRemainingTime.Size = new System.Drawing.Size(49, 17);
            this.labelRemainingTime.TabIndex = 2;
            this.labelRemainingTime.Text = "??:??";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(127, 66);
            this.Controls.Add(this.labelRemainingTime);
            this.Controls.Add(this.labelCurrentPower);
            this.Controls.Add(this.labelClose);
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Text = "ABM2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label labelCurrentPower;
        private System.Windows.Forms.Label labelRemainingTime;
    }
}

