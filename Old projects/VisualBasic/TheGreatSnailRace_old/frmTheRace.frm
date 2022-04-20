VERSION 5.00
Object = "{C1A8AF28-1257-101B-8FB0-0020AF039CA3}#1.1#0"; "MCI32.OCX"
Begin VB.Form frmTheRace 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   0  'None
   Caption         =   "TheRace"
   ClientHeight    =   6696
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   8892
   Icon            =   "frmTheRace.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6696
   ScaleWidth      =   8892
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin MCI.MMControl Ef1 
      Height          =   492
      Index           =   0
      Left            =   4440
      TabIndex        =   12
      Top             =   1680
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s0.wav"
   End
   Begin VB.Timer EndTimer 
      Interval        =   5000
      Left            =   3360
      Top             =   1560
   End
   Begin VB.Frame Frame1 
      Height          =   1092
      Index           =   2
      Left            =   0
      TabIndex        =   9
      Top             =   0
      Width           =   8892
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "THE GREAT SNAIL RACE"
         BeginProperty Font 
            Name            =   "Narkisim"
            Size            =   36
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C000C0&
         Height          =   612
         Index           =   7
         Left            =   600
         TabIndex        =   10
         Top             =   240
         Width           =   7932
      End
   End
   Begin VB.Frame Frame2 
      BorderStyle     =   0  'None
      Height          =   4812
      Left            =   0
      TabIndex        =   8
      Top             =   1080
      Width           =   132
   End
   Begin VB.Timer RaceTimer 
      Interval        =   50
      Left            =   2400
      Top             =   1560
   End
   Begin VB.Frame Frame1 
      BorderStyle     =   0  'None
      Height          =   4812
      Index           =   0
      Left            =   8760
      TabIndex        =   6
      Top             =   1080
      Width           =   132
   End
   Begin VB.Frame Frame1 
      Height          =   852
      Index           =   1
      Left            =   0
      TabIndex        =   7
      Top             =   5880
      Width           =   8892
      Begin VB.Label TheWinnerLabel 
         Alignment       =   2  'Center
         Caption         =   "???"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   18
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   372
         Left            =   120
         TabIndex        =   11
         Top             =   240
         Width           =   8652
      End
   End
   Begin MCI.MMControl Ef1 
      Height          =   492
      Index           =   1
      Left            =   4440
      TabIndex        =   13
      Top             =   2160
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s1.wav"
   End
   Begin MCI.MMControl Ef1 
      Height          =   492
      Index           =   2
      Left            =   4440
      TabIndex        =   14
      Top             =   2640
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s2.wav"
   End
   Begin MCI.MMControl Ef1 
      Height          =   492
      Index           =   3
      Left            =   4440
      TabIndex        =   15
      Top             =   3120
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s3.wav"
   End
   Begin MCI.MMControl Ef1 
      Height          =   492
      Index           =   4
      Left            =   4440
      TabIndex        =   16
      Top             =   3600
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s4.wav"
   End
   Begin MCI.MMControl Ef1 
      Height          =   492
      Index           =   5
      Left            =   4440
      TabIndex        =   17
      Top             =   4080
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s5.wav"
   End
   Begin MCI.MMControl Ef1 
      Height          =   492
      Index           =   6
      Left            =   1560
      TabIndex        =   18
      Top             =   4560
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\l4.wav"
   End
   Begin MCI.MMControl Ef1 
      Height          =   492
      Index           =   7
      Left            =   1560
      TabIndex        =   19
      Top             =   5040
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\l2.wav"
   End
   Begin VB.Line Line1 
      BorderColor     =   &H000000FF&
      BorderWidth     =   8
      X1              =   7680
      X2              =   7680
      Y1              =   1680
      Y2              =   5280
   End
   Begin VB.Line Line3 
      BorderColor     =   &H0000C000&
      BorderWidth     =   4
      Index           =   5
      X1              =   600
      X2              =   8160
      Y1              =   2880
      Y2              =   2880
   End
   Begin VB.Line Line3 
      BorderColor     =   &H0000C000&
      BorderWidth     =   4
      Index           =   4
      X1              =   600
      X2              =   8160
      Y1              =   3480
      Y2              =   3480
   End
   Begin VB.Line Line3 
      BorderColor     =   &H0000C000&
      BorderWidth     =   4
      Index           =   3
      X1              =   600
      X2              =   8160
      Y1              =   4080
      Y2              =   4080
   End
   Begin VB.Line Line3 
      BorderColor     =   &H0000C000&
      BorderWidth     =   4
      Index           =   2
      X1              =   600
      X2              =   8160
      Y1              =   4680
      Y2              =   4680
   End
   Begin VB.Line Line3 
      BorderColor     =   &H0000C000&
      BorderWidth     =   4
      Index           =   1
      X1              =   600
      X2              =   8160
      Y1              =   5280
      Y2              =   5280
   End
   Begin VB.Line Line3 
      BorderColor     =   &H0000C000&
      BorderWidth     =   4
      Index           =   0
      X1              =   600
      X2              =   8160
      Y1              =   2280
      Y2              =   2280
   End
   Begin VB.Image RunSnail 
      Height          =   468
      Index           =   5
      Left            =   960
      Picture         =   "frmTheRace.frx":0442
      Top             =   4800
      Width           =   1044
   End
   Begin VB.Image RunSnail 
      Height          =   468
      Index           =   4
      Left            =   960
      Picture         =   "frmTheRace.frx":2CBC
      Top             =   4200
      Width           =   1044
   End
   Begin VB.Image RunSnail 
      Height          =   468
      Index           =   3
      Left            =   960
      Picture         =   "frmTheRace.frx":5536
      Top             =   3600
      Width           =   1044
   End
   Begin VB.Image RunSnail 
      Height          =   468
      Index           =   2
      Left            =   960
      Picture         =   "frmTheRace.frx":7DB0
      Top             =   3000
      Width           =   1044
   End
   Begin VB.Image RunSnail 
      Height          =   468
      Index           =   1
      Left            =   960
      Picture         =   "frmTheRace.frx":A62A
      Top             =   2400
      Width           =   1044
   End
   Begin VB.Shape Shape7 
      BorderColor     =   &H00C00000&
      BorderStyle     =   6  'Inside Solid
      BorderWidth     =   3
      Height          =   4092
      Index           =   1
      Left            =   360
      Top             =   1440
      Width           =   8172
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "3"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   24
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00008000&
      Height          =   612
      Index           =   5
      Left            =   600
      TabIndex        =   5
      Top             =   2880
      Width           =   372
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "4"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   24
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00008000&
      Height          =   612
      Index           =   4
      Left            =   600
      TabIndex        =   4
      Top             =   3480
      Width           =   372
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "5"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   24
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00008000&
      Height          =   612
      Index           =   3
      Left            =   600
      TabIndex        =   3
      Top             =   4080
      Width           =   372
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "6"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   24
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00008000&
      Height          =   612
      Index           =   2
      Left            =   600
      TabIndex        =   2
      Top             =   4680
      Width           =   372
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "2"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   24
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00008000&
      Height          =   612
      Index           =   1
      Left            =   600
      TabIndex        =   1
      Top             =   2280
      Width           =   372
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "1"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   24
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00008000&
      Height          =   612
      Index           =   0
      Left            =   600
      TabIndex        =   0
      Top             =   1680
      Width           =   372
   End
   Begin VB.Line Line2 
      BorderColor     =   &H00C00000&
      BorderWidth     =   4
      Index           =   3
      X1              =   120
      X2              =   480
      Y1              =   1200
      Y2              =   1560
   End
   Begin VB.Line Line2 
      BorderColor     =   &H00C00000&
      BorderWidth     =   4
      Index           =   2
      X1              =   8400
      X2              =   8760
      Y1              =   1560
      Y2              =   1200
   End
   Begin VB.Line Line2 
      BorderColor     =   &H00C00000&
      BorderWidth     =   4
      Index           =   1
      X1              =   480
      X2              =   120
      Y1              =   5400
      Y2              =   5760
   End
   Begin VB.Line Line2 
      BorderColor     =   &H00C00000&
      BorderWidth     =   4
      Index           =   0
      X1              =   8400
      X2              =   8760
      Y1              =   5400
      Y2              =   5760
   End
   Begin VB.Image Image1 
      Height          =   468
      Index           =   0
      Left            =   10320
      Picture         =   "frmTheRace.frx":CEA4
      Top             =   3360
      Visible         =   0   'False
      Width           =   1044
   End
   Begin VB.Image Image1 
      Height          =   468
      Index           =   1
      Left            =   10320
      Picture         =   "frmTheRace.frx":F71E
      Top             =   3480
      Visible         =   0   'False
      Width           =   924
   End
   Begin VB.Image Image1 
      Height          =   468
      Index           =   2
      Left            =   10320
      Picture         =   "frmTheRace.frx":11AB8
      Top             =   3600
      Visible         =   0   'False
      Width           =   816
   End
   Begin VB.Image Image1 
      Height          =   468
      Index           =   3
      Left            =   10320
      Picture         =   "frmTheRace.frx":13A0E
      Top             =   3720
      Visible         =   0   'False
      Width           =   924
   End
   Begin VB.Shape Shape7 
      BorderColor     =   &H00C00000&
      BorderStyle     =   6  'Inside Solid
      BorderWidth     =   3
      Height          =   3852
      Index           =   0
      Left            =   480
      Top             =   1560
      Width           =   7932
   End
   Begin VB.Shape Shape7 
      BorderColor     =   &H00C00000&
      BorderStyle     =   6  'Inside Solid
      BorderWidth     =   3
      Height          =   4572
      Index           =   2
      Left            =   120
      Top             =   1200
      Width           =   8652
   End
   Begin VB.Image RunSnail 
      Height          =   468
      Index           =   0
      Left            =   960
      Picture         =   "frmTheRace.frx":15DA8
      Top             =   1680
      Width           =   1044
   End
End
Attribute VB_Name = "frmTheRace"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim SnailPicture(0 To 5) As Integer
Function SnailRandom(ByVal Racers As Integer) As Integer
    Dim a As Double
    a = Int((Racers - 1 - 0 + 1) * Rnd + 0)
    SnailRandom = a
End Function
Private Sub EndTimer_Timer()
'end of race delay
    Dim a As Integer
        TheWinnerLabel.Caption = ""
        frmMain.Visible = True
        frmMain.SetSnailOdds
        frmMain.InitBets
        For a = 0 To 7
            Ef1(a).Command = "close"
        Next a
        Unload Me
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
If KeyCode = 27 Then Unload frmTheRace
End Sub
Private Sub Form_Load()
    Dim a As Integer
    Me.Height = 7000
    Me.Width = 8892
    Randomize
    RaceTimer.Enabled = True
    EndTimer.Enabled = False
    For a = 0 To 5
        RunSnail(a).Left = 960
        Ef1(a).Command = "open"
    Next a
        Ef1(6).Command = "open"
        Ef1(7).Command = "open"
        
    
End Sub
Private Sub RaceTimer_Timer()
    Dim a As Integer
    a = SnailRandom(6)
    If SnailPicture(a) = 3 Then Ef1(a).Command = "play"
    If SnailPicture(a) = 3 Then Ef1(a).Command = "prev"
    RunSnail(a).Left = RunSnail(a).Left + 38 - Odds(a)
    SnailPicture(a) = SnailPicture(a) + 1
    If RunSnail(a).Left > 6000 Then Ef1(6).Command = "play"
    If RunSnail(a).Left > 6700 Then Ef1(7).Command = "play"
    If SnailPicture(a) > 3 Then SnailPicture(a) = 0
    RunSnail(a).Picture = Image1(SnailPicture(a))
    'end of race check
    If RunSnail(a).Left >= 6800 Then
        RaceWinner = a
        CheckBets
        TheWinnerLabel.Caption = Str(a + 1) & " המנצח הוא שבלול מספר "
        EndTimer.Enabled = True
        RaceTimer.Enabled = False
    End If
End Sub
Sub CheckBets()
    Dim a As Integer
    For a = 0 To 9
        Player(a).MoneyLeft = Player(a).MoneyLeft - Player(a).MoneyBet
        If Player(a).SnailBet = (RaceWinner + 1) Then
            Player(a).MoneyLeft = Player(a).MoneyLeft + (1 + Odds(RaceWinner)) * Player(a).MoneyBet
        End If
    Next a
End Sub
