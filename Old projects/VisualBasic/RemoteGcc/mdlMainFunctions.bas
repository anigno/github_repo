Attribute VB_Name = "mdlMainFunctions"
Option Explicit

Public Sub setCurrentFile(Form1 As Form, iFilename As String)
    Form1.Caption = "Remote gcc - " & iFilename
    currentFile = iFilename
End Sub

Public Sub saveFile(iFile As FileListBox, RTF As RichTextBox, iFilename As String)
    If iFilename <> "no file" Then
        RTF.saveFile iFile.Path & "\" & iFilename, 1
        If iFilename <> "\_temp" Then frmMain.lstAction.AddItem iFilename & " saved", 0
    End If
End Sub

Public Sub replaceFiles(iFile As FileListBox, RTF As RichTextBox, oldFile As String, newFile As String)
    saveFile iFile, RTF, oldFile
    RTF.LoadFile iFile.Path & "\" & newFile, 1
    setCurrentFile frmMain, newFile
End Sub

Public Sub createNewFile(Form1 As Form, iFile As FileListBox, RTF As RichTextBox)
    On Error GoTo error_creatingNewFile
    Dim newFile As String
    saveFile iFile, RTF, currentFile
    newFile = InputBox("Enter new file name")
    RTF.Text = ""
    saveFile iFile, RTF, newFile
    setCurrentFile Form1, newFile
    iFile.Refresh
    Exit Sub
error_creatingNewFile:
    MsgBox "Error creating new file!", vbCritical
    If currentFile <> "no file" Then
        RTF.LoadFile iFile.Path & "\" & currentFile, 1
    End If
End Sub

Public Sub sendFiles(iFile As FileListBox, FTP As EZFTP, list1 As ListBox, RTF1 As RichTextBox, RTF2 As RichTextBox)
On Error GoTo errorSendfiles
    Dim a As Integer
    Dim filename As String, S As String
    saveFile iFile, RTF1, currentFile
    For a = 0 To iFile.ListCount - 1
        filename = iFile.List(a)
        RTF2.LoadFile iFile.Path & "\" & filename
        RTF2.Text = removeChar13(RTF2.Text)
        saveFile iFile, RTF2, "\_temp"
        FTP.LocalFile = iFile.Path & "\_temp"
        FTP.RemoteFile = iFile.List(a)
        FTP.PutFile
        If list1.ListCount > 30000 Then list1.Clear
        list1.AddItem FTP.RemoteFile & " loaded", 0
        DoEvents
    Next a
    list1.AddItem "-send files end -", 0
    Exit Sub
errorSendfiles:
    MsgBox "error, no FTP, restart program or open ftp.", vbCritical
End Sub

Public Function removeChar13(s1 As String) As String
        Dim b As Integer
        Dim s2 As String
        For b = 1 To Len(s1)
            If Asc(Mid(s1, b, 1)) <> 13 Then
                s2 = s2 & Mid(s1, b, 1)
            End If
        Next b
        removeChar13 = s2
End Function

Public Sub addToString(sInto As String, sWhat As String, iWhere As Integer)

End Sub
