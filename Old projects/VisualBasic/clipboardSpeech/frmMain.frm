VERSION 5.00
Object = "{EEE78583-FE22-11D0-8BEF-0060081841DE}#1.0#0"; "XVoice.dll"
Begin VB.Form frmMain 
   Caption         =   "clipBoard Speech"
   ClientHeight    =   1176
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   3180
   LinkTopic       =   "Form1"
   ScaleHeight     =   1176
   ScaleWidth      =   3180
   StartUpPosition =   3  'Windows Default
   Begin VB.CheckBox chkCheckClipboard 
      Caption         =   "Check clipboard"
      Height          =   252
      Left            =   1320
      TabIndex        =   3
      Top             =   120
      Width           =   1572
   End
   Begin VB.Timer tmrCheckClipboard 
      Interval        =   1000
      Left            =   2760
      Top             =   0
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Height          =   252
      Left            =   600
      TabIndex        =   2
      Top             =   120
      Width           =   612
   End
   Begin VB.TextBox txtSpeech 
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   612
      Left            =   0
      TabIndex        =   1
      Top             =   480
      Width           =   3132
   End
   Begin ACTIVEVOICEPROJECTLibCtl.DirectSS DirectSS1 
      Height          =   492
      Left            =   0
      OleObjectBlob   =   "frmMain.frx":0000
      TabIndex        =   0
      Top             =   0
      Width           =   612
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub tmrCheckClipboard_Timer()
    On Error Resume Next
    'If Clipboard.GetFormat(vbCFText) = True Then
        txtSpeech.Text = Clipboard.GetData
        DirectSS1.Speak txtSpeech.Text
        Clipboard.Clear
    'End If
    
End Sub
