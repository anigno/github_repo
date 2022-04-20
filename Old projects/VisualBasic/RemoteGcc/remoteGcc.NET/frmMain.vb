Option Strict Off
Option Explicit On
Friend Class frmMain
	Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
	Public Sub New()
		MyBase.New()
		If m_vb6FormDefInstance Is Nothing Then
			If m_InitializingDefInstance Then
				m_vb6FormDefInstance = Me
			Else
				Try 
					'For the start-up form, the first instance created is the default instance.
					If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
						m_vb6FormDefInstance = Me
					End If
				Catch
				End Try
			End If
		End If
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cmdRun3 As System.Windows.Forms.Button
	Public WithEvents chkFtp1 As System.Windows.Forms.CheckBox
	Public WithEvents chkFtp As System.Windows.Forms.CheckBox
	Public WithEvents txtCommandLine3 As System.Windows.Forms.TextBox
	Public WithEvents txtCommandLine2 As System.Windows.Forms.TextBox
	Public WithEvents cmdRun2 As System.Windows.Forms.Button
	Public WithEvents cmdOpenTelnet As System.Windows.Forms.Button
	Public WithEvents RTF2 As AxRichTextLib.AxRichTextBox
	Public WithEvents cmdRun As System.Windows.Forms.Button
	Public WithEvents txtCommandLine As System.Windows.Forms.TextBox
	Public WithEvents lstAction As System.Windows.Forms.ListBox
	Public WithEvents FTP1 As AxEZFTPLib.AxEZFTP
	Public WithEvents cmdOpenFTP As System.Windows.Forms.Button
	Public WithEvents File1 As Microsoft.VisualBasic.Compatibility.VB6.FileListBox
	Public WithEvents RTF1 As AxRichTextLib.AxRichTextBox
	Public WithEvents lblPath As System.Windows.Forms.Label
	Public WithEvents menuChangeProjectDir As System.Windows.Forms.MenuItem
	Public WithEvents menuFtpParameters As System.Windows.Forms.MenuItem
	Public WithEvents menuSaveProjectParameters As System.Windows.Forms.MenuItem
	Public WithEvents menuProject As System.Windows.Forms.MenuItem
	Public WithEvents menuNewFile As System.Windows.Forms.MenuItem
	Public WithEvents menuSaveCurrentFile As System.Windows.Forms.MenuItem
	Public WithEvents menuFile As System.Windows.Forms.MenuItem
	Public MainMenu1 As System.Windows.Forms.MainMenu
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cmdRun3 = New System.Windows.Forms.Button
		Me.chkFtp1 = New System.Windows.Forms.CheckBox
		Me.chkFtp = New System.Windows.Forms.CheckBox
		Me.txtCommandLine3 = New System.Windows.Forms.TextBox
		Me.txtCommandLine2 = New System.Windows.Forms.TextBox
		Me.cmdRun2 = New System.Windows.Forms.Button
		Me.cmdOpenTelnet = New System.Windows.Forms.Button
		Me.RTF2 = New AxRichTextLib.AxRichTextBox
		Me.cmdRun = New System.Windows.Forms.Button
		Me.txtCommandLine = New System.Windows.Forms.TextBox
		Me.lstAction = New System.Windows.Forms.ListBox
		Me.FTP1 = New AxEZFTPLib.AxEZFTP
		Me.cmdOpenFTP = New System.Windows.Forms.Button
		Me.File1 = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox
		Me.RTF1 = New AxRichTextLib.AxRichTextBox
		Me.lblPath = New System.Windows.Forms.Label
		Me.MainMenu1 = New System.Windows.Forms.MainMenu
		Me.menuProject = New System.Windows.Forms.MenuItem
		Me.menuChangeProjectDir = New System.Windows.Forms.MenuItem
		Me.menuFtpParameters = New System.Windows.Forms.MenuItem
		Me.menuSaveProjectParameters = New System.Windows.Forms.MenuItem
		Me.menuFile = New System.Windows.Forms.MenuItem
		Me.menuNewFile = New System.Windows.Forms.MenuItem
		Me.menuSaveCurrentFile = New System.Windows.Forms.MenuItem
		CType(Me.RTF2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.FTP1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.RTF1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Remote gcc"
		Me.ClientSize = New System.Drawing.Size(874, 613)
		Me.Location = New System.Drawing.Point(11, 35)
		Me.Icon = CType(resources.GetObject("frmMain.Icon"), System.Drawing.Icon)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMain"
		Me.cmdRun3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRun3.Text = "Run no ftp"
		Me.cmdRun3.Size = New System.Drawing.Size(91, 26)
		Me.cmdRun3.Location = New System.Drawing.Point(200, 90)
		Me.cmdRun3.TabIndex = 11
		Me.cmdRun3.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRun3.CausesValidation = True
		Me.cmdRun3.Enabled = True
		Me.cmdRun3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRun3.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRun3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRun3.TabStop = True
		Me.cmdRun3.Name = "cmdRun3"
		Me.chkFtp1.Text = "ftp"
		Me.chkFtp1.Size = New System.Drawing.Size(41, 31)
		Me.chkFtp1.Location = New System.Drawing.Point(250, 60)
		Me.chkFtp1.TabIndex = 14
		Me.chkFtp1.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkFtp1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkFtp1.BackColor = System.Drawing.SystemColors.Control
		Me.chkFtp1.CausesValidation = True
		Me.chkFtp1.Enabled = True
		Me.chkFtp1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkFtp1.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkFtp1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkFtp1.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkFtp1.TabStop = True
		Me.chkFtp1.Visible = True
		Me.chkFtp1.Name = "chkFtp1"
		Me.chkFtp.Text = "ftp"
		Me.chkFtp.Size = New System.Drawing.Size(41, 31)
		Me.chkFtp.Location = New System.Drawing.Point(250, 30)
		Me.chkFtp.TabIndex = 13
		Me.chkFtp.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkFtp.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkFtp.BackColor = System.Drawing.SystemColors.Control
		Me.chkFtp.CausesValidation = True
		Me.chkFtp.Enabled = True
		Me.chkFtp.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkFtp.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkFtp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkFtp.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkFtp.TabStop = True
		Me.chkFtp.Visible = True
		Me.chkFtp.Name = "chkFtp"
		Me.txtCommandLine3.AutoSize = False
		Me.txtCommandLine3.Size = New System.Drawing.Size(411, 24)
		Me.txtCommandLine3.Location = New System.Drawing.Point(300, 90)
		Me.txtCommandLine3.TabIndex = 12
		Me.txtCommandLine3.Text = "gcc -ansi -pedantic -Wall file01.c -o file01_run"
		Me.txtCommandLine3.AcceptsReturn = True
		Me.txtCommandLine3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCommandLine3.BackColor = System.Drawing.SystemColors.Window
		Me.txtCommandLine3.CausesValidation = True
		Me.txtCommandLine3.Enabled = True
		Me.txtCommandLine3.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCommandLine3.HideSelection = True
		Me.txtCommandLine3.ReadOnly = False
		Me.txtCommandLine3.Maxlength = 0
		Me.txtCommandLine3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCommandLine3.MultiLine = False
		Me.txtCommandLine3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCommandLine3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCommandLine3.TabStop = True
		Me.txtCommandLine3.Visible = True
		Me.txtCommandLine3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCommandLine3.Name = "txtCommandLine3"
		Me.txtCommandLine2.AutoSize = False
		Me.txtCommandLine2.Size = New System.Drawing.Size(411, 24)
		Me.txtCommandLine2.Location = New System.Drawing.Point(300, 60)
		Me.txtCommandLine2.TabIndex = 10
		Me.txtCommandLine2.Text = "gcc -ansi -pedantic -Wall file01.c -o file01_run"
		Me.txtCommandLine2.AcceptsReturn = True
		Me.txtCommandLine2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCommandLine2.BackColor = System.Drawing.SystemColors.Window
		Me.txtCommandLine2.CausesValidation = True
		Me.txtCommandLine2.Enabled = True
		Me.txtCommandLine2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCommandLine2.HideSelection = True
		Me.txtCommandLine2.ReadOnly = False
		Me.txtCommandLine2.Maxlength = 0
		Me.txtCommandLine2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCommandLine2.MultiLine = False
		Me.txtCommandLine2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCommandLine2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCommandLine2.TabStop = True
		Me.txtCommandLine2.Visible = True
		Me.txtCommandLine2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCommandLine2.Name = "txtCommandLine2"
		Me.cmdRun2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRun2.Text = "Run"
		Me.cmdRun2.Size = New System.Drawing.Size(41, 26)
		Me.cmdRun2.Location = New System.Drawing.Point(200, 60)
		Me.cmdRun2.TabIndex = 9
		Me.cmdRun2.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRun2.CausesValidation = True
		Me.cmdRun2.Enabled = True
		Me.cmdRun2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRun2.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRun2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRun2.TabStop = True
		Me.cmdRun2.Name = "cmdRun2"
		Me.cmdOpenTelnet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOpenTelnet.Text = "Open new TELNET"
		Me.cmdOpenTelnet.Enabled = False
		Me.cmdOpenTelnet.Size = New System.Drawing.Size(71, 41)
		Me.cmdOpenTelnet.Location = New System.Drawing.Point(70, 240)
		Me.cmdOpenTelnet.TabIndex = 3
		Me.cmdOpenTelnet.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOpenTelnet.CausesValidation = True
		Me.cmdOpenTelnet.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOpenTelnet.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOpenTelnet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOpenTelnet.TabStop = True
		Me.cmdOpenTelnet.Name = "cmdOpenTelnet"
		RTF2.OcxState = CType(resources.GetObject("RTF2.OcxState"), System.Windows.Forms.AxHost.State)
		Me.RTF2.Size = New System.Drawing.Size(71, 51)
		Me.RTF2.Location = New System.Drawing.Point(220, 140)
		Me.RTF2.TabIndex = 8
		Me.RTF2.Visible = False
		Me.RTF2.Name = "RTF2"
		Me.cmdRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRun.Text = "Run"
		Me.cmdRun.Size = New System.Drawing.Size(41, 26)
		Me.cmdRun.Location = New System.Drawing.Point(200, 30)
		Me.cmdRun.TabIndex = 7
		Me.cmdRun.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRun.CausesValidation = True
		Me.cmdRun.Enabled = True
		Me.cmdRun.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRun.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRun.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRun.TabStop = True
		Me.cmdRun.Name = "cmdRun"
		Me.txtCommandLine.AutoSize = False
		Me.txtCommandLine.Size = New System.Drawing.Size(411, 24)
		Me.txtCommandLine.Location = New System.Drawing.Point(300, 30)
		Me.txtCommandLine.TabIndex = 6
		Me.txtCommandLine.Text = "gcc -ansi -pedantic -Wall file01.c -o file01_run"
		Me.txtCommandLine.AcceptsReturn = True
		Me.txtCommandLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCommandLine.BackColor = System.Drawing.SystemColors.Window
		Me.txtCommandLine.CausesValidation = True
		Me.txtCommandLine.Enabled = True
		Me.txtCommandLine.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCommandLine.HideSelection = True
		Me.txtCommandLine.ReadOnly = False
		Me.txtCommandLine.Maxlength = 0
		Me.txtCommandLine.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCommandLine.MultiLine = False
		Me.txtCommandLine.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCommandLine.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCommandLine.TabStop = True
		Me.txtCommandLine.Visible = True
		Me.txtCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCommandLine.Name = "txtCommandLine"
		Me.lstAction.Size = New System.Drawing.Size(201, 312)
		Me.lstAction.Location = New System.Drawing.Point(0, 290)
		Me.lstAction.TabIndex = 5
		Me.lstAction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstAction.BackColor = System.Drawing.SystemColors.Window
		Me.lstAction.CausesValidation = True
		Me.lstAction.Enabled = True
		Me.lstAction.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstAction.IntegralHeight = True
		Me.lstAction.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstAction.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstAction.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstAction.Sorted = False
		Me.lstAction.TabStop = True
		Me.lstAction.Visible = True
		Me.lstAction.MultiColumn = False
		Me.lstAction.Name = "lstAction"
		FTP1.OcxState = CType(resources.GetObject("FTP1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.FTP1.Location = New System.Drawing.Point(300, 140)
		Me.FTP1.Name = "FTP1"
		Me.cmdOpenFTP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOpenFTP.Text = "OpenFTP"
		Me.cmdOpenFTP.Size = New System.Drawing.Size(71, 41)
		Me.cmdOpenFTP.Location = New System.Drawing.Point(0, 240)
		Me.cmdOpenFTP.TabIndex = 4
		Me.cmdOpenFTP.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOpenFTP.CausesValidation = True
		Me.cmdOpenFTP.Enabled = True
		Me.cmdOpenFTP.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOpenFTP.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOpenFTP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOpenFTP.TabStop = True
		Me.cmdOpenFTP.Name = "cmdOpenFTP"
		Me.File1.Size = New System.Drawing.Size(201, 214)
		Me.File1.Location = New System.Drawing.Point(0, 20)
		Me.File1.Pattern = "*.c;*.cpp;*.h;*.txt"
		Me.File1.TabIndex = 1
		Me.File1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.File1.Archive = True
		Me.File1.BackColor = System.Drawing.SystemColors.Window
		Me.File1.CausesValidation = True
		Me.File1.Enabled = True
		Me.File1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.File1.Hidden = False
		Me.File1.Cursor = System.Windows.Forms.Cursors.Default
		Me.File1.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.File1.Normal = True
		Me.File1.ReadOnly = True
		Me.File1.System = False
		Me.File1.TabStop = True
		Me.File1.TopIndex = 0
		Me.File1.Visible = True
		Me.File1.Name = "File1"
		RTF1.OcxState = CType(resources.GetObject("RTF1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.RTF1.Size = New System.Drawing.Size(501, 491)
		Me.RTF1.Location = New System.Drawing.Point(210, 120)
		Me.RTF1.TabIndex = 0
		Me.RTF1.Name = "RTF1"
		Me.lblPath.Text = "path"
		Me.lblPath.Size = New System.Drawing.Size(511, 21)
		Me.lblPath.Location = New System.Drawing.Point(0, 0)
		Me.lblPath.TabIndex = 2
		Me.lblPath.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPath.BackColor = System.Drawing.SystemColors.Control
		Me.lblPath.Enabled = True
		Me.lblPath.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPath.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPath.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPath.UseMnemonic = True
		Me.lblPath.Visible = True
		Me.lblPath.AutoSize = False
		Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPath.Name = "lblPath"
		Me.menuProject.Text = "&Project"
		Me.menuProject.Checked = False
		Me.menuProject.Enabled = True
		Me.menuProject.Visible = True
		Me.menuProject.MDIList = False
		Me.menuChangeProjectDir.Text = "Change project DIR"
		Me.menuChangeProjectDir.Shortcut = System.Windows.Forms.Shortcut.CtrlD
		Me.menuChangeProjectDir.Checked = False
		Me.menuChangeProjectDir.Enabled = True
		Me.menuChangeProjectDir.Visible = True
		Me.menuChangeProjectDir.MDIList = False
		Me.menuFtpParameters.Text = "Ftp and Telnet parameters"
		Me.menuFtpParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlF
		Me.menuFtpParameters.Checked = False
		Me.menuFtpParameters.Enabled = True
		Me.menuFtpParameters.Visible = True
		Me.menuFtpParameters.MDIList = False
		Me.menuSaveProjectParameters.Text = "Save project parameters"
		Me.menuSaveProjectParameters.Shortcut = System.Windows.Forms.Shortcut.CtrlP
		Me.menuSaveProjectParameters.Checked = False
		Me.menuSaveProjectParameters.Enabled = True
		Me.menuSaveProjectParameters.Visible = True
		Me.menuSaveProjectParameters.MDIList = False
		Me.menuFile.Text = "&File"
		Me.menuFile.Checked = False
		Me.menuFile.Enabled = True
		Me.menuFile.Visible = True
		Me.menuFile.MDIList = False
		Me.menuNewFile.Text = "New file"
		Me.menuNewFile.Checked = False
		Me.menuNewFile.Enabled = True
		Me.menuNewFile.Visible = True
		Me.menuNewFile.MDIList = False
		Me.menuSaveCurrentFile.Text = "Save current file"
		Me.menuSaveCurrentFile.Shortcut = System.Windows.Forms.Shortcut.CtrlS
		Me.menuSaveCurrentFile.Checked = False
		Me.menuSaveCurrentFile.Enabled = True
		Me.menuSaveCurrentFile.Visible = True
		Me.menuSaveCurrentFile.MDIList = False
		Me.Controls.Add(cmdRun3)
		Me.Controls.Add(chkFtp1)
		Me.Controls.Add(chkFtp)
		Me.Controls.Add(txtCommandLine3)
		Me.Controls.Add(txtCommandLine2)
		Me.Controls.Add(cmdRun2)
		Me.Controls.Add(cmdOpenTelnet)
		Me.Controls.Add(RTF2)
		Me.Controls.Add(cmdRun)
		Me.Controls.Add(txtCommandLine)
		Me.Controls.Add(lstAction)
		Me.Controls.Add(FTP1)
		Me.Controls.Add(cmdOpenFTP)
		Me.Controls.Add(File1)
		Me.Controls.Add(RTF1)
		Me.Controls.Add(lblPath)
		CType(Me.RTF1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FTP1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.RTF2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.menuProject.Index = 0
		Me.menuFile.Index = 1
		MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem(){Me.menuProject, Me.menuFile})
		Me.menuChangeProjectDir.Index = 0
		Me.menuFtpParameters.Index = 1
		Me.menuSaveProjectParameters.Index = 2
		menuProject.MenuItems.AddRange(New System.Windows.Forms.MenuItem(){Me.menuChangeProjectDir, Me.menuFtpParameters, Me.menuSaveProjectParameters})
		Me.menuNewFile.Index = 0
		Me.menuSaveCurrentFile.Index = 1
		menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem(){Me.menuNewFile, Me.menuSaveCurrentFile})
		Me.Menu = MainMenu1
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmMain
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmMain
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmMain()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	Private Sub cmdOpenFTP_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpenFTP.Click
		On Error GoTo errorFtpConnect
		cmdOpenFTP.Text = "WAIT"
		FTP1.RemoteAddress = ftpHost
		FTP1.UserName = ftpUsername
		FTP1.Password = ftpPassword
		FTP1.Connect()
		cmdOpenTelnet.Enabled = True
		cmdOpenFTP.Enabled = False
		Exit Sub
errorFtpConnect: 
		MsgBox("error open FTP, check parameters.", MsgBoxStyle.Critical)
		cmdOpenFTP.Text = "Open FTP"
	End Sub
	
	Private Sub cmdOpenTelnet_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOpenTelnet.Click
		'UPGRADE_WARNING: Couldn't resolve default property of object TelnetNumber. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"'
		TelnetNumber = Shell("telnet " & ftpHost, AppWinStyle.NormalFocus)
	End Sub
	
	Private Sub cmdRun_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRun.Click
		On Error GoTo errorRun
		saveFile(File1, RTF1, currentFile)
		If chkFtp.CheckState = 1 Then sendFiles(File1, FTP1, lstAction, RTF1, RTF2)
		AppActivate(TelnetNumber)
		System.Windows.Forms.SendKeys.Send(txtCommandLine.Text & "{enter}")
		Exit Sub
errorRun: 
		MsgBox("error, no telnet!, restart program or open telnet.", MsgBoxStyle.Critical)
	End Sub
	
	Private Sub cmdRun2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRun2.Click
		On Error GoTo errorRun
		saveFile(File1, RTF1, currentFile)
		If chkFtp1.CheckState = 1 Then sendFiles(File1, FTP1, lstAction, RTF1, RTF2)
		AppActivate(TelnetNumber)
		System.Windows.Forms.SendKeys.Send(txtCommandLine2.Text & "{enter}")
		Exit Sub
errorRun: 
		MsgBox("error, no telnet!, restart program or open telnet.", MsgBoxStyle.Critical)
	End Sub
	
	Private Sub cmdRun3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRun3.Click
		On Error GoTo errorRun
		saveFile(File1, RTF1, currentFile)
		'sendFiles File1, FTP1, lstAction, RTF1, RTF2
		AppActivate(TelnetNumber)
		System.Windows.Forms.SendKeys.Send(txtCommandLine3.Text & "{enter}")
		Exit Sub
errorRun: 
		MsgBox("error, no telnet!, restart program or open telnet.", MsgBoxStyle.Critical)
	End Sub
	
	
	
	Private Sub File1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles File1.SelectedIndexChanged
		replaceFiles(File1, RTF1, currentFile, File1.Items(File1.SelectedIndex))
	End Sub
	
	Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		setCurrentFile(frmMain.DefInstance, "no file")
		lblPath.Text = File1.Path
		ftpHost = GetSetting("remoteGcc", "param", "ftpHost", "study.haifa.ac.il")
		ftpUsername = GetSetting("remoteGcc", "param", "ftpUsername", "anigno")
		ftpPassword = GetSetting("remoteGcc", "param", "ftpPassword", "29024783")
		File1.Path = GetSetting("remoteGcc", "param", "projectDir", "c:\")
		txtCommandLine.Text = GetSetting("remoteGcc", "param", "run", "gcc -ansi -pedantic -Wall source.c -o run_file")
		txtCommandLine2.Text = GetSetting("remoteGcc", "param", "run2", "gcc -ansi -pedantic -Wall source.c -o run_file")
		txtCommandLine3.Text = GetSetting("remoteGcc", "param", "run3", "gcc -ansi -pedantic -Wall source.c -o run_file")
	End Sub
	
	'UPGRADE_WARNING: Form event frmMain.Unload has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmMain_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
		FTP1.Disconnect()
		SaveSetting("remoteGcc", "param", "run", frmMain.DefInstance.txtCommandLine.Text)
		SaveSetting("remoteGcc", "param", "run2", frmMain.DefInstance.txtCommandLine2.Text)
		SaveSetting("remoteGcc", "param", "run3", frmMain.DefInstance.txtCommandLine3.Text)
		saveFile(File1, RTF1, currentFile)
	End Sub
	
	Public Sub menuChangeProjectDir_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menuChangeProjectDir.Popup
		menuChangeProjectDir_Click(eventSender, eventArgs)
	End Sub
	Public Sub menuChangeProjectDir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menuChangeProjectDir.Click
		frmMain.DefInstance.Enabled = False
		frmSelectDir.DefInstance.Show()
	End Sub
	
	Public Sub menuFtpParameters_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menuFtpParameters.Popup
		menuFtpParameters_Click(eventSender, eventArgs)
	End Sub
	Public Sub menuFtpParameters_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menuFtpParameters.Click
		frmMain.DefInstance.Enabled = False
		frmFtp.DefInstance.Show()
	End Sub
	
	Public Sub menuNewFile_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menuNewFile.Popup
		menuNewFile_Click(eventSender, eventArgs)
	End Sub
	Public Sub menuNewFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menuNewFile.Click
		createNewFile(frmMain.DefInstance, File1, RTF1)
	End Sub
	
	Public Sub menuSaveCurrentFile_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menuSaveCurrentFile.Popup
		menuSaveCurrentFile_Click(eventSender, eventArgs)
	End Sub
	Public Sub menuSaveCurrentFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles menuSaveCurrentFile.Click
		saveFile(File1, RTF1, currentFile)
	End Sub
End Class