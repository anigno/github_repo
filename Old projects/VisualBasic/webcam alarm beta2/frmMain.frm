VERSION 5.00
Object = "{48E59290-9880-11CF-9754-00AA00C00908}#1.0#0"; "MSINET.OCX"
Object = "{DF6D6558-5B0C-11D3-9396-008029E9B3A6}#1.0#0"; "ezVidC60.ocx"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Object = "{E5CEE37F-8CF8-489E-BFA0-8201CBD6AEE8}#1.0#0"; "PicFormat32.ocx"
Begin VB.Form frmMain 
   Caption         =   "Webcam alarm"
   ClientHeight    =   7260
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   9348
   LinkTopic       =   "Form1"
   ScaleHeight     =   605
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   779
   StartUpPosition =   3  'Windows Default
   Begin VB.CheckBox chkFtpEnable2 
      Caption         =   "enable FTP2"
      Height          =   252
      Left            =   4680
      TabIndex        =   21
      Top             =   6240
      Width           =   1212
   End
   Begin VB.ListBox lstFtp2 
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5232
      Left            =   2280
      TabIndex        =   19
      Top             =   1920
      Width           =   2172
   End
   Begin VB.Timer tmrFtp2 
      Enabled         =   0   'False
      Interval        =   1000
      Left            =   7920
      Top             =   6360
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "EXIT"
      Height          =   252
      Left            =   6720
      TabIndex        =   18
      Top             =   6360
      Width           =   852
   End
   Begin VB.CommandButton cmdOpenFtp 
      Caption         =   "open FTP"
      Height          =   252
      Left            =   6720
      TabIndex        =   17
      Top             =   5760
      Width           =   852
   End
   Begin VB.CheckBox chkCheckDif 
      Caption         =   "enable Check"
      Height          =   252
      Left            =   4680
      TabIndex        =   16
      Top             =   5760
      Width           =   1332
   End
   Begin VB.Timer tmrRun 
      Interval        =   1
      Left            =   8880
      Top             =   6600
   End
   Begin VB.CheckBox chkFtpEnable 
      Caption         =   "enable FTP"
      Height          =   252
      Left            =   4680
      TabIndex        =   15
      Top             =   6000
      Width           =   1092
   End
   Begin VB.TextBox txtFtpUrl 
      Height          =   288
      Left            =   4680
      TabIndex        =   14
      Text            =   "ftp://"
      Top             =   5400
      Width           =   3972
   End
   Begin PicFormat32a.PicFormat32 picFormat1 
      Height          =   252
      Left            =   7680
      TabIndex        =   13
      Top             =   5880
      Visible         =   0   'False
      Width           =   252
      _ExtentX        =   445
      _ExtentY        =   445
   End
   Begin VB.ListBox lstFtp 
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5232
      Left            =   0
      TabIndex        =   11
      Top             =   1920
      Width           =   2172
   End
   Begin VB.PictureBox picBrowse 
      Height          =   1812
      Left            =   6720
      ScaleHeight     =   1764
      ScaleWidth      =   2124
      TabIndex        =   10
      Top             =   3240
      Width           =   2172
   End
   Begin VB.FileListBox File1 
      Height          =   3144
      Left            =   4680
      Pattern         =   "*.jpg"
      TabIndex        =   9
      Top             =   1920
      Width           =   2052
   End
   Begin VB.PictureBox picSense 
      AutoRedraw      =   -1  'True
      Height          =   1812
      Index           =   1
      Left            =   2280
      ScaleHeight     =   1764
      ScaleWidth      =   2124
      TabIndex        =   8
      Top             =   1920
      Visible         =   0   'False
      Width           =   2172
   End
   Begin VB.PictureBox picSense 
      AutoRedraw      =   -1  'True
      Height          =   1812
      Index           =   0
      Left            =   0
      ScaleHeight     =   1764
      ScaleWidth      =   2124
      TabIndex        =   7
      Top             =   1920
      Visible         =   0   'False
      Width           =   2172
   End
   Begin MSComctlLib.Slider sldSensor 
      Height          =   252
      Left            =   6960
      TabIndex        =   6
      Top             =   2160
      Width           =   2172
      _ExtentX        =   3831
      _ExtentY        =   445
      _Version        =   393216
      LargeChange     =   50
      SmallChange     =   10
      Max             =   2000
      SelStart        =   900
      TickStyle       =   1
      TickFrequency   =   50
      Value           =   900
   End
   Begin MSComctlLib.ProgressBar pbrErrorDif 
      Height          =   252
      Left            =   6960
      TabIndex        =   5
      Top             =   1920
      Width           =   2172
      _ExtentX        =   3831
      _ExtentY        =   445
      _Version        =   393216
      Appearance      =   0
      Max             =   2000
      Scrolling       =   1
   End
   Begin VB.Timer tmrFtp 
      Enabled         =   0   'False
      Interval        =   1000
      Left            =   8400
      Top             =   6360
   End
   Begin VB.PictureBox picCapture 
      AutoRedraw      =   -1  'True
      Height          =   1812
      Index           =   2
      Left            =   6960
      ScaleHeight     =   1764
      ScaleWidth      =   2124
      TabIndex        =   3
      Top             =   0
      Width           =   2172
   End
   Begin VB.PictureBox picCapture 
      AutoRedraw      =   -1  'True
      Height          =   1812
      Index           =   1
      Left            =   4560
      ScaleHeight     =   1764
      ScaleWidth      =   2124
      TabIndex        =   2
      Top             =   0
      Width           =   2172
   End
   Begin VB.Timer tmrCheckDif 
      Enabled         =   0   'False
      Interval        =   600
      Left            =   8880
      Top             =   6240
   End
   Begin VB.PictureBox picCapture 
      AutoRedraw      =   -1  'True
      Height          =   1812
      Index           =   0
      Left            =   2160
      ScaleHeight     =   1764
      ScaleWidth      =   2124
      TabIndex        =   1
      Top             =   0
      Width           =   2172
   End
   Begin vbVidC60.ezVidCap cam1 
      Height          =   1728
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   2112
      _ExtentX        =   3725
      _ExtentY        =   3048
      BorderStyle     =   0
      VideoBorder     =   0
      PreviewRate     =   30
   End
   Begin InetCtlsObjects.Inet Inet1 
      Left            =   8400
      Top             =   5880
      _ExtentX        =   804
      _ExtentY        =   804
      _Version        =   393216
      Protocol        =   2
      RemoteHost      =   "members.truepath.com"
      RemotePort      =   21
      URL             =   "ftp://anigno2:h7xmiz@members.truepath.com"
      UserName        =   "anigno2"
      Password        =   "h7xmiz"
      RequestTimeout  =   10
   End
   Begin InetCtlsObjects.Inet Inet2 
      Left            =   7920
      Top             =   5880
      _ExtentX        =   804
      _ExtentY        =   804
      _Version        =   393216
      Protocol        =   2
      RemoteHost      =   "members.truepath.com"
      RemotePort      =   21
      URL             =   "ftp://anigno2:h7xmiz@members.truepath.com"
      UserName        =   "anigno2"
      Password        =   "h7xmiz"
      RequestTimeout  =   10
   End
   Begin VB.Label lblFtp2 
      AutoSize        =   -1  'True
      Caption         =   "00"
      Height          =   192
      Left            =   4920
      TabIndex        =   20
      Top             =   5160
      Width           =   168
   End
   Begin VB.Label lblFtp 
      AutoSize        =   -1  'True
      Caption         =   "00"
      Height          =   192
      Left            =   4680
      TabIndex        =   12
      Top             =   5160
      Width           =   168
   End
   Begin VB.Label lblErrorDif 
      AutoSize        =   -1  'True
      Caption         =   "0000"
      Height          =   192
      Left            =   6960
      TabIndex        =   4
      Top             =   2520
      Width           =   336
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim pictureToUpdate As Byte
Dim pWidth As Long
Dim pHeight As Integer
Dim pSize As Long
Dim arrayPic0() As Byte
Dim arrayPic1() As Byte
Dim ErrorDif(1) As Long
Dim errorReal As Long
Dim errorSense
Dim picSenseCnt As Integer
Dim sTime As String
Dim ftpCnt As Integer
Dim ftpCnt2 As Integer
Dim lastFileSent As Integer
Dim ftpRestartTime As Integer
Dim ftpUrl As String
Dim firstFileRefresh As Boolean

Private Sub Form_Load()
'    On Error Resume Next
    Shell "command.com /c del c:\*.bmp"
    Shell "command.com /c del c:\*.jpg"
    Shell "regsvr32 " & App.Path & "\PicFormat32.dll /s"
    Inet1.RequestTimeout = 10
    errorSense = 900
    ftpRestartTime = 20
    Inet1.Password = "h7xmiz"
    Inet1.RemoteHost = "members.truepath.com"
    Inet1.RemotePort = 21
    Inet1.UserName = "anigno2"
    ftpUrl = Inet1.URL
    
    frmMain.ScaleMode = vbPixels    'must be for manipulating pictures
    'setPictureBoxesToCam1Size
    pWidth = frmMain.picCapture(0).Width
    pHeight = frmMain.picCapture(0).Height
    pSize = 2 * pWidth * pHeight
    File1.Path = "c:\"
    File1.Refresh
ReDim arrayPic0(2, pWidth, pHeight) As Byte
ReDim arrayPic1(2, pWidth, pHeight) As Byte
End Sub

Public Sub checkDiff()
    On Error Resume Next
    Dim a As Integer, x As Integer, y As Integer
    Dim p1 As Integer, p2 As Integer, p3 As Integer
    frmMain.cam1.EditCopy
    
    picCapture(pictureToUpdate).Picture = Clipboard.GetData
    Clipboard.Clear
    pictureToUpdate = pictureToUpdate + 1: If pictureToUpdate > 1 Then pictureToUpdate = 0
    GetBitmapBits picCapture(0).Image, pSize, arrayPic0(0, 0, 0)
    GetBitmapBits picCapture(1).Image, pSize, arrayPic1(0, 0, 0)

    ErrorDif(pictureToUpdate) = 0
    For x = 0 To pWidth
        For y = 0 To pHeight
            For a = 0 To 2
                p1 = arrayPic0(a, x, y)
                p2 = arrayPic1(a, x, y)
                p3 = Abs(p1 - p2)
                arrayPic0(a, x, y) = p3
                If p3 = 0 Then ErrorDif(pictureToUpdate) = ErrorDif(pictureToUpdate) + 1
            Next a
        Next y
    Next x

    errorReal = Abs(ErrorDif(0) - ErrorDif(1))
    SetBitmapBits picCapture(2).Image, pSize, arrayPic0(0, 0, 0)
    If errorReal > 2000 Then errorReal = 2000
    lblErrorDif.Caption = errorReal
    pbrErrorDif.Value = errorReal
    If errorReal > errorSense Then
        picSense(picSenseCnt).Picture = picCapture(0).Picture
        picSense(picSenseCnt + 1).Picture = picCapture(1).Picture
        sTime = ""
        If Hour(Time) < 10 Then
            sTime = sTime & "0" & Hour(Time)
        Else
            sTime = sTime & Hour(Time)
        End If
        If Minute(Time) < 10 Then
            sTime = sTime & "0" & Minute(Time)
        Else
            sTime = sTime & Minute(Time)
        End If
        If Second(Time) < 10 Then
            sTime = sTime & "0" & Second(Time)
        Else
            sTime = sTime & Second(Time)
        End If
        File1.Refresh
        SavePicture picSense(0).Image, "c:\pic" & sTime & ".bmp"
        SavePicture picSense(1).Image, "c:\pic" & sTime & "_2.bmp"
        If FileExist("c:\pic" & sTime & ".bmp") Then picFormat1.SaveBmpToJpeg "c:\pic" & sTime & ".bmp", "c:\pic" & sTime & ".jpg", 60
        If FileExist("c:\pic" & sTime & "_2.bmp") Then picFormat1.SaveBmpToJpeg "c:\pic" & sTime & "_2.bmp", "c:\pic" & sTime & "_2.jpg", 60
        Shell "command.com /c del c:\*.bmp"
        File1.Refresh
        If File1.ListCount > 10000 Then End
    End If
End Sub


Private Sub cmdExit_Click()
    End
End Sub

Private Sub cmdOpenFtp_Click()
    chkCheckDif.Value = 0
    chkFtpEnable.Value = 0
    Shell "explorer " & ftpUrl
End Sub

Private Sub File1_Click()
    On Error Resume Next
    picBrowse.Picture = LoadPicture(File1.Path & "\" & File1.List(File1.ListIndex))
End Sub


Private Sub Inet1_StateChanged(ByVal State As Integer)
    If lstFtp.ListCount > 1000 Then lstFtp.Clear
    If State = 11 Or State = 12 Then lstFtp.AddItem Time & " " & State, 0
    If State = 12 Then ftpCnt = 0
    If State = 11 Then ftpCnt = 0
End Sub

Private Sub Inet2_StateChanged(ByVal State As Integer)
    lstFtp2.AddItem State, 0
End Sub

Private Sub sldSensor_Click()
    errorSense = sldSensor.Value
End Sub

Private Sub tmrCheckDif_Timer()
    checkDiff
    ' at start interval=2000
    If tmrCheckDif.Interval <> 200 Then tmrCheckDif.Interval = 200
End Sub

Private Sub tmrFtp_Timer()
    On Error Resume Next
    ftpCnt = ftpCnt - 1: If ftpCnt < 0 Then ftpCnt = 0
    lblFtp.Caption = ftpCnt
    If ftpCnt < 1 And lastFileSent < File1.ListCount Then
        ftpCnt = ftpRestartTime
        lstFtp.AddItem "PUT c:\" & File1.List(lastFileSent) & " /" & File1.List(lastFileSent), 0
        Inet1.Execute , "PUT c:\" & File1.List(lastFileSent) & " /" & File1.List(lastFileSent)
        lastFileSent = lastFileSent + 1
    End If
End Sub

Private Sub tmrFtp2_Timer()
    On Error Resume Next
    If lstFtp2.ListCount > 1000 Then lstFtp2.Clear
    lblFtp2.Caption = ftpCnt2
    ftpCnt2 = ftpCnt2 - 1
    If ftpCnt2 < 1 Then
        ftpCnt2 = 10
        SavePicture picSense(0).Image, "c:\cam1.bmp"
        If FileExist("c:\cam1.bmp") Then
            picFormat1.SaveBmpToJpeg "c:\cam1.bmp", "c:\cam1.jpg", 60
            lstFtp2.AddItem "saved", 0
        End If
        Inet2.Execute , "PUT c:\cam1.jpg /cam1.jpg"
    End If
End Sub

Private Sub tmrRun_Timer()
    If chkFtpEnable.Value = 0 Then
        tmrFtp.Enabled = False
    Else
        tmrFtp.Enabled = True
    End If
    If chkFtpEnable2.Value = 0 Then
        tmrFtp2.Enabled = False
    Else
        tmrFtp2.Enabled = True
    End If
    If chkCheckDif.Value = 0 Then
        tmrCheckDif.Enabled = False
    Else
        tmrCheckDif.Enabled = True
    End If
    If txtFtpUrl.Text <> ftpUrl Then txtFtpUrl.Text = ftpUrl
End Sub
