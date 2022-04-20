VERSION 5.00
Begin VB.Form frmControl 
   BackColor       =   &H00004000&
   BorderStyle     =   0  'None
   Caption         =   "control"
   ClientHeight    =   576
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   1404
   Icon            =   "frmControl.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   576
   ScaleWidth      =   1404
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton cmdAddPlayer 
      BackColor       =   &H00808000&
      Caption         =   "הוסף שחקן"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   372
      Left            =   120
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   120
      Width           =   1212
   End
End
Attribute VB_Name = "frmControl"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmdAddPlayer_Click()
    'will make new player frmPlayer() from frmMain
    Set frmPlayer(nextPlayer) = New frmMain    ' Create valid object reference.
    'will set the playerIsOn flag = true
    playerIsOn(nextPlayer) = True
    frmPlayer(nextPlayer).Show
    nextPlayer = nextPlayer + 1
End Sub

Private Sub Form_Load()
    frmControl.Left = 0
    frmControl.Top = 0
End Sub
