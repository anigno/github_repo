VERSION 5.00
Object = "{9A03465D-3CA7-4DAA-9024-7738C42A706E}#1.2#0"; "ImpulseMP3.ocx"
Object = "{AC84AB1F-E6DA-11D2-A382-CDAF7A2D9501}#6.0#0"; "EzyID3.ocx"
Begin VB.Form frmMain 
   Caption         =   "File name changer V2"
   ClientHeight    =   6564
   ClientLeft      =   48
   ClientTop       =   348
   ClientWidth     =   11376
   LinkTopic       =   "Form1"
   ScaleHeight     =   6564
   ScaleWidth      =   11376
   StartUpPosition =   2  'CenterScreen
   Begin vbpEzyID3.EzyID3 EzyID31 
      Left            =   9600
      Top             =   2280
      _ExtentX        =   1016
      _ExtentY        =   1016
   End
   Begin ImpulseMP3.ISMP3Player ISMP3Player1 
      Left            =   8880
      Top             =   2400
      _ExtentX        =   677
      _ExtentY        =   677
   End
   Begin VB.TextBox txtList 
      Height          =   288
      Left            =   5760
      TabIndex        =   20
      Top             =   2880
      Width           =   5532
   End
   Begin VB.TextBox txtPattern 
      Height          =   288
      Left            =   3720
      TabIndex        =   18
      Text            =   "*"
      Top             =   120
      Width           =   612
   End
   Begin VB.CommandButton cmdRunAction 
      Caption         =   "Run action"
      Height          =   372
      Left            =   4560
      TabIndex        =   15
      Top             =   2640
      Width           =   972
   End
   Begin VB.PictureBox Mp3Play1 
      Height          =   612
      Left            =   10680
      ScaleHeight     =   564
      ScaleWidth      =   564
      TabIndex        =   14
      Top             =   0
      Width           =   612
   End
   Begin VB.Frame Frame1 
      Caption         =   "Action"
      Height          =   2172
      Left            =   4560
      TabIndex        =   4
      Top             =   120
      Width           =   6492
      Begin VB.OptionButton optAction 
         Caption         =   "Set mp3 tag"
         Height          =   252
         Index           =   5
         Left            =   1680
         TabIndex        =   19
         Top             =   720
         Width           =   1092
      End
      Begin VB.TextBox Text2 
         Height          =   288
         Left            =   600
         TabIndex        =   13
         Top             =   1800
         Width           =   5772
      End
      Begin VB.TextBox Text1 
         Height          =   288
         Left            =   600
         TabIndex        =   12
         Top             =   1440
         Width           =   5772
      End
      Begin VB.CheckBox chkTestOnly 
         Caption         =   "Test only"
         Height          =   252
         Left            =   120
         TabIndex        =   10
         Top             =   1080
         Value           =   1  'Checked
         Width           =   972
      End
      Begin VB.OptionButton optAction 
         Caption         =   "By mp3 tag"
         Height          =   252
         Index           =   4
         Left            =   1680
         TabIndex        =   9
         Top             =   480
         Width           =   1092
      End
      Begin VB.OptionButton optAction 
         Caption         =   "Manual edit"
         Height          =   252
         Index           =   3
         Left            =   1680
         TabIndex        =   8
         Top             =   240
         Width           =   1092
      End
      Begin VB.OptionButton optAction 
         Caption         =   "Add text"
         Height          =   252
         Index           =   2
         Left            =   120
         TabIndex        =   7
         Top             =   720
         Width           =   972
      End
      Begin VB.OptionButton optAction 
         Caption         =   "Replace chars"
         Height          =   252
         Index           =   1
         Left            =   120
         TabIndex        =   6
         Top             =   480
         Width           =   1332
      End
      Begin VB.OptionButton optAction 
         Caption         =   "Del chars"
         Height          =   252
         Index           =   0
         Left            =   120
         TabIndex        =   5
         Top             =   240
         Value           =   -1  'True
         Width           =   972
      End
      Begin VB.Label Label2 
         Caption         =   "input 2"
         Height          =   252
         Left            =   120
         TabIndex        =   17
         Top             =   1800
         Width           =   492
      End
      Begin VB.Label Label1 
         Caption         =   "input 1"
         Height          =   252
         Left            =   120
         TabIndex        =   16
         Top             =   1440
         Width           =   492
      End
      Begin VB.Label lblActionMsg 
         Caption         =   "Delete chars at position ( input 1) to (input 2)"
         Height          =   252
         Left            =   1320
         TabIndex        =   11
         Top             =   1080
         Width           =   4812
      End
   End
   Begin VB.ListBox List1 
      Appearance      =   0  'Flat
      Height          =   2520
      Left            =   5760
      TabIndex        =   3
      Top             =   3240
      Width           =   5532
   End
   Begin VB.FileListBox File1 
      Appearance      =   0  'Flat
      Height          =   2520
      Hidden          =   -1  'True
      Left            =   120
      MultiSelect     =   2  'Extended
      System          =   -1  'True
      TabIndex        =   2
      Top             =   3240
      Width           =   5532
   End
   Begin VB.DirListBox Dir1 
      Appearance      =   0  'Flat
      Height          =   2664
      Left            =   120
      TabIndex        =   1
      Top             =   480
      Width           =   4332
   End
   Begin VB.DriveListBox Drive1 
      Appearance      =   0  'Flat
      Height          =   288
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   3492
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmdRunAction_Click()
    runAction Dir1, File1, List1, Text1.Text, Text2.Text, chkTestOnly.Value, ISMP3Player1, EzyID31
End Sub

Private Sub Dir1_Change()
    On Error GoTo errorNoDir
    File1.Path = Dir1.Path
    Exit Sub
errorNoDir:
    MsgBox "Error, path not found!", vbCritical
End Sub

Private Sub Drive1_Change()
On Error GoTo errorNoDrive
    Dir1.Path = Drive1.Drive
    Exit Sub
errorNoDrive:
    MsgBox "Error, drive not ready!", vbCritical
End Sub

Private Sub File1_Click()
    Dim a As Integer
    'add selected file name to text1 if action is 3, manual edit
    If ActionSet = 3 Then
        For a = 0 To File1.ListCount - 1
            If File1.Selected(a) = True Then
                Text1.Text = File1.List(a)
            End If
        Next a
    End If
End Sub

Private Sub Form_Load()
    'authorise mp3player control
'    Mp3Play1.Authorize "saharon", "326221192"
    'init controls and globals
    ActionSet = 0
    chkTestOnly.Value = 1
End Sub

Private Sub List1_Click()
    txtList.Text = List1.List(List1.ListIndex)
End Sub

Private Sub optAction_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    'will set the action to be performed
    ActionSet = Index
    Select Case Index
        Case 0
            lblActionMsg.Caption = "Delete chars at position (input1) to (input2)"
        Case 1
            lblActionMsg.Caption = "Replace chars at (input1) with chars at (input2)"
        Case 2
            lblActionMsg.Caption = "Add text (input1) at position (input2)"
        Case 3
            lblActionMsg.Caption = "Select file name, edit at (input1) and Run action"
            File1.Refresh
        Case 4
            lblActionMsg.Caption = "mp3 tag will work only on mp3 files"
            txtPattern.Text = "*.mp3"
    End Select
End Sub

Private Sub Text1_GotFocus()
    Text1.SelStart = 0: Text1.SelLength = Len(Text1.Text)
End Sub

Private Sub Text1_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then cmdRunAction.SetFocus
End Sub

Private Sub Text2_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then cmdRunAction.SetFocus
End Sub

Private Sub Text2_GotFocus()
    Text2.SelStart = 0: Text2.SelLength = Len(Text2.Text)
End Sub

Private Sub txtPattern_Change()
    On Error GoTo ERROR01
    File1.Pattern = txtPattern.Text
    File1.Refresh
    Exit Sub
ERROR01:
    MsgBox "ERROR!, file pattern.", vbCritical
End Sub
