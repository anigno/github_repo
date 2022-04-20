namespace AnignoLibrary.UI.TreeViewControls.AnignoTreeListViewControl
{
    partial class AnignoTreeListView
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
            this.listViewMain = new System.Windows.Forms.ListView();
            this.labelHeader = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewScrollableMain = new AnignoLibrary.UI.TreeViewControls.AnignoTreeListViewControl.TreeViewScrollable();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewMain
            // 
            this.listViewMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.GridLines = true;
            this.listViewMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewMain.Location = new System.Drawing.Point(0, 0);
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Scrollable = false;
            this.listViewMain.Size = new System.Drawing.Size(214, 393);
            this.listViewMain.TabIndex = 1;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new System.Drawing.Point(3, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(101, 13);
            this.labelHeader.TabIndex = 4;
            this.labelHeader.Text = "AnignoTreeListView";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewScrollableMain);
            this.splitContainer1.Panel1.Controls.Add(this.labelHeader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewMain);
            this.splitContainer1.Size = new System.Drawing.Size(410, 397);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 5;
            // 
            // treeViewScrollableMain
            // 
            this.treeViewScrollableMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewScrollableMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewScrollableMain.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeViewScrollableMain.FullRowSelect = true;
            this.treeViewScrollableMain.HideSelection = false;
            this.treeViewScrollableMain.Indent = 15;
            this.treeViewScrollableMain.Location = new System.Drawing.Point(-3, 16);
            this.treeViewScrollableMain.Name = "treeViewScrollableMain";
            this.treeViewScrollableMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeViewScrollableMain.ShowNodeToolTips = true;
            this.treeViewScrollableMain.Size = new System.Drawing.Size(186, 377);
            this.treeViewScrollableMain.TabIndex = 2;
            // 
            // AnignoTreeListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Name = "AnignoTreeListView";
            this.Size = new System.Drawing.Size(410, 397);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewMain;
        private TreeViewScrollable treeViewScrollableMain;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
