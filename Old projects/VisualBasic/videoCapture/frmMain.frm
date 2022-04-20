VERSION 5.00
Object = "{DF6D6558-5B0C-11D3-9396-008029E9B3A6}#1.0#0"; "ezVidC60.ocx"
Begin VB.Form frmMain 
   Caption         =   "capture"
   ClientHeight    =   3132
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   6468
   LinkTopic       =   "Form1"
   ScaleHeight     =   261
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   539
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "stop"
      Height          =   372
      Left            =   2400
      TabIndex        =   2
      Top             =   600
      Width           =   1092
   End
   Begin VB.CommandButton Command1 
      Caption         =   "start"
      Height          =   372
      Left            =   2400
      TabIndex        =   1
      Top             =   120
      Width           =   1092
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
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
    cam1.CaptureVideo
End Sub

Private Sub Command2_Click()
    cam1.CaptureEnd
End Sub

Private Sub Form_Load()
    cam1.CaptureFile = "c:\capture01.avi"
    cam1.CaptureRate = 4
    cam1.CaptureViaBackgroundThread = True
End Sub
