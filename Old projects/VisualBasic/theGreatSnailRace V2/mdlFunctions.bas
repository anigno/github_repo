Attribute VB_Name = "mdlFunctions"
Option Explicit

Public Sub initSnails()
    Dim a As Integer
    For a = 0 To 5
        snail(a).posx = 600
        snail(a).drawState = 0
    Next a
End Sub
Public Sub initSnailDetails()
    Dim a As Integer
    For a = 0 To 5
        snail(a).speed = Int(Rnd * 6) + 5
        snail(a).odds = 11 - snail(a).speed
    Next a
End Sub

Public Sub initPlayers()
    Dim a As Integer
    For a = 0 To 3
        player(a).betMoney = 0
        player(a).betSnail = 99
    Next a
End Sub

Public Sub initGame()
    Dim a As Integer
    For a = 0 To 3
        player(a).money = 50
    Next a
    playerCoin = 1
End Sub

Public Sub showSnailsDetails()
    Dim a As Integer
    frmMain.frameSnailDetails.Visible = True
    For a = 0 To 5
        frmMain.imgSnail(a + 6).Left = 120
        frmMain.imgSnail(a + 6).Width = Int(1836 / 9 * snail(a).speed)
        DoEvents
        frmMain.lblSpeed(a + 6).Caption = snail(a).speed
        frmMain.lblOdds(a + 6).Caption = snail(a).odds
        frmMain.List1.AddItem a + 6 & " " & frmMain.imgSnail(a + 6).Width
    Next a
End Sub

Public Sub checkWinner(w As Integer)
    Dim a As Integer
    For a = 0 To 3
        If player(a).betSnail = w Then
            player(a).money = player(a).money + player(a).betMoney * snail(w).odds
        End If
    Next a
End Sub

