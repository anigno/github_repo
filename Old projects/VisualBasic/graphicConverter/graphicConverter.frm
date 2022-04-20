VERSION 5.00
Object = "{E5CEE37F-8CF8-489E-BFA0-8201CBD6AEE8}#1.0#0"; "PicFormat32.ocx"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   2544
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   3744
   LinkTopic       =   "Form1"
   ScaleHeight     =   2544
   ScaleWidth      =   3744
   StartUpPosition =   3  'Windows Default
   Begin PicFormat32a.PicFormat32 PicFormat321 
      Height          =   252
      Left            =   1800
      TabIndex        =   1
      Top             =   1200
      Width           =   252
      _ExtentX        =   445
      _ExtentY        =   445
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   372
      Left            =   840
      TabIndex        =   0
      Top             =   240
      Width           =   972
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
    PicFormat321.SaveBmpToGif "c:\cam1.bmp", "c:\cam1.gif"
    PicFormat321.SaveBmpToJpeg "c:\cam1.bmp", "c:\cam1.jpg", 60
End Sub

Private Sub Form_Load()
    Shell "regsvr32 " & App.Path & "\PicFormat32.dll /s"
End Sub
