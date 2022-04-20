VERSION 5.00
Object = "{C1A8AF28-1257-101B-8FB0-0020AF039CA3}#1.1#0"; "MCI32.OCX"
Begin VB.Form frmMain 
   Caption         =   "THE GREAT SNAIL RACE"
   ClientHeight    =   6372
   ClientLeft      =   48
   ClientTop       =   276
   ClientWidth     =   8472
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   8892
   ScaleWidth      =   12192
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame Frame2 
      Caption         =   "משתתפים"
      Height          =   4212
      Left            =   120
      TabIndex        =   15
      Top             =   720
      Width           =   4692
      Begin VB.ComboBox SnailBetCombo 
         Height          =   288
         Index           =   9
         ItemData        =   "frmMain.frx":030A
         Left            =   3240
         List            =   "frmMain.frx":0323
         TabIndex        =   71
         Top             =   3840
         Width           =   612
      End
      Begin VB.ComboBox SnailBetCombo 
         Height          =   288
         Index           =   8
         ItemData        =   "frmMain.frx":033D
         Left            =   3240
         List            =   "frmMain.frx":0356
         TabIndex        =   70
         Top             =   3480
         Width           =   612
      End
      Begin VB.ComboBox SnailBetCombo 
         Height          =   288
         Index           =   7
         ItemData        =   "frmMain.frx":0370
         Left            =   3240
         List            =   "frmMain.frx":0389
         TabIndex        =   69
         Top             =   3120
         Width           =   612
      End
      Begin VB.ComboBox SnailBetCombo 
         Height          =   288
         Index           =   6
         ItemData        =   "frmMain.frx":03A3
         Left            =   3240
         List            =   "frmMain.frx":03BC
         TabIndex        =   68
         Top             =   2760
         Width           =   612
      End
      Begin VB.ComboBox SnailBetCombo 
         Height          =   288
         Index           =   5
         ItemData        =   "frmMain.frx":03D6
         Left            =   3240
         List            =   "frmMain.frx":03EF
         TabIndex        =   67
         Top             =   2400
         Width           =   612
      End
      Begin VB.ComboBox SnailBetCombo 
         Height          =   288
         Index           =   4
         ItemData        =   "frmMain.frx":0409
         Left            =   3240
         List            =   "frmMain.frx":0422
         TabIndex        =   66
         Top             =   2040
         Width           =   612
      End
      Begin VB.ComboBox SnailBetCombo 
         Height          =   288
         Index           =   3
         ItemData        =   "frmMain.frx":043C
         Left            =   3240
         List            =   "frmMain.frx":0455
         TabIndex        =   65
         Top             =   1680
         Width           =   612
      End
      Begin VB.ComboBox SnailBetCombo 
         Height          =   288
         Index           =   2
         ItemData        =   "frmMain.frx":046F
         Left            =   3240
         List            =   "frmMain.frx":0488
         TabIndex        =   64
         Top             =   1320
         Width           =   612
      End
      Begin VB.ComboBox SnailBetCombo 
         Height          =   288
         Index           =   1
         ItemData        =   "frmMain.frx":04A2
         Left            =   3240
         List            =   "frmMain.frx":04BB
         TabIndex        =   63
         Top             =   960
         Width           =   612
      End
      Begin VB.ComboBox SnailBetCombo 
         Height          =   288
         Index           =   0
         ItemData        =   "frmMain.frx":04D5
         Left            =   3240
         List            =   "frmMain.frx":04EE
         TabIndex        =   36
         Top             =   600
         Width           =   612
      End
      Begin VB.TextBox MoneyBetText 
         Height          =   288
         Index           =   0
         Left            =   3960
         TabIndex        =   35
         Top             =   600
         Width           =   612
      End
      Begin VB.TextBox NameText 
         Alignment       =   2  'Center
         Height          =   288
         Index           =   9
         Left            =   480
         TabIndex        =   34
         Top             =   3840
         Width           =   1692
      End
      Begin VB.TextBox NameText 
         Alignment       =   2  'Center
         Height          =   288
         Index           =   8
         Left            =   480
         TabIndex        =   33
         Top             =   3480
         Width           =   1692
      End
      Begin VB.TextBox NameText 
         Alignment       =   2  'Center
         Height          =   288
         Index           =   7
         Left            =   480
         TabIndex        =   32
         Top             =   3120
         Width           =   1692
      End
      Begin VB.TextBox NameText 
         Alignment       =   2  'Center
         Height          =   288
         Index           =   6
         Left            =   480
         TabIndex        =   31
         Top             =   2760
         Width           =   1692
      End
      Begin VB.TextBox NameText 
         Alignment       =   2  'Center
         Height          =   288
         Index           =   5
         Left            =   480
         TabIndex        =   30
         Top             =   2400
         Width           =   1692
      End
      Begin VB.TextBox NameText 
         Alignment       =   2  'Center
         Height          =   288
         Index           =   4
         Left            =   480
         TabIndex        =   29
         Top             =   2040
         Width           =   1692
      End
      Begin VB.TextBox NameText 
         Alignment       =   2  'Center
         Height          =   288
         Index           =   3
         Left            =   480
         TabIndex        =   28
         Top             =   1680
         Width           =   1692
      End
      Begin VB.TextBox NameText 
         Alignment       =   2  'Center
         Height          =   288
         Index           =   2
         Left            =   480
         TabIndex        =   27
         Top             =   1320
         Width           =   1692
      End
      Begin VB.TextBox NameText 
         Alignment       =   2  'Center
         Height          =   288
         Index           =   1
         Left            =   480
         TabIndex        =   26
         Top             =   960
         Width           =   1692
      End
      Begin VB.TextBox NameText 
         Alignment       =   2  'Center
         Height          =   288
         Index           =   0
         Left            =   480
         TabIndex        =   25
         Top             =   600
         Width           =   1692
      End
      Begin VB.TextBox MoneyBetText 
         Height          =   288
         Index           =   1
         Left            =   3960
         TabIndex        =   24
         Top             =   960
         Width           =   612
      End
      Begin VB.TextBox MoneyBetText 
         Height          =   288
         Index           =   2
         Left            =   3960
         TabIndex        =   23
         Top             =   1320
         Width           =   612
      End
      Begin VB.TextBox MoneyBetText 
         Height          =   288
         Index           =   3
         Left            =   3960
         TabIndex        =   22
         Top             =   1680
         Width           =   612
      End
      Begin VB.TextBox MoneyBetText 
         Height          =   288
         Index           =   4
         Left            =   3960
         TabIndex        =   21
         Top             =   2040
         Width           =   612
      End
      Begin VB.TextBox MoneyBetText 
         Height          =   288
         Index           =   5
         Left            =   3960
         TabIndex        =   20
         Top             =   2400
         Width           =   612
      End
      Begin VB.TextBox MoneyBetText 
         Height          =   288
         Index           =   6
         Left            =   3960
         TabIndex        =   19
         Top             =   2760
         Width           =   612
      End
      Begin VB.TextBox MoneyBetText 
         Height          =   288
         Index           =   7
         Left            =   3960
         TabIndex        =   18
         Top             =   3120
         Width           =   612
      End
      Begin VB.TextBox MoneyBetText 
         Height          =   288
         Index           =   8
         Left            =   3960
         TabIndex        =   17
         Top             =   3480
         Width           =   612
      End
      Begin VB.TextBox MoneyBetText 
         Height          =   288
         Index           =   9
         Left            =   3960
         TabIndex        =   16
         Top             =   3840
         Width           =   612
      End
      Begin VB.Label Label3 
         Alignment       =   2  'Center
         Caption         =   "Bet"
         Height          =   252
         Index           =   3
         Left            =   3960
         TabIndex        =   60
         Top             =   240
         Width           =   612
      End
      Begin VB.Label Label3 
         Alignment       =   2  'Center
         Caption         =   "Snail"
         Height          =   252
         Index           =   2
         Left            =   3240
         TabIndex        =   59
         Top             =   240
         Width           =   612
      End
      Begin VB.Label MoneyLeftLabel 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         ForeColor       =   &H80000008&
         Height          =   252
         Index           =   1
         Left            =   2280
         TabIndex        =   58
         Top             =   960
         Width           =   852
      End
      Begin VB.Label MoneyLeftLabel 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         ForeColor       =   &H80000008&
         Height          =   252
         Index           =   9
         Left            =   2280
         TabIndex        =   57
         Top             =   3840
         Width           =   852
      End
      Begin VB.Label MoneyLeftLabel 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         ForeColor       =   &H80000008&
         Height          =   252
         Index           =   8
         Left            =   2280
         TabIndex        =   56
         Top             =   3480
         Width           =   852
      End
      Begin VB.Label MoneyLeftLabel 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         ForeColor       =   &H80000008&
         Height          =   252
         Index           =   7
         Left            =   2280
         TabIndex        =   55
         Top             =   3120
         Width           =   852
      End
      Begin VB.Label MoneyLeftLabel 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         ForeColor       =   &H80000008&
         Height          =   252
         Index           =   6
         Left            =   2280
         TabIndex        =   54
         Top             =   2760
         Width           =   852
      End
      Begin VB.Label MoneyLeftLabel 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         ForeColor       =   &H80000008&
         Height          =   252
         Index           =   5
         Left            =   2280
         TabIndex        =   53
         Top             =   2400
         Width           =   852
      End
      Begin VB.Label MoneyLeftLabel 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         ForeColor       =   &H80000008&
         Height          =   252
         Index           =   4
         Left            =   2280
         TabIndex        =   52
         Top             =   2040
         Width           =   852
      End
      Begin VB.Label MoneyLeftLabel 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         ForeColor       =   &H80000008&
         Height          =   252
         Index           =   3
         Left            =   2280
         TabIndex        =   51
         Top             =   1680
         Width           =   852
      End
      Begin VB.Label MoneyLeftLabel 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         ForeColor       =   &H80000008&
         Height          =   252
         Index           =   2
         Left            =   2280
         TabIndex        =   50
         Top             =   1320
         Width           =   852
      End
      Begin VB.Label Label3 
         Alignment       =   2  'Center
         Caption         =   "Money left"
         Height          =   252
         Index           =   1
         Left            =   2280
         TabIndex        =   49
         Top             =   240
         Width           =   852
      End
      Begin VB.Label Label3 
         Alignment       =   2  'Center
         Caption         =   "Names"
         Height          =   252
         Index           =   0
         Left            =   480
         TabIndex        =   48
         Top             =   240
         Width           =   1692
      End
      Begin VB.Label MoneyLeftLabel 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         ForeColor       =   &H80000008&
         Height          =   252
         Index           =   0
         Left            =   2280
         TabIndex        =   47
         Top             =   600
         Width           =   852
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "2"
         Height          =   252
         Index           =   9
         Left            =   120
         TabIndex        =   46
         Top             =   960
         Width           =   252
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "3"
         Height          =   252
         Index           =   8
         Left            =   120
         TabIndex        =   45
         Top             =   1320
         Width           =   252
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "4"
         Height          =   252
         Index           =   7
         Left            =   120
         TabIndex        =   44
         Top             =   1680
         Width           =   252
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "5"
         Height          =   252
         Index           =   6
         Left            =   120
         TabIndex        =   43
         Top             =   2040
         Width           =   252
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "6"
         Height          =   252
         Index           =   5
         Left            =   120
         TabIndex        =   42
         Top             =   2400
         Width           =   252
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "7"
         Height          =   252
         Index           =   4
         Left            =   120
         TabIndex        =   41
         Top             =   2760
         Width           =   252
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "8"
         Height          =   252
         Index           =   3
         Left            =   120
         TabIndex        =   40
         Top             =   3120
         Width           =   252
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "9"
         Height          =   252
         Index           =   2
         Left            =   120
         TabIndex        =   39
         Top             =   3480
         Width           =   252
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "10"
         Height          =   252
         Index           =   1
         Left            =   120
         TabIndex        =   38
         Top             =   3840
         Width           =   252
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "1"
         Height          =   252
         Index           =   0
         Left            =   120
         TabIndex        =   37
         Top             =   600
         Width           =   252
      End
   End
   Begin VB.CommandButton RunTheRaceButton 
      Caption         =   "התחל במרוץ"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   24
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1092
      Left            =   6240
      TabIndex        =   14
      Top             =   4680
      Width           =   1932
   End
   Begin VB.Frame Frame1 
      Appearance      =   0  'Flat
      Caption         =   "טבלת סיכויים"
      ForeColor       =   &H00800000&
      Height          =   3732
      Left            =   4920
      TabIndex        =   1
      Top             =   840
      Width           =   3132
      Begin VB.Label Label6 
         Caption         =   "יחס הימורים"
         Height          =   252
         Left            =   2040
         TabIndex        =   62
         Top             =   240
         Width           =   972
      End
      Begin VB.Label OddsLabel 
         Caption         =   "8"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   252
         Index           =   0
         Left            =   2400
         TabIndex        =   61
         Top             =   480
         Width           =   612
      End
      Begin VB.Label OddsLabel 
         Caption         =   "8"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   252
         Index           =   5
         Left            =   2400
         TabIndex        =   13
         Top             =   2880
         Width           =   612
      End
      Begin VB.Label OddsLabel 
         Caption         =   "8"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   252
         Index           =   4
         Left            =   2400
         TabIndex        =   12
         Top             =   2400
         Width           =   612
      End
      Begin VB.Label OddsLabel 
         Caption         =   "8"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   252
         Index           =   3
         Left            =   2400
         TabIndex        =   11
         Top             =   1920
         Width           =   612
      End
      Begin VB.Label OddsLabel 
         Caption         =   "8"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   252
         Index           =   2
         Left            =   2400
         TabIndex        =   10
         Top             =   1440
         Width           =   612
      End
      Begin VB.Label OddsLabel 
         Caption         =   "8"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   252
         Index           =   1
         Left            =   2400
         TabIndex        =   9
         Top             =   960
         Width           =   612
      End
      Begin VB.Label Label5 
         BackStyle       =   0  'Transparent
         Caption         =   "מהירות"
         Height          =   252
         Left            =   1320
         TabIndex        =   8
         Top             =   3240
         Width           =   612
      End
      Begin VB.Line Line1 
         Index           =   2
         X1              =   2160
         X2              =   2280
         Y1              =   3600
         Y2              =   3480
      End
      Begin VB.Line Line1 
         Index           =   1
         X1              =   2160
         X2              =   2280
         Y1              =   3360
         Y2              =   3480
      End
      Begin VB.Line Line1 
         Index           =   0
         X1              =   360
         X2              =   2280
         Y1              =   3480
         Y2              =   3480
      End
      Begin VB.Label Label4 
         Caption         =   "2"
         Height          =   252
         Index           =   5
         Left            =   120
         TabIndex        =   7
         Top             =   960
         Width           =   132
      End
      Begin VB.Label Label4 
         Caption         =   "3"
         Height          =   252
         Index           =   4
         Left            =   120
         TabIndex        =   6
         Top             =   1440
         Width           =   132
      End
      Begin VB.Label Label4 
         Caption         =   "4"
         Height          =   252
         Index           =   3
         Left            =   120
         TabIndex        =   5
         Top             =   1920
         Width           =   132
      End
      Begin VB.Label Label4 
         Caption         =   "5"
         Height          =   252
         Index           =   2
         Left            =   120
         TabIndex        =   4
         Top             =   2400
         Width           =   132
      End
      Begin VB.Label Label4 
         Caption         =   "6"
         Height          =   252
         Index           =   1
         Left            =   120
         TabIndex        =   3
         Top             =   2880
         Width           =   132
      End
      Begin VB.Label Label4 
         Caption         =   "1"
         Height          =   252
         Index           =   0
         Left            =   120
         TabIndex        =   2
         Top             =   480
         Width           =   132
      End
      Begin VB.Image SnailOdds 
         Height          =   360
         Index           =   5
         Left            =   240
         Picture         =   "frmMain.frx":0508
         Stretch         =   -1  'True
         Top             =   2880
         Width           =   720
      End
      Begin VB.Image SnailOdds 
         Height          =   360
         Index           =   4
         Left            =   240
         Picture         =   "frmMain.frx":2D82
         Stretch         =   -1  'True
         Top             =   2400
         Width           =   720
      End
      Begin VB.Image SnailOdds 
         Height          =   360
         Index           =   3
         Left            =   240
         Picture         =   "frmMain.frx":55FC
         Stretch         =   -1  'True
         Top             =   1920
         Width           =   720
      End
      Begin VB.Image SnailOdds 
         Height          =   360
         Index           =   2
         Left            =   240
         Picture         =   "frmMain.frx":7E76
         Stretch         =   -1  'True
         Top             =   1440
         Width           =   720
      End
      Begin VB.Image SnailOdds 
         Height          =   360
         Index           =   1
         Left            =   240
         Picture         =   "frmMain.frx":A6F0
         Stretch         =   -1  'True
         Top             =   960
         Width           =   720
      End
      Begin VB.Image SnailOdds 
         Height          =   360
         Index           =   0
         Left            =   240
         Picture         =   "frmMain.frx":CF6A
         Stretch         =   -1  'True
         Top             =   480
         Width           =   720
      End
   End
   Begin MCI.MMControl EF0 
      Height          =   492
      Index           =   0
      Left            =   0
      TabIndex        =   72
      Top             =   0
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s0.wav"
   End
   Begin MCI.MMControl EF0 
      Height          =   492
      Index           =   1
      Left            =   0
      TabIndex        =   73
      Top             =   480
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s1.wav"
   End
   Begin MCI.MMControl EF0 
      Height          =   492
      Index           =   2
      Left            =   0
      TabIndex        =   74
      Top             =   960
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s2.wav"
   End
   Begin MCI.MMControl EF0 
      Height          =   492
      Index           =   3
      Left            =   0
      TabIndex        =   75
      Top             =   1440
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s3.wav"
   End
   Begin MCI.MMControl EF0 
      Height          =   492
      Index           =   4
      Left            =   0
      TabIndex        =   76
      Top             =   1920
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s4.wav"
   End
   Begin MCI.MMControl EF0 
      Height          =   492
      Index           =   5
      Left            =   0
      TabIndex        =   77
      Top             =   2400
      Visible         =   0   'False
      Width           =   2832
      _ExtentX        =   4995
      _ExtentY        =   868
      _Version        =   393216
      PlayEnabled     =   -1  'True
      DeviceType      =   ""
      FileName        =   "C:\My Documents\Visual Vb Vc.LIB\VbProjects\TheGreatSnailRace\sounds\s5.wav"
   End
   Begin VB.Image Image2 
      Height          =   1200
      Left            =   120
      Picture         =   "frmMain.frx":F7E4
      Stretch         =   -1  'True
      Top             =   5040
      Width           =   2280
   End
   Begin VB.Image Image1 
      Height          =   1212
      Left            =   2760
      Picture         =   "frmMain.frx":978B6
      Stretch         =   -1  'True
      Top             =   5040
      Width           =   3060
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "THE GREAT SNAIL RACE   I"
      BeginProperty Font 
         Name            =   "Narkisim"
         Size            =   28.2
         Charset         =   177
         Weight          =   350
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C000C0&
      Height          =   612
      Index           =   7
      Left            =   840
      TabIndex        =   0
      Top             =   120
      Width           =   6852
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Sub Form_Load()
    Dim a As Integer
    For a = 0 To 5
        EF0(a).Command = "open"
    Next a
    Me.Width = 8892
    Me.Height = 7000
    'init players and snail data
    For a = 0 To 9
        Player(a).MoneyBet = 0
        Player(a).MoneyLeft = 500
        Player(a).Name = ""
        Player(a).SnailBet = 99 '99-for did not bet yet
    Next a
    SetSnailOdds
    SetPlayersDataOnScreen
End Sub
Sub SetSnailOdds()
    Dim a As Integer
    Randomize
    For a = 0 To 5
        Odds(a) = Int(7 * Rnd) + 1
        SnailOdds(a).Left = 1440 - Odds(a) * 140
        OddsLabel(a) = Odds(a)
    Next a
End Sub


Private Sub Form_Unload(Cancel As Integer)
    Dim a As Integer
    For a = 0 To 5
        EF0(a).Command = "close"
    Next a
End Sub

Private Sub MoneyBetText_Change(Index As Integer)
    If Val(MoneyBetText(Index).Text) > 9999 Then MoneyBetText(Index).Text = 9999
    If Val(MoneyBetText(Index).Text) > Player(Index).MoneyLeft Then MoneyBetText(Index).Text = 0
    If MoneyBetText(Index).Text = "" Then MoneyBetText(Index).Text = "99"
    Player(Index).MoneyBet = Val(MoneyBetText(Index).Text)
End Sub

Private Sub MoneyBetText_GotFocus(Index As Integer)
    MoneyBetText(Index).Text = 0
End Sub

Private Sub NameText_Change(Index As Integer)
    Player(Index).Name = NameText(Index).Text
End Sub

Private Sub RunTheRaceButton_Click()
    Dim a As Integer
    For a = 0 To 5
        EF0(a).Command = "close"
    Next a
    
    frmTheRace.Visible = True
End Sub
Sub SetPlayersDataOnScreen()
    Dim a As Integer
    For a = 0 To 9
        NameText(a).Text = Player(a).Name
        MoneyLeftLabel(a).Caption = Player(a).MoneyLeft
        SnailBetCombo(a).Text = Player(a).SnailBet
        MoneyBetText(a).Text = Player(a).MoneyBet
    Next a
End Sub
Sub InitBets()
    Dim a As Integer
    For a = 0 To 9
        Player(a).MoneyBet = 0
        Player(a).SnailBet = 99
        SetPlayersDataOnScreen
    Next a
End Sub

Private Sub SnailBetCombo_Change(Index As Integer)
    If SnailBetCombo(Index).Text > 99 Then SnailBetCombo(Index).Text = 99
    Player(Index).SnailBet = Val(SnailBetCombo(Index).Text)
    If SnailBetCombo(Index).Text <= 6 And SnailBetCombo(Index).Text >= 1 Then
        EF0(SnailBetCombo(Index).Text - 1).Command = "prev"
        EF0(SnailBetCombo(Index).Text - 1).Command = "play"
        EF0(SnailBetCombo(Index).Text - 1).Command = "prev"
    End If
End Sub

Private Sub SnailBetCombo_Click(Index As Integer)
    Player(Index).SnailBet = Val(SnailBetCombo(Index).Text)
    If SnailBetCombo(Index).Text <= 6 And SnailBetCombo(Index).Text >= 1 Then
        EF0(SnailBetCombo(Index).Text - 1).Command = "prev"
        EF0(SnailBetCombo(Index).Text - 1).Command = "play"
        EF0(SnailBetCombo(Index).Text - 1).Command = "prev"
    End If
End Sub
