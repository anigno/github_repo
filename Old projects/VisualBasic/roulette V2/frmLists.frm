VERSION 5.00
Begin VB.Form frmLists 
   BackColor       =   &H00004000&
   BorderStyle     =   1  'Fixed Single
   ClientHeight    =   3396
   ClientLeft      =   36
   ClientTop       =   276
   ClientWidth     =   5796
   Icon            =   "frmLists.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   3396
   ScaleWidth      =   5796
   Begin VB.CommandButton cmdClose 
      BackColor       =   &H00808000&
      Caption         =   "סגור"
      Height          =   252
      Left            =   0
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   0
      Width           =   732
   End
   Begin VB.ListBox List1 
      BackColor       =   &H00008000&
      ForeColor       =   &H0000FFFF&
      Height          =   3120
      ItemData        =   "frmLists.frx":0442
      Left            =   0
      List            =   "frmLists.frx":0444
      TabIndex        =   0
      Top             =   240
      Width           =   5772
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      BackStyle       =   0  'Transparent
      Caption         =   "הודעות"
      BeginProperty Font 
         Name            =   "David Transparent"
         Size            =   10.2
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   252
      Left            =   1920
      TabIndex        =   1
      Top             =   0
      Width           =   1452
   End
End
Attribute VB_Name = "frmLists"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdClose_Click()
    frmLists.Visible = False
End Sub

Private Sub Form_Load()
    frmLists.Top = frmLastNumbers.Height
    frmLists.Left = MDIForm1.Width - frmLists.Width
End Sub
