VERSION 5.00
Begin VB.Form frmSelectDir 
   Caption         =   "Select Dir"
   ClientHeight    =   3840
   ClientLeft      =   48
   ClientTop       =   336
   ClientWidth     =   3024
   Icon            =   "frmSelectDir.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   3840
   ScaleWidth      =   3024
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdCancel 
      Caption         =   "Cancel"
      Height          =   372
      Left            =   2040
      TabIndex        =   3
      Top             =   3480
      Width           =   972
   End
   Begin VB.CommandButton cmdSelect 
      Caption         =   "Select"
      Height          =   372
      Left            =   0
      TabIndex        =   2
      Top             =   3480
      Width           =   972
   End
   Begin VB.DirListBox Dir1 
      Height          =   3096
      Left            =   0
      TabIndex        =   1
      Top             =   360
      Width           =   3012
   End
   Begin VB.DriveListBox Drive1 
      Height          =   288
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   3012
   End
End
Attribute VB_Name = "frmSelectDir"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdCancel_Click()
    Unload frmSelectDir
End Sub

Private Sub cmdSelect_Click()
    frmMain.File1.Path = Dir1.List(Dir1.ListIndex)
    frmMain.RTF1.Text = ""
    frmMain.lblPath.Caption = frmMain.File1.Path
    SaveSetting "remoteGcc", "param", "projectDir", frmMain.File1.Path
    setCurrentFile frmMain, "no file"
    Unload frmSelectDir
End Sub

Private Sub Drive1_Change()
    On Error Resume Next
    Dir1.Path = Drive1.Drive
End Sub

Private Sub Form_Unload(Cancel As Integer)
    frmMain.Enabled = True
End Sub
