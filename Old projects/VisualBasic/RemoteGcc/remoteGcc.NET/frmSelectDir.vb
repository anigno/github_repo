Option Strict Off
Option Explicit On
Friend Class frmSelectDir
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
	Public WithEvents cmdSelect As System.Windows.Forms.Button
	Public WithEvents Dir1 As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
	Public WithEvents Drive1 As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelectDir))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdSelect = New System.Windows.Forms.Button
		Me.Dir1 = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox
		Me.Drive1 = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
		Me.Text = "Select Dir"
		Me.ClientSize = New System.Drawing.Size(252, 320)
		Me.Location = New System.Drawing.Point(4, 28)
		Me.Icon = CType(resources.GetObject("frmSelectDir.Icon"), System.Drawing.Icon)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
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
		Me.Name = "frmSelectDir"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(81, 31)
		Me.cmdCancel.Location = New System.Drawing.Point(170, 290)
		Me.cmdCancel.TabIndex = 3
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSelect.Text = "Select"
		Me.cmdSelect.Size = New System.Drawing.Size(81, 31)
		Me.cmdSelect.Location = New System.Drawing.Point(0, 290)
		Me.cmdSelect.TabIndex = 2
		Me.cmdSelect.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSelect.CausesValidation = True
		Me.cmdSelect.Enabled = True
		Me.cmdSelect.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSelect.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSelect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSelect.TabStop = True
		Me.cmdSelect.Name = "cmdSelect"
		Me.Dir1.Size = New System.Drawing.Size(251, 258)
		Me.Dir1.Location = New System.Drawing.Point(0, 30)
		Me.Dir1.TabIndex = 1
		Me.Dir1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Dir1.BackColor = System.Drawing.SystemColors.Window
		Me.Dir1.CausesValidation = True
		Me.Dir1.Enabled = True
		Me.Dir1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Dir1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Dir1.TabStop = True
		Me.Dir1.Visible = True
		Me.Dir1.Name = "Dir1"
		Me.Drive1.Size = New System.Drawing.Size(251, 24)
		Me.Drive1.Location = New System.Drawing.Point(0, 0)
		Me.Drive1.TabIndex = 0
		Me.Drive1.BackColor = System.Drawing.SystemColors.Window
		Me.Drive1.CausesValidation = True
		Me.Drive1.Enabled = True
		Me.Drive1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Drive1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Drive1.TabStop = True
		Me.Drive1.Visible = True
		Me.Drive1.Name = "Drive1"
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdSelect)
		Me.Controls.Add(Dir1)
		Me.Controls.Add(Drive1)
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmSelectDir
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmSelectDir
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmSelectDir()
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
		frmSelectDir.DefInstance.Close()
	End Sub
	
	Private Sub cmdSelect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelect.Click
		frmMain.DefInstance.File1.Path = Dir1.DirList(Dir1.DirListIndex)
		frmMain.DefInstance.RTF1.Text = ""
		frmMain.DefInstance.lblPath.Text = frmMain.DefInstance.File1.Path
		SaveSetting("remoteGcc", "param", "projectDir", frmMain.DefInstance.File1.Path)
		setCurrentFile(frmMain.DefInstance, "no file")
		frmSelectDir.DefInstance.Close()
	End Sub
	
	Private Sub Drive1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Drive1.SelectedIndexChanged
		On Error Resume Next
		Dir1.Path = Drive1.Drive
	End Sub
	
	'UPGRADE_WARNING: Form event frmSelectDir.Unload has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup2065"'
	Private Sub frmSelectDir_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
		frmMain.DefInstance.Enabled = True
	End Sub
End Class