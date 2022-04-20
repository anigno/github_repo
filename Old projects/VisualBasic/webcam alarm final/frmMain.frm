VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Object = "{48E59290-9880-11CF-9754-00AA00C00908}#1.0#0"; "MSINET.OCX"
Object = "{DF6D6558-5B0C-11D3-9396-008029E9B3A6}#1.0#0"; "ezVidC60.ocx"
Object = "{E5CEE37F-8CF8-489E-BFA0-8201CBD6AEE8}#1.0#0"; "PicFormat32.ocx"
Begin VB.Form frmMain 
   Caption         =   "WebCam Alarm V1"
   ClientHeight    =   5688
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   6228
   LinkTopic       =   "Form1"
   ScaleHeight     =   474
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   519
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox lstFtpQue 
      Appearance      =   0  'Flat
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2472
      Left            =   600
      TabIndex        =   11
      Top             =   3120
      Width           =   1572
   End
   Begin VB.PictureBox picPreview 
      AutoRedraw      =   -1  'True
      ForeColor       =   &H00FFFFFF&
      Height          =   1932
      Left            =   2280
      ScaleHeight     =   1884
      ScaleWidth      =   2124
      TabIndex        =   10
      TabStop         =   0   'False
      Top             =   3720
      Width           =   2172
   End
   Begin VB.FileListBox File1 
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5544
      Left            =   4560
      Pattern         =   "*.jpg"
      TabIndex        =   9
      Top             =   120
      Width           =   1572
   End
   Begin PicFormat32a.PicFormat32 picFormat 
      Height          =   252
      Left            =   6720
      TabIndex        =   8
      Top             =   4320
      Visible         =   0   'False
      Width           =   252
      _ExtentX        =   445
      _ExtentY        =   445
   End
   Begin VB.ListBox lstFtp1 
      Appearance      =   0  'Flat
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2472
      Left            =   120
      TabIndex        =   7
      Top             =   3120
      Width           =   372
   End
   Begin VB.PictureBox picCapture2 
      Appearance      =   0  'Flat
      AutoRedraw      =   -1  'True
      BackColor       =   &H80000005&
      ForeColor       =   &H80000008&
      Height          =   1692
      Left            =   2280
      ScaleHeight     =   1668
      ScaleWidth      =   2148
      TabIndex        =   6
      TabStop         =   0   'False
      Top             =   1920
      Width           =   2172
   End
   Begin VB.Timer tmrFtp2 
      Enabled         =   0   'False
      Left            =   6240
      Top             =   5160
   End
   Begin VB.Timer tmrFtp1 
      Enabled         =   0   'False
      Interval        =   500
      Left            =   6240
      Top             =   4680
   End
   Begin VB.Timer tmrCapture 
      Enabled         =   0   'False
      Interval        =   500
      Left            =   6240
      Top             =   4200
   End
   Begin VB.Timer tmrRun 
      Interval        =   1
      Left            =   6240
      Top             =   3720
   End
   Begin VB.CheckBox chkEnableFtp 
      Caption         =   "Enable FTP"
      Height          =   252
      Left            =   120
      TabIndex        =   5
      Top             =   2880
      Width           =   1332
   End
   Begin VB.CheckBox chkEnableCheck 
      Caption         =   "Enable Check"
      Height          =   252
      Left            =   120
      TabIndex        =   4
      Top             =   2640
      Width           =   1332
   End
   Begin MSComctlLib.Slider sldSense 
      Height          =   252
      Left            =   120
      TabIndex        =   3
      TabStop         =   0   'False
      Top             =   2280
      Width           =   2052
      _ExtentX        =   3620
      _ExtentY        =   445
      _Version        =   393216
      LargeChange     =   200
      SmallChange     =   50
      Max             =   2000
      SelStart        =   2000
      TickStyle       =   1
      TickFrequency   =   200
      Value           =   2000
   End
   Begin MSComctlLib.ProgressBar prbErrorDif 
      Height          =   252
      Left            =   120
      TabIndex        =   2
      Top             =   1920
      Width           =   2052
      _ExtentX        =   3620
      _ExtentY        =   445
      _Version        =   393216
      Appearance      =   0
      Max             =   2000
      Scrolling       =   1
   End
   Begin VB.PictureBox picCapture1 
      Appearance      =   0  'Flat
      AutoRedraw      =   -1  'True
      BackColor       =   &H80000005&
      ForeColor       =   &H80000008&
      Height          =   1692
      Left            =   2280
      ScaleHeight     =   1668
      ScaleWidth      =   2148
      TabIndex        =   1
      TabStop         =   0   'False
      Top             =   120
      Width           =   2172
   End
   Begin vbVidC60.ezVidCap cam1 
      Height          =   1728
      Left            =   120
      TabIndex        =   0
      TabStop         =   0   'False
      Top             =   120
      Width           =   2112
      _ExtentX        =   3725
      _ExtentY        =   3048
      VideoBorder     =   0
      CaptureViaBackgroundThread=   -1
   End
   Begin InetCtlsObjects.Inet Inet1 
      Left            =   6600
      Top             =   4680
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
      Left            =   6600
      Top             =   5160
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
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub File1_Click()
    'preview recorded picture
    picPreview.Picture = LoadPicture(File1.Path & "/" & File1.List(File1.ListIndex))
End Sub

Private Sub Form_Load()
    'write in regisry picFormat32.dll
    Shell "regsvr32 " & App.Path & "\PicFormat32.dll /s"
    'set all pictures to size of cam, and calculate size of arrays
    pWidth = picCapture1.Width
    pHeight = picCapture1.Height
    pSize = 3 * pHeight * pWidth
    picCapture1.Height = cam1.Height
    picCapture2.Height = cam1.Height
    picPreview.Height = cam1.Height
    picCapture1.Width = cam1.Width
    picCapture2.Width = cam1.Width
    picPreview.Width = cam1.Width
    'redim pictures arrays
    ReDim aPic1(2, pWidth, pHeight)
    ReDim aPic2(2, pWidth, pHeight)
    'set errorSense value to the visual sldSense.value
    errorSense = sldSense.Value
    'create special dir on HD to hols pictures
    makeWebAlarmDir
    'set file manager to path
    File1.Path = "c:\webAlarm"
    'delete all previous files
    deleteAllFilesJpg
End Sub

Private Sub Form_Unload(Cancel As Integer)
    'free memory
    ReDim aPic1(0)
    ReDim aPic2(0)
    End
End Sub

Private Sub Inet1_StateChanged(ByVal State As Integer)
    'check if last operation succeded
    If State = 12 Then
        'remove last file wrriten and refresh listBox
        lstFtpQue.RemoveItem 0
        lstFtpQue.Refresh
    End If
    'check for ftp1 error and write it to flag error
    If State = 11 Then ftp1LastError = 11
    'update listBox with the state of Inet1 (ftp1), check for listBox overflow
    lstFtp1.AddItem State, 0
    If lstFtp1.ListCount > 1000 Then lstFtp1.Clear
End Sub

Private Sub sldSense_Click()
    'change error sensebility according to slider
    errorSense = sldSense.Value
End Sub

Private Sub tmrCapture_Timer()
    'check for real error (movement) and writes pictures
    If checkError() > errorSense Then
        savePictures
    End If
End Sub

Private Sub tmrFtp1_Timer()
    On Error Resume Next
    'check for Inet state, to send picture via ftp
    If Inet1.StillExecuting = False Or ftp1LastError = 11 Then
        'check if ftp que has picture
        If lstFtpQue.ListCount > 0 Then
            Inet1.Execute , "PUT " & "c:\webAlarm\" & lstFtpQue.List(0) & " /" & lstFtpQue.List(0)
        End If
    End If
End Sub

Private Sub tmrRun_Timer()
    'check state of checkBoxs to set timers enable property
    If chkEnableCheck.Value = 1 Then tmrCapture.Enabled = True Else tmrCapture.Enabled = False
    If chkEnableFtp.Value = 1 Then tmrFtp1.Enabled = True Else tmrFtp1.Enabled = False
End Sub
