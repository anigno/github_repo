Attribute VB_Name = "mdlVars"
Option Explicit

Type snailType
    speed As Integer
    posx As Integer
    posy As Integer
    odds As Integer
    drawState As Integer
End Type

Type playerType
    name As String
    money As Long
    betMoney As Long
    betSnail As Integer
End Type

Public snail(6) As snailType
Public player(4) As playerType
Public gameState As Integer
Public playerCoin As Integer
Public SnailWinner As Integer
