VERSION 5.00
Begin VB.Form frmMain 
   BackColor       =   &H00008000&
   Caption         =   "POKER"
   ClientHeight    =   6564
   ClientLeft      =   48
   ClientTop       =   348
   ClientWidth     =   8688
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   6564
   ScaleWidth      =   8688
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   372
      Left            =   9480
      TabIndex        =   42
      Top             =   3120
      Width           =   972
   End
   Begin VB.Frame frameWinner 
      BackColor       =   &H00400000&
      Caption         =   "Winner"
      ForeColor       =   &H00C0C0FF&
      Height          =   2172
      Left            =   1800
      TabIndex        =   27
      Top             =   1920
      Visible         =   0   'False
      Width           =   5052
      Begin VB.CommandButton cmdExit 
         BackColor       =   &H0080C0FF&
         Caption         =   "Exit"
         Height          =   492
         Left            =   3840
         Style           =   1  'Graphical
         TabIndex        =   37
         Top             =   1560
         Width           =   852
      End
      Begin VB.CommandButton cmdNextRound 
         BackColor       =   &H00FF8080&
         Caption         =   "Next round"
         Height          =   492
         Left            =   240
         Style           =   1  'Graphical
         TabIndex        =   29
         Top             =   1560
         Width           =   852
      End
      Begin VB.Label lblWinner 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         Caption         =   "---"
         ForeColor       =   &H00800000&
         Height          =   372
         Left            =   1560
         TabIndex        =   28
         Top             =   1560
         Width           =   1812
      End
      Begin VB.Image imgWinCard 
         Height          =   1152
         Index           =   5
         Left            =   3960
         Picture         =   "frmMain.frx":030A
         Top             =   240
         Width           =   852
      End
      Begin VB.Image imgWinCard 
         Height          =   1152
         Index           =   4
         Left            =   3000
         Picture         =   "frmMain.frx":0A6A
         Top             =   240
         Width           =   852
      End
      Begin VB.Image imgWinCard 
         Height          =   1152
         Index           =   3
         Left            =   2040
         Picture         =   "frmMain.frx":11CA
         Top             =   240
         Width           =   852
      End
      Begin VB.Image imgWinCard 
         Height          =   1152
         Index           =   2
         Left            =   1080
         Picture         =   "frmMain.frx":192A
         Top             =   240
         Width           =   852
      End
      Begin VB.Image imgWinCard 
         Height          =   1152
         Index           =   1
         Left            =   120
         Picture         =   "frmMain.frx":208A
         Top             =   240
         Width           =   852
      End
   End
   Begin VB.ListBox List1 
      Height          =   2736
      Left            =   8880
      TabIndex        =   18
      Top             =   120
      Visible         =   0   'False
      Width           =   2172
   End
   Begin VB.Timer tmrBetting 
      Enabled         =   0   'False
      Interval        =   1000
      Left            =   1080
      Top             =   0
   End
   Begin VB.CommandButton cmdQuit 
      BackColor       =   &H00008000&
      Caption         =   "Quit"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   372
      Left            =   2520
      Style           =   1  'Graphical
      TabIndex        =   17
      Top             =   3600
      Visible         =   0   'False
      Width           =   732
   End
   Begin VB.CommandButton cmdNext 
      BackColor       =   &H00008000&
      Caption         =   "Next"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   372
      Left            =   1800
      Style           =   1  'Graphical
      TabIndex        =   12
      Top             =   3600
      Visible         =   0   'False
      Width           =   732
   End
   Begin VB.Timer tmrPlayers 
      Interval        =   200
      Left            =   720
      Top             =   0
   End
   Begin VB.Timer tmrRun 
      Interval        =   100
      Left            =   360
      Top             =   0
   End
   Begin VB.Frame frame1 
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      Caption         =   "PLAYER 3"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FF8080&
      Height          =   5172
      Index           =   2
      Left            =   7080
      TabIndex        =   2
      Top             =   1080
      Width           =   1452
      Begin VB.Label lblInGame 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00008000&
         Caption         =   "In game"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H008080FF&
         Height          =   252
         Index           =   7
         Left            =   120
         TabIndex        =   34
         Top             =   240
         Width           =   1092
      End
      Begin VB.Label lblChangedCards 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00008000&
         Caption         =   "--"
         ForeColor       =   &H00C0FFC0&
         Height          =   252
         Index           =   3
         Left            =   240
         TabIndex        =   21
         Top             =   4800
         Width           =   972
      End
      Begin VB.Image imgPLayerCard 
         Height          =   792
         Index           =   15
         Left            =   120
         Picture         =   "frmMain.frx":27EA
         Stretch         =   -1  'True
         Top             =   3960
         Width           =   1212
      End
      Begin VB.Image imgPLayerCard 
         Height          =   792
         Index           =   14
         Left            =   120
         Picture         =   "frmMain.frx":2F4A
         Stretch         =   -1  'True
         Top             =   3120
         Width           =   1212
      End
      Begin VB.Image imgPLayerCard 
         Height          =   792
         Index           =   13
         Left            =   120
         Picture         =   "frmMain.frx":36AA
         Stretch         =   -1  'True
         Top             =   2280
         Width           =   1212
      End
      Begin VB.Image imgPLayerCard 
         Height          =   792
         Index           =   12
         Left            =   120
         Picture         =   "frmMain.frx":3E0A
         Stretch         =   -1  'True
         Top             =   1440
         Width           =   1212
      End
      Begin VB.Image imgPLayerCard 
         Height          =   792
         Index           =   11
         Left            =   120
         Picture         =   "frmMain.frx":456A
         Stretch         =   -1  'True
         Top             =   600
         Width           =   1212
      End
   End
   Begin VB.Frame frame1 
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      Caption         =   "PLAYER 2"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FF8080&
      Height          =   1692
      Index           =   1
      Left            =   2160
      TabIndex        =   1
      Top             =   120
      Width           =   4332
      Begin VB.Label lblInGame 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00008000&
         Caption         =   "In game"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H008080FF&
         Height          =   252
         Index           =   6
         Left            =   1560
         TabIndex        =   35
         Top             =   240
         Width           =   1092
      End
      Begin VB.Label lblChangedCards 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00008000&
         Caption         =   "--"
         ForeColor       =   &H00C0FFC0&
         Height          =   252
         Index           =   2
         Left            =   3240
         TabIndex        =   20
         Top             =   240
         Width           =   972
      End
      Begin VB.Image imgPLayerCard 
         Height          =   1032
         Index           =   10
         Left            =   3480
         Picture         =   "frmMain.frx":4CCA
         Stretch         =   -1  'True
         Top             =   480
         Width           =   732
      End
      Begin VB.Image imgPLayerCard 
         Height          =   1032
         Index           =   9
         Left            =   2640
         Picture         =   "frmMain.frx":542A
         Stretch         =   -1  'True
         Top             =   480
         Width           =   732
      End
      Begin VB.Image imgPLayerCard 
         Height          =   1032
         Index           =   8
         Left            =   1800
         Picture         =   "frmMain.frx":5B8A
         Stretch         =   -1  'True
         Top             =   480
         Width           =   732
      End
      Begin VB.Image imgPLayerCard 
         Height          =   1032
         Index           =   7
         Left            =   960
         Picture         =   "frmMain.frx":62EA
         Stretch         =   -1  'True
         Top             =   480
         Width           =   732
      End
      Begin VB.Image imgPLayerCard 
         Height          =   1032
         Index           =   6
         Left            =   120
         Picture         =   "frmMain.frx":6A4A
         Stretch         =   -1  'True
         Top             =   480
         Width           =   732
      End
   End
   Begin VB.Frame frame1 
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      Caption         =   "PLAYER 1"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FF8080&
      Height          =   5172
      Index           =   0
      Left            =   120
      TabIndex        =   0
      Top             =   960
      Width           =   1452
      Begin VB.Label lblInGame 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00008000&
         Caption         =   "In game"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H008080FF&
         Height          =   252
         Index           =   5
         Left            =   120
         TabIndex        =   36
         Top             =   240
         Width           =   1092
      End
      Begin VB.Label lblChangedCards 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00008000&
         Caption         =   "--"
         ForeColor       =   &H0080FF80&
         Height          =   252
         Index           =   1
         Left            =   120
         TabIndex        =   19
         Top             =   4800
         Width           =   972
      End
      Begin VB.Image imgPLayerCard 
         Height          =   792
         Index           =   5
         Left            =   120
         Picture         =   "frmMain.frx":71AA
         Stretch         =   -1  'True
         Top             =   3960
         Width           =   1092
      End
      Begin VB.Image imgPLayerCard 
         Height          =   792
         Index           =   4
         Left            =   120
         Picture         =   "frmMain.frx":790A
         Stretch         =   -1  'True
         Top             =   3120
         Width           =   1092
      End
      Begin VB.Image imgPLayerCard 
         Height          =   792
         Index           =   3
         Left            =   120
         Picture         =   "frmMain.frx":806A
         Stretch         =   -1  'True
         Top             =   2280
         Width           =   1092
      End
      Begin VB.Image imgPLayerCard 
         Height          =   792
         Index           =   2
         Left            =   120
         Picture         =   "frmMain.frx":87CA
         Stretch         =   -1  'True
         Top             =   1440
         Width           =   1092
      End
      Begin VB.Image imgPLayerCard 
         Height          =   792
         Index           =   1
         Left            =   120
         Picture         =   "frmMain.frx":8F2A
         Stretch         =   -1  'True
         Top             =   600
         Width           =   1092
      End
   End
   Begin VB.Frame frame1 
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      Caption         =   "PLAYER 4"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0080C0FF&
      Height          =   2292
      Index           =   3
      Left            =   1920
      TabIndex        =   4
      Top             =   4200
      Width           =   4932
      Begin VB.Label lblInGame 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00008000&
         Caption         =   "In game"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H008080FF&
         Height          =   252
         Index           =   8
         Left            =   3720
         TabIndex        =   33
         Top             =   1560
         Width           =   1092
      End
      Begin VB.Label lblChangedCards 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00008000&
         Caption         =   "--"
         ForeColor       =   &H00C0FFC0&
         Height          =   252
         Index           =   4
         Left            =   3840
         TabIndex        =   22
         Top             =   1920
         Width           =   972
      End
      Begin VB.Image imgPLayerCard 
         Height          =   1152
         Index           =   20
         Left            =   3960
         Picture         =   "frmMain.frx":968A
         Top             =   240
         Width           =   852
      End
      Begin VB.Image imgPLayerCard 
         Height          =   1152
         Index           =   19
         Left            =   3000
         Picture         =   "frmMain.frx":9DEA
         Top             =   240
         Width           =   852
      End
      Begin VB.Image imgPLayerCard 
         Height          =   1152
         Index           =   18
         Left            =   2040
         Picture         =   "frmMain.frx":A54A
         Top             =   240
         Width           =   852
      End
      Begin VB.Image imgPLayerCard 
         Height          =   1152
         Index           =   17
         Left            =   1080
         Picture         =   "frmMain.frx":ACAA
         Top             =   240
         Width           =   852
      End
      Begin VB.Image imgPLayerCard 
         Height          =   1152
         Index           =   16
         Left            =   120
         Picture         =   "frmMain.frx":B40A
         Top             =   240
         Width           =   852
      End
      Begin VB.Label lblPlayerMoney 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00004000&
         Caption         =   "money"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   4
         Left            =   2160
         TabIndex        =   13
         Top             =   1560
         Width           =   1212
      End
      Begin VB.Label lblPlayerCoin 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00008000&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "50"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   13.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C0C0FF&
         Height          =   612
         Index           =   3
         Left            =   1560
         TabIndex        =   8
         Top             =   1560
         Width           =   492
      End
      Begin VB.Label lblPlayerCoin 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00008000&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "10"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   13.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C0C0FF&
         Height          =   612
         Index           =   2
         Left            =   1080
         TabIndex        =   7
         Top             =   1560
         Width           =   492
      End
      Begin VB.Label lblPlayerCoin 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00008000&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "5"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   13.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C0C0FF&
         Height          =   612
         Index           =   1
         Left            =   600
         TabIndex        =   6
         Top             =   1560
         Width           =   492
      End
      Begin VB.Label lblPlayerCoin 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00808000&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "1"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   13.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00C0C0FF&
         Height          =   612
         Index           =   0
         Left            =   120
         TabIndex        =   5
         Top             =   1560
         Width           =   492
      End
   End
   Begin VB.CommandButton cmdCardChange 
      BackColor       =   &H00008000&
      Caption         =   "Change"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   372
      Left            =   2040
      Style           =   1  'Graphical
      TabIndex        =   15
      Top             =   3240
      Visible         =   0   'False
      Width           =   972
   End
   Begin VB.CommandButton cmdDeal 
      BackColor       =   &H00008000&
      Caption         =   "Deal"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   372
      Left            =   2040
      Style           =   1  'Graphical
      TabIndex        =   16
      Top             =   2880
      Visible         =   0   'False
      Width           =   972
   End
   Begin VB.Label lblStartBet 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000040&
      Height          =   252
      Index           =   2
      Left            =   5760
      TabIndex        =   41
      Top             =   1800
      Width           =   732
      WordWrap        =   -1  'True
   End
   Begin VB.Label lblStartBet 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000040&
      Height          =   252
      Index           =   4
      Left            =   6120
      TabIndex        =   40
      Top             =   3960
      Width           =   732
      WordWrap        =   -1  'True
   End
   Begin VB.Label lblStartBet 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000040&
      Height          =   252
      Index           =   3
      Left            =   7800
      TabIndex        =   39
      Top             =   840
      Width           =   732
      WordWrap        =   -1  'True
   End
   Begin VB.Label lblStartBet 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      Caption         =   "START"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000040&
      Height          =   252
      Index           =   1
      Left            =   120
      TabIndex        =   38
      Top             =   720
      Width           =   732
      WordWrap        =   -1  'True
   End
   Begin VB.Label lblPlayerMoney 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "money"
      ForeColor       =   &H00FFC0C0&
      Height          =   252
      Index           =   3
      Left            =   6720
      TabIndex        =   32
      Top             =   600
      Visible         =   0   'False
      Width           =   1212
   End
   Begin VB.Label lblPlayerMoney 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "money"
      ForeColor       =   &H00FFC0C0&
      Height          =   252
      Index           =   1
      Left            =   6720
      TabIndex        =   31
      Top             =   120
      Visible         =   0   'False
      Width           =   1212
   End
   Begin VB.Label lblPlayerMoney 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "money"
      ForeColor       =   &H00FFC0C0&
      Height          =   252
      Index           =   2
      Left            =   6720
      TabIndex        =   30
      Top             =   360
      Visible         =   0   'False
      Width           =   1212
   End
   Begin VB.Label lblInGame 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      Caption         =   "In game"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H008080FF&
      Height          =   252
      Index           =   4
      Left            =   3840
      TabIndex        =   26
      Top             =   3840
      Width           =   1092
   End
   Begin VB.Label lblInGame 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      Caption         =   "In game"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H008080FF&
      Height          =   252
      Index           =   3
      Left            =   5160
      TabIndex        =   25
      Top             =   2280
      Width           =   1092
   End
   Begin VB.Label lblInGame 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      Caption         =   "In game"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H008080FF&
      Height          =   252
      Index           =   1
      Left            =   2400
      TabIndex        =   24
      Top             =   2280
      Width           =   1092
   End
   Begin VB.Label lblInGame 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      Caption         =   "In game"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H008080FF&
      Height          =   252
      Index           =   2
      Left            =   3840
      TabIndex        =   23
      Top             =   2040
      Width           =   1092
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   53
      Left            =   9000
      Picture         =   "frmMain.frx":BB6A
      Top             =   5400
      Width           =   852
   End
   Begin VB.Label lblMessage 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      Caption         =   "Dealing cards"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0080FF80&
      Height          =   612
      Left            =   5160
      TabIndex        =   14
      Top             =   3120
      Width           =   1692
      WordWrap        =   -1  'True
   End
   Begin VB.Label lblBetMoney 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "bet money"
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
      Height          =   252
      Index           =   4
      Left            =   3840
      TabIndex        =   11
      Top             =   3600
      Width           =   1092
   End
   Begin VB.Label lblBetMoney 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "bet money"
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
      Height          =   252
      Index           =   3
      Left            =   5160
      TabIndex        =   10
      Top             =   2520
      Width           =   1092
   End
   Begin VB.Label lblBetMoney 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "bet money"
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
      Height          =   252
      Index           =   1
      Left            =   2400
      TabIndex        =   9
      Top             =   2520
      Width           =   1092
   End
   Begin VB.Label lblBetMoney 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      Caption         =   "bet money"
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
      Height          =   252
      Index           =   2
      Left            =   3840
      TabIndex        =   3
      Top             =   2280
      Width           =   1092
   End
   Begin VB.Image imgTheDec 
      Appearance      =   0  'Flat
      Height          =   816
      Left            =   3720
      Picture         =   "frmMain.frx":C2CA
      Stretch         =   -1  'True
      Top             =   2640
      Width           =   1260
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   52
      Left            =   9000
      Picture         =   "frmMain.frx":CA6B
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   51
      Left            =   9000
      Picture         =   "frmMain.frx":D204
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   50
      Left            =   9000
      Picture         =   "frmMain.frx":D99D
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   49
      Left            =   9000
      Picture         =   "frmMain.frx":E136
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   48
      Left            =   9000
      Picture         =   "frmMain.frx":E8CF
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   47
      Left            =   9000
      Picture         =   "frmMain.frx":F068
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   46
      Left            =   9000
      Picture         =   "frmMain.frx":F801
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   45
      Left            =   9000
      Picture         =   "frmMain.frx":FF9A
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   44
      Left            =   9000
      Picture         =   "frmMain.frx":10733
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   43
      Left            =   9000
      Picture         =   "frmMain.frx":10ECC
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   42
      Left            =   9000
      Picture         =   "frmMain.frx":11665
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   41
      Left            =   9000
      Picture         =   "frmMain.frx":11DFE
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   40
      Left            =   9000
      Picture         =   "frmMain.frx":12597
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   39
      Left            =   9000
      Picture         =   "frmMain.frx":12D30
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   38
      Left            =   9000
      Picture         =   "frmMain.frx":134C9
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   37
      Left            =   9000
      Picture         =   "frmMain.frx":13C62
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   36
      Left            =   9000
      Picture         =   "frmMain.frx":143FB
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   35
      Left            =   9000
      Picture         =   "frmMain.frx":14B94
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   34
      Left            =   9000
      Picture         =   "frmMain.frx":1532D
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   33
      Left            =   9000
      Picture         =   "frmMain.frx":15AC6
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   32
      Left            =   9000
      Picture         =   "frmMain.frx":1625F
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   31
      Left            =   9000
      Picture         =   "frmMain.frx":169F8
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   30
      Left            =   9000
      Picture         =   "frmMain.frx":17191
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   29
      Left            =   9000
      Picture         =   "frmMain.frx":1792A
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   28
      Left            =   9000
      Picture         =   "frmMain.frx":180C3
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   27
      Left            =   9000
      Picture         =   "frmMain.frx":1885C
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   26
      Left            =   9000
      Picture         =   "frmMain.frx":18FF5
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   25
      Left            =   9000
      Picture         =   "frmMain.frx":1978E
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   24
      Left            =   9000
      Picture         =   "frmMain.frx":19F27
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   23
      Left            =   9000
      Picture         =   "frmMain.frx":1A6C0
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   22
      Left            =   9000
      Picture         =   "frmMain.frx":1AE59
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   21
      Left            =   9000
      Picture         =   "frmMain.frx":1B5F2
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   20
      Left            =   9000
      Picture         =   "frmMain.frx":1BD8B
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   19
      Left            =   9000
      Picture         =   "frmMain.frx":1C524
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   18
      Left            =   9000
      Picture         =   "frmMain.frx":1CCBD
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   17
      Left            =   9000
      Picture         =   "frmMain.frx":1D456
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   16
      Left            =   9000
      Picture         =   "frmMain.frx":1DBEF
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   15
      Left            =   9000
      Picture         =   "frmMain.frx":1E388
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   14
      Left            =   9000
      Picture         =   "frmMain.frx":1EB21
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   13
      Left            =   9000
      Picture         =   "frmMain.frx":1F2BA
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   12
      Left            =   9000
      Picture         =   "frmMain.frx":1FA53
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   11
      Left            =   9000
      Picture         =   "frmMain.frx":201EC
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   10
      Left            =   9000
      Picture         =   "frmMain.frx":20985
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   9
      Left            =   9000
      Picture         =   "frmMain.frx":2111E
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   8
      Left            =   9000
      Picture         =   "frmMain.frx":218B7
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   7
      Left            =   9000
      Picture         =   "frmMain.frx":22050
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   6
      Left            =   9000
      Picture         =   "frmMain.frx":227E9
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   5
      Left            =   9000
      Picture         =   "frmMain.frx":22F82
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   4
      Left            =   9000
      Picture         =   "frmMain.frx":2371B
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   3
      Left            =   9000
      Picture         =   "frmMain.frx":23EB4
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   2
      Left            =   9000
      Picture         =   "frmMain.frx":2464D
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   1
      Left            =   9000
      Picture         =   "frmMain.frx":24DE6
      Top             =   5400
      Width           =   852
   End
   Begin VB.Image imgCard 
      Appearance      =   0  'Flat
      Height          =   1152
      Index           =   0
      Left            =   9000
      Picture         =   "frmMain.frx":2557F
      Top             =   5400
      Width           =   852
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmdCardChange_Click()
    gameState = 4
End Sub

Private Sub cmdDeal_Click()
    gameState = 2
End Sub

Private Sub cmdExit_Click()
    End
End Sub

Private Sub cmdNext_Click()
    Dim a As Integer, b As Integer
    Dim topBet As Long
    'calculate topBet
    For a = 1 To 4
        If player(a).bet > topBet Then topBet = player(a).bet
    Next a
    If player(4).bet >= topBet Then
        tmrBetting.Enabled = True
        cmdNext.Visible = False
        cmdQuit.Visible = False
    End If
End Sub

Private Sub cmdNextRound_Click()
    gameState = 0
    tmrPlayers.Enabled = True
    frameWinner.Visible = False
End Sub

Private Sub cmdQuit_Click()
    player(4).inGame = False
    tmrBetting.Enabled = True
    cmdNext.Visible = False
    cmdQuit.Visible = False
End Sub

Private Sub Form_Load()
    Dim a As Integer
    'set players cheat factor
    For a = 1 To 4
        player(a).CheatFactor = getRandom(3) + 2
        List1.AddItem a & " cheat factor=" & player(a).CheatFactor
    Next a
    gameState = 0
    playerCoin = 1      'set player coin value to 1 (1$)
    givePLayersMoney
    lastRoundPlayerBetFirst = 0 'next one will be player 1
    bettingPlayer = 1
    frmMain.Visible = False
End Sub

'used to enable player to change cards position
Private Sub imgPLayerCard_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    If Button = 2 And Index > 15 Then
    imgPLayerCard(Index).Left = imgPLayerCard(Index).Left + X - imgPLayerCard(Index).Width / 2
    imgPLayerCard(Index).Top = imgPLayerCard(Index).Top + Y - imgPLayerCard(Index).Height / 2
    'will check that the card is still on player frame
    If imgPLayerCard(Index).Top + imgPLayerCard(Index).Height / 2 > frame1(3).Height Then imgPLayerCard(Index).Top = frame1(3).Height - imgPLayerCard(Index).Height / 2
    If imgPLayerCard(Index).Top + imgPLayerCard(Index).Height / 2 < 0 Then imgPLayerCard(Index).Top = -imgPLayerCard(Index).Height / 2
    If imgPLayerCard(Index).Left + imgPLayerCard(Index).Width / 2 > frame1(3).Width Then imgPLayerCard(Index).Left = frame1(3).Width - imgPLayerCard(Index).Width / 2
    If imgPLayerCard(Index).Left + imgPLayerCard(Index).Width / 2 < 0 Then imgPLayerCard(Index).Left = -imgPLayerCard(Index).Width / 2
    End If
    
End Sub

'used to mark player cards MAX=3
Private Sub imgPLayerCard_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    'checks if humen cards were left clicked
    If Button = 1 And Index > 15 And gameState = 3 Then
        'the index-15 is because imgCards of the player are 15 to 20 by index
        If player(4).card(Index - 15).cMark = True Then
            'card is marked will un-marked it
            player(4).card(Index - 15).cMark = False
            player(4).cardsMarked = player(4).cardsMarked - 1
        Else
            'card is un-marked will mark it if less then 3 cards are marked
            If player(4).cardsMarked < 3 Then
                player(4).card(Index - 15).cMark = True
                player(4).cardsMarked = player(4).cardsMarked + 1
            End If
        End If
    End If
End Sub

Private Sub lblBetMoney_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    If Button = 1 And (gameState = 1 Or gameState = 5) Then
        playerPay 4, playerCoin
    End If
    If Button = 2 Then
        playerPay 4, -playerCoin
    End If
End Sub

Private Sub lblPlayerCoin_Click(Index As Integer)
    Dim a As Integer
    For a = 0 To 3
        lblPlayerCoin(a).BackColor = &H8000&
    Next a
    lblPlayerCoin(Index).BackColor = &H808000
    Select Case Index
        Case 0
            playerCoin = 1
        Case 1
            playerCoin = 5
        Case 2
            playerCoin = 10
        Case 3
            playerCoin = 50
    End Select
End Sub

Private Sub tmrBetting_Timer()
    Dim bp As Integer
    Dim topBet As Long
    Dim a As Integer, b As Integer
    Dim incBet As Long
    Dim inGameCount As Integer
    Dim isWinner As Boolean
    bp = bettingPlayer
    'calculate top bet on table
    topBet = 0
    For a = 1 To 4
        If player(a).bet > topBet Then topBet = player(a).bet
    Next a
    'count how many players are inGame
    inGameCount = 0
    For a = 1 To 4
        If player(a).inGame = True Then inGameCount = inGameCount + 1
    Next a
    'timerControll used to enable winner check only after first betting round
    '   because at the first betting round all bets are at the starting level
    timerCounter = timerCounter + 1
    If timerCounter > 4 Then
        'disable timerCount to count forever
        If timerCounter > 5 Then timerCounter = 5
        'count inGame players if equal topBet
        b = 0
        For a = 1 To 4
            If player(a).bet = topBet And player(a).inGame = True Then b = b + 1
        Next a
        'check if all inGame players are at the same topBet to close round
        If b = inGameCount Then isWinner = True
        If inGameCount < 2 Then isWinner = True
    End If
    
    'check if there is a winner in the game, do not bet anymore
    If isWinner = False Then
        'check if player is in the game
        If player(bp).inGame = True Then
            'check if computer bet
            If bettingPlayer <> 4 Then
                'computer bet
                lblBetMoney(4).Enabled = False
                cmdNext.Visible = False
                cmdQuit.Visible = False
                'decide next bet
                If getRandom(player(bp).CheatFactor) = 0 Then
                    'fake, big max grade
                    player(bp).maxBet = (player(bp).totalGrade - 50) * 7 + getRandom(30 / player(bp).CheatFactor)
                    If player(bp).totalGrade < 80 Then
                        'small grade
                        incBet = (topBet - player(bp).bet) + 10 + getRandom(10)
                    Else
                        'big grade
                       incBet = (topBet - player(bp).bet) + 5 + getRandom(10)
                    End If
                Else
                    'not fake
                    If player(bp).totalGrade <= 80 Then
                        'small grade, small max bet
                        player(bp).maxBet = (player(bp).totalGrade - 50) * 2 + getRandom(20 / player(bp).CheatFactor)
                        incBet = (topBet - player(bp).bet) + 0 + getRandom(10)
                    Else
                        'big grade, big maxbet
                        player(bp).maxBet = (player(bp).totalGrade - 50) * 7 + getRandom(30 / player(bp).CheatFactor)
                        incBet = (topBet - player(bp).bet) + 30 + getRandom(10)
                    End If
                End If
                List1.AddItem bp & "->" & player(bp).maxBet & " " & incBet, 0
                
                
                'check if player can inc topBet
                If player(bp).bet + incBet <= player(bp).maxBet Then
                    player(bp).bet = player(bp).bet + incBet
                Else
                    'set incBet to equal topBet
                    incBet = (topBet - player(bp).bet)
                    'check if player can equal topBet
                    If player(bp).bet + incBet <= player(bp).maxBet Then
                        player(bp).bet = player(bp).bet + incBet
                    Else
                        player(bp).inGame = False
                    End If  'check if player can equal topBet
                End If  'check if player can inc topBet
            Else
                'heman bet
                tmrBetting.Enabled = False
                cmdNext.Visible = True
                cmdQuit.Visible = True
                lblBetMoney(4).Enabled = True
                'player bet is chacked in cmdNext_onClick()
            End If  'human or computer bet
        End If 'check if player is in the game
       'move to next player
        bettingPlayer = bettingPlayer + 1: If bettingPlayer > 4 Then bettingPlayer = 1
    Else
        tmrBetting.Enabled = False
        tmrPlayers.Enabled = True
        gameState = 6
    End If  'isWinner check
End Sub

Private Sub tmrPlayers_Timer()
    Dim a As Integer, b As Integer
    Select Case gameState
        Case 6
            'finish betting
            frameWinner.Visible = True
            checkWinner imgWinCard, lblWinner, imgCard
            tmrPlayers.Enabled = False
        Case 5
            'betting
            cmdDeal.Visible = False
            cmdCardChange.Visible = False
            cmdNext.Visible = False
            cmdQuit.Visible = False
            lblMessage.Caption = "Betting"
            'set first to bet player, and inc lastRoundBettingPLayer for next round rotatinon
            lastRoundPlayerBetFirst = lastRoundPlayerBetFirst + 1
            If lastRoundPlayerBetFirst > 4 Then
                bettingPlayer = 1
                lastRoundPlayerBetFirst = 1
            End If
            
            bettingPlayer = lastRoundPlayerBetFirst
            tmrBetting.Enabled = True
            tmrPlayers.Enabled = False
            'un-mark all cards
            For a = 1 To 5
                player(4).card(a).cMark = False
            Next a
        
        Case 4
            'changing cards
            '(computer changes cards now)
            setPlayerCardsGrade 1
            setPlayerCardsGrade 2
            setPlayerCardsGrade 3
'            setPlayerCardsGrade 4
            'write changed cards to lblChangedCards
            countMarkedCards 1, lblChangedCards
            countMarkedCards 2, lblChangedCards
            countMarkedCards 3, lblChangedCards
            countMarkedCards 4, lblChangedCards
            deckToPlayer 1
            deckToPlayer 2
            deckToPlayer 3
            deckToPlayer 4
            List1.AddItem "********"
            'call again to change maxBet of players
            setPlayerCardsGrade 1
            setPlayerCardsGrade 2
            setPlayerCardsGrade 3
            setPlayerCardsGrade 4
            gameState = 5
        Case 3
            'waiting for cards change, cmdCardChange (player4 changes cards now)
            cmdDeal.Visible = False
            cmdCardChange.Visible = True
            cmdNext.Visible = False
            cmdQuit.Visible = False
            lblMessage.Caption = "Mark cards for change"
        Case 2
            'mix and deal
            mixDeck
            dealCards
            'computer players pay
            computerPlayersPay player(4).bet
            gameState = 3
        Case 1
            'waiting for first bet, cmdDeal
            cmdDeal.Visible = True
            cmdCardChange.Visible = False
            cmdNext.Visible = False
            cmdQuit.Visible = False
            lblBetMoney(4).Enabled = True
            lblMessage.Caption = "Enter first bet fee"
        Case 0
            'init cards,mix deck,deal cards
            cmdDeal.Visible = False
            cmdCardChange.Visible = False
            cmdNext.Visible = False
            cmdQuit.Visible = False
            startGame imgCard
            gameState = 1
            DoEvents
            frmMain.Visible = True
            'write start betting player in label
            b = lastRoundPlayerBetFirst + 1
            If b > 4 Then b = 1
            For a = 1 To 4
                If a = b Then
                    lblStartBet(a).Caption = "START"
                Else
                    lblStartBet(a).Caption = ""
                End If
            Next a
    End Select
    
End Sub

Private Sub tmrRun_Timer()
    Dim a As Integer, b As Integer
    Dim s As String
    'show players cards, set to "for a=4 to 4" when done programing
    'show only in first states of the game because of extra call to setPlayerCardsGrade
        For a = 4 To 4
            For b = 1 To 5
                    'cards view, marked or not, player cards are 1 to 5 imgCard are 1 to 20
                    If player(a).card(b).cMark = True Then
                        imgPLayerCard((a - 1) * 5 + b).BorderStyle = 1
                    Else
                        imgPLayerCard((a - 1) * 5 + b).BorderStyle = 0
                    End If
            imgPLayerCard((a - 1) * 5 + b).Picture = imgCard(player(a).card(b).imageIndex).Picture
            Next b
        Next a
    'show players data
    For a = 1 To 4
        lblBetMoney(a).Caption = player(a).bet
        lblPlayerMoney(a).Caption = player(a).money
        lblBetMoney(a).Caption = player(a).bet
        If player(a).inGame = True Then
            s = "In game"
        Else
            s = "Out"
        End If
        If lastRoundPlayerBetFirst = a Then
            lblInGame(a).Caption = s
        Else
            lblInGame(a).Caption = s
        End If
    Next a
End Sub


