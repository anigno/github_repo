VERSION 5.00
Object = "{6580F760-7819-11CF-B86C-444553540000}#1.0#0"; "EZFTP.OCX"
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.3#0"; "COMCTL32.OCX"
Begin VB.Form Main 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Easy FTP OLE Control Demo"
   ClientHeight    =   4920
   ClientLeft      =   2256
   ClientTop       =   1656
   ClientWidth     =   6984
   Icon            =   "FTP.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4920
   ScaleWidth      =   6984
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton Exit 
      Caption         =   "E&xit"
      Height          =   375
      Left            =   5880
      TabIndex        =   21
      Top             =   4500
      Width           =   1035
   End
   Begin VB.CommandButton About 
      Caption         =   "&About"
      Height          =   375
      Left            =   60
      TabIndex        =   20
      Top             =   4500
      Width           =   1035
   End
   Begin VB.OptionButton ASCIIMode 
      Caption         =   "ASCII"
      Height          =   195
      Left            =   3540
      TabIndex        =   19
      Top             =   4560
      Width           =   855
   End
   Begin VB.OptionButton BinaryMode 
      Caption         =   "Binary"
      Height          =   195
      Left            =   2520
      TabIndex        =   18
      Top             =   4560
      Value           =   -1  'True
      Width           =   855
   End
   Begin VB.CommandButton ToRemote 
      Caption         =   "-->"
      Height          =   375
      Left            =   3240
      TabIndex        =   3
      Top             =   1980
      Width           =   495
   End
   Begin VB.CommandButton ToLocal 
      Caption         =   "<--"
      Height          =   375
      Left            =   3240
      TabIndex        =   2
      Top             =   1320
      Width           =   495
   End
   Begin VB.Frame Remote 
      Caption         =   "Remote System"
      Height          =   4335
      Left            =   3840
      TabIndex        =   1
      Top             =   60
      Width           =   3075
      Begin VB.CommandButton RemoteDEL 
         Caption         =   "DEL"
         Height          =   315
         Left            =   2460
         TabIndex        =   17
         Top             =   1800
         Width           =   495
      End
      Begin VB.CommandButton RemoteMD 
         Caption         =   "MD"
         Height          =   315
         Left            =   2460
         TabIndex        =   15
         Top             =   1380
         Width           =   495
      End
      Begin VB.CommandButton RemoteRD 
         Caption         =   "RD"
         Height          =   315
         Left            =   2460
         TabIndex        =   14
         Top             =   1020
         Width           =   495
      End
      Begin VB.CommandButton RemoteCD 
         Caption         =   "CD"
         Height          =   315
         Left            =   2460
         TabIndex        =   13
         Top             =   660
         Width           =   495
      End
      Begin VB.ListBox RemoteFiles 
         Height          =   2352
         Left            =   180
         TabIndex        =   12
         Top             =   1800
         Width           =   2235
      End
      Begin VB.ListBox RemoteDirectories 
         Height          =   1008
         Left            =   180
         TabIndex        =   11
         Top             =   660
         Width           =   2235
      End
      Begin VB.Label RemotePWD 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   180
         TabIndex        =   5
         Top             =   300
         Width           =   2715
      End
   End
   Begin VB.Frame Local 
      Caption         =   "Local System"
      Height          =   4335
      Left            =   60
      TabIndex        =   0
      Top             =   60
      Width           =   3075
      Begin VB.CommandButton LocalDEL 
         Caption         =   "DEL"
         Height          =   315
         Left            =   2460
         TabIndex        =   16
         Top             =   1800
         Width           =   495
      End
      Begin VB.CommandButton LocalMD 
         Caption         =   "MD"
         Height          =   315
         Left            =   2460
         TabIndex        =   10
         Top             =   1380
         Width           =   495
      End
      Begin VB.CommandButton LocalRD 
         Caption         =   "RD"
         Height          =   315
         Left            =   2460
         TabIndex        =   9
         Top             =   1020
         Width           =   495
      End
      Begin VB.CommandButton LocalCD 
         Caption         =   "CD"
         Height          =   315
         Left            =   2460
         TabIndex        =   8
         Top             =   660
         Width           =   495
      End
      Begin VB.ListBox LocalFiles 
         Height          =   2352
         Left            =   180
         TabIndex        =   7
         Top             =   1800
         Width           =   2235
      End
      Begin VB.ListBox LocalDirectories 
         Height          =   1008
         Left            =   180
         TabIndex        =   6
         Top             =   660
         Width           =   2235
      End
      Begin VB.Label LocalPWD 
         BorderStyle     =   1  'Fixed Single
         Height          =   255
         Left            =   180
         TabIndex        =   4
         Top             =   300
         Width           =   2715
      End
   End
   Begin ComctlLib.ProgressBar ProgressBar 
      Height          =   195
      Left            =   1380
      TabIndex        =   22
      Top             =   4560
      Visible         =   0   'False
      Width           =   4395
      _ExtentX        =   7747
      _ExtentY        =   339
      _Version        =   327682
      Appearance      =   1
   End
   Begin EZFTPLib.EZFTP FTP 
      Left            =   3300
      Top             =   2520
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
End
Attribute VB_Name = "Main"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim FirstTime As Boolean
Dim CancelFlag As Boolean
Sub RefreshAll()

    RefreshLocal
    RefreshRemote
    
End Sub


Sub RefreshLocal()

    Screen.MousePointer = vbHourglass

'Local Directories and Files
Dim NextLocal As String
Dim FullSpec As String
    
    LocalPWD.Caption = CurDir()

    LocalDirectories.Clear
    LocalFiles.Clear
'    LocalDirectories.Sorted = False
'    LocalFiles.Sorted = False
    If Len(CurDir()) = 3 Then
        FullSpec = CurDir() & "*.*"
    Else
        FullSpec = CurDir() & "\*.*"
    End If
    NextLocal = Dir(FullSpec, vbDirectory + vbNormal)
    Do While NextLocal <> ""
        If Len(CurDir()) = 3 Then
            FullSpec = CurDir() & NextLocal
        Else
            FullSpec = CurDir() & "\" & NextLocal
        End If
        On Error Resume Next
        If (GetAttr(FullSpec) And vbDirectory) = vbDirectory Then
            LocalDirectories.AddItem NextLocal
        Else
            LocalFiles.AddItem NextLocal
        End If
        NextLocal = Dir
    Loop
'    LocalDirectories.Sorted = True
'    LocalFiles.Sorted = True
    
    Screen.MousePointer = vbDefault

End Sub

Sub RefreshRemote()
    
    Screen.MousePointer = vbHourglass
    
'Remote Directories and Files (done in the FTP NextDirectoryEntry event)
    RemotePWD.Caption = FTP.RemoteDirectory
    
    RemoteDirectories.Clear
    RemoteFiles.Clear
    FTP.GetDirectory ("*.*")

    Screen.MousePointer = vbDefault

End Sub

Private Sub About_Click()

    If About.Caption = "&About" Then
        AboutBox.Show vbModal
    Else
        CancelFlag = True
    End If

End Sub

Private Sub ASCIIMode_Click()

    If ASCIIMode.Value = True Then
        FTP.Binary = False
    End If
    
End Sub

Private Sub BinaryMode_Click()

    If BinaryMode.Value = True Then
        FTP.Binary = True
    End If
    
End Sub

Private Sub Exit_Click()

    Unload Me
    
End Sub

Private Sub Form_Activate()

    If FirstTime = False Then
        FirstTime = True
        DoEvents ' give the form a chance to paint
        RefreshAll
    End If
        
End Sub

Private Sub Form_Load()
    
    Me.Move (Screen.Width \ 2) - (Me.Width \ 2), (Screen.Height \ 2) - (Me.Height \ 2)
    FirstTime = False
    FTP.Binary = True
    FTP.UseCache = False
    
End Sub


Private Sub Form_Unload(Cancel As Integer)

    FTP.Disconnect
    
End Sub



Private Sub FTP_NextDirectoryEntry(ByVal FileName As String, ByVal Attributes As Long, ByVal Length As Double)

    If (Attributes And 16) = 16 Or Attributes = 0 Then
        RemoteDirectories.AddItem FileName
    Else
        RemoteFiles.AddItem FileName
    End If
    
End Sub



Private Sub FTP_TransferProgress(ByVal BytesTransferred As Long, ByVal TotalBytes As Long)

    If CancelFlag = True Then
        FTP.CancelTransfer = True
    End If
    
    If ProgressBar.Max = 1 Then
        ProgressBar.Max = TotalBytes
    End If
    ProgressBar.Value = BytesTransferred
    DoEvents ' to give the cancel button a chance

End Sub


Private Sub LocalCD_Click()

Dim NewDirectory As String

    NewDirectory = InputBox$("Enter directory to change to")
    If NewDirectory = "" Then
        Exit Sub
    End If

    On Error Resume Next
    ChDir NewDirectory
    If Err <> 0 Then
        MsgBox "Unable to change directory", vbExclamation
    Else
        RefreshLocal
    End If
    
End Sub

Private Sub LocalDEL_Click()
    
    If LocalFiles.ListIndex = -1 Then
        Beep
        Exit Sub
    End If
    
    On Error Resume Next
    Kill LocalFiles.Text
    If Err <> 0 Then
        MsgBox "Unable to delete local file", vbExclamation
    Else
        RefreshLocal
    End If

End Sub

Private Sub LocalDirectories_DblClick()

    If LocalDirectories.ListIndex = -1 Then
        Beep
        Exit Sub
    End If
    ChDir LocalDirectories.Text
    RefreshLocal
    
End Sub


Private Sub LocalFiles_DblClick()

    ToRemote.Value = 1
    
End Sub


Private Sub LocalMD_Click()

Dim NewDirectory As String
    
    NewDirectory = InputBox$("Enter new directory name")
    If NewDirectory = "" Then
        Exit Sub
    End If
    
    On Error Resume Next
    MkDir NewDirectory
    If Err <> 0 Then
        MsgBox "Unable to make local directory", vbExclamation
    Else
        RefreshLocal
    End If

End Sub

Private Sub LocalRD_Click()
    
    If LocalDirectories.ListIndex = -1 Then
        Beep
        Exit Sub
    End If
    
    On Error Resume Next
    RmDir LocalDirectories.Text
    If Err <> 0 Then
        MsgBox "Unable to remove local directory", vbExclamation
    Else
        RefreshLocal
    End If

End Sub

Private Sub RemoteCD_Click()

Dim NewDirectory As String

    NewDirectory = InputBox$("Enter directory to change to")
    If NewDirectory = "" Then
        Exit Sub
    End If
    
    On Error Resume Next
    FTP.RemoteDirectory = NewDirectory
    If Err <> 0 Then
        MsgBox "Unable to change directory", vbExclamation
    Else
        RefreshRemote
    End If
        
End Sub

Private Sub RemoteDEL_Click()

    If RemoteFiles.ListIndex = -1 Then
        Beep
        Exit Sub
    End If
    
    On Error Resume Next
    FTP.DeleteFile RemoteFiles.Text
    If Err <> 0 Then
        MsgBox "Unable to delete remote file", vbExclamation
    Else
        RefreshRemote
    End If
    
End Sub

Private Sub RemoteDirectories_DblClick()

    On Error Resume Next
    FTP.RemoteDirectory = RemoteDirectories.Text
    If Err <> 0 Then
        MsgBox "Unable to change directory", vbExclamation
    Else
        RefreshRemote
    End If
    
End Sub


Private Sub RemoteFiles_DblClick()

    ToLocal.Value = 1
    
End Sub


Private Sub RemoteMD_Click()

Dim NewDirectory As String
    
    NewDirectory = InputBox$("Enter new directory name")
    If NewDirectory = "" Then
        Exit Sub
    End If
    
    On Error Resume Next
    FTP.MkDir NewDirectory
    If Err <> 0 Then
        MsgBox "Unable to make remote directory", vbExclamation
    Else
        RefreshRemote
    End If
    

End Sub

Private Sub RemoteRD_Click()

    If RemoteDirectories.ListIndex = -1 Then
        Beep
        Exit Sub
    End If
    
    On Error Resume Next
    FTP.RmDir RemoteDirectories.Text
    If Err <> 0 Then
        MsgBox "Unable to remove remote directory", vbExclamation
    Else
        RefreshRemote
    End If
    
End Sub

Private Sub ToLocal_Click()

    If RemoteFiles.ListIndex = -1 Then
        Beep
        Exit Sub
    End If
    
    FTP.RemoteFile = RemoteFiles.Text
    FTP.LocalFile = RemoteFiles.Text
    Screen.MousePointer = vbHourglass
    
'Fancy stuff for the Pro Edition
    If FTP.ProfessionalEdition = True Then
        BinaryMode.Visible = False
        ASCIIMode.Visible = False
        ProgressBar.Visible = True
        ProgressBar.Value = 0
        ProgressBar.Max = 1
        CancelFlag = False
        About.Caption = "&Cancel"
        DoEvents
    End If
    
    On Error Resume Next
    FTP.GetFile
    Screen.MousePointer = vbDefault
    If Err <> 0 Then
        MsgBox "Unable to transfer from remote system", vbExclamation
    Else
        If CancelFlag = True Then
            On Error GoTo 0
            Screen.MousePointer = vbHourglass
            FTP.Disconnect
            FTP.Connect
            FTP.RemoteDirectory = RemotePWD.Caption
            CancelFlag = False
            Screen.MousePointer = vbDefault
        End If
        Beep
        RefreshLocal
    End If
    
    If FTP.ProfessionalEdition = True Then
        BinaryMode.Visible = True
        ASCIIMode.Visible = True
        ProgressBar.Visible = False
        About.Caption = "&About"
    End If
    
End Sub


Private Sub ToRemote_Click()

    If LocalFiles.ListIndex = -1 Then
        Beep
        Exit Sub
    End If
    
    FTP.LocalFile = LocalFiles.Text
    FTP.RemoteFile = LocalFiles.Text

'Fancy stuff for the Pro Edition
    If FTP.ProfessionalEdition = True Then
        BinaryMode.Visible = False
        ASCIIMode.Visible = False
        ProgressBar.Visible = True
        ProgressBar.Value = 0
        ProgressBar.Max = 1
        CancelFlag = False
        About.Caption = "&Cancel"
        DoEvents
    End If
    
    Screen.MousePointer = vbHourglass
    On Error Resume Next
    FTP.PutFile
    Screen.MousePointer = vbDefault
    If Err <> 0 Then
        MsgBox "Unable to transfer to remote system", vbExclamation
    Else
        If CancelFlag = True Then
            On Error GoTo 0
            Screen.MousePointer = vbHourglass
            FTP.Disconnect
            FTP.Connect
            FTP.RemoteDirectory = RemotePWD.Caption
            CancelFlag = False
            Screen.MousePointer = vbDefault
        End If
        Beep
        RefreshRemote
    End If
    
    If FTP.ProfessionalEdition = True Then
        BinaryMode.Visible = True
        ASCIIMode.Visible = True
        ProgressBar.Visible = False
        About.Caption = "&About"
    End If
    
End Sub


