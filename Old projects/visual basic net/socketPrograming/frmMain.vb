Public Class frmMain
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
    Friend WithEvents btnServer As System.Windows.Forms.Button
    Friend WithEvents btnClient As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnServer = New System.Windows.Forms.Button
        Me.btnClient = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnServer
        '
        Me.btnServer.Location = New System.Drawing.Point(32, 32)
        Me.btnServer.Name = "btnServer"
        Me.btnServer.Size = New System.Drawing.Size(75, 32)
        Me.btnServer.TabIndex = 0
        Me.btnServer.Text = "start server"
        '
        'btnClient
        '
        Me.btnClient.Location = New System.Drawing.Point(32, 72)
        Me.btnClient.Name = "btnClient"
        Me.btnClient.Size = New System.Drawing.Size(75, 32)
        Me.btnClient.TabIndex = 1
        Me.btnClient.Text = "start client"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(152, 172)
        Me.Controls.Add(Me.btnClient)
        Me.Controls.Add(Me.btnServer)
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServer.Click
        Dim newServer As New frmServer
        newServer.Show()
    End Sub

    Private Sub btnClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClient.Click
        Dim newClient As New frmClient
        newClient.Show()
    End Sub
End Class
