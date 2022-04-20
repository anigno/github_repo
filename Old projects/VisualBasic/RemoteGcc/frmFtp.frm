VERSION 5.00
Begin VB.Form frmFtp 
   Caption         =   "FTP parameters"
   ClientHeight    =   1596
   ClientLeft      =   48
   ClientTop       =   336
   ClientWidth     =   5088
   Icon            =   "frmFtp.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   1596
   ScaleWidth      =   5088
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdCancel 
      Caption         =   "Cancel"
      Height          =   372
      Left            =   2040
      TabIndex        =   7
      Top             =   1200
      Width           =   972
   End
   Begin VB.CommandButton cmdSet 
      Caption         =   "Set"
      Height          =   372
      Left            =   960
      TabIndex        =   6
      Top             =   1200
      Width           =   972
   End
   Begin VB.TextBox txtPassword 
      Height          =   288
      Left            =   960
      TabIndex        =   4
      Top             =   720
      Width           =   4092
   End
   Begin VB.TextBox txtUsername 
      Height          =   288
      Left            =   960
      TabIndex        =   2
      Top             =   360
      Width           =   4092
   End
   Begin VB.TextBox txtHost 
      Height          =   288
      Left            =   960
      TabIndex        =   0
      Top             =   0
      Width           =   4092
   End
   Begin VB.Label Label3 
      Caption         =   "Password:"
      Height          =   252
      Left            =   0
      TabIndex        =   5
      Top             =   720
      Width           =   972
   End
   Begin VB.Label Label2 
      Caption         =   "User name:"
      Height          =   252
      Left            =   0
      TabIndex        =   3
      Top             =   360
      Width           =   972
   End
   Begin VB.Label Label1 
      Caption         =   "HOST:"
      Height          =   252
      Left            =   0
      TabIndex        =   1
      Top             =   0
      Width           =   972
   End
End
Attribute VB_Name = "frmFtp"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmdCancel_Click()
    Unload frmFtp
End Sub

Private Sub cmdSet_Click()
    ftpHost = txtHost.Text
    ftpUsername = txtUsername.Text
    ftpPassword = txtPassword.Text
    SaveSetting "remoteGcc", "param", "ftpHost", ftpHost
    SaveSetting "remoteGcc", "param", "ftpUsername", ftpUsername
    SaveSetting "remoteGcc", "param", "ftpPassword", ftpPassword
    Unload frmFtp
End Sub

Private Sub Form_Load()
    txtHost.Text = ftpHost
    txtUsername.Text = ftpUsername
    txtPassword.Text = ftpPassword
End Sub

Private Sub Form_Unload(Cancel As Integer)
    frmMain.Enabled = True
End Sub
