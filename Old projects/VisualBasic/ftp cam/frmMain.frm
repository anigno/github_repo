VERSION 5.00
Object = "{48E59290-9880-11CF-9754-00AA00C00908}#1.0#0"; "MSINET.OCX"
Object = "{DF6D6558-5B0C-11D3-9396-008029E9B3A6}#1.0#0"; "ezVidC60.ocx"
Object = "{E5CEE37F-8CF8-489E-BFA0-8201CBD6AEE8}#1.0#0"; "PicFormat32.ocx"
Begin VB.Form frmMain 
   Caption         =   "webCam Ftp"
   ClientHeight    =   3132
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   6468
   LinkTopic       =   "Form1"
   ScaleHeight     =   261
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   539
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdOpenUrl 
      Caption         =   "Open Url"
      Height          =   252
      Left            =   600
      TabIndex        =   5
      Top             =   2040
      Width           =   1212
   End
   Begin VB.ListBox List1 
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3072
      Left            =   4560
      TabIndex        =   3
      Top             =   0
      Width           =   612
   End
   Begin VB.PictureBox Picture1 
      Height          =   1812
      Left            =   2280
      ScaleHeight     =   1764
      ScaleWidth      =   2124
      TabIndex        =   2
      Top             =   0
      Width           =   2172
   End
   Begin VB.Timer tmrRun 
      Interval        =   1000
      Left            =   5520
      Top             =   120
   End
   Begin PicFormat32a.PicFormat32 PicFormat321 
      Height          =   252
      Left            =   5520
      TabIndex        =   1
      Top             =   1320
      Visible         =   0   'False
      Width           =   252
      _ExtentX        =   445
      _ExtentY        =   445
   End
   Begin vbVidC60.ezVidCap cam1 
      Height          =   1728
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   2112
      _ExtentX        =   3725
      _ExtentY        =   3048
   End
   Begin InetCtlsObjects.Inet Inet1 
      Left            =   5520
      Top             =   600
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
      AutoSize        =   -1  'True
      Caption         =   "00"
      Height          =   192
      Left            =   4200
      TabIndex        =   4
      Top             =   1920
      Width           =   168
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim sendToFtp As Integer

Private Sub cmdOpenUrl_Click()
    Shell "explorer http://members.truepath.com/anigno2/"
End Sub

Private Sub Form_Load()
    Shell "regsvr32 " & App.Path & "\PicFormat32.dll /s"
    sendToFtp = 0
End Sub

Private Sub Inet1_StateChanged(ByVal State As Integer)
    List1.AddItem State, 0
    If State = 11 Then sendToFtp = 0
End Sub

Private Sub tmrRun_Timer()
    On Error Resume Next
    sendToFtp = sendToFtp - 1
    Label1.Caption = sendToFtp
    If sendToFtp < 1 Then
        cam1.EditCopy
        Picture1.Picture = Clipboard.GetData
        SavePicture Picture1.Image, "c:/cam1.bmp"
        PicFormat321.SaveBmpToJpeg "c:/cam1.bmp", "c:/cam1.jpg", 30
        sendToFtp = 10
        Inet1.Execute , "PUT c:\cam1.jpg /cam1.jpg"
    End If
    If List1.ListCount > 1000 Then List1.Clear
End Sub
