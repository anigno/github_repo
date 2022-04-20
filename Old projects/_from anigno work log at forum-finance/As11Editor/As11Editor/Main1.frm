VERSION 5.00
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Main1 
   Caption         =   "As11Editor"
   ClientHeight    =   7800
   ClientLeft      =   132
   ClientTop       =   708
   ClientWidth     =   11964
   Icon            =   "Main1.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   7800
   ScaleWidth      =   11964
   StartUpPosition =   3  'Windows Default
   WindowState     =   2  'Maximized
   Begin VB.TextBox Text1 
      Height          =   285
      Left            =   5160
      TabIndex        =   16
      TabStop         =   0   'False
      Text            =   "-f"
      Top             =   120
      Width           =   615
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Show List"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   10440
      TabIndex        =   15
      TabStop         =   0   'False
      Top             =   4920
      Width           =   1215
   End
   Begin VB.HScrollBar HScroll1 
      Height          =   255
      Left            =   10440
      Max             =   5
      TabIndex        =   12
      TabStop         =   0   'False
      Top             =   1440
      Value           =   3
      Width           =   1215
   End
   Begin VB.Timer Timer1 
      Interval        =   20
      Left            =   9120
      Top             =   0
   End
   Begin VB.Frame Frame2 
      Caption         =   "FILES"
      Height          =   1215
      Left            =   10440
      TabIndex        =   9
      Top             =   2160
      Width           =   1215
      Begin VB.CommandButton LoadFileButton 
         Caption         =   "LoadFile"
         Height          =   375
         Index           =   0
         Left            =   120
         TabIndex        =   11
         TabStop         =   0   'False
         Top             =   240
         Width           =   975
      End
      Begin VB.CommandButton SaveFileButton 
         Caption         =   "SaveFile"
         Height          =   375
         Index           =   1
         Left            =   120
         TabIndex        =   10
         TabStop         =   0   'False
         Top             =   720
         Width           =   975
      End
   End
   Begin MSComDlg.CommonDialog File 
      Left            =   8520
      Top             =   0
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      Filter          =   "*.s11|*.s11|*.*|*.*"
   End
   Begin VB.CommandButton Exit 
      Caption         =   "Exit"
      Height          =   255
      Index           =   0
      Left            =   10920
      TabIndex        =   4
      TabStop         =   0   'False
      Top             =   120
      Width           =   735
   End
   Begin RichTextLib.RichTextBox List 
      Height          =   7815
      Left            =   3000
      TabIndex        =   1
      TabStop         =   0   'False
      Top             =   600
      Width           =   7095
      _ExtentX        =   12510
      _ExtentY        =   13780
      _Version        =   393217
      BackColor       =   32768
      ScrollBars      =   3
      TextRTF         =   $"Main1.frx":0442
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Narkisim"
         Size            =   8.4
         Charset         =   177
         Weight          =   350
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin RichTextLib.RichTextBox Source 
      Height          =   8055
      Left            =   120
      TabIndex        =   0
      Top             =   480
      Width           =   10095
      _ExtentX        =   17801
      _ExtentY        =   14203
      _Version        =   393217
      ScrollBars      =   3
      RightMargin     =   1
      TextRTF         =   $"Main1.frx":0565
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin VB.Frame Frame1 
      Caption         =   "RUN"
      Height          =   1215
      Left            =   10440
      TabIndex        =   2
      Top             =   3480
      Width           =   1215
      Begin VB.CommandButton RunSim11 
         Caption         =   "Run Sim11"
         Height          =   375
         Left            =   120
         TabIndex        =   8
         TabStop         =   0   'False
         Top             =   720
         Width           =   975
      End
      Begin VB.CommandButton RunAs11 
         Caption         =   "Run As11"
         Height          =   375
         Left            =   120
         TabIndex        =   3
         TabStop         =   0   'False
         Top             =   240
         Width           =   975
      End
   End
   Begin VB.Label Label2 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BackStyle       =   0  'Transparent
      BorderStyle     =   1  'Fixed Single
      Caption         =   "ERROR!"
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   10680
      TabIndex        =   14
      Top             =   1800
      Width           =   855
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      Caption         =   "Delay"
      Height          =   255
      Left            =   10680
      TabIndex        =   13
      Top             =   1200
      Width           =   735
   End
   Begin VB.Label Budgita 
      Alignment       =   2  'Center
      BackColor       =   &H00000000&
      Caption         =   "BODGITA.[R]"
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   10560
      TabIndex        =   7
      ToolTipText     =   "נכתב ע""י גינה רוני"
      Top             =   480
      Width           =   1095
   End
   Begin VB.Label Path 
      Caption         =   "Path"
      Height          =   255
      Left            =   120
      TabIndex        =   6
      Top             =   240
      Width           =   3255
   End
   Begin VB.Label FileName 
      Caption         =   "FileName"
      Height          =   255
      Left            =   120
      TabIndex        =   5
      Top             =   0
      Width           =   1935
   End
   Begin VB.Menu mnuFile 
      Caption         =   "&File"
      Begin VB.Menu mnuLoad 
         Caption         =   "Load"
         Shortcut        =   ^O
      End
      Begin VB.Menu mnuSave 
         Caption         =   "Save"
         Shortcut        =   ^S
      End
      Begin VB.Menu mnuExit 
         Caption         =   "Exit"
         Shortcut        =   ^X
      End
   End
   Begin VB.Menu mnuRun 
      Caption         =   "&Run"
      Begin VB.Menu mnuAs11 
         Caption         =   "As11"
         Shortcut        =   ^T
      End
      Begin VB.Menu mnuSim11 
         Caption         =   "Sim11"
         Shortcut        =   ^R
      End
      Begin VB.Menu mnuList 
         Caption         =   "List hide/show"
         Shortcut        =   ^L
      End
   End
End
Attribute VB_Name = "Main1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim TimerCnt As Integer
Dim TempCnt1 As Integer

Private Sub Command1_Click()
    If List.Visible = False Then
        List.Visible = True
        Command1.Caption = "Hide List"
    ElseIf List.Visible = True Then
        List.Visible = False
        Command1.Caption = "Show List"
    End If
    
End Sub

Private Sub Exit_Click(Index As Integer)
    'ending program
    End
End Sub



Private Sub Form_Load()
Label2.Visible = False
List.Visible = False
End Sub

Private Sub List_Change()
    Dim Search As Long
    Search = List.Find("error", 0, , 2)
    Label2.Visible = False
    If Search <> -1 Then Label2.Visible = True
End Sub

Private Sub LoadFileButton_Click(Index As Integer)
    Dim listname As String * 100 'contains then *.lst filename
    File.Action = 1 'for file reading
    If File.CancelError = False Then 'no Cancel is pressed nor no file to load
        On Error Resume Next
        Source.LoadFile File.FileName, rtfText 'loading source file *.s11
        List.Text = "" 'clearing list rtf befor checking for *.lst file
        List.Refresh 'update list rtf
        Source.Refresh 'update source rtf
        'setting list file name *.lst form file(CommonControl).filename
        listname = Mid(File.FileName, 1, Len(File.FileName) - 3) & "lst"
        On Error Resume Next
        List.LoadFile listname 'loading list file *.lst if exsist
        List.Refresh
        FileName.Caption = File.FileTitle 'setting filename and file path
        Path.Caption = File.FileName      ' to temp-labels file. & path.
    End If
End Sub

Private Sub mnuAs11_Click()
    RunAs11_Click
End Sub

Private Sub mnuExit_Click()
    Exit_Click 0
End Sub

Private Sub mnuList_Click()
    Command1_Click
End Sub

Private Sub mnuLoad_Click()
    LoadFileButton_Click 0
End Sub

Private Sub mnuSave_Click()
    SaveFileButton_Click 1
End Sub

Private Sub mnuSim11_Click()
    RunSim11_Click
End Sub

Private Sub RunAs11_Click()
    Dim As11Path As String * 100 'contains the path of the as11.exe
    Dim listname As String * 100 'contains *.lst file
    Dim tempvar As Long
        List.Visible = True
        Command1.Caption = "Hide List"
    On Error Resume Next
    'setting as11.exe path from path. and file. temp-label
    As11Path = Mid(Path, 1, Len(Path.Caption) - Len(FileName.Caption))
    On Error GoTo runerror
        'saveing befor running
        On Error Resume Next
        RunAs11.Caption = "Saving file"
        Source.SaveFile File.FileName, rtfText
        FileName.Caption = File.FileTitle
        Path.Caption = File.FileName
   'delay because of hd in progress
    For TempCnt1 = 0 To HScroll1.Value
        For tempvar = 1 To 3999999 * 2
        Next tempvar
    Next TempCnt1
    RunAs11.Caption = "Running !"
    ''running as11.exe with source file
    Shell "as11.exe" & " " & FileName.Caption, vbNormalFocus
    'small delay untill loading new list
   'delay because of hd in progress
    For TempCnt1 = 0 To HScroll1.Value
        For tempvar = 1 To 3999999 * 3
        Next tempvar
    Next TempCnt1
    'loading new list
    RunAs11.Caption = "Creating .lst"
    listname = Mid(File.FileName, 1, Len(File.FileName) - 3) & "lst"
    On Error Resume Next
    List.LoadFile listname
    List.Refresh
    RunAs11.Caption = "Run As11"
    
Exit Sub
runerror:
MsgBox "Must run file.s11 from as11.exe directory", vbCritical, "ERROR!"
End Sub



Private Sub RunSim11_Click()
'run sim11.exe on SourceFile
    On Error Resume Next
    Shell "sim11.exe " & Text1.Text & " " & Mid(FileName.Caption, 1, Len(FileName.Caption) - 4), vbMaximizedFocus

End Sub


Private Sub SaveFileButton_Click(Index As Integer)
    'saveing file button pressed
    File.Action = 2 'for file saveing
    If File.CancelError = False Then 'not cancel nor no file
        On Error Resume Next
        Source.SaveFile File.FileName, rtfText
        'setting temp-labels fiel. & path. to contain file and path name
        FileName.Caption = File.FileTitle
        Path.Caption = File.FileName
    End If
End Sub





Private Sub Timer1_Timer()
TimerCnt = TimerCnt + 1
If TimerCnt < 80 Then Budgita.Caption = "BUDGITA.[R]" Else Budgita.Caption = "גינה רוני"
If TimerCnt > 100 Then TimerCnt = 0
End Sub


