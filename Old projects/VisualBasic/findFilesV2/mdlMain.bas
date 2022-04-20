Attribute VB_Name = "mdlMain"
Option Explicit

Public dirList() As String
Public FileList() As String
Public iSearchWord As String
Public iPath As String


Public Sub runFind(Dir1 As DirListBox, File1 As FileListBox)
    Dim a As Integer
    Dim b As Integer
    For b = 0 To File1.listCount - 1
        If InStr(1, File1.List(b), iSearchWord, vbBinaryCompare) <> 0 Then
            FileList(UBound(FileList)) = File1.List(b)
            dirList(UBound(FileList)) = Dir1.path
            ReDim Preserve FileList(UBound(FileList) + 1)
            ReDim Preserve dirList(UBound(FileList) + 1)
        End If
    Next b
    For a = 0 To Dir1.listCount - 1
        Dir1.path = Dir1.List(a)
        runFind Dir1, File1
        Dir1.path = Dir1.List(-2)
        DoEvents
    Next a
End Sub

Public Sub setArrays()
    ReDim FileList(0)
    ReDim dirList(0)
End Sub

