VERSION 5.00
Begin VB.Form frmRoulette 
   BackColor       =   &H00008000&
   BorderStyle     =   0  'None
   ClientHeight    =   1464
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4548
   Icon            =   "frmRoulette.frx":0000
   LinkTopic       =   "Form1"
   MDIChild        =   -1  'True
   ScaleHeight     =   1464
   ScaleWidth      =   4548
   ShowInTaskbar   =   0   'False
   Begin VB.Timer tmrControl 
      Enabled         =   0   'False
      Interval        =   15000
      Left            =   1560
      Top             =   3600
   End
   Begin VB.Timer tmrNumbersRun 
      Interval        =   2
      Left            =   1200
      Top             =   3600
   End
   Begin VB.Timer tmrEnd 
      Enabled         =   0   'False
      Interval        =   2000
      Left            =   840
      Top             =   3600
   End
   Begin VB.Timer tmrRoulette 
      Interval        =   100
      Left            =   480
      Top             =   3600
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   12
      Left            =   4080
      TabIndex        =   12
      Top             =   1080
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   11
      Left            =   3840
      TabIndex        =   11
      Top             =   840
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   10
      Left            =   3480
      TabIndex        =   10
      Top             =   600
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   9
      Left            =   3120
      TabIndex        =   9
      Top             =   480
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   8
      Left            =   2760
      TabIndex        =   8
      Top             =   360
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   3
      Left            =   960
      TabIndex        =   7
      Top             =   480
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   7
      Left            =   2400
      TabIndex        =   6
      Top             =   240
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   2
      Left            =   600
      TabIndex        =   5
      Top             =   600
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   6
      Left            =   2040
      TabIndex        =   4
      Top             =   240
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   5
      Left            =   1680
      TabIndex        =   3
      Top             =   240
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   4
      Left            =   1320
      TabIndex        =   2
      Top             =   360
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   0
      Left            =   0
      TabIndex        =   1
      Top             =   1080
      Width           =   372
   End
   Begin VB.Label lblNum 
      Alignment       =   2  'Center
      BackColor       =   &H00008000&
      Caption         =   "00"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   252
      Index           =   1
      Left            =   240
      TabIndex        =   0
      Top             =   840
      Width           =   372
   End
   Begin VB.Image Image1 
      Height          =   732
      Index           =   4
      Left            =   5880
      Picture         =   "frmRoulette.frx":0442
      Top             =   3720
      Width           =   1056
   End
   Begin VB.Image Image1 
      Height          =   732
      Index           =   3
      Left            =   5880
      Picture         =   "frmRoulette.frx":1041
      Top             =   3000
      Width           =   1056
   End
   Begin VB.Image Image1 
      Height          =   732
      Index           =   2
      Left            =   5880
      Picture         =   "frmRoulette.frx":1C4F
      Top             =   2280
      Width           =   1056
   End
   Begin VB.Image Image1 
      Height          =   732
      Index           =   1
      Left            =   5880
      Picture         =   "frmRoulette.frx":2839
      Top             =   1560
      Width           =   1056
   End
   Begin VB.Image Image1 
      Height          =   732
      Index           =   0
      Left            =   5880
      Picture         =   "frmRoulette.frx":3439
      Top             =   840
      Width           =   1056
   End
   Begin VB.Image imgRoulette 
      Height          =   852
      Left            =   1680
      Picture         =   "frmRoulette.frx":4031
      Stretch         =   -1  'True
      Top             =   600
      Width           =   1092
   End
End
Attribute VB_Name = "frmRoulette"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim bl As Integer       'random number at the end of roulette numbers run proccess
Dim al As Double        'roulette acc for timers uses
Dim cl As Integer       'index to run in the real numbers array
Dim ti(5) As Integer
Dim rNum(37) As Integer     'real roulette numbers
Dim ci As Integer
Dim fCanRunRoulette As Boolean

Private Sub Form_Load()
    Dim a As Integer
    Dim fOk As Boolean
    initRNums
    frmLastNumbers.Show
    'set frmRoulette pos
    frmRoulette.Left = Screen.Width / 2 - frmRoulette.Width / 2
    frmRoulette.Top = Screen.Height / 2 - frmRoulette.Height / 2
    fCanRunRoulette = True
    fOk = True
    'set frmLists position
    frmLists.Visible = False
    frmLists.List1.Clear
    'will check for correct bets in all frmPLayer()
    For a = 0 To nextPlayer - 1
        If frmPlayer(a).checkCorrectBets() = False Then fOk = False
    Next a
    If fOk = False Then
        'not correct
        frmLists.Show
        'this flag is used in tmrNumbersRun timer to maybe close the roulette
        fCanRunRoulette = fOk
    Else
        'bets OK
        canRunBets = False
        tmrControl.Enabled = True
    End If
    'will random the first index in real numbers array to start run numbers
    Randomize
    cl = Int(Rnd * 37)
    'set start value for timer
    al = 1
End Sub

Private Sub Form_LostFocus()
    frmRoulette.SetFocus
End Sub

Private Sub tmrControl_Timer()
'timer to controll the roulette random proccess
    'enable the end timer to show result and close
    tmrEnd.Enabled = True
    'disable the timers to stop turning and calculating
    tmrRoulette.Enabled = False
    tmrNumbersRun.Enabled = False
End Sub

Private Sub tmrEnd_Timer()
'show results and close the form ,update frmPlayer(0) with results
'   check for wins, init the bets
    Dim a
    frmLists.List1.Clear
    For a = 0 To nextPlayer - 1
        'will check if player is on
        If playerIsOn(a) = True Then
            'will write the roulette number to frmPlayer()
            frmPlayer(a).lblLastNumber = Val(bl)
            If isRed(bl) = True Then
                frmPlayer(a).lblLastNumber.ForeColor = &HFF&
            Else
                frmPlayer(a).lblLastNumber.ForeColor = &H0&
            End If
            'will check if number=00 to change color to green
            If bl = 0 Then frmPlayer(a).lblLastNumber.ForeColor = &HFF00&
            frmPlayer(a).checkWin
            'will enable tmrClear to show data and then init bets
            frmPlayer(a).tmrClear.Enabled = True
        End If
    Next a
    'will update last number list
    updateLastNumbers
    canRunBets = True
    Unload frmRoulette
End Sub

Private Sub tmrNumbersRun_Timer()
    Dim a As Integer
    'will check if can run the roulette
    If fCanRunRoulette = False Then
        Unload frmRoulette
    Else
        'run the number proccess, bl is the final number
        cl = cl + 1
        If cl > 36 Then cl = 0
        For a = 0 To 12
            If cl + a > 36 Then
                lblNum(a).Caption = rNum(cl + a - 36 - 1)
            Else
                lblNum(a).Caption = rNum(cl + a)
            End If
        Next a
        'set colors to labels
        For a = 0 To 12
            If isRed(Val(lblNum(a).Caption)) = True Then
                lblNum(a).ForeColor = &HFF&
            Else
                lblNum(a).ForeColor = &H0&
            End If
            If Val(lblNum(a).Caption) = 0 Then lblNum(a).ForeColor = &HFF00&
        Next a
        bl = Val(lblNum(6).Caption)
        al = al * 1.05
        tmrRoulette.Interval = tmrRoulette.Interval + al / 15
        tmrNumbersRun.Interval = Int(al)
    End If
End Sub

Private Sub tmrRoulette_Timer()
    rolAnim = rolAnim + 1
    If rolAnim < 2 Then rolAnim = 2
    If rolAnim > 6 Then rolAnim = 2
    imgRoulette.Picture = Image1(rolAnim - 2).Picture
End Sub

Private Sub updateLastNumbers()
    Dim sRed As String
    Dim sNum As String
    If isRed(bl) Then
        'red
        frmLastNumbers.lstRed.AddItem bl, 0
        'will check if number =0 to add to both lists
        If bl = 0 Then
            frmLastNumbers.lstBlack.AddItem "0", 0
        Else
            frmLastNumbers.lstBlack.AddItem " ", 0
        End If
    Else
        'black
        frmLastNumbers.lstBlack.AddItem bl, 0
        'will check if number =0 to add to both lists
        If bl = 0 Then
            frmLastNumbers.lstRed.AddItem "0", 0
        Else
            frmLastNumbers.lstRed.AddItem " ", 0
        End If
    End If
    If frmLastNumbers.lstBlack.ListCount > 9 Then
        frmLastNumbers.lstBlack.RemoveItem 9
        frmLastNumbers.lstRed.RemoveItem 9
    End If
End Sub

Public Function isRed(num As Integer) As Boolean
    Dim sRed As String
    Dim sNum As String
    sRed = "01 03 05 07 09 12 14 16 18 19 21 23 25 27 30 32 34 36"
    If num < 10 Then
        sNum = "0" & Trim(Val(num))
    Else
        sNum = Trim(Val(num))
    End If
    If InStr(1, sRed, sNum) <> 0 Then
        'red
        isRed = True
    Else
        'black
        isRed = False
    End If
End Function

Private Sub initRNums()
    rNum(0) = 5
    rNum(1) = 17
    rNum(2) = 32
    rNum(3) = 20
    rNum(4) = 7
    rNum(5) = 11
    rNum(6) = 30
    rNum(7) = 26
    rNum(8) = 9
    rNum(9) = 28
    rNum(10) = 0
    rNum(11) = 2
    rNum(12) = 14
    rNum(13) = 35
    rNum(14) = 23
    rNum(15) = 4
    rNum(16) = 16
    rNum(17) = 33
    rNum(18) = 21
    rNum(19) = 6
    rNum(20) = 18
    rNum(21) = 31
    rNum(22) = 19
    rNum(23) = 8
    rNum(24) = 12
    rNum(25) = 29
    rNum(26) = 25
    rNum(27) = 10
    rNum(28) = 27
    rNum(29) = 1
    rNum(30) = 13
    rNum(31) = 36
    rNum(32) = 24
    rNum(33) = 3
    rNum(34) = 15
    rNum(35) = 34
    rNum(36) = 22
End Sub
