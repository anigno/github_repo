namespace FinanceAnalizer3.UI
{
    partial class FormTestStocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTestStocks));
            this.listViewStocksNames = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxAddSnP = new System.Windows.Forms.CheckBox();
            this.checkBoxCsv = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelHitsLongPer = new System.Windows.Forms.Label();
            this.labelHitsLongNum = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelMissesLongNum = new System.Windows.Forms.Label();
            this.labelMissesLongPer = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelMissesShortNum = new System.Windows.Forms.Label();
            this.labelMissesShortPer = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelHitsShortNum = new System.Windows.Forms.Label();
            this.labelHitsShortPer = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelMissesTotalNum = new System.Windows.Forms.Label();
            this.labelMissesTotalPer = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.labelHitsTotalNum = new System.Windows.Forms.Label();
            this.labelHitsTotalPer = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelTotalTotalNum = new System.Windows.Forms.Label();
            this.labelTotalTotalPer = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.labelTotalShortNum = new System.Windows.Forms.Label();
            this.labelTotalShortPer = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.labelTotalLongNum = new System.Windows.Forms.Label();
            this.labelTotalLongPer = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.anignoGraphDisplay = new AnignoLibrary.UI.Graphs.AnignoGraphDisplay();
            this.buttonCheckAll = new System.Windows.Forms.Button();
            this.buttonCheckNone = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewStocksNames
            // 
            this.listViewStocksNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewStocksNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewStocksNames.CheckBoxes = true;
            this.listViewStocksNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewStocksNames.Location = new System.Drawing.Point(12, 182);
            this.listViewStocksNames.Name = "listViewStocksNames";
            this.listViewStocksNames.Size = new System.Drawing.Size(136, 436);
            this.listViewStocksNames.TabIndex = 0;
            this.listViewStocksNames.UseCompatibleStateImageBehavior = false;
            this.listViewStocksNames.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Stocks Names";
            this.columnHeader1.Width = 91;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalculate.ForeColor = System.Drawing.Color.Navy;
            this.buttonCalculate.Location = new System.Drawing.Point(6, 105);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(122, 23);
            this.buttonCalculate.TabIndex = 1;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = false;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(42, 3);
            this.dateTimePickerFrom.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.ShowUpDown = true;
            this.dateTimePickerFrom.Size = new System.Drawing.Size(86, 20);
            this.dateTimePickerFrom.TabIndex = 4;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(42, 29);
            this.dateTimePickerTo.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.ShowUpDown = true;
            this.dateTimePickerTo.Size = new System.Drawing.Size(86, 20);
            this.dateTimePickerTo.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxAddSnP);
            this.panel1.Controls.Add(this.checkBoxCsv);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonCalculate);
            this.panel1.Controls.Add(this.dateTimePickerTo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePickerFrom);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 135);
            this.panel1.TabIndex = 6;
            // 
            // checkBoxAddSnP
            // 
            this.checkBoxAddSnP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAddSnP.Location = new System.Drawing.Point(6, 80);
            this.checkBoxAddSnP.Name = "checkBoxAddSnP";
            this.checkBoxAddSnP.Size = new System.Drawing.Size(122, 19);
            this.checkBoxAddSnP.TabIndex = 7;
            this.checkBoxAddSnP.Text = "Add S&&P data";
            this.checkBoxAddSnP.UseVisualStyleBackColor = true;
            // 
            // checkBoxCsv
            // 
            this.checkBoxCsv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCsv.Location = new System.Drawing.Point(6, 55);
            this.checkBoxCsv.Name = "checkBoxCsv";
            this.checkBoxCsv.Size = new System.Drawing.Size(122, 19);
            this.checkBoxCsv.TabIndex = 6;
            this.checkBoxCsv.Text = "Export to CSV";
            this.checkBoxCsv.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(13, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(107, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "%";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHitsLongPer
            // 
            this.labelHitsLongPer.BackColor = System.Drawing.Color.Transparent;
            this.labelHitsLongPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelHitsLongPer.Location = new System.Drawing.Point(52, 7);
            this.labelHitsLongPer.Name = "labelHitsLongPer";
            this.labelHitsLongPer.Size = new System.Drawing.Size(65, 23);
            this.labelHitsLongPer.TabIndex = 8;
            this.labelHitsLongPer.Text = "0000.00";
            this.labelHitsLongPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHitsLongNum
            // 
            this.labelHitsLongNum.BackColor = System.Drawing.Color.Transparent;
            this.labelHitsLongNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelHitsLongNum.Location = new System.Drawing.Point(4, 7);
            this.labelHitsLongNum.Name = "labelHitsLongNum";
            this.labelHitsLongNum.Size = new System.Drawing.Size(42, 23);
            this.labelHitsLongNum.TabIndex = 7;
            this.labelHitsLongNum.Text = "0000";
            this.labelHitsLongNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelHitsLongNum);
            this.panel2.Controls.Add(this.labelHitsLongPer);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(83, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(146, 36);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.labelMissesLongNum);
            this.panel3.Controls.Add(this.labelMissesLongPer);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(235, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(146, 36);
            this.panel3.TabIndex = 11;
            // 
            // labelMissesLongNum
            // 
            this.labelMissesLongNum.BackColor = System.Drawing.Color.Transparent;
            this.labelMissesLongNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMissesLongNum.Location = new System.Drawing.Point(4, 7);
            this.labelMissesLongNum.Name = "labelMissesLongNum";
            this.labelMissesLongNum.Size = new System.Drawing.Size(42, 23);
            this.labelMissesLongNum.TabIndex = 7;
            this.labelMissesLongNum.Text = "0000";
            this.labelMissesLongNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMissesLongPer
            // 
            this.labelMissesLongPer.BackColor = System.Drawing.Color.Transparent;
            this.labelMissesLongPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMissesLongPer.Location = new System.Drawing.Point(52, 7);
            this.labelMissesLongPer.Name = "labelMissesLongPer";
            this.labelMissesLongPer.Size = new System.Drawing.Size(65, 23);
            this.labelMissesLongPer.TabIndex = 8;
            this.labelMissesLongPer.Text = "0000.00";
            this.labelMissesLongPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(107, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 23);
            this.label11.TabIndex = 9;
            this.label11.Text = "%";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.labelMissesShortNum);
            this.panel4.Controls.Add(this.labelMissesShortPer);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Location = new System.Drawing.Point(235, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(146, 36);
            this.panel4.TabIndex = 13;
            // 
            // labelMissesShortNum
            // 
            this.labelMissesShortNum.BackColor = System.Drawing.Color.Transparent;
            this.labelMissesShortNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMissesShortNum.Location = new System.Drawing.Point(4, 7);
            this.labelMissesShortNum.Name = "labelMissesShortNum";
            this.labelMissesShortNum.Size = new System.Drawing.Size(42, 23);
            this.labelMissesShortNum.TabIndex = 7;
            this.labelMissesShortNum.Text = "0000";
            this.labelMissesShortNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMissesShortPer
            // 
            this.labelMissesShortPer.BackColor = System.Drawing.Color.Transparent;
            this.labelMissesShortPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMissesShortPer.Location = new System.Drawing.Point(52, 7);
            this.labelMissesShortPer.Name = "labelMissesShortPer";
            this.labelMissesShortPer.Size = new System.Drawing.Size(65, 23);
            this.labelMissesShortPer.TabIndex = 8;
            this.labelMissesShortPer.Text = "0000.00";
            this.labelMissesShortPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label14.Location = new System.Drawing.Point(107, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 23);
            this.label14.TabIndex = 9;
            this.label14.Text = "%";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.labelHitsShortNum);
            this.panel5.Controls.Add(this.labelHitsShortPer);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Location = new System.Drawing.Point(83, 80);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(146, 36);
            this.panel5.TabIndex = 12;
            // 
            // labelHitsShortNum
            // 
            this.labelHitsShortNum.BackColor = System.Drawing.Color.Transparent;
            this.labelHitsShortNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelHitsShortNum.Location = new System.Drawing.Point(4, 7);
            this.labelHitsShortNum.Name = "labelHitsShortNum";
            this.labelHitsShortNum.Size = new System.Drawing.Size(42, 23);
            this.labelHitsShortNum.TabIndex = 7;
            this.labelHitsShortNum.Text = "0000";
            this.labelHitsShortNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHitsShortPer
            // 
            this.labelHitsShortPer.BackColor = System.Drawing.Color.Transparent;
            this.labelHitsShortPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelHitsShortPer.Location = new System.Drawing.Point(52, 7);
            this.labelHitsShortPer.Name = "labelHitsShortPer";
            this.labelHitsShortPer.Size = new System.Drawing.Size(65, 23);
            this.labelHitsShortPer.TabIndex = 8;
            this.labelHitsShortPer.Text = "0000.00";
            this.labelHitsShortPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label17.Location = new System.Drawing.Point(107, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 23);
            this.label17.TabIndex = 9;
            this.label17.Text = "%";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.labelMissesTotalNum);
            this.panel6.Controls.Add(this.labelMissesTotalPer);
            this.panel6.Controls.Add(this.label20);
            this.panel6.Location = new System.Drawing.Point(235, 122);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(146, 36);
            this.panel6.TabIndex = 13;
            // 
            // labelMissesTotalNum
            // 
            this.labelMissesTotalNum.BackColor = System.Drawing.Color.Transparent;
            this.labelMissesTotalNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMissesTotalNum.Location = new System.Drawing.Point(4, 7);
            this.labelMissesTotalNum.Name = "labelMissesTotalNum";
            this.labelMissesTotalNum.Size = new System.Drawing.Size(42, 23);
            this.labelMissesTotalNum.TabIndex = 7;
            this.labelMissesTotalNum.Text = "0000";
            this.labelMissesTotalNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMissesTotalPer
            // 
            this.labelMissesTotalPer.BackColor = System.Drawing.Color.Transparent;
            this.labelMissesTotalPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMissesTotalPer.Location = new System.Drawing.Point(52, 7);
            this.labelMissesTotalPer.Name = "labelMissesTotalPer";
            this.labelMissesTotalPer.Size = new System.Drawing.Size(65, 23);
            this.labelMissesTotalPer.TabIndex = 8;
            this.labelMissesTotalPer.Text = "0000.00";
            this.labelMissesTotalPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label20.Location = new System.Drawing.Point(107, 7);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 23);
            this.label20.TabIndex = 9;
            this.label20.Text = "%";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.labelHitsTotalNum);
            this.panel7.Controls.Add(this.labelHitsTotalPer);
            this.panel7.Controls.Add(this.label23);
            this.panel7.Location = new System.Drawing.Point(83, 122);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(146, 36);
            this.panel7.TabIndex = 12;
            // 
            // labelHitsTotalNum
            // 
            this.labelHitsTotalNum.BackColor = System.Drawing.Color.Transparent;
            this.labelHitsTotalNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelHitsTotalNum.Location = new System.Drawing.Point(4, 7);
            this.labelHitsTotalNum.Name = "labelHitsTotalNum";
            this.labelHitsTotalNum.Size = new System.Drawing.Size(42, 23);
            this.labelHitsTotalNum.TabIndex = 7;
            this.labelHitsTotalNum.Text = "0000";
            this.labelHitsTotalNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHitsTotalPer
            // 
            this.labelHitsTotalPer.BackColor = System.Drawing.Color.Transparent;
            this.labelHitsTotalPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelHitsTotalPer.Location = new System.Drawing.Point(52, 7);
            this.labelHitsTotalPer.Name = "labelHitsTotalPer";
            this.labelHitsTotalPer.Size = new System.Drawing.Size(65, 23);
            this.labelHitsTotalPer.TabIndex = 8;
            this.labelHitsTotalPer.Text = "0000.00";
            this.labelHitsTotalPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label23.Location = new System.Drawing.Point(107, 7);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(36, 23);
            this.label23.TabIndex = 9;
            this.label23.Text = "%";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.labelTotalTotalNum);
            this.panel8.Controls.Add(this.labelTotalTotalPer);
            this.panel8.Controls.Add(this.label26);
            this.panel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.panel8.Location = new System.Drawing.Point(387, 122);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(146, 36);
            this.panel8.TabIndex = 15;
            // 
            // labelTotalTotalNum
            // 
            this.labelTotalTotalNum.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalTotalNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelTotalTotalNum.Location = new System.Drawing.Point(4, 7);
            this.labelTotalTotalNum.Name = "labelTotalTotalNum";
            this.labelTotalTotalNum.Size = new System.Drawing.Size(50, 23);
            this.labelTotalTotalNum.TabIndex = 7;
            this.labelTotalTotalNum.Text = "0000";
            this.labelTotalTotalNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalTotalPer
            // 
            this.labelTotalTotalPer.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalTotalPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelTotalTotalPer.Location = new System.Drawing.Point(52, 9);
            this.labelTotalTotalPer.Name = "labelTotalTotalPer";
            this.labelTotalTotalPer.Size = new System.Drawing.Size(65, 23);
            this.labelTotalTotalPer.TabIndex = 8;
            this.labelTotalTotalPer.Text = "0000.00";
            this.labelTotalTotalPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label26.Location = new System.Drawing.Point(107, 7);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(36, 23);
            this.label26.TabIndex = 9;
            this.label26.Text = "%";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.labelTotalShortNum);
            this.panel9.Controls.Add(this.labelTotalShortPer);
            this.panel9.Controls.Add(this.label29);
            this.panel9.Location = new System.Drawing.Point(387, 80);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(146, 36);
            this.panel9.TabIndex = 16;
            // 
            // labelTotalShortNum
            // 
            this.labelTotalShortNum.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalShortNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelTotalShortNum.Location = new System.Drawing.Point(4, 7);
            this.labelTotalShortNum.Name = "labelTotalShortNum";
            this.labelTotalShortNum.Size = new System.Drawing.Size(42, 23);
            this.labelTotalShortNum.TabIndex = 7;
            this.labelTotalShortNum.Text = "0000";
            this.labelTotalShortNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalShortPer
            // 
            this.labelTotalShortPer.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalShortPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelTotalShortPer.Location = new System.Drawing.Point(52, 7);
            this.labelTotalShortPer.Name = "labelTotalShortPer";
            this.labelTotalShortPer.Size = new System.Drawing.Size(65, 23);
            this.labelTotalShortPer.TabIndex = 8;
            this.labelTotalShortPer.Text = "0000.00";
            this.labelTotalShortPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label29.Location = new System.Drawing.Point(107, 7);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(36, 23);
            this.label29.TabIndex = 9;
            this.label29.Text = "%";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.labelTotalLongNum);
            this.panel10.Controls.Add(this.labelTotalLongPer);
            this.panel10.Controls.Add(this.label32);
            this.panel10.Location = new System.Drawing.Point(387, 38);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(146, 36);
            this.panel10.TabIndex = 14;
            // 
            // labelTotalLongNum
            // 
            this.labelTotalLongNum.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalLongNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelTotalLongNum.Location = new System.Drawing.Point(4, 7);
            this.labelTotalLongNum.Name = "labelTotalLongNum";
            this.labelTotalLongNum.Size = new System.Drawing.Size(42, 23);
            this.labelTotalLongNum.TabIndex = 7;
            this.labelTotalLongNum.Text = "0000";
            this.labelTotalLongNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalLongPer
            // 
            this.labelTotalLongPer.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalLongPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelTotalLongPer.Location = new System.Drawing.Point(52, 7);
            this.labelTotalLongPer.Name = "labelTotalLongPer";
            this.labelTotalLongPer.Size = new System.Drawing.Size(65, 23);
            this.labelTotalLongPer.TabIndex = 8;
            this.labelTotalLongPer.Text = "0000.00";
            this.labelTotalLongPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label32.Location = new System.Drawing.Point(107, 7);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(36, 23);
            this.label32.TabIndex = 9;
            this.label32.Text = "%";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Long:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(12, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Short:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(12, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Total:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(87, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 23);
            this.label7.TabIndex = 20;
            this.label7.Text = "Hits";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(239, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 23);
            this.label8.TabIndex = 21;
            this.label8.Text = "Misses";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label33.Location = new System.Drawing.Point(391, 12);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(139, 23);
            this.label33.TabIndex = 22;
            this.label33.Text = "Total:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label4);
            this.panel11.Controls.Add(this.label33);
            this.panel11.Controls.Add(this.panel2);
            this.panel11.Controls.Add(this.label8);
            this.panel11.Controls.Add(this.panel5);
            this.panel11.Controls.Add(this.label7);
            this.panel11.Controls.Add(this.panel3);
            this.panel11.Controls.Add(this.label6);
            this.panel11.Controls.Add(this.panel7);
            this.panel11.Controls.Add(this.label5);
            this.panel11.Controls.Add(this.panel10);
            this.panel11.Controls.Add(this.panel4);
            this.panel11.Controls.Add(this.panel8);
            this.panel11.Controls.Add(this.panel9);
            this.panel11.Controls.Add(this.panel6);
            this.panel11.Location = new System.Drawing.Point(154, 12);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(544, 171);
            this.panel11.TabIndex = 23;
            // 
            // anignoGraphDisplay
            // 
            this.anignoGraphDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.anignoGraphDisplay.AutoGridScale = true;
            this.anignoGraphDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anignoGraphDisplay.ColorGrid = System.Drawing.Color.Gray;
            this.anignoGraphDisplay.ColorZeroAxes = System.Drawing.Color.White;
            this.anignoGraphDisplay.DrawGrid = true;
            this.anignoGraphDisplay.DrawGridNumbers = true;
            this.anignoGraphDisplay.GridMaxY = 100F;
            this.anignoGraphDisplay.GridMinY = -100F;
            this.anignoGraphDisplay.Location = new System.Drawing.Point(154, 189);
            this.anignoGraphDisplay.Name = "anignoGraphDisplay";
            this.anignoGraphDisplay.Size = new System.Drawing.Size(554, 429);
            this.anignoGraphDisplay.TabIndex = 24;
            this.anignoGraphDisplay.X_GridLines = 10;
            this.anignoGraphDisplay.Y_GridLines = 5;
            // 
            // buttonCheckAll
            // 
            this.buttonCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckAll.Location = new System.Drawing.Point(12, 153);
            this.buttonCheckAll.Name = "buttonCheckAll";
            this.buttonCheckAll.Size = new System.Drawing.Size(48, 23);
            this.buttonCheckAll.TabIndex = 6;
            this.buttonCheckAll.Text = "All";
            this.buttonCheckAll.UseVisualStyleBackColor = true;
            this.buttonCheckAll.Click += new System.EventHandler(this.buttonCheckAll_Click);
            // 
            // buttonCheckNone
            // 
            this.buttonCheckNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckNone.Location = new System.Drawing.Point(100, 153);
            this.buttonCheckNone.Name = "buttonCheckNone";
            this.buttonCheckNone.Size = new System.Drawing.Size(48, 23);
            this.buttonCheckNone.TabIndex = 25;
            this.buttonCheckNone.Text = "None";
            this.buttonCheckNone.UseVisualStyleBackColor = true;
            this.buttonCheckNone.Click += new System.EventHandler(this.buttonCheckNone_Click);
            // 
            // FormTestStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 630);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCheckNone);
            this.Controls.Add(this.buttonCheckAll);
            this.Controls.Add(this.anignoGraphDisplay);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.listViewStocksNames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTestStocks";
            this.Text = "Test Stocks";
            this.Load += new System.EventHandler(this.FormTestStocks_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewStocksNames;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelHitsLongPer;
        private System.Windows.Forms.Label labelHitsLongNum;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelMissesLongNum;
        private System.Windows.Forms.Label labelMissesLongPer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelMissesShortNum;
        private System.Windows.Forms.Label labelMissesShortPer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelHitsShortNum;
        private System.Windows.Forms.Label labelHitsShortPer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label labelMissesTotalNum;
        private System.Windows.Forms.Label labelMissesTotalPer;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label labelHitsTotalNum;
        private System.Windows.Forms.Label labelHitsTotalPer;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label labelTotalTotalNum;
        private System.Windows.Forms.Label labelTotalTotalPer;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label labelTotalShortNum;
        private System.Windows.Forms.Label labelTotalShortPer;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label labelTotalLongNum;
        private System.Windows.Forms.Label labelTotalLongPer;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Panel panel11;
        private AnignoLibrary.UI.Graphs.AnignoGraphDisplay anignoGraphDisplay;
        private System.Windows.Forms.Button buttonCheckAll;
        private System.Windows.Forms.Button buttonCheckNone;
        private System.Windows.Forms.CheckBox checkBoxCsv;
        private System.Windows.Forms.CheckBox checkBoxAddSnP;
    }
}