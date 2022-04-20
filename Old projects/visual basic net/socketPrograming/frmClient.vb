Imports System.Net.Sockets
Public Class frmClient
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
    Friend WithEvents lstClient As System.Windows.Forms.ListBox
    Friend WithEvents tmrClient As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lstClient = New System.Windows.Forms.ListBox
        Me.tmrClient = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lstClient
        '
        Me.lstClient.ItemHeight = 16
        Me.lstClient.Location = New System.Drawing.Point(0, 0)
        Me.lstClient.Name = "lstClient"
        Me.lstClient.Size = New System.Drawing.Size(184, 292)
        Me.lstClient.TabIndex = 0
        '
        'tmrClient
        '
        Me.tmrClient.Interval = 3000
        '
        'frmClient
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(192, 324)
        Me.Controls.Add(Me.lstClient)
        Me.Name = "frmClient"
        Me.Text = "frmClient"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public client As System.Net.Sockets.TcpClient
    Public stream As NetworkStream

    Private Sub frmClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        Me.Text = CInt(Rnd(1000) * 1000)
        client = New System.Net.Sockets.TcpClient
        Try
            client.Connect("127.0.0.1", 8000)
            tmrClient.Enabled = True
        Catch exception1 As Exception
            lstClient.Items.Insert(0, exception1.ToString)
            Me.Close()
        End Try
    End Sub

    Private Sub tmrClient_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrClient.Tick
        stream = client.GetStream()
        Dim sendBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(Me.Text & "-" & Now.ToString)
        stream.Write(sendBytes, 0, sendBytes.Length)
        lstClient.Items.Insert(0, Now.ToString)
    End Sub

End Class
