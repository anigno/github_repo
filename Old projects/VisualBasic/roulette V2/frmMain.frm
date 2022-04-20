VERSION 5.00
Begin VB.Form frmMain 
   BackColor       =   &H00004000&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Roulette V1"
   ClientHeight    =   3528
   ClientLeft      =   36
   ClientTop       =   336
   ClientWidth     =   6780
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   3528
   ScaleWidth      =   6780
   Begin VB.CommandButton cmdRunRoulette 
      BackColor       =   &H0000C000&
      Caption         =   "הרץ רולטה"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   252
      Left            =   0
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   3000
      Width           =   1212
   End
   Begin VB.Timer tmrClear 
      Enabled         =   0   'False
      Interval        =   4000
      Left            =   6960
      Top             =   2400
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   139
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
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
      ForeColor       =   &H0080FF80&
      Height          =   372
      Index           =   139
      Left            =   240
      TabIndex        =   150
      Top             =   0
      Width           =   372
   End
   Begin VB.Label lblMessage 
      Alignment       =   2  'Center
      BackColor       =   &H00404000&
      Caption         =   "--"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   13.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFC0C0&
      Height          =   492
      Left            =   1440
      TabIndex        =   1
      Top             =   2880
      Visible         =   0   'False
      Width           =   3132
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   138
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   137
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   136
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   135
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   134
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   133
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   132
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   131
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   130
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   129
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   128
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   127
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   126
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   125
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   124
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   123
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   122
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   121
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   120
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   119
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   118
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   117
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   116
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   115
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   114
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   113
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   112
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   111
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   110
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   109
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   108
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   107
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   106
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   105
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   104
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   103
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   102
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   101
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   100
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   99
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   98
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   97
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   96
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   95
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   94
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   93
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   92
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   91
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   90
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   89
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   88
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   87
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   86
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   85
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   84
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   83
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   82
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   81
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   80
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   79
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   78
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   77
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   76
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   75
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   74
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   73
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   72
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   71
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   70
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   69
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   68
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   67
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   66
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   65
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   64
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   63
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   62
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   61
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   60
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   59
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   58
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   57
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   56
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   55
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   54
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   53
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   52
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   51
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   50
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   49
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   48
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   47
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   46
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   45
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   44
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   43
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   42
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   41
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   40
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   39
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   38
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   37
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   36
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   35
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   34
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   33
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   32
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   31
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   30
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   29
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   28
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   27
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   26
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   25
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   24
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   23
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   22
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   21
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   20
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   19
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   0
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   1
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   2
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   3
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   4
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   5
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   6
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   7
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   8
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   9
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   10
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   11
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   12
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   13
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   14
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   15
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   16
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   17
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Shape coin 
      BorderColor     =   &H0000FFFF&
      FillColor       =   &H00FF8080&
      FillStyle       =   0  'Solid
      Height          =   252
      Index           =   18
      Left            =   6960
      Shape           =   3  'Circle
      Top             =   2760
      Width           =   252
   End
   Begin VB.Label lblBet 
      Alignment       =   2  'Center
      BackColor       =   &H00FFFFFF&
      Caption         =   "bet"
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   132
      Left            =   6480
      TabIndex        =   5
      Top             =   1800
      Width           =   252
   End
   Begin VB.Label lblAmount 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "50"
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   492
      Index           =   3
      Left            =   4080
      TabIndex        =   149
      Top             =   3000
      Width           =   372
   End
   Begin VB.Label lblAmount 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "10"
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   492
      Index           =   2
      Left            =   3600
      TabIndex        =   148
      Top             =   3000
      Width           =   372
   End
   Begin VB.Label lblAmount 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "5"
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   492
      Index           =   1
      Left            =   3120
      TabIndex        =   147
      Top             =   3000
      Width           =   372
   End
   Begin VB.Label lblAmount 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00404000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "1"
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   492
      Index           =   0
      Left            =   2640
      TabIndex        =   146
      Top             =   3000
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "07"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   6
      Left            =   960
      TabIndex        =   145
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "35"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   34
      Left            =   5280
      TabIndex        =   143
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "34"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   33
      Left            =   5280
      TabIndex        =   142
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "33"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   32
      Left            =   4800
      TabIndex        =   141
      Top             =   1440
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "32"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   31
      Left            =   4800
      TabIndex        =   140
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "31"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   30
      Left            =   4800
      TabIndex        =   139
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "30"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   29
      Left            =   4320
      TabIndex        =   138
      Top             =   1440
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "29"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   28
      Left            =   4320
      TabIndex        =   137
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "28"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   27
      Left            =   4320
      TabIndex        =   136
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "27"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   26
      Left            =   3840
      TabIndex        =   135
      Top             =   1440
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "26"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   25
      Left            =   3840
      TabIndex        =   134
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "25"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   24
      Left            =   3840
      TabIndex        =   133
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "24"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   23
      Left            =   3360
      TabIndex        =   132
      Top             =   1440
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "23"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   22
      Left            =   3360
      TabIndex        =   131
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "22"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   21
      Left            =   3360
      TabIndex        =   130
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "21"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   20
      Left            =   2880
      TabIndex        =   129
      Top             =   1440
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "20"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   19
      Left            =   2880
      TabIndex        =   128
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "19"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   18
      Left            =   2880
      TabIndex        =   127
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "18"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   17
      Left            =   2400
      TabIndex        =   126
      Top             =   1440
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "17"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   16
      Left            =   2400
      TabIndex        =   125
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "16"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   15
      Left            =   2400
      TabIndex        =   124
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "15"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   14
      Left            =   1920
      TabIndex        =   123
      Top             =   1440
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "14"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   13
      Left            =   1920
      TabIndex        =   122
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "13"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   12
      Left            =   1920
      TabIndex        =   121
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "12"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   11
      Left            =   1440
      TabIndex        =   120
      Top             =   1440
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "11"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   10
      Left            =   1440
      TabIndex        =   119
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "10"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   9
      Left            =   1440
      TabIndex        =   118
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "09"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   8
      Left            =   960
      TabIndex        =   117
      Top             =   1440
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "08"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   7
      Left            =   960
      TabIndex        =   116
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "06"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   5
      Left            =   480
      TabIndex        =   115
      Top             =   1440
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "05"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   4
      Left            =   480
      TabIndex        =   114
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "04"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   3
      Left            =   480
      TabIndex        =   113
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "03"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   2
      Left            =   0
      TabIndex        =   112
      Top             =   1440
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "02"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   1
      Left            =   0
      TabIndex        =   111
      Top             =   960
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "01"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   0
      Left            =   0
      TabIndex        =   110
      Top             =   480
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   36
      Left            =   0
      TabIndex        =   109
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   37
      Left            =   0
      TabIndex        =   108
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   38
      Left            =   480
      TabIndex        =   107
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   39
      Left            =   480
      TabIndex        =   106
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   40
      Left            =   960
      TabIndex        =   105
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   41
      Left            =   960
      TabIndex        =   104
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   42
      Left            =   1440
      TabIndex        =   103
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   43
      Left            =   1440
      TabIndex        =   102
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   44
      Left            =   1920
      TabIndex        =   101
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   45
      Left            =   1920
      TabIndex        =   100
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   46
      Left            =   2400
      TabIndex        =   99
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   47
      Left            =   2400
      TabIndex        =   98
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   48
      Left            =   2880
      TabIndex        =   97
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   49
      Left            =   2880
      TabIndex        =   96
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   50
      Left            =   3360
      TabIndex        =   95
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   51
      Left            =   3360
      TabIndex        =   94
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   52
      Left            =   3840
      TabIndex        =   93
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   53
      Left            =   3840
      TabIndex        =   92
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   54
      Left            =   4320
      TabIndex        =   91
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   55
      Left            =   4320
      TabIndex        =   90
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   56
      Left            =   4800
      TabIndex        =   89
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   57
      Left            =   4800
      TabIndex        =   88
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   58
      Left            =   5280
      TabIndex        =   87
      Top             =   840
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   59
      Left            =   5280
      TabIndex        =   86
      Top             =   1320
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   60
      Left            =   360
      TabIndex        =   85
      Top             =   480
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   61
      Left            =   360
      TabIndex        =   84
      Top             =   960
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   62
      Left            =   360
      TabIndex        =   83
      Top             =   1440
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   63
      Left            =   840
      TabIndex        =   82
      Top             =   480
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   64
      Left            =   840
      TabIndex        =   81
      Top             =   960
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   65
      Left            =   840
      TabIndex        =   80
      Top             =   1440
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   66
      Left            =   1320
      TabIndex        =   79
      Top             =   480
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   67
      Left            =   1320
      TabIndex        =   78
      Top             =   960
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   68
      Left            =   1320
      TabIndex        =   77
      Top             =   1440
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   69
      Left            =   1800
      TabIndex        =   76
      Top             =   480
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   70
      Left            =   1800
      TabIndex        =   75
      Top             =   960
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   71
      Left            =   1800
      TabIndex        =   74
      Top             =   1440
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   72
      Left            =   2280
      TabIndex        =   73
      Top             =   480
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   73
      Left            =   2280
      TabIndex        =   72
      Top             =   960
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   74
      Left            =   2280
      TabIndex        =   71
      Top             =   1440
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   75
      Left            =   2760
      TabIndex        =   70
      Top             =   480
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   76
      Left            =   2760
      TabIndex        =   69
      Top             =   960
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   77
      Left            =   2760
      TabIndex        =   68
      Top             =   1440
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   78
      Left            =   3240
      TabIndex        =   67
      Top             =   480
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   79
      Left            =   3240
      TabIndex        =   66
      Top             =   960
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   80
      Left            =   3240
      TabIndex        =   65
      Top             =   1440
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   81
      Left            =   3720
      TabIndex        =   64
      Top             =   480
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   82
      Left            =   3720
      TabIndex        =   63
      Top             =   960
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   83
      Left            =   3720
      TabIndex        =   62
      Top             =   1440
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   84
      Left            =   4200
      TabIndex        =   61
      Top             =   480
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   85
      Left            =   4200
      TabIndex        =   60
      Top             =   960
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   86
      Left            =   4200
      TabIndex        =   59
      Top             =   1440
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   87
      Left            =   4680
      TabIndex        =   58
      Top             =   480
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   88
      Left            =   4680
      TabIndex        =   57
      Top             =   960
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   89
      Left            =   4680
      TabIndex        =   56
      Top             =   1440
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   90
      Left            =   5160
      TabIndex        =   55
      Top             =   480
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   91
      Left            =   5160
      TabIndex        =   54
      Top             =   960
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   92
      Left            =   5160
      TabIndex        =   53
      Top             =   1440
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   93
      Left            =   360
      TabIndex        =   52
      Top             =   840
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   94
      Left            =   360
      TabIndex        =   51
      Top             =   1320
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   95
      Left            =   840
      TabIndex        =   50
      Top             =   840
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   96
      Left            =   840
      TabIndex        =   49
      Top             =   1320
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   97
      Left            =   1320
      TabIndex        =   48
      Top             =   840
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   98
      Left            =   1320
      TabIndex        =   47
      Top             =   1320
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   99
      Left            =   1800
      TabIndex        =   46
      Top             =   840
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   100
      Left            =   1800
      TabIndex        =   45
      Top             =   1320
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   101
      Left            =   2280
      TabIndex        =   44
      Top             =   840
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   102
      Left            =   2280
      TabIndex        =   43
      Top             =   1320
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   103
      Left            =   2760
      TabIndex        =   42
      Top             =   840
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   104
      Left            =   2760
      TabIndex        =   41
      Top             =   1320
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   105
      Left            =   3240
      TabIndex        =   40
      Top             =   840
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   106
      Left            =   3240
      TabIndex        =   39
      Top             =   1320
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   107
      Left            =   3720
      TabIndex        =   38
      Top             =   840
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   108
      Left            =   3720
      TabIndex        =   37
      Top             =   1320
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   109
      Left            =   4200
      TabIndex        =   36
      Top             =   840
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   110
      Left            =   4200
      TabIndex        =   35
      Top             =   1320
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   111
      Left            =   4680
      TabIndex        =   34
      Top             =   840
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   112
      Left            =   4680
      TabIndex        =   33
      Top             =   1320
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   113
      Left            =   5160
      TabIndex        =   32
      Top             =   840
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   114
      Left            =   5160
      TabIndex        =   31
      Top             =   1320
      Width           =   132
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   115
      Left            =   0
      TabIndex        =   30
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   116
      Left            =   480
      TabIndex        =   29
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   117
      Left            =   960
      TabIndex        =   28
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   118
      Left            =   1440
      TabIndex        =   27
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   119
      Left            =   1920
      TabIndex        =   26
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   120
      Left            =   2400
      TabIndex        =   25
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   121
      Left            =   2880
      TabIndex        =   24
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   122
      Left            =   3360
      TabIndex        =   23
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   123
      Left            =   3840
      TabIndex        =   22
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   124
      Left            =   4320
      TabIndex        =   21
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   125
      Left            =   4800
      TabIndex        =   20
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   132
      Index           =   126
      Left            =   5280
      TabIndex        =   19
      Top             =   360
      Width           =   372
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "ROW 1"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C0C0FF&
      Height          =   372
      Index           =   127
      Left            =   5640
      TabIndex        =   18
      Top             =   480
      Width           =   852
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "ROW 2"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C0C0FF&
      Height          =   372
      Index           =   128
      Left            =   5640
      TabIndex        =   17
      Top             =   960
      Width           =   852
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "ROW 3"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C0C0FF&
      Height          =   372
      Index           =   129
      Left            =   5640
      TabIndex        =   16
      Top             =   1440
      Width           =   852
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "1 to 12"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C0C0FF&
      Height          =   372
      Index           =   130
      Left            =   0
      TabIndex        =   15
      Top             =   1800
      Width           =   1812
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "13 to 24"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C0C0FF&
      Height          =   372
      Index           =   131
      Left            =   1920
      TabIndex        =   14
      Top             =   1800
      Width           =   1812
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "25 to 36"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C0C0FF&
      Height          =   372
      Index           =   132
      Left            =   3840
      TabIndex        =   13
      Top             =   1800
      Width           =   1812
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "1 to 18"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0080C0FF&
      Height          =   372
      Index           =   133
      Left            =   0
      TabIndex        =   12
      Top             =   2160
      Width           =   2772
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "19 to 36"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0080C0FF&
      Height          =   372
      Index           =   134
      Left            =   2880
      TabIndex        =   11
      Top             =   2160
      Width           =   2772
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "EVEN"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0080C0FF&
      Height          =   372
      Index           =   135
      Left            =   0
      TabIndex        =   10
      Top             =   2520
      Width           =   1332
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "RED"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0080C0FF&
      Height          =   372
      Index           =   136
      Left            =   1440
      TabIndex        =   9
      Top             =   2520
      Width           =   1332
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00000000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "BLACK"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0080C0FF&
      Height          =   372
      Index           =   137
      Left            =   2880
      TabIndex        =   8
      Top             =   2520
      Width           =   1332
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00004000&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "ODD"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0080C0FF&
      Height          =   372
      Index           =   138
      Left            =   4320
      TabIndex        =   7
      Top             =   2520
      Width           =   1332
   End
   Begin VB.Shape pCoin 
      FillColor       =   &H00C0E0FF&
      FillStyle       =   0  'Solid
      Height          =   372
      Index           =   0
      Left            =   2640
      Shape           =   3  'Circle
      Top             =   3000
      Width           =   372
   End
   Begin VB.Shape pCoin 
      FillColor       =   &H0080C0FF&
      FillStyle       =   0  'Solid
      Height          =   372
      Index           =   1
      Left            =   3120
      Shape           =   3  'Circle
      Top             =   3000
      Width           =   372
   End
   Begin VB.Shape pCoin 
      FillColor       =   &H000080FF&
      FillStyle       =   0  'Solid
      Height          =   372
      Index           =   2
      Left            =   3600
      Shape           =   3  'Circle
      Top             =   3000
      Width           =   372
   End
   Begin VB.Shape pCoin 
      FillColor       =   &H000040C0&
      FillStyle       =   0  'Solid
      Height          =   372
      Index           =   3
      Left            =   4080
      Shape           =   3  'Circle
      Top             =   3000
      Width           =   372
   End
   Begin VB.Label lblMoney 
      Alignment       =   2  'Center
      BackColor       =   &H00004000&
      Caption         =   "000"
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   252
      Left            =   4560
      TabIndex        =   6
      Top             =   3240
      Width           =   612
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00004000&
      Caption         =   "כסף"
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   252
      Left            =   4560
      TabIndex        =   4
      Top             =   3000
      Width           =   612
   End
   Begin VB.Label lblLastNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H00008000&
      Caption         =   "--"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   24
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000C0&
      Height          =   492
      Left            =   5640
      TabIndex        =   2
      Top             =   1800
      Width           =   852
   End
   Begin VB.Label cNumber 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H000000C0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "36"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   372
      Index           =   35
      Left            =   5280
      TabIndex        =   144
      Top             =   1440
      Width           =   372
   End
   Begin VB.Shape Shape1 
      FillColor       =   &H00004000&
      FillStyle       =   0  'Solid
      Height          =   2532
      Left            =   0
      Top             =   360
      Width           =   6492
   End
   Begin VB.Label lblCellWin 
      Alignment       =   2  'Center
      BackColor       =   &H00004000&
      Caption         =   "->"
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   252
      Left            =   1200
      TabIndex        =   3
      Top             =   0
      Width           =   4332
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim playerCoinValue As Integer  'value of player coin to put on board
Dim playerMoney As Long
Dim playerName As String
Dim CellData(139) As cellType
Dim playerNumber As Integer

Private Sub cmdEndGame_Click()
    Unload Me
End Sub

Private Sub cmdRunRoulette_Click()
    frmRoulette.Show
End Sub

Private Sub cNumber_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    'will check for left button and clear timer(inc bet and add coin)
    If Button = 1 And tmrClear.Enabled = False And canRunBets = True Then
        'will check if player has money
'        If playerMoney >= playerCoinValue Then
            'will put coin there
            coin(Index).Left = cNumber(Index).Left - coin(Index).Width / 2 + cNumber(Index).Width / 2
            coin(Index).Top = cNumber(Index).Top - coin(Index).Height / 2 + cNumber(Index).Height / 2
            coin(Index).Visible = True
            'update cell betMoney
            CellData(Index).betMoney = CellData(Index).betMoney + playerCoinValue
            'update playerMoney and lblMoney
            playerMoney = playerMoney - playerCoinValue
            lblMoney.Caption = playerMoney
'        End If
    End If
    'will check for right button (dec bet and remove coin)
    If Button = 2 And tmrClear.Enabled = False And canRunBets = True Then
        'will check if there a bet on this cell
        If CellData(Index).betMoney > 0 Then
            'will check if enough betMoney do dec playerCoinValue
            If CellData(Index).betMoney > playerCoinValue Then
                CellData(Index).betMoney = CellData(Index).betMoney - playerCoinValue
                playerMoney = playerMoney + playerCoinValue
            Else
                'will zero the betMoney
                playerMoney = playerMoney + CellData(Index).betMoney
                CellData(Index).betMoney = 0
            End If
            'check and remove coin from board
            If CellData(Index).betMoney = 0 Then coin(Index).Visible = False
        End If
    'update lblMoney
    lblMoney.Caption = playerMoney
    End If
End Sub

Private Sub cNumber_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
'will show the bet on each cNumber() and the winning numbers
    lblBet.Caption = CellData(Index).betMoney
    lblBet.Left = cNumber(Index).Left + cNumber(Index).Width
    lblBet.Top = cNumber(Index).Top + cNumber(Index).Height
    lblCellWin.Caption = CellData(Index).winNumbers & "->" & CellData(Index).winMul
End Sub

Private Sub Form_Load()
    Dim a As Integer
    'will write playerNumber for playerIsOn() array and roulette proccesses
    playerNumber = nextPlayer
    canRunBets = True
    'set position of form
    Me.Left = MDIForm1.Top + nextPlayer * 1000
    Me.Top = MDIForm1.Top + frmControl.Height + nextPlayer * 1000
    'init CellData()
    initCells
    'init the bets
    initBets
    playerCoinValue = 1
    DoEvents
    playerName = InputBox("כתוב את שם המשתמש שלך בבקשה", "ROULETTE V1")
    If playerName = "" Then
        playerName = "lima"
        playerMoney = 100
    End If
    Me.Caption = playerName
    'will try to load player data
    On Error GoTo noFile
    Open App.Path & "\" & playerName For Input As #1
        Input #1, playerMoney
    Close #1
    lblMoney.Caption = playerMoney
    Exit Sub
noFile:
    'no file exist will give new player 100$
    playerMoney = 100
    lblMoney.Caption = playerMoney
End Sub

Private Sub Form_Unload(Cancel As Integer)
    'will set the playerIsOn flag =false
    playerIsOn(playerNumber) = False
    'will save player data
    Open App.Path & "\" & playerName For Output As #1
        Print #1, playerMoney
    Close #1
End Sub

Private Sub lblAmount_Click(Index As Integer)
'set the amount of bet money per click
    Dim a As Integer
    For a = 0 To 3
        lblAmount(a).BackColor = &H4000&
    Next a
    If Index = 0 Then playerCoinValue = 1
    If Index = 1 Then playerCoinValue = 5
    If Index = 2 Then playerCoinValue = 10
    If Index = 3 Then playerCoinValue = 50
    lblAmount(Index).BackColor = &H404000
End Sub

Public Sub checkWin()
'will check if the player won money
    Dim a As Integer
    Dim num As Integer
    Dim sNum As String
    Dim totalWinMoney As Long
    Dim sText As String     'used to disply data to the player on his win, caption or number
    'will get the roulette number from frmRoulette that put it
    '   at lblLastNum of all the frmPlayer()
    num = Val(lblLastNumber.Caption)
    'will correct the sNum if num<10 with additional "0" to two digits
    If num < 10 Then
        sNum = "0" & Trim(Str(num))
    Else
        sNum = Trim(Str(num))
    End If
    'check for winning
'    frmLists.Visible = True
    For a = 0 To 139
        'will check if the roulette number is in the cell winNumbers
        If InStr(1, CellData(a).winNumbers, sNum) <> 0 Then
            'will pay the player if he had abet in this cell
            playerMoney = playerMoney + CellData(a).betMoney * CellData(a).winMul
            'will check if there was any money there
            If CellData(a).betMoney > 0 Then
                'will add win to frmLists
                frmLists.Visible = True
                DoEvents
               'will set the player won message
               If cNumber(a).Caption = "" Then
                sText = sNum
                Else
                    sText = cNumber(a).Caption
                End If
                frmLists.List1.AddItem playerName & " won <" & _
                                       sText & _
                                       "> " & CellData(a).betMoney & " * " & _
                                       CellData(a).winMul & " = " & _
                                       CellData(a).betMoney * CellData(a).winMul

            End If
        End If
    Next a
    lblMoney.Caption = playerMoney
    lblMessage.Caption = "המתן בבקשה!"
    lblMessage.Visible = True
End Sub

Public Sub initBets()
    Dim a As Integer
    For a = 0 To 139
        coin(a).Visible = False
        CellData(a).betMoney = 0
    Next a
End Sub

Private Sub tmrClear_Timer()
    initBets
    tmrClear.Enabled = False
    lblMessage.Visible = False
End Sub

Public Sub initCells()
    Dim dammS As String 'used as damm string to get un-needed explaination string from file
    Dim a As Integer
    Open App.Path & "/rollete.dat" For Input As #1
    Input #1, dammS
    Input #1, dammS
    a = 0
    While (Not EOF(1))
        With CellData(a)
            Input #1, .winNumbers
            Input #1, .winMul
        End With
        a = a + 1
        Input #1, dammS
    Wend
    Close #1
End Sub

Public Function checkCorrectBets() As Boolean
    Dim a As Integer
    Dim fOk As Boolean      'flag, does all bets are OK
    'will check for correct bets of all players(only the cellData of
     '   special cells 127 to 138
    fOk = True
    For a = 127 To 138
        'will check if there is abet on the cell
        If CellData(a).betMoney <> 0 Then
            'will check that the bet is ok
            If CellData(a).betMoney < 5 Or _
               CellData(a).betMoney > 200 _
               Then fOk = False
               frmLists.List1.AddItem playerName & _
               " has problem with <" & _
               cNumber(a).Caption & "> = " & _
               CellData(a).betMoney
        End If
    Next a
    checkCorrectBets = fOk
End Function
