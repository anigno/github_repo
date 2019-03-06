namespace AnignoBatteryMonitor
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
            this.labelPower = new System.Windows.Forms.Label();
            this.labelCharging = new System.Windows.Forms.Label();
            this.labelTimeRemain = new System.Windows.Forms.Label();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // labelPower
            // 
            this.labelPower.AutoSize = true;
            this.labelPower.Location = new System.Drawing.Point(33, 9);
            this.labelPower.Name = "labelPower";
            this.labelPower.Size = new System.Drawing.Size(33, 13);
            this.labelPower.TabIndex = 0;
            this.labelPower.Text = "???%";
            // 
            // labelCharging
            // 
            this.labelCharging.AutoSize = true;
            this.labelCharging.Location = new System.Drawing.Point(12, 9);
            this.labelCharging.Name = "labelCharging";
            this.labelCharging.Size = new System.Drawing.Size(10, 13);
            this.labelCharging.TabIndex = 2;
            this.labelCharging.Text = ".";
            // 
            // labelTimeRemain
            // 
            this.labelTimeRemain.AutoSize = true;
            this.labelTimeRemain.Location = new System.Drawing.Point(72, 9);
            this.labelTimeRemain.Name = "labelTimeRemain";
            this.labelTimeRemain.Size = new System.Drawing.Size(34, 13);
            this.labelTimeRemain.TabIndex = 3;
            this.labelTimeRemain.Text = "??:??";
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Battery Monitor";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.Click += new System.EventHandler(this.notifyIconMain_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(115, 29);
            this.Controls.Add(this.labelTimeRemain);
            this.Controls.Add(this.labelCharging);
            this.Controls.Add(this.labelPower);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.Text = "Battery Monitor";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPower;
        private System.Windows.Forms.Label labelCharging;
        private System.Windows.Forms.Label labelTimeRemain;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
    }
}

