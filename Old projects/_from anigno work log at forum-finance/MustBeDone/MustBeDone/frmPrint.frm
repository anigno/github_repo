VERSION 5.00
Begin VB.Form frmPrint 
   BackColor       =   &H00E0E0E0&
   Caption         =   "MustBeDone"
   ClientHeight    =   6276
   ClientLeft      =   48
   ClientTop       =   276
   ClientWidth     =   7524
   Icon            =   "frmPrint.frx":0000
   LinkTopic       =   "Form1"
   RightToLeft     =   -1  'True
   ScaleHeight     =   6276
   ScaleWidth      =   7524
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox Hours 
      BackColor       =   &H00FFFFFF&
      ForeColor       =   &H00000000&
      Height          =   3504
      ItemData        =   "frmPrint.frx":0442
      Left            =   6960
      List            =   "frmPrint.frx":047C
      TabIndex        =   4
      TabStop         =   0   'False
      Top             =   480
      Width           =   492
   End
   Begin VB.CommandButton Command1 
      Caption         =   "ביטול"
      Height          =   252
      Left            =   5040
      TabIndex        =   3
      TabStop         =   0   'False
      Top             =   4080
      Width           =   612
   End
   Begin VB.CommandButton PrintButton 
      Caption         =   "הדפס"
      Height          =   252
      Left            =   4200
      TabIndex        =   2
      TabStop         =   0   'False
      Top             =   4080
      Width           =   612
   End
   Begin VB.ListBox ActionList 
      BackColor       =   &H00FFFFFF&
      ForeColor       =   &H00000000&
      Height          =   3504
      Left            =   3600
      RightToLeft     =   -1  'True
      TabIndex        =   1
      TabStop         =   0   'False
      Top             =   480
      Width           =   3372
   End
   Begin VB.ListBox MemoList 
      BackColor       =   &H00FFFFFF&
      ForeColor       =   &H00000000&
      Height          =   6192
      Left            =   0
      RightToLeft     =   -1  'True
      TabIndex        =   0
      TabStop         =   0   'False
      Top             =   0
      Width           =   3612
   End
   Begin VB.Label Budgita 
      Alignment       =   2  'Center
      BackColor       =   &H00000000&
      Caption         =   "BUDGITA"
      BeginProperty Font 
         Name            =   "Miriam"
         Size            =   13.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   252
      Left            =   4200
      TabIndex        =   6
      ToolTipText     =   "גינה רוני saharon@t2.technion.ac.il"
      Top             =   4680
      Width           =   1452
   End
   Begin VB.Label DateLabel 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      Caption         =   "Label1"
      Height          =   252
      Left            =   3720
      RightToLeft     =   -1  'True
      TabIndex        =   5
      Top             =   120
      Width           =   3132
   End
End
Attribute VB_Name = "frmPrint"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
    Unload frmPrint
End Sub
Private Sub Form_Load()
    Dim a As Integer
    frmMain.Enabled = False
    'will write date to DataLabel
    DateLabel.Caption = TheDay & "/" & TheMonth & "/" & TheYear
    'will write to action list
    For a = 0 To 17
        ActionList.AddItem frmMain.ActionText(a)
    Next a
    'will write to Print MemoList
    Dim b, DayCnt, Cnt, MemoCnt As Integer
    MemoList.Clear
    DayCnt = TheDay - 3
    If DayCnt < 1 Then DayCnt = 1
    Cnt = 1
    While Cnt <= 7 And DayCnt <= LastDay
        If DayCnt = Day(Date) And TheMonth = Month(Date) Then
            MemoList.AddItem "             -  -  -  - " & DayCnt & "/" & TheMonth & " - - - -"
        Else
            MemoList.AddItem "                         " & DayCnt & "/" & TheMonth
        End If
        
        For b = 0 To 5
            If Memo(DayCnt, b) <> "" And MemoDone(DayCnt, b) <> 1 Then MemoList.AddItem Memo(DayCnt, b)
        Next b
        MemoList.AddItem "                         "
        DayCnt = DayCnt + 1
        Cnt = Cnt + 1
    Wend

End Sub


Private Sub Form_Unload(Cancel As Integer)
    frmMain.Enabled = True
End Sub

Private Sub PrintButton_Click()
    On Error GoTo NoPrint
    frmPrint.PrintForm
    Unload frmPrint
    Exit Sub
NoPrint:
    MsgBox "Can not print !", vbCritical, "Error !"
End Sub


