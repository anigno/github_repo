using AnignoLibrary.UI.CheckBoxs;

namespace AnignoProcessMonitorV2.UI
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
            this.contextMenuStripProcesses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.processBlockingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processAnnouncementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.announceProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoNotAnnounceProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToSystemProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromSystemProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.buttonRoundedGlowRenameProcesses = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.buttonRoundedGlowEraseProcesses = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.panelRoundedContainerBlocking = new AnignoLibrary.UI.Extenders.PanelRoundedContainer();
            this.checkBoxColoredBlockingActive = new AnignoLibrary.UI.CheckBoxs.CheckBoxColored();
            this.buttonRoundedGlowKillProcesses = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.checkBoxAnnounceActive = new AnignoLibrary.UI.CheckBoxs.CheckBoxColored();
            this.buttonRoundedGlowClearProcesses = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.listViewProcessesMain = new AnignoProcessMonitorV2.UI.ListViewProcesses();
            this.contextMenuStripProcesses.SuspendLayout();
            this.panelRoundedContainerBlocking.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripProcesses
            // 
            this.contextMenuStripProcesses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processBlockingToolStripMenuItem,
            this.processAnnouncementToolStripMenuItem,
            this.systemProcessesToolStripMenuItem,
            this.googleProcessesToolStripMenuItem});
            this.contextMenuStripProcesses.Name = "contextMenuStripProcesses";
            this.contextMenuStripProcesses.Size = new System.Drawing.Size(187, 92);
            // 
            // processBlockingToolStripMenuItem
            // 
            this.processBlockingToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.processBlockingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allowProcessToolStripMenuItem,
            this.blockProcessToolStripMenuItem});
            this.processBlockingToolStripMenuItem.Image = global::AnignoProcessMonitorV2.Properties.Resources.agent;
            this.processBlockingToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.processBlockingToolStripMenuItem.Name = "processBlockingToolStripMenuItem";
            this.processBlockingToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.processBlockingToolStripMenuItem.Text = "Process blocking";
            // 
            // allowProcessToolStripMenuItem
            // 
            this.allowProcessToolStripMenuItem.Image = global::AnignoProcessMonitorV2.Properties.Resources.button_ok;
            this.allowProcessToolStripMenuItem.Name = "allowProcessToolStripMenuItem";
            this.allowProcessToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.allowProcessToolStripMenuItem.Text = "Allow process";
            this.allowProcessToolStripMenuItem.Click += new System.EventHandler(this.allowProcessToolStripMenuItem_Click);
            // 
            // blockProcessToolStripMenuItem
            // 
            this.blockProcessToolStripMenuItem.Image = global::AnignoProcessMonitorV2.Properties.Resources.button_cancel;
            this.blockProcessToolStripMenuItem.Name = "blockProcessToolStripMenuItem";
            this.blockProcessToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.blockProcessToolStripMenuItem.Text = "Block process";
            this.blockProcessToolStripMenuItem.Click += new System.EventHandler(this.blockProcessToolStripMenuItem_Click);
            // 
            // processAnnouncementToolStripMenuItem
            // 
            this.processAnnouncementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.announceProcessToolStripMenuItem,
            this.DoNotAnnounceProcessToolStripMenuItem});
            this.processAnnouncementToolStripMenuItem.Image = global::AnignoProcessMonitorV2.Properties.Resources.knotify;
            this.processAnnouncementToolStripMenuItem.Name = "processAnnouncementToolStripMenuItem";
            this.processAnnouncementToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.processAnnouncementToolStripMenuItem.Text = "Process announcement";
            // 
            // announceProcessToolStripMenuItem
            // 
            this.announceProcessToolStripMenuItem.Image = global::AnignoProcessMonitorV2.Properties.Resources.button_ok;
            this.announceProcessToolStripMenuItem.Name = "announceProcessToolStripMenuItem";
            this.announceProcessToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.announceProcessToolStripMenuItem.Text = "Announce process";
            this.announceProcessToolStripMenuItem.Click += new System.EventHandler(this.announceProcessToolStripMenuItem_Click);
            // 
            // DoNotAnnounceProcessToolStripMenuItem
            // 
            this.DoNotAnnounceProcessToolStripMenuItem.Image = global::AnignoProcessMonitorV2.Properties.Resources.button_cancel;
            this.DoNotAnnounceProcessToolStripMenuItem.Name = "DoNotAnnounceProcessToolStripMenuItem";
            this.DoNotAnnounceProcessToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.DoNotAnnounceProcessToolStripMenuItem.Text = "Do not announce process";
            this.DoNotAnnounceProcessToolStripMenuItem.Click += new System.EventHandler(this.DoNotAnnounceProcessToolStripMenuItem_Click);
            // 
            // systemProcessesToolStripMenuItem
            // 
            this.systemProcessesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToSystemProcessesToolStripMenuItem,
            this.removeFromSystemProcessesToolStripMenuItem});
            this.systemProcessesToolStripMenuItem.Image = global::AnignoProcessMonitorV2.Properties.Resources.CMS_Indemnity_OD_Y_calc;
            this.systemProcessesToolStripMenuItem.Name = "systemProcessesToolStripMenuItem";
            this.systemProcessesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.systemProcessesToolStripMenuItem.Text = "System processes";
            // 
            // addToSystemProcessesToolStripMenuItem
            // 
            this.addToSystemProcessesToolStripMenuItem.Image = global::AnignoProcessMonitorV2.Properties.Resources.button_ok;
            this.addToSystemProcessesToolStripMenuItem.Name = "addToSystemProcessesToolStripMenuItem";
            this.addToSystemProcessesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.addToSystemProcessesToolStripMenuItem.Text = "Add to system processes";
            this.addToSystemProcessesToolStripMenuItem.Click += new System.EventHandler(this.addToSystemProcessesToolStripMenuItem_Click);
            // 
            // removeFromSystemProcessesToolStripMenuItem
            // 
            this.removeFromSystemProcessesToolStripMenuItem.Image = global::AnignoProcessMonitorV2.Properties.Resources.button_cancel;
            this.removeFromSystemProcessesToolStripMenuItem.Name = "removeFromSystemProcessesToolStripMenuItem";
            this.removeFromSystemProcessesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.removeFromSystemProcessesToolStripMenuItem.Text = "Remove from system processes";
            this.removeFromSystemProcessesToolStripMenuItem.Click += new System.EventHandler(this.removeFromSystemProcessesToolStripMenuItem_Click);
            // 
            // googleProcessesToolStripMenuItem
            // 
            this.googleProcessesToolStripMenuItem.Image = global::AnignoProcessMonitorV2.Properties.Resources.browser;
            this.googleProcessesToolStripMenuItem.Name = "googleProcessesToolStripMenuItem";
            this.googleProcessesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.googleProcessesToolStripMenuItem.Text = "Google processes";
            this.googleProcessesToolStripMenuItem.Click += new System.EventHandler(this.googleProcessesToolStripMenuItem_Click);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Anigno Process Monitor V2";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.Click += new System.EventHandler(this.notifyIconMain_Click);
            // 
            // listViewLog
            // 
            this.listViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewLog.Location = new System.Drawing.Point(12, 401);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(854, 164);
            this.listViewLog.TabIndex = 4;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time";
            this.columnHeader1.Width = 126;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Action";
            this.columnHeader2.Width = 127;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Process name";
            this.columnHeader3.Width = 158;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 737;
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
            this.buttonRoundedGlowRenameProcesses.Location = new System.Drawing.Point(734, 179);
            this.buttonRoundedGlowRenameProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowRenameProcesses.Name = "buttonRoundedGlowRenameProcesses";
            this.buttonRoundedGlowRenameProcesses.RoundedCornersRadious = 15;
            this.buttonRoundedGlowRenameProcesses.Size = new System.Drawing.Size(132, 34);
            this.buttonRoundedGlowRenameProcesses.TabIndex = 9;
            this.toolTipMain.SetToolTip(this.buttonRoundedGlowRenameProcesses, "Rename selected processes, after killing them, adding \'_\' to the end of each file" +
                    "");
            this.buttonRoundedGlowRenameProcesses.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowRenameProcesses_OnButtonRoundedGlowMouseClick);
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
            this.buttonRoundedGlowEraseProcesses.Location = new System.Drawing.Point(734, 95);
            this.buttonRoundedGlowEraseProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowEraseProcesses.Name = "buttonRoundedGlowEraseProcesses";
            this.buttonRoundedGlowEraseProcesses.RoundedCornersRadious = 15;
            this.buttonRoundedGlowEraseProcesses.Size = new System.Drawing.Size(131, 34);
            this.buttonRoundedGlowEraseProcesses.TabIndex = 8;
            this.toolTipMain.SetToolTip(this.buttonRoundedGlowEraseProcesses, "Erase selected processes");
            this.buttonRoundedGlowEraseProcesses.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowEraseProcesses_OnButtonRoundedGlowMouseClick);
            // 
            // panelRoundedContainerBlocking
            // 
            this.panelRoundedContainerBlocking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRoundedContainerBlocking.ColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelRoundedContainerBlocking.ColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelRoundedContainerBlocking.Controls.Add(this.checkBoxColoredBlockingActive);
            this.panelRoundedContainerBlocking.CornersRadious = 20F;
            this.panelRoundedContainerBlocking.GradientAngle = 30F;
            this.panelRoundedContainerBlocking.Location = new System.Drawing.Point(734, 12);
            this.panelRoundedContainerBlocking.Name = "panelRoundedContainerBlocking";
            this.panelRoundedContainerBlocking.Size = new System.Drawing.Size(132, 34);
            this.panelRoundedContainerBlocking.TabIndex = 7;
            // 
            // checkBoxColoredBlockingActive
            // 
            this.checkBoxColoredBlockingActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxColoredBlockingActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.checkBoxColoredBlockingActive.ColorChecked = System.Drawing.Color.Lime;
            this.checkBoxColoredBlockingActive.ColorUnChecked = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.checkBoxColoredBlockingActive.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkBoxColoredBlockingActive.FlatAppearance.BorderSize = 0;
            this.checkBoxColoredBlockingActive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.checkBoxColoredBlockingActive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.checkBoxColoredBlockingActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxColoredBlockingActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBoxColoredBlockingActive.Location = new System.Drawing.Point(5, 5);
            this.checkBoxColoredBlockingActive.Name = "checkBoxColoredBlockingActive";
            this.checkBoxColoredBlockingActive.Size = new System.Drawing.Size(122, 24);
            this.checkBoxColoredBlockingActive.TabIndex = 5;
            this.checkBoxColoredBlockingActive.Text = "Blocking";
            this.checkBoxColoredBlockingActive.UseVisualStyleBackColor = false;
            this.checkBoxColoredBlockingActive.CheckedChanged += new System.EventHandler(this.checkBoxColoredBlockingActive_CheckedChanged);
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
            this.buttonRoundedGlowKillProcesses.Location = new System.Drawing.Point(734, 53);
            this.buttonRoundedGlowKillProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowKillProcesses.Name = "buttonRoundedGlowKillProcesses";
            this.buttonRoundedGlowKillProcesses.RoundedCornersRadious = 15;
            this.buttonRoundedGlowKillProcesses.Size = new System.Drawing.Size(132, 34);
            this.buttonRoundedGlowKillProcesses.TabIndex = 6;
            this.toolTipMain.SetToolTip(this.buttonRoundedGlowKillProcesses, "Kill all instances of selected processes");
            this.buttonRoundedGlowKillProcesses.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowKillProcesses_OnButtonRoundedGlowMouseClick);
            // 
            // checkBoxAnnounceActive
            // 
            this.checkBoxAnnounceActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAnnounceActive.BackColor = System.Drawing.Color.DodgerBlue;
            this.checkBoxAnnounceActive.ColorChecked = System.Drawing.Color.LightBlue;
            this.checkBoxAnnounceActive.ColorUnChecked = System.Drawing.Color.DodgerBlue;
            this.checkBoxAnnounceActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAnnounceActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBoxAnnounceActive.Location = new System.Drawing.Point(739, 361);
            this.checkBoxAnnounceActive.Name = "checkBoxAnnounceActive";
            this.checkBoxAnnounceActive.Size = new System.Drawing.Size(126, 34);
            this.checkBoxAnnounceActive.TabIndex = 2;
            this.checkBoxAnnounceActive.Text = "Announce";
            this.checkBoxAnnounceActive.UseVisualStyleBackColor = false;
            this.checkBoxAnnounceActive.Visible = false;
            this.checkBoxAnnounceActive.CheckedChanged += new System.EventHandler(this.checkBoxAnnounceActive_CheckedChanged);
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
            this.buttonRoundedGlowClearProcesses.Location = new System.Drawing.Point(734, 137);
            this.buttonRoundedGlowClearProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowClearProcesses.Name = "buttonRoundedGlowClearProcesses";
            this.buttonRoundedGlowClearProcesses.RoundedCornersRadious = 15;
            this.buttonRoundedGlowClearProcesses.Size = new System.Drawing.Size(131, 34);
            this.buttonRoundedGlowClearProcesses.TabIndex = 10;
            this.toolTipMain.SetToolTip(this.buttonRoundedGlowClearProcesses, "Clear all processes with no description");
            this.buttonRoundedGlowClearProcesses.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowClearProcesses_OnButtonRoundedGlowMouseClick);
            // 
            // listViewProcessesMain
            // 
            this.listViewProcessesMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewProcessesMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewProcessesMain.ContextMenuStrip = this.contextMenuStripProcesses;
            this.listViewProcessesMain.FullRowSelect = true;
            this.listViewProcessesMain.GridLines = true;
            this.listViewProcessesMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewProcessesMain.HideSelection = false;
            this.listViewProcessesMain.Location = new System.Drawing.Point(12, 12);
            this.listViewProcessesMain.Name = "listViewProcessesMain";
            this.listViewProcessesMain.Size = new System.Drawing.Size(715, 383);
            this.listViewProcessesMain.TabIndex = 0;
            this.listViewProcessesMain.UseCompatibleStateImageBehavior = false;
            this.listViewProcessesMain.View = System.Windows.Forms.View.Details;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(878, 577);
            this.Controls.Add(this.buttonRoundedGlowClearProcesses);
            this.Controls.Add(this.buttonRoundedGlowRenameProcesses);
            this.Controls.Add(this.buttonRoundedGlowEraseProcesses);
            this.Controls.Add(this.panelRoundedContainerBlocking);
            this.Controls.Add(this.buttonRoundedGlowKillProcesses);
            this.Controls.Add(this.listViewProcessesMain);
            this.Controls.Add(this.listViewLog);
            this.Controls.Add(this.checkBoxAnnounceActive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.Text = "Anigno Process Monitor";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.contextMenuStripProcesses.ResumeLayout(false);
            this.panelRoundedContainerBlocking.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewProcesses listViewProcessesMain;
        private AnignoLibrary.UI.CheckBoxs.CheckBoxColored checkBoxAnnounceActive;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProcesses;
        private System.Windows.Forms.ToolStripMenuItem processBlockingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processAnnouncementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem announceProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoNotAnnounceProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemProcessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToSystemProcessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromSystemProcessesToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ToolStripMenuItem googleProcessesToolStripMenuItem;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private AnignoLibrary.UI.CheckBoxs.CheckBoxColored checkBoxColoredBlockingActive;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowKillProcesses;
        private AnignoLibrary.UI.Extenders.PanelRoundedContainer panelRoundedContainerBlocking;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowEraseProcesses;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowRenameProcesses;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowClearProcesses;
        private System.Windows.Forms.ToolTip toolTipMain;
    }
}