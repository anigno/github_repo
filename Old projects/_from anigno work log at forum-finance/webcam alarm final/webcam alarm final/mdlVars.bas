Attribute VB_Name = "mdlVars"
Option Explicit

Public pWidth As Long               'all pictures and cam widths
Public pHeight As Long              'all pictures and cam heights
Public pSize As Long                'size of cam and pictures
Public aPic1() As Byte              'array of picCapture1
Public aPic2() As Byte              'array of picCapture2
Public picToPlace As Byte           'the picture to be copy from cam
Public lastErrorDiff As Long        'last error red from checkDiff()
Public realError As Long            'real error, the defference between lastErrorDiff and the actual checkDiff()
Public errorSense As Long           'error sensor sensebility
Public ftp1LastError As Integer     'last error by FTP1

