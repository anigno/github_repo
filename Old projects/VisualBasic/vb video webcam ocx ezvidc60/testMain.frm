VERSION 5.00
Object = "{DF6D6558-5B0C-11D3-9396-008029E9B3A6}#1.0#0"; "ezVidC60.ocx"
Begin VB.Form frmCapTest 
   Caption         =   "ezCapWnd Test Program"
   ClientHeight    =   6315
   ClientLeft      =   990
   ClientTop       =   1785
   ClientWidth     =   6540
   Icon            =   "testMain.frx":0000
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   ScaleHeight     =   421
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   436
   Begin vbVidC60.ezVidCap ezVidCap1 
      Height          =   1800
      Left            =   1560
      TabIndex        =   24
      Top             =   120
      Width           =   2400
      _ExtentX        =   4233
      _ExtentY        =   3175
   End
   Begin VB.CheckBox chkFrameCallback 
      Caption         =   "Enable FrameCallback Event"
      Height          =   240
      Left            =   180
      TabIndex        =   23
      Top             =   4650
      Width           =   2370
   End
   Begin VB.CheckBox chkPreview 
      Caption         =   "Preview video"
      Height          =   240
      Left            =   180
      TabIndex        =   22
      Top             =   4365
      Width           =   1365
   End
   Begin VB.CheckBox chkUserConfirm 
      Caption         =   "Show VFW defined user dialog to confirm capture"
      Height          =   240
      Left            =   180
      TabIndex        =   21
      Top             =   3780
      Width           =   3840
   End
   Begin VB.CheckBox chkPreRoll 
      Caption         =   "Use Precise Capture Controls (Preroll)"
      Height          =   240
      Left            =   180
      TabIndex        =   20
      Top             =   4080
      Width           =   3060
   End
   Begin VB.CommandButton cmdSaveDIB 
      Caption         =   "Save DIB..."
      Height          =   300
      Left            =   5220
      TabIndex        =   19
      Top             =   5115
      Width           =   1230
   End
   Begin VB.CommandButton cmdSaveAs 
      Caption         =   "Save AVI..."
      Height          =   300
      Left            =   3840
      TabIndex        =   18
      Top             =   5115
      Width           =   1230
   End
   Begin VB.ComboBox cbDriver 
      Height          =   315
      ItemData        =   "testMain.frx":0442
      Left            =   3840
      List            =   "testMain.frx":0444
      Style           =   2  'Dropdown List
      TabIndex        =   17
      Top             =   5445
      Width           =   2610
   End
   Begin VB.TextBox txtWidth 
      Height          =   285
      Left            =   2880
      TabIndex        =   16
      Text            =   "160"
      Top             =   5100
      Width           =   615
   End
   Begin VB.CommandButton cmdWidth 
      Caption         =   "Set Width"
      Height          =   300
      Left            =   1905
      TabIndex        =   15
      Top             =   5100
      Width           =   945
   End
   Begin VB.TextBox txtHeight 
      Height          =   285
      Left            =   2880
      TabIndex        =   14
      Text            =   "120"
      Top             =   5460
      Width           =   615
   End
   Begin VB.CommandButton cmdHeight 
      Caption         =   "Set Height"
      Height          =   300
      Left            =   1905
      TabIndex        =   13
      Top             =   5460
      Width           =   945
   End
   Begin VB.CheckBox chkStretch 
      Caption         =   "StretchPreview"
      Height          =   240
      Left            =   180
      TabIndex        =   12
      Top             =   5550
      Width           =   1635
   End
   Begin VB.CheckBox chkCenter 
      Caption         =   "AutoCenter"
      Height          =   240
      Left            =   180
      TabIndex        =   11
      Top             =   5280
      Value           =   1  'Checked
      Width           =   1635
   End
   Begin VB.CheckBox chkAutoSize 
      Caption         =   "AutoSize"
      Height          =   240
      Left            =   180
      TabIndex        =   10
      Top             =   5025
      Value           =   1  'Checked
      Width           =   1635
   End
   Begin VB.CheckBox chkAudio 
      Caption         =   "Capture Audio"
      Height          =   240
      Left            =   180
      TabIndex        =   9
      Top             =   3495
      Width           =   1320
   End
   Begin VB.CommandButton cmdAudioDlg 
      Caption         =   "Audio DLG"
      Height          =   465
      Left            =   165
      TabIndex        =   8
      Top             =   2970
      Width           =   1230
   End
   Begin VB.CommandButton cmdCompDlg 
      Caption         =   "Comp DLG"
      Height          =   465
      Left            =   165
      TabIndex        =   7
      Top             =   2460
      Width           =   1230
   End
   Begin VB.CommandButton cmdSourceDlg 
      Caption         =   "Source DLG"
      Height          =   465
      Left            =   165
      TabIndex        =   6
      Top             =   1800
      Width           =   1230
   End
   Begin VB.CommandButton cmdDisplayDlg 
      Caption         =   "Display DLG"
      Height          =   465
      Left            =   165
      TabIndex        =   5
      Top             =   1290
      Width           =   1230
   End
   Begin VB.CommandButton cmdFormatDlg 
      Caption         =   "Format DLG"
      Height          =   465
      Left            =   165
      TabIndex        =   4
      Top             =   780
      Width           =   1230
   End
   Begin VB.PictureBox picStatus 
      Align           =   2  'Align Bottom
      BeginProperty Font 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H8000000F&
      Height          =   465
      Left            =   0
      ScaleHeight     =   27
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   432
      TabIndex        =   1
      Top             =   5850
      Width           =   6540
      Begin VB.Label lblStatusString 
         Alignment       =   2  'Center
         Caption         =   "status label"
         BeginProperty Font 
            Name            =   "ÇlÇr ÉSÉVÉbÉN"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   2880
         TabIndex        =   3
         Top             =   75
         Width           =   2220
         WordWrap        =   -1  'True
      End
      Begin VB.Label lblStatusCode 
         Alignment       =   2  'Center
         Caption         =   "status label"
         BeginProperty Font 
            Name            =   "ÇlÇr ÉSÉVÉbÉN"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000FF&
         Height          =   195
         Left            =   105
         TabIndex        =   2
         Top             =   60
         Width           =   2220
      End
   End
   Begin VB.CommandButton cmdCapture 
      Caption         =   "Capture Video"
      Height          =   465
      Left            =   165
      TabIndex        =   0
      Top             =   105
      Width           =   1230
   End
End
Attribute VB_Name = "frmCapTest"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
 
Private Sub cbDriver_Click()
    Dim oldDriver As Long
    oldDriver = ezVidCap1.DriverIndex
    
    On Error Resume Next
    ezVidCap1.DriverIndex = cbDriver.ListIndex
    If Err Then
        'restore old settings
        ezVidCap1.DriverIndex = oldDriver
        cbDriver.ListIndex = oldDriver
        lblStatusString = "Could not connect!"
    End If
    
End Sub

Private Sub chkAudio_Click()
    If chkAudio.Value = 1 Then
        ezVidCap1.CaptureAudio = True
    Else
        ezVidCap1.CaptureAudio = False
    End If
End Sub

Private Sub chkAutoSize_Click()
    If chkAutoSize.Value = 1 Then
        ezVidCap1.AutoSize = True
    Else
        ezVidCap1.AutoSize = False
    End If
End Sub

Private Sub chkCenter_Click()
    If chkCenter.Value = 1 Then
        ezVidCap1.CenterVideo = True
    Else
        ezVidCap1.CenterVideo = False
    End If
End Sub

Private Sub chkFrameCallback_Click()
    If chkFrameCallback.Value = 1 Then
        ezVidCap1.FrameEventEnabled = True
    Else
        ezVidCap1.FrameEventEnabled = False
    End If
End Sub

Private Sub chkPreRoll_Click()
    If chkPreRoll.Value = 1 Then
        ezVidCap1.UsePreciseCaptureControls = True
    Else
        ezVidCap1.UsePreciseCaptureControls = False
    End If
End Sub

Private Sub chkPreview_Click()
    If chkPreview.Value = 1 Then
        ezVidCap1.Preview = True
    Else
        ezVidCap1.Preview = False
    End If
End Sub

Private Sub chkStretch_Click()
    If chkStretch.Value = 1 Then
        ezVidCap1.StretchPreview = True
    Else
        ezVidCap1.StretchPreview = False
    End If
End Sub

Private Sub chkUserConfirm_Click()
    If chkUserConfirm.Value = 1 Then
        ezVidCap1.MakeUserConfirmCapture = True
    Else
        ezVidCap1.MakeUserConfirmCapture = False
    End If
End Sub

Private Sub cmdAudioDlg_Click()
    'From Beta2 the syntax has changed here
    'ezVidCap1.ShowDlgAudioFormat = True
    ezVidCap1.ShowDlgAudioFormat
End Sub

Private Sub cmdCapture_Click()
    Call ezVidCap1.CaptureVideo
End Sub

Private Sub cmdCompDlg_Click()
    'From Beta2 the syntax has changed here
    'ezVidCap1.ShowDlgCompressionOptions = True
    ezVidCap1.ShowDlgCompressionOptions
End Sub

Private Sub cmdDisplayDlg_Click()
    'From Beta2 the syntax has changed here
    'ezVidCap1.ShowDlgVideoDisplay = True
    ezVidCap1.ShowDlgVideoDisplay
End Sub

Private Sub cmdFormatDlg_Click()
    'From Beta2 the syntax has changed here
    'ezVidCap1.ShowDlgVideoFormat = True
    ezVidCap1.ShowDlgVideoFormat
End Sub

Private Sub cmdHeight_Click()
    ezVidCap1.Height = txtHeight.Text
    'show actual size (in case auto size is turned on)
    txtHeight.Text = ezVidCap1.Height
End Sub

Private Sub cmdSaveAs_Click()
    Dim filename As String
    If mCmnDlg.VBGetSaveFileNamePreview(filename, _
                            FileMustExist:=False, _
                            filter:="AVI files (*.avi)|*.avi", _
                            InitDir:=App.path, _
                            DlgTitle:="Save AVI File", _
                            DefaultExt:="avi", _
                            Owner:=Me.hWnd) _
                                                    Then
        On Error Resume Next
        Call ezVidCap1.SaveAs(filename)
        If Err Then
            MsgBox Err.Description, vbInformation, App.Title
        End If
    End If
                            
End Sub

Private Sub cmdSaveDIB_Click()
    Dim filename As String
    If mCmnDlg.VBGetSaveFileName(filename, _
                            filter:="Bitmap files (*.bmp)|*.bmp", _
                            InitDir:=App.path, _
                            DlgTitle:="Save Frame As Bitmap File", _
                            DefaultExt:="bmp", _
                            Owner:=Me.hWnd) _
                                                    Then
        On Error Resume Next
        Call ezVidCap1.SaveDIB(filename)
        If Err Then
            MsgBox Err.Description, vbInformation, App.Title
        End If
    End If
End Sub

Private Sub cmdSourceDlg_Click()
    'From Beta2 the syntax has changed here
    'ezVidCap1.ShowDlgVideoSource = True
    ezVidCap1.ShowDlgVideoSource
End Sub

Private Sub cmdWidth_Click()
    ezVidCap1.Width = txtWidth.Text
    'show actual size (in case auto size is turned on)
    txtWidth.Text = ezVidCap1.Width
End Sub

Private Sub ezVidCap1_StatusClear()
    lblStatusCode.Caption = ""
    lblStatusString.Caption = ""
End Sub

Private Sub ezVidCap1_CaptureYield()
    'Setting Yield = True will allow this event to be generated
    'but will slow down performance
    Debug.Print "yield"
    DoEvents
End Sub

Private Sub ezVidCap1_ErrorMessage(ByVal ErrCode As Long, ByVal ErrString As String)
    If ErrCode <> 0 Then
        'Debug.Print ErrString
        lblStatusString = "Error " & ErrString
        lblStatusString.Refresh
    End If
End Sub

Private Sub ezVidCap1_FrameCallback(ByVal lpVHdr As Long)
Debug.Print "Video frame: " & lpVHdr

Call MessWithVidBits(lpVHdr)

End Sub

Private Sub ezVidCap1_PreRollComplete()
    Dim userRet As Long
    
    userRet = MsgBox("Using precise capture controls." & vbCrLf & _
                                    "PreRoll complete - Click OK to start capture immediately." _
                                    , vbOKCancel, App.Title)
    If userRet = vbOK Then
        ezVidCap1.PreciseCaptureStart
    Else
        ezVidCap1.PreciseCaptureCancel
    End If
End Sub

Private Sub ezVidCap1_StatusMessage(ByVal StatCode As Long, ByVal StatString As String)
lblStatusCode.Caption = "StatusCode: " & StatCode
lblStatusCode.Refresh
If StatCode <> 0 Then
    'Debug.Print StatString
    lblStatusString.Caption = StatString
    lblStatusString.Refresh
End If
End Sub
Private Sub EnableButtons()
    cmdAudioDlg.Enabled = False
    cmdFormatDlg.Enabled = False
    cmdDisplayDlg.Enabled = False
    cmdSourceDlg.Enabled = False
    cmdCapture.Enabled = False
    cmdCompDlg.Enabled = False
    
    With ezVidCap1
        If .NumCapDevs > 0 Then
            cmdCapture.Enabled = True
            cmdCompDlg.Enabled = True
        End If
        If .HasAudio Then cmdAudioDlg.Enabled = True
        If .HasDlgFormat Then cmdFormatDlg.Enabled = True
        If .HasDlgDisplay Then cmdDisplayDlg.Enabled = True
        If .HasDlgSource Then cmdSourceDlg.Enabled = True
    End With
End Sub

Private Sub ezVidCap1_VideoStreamCallback(ByVal lpVHdr As Long)
Debug.Print "Video stream: " & lpVHdr
End Sub

Private Sub ezVidCap1_WaveStreamCallback(ByVal lpWHdr As Long)
Debug.Print "Wave stream: " & lpWHdr
End Sub

Private Sub Form_Load()

'THE FOLLOWING 2 LINES ARE UNNECESSARY AFTER BETA2
'Me.Show 'control will not connect to capdevice until it is shown
'        'it must be initialized by being shown before you can read some of the properties
'DoEvents 'allows driver to connect

Dim i As Long

Call EnableButtons 'check device caps and enable appropriate btns
Me.Show 'show form
Me.Refresh
If 0 < ezVidCap1.NumCapDevs Then
    For i = 0 To ezVidCap1.NumCapDevs - 1
        cbDriver.AddItem (ezVidCap1.GetDriverName(i))
    Next
    cbDriver.ListIndex = ezVidCap1.DriverIndex
Else
    cbDriver.AddItem ("<none>")
    cbDriver.ListIndex = 0
    MsgBox "No Video Capture Device!", vbInformation, App.Title
End If

'init form with current properties
lblStatusCode = "Status Panel"
lblStatusString = ezVidCap1.GetDriverVersion()
txtWidth = ezVidCap1.Width
txtHeight = ezVidCap1.Height
chkAutoSize.Value = -(ezVidCap1.AutoSize)
chkCenter.Value = -(ezVidCap1.CenterVideo)
chkStretch.Value = -(ezVidCap1.StretchPreview)
chkAudio.Value = -(ezVidCap1.CaptureAudio)
chkPreRoll.Value = -(ezVidCap1.UsePreciseCaptureControls)
chkUserConfirm.Value = -(ezVidCap1.MakeUserConfirmCapture)
chkPreview.Value = -(ezVidCap1.Preview)
chkFrameCallback.Value = -(ezVidCap1.FrameEventEnabled)
End Sub

Private Sub Form_Resize()
'this is just to provide a nice status bar with no control
With picStatus
    lblStatusCode.Move 0, 0, .Width * 0.25, .Height
    lblStatusString.Move .Width * 0.25, 0, .Width * 0.75, .Height
End With

End Sub

