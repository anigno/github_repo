namespace AnignoLaptopBatteryMonitor
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
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anignoProgressBarMinutes = new AnignoLibrary.UI.ProgressBars.AnignoProgressBar();
            this.anignoProgressBarPower = new AnignoLibrary.UI.ProgressBars.AnignoProgressBar();
            this.contextMenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripMain;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Laptop Battery Monitor";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseClick);
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(92, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // anignoProgressBarMinutes
            // 
            this.anignoProgressBarMinutes.BackColor = System.Drawing.Color.Transparent;
            this.anignoProgressBarMinutes.BackgroundColorFirst = System.Drawing.Color.Lime;
            this.anignoProgressBarMinutes.BackgroundColorSecond = System.Drawing.Color.Red;
            this.anignoProgressBarMinutes.BarColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.anignoProgressBarMinutes.BarColorSecond = System.Drawing.Color.Blue;
            this.anignoProgressBarMinutes.BarGradientAngle = 30F;
            this.anignoProgressBarMinutes.BarOrientation = System.Windows.Forms.Orientation.Vertical;
            this.anignoProgressBarMinutes.BorderColor = System.Drawing.Color.Black;
            this.anignoProgressBarMinutes.BorderDraw = false;
            this.anignoProgressBarMinutes.CornerRadious = 10F;
            this.anignoProgressBarMinutes.ForeColor = System.Drawing.Color.Yellow;
            this.anignoProgressBarMinutes.GradientAngle = 90F;
            this.anignoProgressBarMinutes.Location = new System.Drawing.Point(63, 17);
            this.anignoProgressBarMinutes.Maximum = 240F;
            this.anignoProgressBarMinutes.Minimum = 0F;
            this.anignoProgressBarMinutes.Name = "anignoProgressBarMinutes";
            this.anignoProgressBarMinutes.Size = new System.Drawing.Size(28, 160);
            this.anignoProgressBarMinutes.TabIndex = 5;
            this.anignoProgressBarMinutes.Text = "240m";
            this.anignoProgressBarMinutes.Value = 240F;
            // 
            // anignoProgressBarPower
            // 
            this.anignoProgressBarPower.BackColor = System.Drawing.Color.Transparent;
            this.anignoProgressBarPower.BackgroundColorFirst = System.Drawing.Color.Lime;
            this.anignoProgressBarPower.BackgroundColorSecond = System.Drawing.Color.Red;
            this.anignoProgressBarPower.BarColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.anignoProgressBarPower.BarColorSecond = System.Drawing.Color.Blue;
            this.anignoProgressBarPower.BarGradientAngle = 30F;
            this.anignoProgressBarPower.BarOrientation = System.Windows.Forms.Orientation.Vertical;
            this.anignoProgressBarPower.BorderColor = System.Drawing.Color.Black;
            this.anignoProgressBarPower.BorderDraw = false;
            this.anignoProgressBarPower.CornerRadious = 10F;
            this.anignoProgressBarPower.ForeColor = System.Drawing.Color.Yellow;
            this.anignoProgressBarPower.GradientAngle = 90F;
            this.anignoProgressBarPower.Location = new System.Drawing.Point(29, 17);
            this.anignoProgressBarPower.Maximum = 100F;
            this.anignoProgressBarPower.Minimum = 0F;
            this.anignoProgressBarPower.Name = "anignoProgressBarPower";
            this.anignoProgressBarPower.Size = new System.Drawing.Size(28, 160);
            this.anignoProgressBarPower.TabIndex = 4;
            this.anignoProgressBarPower.Text = "100%";
            this.anignoProgressBarPower.Value = 100F;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(120, 195);
            this.Controls.Add(this.anignoProgressBarMinutes);
            this.Controls.Add(this.anignoProgressBarPower);
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.Text = "Anigno Laptop Battery Monitor";
            this.Controls.SetChildIndex(this.anignoProgressBarPower, 0);
            this.Controls.SetChildIndex(this.anignoProgressBarMinutes, 0);
            this.contextMenuStripMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private AnignoLibrary.UI.ProgressBars.AnignoProgressBar anignoProgressBarMinutes;
        private AnignoLibrary.UI.ProgressBars.AnignoProgressBar anignoProgressBarPower;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

