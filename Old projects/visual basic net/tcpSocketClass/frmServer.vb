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
    Friend WithEvents lstState As System.Windows.Forms.ListBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents pic As System.Windows.Forms.PictureBox
    Friend WithEvents txtToSend As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lstState = New System.Windows.Forms.ListBox
        Me.btnSend = New System.Windows.Forms.Button
        Me.txtToSend = New System.Windows.Forms.TextBox
        Me.pic = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'lstState
        '
        Me.lstState.ItemHeight = 16
        Me.lstState.Location = New System.Drawing.Point(0, 0)
        Me.lstState.Name = "lstState"
        Me.lstState.Size = New System.Drawing.Size(232, 212)
        Me.lstState.TabIndex = 0
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(0, 240)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(104, 24)
        Me.btnSend.TabIndex = 1
        Me.btnSend.Text = "send text"
        '
        'txtToSend
        '
        Me.txtToSend.Location = New System.Drawing.Point(0, 216)
        Me.txtToSend.Name = "txtToSend"
        Me.txtToSend.Size = New System.Drawing.Size(232, 22)
        Me.txtToSend.TabIndex = 2
        Me.txtToSend.Text = ""
        '
        'pic
        '
        Me.pic.Location = New System.Drawing.Point(232, 0)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(144, 136)
        Me.pic.TabIndex = 3
        Me.pic.TabStop = False
        '
        'frmServer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(384, 268)
        Me.Controls.Add(Me.pic)
        Me.Controls.Add(Me.txtToSend)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.lstState)
        Me.Name = "frmServer"
        Me.Text = "frmServer"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents tcpSocket As tcpSocketClass
    Private transferedDataType As String

    Private Sub frmServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        transferedDataType = ""
        'init socket to server and setting port
        tcpSocket = New tcpSocketClass(tcpSocketClass.CONNECTION_SOCKET_TYPE.SERVER, 8000)
        'listen to port
        tcpSocket.startListen()
    End Sub

    Private Sub tcpSocket_stateChanged(ByVal sender As Object) Handles tcpSocket.stateChanged
        'write event number and socket state to listbox
        lstState.Items.Insert(0, tcpSocket.eventCounter & ":" & tcpSocket.socketState)
    End Sub

    Private Sub tcpSocket_dataAvaliable(ByVal sender As Object) Handles tcpSocket.dataAvaliable
        If transferedDataType = "image" Then
            'data is image
            pic.Image = tcpSocket.getImage()
            transferedDataType = ""
        Else
            'data is text
            Dim inText As String
            inText = tcpSocket.getString()
            'check if data is the word "image" to set next input as image
            Dim codeText As String = Microsoft.VisualBasic.Left(inText, 5)
            If codeText = "image" Then
                transferedDataType = "image"
                lstState.Items.Insert(0, "next data is image!")
            Else
                lstState.Items.Insert(0, inText)
            End If
        End If
    End Sub

    Private Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        tcpSocket.sendString(txtToSend.Text)
    End Sub
End Class
