VERSION 5.00
Object = "{48E59290-9880-11CF-9754-00AA00C00908}#1.0#0"; "MSINET.OCX"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   6720
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   7488
   LinkTopic       =   "Form1"
   ScaleHeight     =   6720
   ScaleWidth      =   7488
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "Command2"
      Height          =   492
      Left            =   5880
      TabIndex        =   3
      Top             =   3600
      Width           =   1092
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   492
      Left            =   5760
      TabIndex        =   2
      Top             =   1560
      Width           =   1092
   End
   Begin VB.Timer Timer1 
      Interval        =   1000
      Left            =   6720
      Top             =   120
   End
   Begin VB.ListBox List1 
      Height          =   6192
      Left            =   2400
      TabIndex        =   0
      Top             =   120
      Width           =   2652
   End
   Begin InetCtlsObjects.Inet Inet1 
      Left            =   6720
      Top             =   2520
      _ExtentX        =   804
      _ExtentY        =   804
      _Version        =   393216
      Protocol        =   2
      RemoteHost      =   "members.truepath.com"
      RemotePort      =   21
      URL             =   "ftp://anigno2:h7xmiz@members.truepath.com"
      UserName        =   "anigno2"
      Password        =   "h7xmiz"
      RequestTimeout  =   10
   End
   Begin VB.Label Label1 
      Caption         =   "Label1"
      Height          =   372
      Left            =   6480
      TabIndex        =   1
      Top             =   720
      Width           =   732
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim a As Integer

Private Sub Command1_Click()
    Inet1.Execute , "put c:\cam1.jpg /cam1.jpg"
End Sub

Private Sub Command2_Click()
    Inet1.Execute "close"
    End
End Sub

Private Sub Inet1_StateChanged(ByVal State As Integer)
    List1.AddItem State & " " & Inet1.ResponseCode & " " & Inet1.ResponseInfo, 0
End Sub

Private Sub Timer1_Timer()
    a = a + 1
    Label1.Caption = a
End Sub
