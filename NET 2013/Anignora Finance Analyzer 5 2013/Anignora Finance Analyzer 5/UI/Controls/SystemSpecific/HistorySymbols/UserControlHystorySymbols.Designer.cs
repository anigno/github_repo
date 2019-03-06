namespace AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.HistorySymbols
{
    partial class UserControlHystorySymbols
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numericUpDownHistoryLength = new System.Windows.Forms.NumericUpDown();
            this.graphDateToFloatHistory = new AnignoraUI.Graphs.GraphDateToFloat();
            this.labelMessage = new System.Windows.Forms.Label();
            this.dataGridViewAutoHistory = new AnignoraUI.Grids.DataGridViewAuto.DataGridViewAuto();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistoryLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutoHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDownHistoryLength
            // 
            this.numericUpDownHistoryLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownHistoryLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numericUpDownHistoryLength.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHistoryLength.Location = new System.Drawing.Point(4, 122);
            this.numericUpDownHistoryLength.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownHistoryLength.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownHistoryLength.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHistoryLength.Name = "numericUpDownHistoryLength";
            this.numericUpDownHistoryLength.Size = new System.Drawing.Size(151, 22);
            this.numericUpDownHistoryLength.TabIndex = 0;
            this.numericUpDownHistoryLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownHistoryLength.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownHistoryLength.ValueChanged += new System.EventHandler(this.onNumericUpDownHistoryLengthValueChanged);
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
            this.graphDateToFloatHistory.GridsHorizontal = ((uint)(3u));
            this.graphDateToFloatHistory.GridsTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.graphDateToFloatHistory.GridsVertical = ((uint)(3u));
            this.graphDateToFloatHistory.GridTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.graphDateToFloatHistory.Location = new System.Drawing.Point(163, 0);
            this.graphDateToFloatHistory.Margin = new System.Windows.Forms.Padding(4);
            this.graphDateToFloatHistory.Name = "graphDateToFloatHistory";
            this.graphDateToFloatHistory.ShowGrids = true;
            this.graphDateToFloatHistory.Size = new System.Drawing.Size(496, 148);
            this.graphDateToFloatHistory.TabIndex = 1;
            this.graphDateToFloatHistory.ZeroLineColor = System.Drawing.Color.White;
            // 
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMessage.Location = new System.Drawing.Point(4, 0);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(150, 118);
            this.labelMessage.TabIndex = 2;
            this.labelMessage.Text = ". . . . . .";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewAutoHistory
            // 
            this.dataGridViewAutoHistory.AllowUserToAddRows = false;
            this.dataGridViewAutoHistory.AllowUserToDeleteRows = false;
            this.dataGridViewAutoHistory.AllowUserToOrderColumns = true;
            this.dataGridViewAutoHistory.AllowUserToResizeRows = false;
            this.dataGridViewAutoHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAutoHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewAutoHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAutoHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAutoHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAutoHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAutoHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAutoHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAutoHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewAutoHistory.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAutoHistory.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewAutoHistory.Name = "dataGridViewAutoHistory";
            this.dataGridViewAutoHistory.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewAutoHistory.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAutoHistory.RowTemplate.Height = 24;
            this.dataGridViewAutoHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewAutoHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAutoHistory.Size = new System.Drawing.Size(663, 487);
            this.dataGridViewAutoHistory.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelMessage);
            this.splitContainer1.Panel1.Controls.Add(this.graphDateToFloatHistory);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDownHistoryLength);
            this.splitContainer1.Panel1MinSize = 153;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewAutoHistory);
            this.splitContainer1.Size = new System.Drawing.Size(663, 644);
            this.splitContainer1.SplitterDistance = 153;
            this.splitContainer1.TabIndex = 4;
            // 
            // UserControlHystorySymbols
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlHystorySymbols";
            this.Size = new System.Drawing.Size(663, 644);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistoryLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutoHistory)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AnignoraUI.Graphs.GraphDateToFloat graphDateToFloatHistory;
        private System.Windows.Forms.NumericUpDown numericUpDownHistoryLength;
        private System.Windows.Forms.Label labelMessage;
        private AnignoraUI.Grids.DataGridViewAuto.DataGridViewAuto dataGridViewAutoHistory;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
