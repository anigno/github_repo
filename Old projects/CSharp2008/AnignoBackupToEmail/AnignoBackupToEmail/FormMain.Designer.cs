namespace AnignoBackupToEmail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddFolders = new System.Windows.Forms.Button();
            this.TvFoldersSelect = new AnignoLibrary.UI.TreeViewControls.AnignoTreeViewFilesAndFoldersBrowserControl.cs.AnignoTreeViewFilesAndFoldersBrowser();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.anignoZipForgeControlMain = new AnignoLibrary.UI.Utils.AnignoZipForgeControl();
            this.listViewExtArchiveQueue = new AnignoLibrary.UI.Lists.ListViewControls.ListViewExt();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listViewExtLog = new AnignoLibrary.UI.Lists.ListViewControls.ListViewExt();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.anignoProgressBarAutoIncreamentTimeout = new AnignoLibrary.UI.ProgressBars.AnignoProgressBarAutoIncreament();
            this.listViewExtSender = new AnignoLibrary.UI.Lists.ListViewControls.ListViewExt();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMaximumAttachmentSizeMb = new System.Windows.Forms.NumericUpDown();
            this.textBoxGmailPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelAverageForMega = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownUploadSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEmailSubjectPrefix = new System.Windows.Forms.TextBox();
            this.TextBoxsArchivesPassword = new AnignoLibrary.UI.TextBoxs.AnignoPasswordConfirmationTextBoxs();
            this.textBoxValidatedEmail = new AnignoLibrary.UI.TextBoxs.TextBoxValidated();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumAttachmentSizeMb)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUploadSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddFolders);
            this.groupBox1.Controls.Add(this.TvFoldersSelect);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 296);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folders selection:";
            // 
            // buttonAddFolders
            // 
            this.buttonAddFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddFolders.Location = new System.Drawing.Point(6, 267);
            this.buttonAddFolders.Name = "buttonAddFolders";
            this.buttonAddFolders.Size = new System.Drawing.Size(134, 23);
            this.buttonAddFolders.TabIndex = 3;
            this.buttonAddFolders.Text = "Add selected folders";
            this.buttonAddFolders.UseVisualStyleBackColor = true;
            this.buttonAddFolders.Click += new System.EventHandler(this.buttonAddFolders_Click);
            // 
            // TvFoldersSelect
            // 
            this.TvFoldersSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TvFoldersSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TvFoldersSelect.CheckBoxes = true;
            this.TvFoldersSelect.ImageIndex = 0;
            this.TvFoldersSelect.Location = new System.Drawing.Point(6, 19);
            this.TvFoldersSelect.Name = "TvFoldersSelect";
            this.TvFoldersSelect.SelectedImageIndex = 0;
            this.TvFoldersSelect.ShowFiles = false;
            this.TvFoldersSelect.ShowNetworkShares = false;
            this.TvFoldersSelect.Size = new System.Drawing.Size(348, 242);
            this.TvFoldersSelect.TabIndex = 2;
            this.TvFoldersSelect.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvFoldersSelect_AfterCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.anignoZipForgeControlMain);
            this.groupBox2.Controls.Add(this.listViewExtArchiveQueue);
            this.groupBox2.Location = new System.Drawing.Point(12, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 293);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Archiver queue";
            // 
            // anignoZipForgeControlMain
            // 
            this.anignoZipForgeControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.anignoZipForgeControlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anignoZipForgeControlMain.DestinationFile = "test.zip";
            this.anignoZipForgeControlMain.Location = new System.Drawing.Point(6, 237);
            this.anignoZipForgeControlMain.Name = "anignoZipForgeControlMain";
            this.anignoZipForgeControlMain.Password = "1234";
            this.anignoZipForgeControlMain.Size = new System.Drawing.Size(348, 50);
            this.anignoZipForgeControlMain.SourceDirectory = "e:\\_Temp\\3";
            this.anignoZipForgeControlMain.TabIndex = 6;
            this.anignoZipForgeControlMain.VolumeSizeMax = ((long)(8000000));
            // 
            // listViewExtArchiveQueue
            // 
            this.listViewExtArchiveQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewExtArchiveQueue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewExtArchiveQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewExtArchiveQueue.FullRowSelect = true;
            this.listViewExtArchiveQueue.GridLines = true;
            this.listViewExtArchiveQueue.HideSelection = false;
            this.listViewExtArchiveQueue.Location = new System.Drawing.Point(6, 19);
            this.listViewExtArchiveQueue.Name = "listViewExtArchiveQueue";
            this.listViewExtArchiveQueue.ShowItemToolTips = true;
            this.listViewExtArchiveQueue.Size = new System.Drawing.Size(348, 212);
            this.listViewExtArchiveQueue.TabIndex = 4;
            this.listViewExtArchiveQueue.UseCompatibleStateImageBehavior = false;
            this.listViewExtArchiveQueue.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 39;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Path";
            this.columnHeader2.Width = 230;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "State";
            this.columnHeader3.Width = 71;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.listViewExtLog);
            this.groupBox3.Controls.Add(this.anignoProgressBarAutoIncreamentTimeout);
            this.groupBox3.Controls.Add(this.listViewExtSender);
            this.groupBox3.Location = new System.Drawing.Point(507, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 358);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sender queue";
            // 
            // listViewExtLog
            // 
            this.listViewExtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewExtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewExtLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader7});
            this.listViewExtLog.FullRowSelect = true;
            this.listViewExtLog.GridLines = true;
            this.listViewExtLog.HideSelection = false;
            this.listViewExtLog.Location = new System.Drawing.Point(6, 254);
            this.listViewExtLog.Name = "listViewExtLog";
            this.listViewExtLog.ShowItemToolTips = true;
            this.listViewExtLog.Size = new System.Drawing.Size(393, 98);
            this.listViewExtLog.TabIndex = 7;
            this.listViewExtLog.UseCompatibleStateImageBehavior = false;
            this.listViewExtLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "UL time";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Message";
            this.columnHeader7.Width = 330;
            // 
            // anignoProgressBarAutoIncreamentTimeout
            // 
            this.anignoProgressBarAutoIncreamentTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.anignoProgressBarAutoIncreamentTimeout.BackColorFirst = System.Drawing.Color.Gray;
            this.anignoProgressBarAutoIncreamentTimeout.BackColorSecond = System.Drawing.Color.LightGray;
            this.anignoProgressBarAutoIncreamentTimeout.ColorMainFirst = System.Drawing.Color.Blue;
            this.anignoProgressBarAutoIncreamentTimeout.ColorMainGradientAngle = 30F;
            this.anignoProgressBarAutoIncreamentTimeout.ColorMainSecond = System.Drawing.Color.Navy;
            this.anignoProgressBarAutoIncreamentTimeout.ColorMaximumRange = System.Drawing.Color.Navy;
            this.anignoProgressBarAutoIncreamentTimeout.ColorMinimumRange = System.Drawing.Color.Blue;
            this.anignoProgressBarAutoIncreamentTimeout.DrawBorder = false;
            this.anignoProgressBarAutoIncreamentTimeout.GradientAngle = 30F;
            this.anignoProgressBarAutoIncreamentTimeout.Increament = 1;
            this.anignoProgressBarAutoIncreamentTimeout.IntervalMs = 1000;
            this.anignoProgressBarAutoIncreamentTimeout.Location = new System.Drawing.Point(6, 225);
            this.anignoProgressBarAutoIncreamentTimeout.Maximum = 100F;
            this.anignoProgressBarAutoIncreamentTimeout.MaximumRange = 90F;
            this.anignoProgressBarAutoIncreamentTimeout.Minimum = 0F;
            this.anignoProgressBarAutoIncreamentTimeout.MinimumRange = 0F;
            this.anignoProgressBarAutoIncreamentTimeout.Name = "anignoProgressBarAutoIncreamentTimeout";
            this.anignoProgressBarAutoIncreamentTimeout.ProgressBarOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.anignoProgressBarAutoIncreamentTimeout.ProgressBarText = "00:00";
            this.anignoProgressBarAutoIncreamentTimeout.ProgressBarTextColor = System.Drawing.Color.White;
            this.anignoProgressBarAutoIncreamentTimeout.ShowTextAsPecent = false;
            this.anignoProgressBarAutoIncreamentTimeout.ShowTextAsTime = true;
            this.anignoProgressBarAutoIncreamentTimeout.Size = new System.Drawing.Size(393, 23);
            this.anignoProgressBarAutoIncreamentTimeout.TabIndex = 6;
            this.anignoProgressBarAutoIncreamentTimeout.Text = "00:00";
            this.anignoProgressBarAutoIncreamentTimeout.TimerEnabled = true;
            this.anignoProgressBarAutoIncreamentTimeout.Value = 100F;
            // 
            // listViewExtSender
            // 
            this.listViewExtSender.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewExtSender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewExtSender.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listViewExtSender.FullRowSelect = true;
            this.listViewExtSender.GridLines = true;
            this.listViewExtSender.HideSelection = false;
            this.listViewExtSender.Location = new System.Drawing.Point(6, 19);
            this.listViewExtSender.Name = "listViewExtSender";
            this.listViewExtSender.ShowItemToolTips = true;
            this.listViewExtSender.Size = new System.Drawing.Size(393, 200);
            this.listViewExtSender.TabIndex = 4;
            this.listViewExtSender.UseCompatibleStateImageBehavior = false;
            this.listViewExtSender.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "File name";
            this.columnHeader5.Width = 317;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Size";
            this.columnHeader6.Width = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Maximum attachment size:";
            // 
            // numericUpDownMaximumAttachmentSizeMb
            // 
            this.numericUpDownMaximumAttachmentSizeMb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownMaximumAttachmentSizeMb.DecimalPlaces = 1;
            this.numericUpDownMaximumAttachmentSizeMb.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownMaximumAttachmentSizeMb.Location = new System.Drawing.Point(170, 153);
            this.numericUpDownMaximumAttachmentSizeMb.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownMaximumAttachmentSizeMb.Name = "numericUpDownMaximumAttachmentSizeMb";
            this.numericUpDownMaximumAttachmentSizeMb.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownMaximumAttachmentSizeMb.TabIndex = 12;
            this.numericUpDownMaximumAttachmentSizeMb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownMaximumAttachmentSizeMb.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDownMaximumAttachmentSizeMb.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownMaximumAttachmentSizeMb.ValueChanged += new System.EventHandler(this.numericUpDownMaximumAttachmentSizeMb_ValueChanged);
            // 
            // textBoxGmailPassword
            // 
            this.textBoxGmailPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGmailPassword.Location = new System.Drawing.Point(143, 42);
            this.textBoxGmailPassword.Name = "textBoxGmailPassword";
            this.textBoxGmailPassword.Size = new System.Drawing.Size(250, 20);
            this.textBoxGmailPassword.TabIndex = 9;
            this.textBoxGmailPassword.TextChanged += new System.EventHandler(this.textBoxGmailPassword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Sender Gmail password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Sender Gmail address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mb";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelAverageForMega);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.numericUpDownUploadSpeed);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.textBoxEmailSubjectPrefix);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.TextBoxsArchivesPassword);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.textBoxValidatedEmail);
            this.groupBox4.Controls.Add(this.numericUpDownMaximumAttachmentSizeMb);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.textBoxGmailPassword);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(513, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(404, 231);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings:";
            // 
            // labelAverageForMega
            // 
            this.labelAverageForMega.AutoSize = true;
            this.labelAverageForMega.Location = new System.Drawing.Point(167, 202);
            this.labelAverageForMega.Name = "labelAverageForMega";
            this.labelAverageForMega.Size = new System.Drawing.Size(25, 13);
            this.labelAverageForMega.TabIndex = 22;
            this.labelAverageForMega.Text = "000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Average time for 1M:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "kps";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Upload speed:";
            // 
            // numericUpDownUploadSpeed
            // 
            this.numericUpDownUploadSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownUploadSpeed.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownUploadSpeed.Location = new System.Drawing.Point(170, 179);
            this.numericUpDownUploadSpeed.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDownUploadSpeed.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownUploadSpeed.Name = "numericUpDownUploadSpeed";
            this.numericUpDownUploadSpeed.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownUploadSpeed.TabIndex = 18;
            this.numericUpDownUploadSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownUploadSpeed.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDownUploadSpeed.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownUploadSpeed.ValueChanged += new System.EventHandler(this.numericUpDownSendTimeout_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "EMail subject prefix:";
            // 
            // textBoxEmailSubjectPrefix
            // 
            this.textBoxEmailSubjectPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmailSubjectPrefix.Location = new System.Drawing.Point(143, 68);
            this.textBoxEmailSubjectPrefix.Name = "textBoxEmailSubjectPrefix";
            this.textBoxEmailSubjectPrefix.Size = new System.Drawing.Size(250, 20);
            this.textBoxEmailSubjectPrefix.TabIndex = 16;
            this.textBoxEmailSubjectPrefix.TextChanged += new System.EventHandler(this.textBoxEmailSubjectPrefix_TextChanged);
            // 
            // TextBoxsArchivesPassword
            // 
            this.TextBoxsArchivesPassword.Context = "Archives password";
            this.TextBoxsArchivesPassword.Location = new System.Drawing.Point(9, 93);
            this.TextBoxsArchivesPassword.Name = "TextBoxsArchivesPassword";
            this.TextBoxsArchivesPassword.Password = "";
            this.TextBoxsArchivesPassword.PasswordChar = '\0';
            this.TextBoxsArchivesPassword.Size = new System.Drawing.Size(384, 54);
            this.TextBoxsArchivesPassword.TabIndex = 11;
            this.TextBoxsArchivesPassword.PasswordChanged += new System.EventHandler(this.TextBoxsArchivesPassword_PasswordChanged);
            // 
            // textBoxValidatedEmail
            // 
            this.textBoxValidatedEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBoxValidatedEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxValidatedEmail.ColorNotValid = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBoxValidatedEmail.ColorValid = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBoxValidatedEmail.CustomValidationRegexString = "";
            this.textBoxValidatedEmail.Location = new System.Drawing.Point(143, 16);
            this.textBoxValidatedEmail.Name = "textBoxValidatedEmail";
            this.textBoxValidatedEmail.Size = new System.Drawing.Size(250, 20);
            this.textBoxValidatedEmail.TabIndex = 7;
            this.textBoxValidatedEmail.ValidationRule = AnignoLibrary.UI.TextBoxs.TextBoxValidated.ValidationRuleEnum.Email;
            this.textBoxValidatedEmail.TextChanged += new System.EventHandler(this.textBoxValidatedEmail_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 619);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Anigno Backup to Gmail";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumAttachmentSizeMb)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUploadSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AnignoLibrary.UI.TreeViewControls.AnignoTreeViewFilesAndFoldersBrowserControl.cs.AnignoTreeViewFilesAndFoldersBrowser TvFoldersSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAddFolders;
        private AnignoLibrary.UI.Lists.ListViewControls.ListViewExt listViewExtArchiveQueue;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox2;
        private AnignoLibrary.UI.Utils.AnignoZipForgeControl anignoZipForgeControlMain;
        private System.Windows.Forms.GroupBox groupBox3;
        private AnignoLibrary.UI.Lists.ListViewControls.ListViewExt listViewExtSender;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private AnignoLibrary.UI.TextBoxs.AnignoPasswordConfirmationTextBoxs TextBoxsArchivesPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMaximumAttachmentSizeMb;
        private System.Windows.Forms.TextBox textBoxGmailPassword;
        private System.Windows.Forms.Label label2;
        private AnignoLibrary.UI.TextBoxs.TextBoxValidated textBoxValidatedEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEmailSubjectPrefix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownUploadSpeed;
        private System.Windows.Forms.Label labelAverageForMega;
        private System.Windows.Forms.Label label8;
        private AnignoLibrary.UI.ProgressBars.AnignoProgressBarAutoIncreament anignoProgressBarAutoIncreamentTimeout;
        private AnignoLibrary.UI.Lists.ListViewControls.ListViewExt listViewExtLog;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}