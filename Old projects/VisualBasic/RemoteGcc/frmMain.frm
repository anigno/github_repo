VERSION 5.00
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Object = "{6580F760-7819-11CF-B86C-444553540000}#1.0#0"; "EZFTP.OCX"
Begin VB.Form frmMain 
   Caption         =   "Remote gcc"
   ClientHeight    =   7356
   ClientLeft      =   132
   ClientTop       =   420
   ClientWidth     =   10488
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   7356
   ScaleWidth      =   10488
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdRun3 
      Caption         =   "Run no ftp"
      Height          =   312
      Left            =   2400
      TabIndex        =   11
      Top             =   1080
      Width           =   1092
   End
   Begin VB.CheckBox chkFtp1 
      Caption         =   "ftp"
      Height          =   372
      Left            =   3000
      TabIndex        =   14
      Top             =   720
      Value           =   1  'Checked
      Width           =   492
   End
   Begin VB.CheckBox chkFtp 
      Caption         =   "ftp"
      Height          =   372
      Left            =   3000
      TabIndex        =   13
      Top             =   360
      Value           =   1  'Checked
      Width           =   492
   End
   Begin VB.TextBox txtCommandLine3 
      Height          =   288
      Left            =   3600
      TabIndex        =   12
      Text            =   "gcc -ansi -pedantic -Wall file01.c -o file01_run"
      Top             =   1080
      Width           =   4932
   End
   Begin VB.TextBox txtCommandLine2 
      Height          =   288
      Left            =   3600
      TabIndex        =   10
      Text            =   "gcc -ansi -pedantic -Wall file01.c -o file01_run"
      Top             =   720
      Width           =   4932
   End
   Begin VB.CommandButton cmdRun2 
      Caption         =   "Run"
      Height          =   312
      Left            =   2400
      TabIndex        =   9
      Top             =   720
      Width           =   492
   End
   Begin VB.CommandButton cmdOpenTelnet 
      Caption         =   "Open new TELNET"
      Enabled         =   0   'False
      Height          =   492
      Left            =   840
      TabIndex        =   3
      Top             =   2880
      Width           =   852
   End
   Begin RichTextLib.RichTextBox RTF2 
      Height          =   612
      Left            =   2640
      TabIndex        =   8
      Top             =   1680
      Visible         =   0   'False
      Width           =   852
      _ExtentX        =   1503
      _ExtentY        =   1080
      _Version        =   393217
      Enabled         =   -1  'True
      TextRTF         =   $"frmMain.frx":0442
   End
   Begin VB.CommandButton cmdRun 
      Caption         =   "Run"
      Height          =   312
      Left            =   2400
      TabIndex        =   7
      Top             =   360
      Width           =   492
   End
   Begin VB.TextBox txtCommandLine 
      Height          =   288
      Left            =   3600
      TabIndex        =   6
      Text            =   "gcc -ansi -pedantic -Wall file01.c -o file01_run"
      Top             =   360
      Width           =   4932
   End
   Begin VB.ListBox lstAction 
      Height          =   3696
      Left            =   0
      TabIndex        =   5
      Top             =   3480
      Width           =   2412
   End
   Begin EZFTPLib.EZFTP FTP1 
      Left            =   3600
      Top             =   1680
      _Version        =   65536
      _ExtentX        =   800
      _ExtentY        =   800
      _StockProps     =   0
      LocalFile       =   ""
      RemoteFile      =   ""
      RemoteAddres    =   ""
      UserName        =   ""
      Password        =   ""
      Binary          =   -1  'True
      UseCache        =   -1  'True
   End
   Begin VB.CommandButton cmdOpenFTP 
      Caption         =   "OpenFTP"
      Height          =   492
      Left            =   0
      TabIndex        =   4
      Top             =   2880
      Width           =   852
   End
   Begin VB.FileListBox File1 
      Height          =   2568
      Left            =   0
      Pattern         =   "*.c;*.cpp;*.h;*.txt"
      TabIndex        =   1
      Top             =   240
      Width           =   2412
   End
   Begin RichTextLib.RichTextBox RTF1 
      Height          =   5892
      Left            =   2520
      TabIndex        =   0
      Top             =   1440
      Width           =   6012
      _ExtentX        =   10605
      _ExtentY        =   10393
      _Version        =   393217
      ScrollBars      =   3
      TextRTF         =   $"frmMain.frx":04D2
   End
   Begin VB.Label lblPath 
      Caption         =   "path"
      Height          =   252
      Left            =   0
      TabIndex        =   2
      Top             =   0
      Width           =   6132
   End
   Begin VB.Menu menuProject 
      Caption         =   "&Project"
      Begin VB.Menu menuChangeProjectDir 
         Caption         =   "Change project DIR"
         Shortcut        =   ^D
      End
      Begin VB.Menu menuFtpParameters 
         Caption         =   "Ftp and Telnet parameters"
         Shortcut        =   ^F
      End
      Begin VB.Menu menuSaveProjectParameters 
         Caption         =   "Save project parameters"
         Shortcut        =   ^P
      End
   End
   Begin VB.Menu menuFile 
      Caption         =   "&File"
      Begin VB.Menu menuNewFile 
         Caption         =   "New file"
      End
      Begin VB.Menu menuSaveCurrentFile 
         Caption         =   "Save current file"
         Shortcut        =   ^S
      End
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmdOpenFTP_Click()
On Error GoTo errorFtpConnect
    cmdOpenFTP.Caption = "WAIT"
    FTP1.RemoteAddress = ftpHost
    FTP1.UserName = ftpUsername
    FTP1.Password = ftpPassword
    FTP1.Connect
    cmdOpenTelnet.Enabled = True
    cmdOpenFTP.Enabled = False
    Exit Sub
errorFtpConnect:
    MsgBox "error open FTP, check parameters.", vbCritical
    cmdOpenFTP.Caption = "Open FTP"
End Sub

Private Sub cmdOpenTelnet_Click()
    TelnetNumber = Shell("telnet " & ftpHost, vbNormalFocus)
End Sub

Private Sub cmdRun_Click()
On Error GoTo errorRun
    saveFile File1, RTF1, currentFile
    If chkFtp.Value = 1 Then sendFiles File1, FTP1, lstAction, RTF1, RTF2
    AppActivate TelnetNumber
    SendKeys txtCommandLine.Text & "{enter}"
    Exit Sub
errorRun:
MsgBox "error, no telnet!, restart program or open telnet.", vbCritical
End Sub

Private Sub cmdRun2_Click()
On Error GoTo errorRun
    saveFile File1, RTF1, currentFile
    If chkFtp1.Value = 1 Then sendFiles File1, FTP1, lstAction, RTF1, RTF2
    AppActivate TelnetNumber
    SendKeys txtCommandLine2.Text & "{enter}"
    Exit Sub
errorRun:
MsgBox "error, no telnet!, restart program or open telnet.", vbCritical
End Sub

Private Sub cmdRun3_Click()
On Error GoTo errorRun
    saveFile File1, RTF1, currentFile
    'sendFiles File1, FTP1, lstAction, RTF1, RTF2
    AppActivate TelnetNumber
    SendKeys txtCommandLine3.Text & "{enter}"
    Exit Sub
errorRun:
MsgBox "error, no telnet!, restart program or open telnet.", vbCritical
End Sub



Private Sub File1_Click()
    replaceFiles File1, RTF1, currentFile, File1.List(File1.ListIndex)
End Sub

Private Sub Form_Load()
    setCurrentFile frmMain, "no file"
    lblPath.Caption = File1.Path
    ftpHost = GetSetting("remoteGcc", "param", "ftpHost", "study.haifa.ac.il")
    ftpUsername = GetSetting("remoteGcc", "param", "ftpUsername", "anigno")
    ftpPassword = GetSetting("remoteGcc", "param", "ftpPassword", "29024783")
    File1.Path = GetSetting("remoteGcc", "param", "projectDir", "c:\")
    txtCommandLine.Text = GetSetting("remoteGcc", "param", "run", "gcc -ansi -pedantic -Wall source.c -o run_file")
    txtCommandLine2.Text = GetSetting("remoteGcc", "param", "run2", "gcc -ansi -pedantic -Wall source.c -o run_file")
    txtCommandLine3.Text = GetSetting("remoteGcc", "param", "run3", "gcc -ansi -pedantic -Wall source.c -o run_file")
End Sub

Private Sub Form_Unload(Cancel As Integer)
    FTP1.Disconnect
    SaveSetting "remoteGcc", "param", "run", frmMain.txtCommandLine.Text
    SaveSetting "remoteGcc", "param", "run2", frmMain.txtCommandLine2.Text
    SaveSetting "remoteGcc", "param", "run3", frmMain.txtCommandLine3.Text
    saveFile File1, RTF1, currentFile
End Sub

Private Sub menuChangeProjectDir_Click()
    frmMain.Enabled = False
    frmSelectDir.Show
End Sub

Private Sub menuFtpParameters_Click()
    frmMain.Enabled = False
    frmFtp.Show
End Sub

Private Sub menuNewFile_Click()
    createNewFile frmMain, File1, RTF1
End Sub

Private Sub menuSaveCurrentFile_Click()
    saveFile File1, RTF1, currentFile
End Sub


