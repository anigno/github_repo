﻿namespace AnignoLibrary.UI.TreeViewControls.AnignoSimpleTreeListViewControl
{
    partial class FormTest
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
            this.anignoSimpleTreeListView1 = new AnignoLibrary.UI.TreeViewControls.AnignoSimpleTreeListViewControl.AnignoSimpleTreeListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // anignoSimpleTreeListView1
            // 
            this.anignoSimpleTreeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.anignoSimpleTreeListView1.GridLines = true;
            this.anignoSimpleTreeListView1.Location = new System.Drawing.Point(12, 12);
            this.anignoSimpleTreeListView1.Name = "anignoSimpleTreeListView1";
            this.anignoSimpleTreeListView1.Size = new System.Drawing.Size(465, 374);
            this.anignoSimpleTreeListView1.TabIndex = 0;
            this.anignoSimpleTreeListView1.UseCompatibleStateImageBehavior = false;
            this.anignoSimpleTreeListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tree column";
            this.columnHeader1.Width = 188;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data column";
            this.columnHeader2.Width = 107;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Second data column";
            this.columnHeader3.Width = 138;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 554);
            this.Controls.Add(this.anignoSimpleTreeListView1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private AnignoLibrary.UI.TreeViewControls.AnignoSimpleTreeListViewControl.AnignoSimpleTreeListView anignoSimpleTreeListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}