namespace AnignoDigitalClock
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
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelStopWatch = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxDateTime = new System.Windows.Forms.GroupBox();
            this.timerDateTimeRefresh = new System.Windows.Forms.Timer(this.components);
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerSnap = new System.Windows.Forms.Timer(this.components);
            this.progressBarBatteryLife = new System.Windows.Forms.ProgressBar();
            this.timerBatteryLife = new System.Windows.Forms.Timer(this.components);
            this.labelBattery = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxDateTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelTime.Location = new System.Drawing.Point(12, 36);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(80, 24);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "00:00:00";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelDate.Location = new System.Drawing.Point(8, 16);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(89, 20);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "00/00/0000";
            // 
            // labelStopWatch
            // 
            this.labelStopWatch.AutoSize = true;
            this.labelStopWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelStopWatch.Location = new System.Drawing.Point(14, 16);
            this.labelStopWatch.Name = "labelStopWatch";
            this.labelStopWatch.Size = new System.Drawing.Size(76, 17);
            this.labelStopWatch.TabIndex = 2;
            this.labelStopWatch.Text = "00:00:00.0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.labelStopWatch);
            this.groupBox1.Location = new System.Drawing.Point(-1, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "StopWatch";
            // 
            // buttonReset
            // 
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonReset.Location = new System.Drawing.Point(71, 36);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(26, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "R";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonStop.Location = new System.Drawing.Point(39, 36);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(26, 23);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "[]";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonStart.Location = new System.Drawing.Point(7, 36);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(26, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = ">";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBoxDateTime
            // 
            this.groupBoxDateTime.Controls.Add(this.labelDate);
            this.groupBoxDateTime.Controls.Add(this.labelTime);
            this.groupBoxDateTime.Location = new System.Drawing.Point(-1, 9);
            this.groupBoxDateTime.Name = "groupBoxDateTime";
            this.groupBoxDateTime.Size = new System.Drawing.Size(104, 65);
            this.groupBoxDateTime.TabIndex = 3;
            this.groupBoxDateTime.TabStop = false;
            // 
            // timerDateTimeRefresh
            // 
            this.timerDateTimeRefresh.Enabled = true;
            this.timerDateTimeRefresh.Interval = 250;
            this.timerDateTimeRefresh.Tick += new System.EventHandler(this.timerDateTimeRefresh_Tick);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Anigno Digital Clock";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseClick);
            // 
            // timerSnap
            // 
            this.timerSnap.Interval = 5000;
            this.timerSnap.Tick += new System.EventHandler(this.timerSnap_Tick);
            // 
            // progressBarBatteryLife
            // 
            this.progressBarBatteryLife.ForeColor = System.Drawing.Color.Green;
            this.progressBarBatteryLife.Location = new System.Drawing.Point(-1, 0);
            this.progressBarBatteryLife.Name = "progressBarBatteryLife";
            this.progressBarBatteryLife.Size = new System.Drawing.Size(104, 16);
            this.progressBarBatteryLife.Step = 5;
            this.progressBarBatteryLife.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarBatteryLife.TabIndex = 4;
            this.progressBarBatteryLife.Value = 60;
            // 
            // timerBatteryLife
            // 
            this.timerBatteryLife.Enabled = true;
            this.timerBatteryLife.Interval = 5000;
            this.timerBatteryLife.Tick += new System.EventHandler(this.timerBatteryLife_Tick);
            // 
            // labelBattery
            // 
            this.labelBattery.AutoSize = true;
            this.labelBattery.ForeColor = System.Drawing.Color.Green;
            this.labelBattery.Location = new System.Drawing.Point(73, 2);
            this.labelBattery.Name = "labelBattery";
            this.labelBattery.Size = new System.Drawing.Size(27, 13);
            this.labelBattery.TabIndex = 5;
            this.labelBattery.Text = "50%";
            this.labelBattery.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(103, 139);
            this.Controls.Add(this.labelBattery);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBarBatteryLife);
            this.Controls.Add(this.groupBoxDateTime);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.Opacity = 0.9;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Digital Clock";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxDateTime.ResumeLayout(false);
            this.groupBoxDateTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelStopWatch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBoxDateTime;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Timer timerDateTimeRefresh;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.Timer timerSnap;
        private System.Windows.Forms.ProgressBar progressBarBatteryLife;
        private System.Windows.Forms.Timer timerBatteryLife;
        private System.Windows.Forms.Label labelBattery;
    }
}

