namespace DivesManager
{
    partial class FormDiveData
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
            this.buttonPlan = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelAutoSize1 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.textBoxPlace = new System.Windows.Forms.TextBox();
            this.labelAutoSize4 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.comboBoxDiveWeght = new System.Windows.Forms.ComboBox();
            this.comboBoxDiveSuit = new System.Windows.Forms.ComboBox();
            this.labelAutoSize5 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.labelAutoSize6 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.dateTimePickerDiveDateTime = new System.Windows.Forms.DateTimePicker();
            this.labelAutoSize2 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.SuspendLayout();
            // 
            // buttonPlan
            // 
            this.buttonPlan.Location = new System.Drawing.Point(159, 153);
            this.buttonPlan.Name = "buttonPlan";
            this.buttonPlan.Size = new System.Drawing.Size(72, 20);
            this.buttonPlan.TabIndex = 16;
            this.buttonPlan.Text = "Plan -->";
            this.buttonPlan.Click += new System.EventHandler(this.buttonPlan_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Location = new System.Drawing.Point(3, 153);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(72, 20);
            this.buttonClose.TabIndex = 14;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelAutoSize1
            // 
            this.labelAutoSize1.AutoSize = true;
            this.labelAutoSize1.Location = new System.Drawing.Point(3, 15);
            this.labelAutoSize1.Name = "labelAutoSize1";
            this.labelAutoSize1.Size = new System.Drawing.Size(37, 15);
            this.labelAutoSize1.Text = "Place:";
            // 
            // textBoxPlace
            // 
            this.textBoxPlace.Location = new System.Drawing.Point(95, 15);
            this.textBoxPlace.Name = "textBoxPlace";
            this.textBoxPlace.Size = new System.Drawing.Size(142, 21);
            this.textBoxPlace.TabIndex = 19;
            this.textBoxPlace.GotFocus += new System.EventHandler(this.textBoxPlace_GotFocus);
            this.textBoxPlace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPlace_KeyDown);
            this.textBoxPlace.LostFocus += new System.EventHandler(this.textBoxPlace_LostFocus);
            // 
            // labelAutoSize4
            // 
            this.labelAutoSize4.AutoSize = true;
            this.labelAutoSize4.Location = new System.Drawing.Point(3, 70);
            this.labelAutoSize4.Name = "labelAutoSize4";
            this.labelAutoSize4.Size = new System.Drawing.Size(47, 15);
            this.labelAutoSize4.Text = "Weight:";
            // 
            // comboBoxDiveWeght
            // 
            this.comboBoxDiveWeght.Items.Add("0");
            this.comboBoxDiveWeght.Items.Add("2");
            this.comboBoxDiveWeght.Items.Add("4");
            this.comboBoxDiveWeght.Items.Add("6");
            this.comboBoxDiveWeght.Items.Add("8");
            this.comboBoxDiveWeght.Items.Add("10");
            this.comboBoxDiveWeght.Items.Add("12");
            this.comboBoxDiveWeght.Items.Add("14");
            this.comboBoxDiveWeght.Items.Add("16");
            this.comboBoxDiveWeght.Items.Add("18");
            this.comboBoxDiveWeght.Items.Add("20");
            this.comboBoxDiveWeght.Items.Add("22");
            this.comboBoxDiveWeght.Items.Add("24");
            this.comboBoxDiveWeght.Items.Add("26");
            this.comboBoxDiveWeght.Items.Add("28");
            this.comboBoxDiveWeght.Items.Add("30");
            this.comboBoxDiveWeght.Items.Add("32");
            this.comboBoxDiveWeght.Items.Add("34");
            this.comboBoxDiveWeght.Items.Add("36");
            this.comboBoxDiveWeght.Items.Add("38");
            this.comboBoxDiveWeght.Items.Add("40");
            this.comboBoxDiveWeght.Items.Add("42");
            this.comboBoxDiveWeght.Items.Add("44");
            this.comboBoxDiveWeght.Items.Add("46");
            this.comboBoxDiveWeght.Items.Add("48");
            this.comboBoxDiveWeght.Items.Add("50");
            this.comboBoxDiveWeght.Location = new System.Drawing.Point(95, 70);
            this.comboBoxDiveWeght.Name = "comboBoxDiveWeght";
            this.comboBoxDiveWeght.Size = new System.Drawing.Size(80, 22);
            this.comboBoxDiveWeght.TabIndex = 26;
            // 
            // comboBoxDiveSuit
            // 
            this.comboBoxDiveSuit.Items.Add("Two parts");
            this.comboBoxDiveSuit.Items.Add("One part");
            this.comboBoxDiveSuit.Items.Add("Pants only");
            this.comboBoxDiveSuit.Location = new System.Drawing.Point(95, 98);
            this.comboBoxDiveSuit.Name = "comboBoxDiveSuit";
            this.comboBoxDiveSuit.Size = new System.Drawing.Size(80, 22);
            this.comboBoxDiveSuit.TabIndex = 28;
            // 
            // labelAutoSize5
            // 
            this.labelAutoSize5.AutoSize = true;
            this.labelAutoSize5.Location = new System.Drawing.Point(3, 98);
            this.labelAutoSize5.Name = "labelAutoSize5";
            this.labelAutoSize5.Size = new System.Drawing.Size(30, 15);
            this.labelAutoSize5.Text = "Suit:";
            // 
            // labelAutoSize6
            // 
            this.labelAutoSize6.AutoSize = true;
            this.labelAutoSize6.Location = new System.Drawing.Point(3, 42);
            this.labelAutoSize6.Name = "labelAutoSize6";
            this.labelAutoSize6.Size = new System.Drawing.Size(86, 15);
            this.labelAutoSize6.Text = "Date and time:";
            // 
            // dateTimePickerDiveDateTime
            // 
            this.dateTimePickerDiveDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerDiveDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDiveDateTime.Location = new System.Drawing.Point(95, 42);
            this.dateTimePickerDiveDateTime.Name = "dateTimePickerDiveDateTime";
            this.dateTimePickerDiveDateTime.ShowUpDown = true;
            this.dateTimePickerDiveDateTime.Size = new System.Drawing.Size(142, 22);
            this.dateTimePickerDiveDateTime.TabIndex = 38;
            // 
            // labelAutoSize2
            // 
            this.labelAutoSize2.AutoSize = true;
            this.labelAutoSize2.Location = new System.Drawing.Point(3, 0);
            this.labelAutoSize2.Name = "labelAutoSize2";
            this.labelAutoSize2.Size = new System.Drawing.Size(79, 15);
            this.labelAutoSize2.Text = "Edit dive data";
            // 
            // FormDiveData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.labelAutoSize2);
            this.Controls.Add(this.dateTimePickerDiveDateTime);
            this.Controls.Add(this.labelAutoSize6);
            this.Controls.Add(this.comboBoxDiveSuit);
            this.Controls.Add(this.labelAutoSize5);
            this.Controls.Add(this.comboBoxDiveWeght);
            this.Controls.Add(this.labelAutoSize4);
            this.Controls.Add(this.labelAutoSize1);
            this.Controls.Add(this.textBoxPlace);
            this.Controls.Add(this.buttonPlan);
            this.Controls.Add(this.buttonClose);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormDiveData";
            this.Text = "FormDiveData";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlan;
        private System.Windows.Forms.Button buttonClose;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize1;
        private System.Windows.Forms.TextBox textBoxPlace;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize4;
        private System.Windows.Forms.ComboBox comboBoxDiveWeght;
        private System.Windows.Forms.ComboBox comboBoxDiveSuit;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize5;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize6;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDiveDateTime;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize2;
    }
}