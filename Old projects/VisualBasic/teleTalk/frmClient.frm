VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Begin VB.Form frmClient 
   Caption         =   "client"
   ClientHeight    =   4392
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   7668
   LinkTopic       =   "Form1"
   ScaleHeight     =   4392
   ScaleWidth      =   7668
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox txtHostData 
      Height          =   288
      Left            =   3480
      TabIndex        =   4
      Top             =   120
      Width           =   2652
   End
   Begin VB.ListBox lstMessages 
      Height          =   3120
      Left            =   240
      TabIndex        =   3
      Top             =   960
      Width           =   4812
   End
   Begin MSWinsockLib.Winsock clienSock 
      Left            =   6720
      Top             =   0
      _ExtentX        =   593
      _ExtentY        =   593
      _Version        =   393216
      RemoteHost      =   "work"
      RemotePort      =   1001
   End
   Begin VB.Timer tmrRun 
      Interval        =   1000
      Left            =   7200
      Top             =   0
   End
   Begin VB.TextBox txtState 
      Height          =   288
      Left            =   5880
      TabIndex        =   1
      Top             =   1680
      Width           =   1692
   End
   Begin VB.CommandButton cmdConnect 
      Caption         =   "connect"
      Height          =   372
      Left            =   240
      TabIndex        =   0
      Top             =   360
      Width           =   972
   End
   Begin RichTextLib.RichTextBox RichTextBox1 
      Height          =   2292
      Left            =   5880
      TabIndex        =   2
      Top             =   2040
      Width           =   1692
      _ExtentX        =   2985
      _ExtentY        =   4043
      _Version        =   393217
      Enabled         =   -1  'True
      TextRTF         =   $"frmClient.frx":0000
   End
End
Attribute VB_Name = "frmClient"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim clientState As Integer
Dim strData As String
Dim portNumber As Integer
Dim T As Integer

Private Sub clienSock_DataArrival(ByVal bytesTotal As Long)
    clienSock.GetData strData, vbString
    'checking for port number arrival
    If Left(strData, 13) = "newportnumber" Then
        lstMessages.AddItem "recive: " & strData
        portNumber = Val(Mid(strData, 14))
        clienSock.Close
        clientState = 1
    End If
    txtHostData.Text = "host sent: " & strData
End Sub

Private Sub cmdConnect_Click()
    clienSock.Connect
    lstMessages.AddItem "connecting with port " & clienSock.LocalPort & " to port 1001"
End Sub

Private Sub Form_Load()
    clienSock.LocalPort = 0
    clienSock.RemoteHost = "work"
    clienSock.RemotePort = 1001
    clientState = 0
End Sub

Private Sub Form_Unload(Cancel As Integer)
    clienSock.Close
End Sub

Private Sub tmrRun_Timer()
    T = T + 1
    Select Case clientState
        Case 2
            'sending data to new port
            clienSock.SendData Str(T)
        Case 1
            'connecting to new port
            clienSock.RemotePort = portNumber
            clienSock.Connect
            clientState = 2
        Case 0
            'waiting for connection on 1001 and new port recived
    End Select
End Sub
