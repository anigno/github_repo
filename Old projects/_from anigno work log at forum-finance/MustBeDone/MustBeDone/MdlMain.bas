Attribute VB_Name = "MdlMain"
Option Explicit

' User current values
Public TheDay As Integer
Public TheMonth As Integer
Public TheYear As Integer
Public FirstDay As Integer
Public LastDay As Integer
'Array values
Public Memo(31, 9) As String           '(1 - 31,0 - 5)
Public MemoDone(31, 9) As Integer      '(1 - 31,0 - 5)
Public Action(31, 17) As String        '(1 - 31,0 - 17)

Public MaxDays(12) As Integer
Public DayName(7) As String





