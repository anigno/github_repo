VERSION 5.00
Begin VB.MDIForm MDIForm1 
   BackColor       =   &H8000000C&
   Caption         =   "ROULETTE V2"
   ClientHeight    =   6984
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   9000
   Icon            =   "MDIForm1.frx":0000
   LinkTopic       =   "MDIForm1"
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
End
Attribute VB_Name = "MDIForm1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub MDIForm_Load()
    frmStart.Show
End Sub

Private Sub MDIForm_Unload(Cancel As Integer)
    Dim a
    For a = 0 To nextPlayer - 1
        Unload frmPlayer(a)
    Next a
End Sub
