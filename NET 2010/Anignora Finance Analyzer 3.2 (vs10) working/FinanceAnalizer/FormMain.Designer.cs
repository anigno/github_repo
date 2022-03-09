namespace FinanceAnalizer
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
            this.listViewStoksNames = new System.Windows.Forms.ListView();
            this.columnHeaderStockName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderanalysis1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAnalysis2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderUpdateDate = new System.Windows.Forms.ColumnHeader();
            this.listViewStockData = new System.Windows.Forms.ListView();
            this.columnHeaderDate = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderOpen = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderHigh = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLow = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderClose = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderVolume = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddStock = new System.Windows.Forms.Button();
            this.textBoxAddStock = new System.Windows.Forms.TextBox();
            this.buttonRemoveStock = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelStockName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.anignoGraphDisplayClose = new AnignoLibrary.UI.Graphs.AnignoGraphDisplay();
            this.labelUpdating = new System.Windows.Forms.Label();
            this.buttonTester = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDownloadCsvData = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewStoksNames
            // 
            this.listViewStoksNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewStoksNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewStoksNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderStockName,
            this.columnHeaderanalysis1,
            this.columnHeaderAnalysis2,
            this.columnHeaderUpdateDate});
            this.listViewStoksNames.FullRowSelect = true;
            this.listViewStoksNames.GridLines = true;
            this.listViewStoksNames.HideSelection = false;
            this.listViewStoksNames.Location = new System.Drawing.Point(12, 25);
            this.listViewStoksNames.MultiSelect = false;
            this.listViewStoksNames.Name = "listViewStoksNames";
            this.listViewStoksNames.ShowItemToolTips = true;
            this.listViewStoksNames.Size = new System.Drawing.Size(385, 376);
            this.listViewStoksNames.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewStoksNames.TabIndex = 1;
            this.listViewStoksNames.UseCompatibleStateImageBehavior = false;
            this.listViewStoksNames.View = System.Windows.Forms.View.Details;
            this.listViewStoksNames.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewStoksNames_MouseUp);
            // 
            // columnHeaderStockName
            // 
            this.columnHeaderStockName.Text = "Name";
            this.columnHeaderStockName.Width = 126;
            // 
            // columnHeaderanalysis1
            // 
            this.columnHeaderanalysis1.Text = "Analysis1";
            this.columnHeaderanalysis1.Width = 61;
            // 
            // columnHeaderAnalysis2
            // 
            this.columnHeaderAnalysis2.Text = "Analysis2";
            // 
            // columnHeaderUpdateDate
            // 
            this.columnHeaderUpdateDate.Text = "Updated";
            this.columnHeaderUpdateDate.Width = 129;
            // 
            // listViewStockData
            // 
            this.listViewStockData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewStockData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewStockData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDate,
            this.columnHeaderOpen,
            this.columnHeaderHigh,
            this.columnHeaderLow,
            this.columnHeaderClose,
            this.columnHeaderVolume,
            this.columnHeader1,
            this.columnHeader2});
            this.listViewStockData.FullRowSelect = true;
            this.listViewStockData.GridLines = true;
            this.listViewStockData.HideSelection = false;
            this.listViewStockData.Location = new System.Drawing.Point(403, 25);
            this.listViewStockData.MultiSelect = false;
            this.listViewStockData.Name = "listViewStockData";
            this.listViewStockData.ShowItemToolTips = true;
            this.listViewStockData.Size = new System.Drawing.Size(608, 684);
            this.listViewStockData.TabIndex = 2;
            this.listViewStockData.UseCompatibleStateImageBehavior = false;
            this.listViewStockData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 120;
            // 
            // columnHeaderOpen
            // 
            this.columnHeaderOpen.Text = "Open";
            // 
            // columnHeaderHigh
            // 
            this.columnHeaderHigh.Text = "High";
            // 
            // columnHeaderLow
            // 
            this.columnHeaderLow.Text = "Low";
            // 
            // columnHeaderClose
            // 
            this.columnHeaderClose.Text = "Close";
            // 
            // columnHeaderVolume
            // 
            this.columnHeaderVolume.Text = "Volume";
            this.columnHeaderVolume.Width = 101;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Analysis1";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Analysis2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stock data:";
            // 
            // buttonAddStock
            // 
            this.buttonAddStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddStock.Location = new System.Drawing.Point(6, 19);
            this.buttonAddStock.Name = "buttonAddStock";
            this.buttonAddStock.Size = new System.Drawing.Size(93, 23);
            this.buttonAddStock.TabIndex = 4;
            this.buttonAddStock.Text = "Add stock";
            this.buttonAddStock.UseVisualStyleBackColor = true;
            this.buttonAddStock.Click += new System.EventHandler(this.buttonAddStock_Click);
            // 
            // textBoxAddStock
            // 
            this.textBoxAddStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAddStock.Location = new System.Drawing.Point(105, 21);
            this.textBoxAddStock.Name = "textBoxAddStock";
            this.textBoxAddStock.Size = new System.Drawing.Size(274, 20);
            this.textBoxAddStock.TabIndex = 5;
            // 
            // buttonRemoveStock
            // 
            this.buttonRemoveStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveStock.Location = new System.Drawing.Point(6, 48);
            this.buttonRemoveStock.Name = "buttonRemoveStock";
            this.buttonRemoveStock.Size = new System.Drawing.Size(93, 23);
            this.buttonRemoveStock.TabIndex = 6;
            this.buttonRemoveStock.Text = "Remove stock";
            this.buttonRemoveStock.UseVisualStyleBackColor = true;
            this.buttonRemoveStock.Click += new System.EventHandler(this.buttonRemoveStock_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.buttonAddStock);
            this.groupBox1.Controls.Add(this.buttonRemoveStock);
            this.groupBox1.Controls.Add(this.textBoxAddStock);
            this.groupBox1.Controls.Add(this.buttonImport);
            this.groupBox1.Location = new System.Drawing.Point(12, 484);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 80);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // buttonImport
            // 
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImport.Location = new System.Drawing.Point(105, 48);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(90, 23);
            this.buttonImport.TabIndex = 7;
            this.buttonImport.Text = "Import Stocks";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.Location = new System.Drawing.Point(6, 19);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(78, 40);
            this.buttonExport.TabIndex = 8;
            this.buttonExport.Text = "Export Report";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelStockName
            // 
            this.labelStockName.AutoSize = true;
            this.labelStockName.BackColor = System.Drawing.Color.White;
            this.labelStockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelStockName.ForeColor = System.Drawing.Color.Black;
            this.labelStockName.Location = new System.Drawing.Point(468, 2);
            this.labelStockName.Name = "labelStockName";
            this.labelStockName.Size = new System.Drawing.Size(19, 20);
            this.labelStockName.TabIndex = 8;
            this.labelStockName.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Updated:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.BackColor = System.Drawing.Color.White;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelDate.ForeColor = System.Drawing.Color.Black;
            this.labelDate.Location = new System.Drawing.Point(690, 2);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(19, 20);
            this.labelDate.TabIndex = 10;
            this.labelDate.Text = "--";
            // 
            // labelDateTime
            // 
            this.labelDateTime.BackColor = System.Drawing.Color.White;
            this.labelDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelDateTime.ForeColor = System.Drawing.Color.Black;
            this.labelDateTime.Location = new System.Drawing.Point(230, 2);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(167, 20);
            this.labelDateTime.TabIndex = 12;
            this.labelDateTime.Text = "00/00/00 00:00:00";
            this.labelDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 1000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // anignoGraphDisplayClose
            // 
            this.anignoGraphDisplayClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.anignoGraphDisplayClose.AutoGridScale = true;
            this.anignoGraphDisplayClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anignoGraphDisplayClose.ColorGrid = System.Drawing.Color.Gray;
            this.anignoGraphDisplayClose.ColorZeroAxes = System.Drawing.Color.White;
            this.anignoGraphDisplayClose.DrawGrid = true;
            this.anignoGraphDisplayClose.DrawGridNumbers = false;
            this.anignoGraphDisplayClose.GridMaxY = 100F;
            this.anignoGraphDisplayClose.GridMinY = -100F;
            this.anignoGraphDisplayClose.Location = new System.Drawing.Point(12, 570);
            this.anignoGraphDisplayClose.Name = "anignoGraphDisplayClose";
            this.anignoGraphDisplayClose.Size = new System.Drawing.Size(385, 139);
            this.anignoGraphDisplayClose.TabIndex = 11;
            this.anignoGraphDisplayClose.X_GridLines = 10;
            this.anignoGraphDisplayClose.Y_GridLines = 5;
            // 
            // labelUpdating
            // 
            this.labelUpdating.BackColor = System.Drawing.Color.White;
            this.labelUpdating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelUpdating.ForeColor = System.Drawing.Color.Black;
            this.labelUpdating.Location = new System.Drawing.Point(14, 2);
            this.labelUpdating.Name = "labelUpdating";
            this.labelUpdating.Size = new System.Drawing.Size(210, 20);
            this.labelUpdating.TabIndex = 13;
            this.labelUpdating.Text = "Updating:";
            this.labelUpdating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonTester
            // 
            this.buttonTester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTester.Location = new System.Drawing.Point(90, 19);
            this.buttonTester.Name = "buttonTester";
            this.buttonTester.Size = new System.Drawing.Size(78, 40);
            this.buttonTester.TabIndex = 9;
            this.buttonTester.Text = "Start Test stock";
            this.buttonTester.UseVisualStyleBackColor = true;
            this.buttonTester.Click += new System.EventHandler(this.buttonTester_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDownloadCsvData);
            this.groupBox2.Controls.Add(this.buttonExport);
            this.groupBox2.Controls.Add(this.buttonTester);
            this.groupBox2.Location = new System.Drawing.Point(12, 407);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 71);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // buttonDownloadCsvData
            // 
            this.buttonDownloadCsvData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDownloadCsvData.Location = new System.Drawing.Point(301, 19);
            this.buttonDownloadCsvData.Name = "buttonDownloadCsvData";
            this.buttonDownloadCsvData.Size = new System.Drawing.Size(78, 40);
            this.buttonDownloadCsvData.TabIndex = 11;
            this.buttonDownloadCsvData.Text = "Open Csv Downloader";
            this.buttonDownloadCsvData.UseVisualStyleBackColor = true;
            this.buttonDownloadCsvData.Click += new System.EventHandler(this.buttonDownloadCsvData_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 721);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelUpdating);
            this.Controls.Add(this.labelDateTime);
            this.Controls.Add(this.anignoGraphDisplayClose);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelStockName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewStockData);
            this.Controls.Add(this.listViewStoksNames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Finance Analizer";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewStoksNames;
        private System.Windows.Forms.ColumnHeader columnHeaderStockName;
        private System.Windows.Forms.ColumnHeader columnHeaderanalysis1;
        private System.Windows.Forms.ListView listViewStockData;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderOpen;
        private System.Windows.Forms.ColumnHeader columnHeaderHigh;
        private System.Windows.Forms.ColumnHeader columnHeaderLow;
        private System.Windows.Forms.ColumnHeader columnHeaderClose;
        private System.Windows.Forms.ColumnHeader columnHeaderVolume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeaderUpdateDate;
        private System.Windows.Forms.Button buttonAddStock;
        private System.Windows.Forms.TextBox textBoxAddStock;
        private System.Windows.Forms.Button buttonRemoveStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelStockName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.ColumnHeader columnHeaderAnalysis2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private AnignoLibrary.UI.Graphs.AnignoGraphDisplay anignoGraphDisplayClose;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Label labelUpdating;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonTester;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDownloadCsvData;
    }
}

