Imports System.Net.Sockets

Public Class tcpSocketClass

    Public Enum CONNECTION_SOCKET_TYPE
        CLIENT
        SERVER
    End Enum

    'private const
    Private Const TIMER_DEFAULT_INTERVAL = 100
    Private Const IMAGE_MAX_SIZE = 76800

    'private members
    Private hostAddress As String
    Private socketType As CONNECTION_SOCKET_TYPE
    Private WithEvents tmrServer As System.Timers.Timer
    Private WithEvents tmrClient As System.Timers.Timer
    Private WithEvents tmrData As System.Timers.Timer

    'public members
    Public ReadOnly socketPortNumber As Integer
    Public socketState As String
    Public socketNetworkStream As NetworkStream
    Public socketTcpClient As TcpClient
    Public listener As TcpListener
    Public eventCounter As Long

    'events
    'Private Event clientPending(ByVal sender As Object)
    Public Event stateChanged(ByVal sender As Object)
    Public Event dataAvaliable(ByVal sender As Object)

    '-------------------------------- CONSTRUCTORS ----------------------------
    Public Sub New(ByVal iSocketType As CONNECTION_SOCKET_TYPE, _
                    ByVal iPortNumber As Integer, _
                    Optional ByVal iConnectToHostAt As String = "127.0.0.1")
        eventCounter = 0
        socketType = iSocketType
        socketPortNumber = iPortNumber
        If socketType = CONNECTION_SOCKET_TYPE.SERVER Then
            'socket is server type
            listener = New TcpListener(System.Net.IPAddress.Any, iPortNumber)
            tmrServer = New System.Timers.Timer(TIMER_DEFAULT_INTERVAL)
        Else
            'socket is client
            socketTcpClient = New System.Net.Sockets.TcpClient
            hostAddress = iConnectToHostAt
        End If
        'tmrData ro check for data pending
        tmrData = New System.Timers.Timer(TIMER_DEFAULT_INTERVAL)
    End Sub

    '-------------------------------- SERVER ---------------------------------
    Public Sub startListen()
        'flldskfsdld
        If socketType = CONNECTION_SOCKET_TYPE.SERVER Then
            listener.Start()
            tmrServer.Enabled = True    'enable tmrServer to check for pending connections
            SocketStateChanged("SERVER_LISTEN_START")
        End If
    End Sub

    Public Sub stopListen()
        If socketType = CONNECTION_SOCKET_TYPE.SERVER Then
            listener.Stop()
            tmrServer.Enabled = False   'disable tmrServer from answering to pending connections
            SocketStateChanged("SERVER_LISTEN_STOP")
        End If
    End Sub

    Private Sub tmrServer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles tmrServer.Elapsed
        If listener.Pending = True Then
            'RaiseEvent clientPending(Me)
            'server stoped listening, to start listen again use .start again
            'Me.stopListen()
            socketTcpClient = listener.AcceptTcpClient
            socketNetworkStream = socketTcpClient.GetStream()
            SocketStateChanged("SERVER_CONNECTED")
            tmrData.Enabled = True
        End If
    End Sub

    '-------------------------------- CLIENT ---------------------------------
    Public Sub connect()
        Try
            socketTcpClient.Connect(hostAddress, socketPortNumber)
            socketNetworkStream = socketTcpClient.GetStream()
            SocketStateChanged("CLIENT_CONNECTED")
            tmrData.Enabled = True
        Catch exception1 As Exception
            SocketStateChanged(exception1.Message)
        End Try
    End Sub

    '-------------------------------- COMMON ---------------------------------
    Private Sub SocketStateChanged(ByVal iText As String)
        eventCounter += 1 : If eventCounter > 999999999 Then eventCounter = 1
        socketState = iText
        RaiseEvent stateChanged(Me)
    End Sub

    Private Sub tmrData_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles tmrData.Elapsed
        If socketNetworkStream.DataAvailable = True Then
            RaiseEvent dataAvaliable(Me)
        End If
    End Sub

    Public Sub sendString(ByVal iText As String)
        Dim sendBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(iText)
        Try
            socketNetworkStream.Write(sendBytes, 0, sendBytes.Length)
            SocketStateChanged("STRING_SEND_SUCCESS")
        Catch e As Exception
            SocketStateChanged("STRING_SEND_FAIL")
        End Try
    End Sub

    Public Function getString() As String
        Dim inBytes(IMAGE_MAX_SIZE) As Byte
        socketNetworkStream.Read(inBytes, 0, CInt(IMAGE_MAX_SIZE))
        getString = System.Text.Encoding.ASCII.GetString(inBytes)
        SocketStateChanged("STRING_RECIEVE_SUCCESS")
    End Function

    Public Sub sendImage(ByVal iImage As Image)
        Dim memStream As New System.IO.MemoryStream(IMAGE_MAX_SIZE)
        iImage.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg)
        If memStream.Position <= IMAGE_MAX_SIZE Then
            Try
                socketNetworkStream.Write(memStream.GetBuffer, 0, memStream.Position)
                SocketStateChanged("IMAGE_SEND_SUCCESS")
            Catch e As Exception
                SocketStateChanged("IMAGE_SEND_FAIL")
            End Try
        Else
            SocketStateChanged("IMAGE_SIZE_ERROR")
        End If

    End Sub

    Public Function getImage() As Image
        Dim inBytes(IMAGE_MAX_SIZE) As Byte
        socketNetworkStream.Read(inBytes, 0, CInt(socketTcpClient.ReceiveBufferSize))
        Dim memStream As New System.IO.MemoryStream(inBytes)
        getImage = Image.FromStream(memStream)
        SocketStateChanged("IMAGE_RECIEVE_SUCCESS")
    End Function

End Class
