VERSION 5.00
Begin VB.Form frmStart 
   Appearance      =   0  'Flat
   BackColor       =   &H80000005&
   BorderStyle     =   0  'None
   ClientHeight    =   5736
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   7668
   Icon            =   "frmStart.frx":0000
   LinkTopic       =   "Form1"
   MDIChild        =   -1  'True
   Picture         =   "frmStart.frx":0442
   ScaleHeight     =   5736
   ScaleWidth      =   7668
   ShowInTaskbar   =   0   'False
   Begin VB.Timer tmrStart 
      Interval        =   4000
      Left            =   0
      Top             =   0
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "עבור ממן יוסי"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000C0&
      Height          =   372
      Left            =   120
      TabIndex        =   2
      Top             =   5280
      Width           =   1812
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "by ANIGNORA"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000C0&
      Height          =   372
      Left            =   5400
      TabIndex        =   1
      Top             =   5280
      Width           =   2172
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "ROULETTE V1"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   24
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   612
      Left            =   120
      TabIndex        =   0
      Top             =   0
      Width           =   3492
   End
End
Attribute VB_Name = "frmStart"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()
    frmStart.Left = Screen.Width / 2 - frmStart.Width / 2
    frmStart.Top = Screen.Height / 2 - frmStart.Height / 2
End Sub

Private Sub tmrStart_Timer()
    frmControl.Show
    Unload frmStart
End Sub
