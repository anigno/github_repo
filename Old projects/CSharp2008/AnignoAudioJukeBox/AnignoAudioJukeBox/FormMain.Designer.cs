namespace AnignoAudioJukeBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonCrossFade = new System.Windows.Forms.Button();
            this.listViewPlaylist = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.listViewBrowse = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.numericUpDownAutoCrossFadeStartInterval = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCrossFadeInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.filesAndFoldersBrowserMain = new AnignoLibrary.UI.TreeViewControls.FilesAndFoldersBrowser();
            this.anignoCheckBoxAutoPlaylist = new AnignoLibrary.UI.CheckBoxs.AnignoCheckBox();
            this.anignoCrossFadeMain = new AnignoLibrary.UI.Multimedia.AnignoCrossFade();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonMoveToTop = new System.Windows.Forms.Button();
            this.buttonMoveToButtom = new System.Windows.Forms.Button();
            this.buttonRemoveFromPlaylist = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.buttonSavePlaylist = new System.Windows.Forms.Button();
            this.buttonLoadPlaylist = new System.Windows.Forms.Button();
            this.anignoIrrKlangMp3PlayerControlLeft = new AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControls.AnignoIrrKlangMp3PlayerControl();
            this.anignoIrrKlangMp3PlayerControlRight = new AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControls.AnignoIrrKlangMp3PlayerControl();
            this.buttonHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoCrossFadeStartInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCrossFadeInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCrossFade
            // 
            this.buttonCrossFade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonCrossFade.Location = new System.Drawing.Point(401, 99);
            this.buttonCrossFade.Name = "buttonCrossFade";
            this.buttonCrossFade.Size = new System.Drawing.Size(116, 38);
            this.buttonCrossFade.TabIndex = 9;
            this.buttonCrossFade.Text = "Cross Fade";
            this.buttonCrossFade.UseVisualStyleBackColor = true;
            this.buttonCrossFade.Click += new System.EventHandler(this.buttonCrossFade_Click);
            // 
            // listViewPlaylist
            // 
            this.listViewPlaylist.AllowDrop = true;
            this.listViewPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listViewPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewPlaylist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listViewPlaylist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewPlaylist.HideSelection = false;
            this.listViewPlaylist.Location = new System.Drawing.Point(536, 135);
            this.listViewPlaylist.Name = "listViewPlaylist";
            this.listViewPlaylist.Size = new System.Drawing.Size(370, 431);
            this.listViewPlaylist.TabIndex = 12;
            this.listViewPlaylist.UseCompatibleStateImageBehavior = false;
            this.listViewPlaylist.View = System.Windows.Forms.View.Details;
            this.listViewPlaylist.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listViewPlaylist_ItemMouseHover);
            this.listViewPlaylist.DoubleClick += new System.EventHandler(this.listViewPlaylist_DoubleClick);
            this.listViewPlaylist.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewPlaylist_DragDrop);
            this.listViewPlaylist.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewPlaylist_MouseMove);
            this.listViewPlaylist.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewPlaylist_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Song Name";
            this.columnHeader1.Width = 354;
            // 
            // listViewBrowse
            // 
            this.listViewBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listViewBrowse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewBrowse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listViewBrowse.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewBrowse.HideSelection = false;
            this.listViewBrowse.Location = new System.Drawing.Point(12, 280);
            this.listViewBrowse.Name = "listViewBrowse";
            this.listViewBrowse.Size = new System.Drawing.Size(367, 286);
            this.listViewBrowse.TabIndex = 16;
            this.listViewBrowse.UseCompatibleStateImageBehavior = false;
            this.listViewBrowse.View = System.Windows.Forms.View.Details;
            this.listViewBrowse.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewBrowse_MouseMove);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Song Name";
            this.columnHeader2.Width = 360;
            // 
            // numericUpDownAutoCrossFadeStartInterval
            // 
            this.numericUpDownAutoCrossFadeStartInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownAutoCrossFadeStartInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numericUpDownAutoCrossFadeStartInterval.Location = new System.Drawing.Point(490, 194);
            this.numericUpDownAutoCrossFadeStartInterval.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownAutoCrossFadeStartInterval.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownAutoCrossFadeStartInterval.Name = "numericUpDownAutoCrossFadeStartInterval";
            this.numericUpDownAutoCrossFadeStartInterval.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownAutoCrossFadeStartInterval.TabIndex = 18;
            this.numericUpDownAutoCrossFadeStartInterval.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownAutoCrossFadeStartInterval.ValueChanged += new System.EventHandler(this.numericUpDownAutoCrossFade_ValueChanged);
            // 
            // numericUpDownCrossFadeInterval
            // 
            this.numericUpDownCrossFadeInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownCrossFadeInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numericUpDownCrossFadeInterval.Location = new System.Drawing.Point(490, 220);
            this.numericUpDownCrossFadeInterval.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownCrossFadeInterval.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownCrossFadeInterval.Name = "numericUpDownCrossFadeInterval";
            this.numericUpDownCrossFadeInterval.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownCrossFadeInterval.TabIndex = 19;
            this.numericUpDownCrossFadeInterval.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownCrossFadeInterval.ValueChanged += new System.EventHandler(this.numericUpDownCrossFade_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(385, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Auto CrossFade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(385, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "CrossFade length:";
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Location = new System.Drawing.Point(492, 298);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(38, 23);
            this.buttonMoveUp.TabIndex = 22;
            this.buttonMoveUp.Text = "/\\";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Location = new System.Drawing.Point(492, 327);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(38, 23);
            this.buttonMoveDown.TabIndex = 23;
            this.buttonMoveDown.Text = "\\/";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // filesAndFoldersBrowserMain
            // 
            this.filesAndFoldersBrowserMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filesAndFoldersBrowserMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filesAndFoldersBrowserMain.CheckBoxes = false;
            this.filesAndFoldersBrowserMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.filesAndFoldersBrowserMain.Location = new System.Drawing.Point(12, 135);
            this.filesAndFoldersBrowserMain.Name = "filesAndFoldersBrowserMain";
            this.filesAndFoldersBrowserMain.ShowFiles = false;
            this.filesAndFoldersBrowserMain.ShowNetworkShares = false;
            this.filesAndFoldersBrowserMain.Size = new System.Drawing.Size(367, 139);
            this.filesAndFoldersBrowserMain.TabIndex = 17;
            this.filesAndFoldersBrowserMain.OnAfterSelect += new AnignoLibrary.UI.TreeViewControls.FilesAndFoldersBrowser.ItemActionDelegate(this.filesAndFoldersBrowserMain_OnAfterSelect);
            // 
            // anignoCheckBoxAutoPlaylist
            // 
            this.anignoCheckBoxAutoPlaylist.BackColor = System.Drawing.Color.Transparent;
            this.anignoCheckBoxAutoPlaylist.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.anignoCheckBoxAutoPlaylist.BackgroundColorSecond = System.Drawing.Color.Gray;
            this.anignoCheckBoxAutoPlaylist.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.anignoCheckBoxAutoPlaylist.BorderDraw = true;
            this.anignoCheckBoxAutoPlaylist.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.anignoCheckBoxAutoPlaylist.Checked = false;
            this.anignoCheckBoxAutoPlaylist.CornerRadious = 15F;
            this.anignoCheckBoxAutoPlaylist.GradientAngle = 30F;
            this.anignoCheckBoxAutoPlaylist.Location = new System.Drawing.Point(412, 143);
            this.anignoCheckBoxAutoPlaylist.Name = "anignoCheckBoxAutoPlaylist";
            this.anignoCheckBoxAutoPlaylist.Size = new System.Drawing.Size(94, 20);
            this.anignoCheckBoxAutoPlaylist.TabIndex = 11;
            this.anignoCheckBoxAutoPlaylist.Text = "Auto Playlist";
            this.anignoCheckBoxAutoPlaylist.OnAfterCheckedChanged += new AnignoLibrary.UI.CheckBoxs.AnignoCheckBox.AfterCheckChanged(this.anignoCheckBoxAutoPlaylist_OnAfterCheckedChanged);
            // 
            // anignoCrossFadeMain
            // 
            this.anignoCrossFadeMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.anignoCrossFadeMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anignoCrossFadeMain.FadeTime = 6000;
            this.anignoCrossFadeMain.ForeColor = System.Drawing.Color.Gray;
            this.anignoCrossFadeMain.Location = new System.Drawing.Point(401, 30);
            this.anignoCrossFadeMain.Name = "anignoCrossFadeMain";
            this.anignoCrossFadeMain.Size = new System.Drawing.Size(116, 63);
            this.anignoCrossFadeMain.TabIndex = 8;
            this.anignoCrossFadeMain.Ticks = 4;
            this.anignoCrossFadeMain.ValueF = 0F;
            this.anignoCrossFadeMain.OnFaderMoved += new AnignoLibrary.UI.Multimedia.AnignoCrossFade.FaderMovedEventHandler(this.anignoCrossFadeMain_OnFaderMoved);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Songs browser:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(533, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Playlist:";
            // 
            // buttonMoveToTop
            // 
            this.buttonMoveToTop.Location = new System.Drawing.Point(492, 269);
            this.buttonMoveToTop.Name = "buttonMoveToTop";
            this.buttonMoveToTop.Size = new System.Drawing.Size(38, 23);
            this.buttonMoveToTop.TabIndex = 26;
            this.buttonMoveToTop.Text = "//\\\\";
            this.buttonMoveToTop.UseVisualStyleBackColor = true;
            this.buttonMoveToTop.Click += new System.EventHandler(this.buttonMoveToTop_Click);
            // 
            // buttonMoveToButtom
            // 
            this.buttonMoveToButtom.Location = new System.Drawing.Point(492, 356);
            this.buttonMoveToButtom.Name = "buttonMoveToButtom";
            this.buttonMoveToButtom.Size = new System.Drawing.Size(38, 23);
            this.buttonMoveToButtom.TabIndex = 27;
            this.buttonMoveToButtom.Text = "\\\\//";
            this.buttonMoveToButtom.UseVisualStyleBackColor = true;
            this.buttonMoveToButtom.Click += new System.EventHandler(this.buttonMoveToButtom_Click);
            // 
            // buttonRemoveFromPlaylist
            // 
            this.buttonRemoveFromPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonRemoveFromPlaylist.Location = new System.Drawing.Point(426, 356);
            this.buttonRemoveFromPlaylist.Name = "buttonRemoveFromPlaylist";
            this.buttonRemoveFromPlaylist.Size = new System.Drawing.Size(60, 23);
            this.buttonRemoveFromPlaylist.TabIndex = 28;
            this.buttonRemoveFromPlaylist.Text = "Remove";
            this.buttonRemoveFromPlaylist.UseVisualStyleBackColor = true;
            this.buttonRemoveFromPlaylist.Click += new System.EventHandler(this.buttonRemoveFromPlaylist_Click);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonShuffle.Location = new System.Drawing.Point(426, 327);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(60, 23);
            this.buttonShuffle.TabIndex = 29;
            this.buttonShuffle.Text = "Shuffle";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // buttonSavePlaylist
            // 
            this.buttonSavePlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSavePlaylist.Location = new System.Drawing.Point(449, 543);
            this.buttonSavePlaylist.Name = "buttonSavePlaylist";
            this.buttonSavePlaylist.Size = new System.Drawing.Size(81, 23);
            this.buttonSavePlaylist.TabIndex = 30;
            this.buttonSavePlaylist.Text = "Save Playlist";
            this.buttonSavePlaylist.UseVisualStyleBackColor = true;
            this.buttonSavePlaylist.Click += new System.EventHandler(this.buttonSavePlaylist_Click);
            // 
            // buttonLoadPlaylist
            // 
            this.buttonLoadPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonLoadPlaylist.Location = new System.Drawing.Point(449, 514);
            this.buttonLoadPlaylist.Name = "buttonLoadPlaylist";
            this.buttonLoadPlaylist.Size = new System.Drawing.Size(81, 23);
            this.buttonLoadPlaylist.TabIndex = 31;
            this.buttonLoadPlaylist.Text = "Load Playlist";
            this.buttonLoadPlaylist.UseVisualStyleBackColor = true;
            this.buttonLoadPlaylist.Click += new System.EventHandler(this.buttonLoadPlaylist_Click);
            // 
            // anignoIrrKlangMp3PlayerControlLeft
            // 
            this.anignoIrrKlangMp3PlayerControlLeft.AllowDrop = true;
            this.anignoIrrKlangMp3PlayerControlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.anignoIrrKlangMp3PlayerControlLeft.DeviceNumber = 1;
            this.anignoIrrKlangMp3PlayerControlLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.anignoIrrKlangMp3PlayerControlLeft.Location = new System.Drawing.Point(12, 30);
            this.anignoIrrKlangMp3PlayerControlLeft.Name = "anignoIrrKlangMp3PlayerControlLeft";
            this.anignoIrrKlangMp3PlayerControlLeft.PeriodicInterval = 250;
            this.anignoIrrKlangMp3PlayerControlLeft.PlayerName = "DeckLeft";
            this.anignoIrrKlangMp3PlayerControlLeft.PositionDeltaMs = ((uint)(10000u));
            this.anignoIrrKlangMp3PlayerControlLeft.PositionSmoothChangeIntervalMs = ((uint)(1000u));
            this.anignoIrrKlangMp3PlayerControlLeft.PreFinishPlayingInterval = ((uint)(6u));
            this.anignoIrrKlangMp3PlayerControlLeft.Size = new System.Drawing.Size(367, 86);
            this.anignoIrrKlangMp3PlayerControlLeft.SongFilename = null;
            this.anignoIrrKlangMp3PlayerControlLeft.TabIndex = 32;
            this.anignoIrrKlangMp3PlayerControlLeft.VolumeCrossFade = 1F;
            this.anignoIrrKlangMp3PlayerControlLeft.VolumePlayer = 1F;
            this.anignoIrrKlangMp3PlayerControlLeft.VolumePower = 1F;
            this.anignoIrrKlangMp3PlayerControlLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.anignoIrrKlangMp3PlayerControlLeft_DragDrop);
            this.anignoIrrKlangMp3PlayerControlLeft.DragEnter += new System.Windows.Forms.DragEventHandler(this.anignoIrrKlangMp3PlayerControlLeft_DragEnter);
            // 
            // anignoIrrKlangMp3PlayerControlRight
            // 
            this.anignoIrrKlangMp3PlayerControlRight.AllowDrop = true;
            this.anignoIrrKlangMp3PlayerControlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.anignoIrrKlangMp3PlayerControlRight.DeviceNumber = 1;
            this.anignoIrrKlangMp3PlayerControlRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.anignoIrrKlangMp3PlayerControlRight.Location = new System.Drawing.Point(536, 30);
            this.anignoIrrKlangMp3PlayerControlRight.Name = "anignoIrrKlangMp3PlayerControlRight";
            this.anignoIrrKlangMp3PlayerControlRight.PeriodicInterval = 250;
            this.anignoIrrKlangMp3PlayerControlRight.PlayerName = "DeckRight";
            this.anignoIrrKlangMp3PlayerControlRight.PositionDeltaMs = ((uint)(10000u));
            this.anignoIrrKlangMp3PlayerControlRight.PositionSmoothChangeIntervalMs = ((uint)(1000u));
            this.anignoIrrKlangMp3PlayerControlRight.PreFinishPlayingInterval = ((uint)(6u));
            this.anignoIrrKlangMp3PlayerControlRight.Size = new System.Drawing.Size(367, 86);
            this.anignoIrrKlangMp3PlayerControlRight.SongFilename = null;
            this.anignoIrrKlangMp3PlayerControlRight.TabIndex = 33;
            this.anignoIrrKlangMp3PlayerControlRight.VolumeCrossFade = 1F;
            this.anignoIrrKlangMp3PlayerControlRight.VolumePlayer = 1F;
            this.anignoIrrKlangMp3PlayerControlRight.VolumePower = 1F;
            this.anignoIrrKlangMp3PlayerControlRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.anignoIrrKlangMp3PlayerControlRight_DragDrop);
            this.anignoIrrKlangMp3PlayerControlRight.DragEnter += new System.Windows.Forms.DragEventHandler(this.anignoIrrKlangMp3PlayerControlRight_DragEnter);
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackColor = System.Drawing.Color.Transparent;
            this.buttonHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHelp.BackgroundImage")));
            this.buttonHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHelp.FlatAppearance.BorderSize = 0;
            this.buttonHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHelp.Location = new System.Drawing.Point(809, 4);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(20, 20);
            this.buttonHelp.TabIndex = 37;
            this.buttonHelp.TabStop = false;
            this.buttonHelp.UseVisualStyleBackColor = false;
            this.buttonHelp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonHelp_MouseClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(916, 575);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.anignoIrrKlangMp3PlayerControlRight);
            this.Controls.Add(this.buttonLoadPlaylist);
            this.Controls.Add(this.buttonSavePlaylist);
            this.Controls.Add(this.buttonShuffle);
            this.Controls.Add(this.anignoIrrKlangMp3PlayerControlLeft);
            this.Controls.Add(this.buttonRemoveFromPlaylist);
            this.Controls.Add(this.buttonMoveToButtom);
            this.Controls.Add(this.buttonMoveToTop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filesAndFoldersBrowserMain);
            this.Controls.Add(this.listViewBrowse);
            this.Controls.Add(this.listViewPlaylist);
            this.Controls.Add(this.numericUpDownCrossFadeInterval);
            this.Controls.Add(this.buttonMoveDown);
            this.Controls.Add(this.buttonCrossFade);
            this.Controls.Add(this.buttonMoveUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.anignoCrossFadeMain);
            this.Controls.Add(this.numericUpDownAutoCrossFadeStartInterval);
            this.Controls.Add(this.anignoCheckBoxAutoPlaylist);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(924, 602);
            this.Name = "FormMain";
            this.Text = "Anigno Mp3 Jukebox V1.0";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoCrossFadeStartInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCrossFadeInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AnignoLibrary.UI.Multimedia.AnignoCrossFade anignoCrossFadeMain;
        private System.Windows.Forms.Button buttonCrossFade;
        private AnignoLibrary.UI.CheckBoxs.AnignoCheckBox anignoCheckBoxAutoPlaylist;
        private System.Windows.Forms.ListView listViewPlaylist;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listViewBrowse;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private AnignoLibrary.UI.TreeViewControls.FilesAndFoldersBrowser filesAndFoldersBrowserMain;
        private System.Windows.Forms.NumericUpDown numericUpDownAutoCrossFadeStartInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownCrossFadeInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonMoveToTop;
        private System.Windows.Forms.Button buttonMoveToButtom;
        private System.Windows.Forms.Button buttonRemoveFromPlaylist;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button buttonSavePlaylist;
        private System.Windows.Forms.Button buttonLoadPlaylist;
        private AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControls.AnignoIrrKlangMp3PlayerControl anignoIrrKlangMp3PlayerControlLeft;
        private AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControls.AnignoIrrKlangMp3PlayerControl anignoIrrKlangMp3PlayerControlRight;
        private System.Windows.Forms.Button buttonHelp;

    }
}

