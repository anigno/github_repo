VERSION 4.00
Begin VB.Form src29 
   Caption         =   "src29 - Click to See Windows & System Paths"
   ClientHeight    =   3270
   ClientLeft      =   1140
   ClientTop       =   1515
   ClientWidth     =   5970
   Height          =   3675
   Left            =   1080
   LinkTopic       =   "Form1"
   ScaleHeight     =   3270
   ScaleWidth      =   5970
   Top             =   1170
   Width           =   6090
End
Attribute VB_Name = "src29"
Attribute VB_Creatable = False
Attribute VB_Exposed = False
Option Explicit

Private Declare Function GetWindowsDirectory Lib "kernel32" Alias "GetWindowsDirectoryA" (ByVal lpBuffer As String, ByVal nSize As Long) As Long
Private Declare Function GetSystemDirectory Lib "kernel32" Alias "GetSystemDirectoryA" (ByVal lpBuffer As String, ByVal nSize As Long) As Long

Private Function GetSysDir() As String
    Dim Temp As String * 256
    Dim x As Integer
    x = GetSystemDirectory(Temp, Len(Temp)) ' Make API Call (Temp will hold return value)
    GetSysDir = Left$(Temp, x)              ' Trim Buffer and return string
End Function

Private Function GetWinDir() As String
    Dim Temp As String * 256
    Dim x As Integer
    x = GetWindowsDirectory(Temp, Len(Temp)) ' Make API Call (Temp will hold return value)
    GetWinDir = Left$(Temp, x)               ' Trim Buffer and return string
End Function

Private Sub Form_Click()
    MsgBox GetWinDir()
    MsgBox GetSysDir()
End Sub

