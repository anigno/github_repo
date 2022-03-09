using AnignoraFinanceAnalyzer5.UI.Controls;

namespace AnignoraFinanceAnalyzer5.UI.Forms
{
    partial class FormSystemsCalculate
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
            this.treeViewSymbols = new System.Windows.Forms.TreeView();
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.ucResultTotal = new ucResult();
            this.ucResultMisses = new ucResult();
            this.ucResultHits = new ucResult();
            this.graphDateToFloatHistory = new AnignoraUI.Graphs.GraphDateToFloat();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.checkBoxSymbolsReport = new System.Windows.Forms.CheckBox();
            this.buttonCreateDebug = new System.Windows.Forms.Button();
            this.groupBoxResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewSymbols
            // 
            this.treeViewSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewSymbols.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeViewSymbols.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewSymbols.CheckBoxes = true;
            this.treeViewSymbols.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.treeViewSymbols.FullRowSelect = true;
            this.treeViewSymbols.HideSelection = false;
            this.treeViewSymbols.ImageIndex = 0;
            this.treeViewSymbols.ImageList = this.imageListMain;
            this.treeViewSymbols.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.treeViewSymbols.Location = new System.Drawing.Point(12, 36);
            this.treeViewSymbols.Name = "treeViewSymbols";
            this.treeViewSymbols.SelectedImageIndex = 0;
            this.treeViewSymbols.Size = new System.Drawing.Size(275, 473);
            this.treeViewSymbols.TabIndex = 0;
            this.treeViewSymbols.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSymbolsAfterCheck);
            this.treeViewSymbols.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSymbolsAfterCollapse);
            // 
            // imageListMain
            // 
            this.imageListMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListMain.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListMain.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalculate.Location = new System.Drawing.Point(12, 516);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(105, 26);
            this.buttonCalculate.TabIndex = 1;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculateClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(57, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Hits";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(331, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Total";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(194, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Misses";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(7, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 26);
            this.label4.TabIndex = 14;
            this.label4.Text = "Longs";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(7, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 26);
            this.label5.TabIndex = 15;
            this.label5.Text = "Shorts";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(7, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 26);
            this.label6.TabIndex = 16;
            this.label6.Text = "Total";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Controls.Add(this.ucResultTotal);
            this.groupBoxResults.Controls.Add(this.ucResultMisses);
            this.groupBoxResults.Controls.Add(this.label3);
            this.groupBoxResults.Controls.Add(this.label6);
            this.groupBoxResults.Controls.Add(this.label2);
            this.groupBoxResults.Controls.Add(this.label1);
            this.groupBoxResults.Controls.Add(this.ucResultHits);
            this.groupBoxResults.Controls.Add(this.label5);
            this.groupBoxResults.Controls.Add(this.label4);
            this.groupBoxResults.Location = new System.Drawing.Point(293, 12);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(478, 161);
            this.groupBoxResults.TabIndex = 17;
            this.groupBoxResults.TabStop = false;
            // 
            // ucResultTotal
            // 
            this.ucResultTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucResultTotal.Location = new System.Drawing.Point(334, 42);
            this.ucResultTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucResultTotal.Name = "ucResultTotal";
            this.ucResultTotal.Size = new System.Drawing.Size(131, 111);
            this.ucResultTotal.TabIndex = 2;
            // 
            // ucResultMisses
            // 
            this.ucResultMisses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucResultMisses.Location = new System.Drawing.Point(197, 42);
            this.ucResultMisses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucResultMisses.Name = "ucResultMisses";
            this.ucResultMisses.Size = new System.Drawing.Size(131, 111);
            this.ucResultMisses.TabIndex = 7;
            // 
            // ucResultHits
            // 
            this.ucResultHits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucResultHits.Location = new System.Drawing.Point(60, 42);
            this.ucResultHits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucResultHits.Name = "ucResultHits";
            this.ucResultHits.Size = new System.Drawing.Size(131, 111);
            this.ucResultHits.TabIndex = 10;
            // 
            // graphDateToFloatHistory
            // 
            this.graphDateToFloatHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphDateToFloatHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.graphDateToFloatHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphDateToFloatHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.graphDateToFloatHistory.GraphColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.graphDateToFloatHistory.GridsColor = System.Drawing.Color.Gray;
            this.graphDateToFloatHistory.GridsHorizontal = ((uint)(7u));
            this.graphDateToFloatHistory.GridsTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.graphDateToFloatHistory.GridsVertical = ((uint)(5u));
            this.graphDateToFloatHistory.GridTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.graphDateToFloatHistory.Location = new System.Drawing.Point(293, 179);
            this.graphDateToFloatHistory.Name = "graphDateToFloatHistory";
            this.graphDateToFloatHistory.ShowGrids = true;
            this.graphDateToFloatHistory.Size = new System.Drawing.Size(516, 330);
            this.graphDateToFloatHistory.TabIndex = 18;
            this.graphDateToFloatHistory.ZeroLineColor = System.Drawing.Color.White;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CustomFormat = "dd/MM/yyy";
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(58, 10);
            this.dateTimePickerFrom.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.ShowUpDown = true;
            this.dateTimePickerFrom.Size = new System.Drawing.Size(96, 22);
            this.dateTimePickerFrom.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "From:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(160, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 23);
            this.label8.TabIndex = 21;
            this.label8.Text = "To:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CustomFormat = "dd/MM/yyy";
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(191, 10);
            this.dateTimePickerTo.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.ShowUpDown = true;
            this.dateTimePickerTo.Size = new System.Drawing.Size(96, 22);
            this.dateTimePickerTo.TabIndex = 22;
            // 
            // checkBoxSymbolsReport
            // 
            this.checkBoxSymbolsReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxSymbolsReport.AutoSize = true;
            this.checkBoxSymbolsReport.Location = new System.Drawing.Point(123, 516);
            this.checkBoxSymbolsReport.Name = "checkBoxSymbolsReport";
            this.checkBoxSymbolsReport.Size = new System.Drawing.Size(137, 21);
            this.checkBoxSymbolsReport.TabIndex = 23;
            this.checkBoxSymbolsReport.Text = "Symbols Reports";
            this.checkBoxSymbolsReport.UseVisualStyleBackColor = true;
            // 
            // buttonCreateDebug
            // 
            this.buttonCreateDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateDebug.Location = new System.Drawing.Point(704, 516);
            this.buttonCreateDebug.Name = "buttonCreateDebug";
            this.buttonCreateDebug.Size = new System.Drawing.Size(105, 26);
            this.buttonCreateDebug.TabIndex = 24;
            this.buttonCreateDebug.Text = "Debug Data";
            this.buttonCreateDebug.UseVisualStyleBackColor = true;
            this.buttonCreateDebug.Click += new System.EventHandler(this.buttonCreateDebugClick);
            // 
            // FormSystemsCalculate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(821, 554);
            this.Controls.Add(this.buttonCreateDebug);
            this.Controls.Add(this.checkBoxSymbolsReport);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.graphDateToFloatHistory);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.treeViewSymbols);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MinimumSize = new System.Drawing.Size(780, 400);
            this.Name = "FormSystemsCalculate";
            this.Text = "Systems Profit Calculation";
            this.groupBoxResults.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewSymbols;
        private System.Windows.Forms.ImageList imageListMain;
        private System.Windows.Forms.Button buttonCalculate;
        private Controls.ucResult ucResultTotal;
        private Controls.ucResult ucResultMisses;
        private Controls.ucResult ucResultHits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private AnignoraUI.Graphs.GraphDateToFloat graphDateToFloatHistory;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.CheckBox checkBoxSymbolsReport;
        private System.Windows.Forms.Button buttonCreateDebug;
    }
}