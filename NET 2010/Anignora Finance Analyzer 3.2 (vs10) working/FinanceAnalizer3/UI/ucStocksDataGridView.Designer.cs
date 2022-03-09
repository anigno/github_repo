namespace FinanceAnalizer3.UI
{
    partial class ucStocksDataGridView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewAsListStocks = new FinanceAnalizer3.UI.DataGridViewAsList();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnClose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDailyChangePer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTwo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTwoPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQualtityForPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSignaled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTimeAnalyzed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsListStocks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAsListStocks
            // 
            this.dataGridViewAsListStocks.AllowUserToAddRows = false;
            this.dataGridViewAsListStocks.AllowUserToDeleteRows = false;
            this.dataGridViewAsListStocks.AllowUserToOrderColumns = true;
            this.dataGridViewAsListStocks.AllowUserToResizeRows = false;
            this.dataGridViewAsListStocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewAsListStocks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAsListStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAsListStocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnDate,
            this.ColumnHigh,
            this.ColumnLow,
            this.ColumnClose,
            this.ColumnDailyChangePer,
            this.ColumnOne,
            this.ColumnTwo,
            this.ColumnTwoPer,
            this.ColumnQualtityForPosition,
            this.ColumnSignaled,
            this.ColumnHit,
            this.ColumnTimeAnalyzed,
            this.ColumnTest});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAsListStocks.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAsListStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAsListStocks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAsListStocks.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAsListStocks.MultiSelect = false;
            this.dataGridViewAsListStocks.Name = "dataGridViewAsListStocks";
            this.dataGridViewAsListStocks.ReadOnly = true;
            this.dataGridViewAsListStocks.RowHeadersVisible = false;
            this.dataGridViewAsListStocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAsListStocks.Size = new System.Drawing.Size(680, 501);
            this.dataGridViewAsListStocks.TabIndex = 16;
            this.dataGridViewAsListStocks.SelectionChanged += new System.EventHandler(this.dataGridViewAsListStocks_SelectionChanged);
            this.dataGridViewAsListStocks.Click += new System.EventHandler(this.dataGridViewAsListStocks_Click);
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = " Name ";
            this.ColumnName.MinimumWidth = 60;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnName.Width = 66;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Date";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            this.ColumnDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnDate.Width = 55;
            // 
            // ColumnHigh
            // 
            this.ColumnHigh.HeaderText = "High";
            this.ColumnHigh.Name = "ColumnHigh";
            this.ColumnHigh.ReadOnly = true;
            this.ColumnHigh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHigh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnHigh.Width = 54;
            // 
            // ColumnLow
            // 
            this.ColumnLow.HeaderText = "Low";
            this.ColumnLow.Name = "ColumnLow";
            this.ColumnLow.ReadOnly = true;
            this.ColumnLow.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnLow.Width = 52;
            // 
            // ColumnClose
            // 
            this.ColumnClose.HeaderText = "Close";
            this.ColumnClose.Name = "ColumnClose";
            this.ColumnClose.ReadOnly = true;
            this.ColumnClose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnClose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnClose.Width = 58;
            // 
            // ColumnDailyChangePer
            // 
            this.ColumnDailyChangePer.HeaderText = "Daily";
            this.ColumnDailyChangePer.Name = "ColumnDailyChangePer";
            this.ColumnDailyChangePer.ReadOnly = true;
            this.ColumnDailyChangePer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDailyChangePer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnDailyChangePer.Width = 55;
            // 
            // ColumnOne
            // 
            this.ColumnOne.HeaderText = "One";
            this.ColumnOne.Name = "ColumnOne";
            this.ColumnOne.ReadOnly = true;
            this.ColumnOne.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnOne.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnOne.Width = 52;
            // 
            // ColumnTwo
            // 
            this.ColumnTwo.HeaderText = "Two";
            this.ColumnTwo.Name = "ColumnTwo";
            this.ColumnTwo.ReadOnly = true;
            this.ColumnTwo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTwo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnTwo.Width = 53;
            // 
            // ColumnTwoPer
            // 
            this.ColumnTwoPer.HeaderText = "TwoPer";
            this.ColumnTwoPer.Name = "ColumnTwoPer";
            this.ColumnTwoPer.ReadOnly = true;
            this.ColumnTwoPer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTwoPer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnTwoPer.Width = 69;
            // 
            // ColumnQualtityForPosition
            // 
            this.ColumnQualtityForPosition.HeaderText = "QFP";
            this.ColumnQualtityForPosition.Name = "ColumnQualtityForPosition";
            this.ColumnQualtityForPosition.ReadOnly = true;
            this.ColumnQualtityForPosition.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnQualtityForPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnQualtityForPosition.Width = 53;
            // 
            // ColumnSignaled
            // 
            this.ColumnSignaled.HeaderText = "Signaled";
            this.ColumnSignaled.Name = "ColumnSignaled";
            this.ColumnSignaled.ReadOnly = true;
            this.ColumnSignaled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSignaled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnSignaled.Width = 73;
            // 
            // ColumnHit
            // 
            this.ColumnHit.HeaderText = "Hit";
            this.ColumnHit.Name = "ColumnHit";
            this.ColumnHit.ReadOnly = true;
            this.ColumnHit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnHit.Width = 45;
            // 
            // ColumnTimeAnalyzed
            // 
            this.ColumnTimeAnalyzed.HeaderText = "Time Analyzed";
            this.ColumnTimeAnalyzed.Name = "ColumnTimeAnalyzed";
            this.ColumnTimeAnalyzed.ReadOnly = true;
            this.ColumnTimeAnalyzed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTimeAnalyzed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnTimeAnalyzed.Width = 101;
            // 
            // ColumnTest
            // 
            this.ColumnTest.HeaderText = "Test";
            this.ColumnTest.Name = "ColumnTest";
            this.ColumnTest.ReadOnly = true;
            this.ColumnTest.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnTest.Width = 53;
            // 
            // ucStocksDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.dataGridViewAsListStocks);
            this.Name = "ucStocksDataGridView";
            this.Size = new System.Drawing.Size(680, 501);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsListStocks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewAsList dataGridViewAsListStocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHigh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDailyChangePer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTwo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTwoPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQualtityForPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSignaled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTimeAnalyzed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTest;
    }
}
