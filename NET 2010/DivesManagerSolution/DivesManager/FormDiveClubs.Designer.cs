namespace DivesManager
{
    partial class FormDiveClubs
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
            this.listViewClubs = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.buttonToMain = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.labelAutoSize1 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.SuspendLayout();
            // 
            // listViewClubs
            // 
            this.listViewClubs.Columns.Add(this.columnHeader1);
            this.listViewClubs.Columns.Add(this.columnHeader2);
            this.listViewClubs.FullRowSelect = true;
            this.listViewClubs.Location = new System.Drawing.Point(3, 17);
            this.listViewClubs.Name = "listViewClubs";
            this.listViewClubs.Size = new System.Drawing.Size(234, 274);
            this.listViewClubs.TabIndex = 1;
            this.listViewClubs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Phone";
            this.columnHeader2.Width = 113;
            // 
            // buttonToMain
            // 
            this.buttonToMain.Location = new System.Drawing.Point(165, 297);
            this.buttonToMain.Name = "buttonToMain";
            this.buttonToMain.Size = new System.Drawing.Size(72, 20);
            this.buttonToMain.TabIndex = 3;
            this.buttonToMain.Text = "Main -->";
            this.buttonToMain.Click += new System.EventHandler(this.buttonToMain_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(3, 297);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(43, 20);
            this.buttonNew.TabIndex = 4;
            this.buttonNew.Text = "New";
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(52, 297);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(42, 20);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(100, 297);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(48, 20);
            this.Delete.TabIndex = 6;
            this.Delete.Text = "Delete";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // labelAutoSize1
            // 
            this.labelAutoSize1.AutoSize = true;
            this.labelAutoSize1.Location = new System.Drawing.Point(3, 0);
            this.labelAutoSize1.Name = "labelAutoSize1";
            this.labelAutoSize1.Size = new System.Drawing.Size(70, 15);
            this.labelAutoSize1.Text = "Diving clubs";
            // 
            // FormDiveClubs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.buttonToMain);
            this.Controls.Add(this.labelAutoSize1);
            this.Controls.Add(this.listViewClubs);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormDiveClubs";
            this.Text = "FormDiveClubs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewClubs;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize1;
        private System.Windows.Forms.Button buttonToMain;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button Delete;

    }
}