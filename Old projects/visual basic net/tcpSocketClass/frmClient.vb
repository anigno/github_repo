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
    Friend WithEvents lstState As System.Windows.Forms.ListBox
    Friend WithEvents pic As System.Windows.Forms.PictureBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents txtToSend As System.Windows.Forms.TextBox
    Friend WithEvents btnSendImage As System.Windows.Forms.Button
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmClient))
        Me.lstState = New System.Windows.Forms.ListBox
        Me.pic = New System.Windows.Forms.PictureBox
        Me.txtToSend = New System.Windows.Forms.TextBox
        Me.btnSend = New System.Windows.Forms.Button
        Me.btnSendImage = New System.Windows.Forms.Button
        Me.btnConnect = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lstState
        '
        Me.lstState.ItemHeight = 16
        Me.lstState.Location = New System.Drawing.Point(0, 0)
        Me.lstState.Name = "lstState"
        Me.lstState.Size = New System.Drawing.Size(232, 212)
        Me.lstState.TabIndex = 4
        '
        'pic
        '
        Me.pic.Image = CType(resources.GetObject("pic.Image"), System.Drawing.Image)
        Me.pic.Location = New System.Drawing.Point(232, 0)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(144, 136)
        Me.pic.TabIndex = 7
        Me.pic.TabStop = False
        '
        'txtToSend
        '
        Me.txtToSend.Location = New System.Drawing.Point(0, 216)
        Me.txtToSend.Name = "txtToSend"
        Me.txtToSend.Size = New System.Drawing.Size(232, 22)
        Me.txtToSend.TabIndex = 6
        Me.txtToSend.Text = ""
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(0, 240)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(104, 24)
        Me.btnSend.TabIndex = 5
        Me.btnSend.Text = "send text"
        '
        'btnSendImage
        '
        Me.btnSendImage.Location = New System.Drawing.Point(232, 136)
        Me.btnSendImage.Name = "btnSendImage"
        Me.btnSendImage.Size = New System.Drawing.Size(104, 24)
        Me.btnSendImage.TabIndex = 8
        Me.btnSendImage.Text = "send Image"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(248, 216)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(104, 24)
        Me.btnConnect.TabIndex = 9
        Me.btnConnect.Text = "connect"
        '
        'frmClient
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(384, 268)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.btnSendImage)
        Me.Controls.Add(Me.pic)
        Me.Controls.Add(Me.txtToSend)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.lstState)
        Me.Name = "frmClient"
        Me.Text = "frmClient"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public WithEvents tcpSocket As tcpSocketClass
    Private Sub frmClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tcpSocket = New tcpSocketClass(tcpSocketClass.CONNECTION_SOCKET_TYPE.CLIENT, 8000, "127.0.0.1")
    End Sub

    Private Sub tcpSocket_stateChanged(ByVal sender As Object) Handles tcpSocket.stateChanged
        lstState.Items.Insert(0, tcpSocket.eventCounter & ":" & tcpSocket.socketState)
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        tcpSocket.connect()
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        tcpSocket.sendString(txtToSend.Text)
    End Sub

    Private Sub btnSendImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendImage.Click
        tcpSocket.sendImage(pic.Image)
    End Sub

    Private Sub tcpSocket_dataAvaliable(ByVal sender As Object) Handles tcpSocket.dataAvaliable
        lstState.Items.Insert(0, tcpSocket.getString())
    End Sub
End Class
