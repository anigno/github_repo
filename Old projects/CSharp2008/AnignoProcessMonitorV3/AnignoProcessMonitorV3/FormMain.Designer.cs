namespace AnignoProcessMonitorV3
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.propertyGridProcess = new System.Windows.Forms.PropertyGrid();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.anignoCheckBoxTwoColorsBlockingEngaged = new AnignoLibrary.UI.CheckBoxs.AnignoCheckBoxTwoColors();
            this.listViewExtProcesses = new AnignoLibrary.UI.Lists.ListViewControls.ListViewExt();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.buttonRoundedGlowClearProcesses = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.buttonRoundedGlowRenameProcesses = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.buttonRoundedGlowEraseProcesses = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.buttonRoundedGlowKillProcesses = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripProcesses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.processBlockingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripProcesses.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGridProcess
            // 
            this.propertyGridProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGridProcess.HelpVisible = false;
            this.propertyGridProcess.Location = new System.Drawing.Point(12, 439);
            this.propertyGridProcess.Name = "propertyGridProcess";
            this.propertyGridProcess.Size = new System.Drawing.Size(287, 122);
            this.propertyGridProcess.TabIndex = 1;
            this.propertyGridProcess.ToolbarVisible = false;
            // 
            // listViewLog
            // 
            this.listViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.GridLines = true;
            this.listViewLog.HideSelection = false;
            this.listViewLog.Location = new System.Drawing.Point(305, 439);
            this.listViewLog.MultiSelect = false;
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.ShowItemToolTips = true;
            this.listViewLog.Size = new System.Drawing.Size(556, 122);
            this.listViewLog.TabIndex = 2;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            this.listViewLog.SelectedIndexChanged += new System.EventHandler(this.listViewLog_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Time";
            this.columnHeader6.Width = 92;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Process name";
            this.columnHeader7.Width = 106;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Action";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Message";
            this.columnHeader9.Width = 200;
            // 
            // anignoCheckBoxTwoColorsBlockingEngaged
            // 
            this.anignoCheckBoxTwoColorsBlockingEngaged.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.anignoCheckBoxTwoColorsBlockingEngaged.BackColor = System.Drawing.Color.Transparent;
            this.anignoCheckBoxTwoColorsBlockingEngaged.BackgroundColorCheckedFirst = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.anignoCheckBoxTwoColorsBlockingEngaged.BackgroundColorCheckedSecond = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.anignoCheckBoxTwoColorsBlockingEngaged.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.anignoCheckBoxTwoColorsBlockingEngaged.BackgroundColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.anignoCheckBoxTwoColorsBlockingEngaged.BorderColor = System.Drawing.Color.Black;
            this.anignoCheckBoxTwoColorsBlockingEngaged.BorderDraw = true;
            this.anignoCheckBoxTwoColorsBlockingEngaged.CheckColor = System.Drawing.Color.Red;
            this.anignoCheckBoxTwoColorsBlockingEngaged.Checked = false;
            this.anignoCheckBoxTwoColorsBlockingEngaged.CornerRadious = 15F;
            this.anignoCheckBoxTwoColorsBlockingEngaged.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.anignoCheckBoxTwoColorsBlockingEngaged.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.anignoCheckBoxTwoColorsBlockingEngaged.GradientAngle = 30F;
            this.anignoCheckBoxTwoColorsBlockingEngaged.Location = new System.Drawing.Point(728, 12);
            this.anignoCheckBoxTwoColorsBlockingEngaged.Name = "anignoCheckBoxTwoColorsBlockingEngaged";
            this.anignoCheckBoxTwoColorsBlockingEngaged.Size = new System.Drawing.Size(133, 43);
            this.anignoCheckBoxTwoColorsBlockingEngaged.TabIndex = 3;
            this.anignoCheckBoxTwoColorsBlockingEngaged.Text = "Blocking";
            this.anignoCheckBoxTwoColorsBlockingEngaged.OnCheckedChanged += new AnignoLibrary.UI.CheckBoxs.AnignoCheckBoxTwoColors.CheckedChangedEventHandler(this.anignoCheckBoxTwoColorsBlockingEngaged_OnCheckedChanged);
            // 
            // listViewExtProcesses
            // 
            this.listViewExtProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewExtProcesses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewExtProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewExtProcesses.ContextMenuStrip = this.contextMenuStripProcesses;
            this.listViewExtProcesses.FullRowSelect = true;
            this.listViewExtProcesses.GridLines = true;
            this.listViewExtProcesses.HideSelection = false;
            this.listViewExtProcesses.Location = new System.Drawing.Point(12, 12);
            this.listViewExtProcesses.Name = "listViewExtProcesses";
            this.listViewExtProcesses.ShowItemToolTips = true;
            this.listViewExtProcesses.Size = new System.Drawing.Size(709, 421);
            this.listViewExtProcesses.TabIndex = 0;
            this.listViewExtProcesses.UseCompatibleStateImageBehavior = false;
            this.listViewExtProcesses.View = System.Windows.Forms.View.Details;
            this.listViewExtProcesses.SelectedIndexChanged += new System.EventHandler(this.listViewExtProcesses_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 167;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "#";
            this.columnHeader5.Width = 39;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 231;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Command line";
            this.columnHeader3.Width = 192;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Allow";
            // 
            // buttonRoundedGlowClearProcesses
            // 
            this.buttonRoundedGlowClearProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRoundedGlowClearProcesses.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowClearProcesses.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonRoundedGlowClearProcesses.BackgroundColorSecond = System.Drawing.Color.RoyalBlue;
            this.buttonRoundedGlowClearProcesses.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowClearProcesses.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowClearProcesses.BorderVisible = true;
            this.buttonRoundedGlowClearProcesses.ButtonText = "Clear processes";
            this.buttonRoundedGlowClearProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonRoundedGlowClearProcesses.ForeColor = System.Drawing.Color.Yellow;
            this.buttonRoundedGlowClearProcesses.GlowAlpha = 200;
            this.buttonRoundedGlowClearProcesses.GlowColor = System.Drawing.Color.White;
            this.buttonRoundedGlowClearProcesses.Location = new System.Drawing.Point(728, 146);
            this.buttonRoundedGlowClearProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowClearProcesses.Name = "buttonRoundedGlowClearProcesses";
            this.buttonRoundedGlowClearProcesses.RoundedCornersRadious = 15;
            this.buttonRoundedGlowClearProcesses.Size = new System.Drawing.Size(133, 34);
            this.buttonRoundedGlowClearProcesses.TabIndex = 14;
            // 
            // buttonRoundedGlowRenameProcesses
            // 
            this.buttonRoundedGlowRenameProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRoundedGlowRenameProcesses.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowRenameProcesses.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowRenameProcesses.BackgroundColorSecond = System.Drawing.Color.Green;
            this.buttonRoundedGlowRenameProcesses.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowRenameProcesses.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowRenameProcesses.BorderVisible = true;
            this.buttonRoundedGlowRenameProcesses.ButtonText = "Rename processes";
            this.buttonRoundedGlowRenameProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonRoundedGlowRenameProcesses.ForeColor = System.Drawing.Color.Yellow;
            this.buttonRoundedGlowRenameProcesses.GlowAlpha = 200;
            this.buttonRoundedGlowRenameProcesses.GlowColor = System.Drawing.Color.White;
            this.buttonRoundedGlowRenameProcesses.Location = new System.Drawing.Point(728, 188);
            this.buttonRoundedGlowRenameProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowRenameProcesses.Name = "buttonRoundedGlowRenameProcesses";
            this.buttonRoundedGlowRenameProcesses.RoundedCornersRadious = 15;
            this.buttonRoundedGlowRenameProcesses.Size = new System.Drawing.Size(133, 34);
            this.buttonRoundedGlowRenameProcesses.TabIndex = 13;
            // 
            // buttonRoundedGlowEraseProcesses
            // 
            this.buttonRoundedGlowEraseProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRoundedGlowEraseProcesses.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowEraseProcesses.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonRoundedGlowEraseProcesses.BackgroundColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowEraseProcesses.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowEraseProcesses.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowEraseProcesses.BorderVisible = true;
            this.buttonRoundedGlowEraseProcesses.ButtonText = "Erase processes";
            this.buttonRoundedGlowEraseProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonRoundedGlowEraseProcesses.ForeColor = System.Drawing.Color.Yellow;
            this.buttonRoundedGlowEraseProcesses.GlowAlpha = 200;
            this.buttonRoundedGlowEraseProcesses.GlowColor = System.Drawing.Color.White;
            this.buttonRoundedGlowEraseProcesses.Location = new System.Drawing.Point(728, 104);
            this.buttonRoundedGlowEraseProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowEraseProcesses.Name = "buttonRoundedGlowEraseProcesses";
            this.buttonRoundedGlowEraseProcesses.RoundedCornersRadious = 15;
            this.buttonRoundedGlowEraseProcesses.Size = new System.Drawing.Size(133, 34);
            this.buttonRoundedGlowEraseProcesses.TabIndex = 12;
            // 
            // buttonRoundedGlowKillProcesses
            // 
            this.buttonRoundedGlowKillProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRoundedGlowKillProcesses.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowKillProcesses.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonRoundedGlowKillProcesses.BackgroundColorSecond = System.Drawing.Color.Red;
            this.buttonRoundedGlowKillProcesses.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowKillProcesses.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowKillProcesses.BorderVisible = true;
            this.buttonRoundedGlowKillProcesses.ButtonText = "Kill processes";
            this.buttonRoundedGlowKillProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonRoundedGlowKillProcesses.ForeColor = System.Drawing.Color.Yellow;
            this.buttonRoundedGlowKillProcesses.GlowAlpha = 200;
            this.buttonRoundedGlowKillProcesses.GlowColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowKillProcesses.Location = new System.Drawing.Point(728, 62);
            this.buttonRoundedGlowKillProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowKillProcesses.Name = "buttonRoundedGlowKillProcesses";
            this.buttonRoundedGlowKillProcesses.RoundedCornersRadious = 15;
            this.buttonRoundedGlowKillProcesses.Size = new System.Drawing.Size(132, 34);
            this.buttonRoundedGlowKillProcesses.TabIndex = 11;
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Anigno Process Monitor V3";
            this.notifyIconMain.Visible = true;
            // 
            // contextMenuStripProcesses
            // 
            this.contextMenuStripProcesses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processBlockingToolStripMenuItem,
            this.googleProcessesToolStripMenuItem,
            this.editDescriptionToolStripMenuItem});
            this.contextMenuStripProcesses.Name = "contextMenuStripProcesses";
            this.contextMenuStripProcesses.Size = new System.Drawing.Size(156, 70);
            // 
            // processBlockingToolStripMenuItem
            // 
            this.processBlockingToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.processBlockingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allowProcessToolStripMenuItem,
            this.blockProcessToolStripMenuItem});
            this.processBlockingToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.processBlockingToolStripMenuItem.Name = "processBlockingToolStripMenuItem";
            this.processBlockingToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.processBlockingToolStripMenuItem.Text = "Process blocking";
            // 
            // allowProcessToolStripMenuItem
            // 
            this.allowProcessToolStripMenuItem.Name = "allowProcessToolStripMenuItem";
            this.allowProcessToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.allowProcessToolStripMenuItem.Text = "Allow process";
            this.allowProcessToolStripMenuItem.Click += new System.EventHandler(this.allowProcessToolStripMenuItem_Click);
            // 
            // blockProcessToolStripMenuItem
            // 
            this.blockProcessToolStripMenuItem.Name = "blockProcessToolStripMenuItem";
            this.blockProcessToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.blockProcessToolStripMenuItem.Text = "Block process";
            this.blockProcessToolStripMenuItem.Click += new System.EventHandler(this.blockProcessToolStripMenuItem_Click);
            // 
            // googleProcessesToolStripMenuItem
            // 
            this.googleProcessesToolStripMenuItem.Name = "googleProcessesToolStripMenuItem";
            this.googleProcessesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.googleProcessesToolStripMenuItem.Text = "Google process";
            // 
            // editDescriptionToolStripMenuItem
            // 
            this.editDescriptionToolStripMenuItem.Name = "editDescriptionToolStripMenuItem";
            this.editDescriptionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.editDescriptionToolStripMenuItem.Text = "Edit description";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(873, 573);
            this.Controls.Add(this.buttonRoundedGlowClearProcesses);
            this.Controls.Add(this.buttonRoundedGlowRenameProcesses);
            this.Controls.Add(this.buttonRoundedGlowEraseProcesses);
            this.Controls.Add(this.buttonRoundedGlowKillProcesses);
            this.Controls.Add(this.anignoCheckBoxTwoColorsBlockingEngaged);
            this.Controls.Add(this.listViewLog);
            this.Controls.Add(this.propertyGridProcess);
            this.Controls.Add(this.listViewExtProcesses);
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.Text = "AnignoProcessMonitorV3";
            this.TopMost = true;
            this.contextMenuStripProcesses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AnignoLibrary.UI.Lists.ListViewControls.ListViewExt listViewExtProcesses;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.PropertyGrid propertyGridProcess;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private AnignoLibrary.UI.CheckBoxs.AnignoCheckBoxTwoColors anignoCheckBoxTwoColorsBlockingEngaged;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowClearProcesses;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowRenameProcesses;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowEraseProcesses;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowKillProcesses;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProcesses;
        private System.Windows.Forms.ToolStripMenuItem processBlockingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleProcessesToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ToolStripMenuItem editDescriptionToolStripMenuItem;



    }
}

