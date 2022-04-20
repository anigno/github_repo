Attribute VB_Name = "mdlFileExist"
Option Explicit

'***                                                  ***
'* Code By: Patrick Kränzlin                            *
'* Rem mailto:inkognito@freesurf.ch                     *
'* Rem http://members.xoom.com/_XMCM/7AAAAAAA/index.htm *
'***                                                  ***

'Shows if a file exists or not

Enum FileSysTyp
    File = 0
    Folder = 1
    Drive = 2
End Enum

'FileTyp is the Typ of File you give with the parameters (File, Folder or Drive), default is File


Public Function FileExist(Filename As String, Optional FileTyp As FileSysTyp = 0) As Boolean
    
    Dim FileSYS As Object
    Set FileSYS = CreateObject("Scripting.FileSystemObject")
        
    Select Case FileTyp
    
        Case 0:    FileExist = FileSYS.FileExists(Filename)   ' Datei
        Case 1:    FileExist = FileSYS.FolderExists(Filename)  ' Verzeichnis
        Case 2:    FileExist = FileSYS.DriveExists(Filename)   ' Laufwerk
    
    End Select

End Function



