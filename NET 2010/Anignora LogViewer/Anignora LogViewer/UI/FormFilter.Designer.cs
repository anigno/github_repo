namespace Anignora_LogViewer.UI
{
    partial class FormFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFilter));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxFilterNegative = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFilterName = new System.Windows.Forms.TextBox();
            this.groupBoxSeverity = new System.Windows.Forms.GroupBox();
            this.checkBoxFatal = new System.Windows.Forms.CheckBox();
            this.checkBoxInfo = new System.Windows.Forms.CheckBox();
            this.checkBoxWarn = new System.Windows.Forms.CheckBox();
            this.checkBoxError = new System.Windows.Forms.CheckBox();
            this.checkBoxDebug = new System.Windows.Forms.CheckBox();
            this.groupBoxName = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxThread = new System.Windows.Forms.TextBox();
            this.checkBoxThreadNegative = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.checkBoxMessageNegative = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMethod = new System.Windows.Forms.TextBox();
            this.checkBoxMethodNegative = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.checkBoxTypeNegative = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLoger = new System.Windows.Forms.TextBox();
            this.checkBoxLogerNegative = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxSeverity.SuspendLayout();
            this.groupBoxName.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(427, 384);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterNegative
            // 
            this.checkBoxFilterNegative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFilterNegative.AutoSize = true;
            this.checkBoxFilterNegative.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxFilterNegative.Location = new System.Drawing.Point(414, 18);
            this.checkBoxFilterNegative.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxFilterNegative.Name = "checkBoxFilterNegative";
            this.checkBoxFilterNegative.Size = new System.Drawing.Size(86, 21);
            this.checkBoxFilterNegative.TabIndex = 6;
            this.checkBoxFilterNegative.Text = "Negative";
            this.checkBoxFilterNegative.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 111;
            this.label1.Text = "Filter Name:";
            // 
            // textBoxFilterName
            // 
            this.textBoxFilterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilterName.Location = new System.Drawing.Point(116, 16);
            this.textBoxFilterName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFilterName.Name = "textBoxFilterName";
            this.textBoxFilterName.Size = new System.Drawing.Size(283, 22);
            this.textBoxFilterName.TabIndex = 0;
            this.textBoxFilterName.TextChanged += new System.EventHandler(this.textBoxFilterName_TextChanged);
            // 
            // groupBoxSeverity
            // 
            this.groupBoxSeverity.Controls.Add(this.checkBoxFatal);
            this.groupBoxSeverity.Controls.Add(this.checkBoxInfo);
            this.groupBoxSeverity.Controls.Add(this.checkBoxWarn);
            this.groupBoxSeverity.Controls.Add(this.checkBoxError);
            this.groupBoxSeverity.Controls.Add(this.checkBoxDebug);
            this.groupBoxSeverity.Location = new System.Drawing.Point(16, 262);
            this.groupBoxSeverity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSeverity.Name = "groupBoxSeverity";
            this.groupBoxSeverity.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSeverity.Size = new System.Drawing.Size(111, 165);
            this.groupBoxSeverity.TabIndex = 2;
            this.groupBoxSeverity.TabStop = false;
            this.groupBoxSeverity.Text = "Severity";
            // 
            // checkBoxFatal
            // 
            this.checkBoxFatal.BackColor = System.Drawing.Color.Red;
            this.checkBoxFatal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxFatal.Location = new System.Drawing.Point(8, 137);
            this.checkBoxFatal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxFatal.Name = "checkBoxFatal";
            this.checkBoxFatal.Size = new System.Drawing.Size(92, 21);
            this.checkBoxFatal.TabIndex = 16;
            this.checkBoxFatal.Text = "Fatal";
            this.checkBoxFatal.UseVisualStyleBackColor = false;
            // 
            // checkBoxInfo
            // 
            this.checkBoxInfo.BackColor = System.Drawing.Color.LightBlue;
            this.checkBoxInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxInfo.Location = new System.Drawing.Point(8, 52);
            this.checkBoxInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxInfo.Name = "checkBoxInfo";
            this.checkBoxInfo.Size = new System.Drawing.Size(92, 21);
            this.checkBoxInfo.TabIndex = 13;
            this.checkBoxInfo.Text = "Info";
            this.checkBoxInfo.UseVisualStyleBackColor = false;
            // 
            // checkBoxWarn
            // 
            this.checkBoxWarn.BackColor = System.Drawing.Color.PeachPuff;
            this.checkBoxWarn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxWarn.Location = new System.Drawing.Point(8, 80);
            this.checkBoxWarn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxWarn.Name = "checkBoxWarn";
            this.checkBoxWarn.Size = new System.Drawing.Size(92, 21);
            this.checkBoxWarn.TabIndex = 14;
            this.checkBoxWarn.Text = "Warn";
            this.checkBoxWarn.UseVisualStyleBackColor = false;
            // 
            // checkBoxError
            // 
            this.checkBoxError.BackColor = System.Drawing.Color.Pink;
            this.checkBoxError.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxError.Location = new System.Drawing.Point(8, 108);
            this.checkBoxError.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxError.Name = "checkBoxError";
            this.checkBoxError.Size = new System.Drawing.Size(92, 21);
            this.checkBoxError.TabIndex = 15;
            this.checkBoxError.Text = "Error";
            this.checkBoxError.UseVisualStyleBackColor = false;
            // 
            // checkBoxDebug
            // 
            this.checkBoxDebug.BackColor = System.Drawing.Color.LightGreen;
            this.checkBoxDebug.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDebug.Location = new System.Drawing.Point(8, 23);
            this.checkBoxDebug.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxDebug.Name = "checkBoxDebug";
            this.checkBoxDebug.Size = new System.Drawing.Size(92, 21);
            this.checkBoxDebug.TabIndex = 12;
            this.checkBoxDebug.Text = "Debug";
            this.checkBoxDebug.UseVisualStyleBackColor = false;
            // 
            // groupBoxName
            // 
            this.groupBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxName.Controls.Add(this.label1);
            this.groupBoxName.Controls.Add(this.textBoxFilterName);
            this.groupBoxName.Controls.Add(this.checkBoxFilterNegative);
            this.groupBoxName.Location = new System.Drawing.Point(16, 15);
            this.groupBoxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxName.Name = "groupBoxName";
            this.groupBoxName.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxName.Size = new System.Drawing.Size(511, 53);
            this.groupBoxName.TabIndex = 0;
            this.groupBoxName.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxThread);
            this.groupBox1.Controls.Add(this.checkBoxThreadNegative);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxMessage);
            this.groupBox1.Controls.Add(this.checkBoxMessageNegative);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxMethod);
            this.groupBox1.Controls.Add(this.checkBoxMethodNegative);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxType);
            this.groupBox1.Controls.Add(this.checkBoxTypeNegative);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxLoger);
            this.groupBox1.Controls.Add(this.checkBoxLogerNegative);
            this.groupBox1.Location = new System.Drawing.Point(16, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(511, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 148);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 111;
            this.label6.Text = "Thread:";
            // 
            // textBoxThread
            // 
            this.textBoxThread.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxThread.Location = new System.Drawing.Point(100, 144);
            this.textBoxThread.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxThread.Name = "textBoxThread";
            this.textBoxThread.Size = new System.Drawing.Size(299, 22);
            this.textBoxThread.TabIndex = 5;
            // 
            // checkBoxThreadNegative
            // 
            this.checkBoxThreadNegative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxThreadNegative.AutoSize = true;
            this.checkBoxThreadNegative.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxThreadNegative.Location = new System.Drawing.Point(414, 146);
            this.checkBoxThreadNegative.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxThreadNegative.Name = "checkBoxThreadNegative";
            this.checkBoxThreadNegative.Size = new System.Drawing.Size(86, 21);
            this.checkBoxThreadNegative.TabIndex = 11;
            this.checkBoxThreadNegative.Text = "Negative";
            this.checkBoxThreadNegative.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 111;
            this.label5.Text = "Message:";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMessage.Location = new System.Drawing.Point(100, 112);
            this.textBoxMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(299, 22);
            this.textBoxMessage.TabIndex = 4;
            // 
            // checkBoxMessageNegative
            // 
            this.checkBoxMessageNegative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxMessageNegative.AutoSize = true;
            this.checkBoxMessageNegative.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxMessageNegative.Location = new System.Drawing.Point(414, 114);
            this.checkBoxMessageNegative.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxMessageNegative.Name = "checkBoxMessageNegative";
            this.checkBoxMessageNegative.Size = new System.Drawing.Size(86, 21);
            this.checkBoxMessageNegative.TabIndex = 10;
            this.checkBoxMessageNegative.Text = "Negative";
            this.checkBoxMessageNegative.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 111;
            this.label4.Text = "Method:";
            // 
            // textBoxMethod
            // 
            this.textBoxMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMethod.Location = new System.Drawing.Point(100, 80);
            this.textBoxMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMethod.Name = "textBoxMethod";
            this.textBoxMethod.Size = new System.Drawing.Size(299, 22);
            this.textBoxMethod.TabIndex = 3;
            // 
            // checkBoxMethodNegative
            // 
            this.checkBoxMethodNegative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxMethodNegative.AutoSize = true;
            this.checkBoxMethodNegative.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxMethodNegative.Location = new System.Drawing.Point(414, 82);
            this.checkBoxMethodNegative.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxMethodNegative.Name = "checkBoxMethodNegative";
            this.checkBoxMethodNegative.Size = new System.Drawing.Size(86, 21);
            this.checkBoxMethodNegative.TabIndex = 9;
            this.checkBoxMethodNegative.Text = "Negative";
            this.checkBoxMethodNegative.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 111;
            this.label2.Text = "Type:";
            // 
            // textBoxType
            // 
            this.textBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxType.Location = new System.Drawing.Point(100, 48);
            this.textBoxType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(299, 22);
            this.textBoxType.TabIndex = 2;
            // 
            // checkBoxTypeNegative
            // 
            this.checkBoxTypeNegative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTypeNegative.AutoSize = true;
            this.checkBoxTypeNegative.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxTypeNegative.Location = new System.Drawing.Point(414, 50);
            this.checkBoxTypeNegative.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxTypeNegative.Name = "checkBoxTypeNegative";
            this.checkBoxTypeNegative.Size = new System.Drawing.Size(86, 21);
            this.checkBoxTypeNegative.TabIndex = 8;
            this.checkBoxTypeNegative.Text = "Negative";
            this.checkBoxTypeNegative.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 111;
            this.label3.Text = "Logger:";
            // 
            // textBoxLoger
            // 
            this.textBoxLoger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLoger.Location = new System.Drawing.Point(100, 16);
            this.textBoxLoger.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLoger.Name = "textBoxLoger";
            this.textBoxLoger.Size = new System.Drawing.Size(299, 22);
            this.textBoxLoger.TabIndex = 1;
            // 
            // checkBoxLogerNegative
            // 
            this.checkBoxLogerNegative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxLogerNegative.AutoSize = true;
            this.checkBoxLogerNegative.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxLogerNegative.Location = new System.Drawing.Point(414, 18);
            this.checkBoxLogerNegative.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLogerNegative.Name = "checkBoxLogerNegative";
            this.checkBoxLogerNegative.Size = new System.Drawing.Size(86, 21);
            this.checkBoxLogerNegative.TabIndex = 7;
            this.checkBoxLogerNegative.Text = "Negative";
            this.checkBoxLogerNegative.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(319, 384);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 28);
            this.buttonOK.TabIndex = 17;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.onButtonOkClick);
            // 
            // FormFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(540, 425);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxName);
            this.Controls.Add(this.groupBoxSeverity);
            this.Controls.Add(this.buttonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(850, 470);
            this.MinimumSize = new System.Drawing.Size(450, 470);
            this.Name = "FormFilter";
            this.Text = "FormFilter";
            this.groupBoxSeverity.ResumeLayout(false);
            this.groupBoxName.ResumeLayout(false);
            this.groupBoxName.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxFilterNegative;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFilterName;
        private System.Windows.Forms.GroupBox groupBoxSeverity;
        private System.Windows.Forms.CheckBox checkBoxFatal;
        private System.Windows.Forms.CheckBox checkBoxInfo;
        private System.Windows.Forms.CheckBox checkBoxWarn;
        private System.Windows.Forms.CheckBox checkBoxError;
        private System.Windows.Forms.CheckBox checkBoxDebug;
        private System.Windows.Forms.GroupBox groupBoxName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLoger;
        private System.Windows.Forms.CheckBox checkBoxLogerNegative;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxThread;
        private System.Windows.Forms.CheckBox checkBoxThreadNegative;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.CheckBox checkBoxMessageNegative;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMethod;
        private System.Windows.Forms.CheckBox checkBoxMethodNegative;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.CheckBox checkBoxTypeNegative;
        private System.Windows.Forms.Button buttonOK;
    }
}