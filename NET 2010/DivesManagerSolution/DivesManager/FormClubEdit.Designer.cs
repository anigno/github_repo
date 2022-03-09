namespace DivesManager
{
    partial class FormClubEdit
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxPhones = new System.Windows.Forms.TextBox();
            this.textBoxPrices = new System.Windows.Forms.TextBox();
            this.labelAutoSize5 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.labelAutoSize4 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.labelAutoSize3 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.labelAutoSize2 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.labelAutoSize1 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Location = new System.Drawing.Point(3, 150);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(72, 20);
            this.buttonClose.TabIndex = 17;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(92, 18);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(142, 21);
            this.textBoxName.TabIndex = 20;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(92, 45);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(142, 21);
            this.textBoxAddress.TabIndex = 25;
            // 
            // textBoxPhones
            // 
            this.textBoxPhones.Location = new System.Drawing.Point(92, 72);
            this.textBoxPhones.Name = "textBoxPhones";
            this.textBoxPhones.Size = new System.Drawing.Size(142, 21);
            this.textBoxPhones.TabIndex = 28;
            // 
            // textBoxPrices
            // 
            this.textBoxPrices.Location = new System.Drawing.Point(50, 99);
            this.textBoxPrices.Multiline = true;
            this.textBoxPrices.Name = "textBoxPrices";
            this.textBoxPrices.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPrices.Size = new System.Drawing.Size(184, 45);
            this.textBoxPrices.TabIndex = 31;
            // 
            // labelAutoSize5
            // 
            this.labelAutoSize5.AutoSize = true;
            this.labelAutoSize5.Location = new System.Drawing.Point(0, 72);
            this.labelAutoSize5.Name = "labelAutoSize5";
            this.labelAutoSize5.Size = new System.Drawing.Size(48, 15);
            this.labelAutoSize5.Text = "Phones:";
            // 
            // labelAutoSize4
            // 
            this.labelAutoSize4.AutoSize = true;
            this.labelAutoSize4.Location = new System.Drawing.Point(3, 99);
            this.labelAutoSize4.Name = "labelAutoSize4";
            this.labelAutoSize4.Size = new System.Drawing.Size(41, 15);
            this.labelAutoSize4.Text = "Prices:";
            // 
            // labelAutoSize3
            // 
            this.labelAutoSize3.AutoSize = true;
            this.labelAutoSize3.Location = new System.Drawing.Point(3, 45);
            this.labelAutoSize3.Name = "labelAutoSize3";
            this.labelAutoSize3.Size = new System.Drawing.Size(52, 15);
            this.labelAutoSize3.Text = "Address:";
            // 
            // labelAutoSize2
            // 
            this.labelAutoSize2.AutoSize = true;
            this.labelAutoSize2.Location = new System.Drawing.Point(3, 0);
            this.labelAutoSize2.Name = "labelAutoSize2";
            this.labelAutoSize2.Size = new System.Drawing.Size(79, 15);
            this.labelAutoSize2.Text = "Edit club data";
            // 
            // labelAutoSize1
            // 
            this.labelAutoSize1.AutoSize = true;
            this.labelAutoSize1.Location = new System.Drawing.Point(3, 18);
            this.labelAutoSize1.Name = "labelAutoSize1";
            this.labelAutoSize1.Size = new System.Drawing.Size(67, 15);
            this.labelAutoSize1.Text = "Club name:";
            // 
            // inputPanel1
            // 
            this.inputPanel1.Enabled = true;
            // 
            // FormClubEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.labelAutoSize5);
            this.Controls.Add(this.textBoxPrices);
            this.Controls.Add(this.labelAutoSize4);
            this.Controls.Add(this.textBoxPhones);
            this.Controls.Add(this.labelAutoSize3);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.labelAutoSize2);
            this.Controls.Add(this.labelAutoSize1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormClubEdit";
            this.Text = "FormClubEdit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize1;
        private System.Windows.Forms.TextBox textBoxName;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize2;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize3;
        private System.Windows.Forms.TextBox textBoxAddress;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize4;
        private System.Windows.Forms.TextBox textBoxPhones;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize5;
        private System.Windows.Forms.TextBox textBoxPrices;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
    }
}