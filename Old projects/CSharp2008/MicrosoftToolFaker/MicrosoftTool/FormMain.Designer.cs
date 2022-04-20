namespace MicrosoftTool
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
            this.checkBoxNotifyVisible = new System.Windows.Forms.CheckBox();
            this.dateTimePickerTriggerDate = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownHold = new System.Windows.Forms.NumericUpDown();
            this.labelHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSaveAndExit = new System.Windows.Forms.Button();
            this.timerTrigger = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHold)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "MicrosoftTool";
            this.notifyIconMain.Visible = true;
            // 
            // checkBoxNotifyVisible
            // 
            this.checkBoxNotifyVisible.AutoSize = true;
            this.checkBoxNotifyVisible.Location = new System.Drawing.Point(11, 51);
            this.checkBoxNotifyVisible.Name = "checkBoxNotifyVisible";
            this.checkBoxNotifyVisible.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxNotifyVisible.Size = new System.Drawing.Size(109, 17);
            this.checkBoxNotifyVisible.TabIndex = 0;
            this.checkBoxNotifyVisible.Text = "Notify Icon visible";
            this.checkBoxNotifyVisible.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerTriggerDate
            // 
            this.dateTimePickerTriggerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTriggerDate.Location = new System.Drawing.Point(107, 25);
            this.dateTimePickerTriggerDate.Name = "dateTimePickerTriggerDate";
            this.dateTimePickerTriggerDate.ShowUpDown = true;
            this.dateTimePickerTriggerDate.Size = new System.Drawing.Size(95, 20);
            this.dateTimePickerTriggerDate.TabIndex = 1;
            // 
            // numericUpDownHold
            // 
            this.numericUpDownHold.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHold.Location = new System.Drawing.Point(107, 74);
            this.numericUpDownHold.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHold.Name = "numericUpDownHold";
            this.numericUpDownHold.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownHold.TabIndex = 2;
            this.numericUpDownHold.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelHeader.Location = new System.Drawing.Point(12, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(88, 13);
            this.labelHeader.TabIndex = 3;
            this.labelHeader.Text = "Microsoft Tool";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Trigger date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hold percentage:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "%";
            // 
            // buttonSaveAndExit
            // 
            this.buttonSaveAndExit.Location = new System.Drawing.Point(15, 106);
            this.buttonSaveAndExit.Name = "buttonSaveAndExit";
            this.buttonSaveAndExit.Size = new System.Drawing.Size(187, 23);
            this.buttonSaveAndExit.TabIndex = 7;
            this.buttonSaveAndExit.Text = "Save and Exit";
            this.buttonSaveAndExit.UseVisualStyleBackColor = true;
            this.buttonSaveAndExit.Click += new System.EventHandler(this.buttonSaveAndExit_Click);
            // 
            // timerTrigger
            // 
            this.timerTrigger.Enabled = true;
            this.timerTrigger.Interval = 5000;
            this.timerTrigger.Tick += new System.EventHandler(this.timerTrigger_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 152);
            this.Controls.Add(this.buttonSaveAndExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.numericUpDownHold);
            this.Controls.Add(this.dateTimePickerTriggerDate);
            this.Controls.Add(this.checkBoxNotifyVisible);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.CheckBox checkBoxNotifyVisible;
        private System.Windows.Forms.DateTimePicker dateTimePickerTriggerDate;
        private System.Windows.Forms.NumericUpDown numericUpDownHold;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSaveAndExit;
        private System.Windows.Forms.Timer timerTrigger;
    }
}

