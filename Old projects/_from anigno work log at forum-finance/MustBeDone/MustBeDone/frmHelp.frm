VERSION 5.00
Begin VB.Form frmHelp 
   Caption         =   "MustBeDone"
   ClientHeight    =   3360
   ClientLeft      =   48
   ClientTop       =   276
   ClientWidth     =   4212
   Icon            =   "frmHelp.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   3360
   ScaleWidth      =   4212
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton Command1 
      BackColor       =   &H00808080&
      Height          =   252
      Index           =   3
      Left            =   240
      Style           =   1  'Graphical
      TabIndex        =   4
      Top             =   600
      Width           =   252
   End
   Begin VB.CommandButton Command1 
      BackColor       =   &H000000FF&
      Height          =   252
      Index           =   2
      Left            =   240
      Style           =   1  'Graphical
      TabIndex        =   3
      Top             =   1080
      Width           =   252
   End
   Begin VB.CommandButton Command1 
      BackColor       =   &H000080FF&
      Height          =   252
      Index           =   1
      Left            =   240
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   1680
      Width           =   252
   End
   Begin VB.CommandButton Command1 
      BackColor       =   &H00C0C0C0&
      Height          =   252
      Index           =   0
      Left            =   240
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   240
      Width           =   252
   End
   Begin VB.CommandButton ExitHelp 
      Caption         =   "EXIT"
      Height          =   252
      Left            =   120
      TabIndex        =   0
      Top             =   2880
      Width           =   492
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      Caption         =   "סימון ליום עם הודעה מיוחדת - סימן @ מופיע בתיבת הודעה מסויימת"
      Height          =   612
      Index           =   2
      Left            =   600
      TabIndex        =   8
      Top             =   1680
      Width           =   3252
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      Caption         =   "סימון ליום עם הודעה קריטית - סימן ! מופיע בתיבת הודעה מסויימת"
      Height          =   372
      Index           =   3
      Left            =   720
      TabIndex        =   7
      Top             =   1080
      Width           =   2892
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      Caption         =   "סימון ליום עם הודעות"
      Height          =   252
      Index           =   1
      Left            =   720
      TabIndex        =   6
      Top             =   600
      Width           =   2172
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      Caption         =   "סימון ליום פנוי, ללא הודעות"
      Height          =   252
      Index           =   0
      Left            =   720
      TabIndex        =   5
      Top             =   240
      Width           =   2172
   End
End
Attribute VB_Name = "frmHelp"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub ExitHelp_Click()
    Unload frmHelp
End Sub
Private Sub Form_Load()
    frmMain.Enabled = False
End Sub
Private Sub Form_Unload(Cancel As Integer)
    frmMain.Enabled = True
    Unload frmHelp
End Sub

