Attribute VB_Name = "mdlFunctions"
Option Explicit

'delete all files in file1 fileBox (jpg)
Public Sub deleteAllFilesJpg()
    Dim a As Integer
    With frmMain
        For a = 0 To .File1.ListCount - 1
            DeleteFile .File1.Path & "/" & .File1.List(a)
        Next a
        .File1.Refresh
    End With
End Sub

'create directory on HD to hold pictures
Public Sub makeWebAlarmDir()
    CreateDirectory "c:\webAlarm", SA
End Sub

'save pictures from picCapture1 and picCapture2 to jpg
Public Sub savePictures()
    Dim tTime As String
    'get time stemp to add to file name
    tTime = getTimeString()
    savePicturesBmp tTime   'save as bmp
    savePicturesJpg tTime   'convert to jpg
    delPicturesBmp tTime    'delete bmp
    frmMain.File1.Refresh           'refresh fileBox
End Sub

'save pictures to bmp
Public Sub savePicturesBmp(tTime As String)
    SavePicture frmMain.picCapture1.Image, "c:\webAlarm\pic" & tTime & "_1.bmp"
    SavePicture frmMain.picCapture2.Image, "c:\webAlarm\pic" & tTime & "_2.bmp"
End Sub

'convert pictures bmp to jpg
Public Sub savePicturesJpg(tTime As String)
    On Error Resume Next
    'wait for pictures to be on HD
    While (FileExist("c:\webAlarm\pic" & tTime & "_1.bmp") * FileExist("c:\webAlarm\pic" & tTime & "_2.bmp")) <> 1
        DoEvents
    Wend
    'convert the pictures
    frmMain.picFormat.SaveBmpToJpeg "c:\webAlarm\pic" & tTime & "_1.bmp", "c:\webAlarm\pic" & tTime & "_1.jpg", 40
    frmMain.picFormat.SaveBmpToJpeg "c:\webAlarm\pic" & tTime & "_2.bmp", "c:\webAlarm\pic" & tTime & "_2.jpg", 40
    'add to ftp que (ftp1)
    frmMain.lstFtpQue.AddItem "pic" & tTime & "_1.jpg"
    frmMain.lstFtpQue.AddItem "pic" & tTime & "_2.jpg"
End Sub

'delete pictures bmp
Public Sub delPicturesBmp(tTime As String)
    DeleteFile "c:\webAlarm\pic" & tTime & "_1.bmp"
    DeleteFile "c:\webAlarm\pic" & tTime & "_2.bmp"
End Sub

'return a string contains the dayInMonth and the time
Public Function getTimeString() As String
    Dim sTime As String
    sTime = ""
    If Day(Date) < 10 Then sTime = sTime & "0"
    sTime = sTime & Day(Date) & "_"
    If Hour(Time) < 10 Then sTime = sTime & "0"
    sTime = sTime & Hour(Time) & "_"
    If Minute(Time) < 10 Then sTime = sTime & "0"
    sTime = sTime & Minute(Time) & "_"
    If Second(Time) < 10 Then sTime = sTime & "0"
    sTime = sTime & Second(Time) & "_"
    getTimeString = sTime
End Function

'return real error between 2 pictures
Public Function checkError() As Long
    Dim tError As Long
    placePic            'place picture from cam to picCapture 1 or 2
    tError = GetDiff()  'get error between pictures
    'calculate real error between last error and actual one
    realError = Abs(lastErrorDiff - tError)
    lastErrorDiff = tError
    If realError > 2000 Then realError = 2000
    frmMain.prbErrorDif.Value = realError
    checkError = realError
End Function

'place the next picture from the cam using the clipboad
Public Sub placePic()
    With frmMain
        .cam1.EditCopy   'using clipboard to pass picture data
        If picToPlace = 0 Then
            .picCapture1.Picture = Clipboard.GetData
        Else
            .picCapture2.Picture = Clipboard.GetData
        End If
        Clipboard.Clear
        picToPlace = picToPlace + 1
        If picToPlace > 1 Then picToPlace = 0
    End With
End Sub

'return actual error between the 2 pictures
'images are already in picCapture1 and picCapture2
Public Function GetDiff() As Long
    Dim x As Integer, y As Integer, a As Integer
    Dim p1 As Integer, p2 As Integer, p3 As Integer
    Dim tError As Long
    'load pictures arrays with pictures data
    GetBitmapBits frmMain.picCapture1.Image, pSize, aPic1(0, 0, 0)
    GetBitmapBits frmMain.picCapture2.Image, pSize, aPic2(0, 0, 0)
    'calculate error between pictures
    For x = 0 To pWidth - 1
        For y = 0 To pHeight - 1
            For a = 0 To 2
                p1 = aPic1(a, x, y)
                p2 = aPic2(a, x, y)
                p3 = Abs(p1 - p2)
                aPic1(a, x, y) = p3
                If p3 = 0 Then tError = tError + 1
            Next a
        Next y
    Next x
    GetDiff = tError
End Function

