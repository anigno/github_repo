VERSION 5.00
Begin VB.Form frmLoader 
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   360
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   3540
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   360
   ScaleWidth      =   3540
   ShowInTaskbar   =   0   'False
   Begin VB.Timer tmrLoader 
      Interval        =   1000
      Left            =   120
      Top             =   480
   End
   Begin VB.Label Label1 
      Caption         =   "Next update"
      Height          =   252
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   3372
   End
End
Attribute VB_Name = "frmLoader"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim s As Integer
Dim m As Integer
Dim X As Object

Private Sub tmrLoader_Timer()
    s = s + 1
    Label1.Caption = s
    If s > 59 Then
        s = 0
        m = m + 1
    End If
    If s = 1 Then
        Set X = New frmMain
        X.Show
        X.Left = 0
        X.Top = 400
    End If
    If s = 20 Then
        Unload X
        s = 0
    End If
        
End Sub

Private Sub MDIForm_Load()

End Sub

