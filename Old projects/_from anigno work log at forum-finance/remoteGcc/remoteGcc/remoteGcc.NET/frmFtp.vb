Option Strict Off
Option Explicit On
Friend Class frmFtp
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
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdSet As System.Windows.Forms.Button
	Public WithEvents txtPassword As System.Windows.Forms.TextBox
	Public WithEvents txtUsername As System.Windows.Forms.TextBox
	Public WithEvents txtHost As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFtp))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdSet = New System.Windows.Forms.Button
		Me.txtPassword = New System.Windows.Forms.TextBox
		Me.txtUsername = New System.Windows.Forms.TextBox
		Me.txtHost = New System.Windows.Forms.TextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Text = "FTP parameters"
		Me.ClientSize = New System.Drawing.Size(424, 133)
		Me.Location = New System.Drawing.Point(4, 28)
		Me.Icon = CType(resources.GetObject("frmFtp.Icon"), System.Drawing.Icon)
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
		Me.Name = "frmFtp"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(81, 31)
		Me.cmdCancel.Location = New System.Drawing.Point(170, 100)
		Me.cmdCancel.TabIndex = 7
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSet.Text = "Set"
		Me.cmdSet.Size = New System.Drawing.Size(81, 31)
		Me.cmdSet.Location = New System.Drawing.Point(80, 100)
		Me.cmdSet.TabIndex = 6
		Me.cmdSet.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSet.CausesValidation = True
		Me.cmdSet.Enabled = True
		Me.cmdSet.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSet.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSet.TabStop = True
		Me.cmdSet.Name = "cmdSet"
		Me.txtPassword.AutoSize = False
		Me.txtPassword.Size = New System.Drawing.Size(341, 24)
		Me.txtPassword.Location = New System.Drawing.Point(80, 60)
		Me.txtPassword.TabIndex = 4
		Me.txtPassword.AcceptsReturn = True
		Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
		Me.txtPassword.CausesValidation = True
		Me.txtPassword.Enabled = True
		Me.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPassword.HideSelection = True
		Me.txtPassword.ReadOnly = False
		Me.txtPassword.Maxlength = 0
		Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPassword.MultiLine = False
		Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPassword.TabStop = True
		Me.txtPassword.Visible = True
		Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPassword.Name = "txtPassword"
		Me.txtUsername.AutoSize = False
		Me.txtUsername.Size = New System.Drawing.Size(341, 24)
		Me.txtUsername.Location = New System.Drawing.Point(80, 30)
		Me.txtUsername.TabIndex = 2
		Me.txtUsername.AcceptsReturn = True
		Me.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtUsername.BackColor = System.Drawing.SystemColors.Window
		Me.txtUsername.CausesValidation = True
		Me.txtUsername.Enabled = True
		Me.txtUsername.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtUsername.HideSelection = True
		Me.txtUsername.ReadOnly = False
		Me.txtUsername.Maxlength = 0
		Me.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtUsername.MultiLine = False
		Me.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtUsername.TabStop = True
		Me.txtUsername.Visible = True
		Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtUsername.Name = "txtUsername"
		Me.txtHost.AutoSize = False
		Me.txtHost.Size = New System.Drawing.Size(341, 24)
		Me.txtHost.Location = New System.Drawing.Point(80, 0)
		Me.txtHost.TabIndex = 0
		Me.txtHost.AcceptsReturn = True
		Me.txtHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtHost.BackColor = System.Drawing.SystemColors.Window
		Me.txtHost.CausesValidation = True
		Me.txtHost.Enabled = True
		Me.txtHost.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtHost.HideSelection = True
		Me.txtHost.ReadOnly = False
		Me.txtHost.Maxlength = 0
		Me.txtHost.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtHost.MultiLine = False
		Me.txtHost.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtHost.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtHost.TabStop = True
		Me.txtHost.Visible = True
		Me.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtHost.Name = "txtHost"
		Me.Label3.Text = "Password:"
		Me.Label3.Size = New System.Drawing.Size(81, 21)
		Me.Label3.Location = New System.Drawing.Point(0, 60)
		Me.Label3.TabIndex = 5
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "User name:"
		Me.Label2.Size = New System.Drawing.Size(81, 21)
		Me.Label2.Location = New System.Drawing.Point(0, 30)
		Me.Label2.TabIndex = 3
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "HOST:"
		Me.Label1.Size = New System.Drawing.Size(81, 21)
		Me.Label1.Location = New System.Drawing.Point(0, 0)
		Me.Label1.TabIndex = 1
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdSet)
		Me.Controls.Add(txtPassword)
		Me.Controls.Add(txtUsername)
		Me.Controls.Add(txtHost)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmFtp
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmFtp
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmFtp()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		frmFtp.DefInstance.Close()
	End Sub
	
	Private Sub cmdSet_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSet.Click
		ftpHost = txtHost.Text
		ftpUsername = txtUsername.Text
		ftpPassword = txtPassword.Text
		SaveSetting("remoteGcc", "param", "ftpHost", ftpHost)
		SaveSetting("remoteGcc", "param", "ftpUsername", ftpUsername)
		SaveSetting("remoteGcc", "param", "ftpPassword", ftpPassword)
		frmFtp.DefInstance.Close()
	End Sub
	
	Private Sub frmFtp_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		txtHost.Text = ftpHost
		txtUsername.Text = ftpUsername
		txtPassword.Text = ftpPassword
	End Sub
	
	'UPGRADE_WARNING: Form event frmFtp.Unload has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmFtp_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
		frmMain.DefInstance.Enabled = True
	End Sub
End Class