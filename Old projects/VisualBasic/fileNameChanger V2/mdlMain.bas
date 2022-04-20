Attribute VB_Name = "mdlMain"
Option Explicit

Declare Function MoveFile Lib "kernel32.dll" Alias "MoveFileA" ( _
    ByVal lpExistingFileName As String, _
    ByVal lpNewFileName As String _
    ) As Long

Public ActionSet As Integer 'the action to be performed

Public Sub runAction(Dir1 As DirListBox, File1 As FileListBox, List1 As ListBox, Text1 As String, Text2 As String, testOnlySet As Integer, mp3Player As ISMP3Player, mp3Tag1 As EzyID3)
    'ActionSet is set at optAction_MouseDown()
    Dim a As Integer
    Dim newFileName As String
    List1.Clear
    For a = 0 To File1.ListCount - 1
        If File1.Selected(a) = True Then
            Select Case ActionSet
                Case 0
                    If Val(Trim(Text1)) > 0 And Val(Trim(Text2)) > 0 And Val(Trim(Text2)) < Len(File1.List(a)) Then
                        newFileName = runDelChars(File1.List(a), Val(Trim(Text1)), Val(Trim(Text2)))
                    Else
                        MsgBox "Error, must be correct values in input1 ans input2!", vbCritical
                    End If
                Case 1
                    If Text1 = "" Then
                        MsgBox "Error, must be text in (input1)", vbCritical
                    Else
                        newFileName = runReplaceChars(File1.List(a), Text1, Text2)
                    End If
                Case 2
                    If Val(Trim(Text2)) < 1 Or Val(Trim(Text2)) > Len(File1.List(a)) Then
                        MsgBox "Error, number must be more then 0!", vbCritical
                    Else
                        newFileName = runAddText(File1.List(a), Text1, Val(Trim(Text2)))
                    End If
                Case 3
                    If Text1 = "" Then
                        MsgBox "Error, must be text in text1 and file selected", vbCritical
                    Else
                        newFileName = runManualEdit(Text1)
                    End If
                Case 4
                    newFileName = runByMp3Tag(Dir1, File1.List(a), mp3Player, mp3Tag1)
            End Select
            If testOnlySet = 1 Then
                List1.AddItem newFileName
            Else
                MoveFile Dir1.Path & "\" & File1.List(a), Dir1.Path & "\" & newFileName
            End If
        End If
    Next a
    If testOnlySet = 0 Then
        Dir1.Refresh
        File1.Refresh
    End If
End Sub

Public Function runDelChars(Filename As String, sPos As Integer, ePos As Integer) As String
    runDelChars = Left(Filename, sPos - 1) & Right(Filename, Len(Filename) - ePos)
End Function
                       
Public Function runReplaceChars(Filename As String, oldChars As String, newChars As String) As String
    Dim a As Integer
    Dim newFileName As String
    newFileName = ""
    For a = 1 To Len(Filename) ' - Len(oldChars) + 1
        If Mid(Filename, a, Len(oldChars)) = oldChars Then
            newFileName = newFileName & newChars
            a = a + Len(oldChars) - 1
        Else
            newFileName = newFileName & Mid(Filename, a, 1)
        End If
    Next a
    runReplaceChars = newFileName
End Function

Public Function runAddText(Filename As String, aText As String, pos As Integer) As String
    If pos > Len(Filename) Then pos = Len(Filename) + 1
    runAddText = Left(Filename, pos - 1) & aText & Right(Filename, Len(Filename) - pos + 1)
End Function

Public Function runManualEdit(aText As String) As String
    runManualEdit = aText
End Function
Public Function runByMp3Tag(Dir1 As DirListBox, Filename As String, mp3Player As ISMP3Player, mp3tag As EzyID3) As String
    Dim ret As Long
    Dim RetSongname As String
    Dim RetArtist As String
    Dim RetAlbum As String
    Dim RetYear As String
    Dim RetComment As String
    Dim RetGenre As Integer
    Dim RetHasTag As Boolean
    mp3tag.Filename = Dir1.Path & "\" & Filename
'    mp3tag.Trim = True
    mp3tag.Read
    If mp3tag.Artist <> "" And mp3tag.Song <> "" Then
        runByMp3Tag = mp3tag.Artist & " - " & mp3tag.Song & ".mp3"
    Else
        runByMp3Tag = "*" & Filename
    End If



'    mp3Player.Filename = dir1.Path & "\" & Filename
'    If mp3Player.ID3Artist = "" Then
'        runByMp3Tag = Filename
'    Else
'        runByMp3Tag = mp3Player.ID3Artist & " - " & mp3Player.ID3Title & ".mp3"
'    End If
End Function
