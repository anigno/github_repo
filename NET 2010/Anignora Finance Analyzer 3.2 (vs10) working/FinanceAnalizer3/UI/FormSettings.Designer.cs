namespace FinanceAnalizer3.UI
{
    partial class FormSettings
    {
		#region (------------------  Fields  ------------------)
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelAnignora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxChangeSet;
        private System.Windows.Forms.RichTextBox richTextBoxHeaderSymbols;
        private System.Windows.Forms.TextBox textBoxPassword;
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Overridden Methods  ------------------)
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
		#endregion (------------------  Overridden Methods  ------------------)




        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelAnignora = new System.Windows.Forms.Label();
            this.richTextBoxChangeSet = new System.Windows.Forms.RichTextBox();
            this.richTextBoxHeaderSymbols = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownPositionSumK = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPositionDevider = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxBrowserAHomePage = new System.Windows.Forms.TextBox();
            this.textBoxBrowserBHomePage = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPositionSumK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPositionDevider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.Black;
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBoxPassword.Location = new System.Drawing.Point(6, 19);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(163, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.BackColor = System.Drawing.Color.Black;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Location = new System.Drawing.Point(615, 541);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelAnignora
            // 
            this.labelAnignora.BackColor = System.Drawing.Color.Transparent;
            this.labelAnignora.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelAnignora.ForeColor = System.Drawing.Color.Crimson;
            this.labelAnignora.Location = new System.Drawing.Point(154, 0);
            this.labelAnignora.Name = "labelAnignora";
            this.labelAnignora.Size = new System.Drawing.Size(306, 45);
            this.labelAnignora.TabIndex = 3;
            this.labelAnignora.Text = "Anignora Solutions";
            this.labelAnignora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBoxChangeSet
            // 
            this.richTextBoxChangeSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxChangeSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richTextBoxChangeSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxChangeSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.richTextBoxChangeSet.Location = new System.Drawing.Point(12, 191);
            this.richTextBoxChangeSet.Name = "richTextBoxChangeSet";
            this.richTextBoxChangeSet.ReadOnly = true;
            this.richTextBoxChangeSet.Size = new System.Drawing.Size(678, 344);
            this.richTextBoxChangeSet.TabIndex = 4;
            this.richTextBoxChangeSet.Text = "";
            // 
            // richTextBoxHeaderSymbols
            // 
            this.richTextBoxHeaderSymbols.BackColor = System.Drawing.Color.Black;
            this.richTextBoxHeaderSymbols.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxHeaderSymbols.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.richTextBoxHeaderSymbols.Location = new System.Drawing.Point(6, 32);
            this.richTextBoxHeaderSymbols.Name = "richTextBoxHeaderSymbols";
            this.richTextBoxHeaderSymbols.Size = new System.Drawing.Size(103, 86);
            this.richTextBoxHeaderSymbols.TabIndex = 5;
            this.richTextBoxHeaderSymbols.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Header Symbols:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Change Set:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Position Sum:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Controls.Add(this.numericUpDownPositionSumK);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownPositionDevider);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 72);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quantity For Positions";
            // 
            // numericUpDownPositionSumK
            // 
            this.numericUpDownPositionSumK.BackColor = System.Drawing.Color.Black;
            this.numericUpDownPositionSumK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownPositionSumK.ForeColor = System.Drawing.Color.Yellow;
            this.numericUpDownPositionSumK.Location = new System.Drawing.Point(83, 19);
            this.numericUpDownPositionSumK.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownPositionSumK.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownPositionSumK.Name = "numericUpDownPositionSumK";
            this.numericUpDownPositionSumK.Size = new System.Drawing.Size(65, 20);
            this.numericUpDownPositionSumK.TabIndex = 12;
            this.numericUpDownPositionSumK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownPositionSumK.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDownPositionSumK.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(149, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "K$";
            // 
            // numericUpDownPositionDevider
            // 
            this.numericUpDownPositionDevider.BackColor = System.Drawing.Color.Black;
            this.numericUpDownPositionDevider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownPositionDevider.ForeColor = System.Drawing.Color.Yellow;
            this.numericUpDownPositionDevider.Location = new System.Drawing.Point(83, 46);
            this.numericUpDownPositionDevider.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPositionDevider.Name = "numericUpDownPositionDevider";
            this.numericUpDownPositionDevider.Size = new System.Drawing.Size(65, 20);
            this.numericUpDownPositionDevider.TabIndex = 11;
            this.numericUpDownPositionDevider.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownPositionDevider.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDownPositionDevider.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Devider:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Controls.Add(this.richTextBoxHeaderSymbols);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(193, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(115, 124);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Special Symbols";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.Controls.Add(this.textBoxPassword);
            this.groupBox3.Location = new System.Drawing.Point(12, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 46);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Password";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox4.Controls.Add(this.textBoxBrowserBHomePage);
            this.groupBox4.Controls.Add(this.textBoxBrowserAHomePage);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(314, 48);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(337, 73);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Web Browsers Home Pages";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Browser A:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(6, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Browser B:";
            // 
            // textBoxBrowserAHomePage
            // 
            this.textBoxBrowserAHomePage.BackColor = System.Drawing.Color.Black;
            this.textBoxBrowserAHomePage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBrowserAHomePage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBoxBrowserAHomePage.Location = new System.Drawing.Point(70, 19);
            this.textBoxBrowserAHomePage.Name = "textBoxBrowserAHomePage";
            this.textBoxBrowserAHomePage.Size = new System.Drawing.Size(261, 20);
            this.textBoxBrowserAHomePage.TabIndex = 8;
            // 
            // textBoxBrowserBHomePage
            // 
            this.textBoxBrowserBHomePage.BackColor = System.Drawing.Color.Black;
            this.textBoxBrowserBHomePage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBrowserBHomePage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBoxBrowserBHomePage.Location = new System.Drawing.Point(70, 45);
            this.textBoxBrowserBHomePage.Name = "textBoxBrowserBHomePage";
            this.textBoxBrowserBHomePage.Size = new System.Drawing.Size(261, 20);
            this.textBoxBrowserBHomePage.TabIndex = 9;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 576);
            this.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Color2 = System.Drawing.Color.Black;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxChangeSet);
            this.Controls.Add(this.labelAnignora);
            this.Controls.Add(this.buttonOK);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Name = "FormSettings";
            this.Text = "Anignora Solutions";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPositionSumK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPositionDevider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownPositionDevider;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownPositionSumK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxBrowserBHomePage;
        private System.Windows.Forms.TextBox textBoxBrowserAHomePage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}