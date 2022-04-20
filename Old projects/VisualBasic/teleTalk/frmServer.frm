VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Object = "{5E9E78A0-531B-11CF-91F6-C2863C385E30}#1.0#0"; "MSFLXGRD.OCX"
Begin VB.Form frmServer 
   Caption         =   "server"
   ClientHeight    =   5208
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   7704
   LinkTopic       =   "Form1"
   ScaleHeight     =   5208
   ScaleWidth      =   7704
   StartUpPosition =   3  'Windows Default
   Begin MSFlexGridLib.MSFlexGrid MSFlexGrid1 
      Height          =   3252
      Left            =   3000
      TabIndex        =   7
      Top             =   960
      Width           =   2052
      _ExtentX        =   3620
      _ExtentY        =   5736
      _Version        =   393216
      Rows            =   1
      FixedRows       =   0
      FixedCols       =   0
   End
   Begin VB.CommandButton cmdNewClient 
      Caption         =   "new client"
      Height          =   372
      Left            =   3120
      TabIndex        =   6
      Top             =   240
      Width           =   972
   End
   Begin VB.ListBox lstMessage 
      Height          =   4656
      Left            =   120
      TabIndex        =   5
      Top             =   240
      Width           =   2772
   End
   Begin VB.TextBox txtClientSock 
      Height          =   288
      Left            =   6960
      TabIndex        =   2
      Top             =   2160
      Width           =   492
   End
   Begin VB.TextBox txtMainSock 
      Height          =   288
      Left            =   6960
      TabIndex        =   1
      Top             =   2520
      Width           =   492
   End
   Begin VB.Timer tmrRun 
      Interval        =   1000
      Left            =   6240
      Top             =   480
   End
   Begin MSWinsockLib.Winsock clientSock 
      Index           =   0
      Left            =   5760
      Top             =   0
      _ExtentX        =   593
      _ExtentY        =   593
      _Version        =   393216
      LocalPort       =   1002
   End
   Begin MSWinsockLib.Winsock mainSock 
      Left            =   6240
      Top             =   0
      _ExtentX        =   593
      _ExtentY        =   593
      _Version        =   393216
      LocalPort       =   1001
   End
   Begin RichTextLib.RichTextBox RichTextBox1 
      Height          =   2292
      Left            =   5880
      TabIndex        =   0
      Top             =   2880
      Width           =   1692
      _ExtentX        =   2985
      _ExtentY        =   4043
      _Version        =   393217
      Enabled         =   -1  'True
      TextRTF         =   $"frmServer.frx":0000
   End
   Begin VB.Label Label2 
      Caption         =   "client"
      Height          =   252
      Left            =   6480
      TabIndex        =   4
      Top             =   2160
      Width           =   492
   End
   Begin VB.Label Label1 
      Caption         =   "main sock"
      Height          =   252
      Left            =   6120
      TabIndex        =   3
      Top             =   2520
      Width           =   852
   End
End
Attribute VB_Name = "frmServer"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim strData As String
Dim T As Integer

Private Sub clientSock_ConnectionRequest(Index As Integer, ByVal requestID As Long)
    If clientSock(Index).State <> sckClosed Then clientSock(Index).Close
    clientSock(Index).Accept requestID
    lstMessage.AddItem "sock(" & Index & ") accept"
End Sub

Private Sub clientSock_DataArrival(Index As Integer, ByVal bytesTotal As Long)
    clientSock(Index).GetData strData, vbString
    MSFlexGrid1.Row = Index
    MSFlexGrid1.Col = 0
    MSFlexGrid1.Text = Index
    MSFlexGrid1.Col = 1
    MSFlexGrid1.Text = strData
    clientSock(Index).SendData Str(T)
End Sub

Private Sub cmdNewClient_Click()
    Dim a
    Set a = New frmClient
    a.Show
End Sub

Private Sub Form_Load()
    nextPort = 1002
    nextSock = 1
    serverState = 0
End Sub

Private Sub Form_Unload(Cancel As Integer)
    End
End Sub

Private Sub mainSock_ConnectionRequest(ByVal requestID As Long)
    'accept connection
    If mainSock.State <> sckClosed Then mainSock.Close
    mainSock.Accept requestID
    lstMessage.AddItem "accept " & requestID
    serverState = 2
End Sub

Private Sub tmrRun_Timer()
T = T + 1
Select Case serverState
    Case 0
        'server sets and start listen on port 1001
        mainSock.LocalPort = 1001
        sockListen mainSock
        serverState = 1
        lstMessage.AddItem "mainSock listen to port 1001"
    Case 1
        'server is waiting on port 1001
        'will move to serverState=2 at connectionRequest
    Case 2
        'open new sock and listen to new port
        Load clientSock(nextSock)
        MSFlexGrid1.Rows = MSFlexGrid1.Rows + 1
        clientSock(nextSock).LocalPort = nextPort
        sockListen clientSock(nextSock)
        lstMessage.AddItem "sock(" & nextSock & ") listen to port " & nextPort
        'send port number to client
        mainSock.SendData Trim("newportnumber" & Trim(Str(nextPort)))
        serverState = 3
    Case 3
        'close mainSock
        mainSock.Close
        lstMessage.AddItem "mainsock closed"
        serverState = 4
    Case 4
        'inc nextPort and nextSock for next client
        nextPort = nextPort + 1
        nextSock = nextSock + 1
        serverState = 0
    Case Else
        MsgBox "Error in server!", vbCritical
End Select
txtMainSock.Text = mainSock.State
End Sub
