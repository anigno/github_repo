Attribute VB_Name = "mdlMain"
Option Explicit
Global Odds(0 To 5) As Integer
Type PlayerData
     Name As String
     SnailBet As Integer
     MoneyBet As Integer
     MoneyLeft As Integer
End Type
Global Player(0 To 9) As PlayerData
Global RaceWinner As Integer

