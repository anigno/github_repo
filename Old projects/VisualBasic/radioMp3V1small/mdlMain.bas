Attribute VB_Name = "mdlMain"
Option Explicit

Type SECURITY_ATTRIBUTES
  nLength As Long
  lpSecurityDescriptor As Long
  bInheritHandle As Boolean
End Type

Declare Function CopyFile Lib "kernel32.dll" Alias "CopyFileA" (ByVal lpExistingFileName As String, ByVal lpNewFileName As String, ByVal bFailIfExists As Long) As Long
Declare Function MoveFile Lib "kernel32.dll" Alias "MoveFileA" (ByVal lpExistingFileName As String, ByVal lpNewFileName As String) As Long
Declare Function CreateDirectory Lib "kernel32.dll" Alias "CreateDirectoryA" (ByVal lpPathName As String, lpSecurityAttributes As SECURITY_ATTRIBUTES) As Long

Public Const MAINDIR = "e:\RadioMp3"
Public ListMax As Integer   'maximum songs in current PlayList
Public SongPlayed() As Boolean
Public AutoMode As Boolean
Public SongName As String
Public SongSent As Boolean  'does asong already sent to PlaySong()
Public SongsLeft As Integer 'songs left to play

Public Sub UpdateDirCombo(iCombo As ComboBox, iFindFiles As FindFiles)
    Dim a As Integer
    On Error GoTo ERROR01
    iCombo.Clear
    iCombo.AddItem MAINDIR
    iFindFiles.FindDir MAINDIR
    For a = 0 To iFindFiles.ListDirCount - 1
        iCombo.AddItem iFindFiles.ListDir(a)
    Next a
    'set main radio dir to cmbDirList
    iCombo.Text = iCombo.List(0)
    Exit Sub
ERROR01:
    MsgBox "no dir " & MAINDIR & " found or read error!", vbCritical
End Sub

Public Sub UpdatePlayList(iList As ListBox, iFindFiles As FindFiles, iPattern As String, iPath As String)
    Dim a As Integer
    iFindFiles.FindFiles iPattern, iPath
    iList.Clear
    For a = 0 To iFindFiles.ListFilesCount - 1
        iList.AddItem iFindFiles.ListFiles(a)
    Next a
    ListMax = iFindFiles.ListFilesCount
    If ListMax > 0 Then ReDim SongPlayed(ListMax - 1)
End Sub

Public Function SelectSong(iList As ListBox) As String
    On Error Resume Next
    Dim a, b, R As Integer
    'will check if there are songs not played in SongPlayed()
    b = 0
    For a = 0 To ListMax - 1
        If SongPlayed(a) = False Then b = b + 1
    Next a
    If b = 0 Then
        'no songs left, will clear SongPlayed()
        For a = 0 To ListMax - 1
            SongPlayed(a) = False
        Next a
    End If
    'will select random song
    Do
        Randomize
        R = Int(Rnd * ListMax)
        DoEvents
    Loop Until SongPlayed(R) = False
    SongPlayed(R) = True
    SelectSong = iList.List(R)
End Function

Public Sub PlaySong(SongPath As String, iMp3Play As Mp3Play)
    Dim a, b, c As Integer
    SongSent = True 'will prevent from other song to be sent when doEvents accures
    Do
        a = iMp3Play.Stop
        b = iMp3Play.Open(SongPath, "")
        c = iMp3Play.Play
'    frmMain.List1.AddItem "stop=" & a
'    frmMain.List1.AddItem "open=" & b
'    frmMain.List1.AddItem "play=" & c
'    frmMain.List1.AddItem a & " ------------------"
    DoEvents    'used to let mp3play controll to be update it self
    Loop Until c = 0
    SongName = GetSongFromPath(SongPath)
    SongSent = False
    SongsLeft = SongsLeft - 1
End Sub

Public Function CalcTimeString(iMp3Play As Mp3Play) As String
    Dim a, b, c, D, pm, ps, tm, ts As Integer
    Dim sps, sts As String
    a = iMp3Play.PlayPosition
    b = iMp3Play.MsPerFrame
    c = Int(a * b / 1000)
    D = Int(iMp3Play.GetWaveLengthSecs)
    pm = Int(c / 60)
    ps = Int(c Mod 60)
    tm = Int(D / 60)
    ts = Int(D Mod 60)
    If ps < 10 Then sps = "0" & ps Else sps = ps
    If ts < 10 Then sts = "0" & ts Else sts = ts
    CalcTimeString = pm & ":" & sps & "/" & tm & ":" & sts
End Function

Public Function GetSongFromPath(iPath As String) As String
    Dim S As String
    Dim a, b As Integer
    S = iPath
    a = 0
    Do
        a = InStr(a + 1, S, "\")
        If a <> 0 Then b = a
    Loop While a <> 0
    S = Right(S, Len(S) - b)
    GetSongFromPath = Left(S, Len(S) - 4)
End Function
