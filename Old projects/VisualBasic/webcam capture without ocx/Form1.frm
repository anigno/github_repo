VERSION 5.00
Object = "{84926CA3-2941-101C-816F-0E6013114B7F}#1.0#0"; "ImgScan.ocx"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   5124
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   7068
   LinkTopic       =   "Form1"
   ScaleHeight     =   5124
   ScaleWidth      =   7068
   StartUpPosition =   3  'Windows Default
   Begin ScanLibCtl.ImgScan ImgScan1 
      Left            =   120
      Top             =   120
      _Version        =   65536
      _ExtentX        =   656
      _ExtentY        =   656
      _StockProps     =   0
      FileType        =   6
      PageType        =   3
      CompressionType =   6
      CompressionInfo =   1024
   End
   Begin VB.PictureBox Picture1 
      Height          =   2172
      Left            =   840
      ScaleHeight     =   2124
      ScaleWidth      =   2604
      TabIndex        =   1
      Top             =   1680
      Width           =   2652
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   372
      Left            =   1560
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
    ImgScan1.FileType = JPG_File
    ImgScan1.Image = "c:\1.jpg"
    ImgScan1.StartScan
    ImgScan1.CloseScanner
    
End Sub

