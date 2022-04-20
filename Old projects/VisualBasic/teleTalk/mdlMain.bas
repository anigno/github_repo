Attribute VB_Name = "mdlMain"
Option Explicit

Public nextPort As Integer
Public nextSock As Integer
Public serverState As Integer

Public Sub sockListen(iSock As Winsock)
    If iSock.State <> sckClosed Then iSock.Close
    iSock.Listen
End Sub
