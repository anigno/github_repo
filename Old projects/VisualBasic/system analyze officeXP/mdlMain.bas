Attribute VB_Name = "mdlMain"
Option Explicit

Public marketOpenValue As Double
Public marketCloseValue As Double
Public marketHighValue As Double
Public marketLowValue As Double
Public marketSystemCall As String


Public Function getNextPos(sString As String, sFind As String, fromPos As Long) As Long
    On Error Resume Next
    getNextPos = InStr(fromPos, sString, sFind)
End Function

Public Function getNextNpos(sString As String, sFind As String, fromPos As Long, N As Integer) As Long
    Dim a As Integer
    Dim b As Long
    For a = 1 To N
        b = getNextPos(sString, sFind, fromPos)
        fromPos = b + 1
    Next a
    getNextNpos = b
End Function
