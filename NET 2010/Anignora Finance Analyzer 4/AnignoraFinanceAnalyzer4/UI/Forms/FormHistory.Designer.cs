namespace AnignoraFinanceAnalyzer4.UI.Forms
{
    partial class FormHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistory));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewSymbols = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSelectNone = new AnignoraUI.Buttons.ButtonGradientGlow();
            this.buttonSelectAll = new AnignoraUI.Buttons.ButtonGradientGlow();
            this.buttonCalculate = new AnignoraUI.Buttons.ButtonGradientGlow();
            this.checkBoxExportCsv = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.graphDateToFloatPer = new AnignoraUI.Graphs.GraphDateToFloat();
            this.ucResultTotal = new AnignoraFinanceAnalyzer4.UI.Controls.ucResult();
            this.ucResultMisses = new AnignoraFinanceAnalyzer4.UI.Controls.ucResult();
            this.ucResultHits = new AnignoraFinanceAnalyzer4.UI.Controls.ucResult();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.listViewSymbols);
            this.groupBox1.Controls.Add(this.buttonSelectNone);
            this.groupBox1.Controls.Add(this.buttonSelectAll);
            this.groupBox1.Controls.Add(this.buttonCalculate);
            this.groupBox1.Controls.Add(this.checkBoxExportCsv);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePickerFrom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 496);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // listViewSymbols
            // 
            this.listViewSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewSymbols.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listViewSymbols.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewSymbols.CheckBoxes = true;
            this.listViewSymbols.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewSymbols.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listViewSymbols.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSymbols.Location = new System.Drawing.Point(6, 147);
            this.listViewSymbols.Name = "listViewSymbols";
            this.listViewSymbols.Size = new System.Drawing.Size(126, 343);
            this.listViewSymbols.TabIndex = 9;
            this.listViewSymbols.UseCompatibleStateImageBehavior = false;
            this.listViewSymbols.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Symbols";
            this.columnHeader1.Width = 108;
            // 
            // buttonSelectNone
            // 
            this.buttonSelectNone.BackColor = System.Drawing.Color.Black;
            this.buttonSelectNone.CornerSize = 5;
            this.buttonSelectNone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonSelectNone.GlowColor = System.Drawing.Color.Blue;
            this.buttonSelectNone.GlowIntensity = ((uint)(100u));
            this.buttonSelectNone.GradientAngle = 270;
            this.buttonSelectNone.GradientColorFirst = System.Drawing.Color.Black;
            this.buttonSelectNone.GradientColorSecond = System.Drawing.Color.Gray;
            this.buttonSelectNone.Location = new System.Drawing.Point(73, 124);
            this.buttonSelectNone.Name = "buttonSelectNone";
            this.buttonSelectNone.Size = new System.Drawing.Size(59, 20);
            this.buttonSelectNone.TabIndex = 8;
            this.buttonSelectNone.Text = "None";
            this.buttonSelectNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonSelectNone.Click += new System.EventHandler(this.buttonSelectNone_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.BackColor = System.Drawing.Color.Black;
            this.buttonSelectAll.CornerSize = 5;
            this.buttonSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonSelectAll.GlowColor = System.Drawing.Color.Blue;
            this.buttonSelectAll.GlowIntensity = ((uint)(100u));
            this.buttonSelectAll.GradientAngle = 270;
            this.buttonSelectAll.GradientColorFirst = System.Drawing.Color.Black;
            this.buttonSelectAll.GradientColorSecond = System.Drawing.Color.Gray;
            this.buttonSelectAll.Location = new System.Drawing.Point(6, 124);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(61, 20);
            this.buttonSelectAll.TabIndex = 7;
            this.buttonSelectAll.Text = "All";
            this.buttonSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.BackColor = System.Drawing.Color.Black;
            this.buttonCalculate.CornerSize = 5;
            this.buttonCalculate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonCalculate.GlowColor = System.Drawing.Color.Blue;
            this.buttonCalculate.GlowIntensity = ((uint)(100u));
            this.buttonCalculate.GradientAngle = 270;
            this.buttonCalculate.GradientColorFirst = System.Drawing.Color.Black;
            this.buttonCalculate.GradientColorSecond = System.Drawing.Color.Gray;
            this.buttonCalculate.Location = new System.Drawing.Point(6, 94);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(126, 25);
            this.buttonCalculate.TabIndex = 6;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // checkBoxExportCsv
            // 
            this.checkBoxExportCsv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxExportCsv.Location = new System.Drawing.Point(9, 71);
            this.checkBoxExportCsv.Name = "checkBoxExportCsv";
            this.checkBoxExportCsv.Size = new System.Drawing.Size(123, 20);
            this.checkBoxExportCsv.TabIndex = 5;
            this.checkBoxExportCsv.Text = "Export CSV:";
            this.checkBoxExportCsv.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePickerTo.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(45, 45);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.ShowUpDown = true;
            this.dateTimePickerTo.Size = new System.Drawing.Size(87, 20);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePickerFrom.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(45, 19);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.ShowUpDown = true;
            this.dateTimePickerFrom.Size = new System.Drawing.Size(87, 20);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Longs:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Shorts:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Hits:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(492, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Total:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(368, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Misses:";
            // 
            // graphDateToFloatPer
            // 
            this.graphDateToFloatPer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.graphDateToFloatPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphDateToFloatPer.GraphColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.graphDateToFloatPer.GridsColor = System.Drawing.Color.Gray;
            this.graphDateToFloatPer.GridsHorizontal = ((uint)(10u));
            this.graphDateToFloatPer.GridsTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.graphDateToFloatPer.GridsVertical = ((uint)(10u));
            this.graphDateToFloatPer.GridTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.graphDateToFloatPer.Location = new System.Drawing.Point(157, 122);
            this.graphDateToFloatPer.Name = "graphDateToFloatPer";
            this.graphDateToFloatPer.ShowGrids = true;
            this.graphDateToFloatPer.Size = new System.Drawing.Size(690, 386);
            this.graphDateToFloatPer.TabIndex = 0;
            this.graphDateToFloatPer.ZeroLineColor = System.Drawing.Color.White;
            // 
            // ucResultTotal
            // 
            this.ucResultTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucResultTotal.Location = new System.Drawing.Point(456, 28);
            this.ucResultTotal.Name = "ucResultTotal";
            this.ucResultTotal.Size = new System.Drawing.Size(140, 88);
            this.ucResultTotal.TabIndex = 3;
            // 
            // ucResultMisses
            // 
            this.ucResultMisses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucResultMisses.Location = new System.Drawing.Point(329, 28);
            this.ucResultMisses.Name = "ucResultMisses";
            this.ucResultMisses.Size = new System.Drawing.Size(121, 88);
            this.ucResultMisses.TabIndex = 2;
            // 
            // ucResultHits
            // 
            this.ucResultHits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucResultHits.Location = new System.Drawing.Point(202, 28);
            this.ucResultHits.Name = "ucResultHits";
            this.ucResultHits.Size = new System.Drawing.Size(121, 88);
            this.ucResultHits.TabIndex = 1;
            // 
            // FormHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(859, 520);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ucResultTotal);
            this.Controls.Add(this.ucResultMisses);
            this.Controls.Add(this.ucResultHits);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.graphDateToFloatPer);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHistory";
            this.Text = "AFA4 History";
            this.Load += new System.EventHandler(this.FormHistory_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AnignoraUI.Graphs.GraphDateToFloat graphDateToFloatPer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxExportCsv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private AnignoraUI.Buttons.ButtonGradientGlow buttonSelectNone;
        private AnignoraUI.Buttons.ButtonGradientGlow buttonSelectAll;
        private AnignoraUI.Buttons.ButtonGradientGlow buttonCalculate;
        private System.Windows.Forms.ListView listViewSymbols;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private Controls.ucResult ucResultHits;
        private Controls.ucResult ucResultMisses;
        private Controls.ucResult ucResultTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}