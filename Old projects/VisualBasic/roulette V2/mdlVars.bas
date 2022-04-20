Attribute VB_Name = "mdlVars"
Option Explicit

Public rouletteNumber As Integer
Public rolAnim As Integer
Public Const maxPlayers = 6
Public nextPlayer As Integer
Public frmPlayer(60) As Object    ' Create a playerBoard object
Public frmPlayerStatus(60) As Integer
Public canRunBets As Boolean
Public playerIsOn(60) As Boolean
