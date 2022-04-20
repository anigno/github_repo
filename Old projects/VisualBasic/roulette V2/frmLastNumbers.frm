VERSION 5.00
Begin VB.Form frmLastNumbers 
   BackColor       =   &H00404000&
   BorderStyle     =   0  'None
   ClientHeight    =   2388
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   984
   Icon            =   "frmLastNumbers.frx":0000
   LinkTopic       =   "Form1"
   MDIChild        =   -1  'True
   ScaleHeight     =   2388
   ScaleWidth      =   984
   ShowInTaskbar   =   0   'False
   Begin VB.ListBox lstBlack 
      Appearance      =   0  'Flat
      BackColor       =   &H0000C000&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   2184
      ItemData        =   "frmLastNumbers.frx":0442
      Left            =   480
      List            =   "frmLastNumbers.frx":0449
      TabIndex        =   1
      Top             =   120
      Width           =   372
   End
   Begin VB.ListBox lstRed 
      Appearance      =   0  'Flat
      BackColor       =   &H0000C000&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   2184
      ItemData        =   "frmLastNumbers.frx":0451
      Left            =   120
      List            =   "frmLastNumbers.frx":0458
      TabIndex        =   0
      Top             =   120
      Width           =   372
   End
End
Attribute VB_Name = "frmLastNumbers"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()
    frmLastNumbers.Left = MDIForm1.Width - frmLastNumbers.Width - 100
    frmLastNumbers.Top = 0
End Sub
