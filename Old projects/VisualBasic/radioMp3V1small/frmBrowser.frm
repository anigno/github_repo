VERSION 5.00
Begin VB.Form frmBrowser 
   BackColor       =   &H00808000&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Browser"
   ClientHeight    =   4992
   ClientLeft      =   36
   ClientTop       =   276
   ClientWidth     =   6000
   Icon            =   "frmBrowser.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4992
   ScaleWidth      =   6000
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdMakeDir 
      BackColor       =   &H000080FF&
      Caption         =   "Make Dir"
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
      Left            =   120
      Style           =   1  'Graphical
      TabIndex        =   10
      Top             =   3600
      Width           =   972
   End
   Begin VB.DirListBox Dir2 
      BackColor       =   &H00FF8080&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1392
      Left            =   2400
      TabIndex        =   8
      Top             =   3600
      Width           =   3612
   End
   Begin VB.DriveListBox Drive1 
      BackColor       =   &H00FF8080&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   336
      Left            =   0
      TabIndex        =   6
      Top             =   0
      Width           =   2412
   End
   Begin VB.DirListBox Dir1 
      BackColor       =   &H00FF8080&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1392
      Left            =   2400
      TabIndex        =   5
      Top             =   0
      Width           =   3612
   End
   Begin VB.FileListBox File1 
      BackColor       =   &H00FF8080&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1752
      Left            =   120
      MultiSelect     =   1  'Simple
      Pattern         =   "*.mp3"
      TabIndex        =   4
      Top             =   1800
      Width           =   5892
   End
   Begin VB.CommandButton cmdMove 
      BackColor       =   &H000080FF&
      Caption         =   "Move"
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
      Left            =   840
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   720
      Width           =   732
   End
   Begin VB.CommandButton cmdExit 
      BackColor       =   &H008080FF&
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
      Height          =   348
      Left            =   1200
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   3600
      Width           =   732
   End
   Begin VB.CommandButton cmdCopy 
      BackColor       =   &H000080FF&
      Caption         =   "Copy"
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
      Left            =   0
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   720
      Width           =   732
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "--> To"
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
      Height          =   372
      Left            =   120
      TabIndex        =   9
      Top             =   3960
      Width           =   1452
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "From -->"
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
      Height          =   372
      Left            =   0
      TabIndex        =   7
      Top             =   360
      Width           =   1452
   End
   Begin VB.Label lblCounter 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "_"
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
      Height          =   252
      Left            =   120
      TabIndex        =   3
      Top             =   4200
      Width           =   2172
   End
End
Attribute VB_Name = "frmBrowser"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim fCounter As Integer

Private Sub cmdCopy_Click()
    Dim S, D As String
    Dim a As Integer
    File1.Enabled = False
    cmdCopy.Enabled = False
    cmdMakeDir.Enabled = False
    cmdMove.Enabled = False
    fCounter = 0
    For a = 0 To File1.ListCount - 1
        If File1.Selected(a) = True Then
            S = Dir1.Path & "\" & File1.List(a)
            D = Dir2.Path & "\" & File1.List(a)
            fCounter = fCounter + 1
            lblCounter.Caption = fCounter & " Copied"
            CopyFile S, D, 1
            DoEvents
        End If
    Next a
    Dir1.Refresh
    Dir2.Refresh
    File1.Refresh
    File1.Enabled = True
    cmdCopy.Enabled = True
    cmdMakeDir.Enabled = True
    cmdMove.Enabled = True
End Sub

Private Sub cmdExit_Click()
    frmMain.Show
    Unload frmBrowser
End Sub

Private Sub cmdMakeDir_Click()
    Dim S, S2 As String
    Dim a As Integer
    Dim SecAtt As SECURITY_ATTRIBUTES
    S = InputBox("Enter directory name for " & Dir2.Path & "\")
    S2 = Dir2.Path & "\" & S
    If S <> "" Then
        a = MsgBox("create dir " & S2 & " ?", vbYesNo)
        If a = vbYes Then
            CreateDirectory S2, SecAtt
        End If
    End If
    Dir1.Refresh
    Dir2.Refresh
    File1.Refresh
End Sub

Private Sub cmdMove_Click()
    File1.Enabled = False
    cmdCopy.Enabled = False
    cmdMakeDir.Enabled = False
    cmdMove.Enabled = False
    Dim S, D As String
    Dim a As Integer
    fCounter = 0
    For a = 0 To File1.ListCount - 1
        If File1.Selected(a) = True Then
            S = Dir1.Path & "\" & File1.List(a)
            D = Dir2.Path & "\" & File1.List(a)
            fCounter = fCounter + 1
            lblCounter.Caption = fCounter & " Moved"
            MoveFile S, D
            DoEvents
        End If
    Next a
    Dir1.Refresh
    Dir2.Refresh
    File1.Refresh
    File1.Enabled = True
    cmdCopy.Enabled = True
    cmdMakeDir.Enabled = True
    cmdMove.Enabled = True
End Sub

Private Sub Dir1_Change()
    On Error Resume Next
    File1.Path = Dir1.Path
End Sub

Private Sub Dir2_Click()
    Dir2.Path = Dir2.List(Dir2.ListIndex)
End Sub

Private Sub Dir1_Click()
    Dir1.Path = Dir1.List(Dir1.ListIndex)
End Sub

Private Sub Drive1_Change()
    On Error Resume Next
    Dir1.Path = Drive1.Drive
End Sub

Private Sub Form_Load()
    Dir2.Path = MAINDIR
    Drive1.Drive = "c:\"
End Sub

Private Sub Form_Unload(Cancel As Integer)
    frmMain.Show
End Sub
