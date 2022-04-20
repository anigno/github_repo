VERSION 5.00
Object = "{3B00B10A-6EF0-11D1-A6AA-0020AFE4DE54}#1.0#0"; "Mp3play.ocx"
Object = "{03CD039A-2FDD-4BFE-8CB8-5C0BDF9A88D3}#14.0#0"; "FindFilesOcx.ocx"
Begin VB.Form frmMain 
   BackColor       =   &H00808000&
   Caption         =   "RadioMp3"
   ClientHeight    =   4092
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   6864
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   4092
   ScaleWidth      =   6864
   StartUpPosition =   2  'CenterScreen
   Begin FindFilesOcx.FindFiles FindFiles1 
      Height          =   612
      Left            =   8040
      TabIndex        =   20
      Top             =   1920
      Width           =   612
      _ExtentX        =   1080
      _ExtentY        =   1080
   End
   Begin MPEGPLAYLib.Mp3Play Mp3Play1 
      Height          =   612
      Left            =   7440
      TabIndex        =   19
      Top             =   360
      Width           =   612
      _Version        =   65536
      _ExtentX        =   1080
      _ExtentY        =   1080
      _StockProps     =   0
   End
   Begin VB.CommandButton cmdExit 
      BackColor       =   &H000080FF&
      Caption         =   "EXIT"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   252
      Left            =   2040
      Style           =   1  'Graphical
      TabIndex        =   11
      Top             =   360
      Width           =   612
   End
   Begin VB.TextBox txtFind 
      BackColor       =   &H008080FF&
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   372
      Left            =   1800
      TabIndex        =   18
      Text            =   "txtFind"
      Top             =   3480
      Visible         =   0   'False
      Width           =   3012
   End
   Begin VB.CommandButton cmdSelected 
      BackColor       =   &H008080FF&
      Caption         =   "Selected only"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   612
      Left            =   960
      Style           =   1  'Graphical
      TabIndex        =   16
      Top             =   3480
      Width           =   852
   End
   Begin VB.CommandButton cmdFilesBrowser 
      BackColor       =   &H008080FF&
      Caption         =   "Files browser"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   612
      Left            =   0
      Style           =   1  'Graphical
      TabIndex        =   15
      Top             =   3480
      Width           =   972
   End
   Begin VB.CommandButton cmdCounterDec 
      BackColor       =   &H00808000&
      Height          =   252
      Left            =   3120
      Picture         =   "frmMain.frx":0442
      Style           =   1  'Graphical
      TabIndex        =   14
      Top             =   840
      Width           =   252
   End
   Begin VB.CommandButton CmdCounterInc 
      BackColor       =   &H00808000&
      Height          =   252
      Left            =   5520
      Picture         =   "frmMain.frx":0884
      Style           =   1  'Graphical
      TabIndex        =   13
      Top             =   840
      Width           =   252
   End
   Begin VB.CommandButton cmdFastForward 
      BackColor       =   &H00FF8080&
      Caption         =   ">>"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   252
      Left            =   960
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   120
      Width           =   372
   End
   Begin VB.CommandButton cmdAgain 
      BackColor       =   &H00FF8080&
      Caption         =   "Again"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   252
      Left            =   360
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   240
      Width           =   612
   End
   Begin VB.CommandButton cmdNext 
      BackColor       =   &H00FF8080&
      Caption         =   "Next"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   252
      Left            =   360
      Style           =   1  'Graphical
      TabIndex        =   3
      Top             =   0
      Width           =   612
   End
   Begin VB.Timer tmrPlay 
      Interval        =   250
      Left            =   7440
      Top             =   3720
   End
   Begin VB.ComboBox cmbDirList 
      BackColor       =   &H00FF8080&
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   348
      Left            =   1440
      TabIndex        =   5
      Top             =   0
      Width           =   5412
   End
   Begin VB.CommandButton cmdFastRewind 
      BackColor       =   &H00FF8080&
      Caption         =   "<<"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   252
      Left            =   0
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   120
      Width           =   372
   End
   Begin VB.ListBox lstPlayList 
      BackColor       =   &H00FF8080&
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   2316
      Left            =   0
      MultiSelect     =   1  'Simple
      TabIndex        =   4
      Top             =   1080
      Width           =   6852
   End
   Begin VB.CommandButton cmdFind 
      BackColor       =   &H008080FF&
      Caption         =   "Find"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   252
      Left            =   1800
      Style           =   1  'Graphical
      TabIndex        =   17
      Top             =   3840
      Width           =   732
   End
   Begin VB.CommandButton cmdStop 
      BackColor       =   &H008080FF&
      Caption         =   "Stop"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   252
      Left            =   1440
      Style           =   1  'Graphical
      TabIndex        =   9
      Top             =   360
      Width           =   612
   End
   Begin VB.Label lblBUDGITA 
      BackColor       =   &H00000000&
      Caption         =   "BUDGITA."
      BeginProperty Font 
         Name            =   "MS Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   252
      Left            =   5880
      TabIndex        =   6
      ToolTipText     =   "גינה רוני saharon@yahoo.com"
      Top             =   3480
      Width           =   972
   End
   Begin VB.Label lblSongsLeft 
      Alignment       =   2  'Center
      BackColor       =   &H00FF8080&
      BackStyle       =   0  'Transparent
      Caption         =   "Songs left : 000"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   252
      Left            =   3360
      TabIndex        =   12
      Top             =   840
      Width           =   2052
   End
   Begin VB.Label lblSong 
      Alignment       =   2  'Center
      BackColor       =   &H00FF8080&
      BackStyle       =   0  'Transparent
      Caption         =   "No song selected"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FF00&
      Height          =   372
      Left            =   0
      TabIndex        =   10
      Top             =   600
      Width           =   6852
   End
   Begin VB.Label lblTime 
      Alignment       =   2  'Center
      BackColor       =   &H00FF8080&
      BackStyle       =   0  'Transparent
      Caption         =   "000/000"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   252
      Left            =   1560
      TabIndex        =   8
      Top             =   840
      Width           =   1452
   End
   Begin VB.Label lblNumberOfSongs 
      BackColor       =   &H00FF8080&
      BackStyle       =   0  'Transparent
      Caption         =   "000 Songs"
      BeginProperty Font 
         Name            =   "Tahoma"
         Size            =   10.2
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   252
      Left            =   120
      TabIndex        =   7
      Top             =   840
      Width           =   1332
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmbDirList_Change()
    'update lstPlayList
    UpdatePlayList lstPlayList, FindFiles1, "*.mp3", cmbDirList
End Sub

Private Sub cmbDirList_Click()
    'call cmbDirList_Change to update lstPlayList
    cmbDirList_Change
    lstPlayList.SetFocus
End Sub

Private Sub cmdAgain_Click()
    Mp3Play1.Seek (0)
    lstPlayList.SetFocus
End Sub

Private Sub cmdCounterDec_Click()
    SongsLeft = Int(SongsLeft * 0.5)
    lstPlayList.SetFocus
End Sub

Private Sub CmdCounterInc_Click()
    SongsLeft = Int(SongsLeft * 2)
    If SongsLeft = 0 Then SongsLeft = 1
    lstPlayList.SetFocus
End Sub

Private Sub cmdExit_Click()
    End
End Sub

Private Sub cmdFastForward_Click()
    Dim a As Integer
    a = Mp3Play1.PlayPosition
    Mp3Play1.Seek (a + 1000)
    lstPlayList.SetFocus
End Sub

Private Sub cmdFastRewind_Click()
    Dim a As Integer
    a = Mp3Play1.PlayPosition
    Mp3Play1.Seek (a - 1000)
    lstPlayList.SetFocus
End Sub

Private Sub cmdFilesBrowser_Click()
    frmBrowser.Show
    Unload frmMain
End Sub

Private Sub cmdFind_Click()
    Dim a As Integer
    txtFind.Visible = True
    txtFind.SetFocus
    txtFind.Text = ""
    'will update FindFiles.listfiles from MAINDIR
    FindFiles1.FindFiles "*.mp3", MAINDIR
    '(next- user must enter string in txtFind control to search for)
End Sub

Private Sub cmdNext_Click()
    If SongSent = False Then
        'SongSent = True
        PlaySong SelectSong(lstPlayList), Mp3Play1
    End If
    lstPlayList.SetFocus
End Sub

Private Sub cmdSelected_Click()
    Dim a As Integer
    For a = 0 To ListMax - 1
        SongPlayed(a) = True
        If lstPlayList.Selected(a) = True Then SongPlayed(a) = False
    Next a
    cmdNext_Click
    lstPlayList.SetFocus
End Sub

Private Sub cmdStop_Click()
    Mp3Play1.Stop
    If AutoMode = True Then
        AutoMode = False
        cmdStop.Caption = "Continue"
    Else
        AutoMode = True
        cmdStop.Caption = "Stop"
    End If
End Sub


Private Sub Form_Load()
    Dim a As Integer
    'authorize mp3play control
    Mp3Play1.Authorize "saharon", "326221192"
    'update cmbDirList with dir's in "c:\radio" dir
    UpdateDirCombo cmbDirList, FindFiles1
    AutoMode = True
    SongsLeft = 1000
    Randomize
End Sub

Private Sub lstPlayList_DblClick()
    PlaySong lstPlayList.List(lstPlayList.ListIndex), Mp3Play1
End Sub

Private Sub tmrPlay_Timer()
    'update lblNumberOfSongs with ListMax number
    lblNumberOfSongs.Caption = ListMax & " Songs"
    'update lblTime
    lblTime.Caption = CalcTimeString(Mp3Play1)
    'check for Automode enable to auto select new songs
    If AutoMode = True Then
        If Mp3Play1.GetStatus <> 1 Then
            If SongsLeft > 0 Then
                'will send only if no song already been sent
                '{this is because of doEvents in PlaySong()
                ' to prevent recoursive call to playSong in auto mode}
                If SongSent = False Then cmdNext_Click
            End If
        End If
    End If
    'update lblSong
    lblSong.Caption = SongName
    If SongsLeft < 0 Then SongsLeft = 0
    If SongsLeft > 999 Then SongsLeft = 999
    lblSongsLeft.Caption = "Songs left : " & SongsLeft
End Sub

Private Sub txtFind_KeyPress(KeyAscii As Integer)
    Dim a, SongsFound As Integer
    Dim S As String
    Dim Srch As String
    Srch = txtFind.Text
    If KeyAscii = 13 Then
        S = txtFind.Text
        If S <> "" Then
            For a = 0 To FindFiles1.ListFilesCount - 1
                If InStr(1, FindFiles1.ListFiles(a), Srch, 1) <> 0 Then
                    lstPlayList.AddItem FindFiles1.ListFiles(a), 0
                    lstPlayList.Selected(0) = True
                    SongsFound = SongsFound + 1
                End If
            Next a
        ListMax = ListMax + SongsFound
        ReDim SongPlayed(ListMax)
        End If
        txtFind.Visible = False
        lstPlayList.SetFocus
    End If
End Sub
