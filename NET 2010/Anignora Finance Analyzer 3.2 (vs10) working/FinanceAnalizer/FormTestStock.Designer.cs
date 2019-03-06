namespace FinanceAnalizer
{
    partial class FormTestStock
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
            this.listBoxStocks = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSmallAvg = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownPosRes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNegRes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLargeAvg = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.labelTotalPer = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTotalMissCount = new System.Windows.Forms.Label();
            this.labelTotalMissPer = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelTotalHitsCount = new System.Windows.Forms.Label();
            this.labelTotalHitsPer = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelShortMissCount = new System.Windows.Forms.Label();
            this.labelShortMissPer = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelShortHitCount = new System.Windows.Forms.Label();
            this.labelShortHitPer = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelLongMissCount = new System.Windows.Forms.Label();
            this.labelLongMissPer = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelLongHitCount = new System.Windows.Forms.Label();
            this.labelLongHitPer = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownDaysForTrans = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.anignoGraphDisplayClose = new AnignoLibrary.UI.Graphs.AnignoGraphDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmallAvg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNegRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLargeAvg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaysForTrans)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxStocks
            // 
            this.listBoxStocks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxStocks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxStocks.FormattingEnabled = true;
            this.listBoxStocks.IntegralHeight = false;
            this.listBoxStocks.Location = new System.Drawing.Point(12, 25);
            this.listBoxStocks.Name = "listBoxStocks";
            this.listBoxStocks.Size = new System.Drawing.Size(117, 368);
            this.listBoxStocks.TabIndex = 11;
            this.listBoxStocks.SelectedIndexChanged += new System.EventHandler(this.listBoxStocks_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Stocks:";
            // 
            // numericUpDownSmallAvg
            // 
            this.numericUpDownSmallAvg.Location = new System.Drawing.Point(73, 19);
            this.numericUpDownSmallAvg.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSmallAvg.Name = "numericUpDownSmallAvg";
            this.numericUpDownSmallAvg.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownSmallAvg.TabIndex = 13;
            this.numericUpDownSmallAvg.ValueChanged += new System.EventHandler(this.numericUpDownSmallAvg_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "SmallAvg:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "LargeAvg:";
            // 
            // numericUpDownPosRes
            // 
            this.numericUpDownPosRes.Location = new System.Drawing.Point(73, 97);
            this.numericUpDownPosRes.Name = "numericUpDownPosRes";
            this.numericUpDownPosRes.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownPosRes.TabIndex = 16;
            this.numericUpDownPosRes.ValueChanged += new System.EventHandler(this.numericUpDownSmallAvg_ValueChanged);
            // 
            // numericUpDownNegRes
            // 
            this.numericUpDownNegRes.Location = new System.Drawing.Point(73, 71);
            this.numericUpDownNegRes.Name = "numericUpDownNegRes";
            this.numericUpDownNegRes.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownNegRes.TabIndex = 17;
            this.numericUpDownNegRes.ValueChanged += new System.EventHandler(this.numericUpDownSmallAvg_ValueChanged);
            // 
            // numericUpDownLargeAvg
            // 
            this.numericUpDownLargeAvg.Location = new System.Drawing.Point(73, 45);
            this.numericUpDownLargeAvg.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownLargeAvg.Name = "numericUpDownLargeAvg";
            this.numericUpDownLargeAvg.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownLargeAvg.TabIndex = 18;
            this.numericUpDownLargeAvg.ValueChanged += new System.EventHandler(this.numericUpDownSmallAvg_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "NegResult:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "PosResult";
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.AllowUserToOrderColumns = true;
            this.dataGridViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewMain.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewMain.Location = new System.Drawing.Point(135, 25);
            this.dataGridViewMain.MultiSelect = false;
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowHeadersVisible = false;
            this.dataGridViewMain.Size = new System.Drawing.Size(456, 368);
            this.dataGridViewMain.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(597, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 122);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results summery:";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.labelTotalPer);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Location = new System.Drawing.Point(274, 87);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(51, 20);
            this.panel7.TabIndex = 36;
            // 
            // labelTotalPer
            // 
            this.labelTotalPer.Location = new System.Drawing.Point(3, 0);
            this.labelTotalPer.Name = "labelTotalPer";
            this.labelTotalPer.Size = new System.Drawing.Size(30, 15);
            this.labelTotalPer.TabIndex = 23;
            this.labelTotalPer.Text = "000";
            this.labelTotalPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(31, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "%";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelTotalMissCount);
            this.panel2.Controls.Add(this.labelTotalMissPer);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(236, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(89, 20);
            this.panel2.TabIndex = 35;
            // 
            // labelTotalMissCount
            // 
            this.labelTotalMissCount.Location = new System.Drawing.Point(3, 0);
            this.labelTotalMissCount.Name = "labelTotalMissCount";
            this.labelTotalMissCount.Size = new System.Drawing.Size(30, 15);
            this.labelTotalMissCount.TabIndex = 17;
            this.labelTotalMissCount.Text = "000";
            this.labelTotalMissCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalMissPer
            // 
            this.labelTotalMissPer.Location = new System.Drawing.Point(39, 0);
            this.labelTotalMissPer.Name = "labelTotalMissPer";
            this.labelTotalMissPer.Size = new System.Drawing.Size(30, 15);
            this.labelTotalMissPer.TabIndex = 23;
            this.labelTotalMissPer.Text = "000";
            this.labelTotalMissPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(67, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "%";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.labelTotalHitsCount);
            this.panel5.Controls.Add(this.labelTotalHitsPer);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Location = new System.Drawing.Point(236, 35);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(89, 20);
            this.panel5.TabIndex = 34;
            // 
            // labelTotalHitsCount
            // 
            this.labelTotalHitsCount.Location = new System.Drawing.Point(3, 0);
            this.labelTotalHitsCount.Name = "labelTotalHitsCount";
            this.labelTotalHitsCount.Size = new System.Drawing.Size(30, 15);
            this.labelTotalHitsCount.TabIndex = 17;
            this.labelTotalHitsCount.Text = "000";
            this.labelTotalHitsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalHitsPer
            // 
            this.labelTotalHitsPer.Location = new System.Drawing.Point(39, 0);
            this.labelTotalHitsPer.Name = "labelTotalHitsPer";
            this.labelTotalHitsPer.Size = new System.Drawing.Size(30, 15);
            this.labelTotalHitsPer.TabIndex = 23;
            this.labelTotalHitsPer.Text = "000";
            this.labelTotalHitsPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(67, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "%";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(233, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "Total";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.labelShortMissCount);
            this.panel4.Controls.Add(this.labelShortMissPer);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Location = new System.Drawing.Point(141, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(89, 20);
            this.panel4.TabIndex = 32;
            // 
            // labelShortMissCount
            // 
            this.labelShortMissCount.Location = new System.Drawing.Point(3, 0);
            this.labelShortMissCount.Name = "labelShortMissCount";
            this.labelShortMissCount.Size = new System.Drawing.Size(30, 15);
            this.labelShortMissCount.TabIndex = 17;
            this.labelShortMissCount.Text = "000";
            this.labelShortMissCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelShortMissPer
            // 
            this.labelShortMissPer.Location = new System.Drawing.Point(39, 0);
            this.labelShortMissPer.Name = "labelShortMissPer";
            this.labelShortMissPer.Size = new System.Drawing.Size(30, 15);
            this.labelShortMissPer.TabIndex = 23;
            this.labelShortMissPer.Text = "000";
            this.labelShortMissPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(67, 2);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 13);
            this.label24.TabIndex = 22;
            this.label24.Text = "%";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.labelShortHitCount);
            this.panel6.Controls.Add(this.labelShortHitPer);
            this.panel6.Controls.Add(this.label30);
            this.panel6.Location = new System.Drawing.Point(141, 34);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(89, 20);
            this.panel6.TabIndex = 30;
            // 
            // labelShortHitCount
            // 
            this.labelShortHitCount.Location = new System.Drawing.Point(3, 0);
            this.labelShortHitCount.Name = "labelShortHitCount";
            this.labelShortHitCount.Size = new System.Drawing.Size(30, 15);
            this.labelShortHitCount.TabIndex = 17;
            this.labelShortHitCount.Text = "000";
            this.labelShortHitCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelShortHitPer
            // 
            this.labelShortHitPer.Location = new System.Drawing.Point(39, 0);
            this.labelShortHitPer.Name = "labelShortHitPer";
            this.labelShortHitPer.Size = new System.Drawing.Size(30, 15);
            this.labelShortHitPer.TabIndex = 23;
            this.labelShortHitPer.Text = "000";
            this.labelShortHitPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(67, 2);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(15, 13);
            this.label30.TabIndex = 22;
            this.label30.Text = "%";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.labelLongMissCount);
            this.panel3.Controls.Add(this.labelLongMissPer);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Location = new System.Drawing.Point(46, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(89, 20);
            this.panel3.TabIndex = 29;
            // 
            // labelLongMissCount
            // 
            this.labelLongMissCount.Location = new System.Drawing.Point(3, 0);
            this.labelLongMissCount.Name = "labelLongMissCount";
            this.labelLongMissCount.Size = new System.Drawing.Size(30, 15);
            this.labelLongMissCount.TabIndex = 17;
            this.labelLongMissCount.Text = "000";
            this.labelLongMissCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLongMissPer
            // 
            this.labelLongMissPer.Location = new System.Drawing.Point(39, 0);
            this.labelLongMissPer.Name = "labelLongMissPer";
            this.labelLongMissPer.Size = new System.Drawing.Size(30, 15);
            this.labelLongMissPer.TabIndex = 23;
            this.labelLongMissPer.Text = "000";
            this.labelLongMissPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(67, 2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(15, 13);
            this.label21.TabIndex = 22;
            this.label21.Text = "%";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelLongHitCount);
            this.panel1.Controls.Add(this.labelLongHitPer);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(46, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(89, 20);
            this.panel1.TabIndex = 27;
            // 
            // labelLongHitCount
            // 
            this.labelLongHitCount.Location = new System.Drawing.Point(3, 0);
            this.labelLongHitCount.Name = "labelLongHitCount";
            this.labelLongHitCount.Size = new System.Drawing.Size(30, 15);
            this.labelLongHitCount.TabIndex = 17;
            this.labelLongHitCount.Text = "000";
            this.labelLongHitCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLongHitPer
            // 
            this.labelLongHitPer.Location = new System.Drawing.Point(39, 0);
            this.labelLongHitPer.Name = "labelLongHitPer";
            this.labelLongHitPer.Size = new System.Drawing.Size(30, 15);
            this.labelLongHitPer.TabIndex = 23;
            this.labelLongHitPer.Text = "000";
            this.labelLongHitPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(67, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Hit:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Miss:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Short";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Long";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.numericUpDownDaysForTrans);
            this.groupBox2.Controls.Add(this.dateTimePickerStart);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numericUpDownSmallAvg);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numericUpDownPosRes);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDownNegRes);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericUpDownLargeAvg);
            this.groupBox2.Location = new System.Drawing.Point(12, 399);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 141);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test parameters:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(131, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Days for transaction:";
            // 
            // numericUpDownDaysForTrans
            // 
            this.numericUpDownDaysForTrans.Location = new System.Drawing.Point(258, 40);
            this.numericUpDownDaysForTrans.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownDaysForTrans.Name = "numericUpDownDaysForTrans";
            this.numericUpDownDaysForTrans.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownDaysForTrans.TabIndex = 23;
            this.numericUpDownDaysForTrans.ValueChanged += new System.EventHandler(this.numericUpDownSmallAvg_ValueChanged);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.Location = new System.Drawing.Point(258, 17);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ShowUpDown = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(95, 20);
            this.dateTimePickerStart.TabIndex = 22;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.numericUpDownSmallAvg_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(129, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Start date:";
            // 
            // anignoGraphDisplayClose
            // 
            this.anignoGraphDisplayClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.anignoGraphDisplayClose.AutoGridScale = true;
            this.anignoGraphDisplayClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anignoGraphDisplayClose.ColorGrid = System.Drawing.Color.Gray;
            this.anignoGraphDisplayClose.ColorZeroAxes = System.Drawing.Color.White;
            this.anignoGraphDisplayClose.DrawGrid = true;
            this.anignoGraphDisplayClose.DrawGridNumbers = false;
            this.anignoGraphDisplayClose.GridMaxY = 100F;
            this.anignoGraphDisplayClose.GridMinY = -100F;
            this.anignoGraphDisplayClose.Location = new System.Drawing.Point(597, 25);
            this.anignoGraphDisplayClose.Name = "anignoGraphDisplayClose";
            this.anignoGraphDisplayClose.Size = new System.Drawing.Size(349, 240);
            this.anignoGraphDisplayClose.TabIndex = 25;
            this.anignoGraphDisplayClose.X_GridLines = 10;
            this.anignoGraphDisplayClose.Y_GridLines = 5;
            // 
            // FormTestStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 552);
            this.Controls.Add(this.anignoGraphDisplayClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxStocks);
            this.MinimumSize = new System.Drawing.Size(830, 500);
            this.Name = "FormTestStock";
            this.Text = "Test stock";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmallAvg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPosRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNegRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLargeAvg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDaysForTrans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxStocks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSmallAvg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownPosRes;
        private System.Windows.Forms.NumericUpDown numericUpDownNegRes;
        private System.Windows.Forms.NumericUpDown numericUpDownLargeAvg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownDaysForTrans;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelLongHitPer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelLongHitCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelShortMissCount;
        private System.Windows.Forms.Label labelShortMissPer;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label labelShortHitCount;
        private System.Windows.Forms.Label labelShortHitPer;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelLongMissCount;
        private System.Windows.Forms.Label labelLongMissPer;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTotalMissCount;
        private System.Windows.Forms.Label labelTotalMissPer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelTotalHitsCount;
        private System.Windows.Forms.Label labelTotalHitsPer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label labelTotalPer;
        private System.Windows.Forms.Label label16;
        private AnignoLibrary.UI.Graphs.AnignoGraphDisplay anignoGraphDisplayClose;
    }
}