Imports System
Imports System.Runtime.InteropServices
Module Module1

    Declare Function EnumWindows Lib "user32" ( _
        ByVal x As CallBack, ByVal y As Integer) As Integer
    Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" ( _
        ByVal hwnd As Long, ByVal lpString As String, ByVal cch As Long) As Long
    Public Declare Auto Function IsWindowVisible Lib "user32" Alias "IsWindowVisible" ( _
        ByVal hwnd As Integer) As Integer

    'deligate function prototype, must be same as callback function
    Public Delegate Function CallBack( _
    ByVal hwnd As Integer, ByVal lParam As Integer) As Boolean



End Module
