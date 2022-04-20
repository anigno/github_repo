VERSION 5.00
Begin VB.Form frmMain 
   BackColor       =   &H00004000&
   Caption         =   "The great snail race V2"
   ClientHeight    =   6960
   ClientLeft      =   48
   ClientTop       =   348
   ClientWidth     =   9456
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   6960
   ScaleWidth      =   9456
   StartUpPosition =   2  'CenterScreen
   Begin VB.ListBox List1 
      Height          =   5616
      Left            =   9720
      TabIndex        =   55
      Top             =   840
      Width           =   1572
   End
   Begin VB.CommandButton Command1 
      Caption         =   "debug"
      Height          =   492
      Left            =   10320
      TabIndex        =   54
      Top             =   240
      Width           =   732
   End
   Begin VB.Timer tmrRace 
      Enabled         =   0   'False
      Interval        =   30
      Left            =   8760
      Top             =   360
   End
   Begin VB.Timer tmrDisplay 
      Interval        =   1
      Left            =   8760
      Top             =   720
   End
   Begin VB.Timer tmrGameState 
      Interval        =   10
      Left            =   8760
      Top             =   0
   End
   Begin VB.ComboBox cboSnail 
      BackColor       =   &H00004000&
      ForeColor       =   &H0000FFFF&
      Height          =   288
      Index           =   3
      ItemData        =   "frmMain.frx":030A
      Left            =   3000
      List            =   "frmMain.frx":0320
      TabIndex        =   53
      Text            =   "Pick snail"
      Top             =   1440
      Width           =   1212
   End
   Begin VB.ComboBox cboSnail 
      BackColor       =   &H00004000&
      ForeColor       =   &H0000FFFF&
      Height          =   288
      Index           =   2
      ItemData        =   "frmMain.frx":035E
      Left            =   3000
      List            =   "frmMain.frx":0374
      TabIndex        =   52
      Text            =   "Pick snail"
      Top             =   1080
      Width           =   1212
   End
   Begin VB.ComboBox cboSnail 
      BackColor       =   &H00004000&
      ForeColor       =   &H0000FFFF&
      Height          =   288
      Index           =   1
      ItemData        =   "frmMain.frx":03B2
      Left            =   3000
      List            =   "frmMain.frx":03C8
      TabIndex        =   51
      Text            =   "Pick snail"
      Top             =   720
      Width           =   1212
   End
   Begin VB.CommandButton cmdRunRace 
      BackColor       =   &H0000C0C0&
      Caption         =   "RUN RACE"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   732
      Left            =   7080
      Style           =   1  'Graphical
      TabIndex        =   50
      Top             =   960
      Visible         =   0   'False
      Width           =   1212
   End
   Begin VB.Frame frameCoins 
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "Pick acoin"
      ForeColor       =   &H0000FF00&
      Height          =   1692
      Left            =   5400
      TabIndex        =   30
      Top             =   120
      Width           =   852
      Begin VB.Label lblCoin 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00808000&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "100"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   18
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C0C0FF&
         Height          =   492
         Index           =   2
         Left            =   0
         TabIndex        =   33
         Top             =   1200
         Width           =   852
      End
      Begin VB.Label lblCoin 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00808000&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "10"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   18
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C0C0FF&
         Height          =   492
         Index           =   1
         Left            =   0
         TabIndex        =   32
         Top             =   720
         Width           =   612
      End
      Begin VB.Label lblCoin 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "1"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   18
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C0C0FF&
         Height          =   492
         Index           =   0
         Left            =   0
         TabIndex        =   31
         Top             =   240
         Width           =   372
      End
   End
   Begin VB.ComboBox cboSnail 
      BackColor       =   &H00004000&
      ForeColor       =   &H0000FFFF&
      Height          =   288
      Index           =   0
      ItemData        =   "frmMain.frx":0406
      Left            =   3000
      List            =   "frmMain.frx":041C
      TabIndex        =   17
      Text            =   "Pick snail"
      Top             =   360
      Width           =   1212
   End
   Begin VB.TextBox txtName 
      BackColor       =   &H0000C000&
      ForeColor       =   &H00800000&
      Height          =   288
      Index           =   3
      Left            =   240
      TabIndex        =   5
      Text            =   "anonimous"
      Top             =   1440
      Width           =   1572
   End
   Begin VB.TextBox txtName 
      BackColor       =   &H0000C000&
      ForeColor       =   &H00800000&
      Height          =   288
      Index           =   2
      Left            =   240
      TabIndex        =   4
      Text            =   "anonimous"
      Top             =   1080
      Width           =   1572
   End
   Begin VB.TextBox txtName 
      BackColor       =   &H0000C000&
      ForeColor       =   &H00800000&
      Height          =   288
      Index           =   1
      Left            =   240
      TabIndex        =   3
      Text            =   "anonimous"
      Top             =   720
      Width           =   1572
   End
   Begin VB.TextBox txtName 
      BackColor       =   &H0000C000&
      ForeColor       =   &H00800000&
      Height          =   288
      Index           =   0
      Left            =   240
      TabIndex        =   1
      Text            =   "anonimous"
      Top             =   360
      Width           =   1572
   End
   Begin VB.Frame frameRaceField 
      Appearance      =   0  'Flat
      BackColor       =   &H0000C000&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   4572
      Left            =   120
      TabIndex        =   0
      Top             =   1920
      Width           =   9012
      Begin VB.Frame frameSnailDetails 
         Appearance      =   0  'Flat
         BackColor       =   &H0000C000&
         Caption         =   "Snails details"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.6
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H0080FFFF&
         Height          =   4572
         Left            =   1800
         TabIndex        =   35
         Top             =   0
         Visible         =   0   'False
         Width           =   3972
         Begin VB.Image imgSnail 
            Height          =   468
            Index           =   11
            Left            =   120
            Picture         =   "frmMain.frx":045A
            Stretch         =   -1  'True
            Top             =   3960
            Width           =   1332
         End
         Begin VB.Image imgSnail 
            Height          =   468
            Index           =   10
            Left            =   120
            Picture         =   "frmMain.frx":2CD4
            Stretch         =   -1  'True
            Top             =   3240
            Width           =   1284
         End
         Begin VB.Image imgSnail 
            Height          =   468
            Index           =   9
            Left            =   120
            Picture         =   "frmMain.frx":554E
            Stretch         =   -1  'True
            Top             =   2520
            Width           =   1284
         End
         Begin VB.Image imgSnail 
            Height          =   468
            Index           =   8
            Left            =   120
            Picture         =   "frmMain.frx":7DC8
            Stretch         =   -1  'True
            Top             =   1800
            Width           =   1284
         End
         Begin VB.Image imgSnail 
            Height          =   468
            Index           =   7
            Left            =   120
            Picture         =   "frmMain.frx":A642
            Stretch         =   -1  'True
            Top             =   1080
            Width           =   1164
         End
         Begin VB.Image imgSnail 
            Height          =   468
            Index           =   6
            Left            =   120
            Picture         =   "frmMain.frx":CEBC
            Stretch         =   -1  'True
            Top             =   360
            Width           =   1164
         End
         Begin VB.Label lblOdds 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "Odds"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000040C0&
            Height          =   252
            Index           =   12
            Left            =   2880
            TabIndex        =   49
            Top             =   0
            Width           =   972
         End
         Begin VB.Label lblSpeed 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "Speed"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   252
            Index           =   12
            Left            =   1800
            TabIndex        =   48
            Top             =   0
            Width           =   972
         End
         Begin VB.Label lblOdds 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "3"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000040C0&
            Height          =   252
            Index           =   11
            Left            =   2880
            TabIndex        =   47
            Top             =   4080
            Width           =   972
         End
         Begin VB.Label lblSpeed 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "NORMAL"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   252
            Index           =   11
            Left            =   1800
            TabIndex        =   46
            Top             =   4080
            Width           =   972
         End
         Begin VB.Label lblOdds 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "5"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000040C0&
            Height          =   252
            Index           =   10
            Left            =   2880
            TabIndex        =   45
            Top             =   3360
            Width           =   972
         End
         Begin VB.Label lblSpeed 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "NORMAL"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   252
            Index           =   10
            Left            =   1800
            TabIndex        =   44
            Top             =   3360
            Width           =   972
         End
         Begin VB.Label lblOdds 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "1"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000040C0&
            Height          =   252
            Index           =   9
            Left            =   2880
            TabIndex        =   43
            Top             =   2760
            Width           =   972
         End
         Begin VB.Label lblSpeed 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "SLOW"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   252
            Index           =   9
            Left            =   1800
            TabIndex        =   42
            Top             =   2760
            Width           =   972
         End
         Begin VB.Label lblOdds 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "3"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000040C0&
            Height          =   252
            Index           =   8
            Left            =   2880
            TabIndex        =   41
            Top             =   2040
            Width           =   972
         End
         Begin VB.Label lblSpeed 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "FAST"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   252
            Index           =   8
            Left            =   1800
            TabIndex        =   40
            Top             =   2040
            Width           =   972
         End
         Begin VB.Label lblOdds 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "4"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000040C0&
            Height          =   252
            Index           =   7
            Left            =   2880
            TabIndex        =   39
            Top             =   1320
            Width           =   972
         End
         Begin VB.Label lblSpeed 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "NORMAL"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   252
            Index           =   7
            Left            =   1800
            TabIndex        =   38
            Top             =   1320
            Width           =   972
         End
         Begin VB.Label lblOdds 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "6"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000040C0&
            Height          =   252
            Index           =   6
            Left            =   2880
            TabIndex        =   37
            Top             =   600
            Width           =   972
         End
         Begin VB.Label lblSpeed 
            Alignment       =   2  'Center
            BackColor       =   &H0000C000&
            Caption         =   "FAST"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   9.6
               Charset         =   177
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   252
            Index           =   6
            Left            =   1800
            TabIndex        =   36
            Top             =   600
            Width           =   972
         End
      End
      Begin VB.Line Line1 
         BorderColor     =   &H000000FF&
         BorderWidth     =   5
         Index           =   4
         X1              =   8640
         X2              =   8640
         Y1              =   240
         Y2              =   4560
      End
      Begin VB.Line Line1 
         BorderColor     =   &H000000FF&
         BorderWidth     =   5
         Index           =   7
         X1              =   1680
         X2              =   1680
         Y1              =   240
         Y2              =   4560
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H0000C000&
         BackStyle       =   0  'Transparent
         Caption         =   "SOUSHY"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000080FF&
         Height          =   252
         Index           =   5
         Left            =   480
         TabIndex        =   23
         Top             =   3000
         Width           =   972
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00C0C000&
         BorderWidth     =   5
         Index           =   8
         X1              =   1440
         X2              =   9000
         Y1              =   3120
         Y2              =   3120
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00C0C000&
         BorderWidth     =   5
         Index           =   5
         X1              =   1440
         X2              =   9000
         Y1              =   2400
         Y2              =   2400
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00C0C000&
         BorderWidth     =   5
         Index           =   3
         X1              =   1440
         X2              =   9000
         Y1              =   3840
         Y2              =   3840
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H0000C000&
         BackStyle       =   0  'Transparent
         Caption         =   "LABERF"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000080FF&
         Height          =   252
         Index           =   6
         Left            =   480
         TabIndex        =   16
         Top             =   3720
         Width           =   972
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H0000C000&
         BackStyle       =   0  'Transparent
         Caption         =   "CASTROLL"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000080FF&
         Height          =   252
         Index           =   4
         Left            =   480
         TabIndex        =   15
         Top             =   2280
         Width           =   972
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H0000C000&
         BackStyle       =   0  'Transparent
         Caption         =   "BUSLI"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000080FF&
         Height          =   252
         Index           =   3
         Left            =   600
         TabIndex        =   14
         Top             =   1560
         Width           =   972
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H0000C000&
         BackStyle       =   0  'Transparent
         Caption         =   "LAVLY"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000080FF&
         Height          =   252
         Index           =   2
         Left            =   480
         TabIndex        =   13
         Top             =   840
         Width           =   972
      End
      Begin VB.Label Label1 
         Alignment       =   2  'Center
         BackColor       =   &H0000C000&
         BackStyle       =   0  'Transparent
         Caption         =   "MIRU"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000080FF&
         Height          =   252
         Index           =   1
         Left            =   600
         TabIndex        =   12
         Top             =   120
         Width           =   972
      End
      Begin VB.Image imgSnail 
         Height          =   468
         Index           =   5
         Left            =   2160
         Picture         =   "frmMain.frx":F736
         Top             =   3960
         Width           =   1044
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00C0C000&
         BorderWidth     =   5
         Index           =   6
         X1              =   1440
         X2              =   9000
         Y1              =   4560
         Y2              =   4560
      End
      Begin VB.Image imgSnail 
         Height          =   468
         Index           =   4
         Left            =   2160
         Picture         =   "frmMain.frx":11FB0
         Top             =   3240
         Width           =   1044
      End
      Begin VB.Image imgSnail 
         Height          =   468
         Index           =   3
         Left            =   2160
         Picture         =   "frmMain.frx":1482A
         Top             =   2520
         Width           =   1044
      End
      Begin VB.Image imgSnail 
         Height          =   468
         Index           =   2
         Left            =   2160
         Picture         =   "frmMain.frx":170A4
         Top             =   1800
         Width           =   1044
      End
      Begin VB.Image imgSnail 
         Height          =   468
         Index           =   1
         Left            =   2160
         Picture         =   "frmMain.frx":1991E
         Top             =   1080
         Width           =   1044
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00C0C000&
         BorderWidth     =   5
         Index           =   2
         X1              =   1440
         X2              =   9000
         Y1              =   1680
         Y2              =   1680
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00C0C000&
         BorderWidth     =   5
         Index           =   1
         X1              =   1440
         X2              =   9000
         Y1              =   240
         Y2              =   240
      End
      Begin VB.Line Line1 
         BorderColor     =   &H00C0C000&
         BorderWidth     =   5
         Index           =   0
         X1              =   1440
         X2              =   9000
         Y1              =   960
         Y2              =   960
      End
      Begin VB.Image imgSnail 
         Height          =   468
         Index           =   0
         Left            =   2160
         Picture         =   "frmMain.frx":1C198
         Top             =   360
         Width           =   1044
      End
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H0000C000&
         Caption         =   "1"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   18
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C000C0&
         Height          =   492
         Index           =   0
         Left            =   0
         TabIndex        =   6
         Top             =   360
         Width           =   372
      End
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H0000C000&
         Caption         =   "2"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   18
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C000C0&
         Height          =   492
         Index           =   1
         Left            =   0
         TabIndex        =   7
         Top             =   1080
         Width           =   372
      End
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H0000C000&
         Caption         =   "6"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   18
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C000C0&
         Height          =   492
         Index           =   5
         Left            =   0
         TabIndex        =   11
         Top             =   3960
         Width           =   372
      End
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H0000C000&
         Caption         =   "5"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   18
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C000C0&
         Height          =   492
         Index           =   4
         Left            =   0
         TabIndex        =   10
         Top             =   3240
         Width           =   372
      End
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H0000C000&
         Caption         =   "4"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   18
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C000C0&
         Height          =   492
         Index           =   3
         Left            =   0
         TabIndex        =   9
         Top             =   2520
         Width           =   372
      End
      Begin VB.Label Label2 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H0000C000&
         Caption         =   "3"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   18
            Charset         =   177
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C000C0&
         Height          =   492
         Index           =   2
         Left            =   0
         TabIndex        =   8
         Top             =   1800
         Width           =   372
      End
   End
   Begin VB.Image imgSnailTemplate 
      Height          =   468
      Index           =   3
      Left            =   9600
      Picture         =   "frmMain.frx":1EA12
      Top             =   2880
      Visible         =   0   'False
      Width           =   924
   End
   Begin VB.Image imgSnailTemplate 
      Height          =   468
      Index           =   2
      Left            =   9600
      Picture         =   "frmMain.frx":20DAC
      Top             =   2400
      Visible         =   0   'False
      Width           =   816
   End
   Begin VB.Image imgSnailTemplate 
      Height          =   468
      Index           =   1
      Left            =   9600
      Picture         =   "frmMain.frx":22D02
      Top             =   1920
      Visible         =   0   'False
      Width           =   924
   End
   Begin VB.Image imgSnailTemplate 
      Height          =   468
      Index           =   0
      Left            =   9600
      Picture         =   "frmMain.frx":2509C
      Top             =   1440
      Visible         =   0   'False
      Width           =   1044
   End
   Begin VB.Label lblMessage 
      Alignment       =   2  'Center
      BackColor       =   &H00004000&
      Caption         =   "The great snail race"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C0FFFF&
      Height          =   732
      Left            =   6600
      TabIndex        =   34
      Top             =   120
      Width           =   2052
      WordWrap        =   -1  'True
   End
   Begin VB.Label lblBet 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   312
      Index           =   3
      Left            =   4320
      TabIndex        =   29
      Top             =   1440
      Width           =   972
   End
   Begin VB.Label lblBet 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   312
      Index           =   2
      Left            =   4320
      TabIndex        =   28
      Top             =   1080
      Width           =   972
   End
   Begin VB.Label lblBet 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   312
      Index           =   1
      Left            =   4320
      TabIndex        =   27
      Top             =   720
      Width           =   972
   End
   Begin VB.Label lblMoney 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   312
      Index           =   3
      Left            =   1920
      TabIndex        =   26
      Top             =   1440
      Width           =   972
   End
   Begin VB.Label lblMoney 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   312
      Index           =   2
      Left            =   1920
      TabIndex        =   25
      Top             =   1080
      Width           =   972
   End
   Begin VB.Label lblMoney 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   312
      Index           =   1
      Left            =   1920
      TabIndex        =   24
      Top             =   720
      Width           =   972
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00004000&
      Caption         =   "Bet"
      ForeColor       =   &H0000FFFF&
      Height          =   252
      Index           =   9
      Left            =   4320
      TabIndex        =   22
      Top             =   120
      Width           =   972
   End
   Begin VB.Label lblBet 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   312
      Index           =   0
      Left            =   4320
      TabIndex        =   21
      Top             =   360
      Width           =   972
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00004000&
      Caption         =   "Money"
      ForeColor       =   &H0000FFFF&
      Height          =   252
      Index           =   8
      Left            =   1920
      TabIndex        =   20
      Top             =   120
      Width           =   972
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00004000&
      Caption         =   "Snail to bet"
      ForeColor       =   &H0000FFFF&
      Height          =   252
      Index           =   7
      Left            =   3000
      TabIndex        =   19
      Top             =   120
      Width           =   1212
   End
   Begin VB.Label lblMoney 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "0"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   312
      Index           =   0
      Left            =   1920
      TabIndex        =   18
      Top             =   360
      Width           =   972
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00004000&
      Caption         =   "Player name"
      ForeColor       =   &H0000FFFF&
      Height          =   252
      Index           =   0
      Left            =   240
      TabIndex        =   2
      Top             =   120
      Width           =   972
   End
   Begin VB.Line Line2 
      BorderColor     =   &H00004000&
      BorderWidth     =   3
      Index           =   1
      X1              =   5280
      X2              =   5160
      Y1              =   5880
      Y2              =   5760
   End
   Begin VB.Line Line3 
      BorderColor     =   &H00004000&
      BorderWidth     =   3
      Index           =   0
      X1              =   5280
      X2              =   5280
      Y1              =   5880
      Y2              =   5760
   End
   Begin VB.Line Line2 
      BorderColor     =   &H00004000&
      BorderWidth     =   3
      Index           =   0
      X1              =   5160
      X2              =   5280
      Y1              =   5880
      Y2              =   5760
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cboSnail_Change(Index As Integer)
    If player(Index).betSnail = 99 Then
        cboSnail(Index).Text = "Pick snail"
    Else
        cboSnail(Index).Text = cboSnail(Index).List(player(Index).betSnail)
    End If
End Sub

Private Sub cboSnail_Click(Index As Integer)
    player(Index).betSnail = cboSnail(Index).ListIndex
End Sub

Private Sub cmdRunRace_Click()
    gameState = gameState + 1
    tmrGameState.Enabled = True
End Sub

Private Sub Form_Load()
    gameState = 0
End Sub

Private Sub lblBet_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    If Button = 1 Then
        If player(Index).money >= playerCoin Then
            player(Index).betMoney = player(Index).betMoney + playerCoin
            player(Index).money = player(Index).money - playerCoin
        End If
    Else
        If player(Index).betMoney >= playerCoin Then
            player(Index).betMoney = player(Index).betMoney - playerCoin
            player(Index).money = player(Index).money + playerCoin
        End If
    End If
End Sub

Private Sub lblCoin_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Dim a As Integer
    For a = 0 To 2
        lblCoin(a).BackColor = &H808000
    Next a
    lblCoin(Index).BackColor = &HFF8080
    Select Case Index
        Case 0
            playerCoin = 1
        Case 1
            playerCoin = 10
        Case 2
            playerCoin = 100
    End Select
End Sub

Private Sub tmrDisplay_Timer()
    Dim a As Integer
    For a = 0 To 5
        If frmMain.imgSnail(a).Left <> snail(a).posx Then
            frmMain.imgSnail(a).Left = snail(a).posx
            frmMain.imgSnail(a).Picture = _
                frmMain.imgSnailTemplate(snail(a).drawState).Picture
        End If
    Next a
    For a = 0 To 3
        lblBet(a).Caption = player(a).betMoney
        lblMoney(a).Caption = player(a).money
    Next a
End Sub

Private Sub tmrGameState_Timer()
    Dim a As Integer
    Select Case gameState
        Case 5
            'end race
            tmrRace.Enabled = False
            checkWinner SnailWinner
            lblMessage.Caption = "winner is " & cboSnail(0).List(SnailWinner)
            gameState = 1
        Case 4
            'race
            cmdRunRace.Visible = False
            tmrGameState.Enabled = False
            frmMain.frameSnailDetails.Visible = False
            For a = 0 To 3
                frmMain.lblBet(a).Enabled = False
                frmMain.cboSnail(a).Enabled = False
            Next a
            frmMain.frameCoins.Visible = False
            tmrRace.Enabled = True
            lblMessage.Caption = "RACE !!!"
            initSnails
        Case 3
            'bet, wait in cmdRunRace
            showSnailsDetails
            For a = 0 To 3
                frmMain.lblBet(a).Enabled = True
                frmMain.cboSnail(a).Enabled = True
            Next a
            frmMain.frameCoins.Visible = True
            cmdRunRace.Visible = True
            lblMessage.Caption = "Pick snail and bet some money"
            tmrGameState.Enabled = False
        Case 2
            frameCoins.Visible = True
            gameState = 3
        Case 1
            initSnailDetails
            initPlayers
            cmdRunRace.Visible = False
            tmrRace.Enabled = False
            gameState = 2
        Case 0
            initGame
            gameState = 1
            lblMessage.Caption = "The great snail race"
    End Select
End Sub

Private Sub tmrRace_Timer()
    Dim r As Integer
    r = Int(Rnd * 6)
    snail(r).posx = snail(r).posx + snail(r).speed * 5
    snail(r).drawState = snail(r).drawState + 1
    If snail(r).drawState > 3 Then snail(r).drawState = 0
    If frmMain.imgSnail(r).Left + frmMain.imgSnail(r).Width >= 8640 Then
        DoEvents
        gameState = gameState + 1
        tmrRace.Enabled = False
        tmrGameState.Enabled = True
        SnailWinner = r
    End If
End Sub
