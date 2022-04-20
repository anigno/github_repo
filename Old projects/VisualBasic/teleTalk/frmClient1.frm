VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Begin VB.Form frmClient1 
   Caption         =   "client1"
   ClientHeight    =   2436
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   6096
   LinkTopic       =   "Form1"
   ScaleHeight     =   2436
   ScaleWidth      =   6096
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   6360
      Top             =   480
   End
   Begin VB.TextBox txtOutput 
      Height          =   372
      Left            =   0
      TabIndex        =   3
      Top             =   360
      Width           =   2772
   End
   Begin VB.TextBox txtSendData 
      Height          =   372
      Left            =   0
      TabIndex        =   2
      Top             =   0
      Width           =   2772
   End
   Begin VB.CommandButton cmdConnect 
      Caption         =   "connect"
      Height          =   372
      Left            =   0
      TabIndex        =   1
      Top             =   960
      Width           =   972
   End
   Begin VB.TextBox Text1 
      Height          =   372
      Left            =   5280
      TabIndex        =   0
      Text            =   "Text1"
      Top             =   120
      Width           =   972
   End
   Begin RichTextLib.RichTextBox RichTextBox1 
      Height          =   2292
      Left            =   2880
      TabIndex        =   4
      Top             =   0
      Width           =   1692
      _ExtentX        =   2985
      _ExtentY        =   4043
      _Version        =   393217
      TextRTF         =   $"frmClient1.frx":0000
   End
   Begin MSWinsockLib.Winsock tcpClient 
      Left            =   6360
      Top             =   120
      _ExtentX        =   593
      _ExtentY        =   593
      _Version        =   393216
   End
End
Attribute VB_Name = "frmClient1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()
' The name of the Winsock control is tcpClient.
' Note: to specify a remote host, you can use
' either the IP address (ex: "121.111.1.1") or
' the computer's "friendly" name, as shown here.
tcpClient.RemoteHost = "work"
tcpClient.RemotePort = 1001
End Sub

Private Sub cmdConnect_Click()
' Invoke the Connect method to initiate a
' connection.
tcpClient.Connect
End Sub

Private Sub txtSendData_Change()
tcpClient.SendData txtSendData.Text
End Sub

Private Sub tcpClient_DataArrival _
(ByVal bytesTotal As Long)
Dim strData As String
tcpClient.GetData strData
txtOutput.Text = strData
End Sub


Private Sub Timer1_Timer()
    Text1.Text = tcpClient.State
End Sub



