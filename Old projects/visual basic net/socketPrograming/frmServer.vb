Imports System.Net.Sockets

Public Class frmServer
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
    Friend WithEvents lstServer As System.Windows.Forms.ListBox
    Friend WithEvents tmrServer As System.Windows.Forms.Timer
    Friend WithEvents tmrData As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lstServer = New System.Windows.Forms.ListBox
        Me.tmrServer = New System.Windows.Forms.Timer(Me.components)
        Me.tmrData = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lstServer
        '
        Me.lstServer.ItemHeight = 16
        Me.lstServer.Location = New System.Drawing.Point(8, 8)
        Me.lstServer.Name = "lstServer"
        Me.lstServer.Size = New System.Drawing.Size(216, 292)
        Me.lstServer.TabIndex = 0
        '
        'tmrServer
        '
        Me.tmrServer.Enabled = True
        Me.tmrServer.Interval = 1000
        '
        'tmrData
        '
        Me.tmrData.Interval = 1000
        '
        'frmServer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(256, 308)
        Me.Controls.Add(Me.lstServer)
        Me.Name = "frmServer"
        Me.Text = "frmServer"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public listener As TcpListener
    Public client As TcpClient
    Public stream As NetworkStream


    Private Sub frmServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listener = New TcpListener(System.Net.IPAddress.Any, 8000)
        listener.Start()
        lstServer.Items.Insert(0, "listen to port 8000")
    End Sub

    Private Sub tmrServer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrServer.Tick
        If listener.Pending = True Then
            tmrServer.Enabled = False
            client = listener.AcceptTcpClient()
            lstServer.Items.Insert(0, "connection accepted")
            stream = client.GetStream()
            tmrData.Enabled = True
        End If
    End Sub

    Private Sub tmrData_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrData.Tick
        If stream.DataAvailable = True Then
            lstServer.Items.Insert(0, "incoming data:")
            Dim inBytes(client.ReceiveBufferSize) As Byte
            stream.Read(inBytes, 0, CInt(client.ReceiveBufferSize))
            Dim clientdata As String = System.Text.Encoding.ASCII.GetString(inBytes)
            lstServer.Items.Insert(0, clientdata)
        End If
    End Sub
End Class
