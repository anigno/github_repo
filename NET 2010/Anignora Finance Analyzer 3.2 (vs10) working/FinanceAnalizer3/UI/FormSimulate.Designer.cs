namespace FinanceAnalizer3.UI
{
    partial class FormSimulate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSimulate));
            this.dataGridViewAsListStocksSimulated = new FinanceAnalizer3.UI.DataGridViewAsList();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelStocks = new System.Windows.Forms.Label();
            this.radioButtonStdDev = new System.Windows.Forms.RadioButton();
            this.numericUpDownTradeDates = new System.Windows.Forms.NumericUpDown();
            this.labelHistoryHeader = new System.Windows.Forms.Label();
            this.buttonSortByStdDev = new System.Windows.Forms.Button();
            this.buttonSortByProfitNormal = new System.Windows.Forms.Button();
            this.buttonSortByHitsMisses = new System.Windows.Forms.Button();
            this.ColumnStockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumberOfDates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalProfitPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProfitNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHitsMisses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSortByBeta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsListStocksSimulated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTradeDates)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAsListStocksSimulated
            // 
            this.dataGridViewAsListStocksSimulated.AllowUserToAddRows = false;
            this.dataGridViewAsListStocksSimulated.AllowUserToDeleteRows = false;
            this.dataGridViewAsListStocksSimulated.AllowUserToOrderColumns = true;
            this.dataGridViewAsListStocksSimulated.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAsListStocksSimulated.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewAsListStocksSimulated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAsListStocksSimulated.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockName,
            this.ColumnStDev,
            this.ColumnNumberOfDates,
            this.ColumnTotalProfitPer,
            this.ColumnProfitNormal,
            this.ColumnHitsMisses,
            this.ColumnBeta});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAsListStocksSimulated.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAsListStocksSimulated.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAsListStocksSimulated.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewAsListStocksSimulated.MultiSelect = false;
            this.dataGridViewAsListStocksSimulated.Name = "dataGridViewAsListStocksSimulated";
            this.dataGridViewAsListStocksSimulated.ReadOnly = true;
            this.dataGridViewAsListStocksSimulated.RowHeadersVisible = false;
            this.dataGridViewAsListStocksSimulated.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAsListStocksSimulated.Size = new System.Drawing.Size(641, 645);
            this.dataGridViewAsListStocksSimulated.TabIndex = 0;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalculate.ForeColor = System.Drawing.Color.Navy;
            this.buttonCalculate.Location = new System.Drawing.Point(662, 12);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(114, 42);
            this.buttonCalculate.TabIndex = 6;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = false;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.ForeColor = System.Drawing.Color.Navy;
            this.buttonExport.Location = new System.Drawing.Point(659, 615);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(117, 42);
            this.buttonExport.TabIndex = 7;
            this.buttonExport.Text = "Export Report To CSV";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelStocks
            // 
            this.labelStocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStocks.BackColor = System.Drawing.Color.Transparent;
            this.labelStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelStocks.Location = new System.Drawing.Point(662, 57);
            this.labelStocks.Name = "labelStocks";
            this.labelStocks.Size = new System.Drawing.Size(114, 31);
            this.labelStocks.TabIndex = 8;
            this.labelStocks.Text = "000";
            this.labelStocks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButtonStdDev
            // 
            this.radioButtonStdDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonStdDev.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonStdDev.Checked = true;
            this.radioButtonStdDev.Location = new System.Drawing.Point(659, 160);
            this.radioButtonStdDev.Name = "radioButtonStdDev";
            this.radioButtonStdDev.Size = new System.Drawing.Size(114, 42);
            this.radioButtonStdDev.TabIndex = 9;
            this.radioButtonStdDev.TabStop = true;
            this.radioButtonStdDev.Text = "Standart Deviation";
            this.radioButtonStdDev.UseVisualStyleBackColor = false;
            // 
            // numericUpDownTradeDates
            // 
            this.numericUpDownTradeDates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownTradeDates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownTradeDates.Increment = new decimal(new int[] {
            124,
            0,
            0,
            0});
            this.numericUpDownTradeDates.Location = new System.Drawing.Point(666, 104);
            this.numericUpDownTradeDates.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTradeDates.Minimum = new decimal(new int[] {
            124,
            0,
            0,
            0});
            this.numericUpDownTradeDates.Name = "numericUpDownTradeDates";
            this.numericUpDownTradeDates.Size = new System.Drawing.Size(104, 16);
            this.numericUpDownTradeDates.TabIndex = 16;
            this.numericUpDownTradeDates.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownTradeDates.Value = new decimal(new int[] {
            248,
            0,
            0,
            0});
            // 
            // labelHistoryHeader
            // 
            this.labelHistoryHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHistoryHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHistoryHeader.Location = new System.Drawing.Point(663, 88);
            this.labelHistoryHeader.Name = "labelHistoryHeader";
            this.labelHistoryHeader.Size = new System.Drawing.Size(110, 13);
            this.labelHistoryHeader.TabIndex = 17;
            this.labelHistoryHeader.Text = "Trade Dates:";
            this.labelHistoryHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSortByStdDev
            // 
            this.buttonSortByStdDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSortByStdDev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonSortByStdDev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSortByStdDev.ForeColor = System.Drawing.Color.Navy;
            this.buttonSortByStdDev.Location = new System.Drawing.Point(659, 208);
            this.buttonSortByStdDev.Name = "buttonSortByStdDev";
            this.buttonSortByStdDev.Size = new System.Drawing.Size(117, 42);
            this.buttonSortByStdDev.TabIndex = 18;
            this.buttonSortByStdDev.Text = "Sort By Std Deviation";
            this.buttonSortByStdDev.UseVisualStyleBackColor = false;
            this.buttonSortByStdDev.Click += new System.EventHandler(this.buttonSortByStdDev_Click);
            // 
            // buttonSortByProfitNormal
            // 
            this.buttonSortByProfitNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSortByProfitNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonSortByProfitNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSortByProfitNormal.ForeColor = System.Drawing.Color.Navy;
            this.buttonSortByProfitNormal.Location = new System.Drawing.Point(659, 256);
            this.buttonSortByProfitNormal.Name = "buttonSortByProfitNormal";
            this.buttonSortByProfitNormal.Size = new System.Drawing.Size(117, 42);
            this.buttonSortByProfitNormal.TabIndex = 19;
            this.buttonSortByProfitNormal.Text = "Sort By Profit Normal";
            this.buttonSortByProfitNormal.UseVisualStyleBackColor = false;
            this.buttonSortByProfitNormal.Click += new System.EventHandler(this.buttonSortByProfitNormal_Click);
            // 
            // buttonSortByHitsMisses
            // 
            this.buttonSortByHitsMisses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSortByHitsMisses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonSortByHitsMisses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSortByHitsMisses.ForeColor = System.Drawing.Color.Navy;
            this.buttonSortByHitsMisses.Location = new System.Drawing.Point(659, 304);
            this.buttonSortByHitsMisses.Name = "buttonSortByHitsMisses";
            this.buttonSortByHitsMisses.Size = new System.Drawing.Size(117, 42);
            this.buttonSortByHitsMisses.TabIndex = 20;
            this.buttonSortByHitsMisses.Text = "Sort By HitsMisses";
            this.buttonSortByHitsMisses.UseVisualStyleBackColor = false;
            this.buttonSortByHitsMisses.Click += new System.EventHandler(this.buttonSortByHitsMisses_Click);
            // 
            // ColumnStockName
            // 
            this.ColumnStockName.HeaderText = "Stock";
            this.ColumnStockName.Name = "ColumnStockName";
            this.ColumnStockName.ReadOnly = true;
            this.ColumnStockName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnStockName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnStockName.Width = 60;
            // 
            // ColumnStDev
            // 
            this.ColumnStDev.HeaderText = "StdDev";
            this.ColumnStDev.Name = "ColumnStDev";
            this.ColumnStDev.ReadOnly = true;
            this.ColumnStDev.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnStDev.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnStDev.Width = 68;
            // 
            // ColumnNumberOfDates
            // 
            this.ColumnNumberOfDates.HeaderText = "nDates";
            this.ColumnNumberOfDates.Name = "ColumnNumberOfDates";
            this.ColumnNumberOfDates.ReadOnly = true;
            this.ColumnNumberOfDates.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnNumberOfDates.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnNumberOfDates.Width = 66;
            // 
            // ColumnTotalProfitPer
            // 
            this.ColumnTotalProfitPer.HeaderText = "Total Profit %";
            this.ColumnTotalProfitPer.Name = "ColumnTotalProfitPer";
            this.ColumnTotalProfitPer.ReadOnly = true;
            this.ColumnTotalProfitPer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTotalProfitPer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnTotalProfitPer.Width = 94;
            // 
            // ColumnProfitNormal
            // 
            this.ColumnProfitNormal.HeaderText = "Profit Normal per Year";
            this.ColumnProfitNormal.Name = "ColumnProfitNormal";
            this.ColumnProfitNormal.ReadOnly = true;
            this.ColumnProfitNormal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnProfitNormal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnProfitNormal.Width = 104;
            // 
            // ColumnHitsMisses
            // 
            this.ColumnHitsMisses.HeaderText = "HitsMisses Ratio";
            this.ColumnHitsMisses.Name = "ColumnHitsMisses";
            this.ColumnHitsMisses.ReadOnly = true;
            this.ColumnHitsMisses.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHitsMisses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnHitsMisses.Width = 101;
            // 
            // ColumnBeta
            // 
            this.ColumnBeta.HeaderText = "Beta result";
            this.ColumnBeta.Name = "ColumnBeta";
            this.ColumnBeta.ReadOnly = true;
            this.ColumnBeta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnBeta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnBeta.Width = 76;
            // 
            // buttonSortByBeta
            // 
            this.buttonSortByBeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSortByBeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonSortByBeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSortByBeta.ForeColor = System.Drawing.Color.Navy;
            this.buttonSortByBeta.Location = new System.Drawing.Point(659, 352);
            this.buttonSortByBeta.Name = "buttonSortByBeta";
            this.buttonSortByBeta.Size = new System.Drawing.Size(117, 42);
            this.buttonSortByBeta.TabIndex = 21;
            this.buttonSortByBeta.Text = "Sort By Beta results";
            this.buttonSortByBeta.UseVisualStyleBackColor = false;
            this.buttonSortByBeta.Click += new System.EventHandler(this.buttonSortByBeta_Click);
            // 
            // FormSimulate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 669);
            this.Controls.Add(this.buttonSortByBeta);
            this.Controls.Add(this.buttonSortByHitsMisses);
            this.Controls.Add(this.buttonSortByProfitNormal);
            this.Controls.Add(this.buttonSortByStdDev);
            this.Controls.Add(this.labelHistoryHeader);
            this.Controls.Add(this.numericUpDownTradeDates);
            this.Controls.Add(this.radioButtonStdDev);
            this.Controls.Add(this.labelStocks);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.dataGridViewAsListStocksSimulated);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSimulate";
            this.Text = "Simulations";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsListStocksSimulated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTradeDates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewAsList dataGridViewAsListStocksSimulated;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label labelStocks;
        private System.Windows.Forms.RadioButton radioButtonStdDev;
        private System.Windows.Forms.NumericUpDown numericUpDownTradeDates;
        private System.Windows.Forms.Label labelHistoryHeader;
        private System.Windows.Forms.Button buttonSortByStdDev;
        private System.Windows.Forms.Button buttonSortByProfitNormal;
        private System.Windows.Forms.Button buttonSortByHitsMisses;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumberOfDates;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalProfitPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProfitNormal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHitsMisses;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBeta;
        private System.Windows.Forms.Button buttonSortByBeta;
    }
}