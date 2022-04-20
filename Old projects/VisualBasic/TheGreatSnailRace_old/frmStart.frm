VERSION 5.00
Object = "{05589FA0-C356-11CE-BF01-00AA0055595A}#2.0#0"; "amovie.ocx"
Begin VB.Form frmStart 
   BorderStyle     =   0  'None
   Caption         =   "frmStart"
   ClientHeight    =   5376
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   7248
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5376
   ScaleWidth      =   7248
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.Timer Timer1 
      Interval        =   16500
      Left            =   6720
      Top             =   240
   End
   Begin AMovieCtl.ActiveMovie ActiveMovie1 
      Height          =   5424
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   7248
      _ExtentX        =   12785
      _ExtentY        =   9567
      ShowDisplay     =   0   'False
      ShowControls    =   0   'False
      EnablePositionControls=   0   'False
      EnableSelectionControls=   0   'False
      ShowTracker     =   0   'False
      EnableTracker   =   0   'False
      AllowHideDisplay=   0   'False
      AllowHideControls=   0   'False
      AutoStart       =   -1  'True
      AutoRewind      =   0   'False
      Appearance      =   0
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\BudgitaOpen.avi"
   End
End
Attribute VB_Name = "frmStart"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Timer1_Timer()
    frmMain.Visible = True
    Unload frmStart
End Sub
