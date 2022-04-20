Public Class frmDirSelect
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents DriveListBox1 As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
    Friend WithEvents DirListBox1 As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DriveListBox1 = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox()
        Me.DirListBox1 = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DriveListBox1
        '
        Me.DriveListBox1.Location = New System.Drawing.Point(8, 8)
        Me.DriveListBox1.Name = "DriveListBox1"
        Me.DriveListBox1.Size = New System.Drawing.Size(216, 23)
        Me.DriveListBox1.TabIndex = 0
        '
        'DirListBox1
        '
        Me.DirListBox1.IntegralHeight = False
        Me.DirListBox1.Location = New System.Drawing.Point(8, 32)
        Me.DirListBox1.Name = "DirListBox1"
        Me.DirListBox1.Size = New System.Drawing.Size(216, 248)
        Me.DirListBox1.TabIndex = 1
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(8, 280)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "Select"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(80, 280)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = "New"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(152, 280)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'frmDirSelect
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(232, 312)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnNew, Me.btnSelect, Me.DirListBox1, Me.DriveListBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDirSelect"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select dir"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub DriveListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DriveListBox1.SelectedIndexChanged
        On Error Resume Next
        DirListBox1.Path = DriveListBox1.Drive
    End Sub

    Public selectedDir As String

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        selectedDir = DirListBox1.DirList(DirListBox1.DirListIndex)
        selectedDir = DirListBox1.DirList(DirListBox1.DirListIndex)
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        selectedDir = ""
        Me.Dispose()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        On Error GoTo errorindirname
        Dim newDir As String
        newDir = InputBox("Enter new dir from this location")
        If newDir <> "" Then
            MkDir(DirListBox1.DirList(DirListBox1.DirListIndex) & "\" & newDir)
            selectedDir = DirListBox1.DirList(DirListBox1.DirListIndex) & "\" & newDir
            Me.Dispose()
        End If
        Exit Sub
errorInDirName:
        MsgBox("Error in dir name!", MsgBoxStyle.Critical)
    End Sub

    Private Sub DirListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirListBox1.SelectedIndexChanged

    End Sub
End Class

