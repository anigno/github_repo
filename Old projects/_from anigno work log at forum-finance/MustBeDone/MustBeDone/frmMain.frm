VERSION 5.00
Begin VB.Form frmMain 
   Caption         =   "MustBeDone"
   ClientHeight    =   6396
   ClientLeft      =   132
   ClientTop       =   360
   ClientWidth     =   10992
   Icon            =   "frmMain.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   NegotiateMenus  =   0   'False
   ScaleHeight     =   6396
   ScaleWidth      =   10992
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame Frame3 
      Height          =   732
      Left            =   120
      TabIndex        =   102
      Top             =   4920
      Width           =   3012
      Begin VB.CommandButton PrintFrmMain 
         Caption         =   "הדפס"
         Height          =   372
         Left            =   120
         TabIndex        =   106
         TabStop         =   0   'False
         Top             =   240
         Width           =   612
      End
      Begin VB.CommandButton HelpView 
         Caption         =   "מסך עזרה"
         Height          =   372
         Left            =   840
         TabIndex        =   105
         TabStop         =   0   'False
         ToolTipText     =   "מסך עזרה לקיצורי דרך"
         Top             =   240
         Width           =   612
      End
      Begin VB.CommandButton CopyToA 
         Caption         =   "יצוא"
         Height          =   372
         Left            =   2280
         RightToLeft     =   -1  'True
         TabIndex        =   104
         TabStop         =   0   'False
         ToolTipText     =   "העתקת חודש לדיסקט"
         Top             =   240
         Width           =   612
      End
      Begin VB.CommandButton CopyFromA 
         Caption         =   "יבוא"
         Height          =   372
         Left            =   1560
         RightToLeft     =   -1  'True
         TabIndex        =   103
         TabStop         =   0   'False
         ToolTipText     =   "העתקת חודש מדיסקט"
         Top             =   240
         Width           =   612
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "משימות"
      Height          =   4692
      Left            =   0
      TabIndex        =   55
      Top             =   120
      Width           =   3252
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   17
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   101
         TabStop         =   0   'False
         Text            =   "23:00"
         Top             =   4080
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   16
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   100
         TabStop         =   0   'False
         Text            =   "24:00"
         Top             =   4320
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   15
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   99
         TabStop         =   0   'False
         Text            =   "21:00"
         Top             =   3600
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   14
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   98
         TabStop         =   0   'False
         Text            =   "22:00"
         Top             =   3840
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   13
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   97
         TabStop         =   0   'False
         Text            =   "19:00"
         Top             =   3120
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   12
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   96
         TabStop         =   0   'False
         Text            =   "20:00"
         Top             =   3360
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   11
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   95
         TabStop         =   0   'False
         Text            =   "17:00"
         Top             =   2640
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   10
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   94
         TabStop         =   0   'False
         Text            =   "18:00"
         Top             =   2880
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   9
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   93
         TabStop         =   0   'False
         Text            =   "15:30"
         Top             =   2160
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   8
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   92
         TabStop         =   0   'False
         Text            =   "16:30"
         Top             =   2400
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   7
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   91
         TabStop         =   0   'False
         Text            =   "13:30"
         Top             =   1680
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   6
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   90
         TabStop         =   0   'False
         Text            =   "14:30"
         Top             =   1920
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   5
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   84
         TabStop         =   0   'False
         Text            =   "11:30"
         Top             =   1200
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   4
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   82
         TabStop         =   0   'False
         Text            =   "12:30"
         Top             =   1440
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   3
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   80
         TabStop         =   0   'False
         Text            =   "9:30"
         Top             =   720
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   2
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   78
         TabStop         =   0   'False
         Text            =   "10:30"
         Top             =   960
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   1
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   76
         TabStop         =   0   'False
         Text            =   "8:30"
         Top             =   480
         Width           =   492
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   0
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   74
         TabStop         =   0   'False
         Text            =   "7:30"
         Top             =   240
         Width           =   492
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   17
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   73
         Top             =   4320
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   16
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   72
         Top             =   4080
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   15
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   71
         Top             =   3840
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   14
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   70
         Top             =   3600
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   13
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   69
         Top             =   3360
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   12
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   68
         Top             =   3120
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   11
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   67
         Top             =   2880
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   10
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   66
         Top             =   2640
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   9
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   65
         Top             =   2400
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   8
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   64
         Top             =   2160
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   7
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   63
         Top             =   1920
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   6
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   62
         Top             =   1680
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   5
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   61
         Top             =   1440
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   4
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   60
         Top             =   1200
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   3
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   59
         Top             =   960
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   2
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   58
         Top             =   720
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   1
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   57
         Top             =   480
         Width           =   2532
      End
      Begin VB.TextBox ActionText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H0080C0FF&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   7.8
            Charset         =   177
            Weight          =   350
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   228
         Index           =   0
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   56
         Top             =   240
         Width           =   2532
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "תזכירים"
      Height          =   2772
      Left            =   3360
      TabIndex        =   48
      Top             =   3240
      Width           =   3852
      Begin VB.CheckBox MemoDoneCheck 
         Height          =   192
         Index           =   9
         Left            =   3600
         TabIndex        =   110
         TabStop         =   0   'False
         Top             =   2400
         Width           =   132
      End
      Begin VB.CheckBox MemoDoneCheck 
         Height          =   192
         Index           =   8
         Left            =   3600
         TabIndex        =   109
         TabStop         =   0   'False
         Top             =   2160
         Width           =   132
      End
      Begin VB.CheckBox MemoDoneCheck 
         Height          =   192
         Index           =   7
         Left            =   3600
         TabIndex        =   108
         TabStop         =   0   'False
         Top             =   1920
         Width           =   132
      End
      Begin VB.CheckBox MemoDoneCheck 
         Height          =   192
         Index           =   6
         Left            =   3600
         TabIndex        =   107
         TabStop         =   0   'False
         Top             =   1680
         Width           =   132
      End
      Begin VB.TextBox MemoText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   10.2
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   288
         Index           =   9
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   89
         Top             =   2400
         Width           =   3372
      End
      Begin VB.TextBox MemoText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   10.2
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   288
         Index           =   8
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   88
         Top             =   2160
         Width           =   3372
      End
      Begin VB.TextBox MemoText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   10.2
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   288
         Index           =   7
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   87
         Top             =   1920
         Width           =   3372
      End
      Begin VB.TextBox MemoText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   10.2
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   288
         Index           =   6
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   86
         Top             =   1680
         Width           =   3372
      End
      Begin VB.TextBox MemoText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   10.2
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   288
         Index           =   0
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   75
         Top             =   240
         Width           =   3372
      End
      Begin VB.CheckBox MemoDoneCheck 
         Height          =   192
         Index           =   0
         Left            =   3600
         TabIndex        =   54
         TabStop         =   0   'False
         Top             =   240
         Width           =   132
      End
      Begin VB.TextBox MemoText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   10.2
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   288
         Index           =   1
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   77
         Top             =   480
         Width           =   3372
      End
      Begin VB.TextBox MemoText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   10.2
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   288
         Index           =   2
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   79
         Top             =   720
         Width           =   3372
      End
      Begin VB.TextBox MemoText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   10.2
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   288
         Index           =   3
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   81
         Top             =   960
         Width           =   3372
      End
      Begin VB.TextBox MemoText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   10.2
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   288
         Index           =   4
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   83
         Top             =   1200
         Width           =   3372
      End
      Begin VB.TextBox MemoText 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BeginProperty Font 
            Name            =   "Miriam"
            Size            =   10.2
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   288
         Index           =   5
         Left            =   120
         RightToLeft     =   -1  'True
         TabIndex        =   85
         Top             =   1440
         Width           =   3372
      End
      Begin VB.CheckBox MemoDoneCheck 
         Height          =   192
         Index           =   1
         Left            =   3600
         TabIndex        =   53
         TabStop         =   0   'False
         Top             =   480
         Width           =   132
      End
      Begin VB.CheckBox MemoDoneCheck 
         Height          =   192
         Index           =   2
         Left            =   3600
         TabIndex        =   52
         TabStop         =   0   'False
         Top             =   720
         Width           =   132
      End
      Begin VB.CheckBox MemoDoneCheck 
         Height          =   192
         Index           =   3
         Left            =   3600
         TabIndex        =   51
         TabStop         =   0   'False
         Top             =   960
         Width           =   132
      End
      Begin VB.CheckBox MemoDoneCheck 
         Height          =   192
         Index           =   4
         Left            =   3600
         TabIndex        =   50
         TabStop         =   0   'False
         Top             =   1200
         Width           =   132
      End
      Begin VB.CheckBox MemoDoneCheck 
         Height          =   192
         Index           =   5
         Left            =   3600
         TabIndex        =   49
         TabStop         =   0   'False
         Top             =   1440
         Width           =   132
      End
   End
   Begin VB.CommandButton ExitButton 
      Caption         =   "EXIT"
      Height          =   252
      Left            =   8760
      TabIndex        =   47
      TabStop         =   0   'False
      Top             =   0
      Width           =   732
   End
   Begin VB.Timer Run 
      Interval        =   200
      Left            =   2880
      Top             =   5880
   End
   Begin VB.ListBox MemoList 
      Height          =   6000
      Left            =   7320
      RightToLeft     =   -1  'True
      TabIndex        =   38
      TabStop         =   0   'False
      Top             =   360
      Width           =   3612
   End
   Begin VB.Frame NewCalendar 
      Caption         =   "WeekDay/Day/Month/Year"
      BeginProperty Font 
         Name            =   "Miriam"
         Size            =   12
         Charset         =   177
         Weight          =   350
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C00000&
      Height          =   3012
      Left            =   3360
      TabIndex        =   0
      Top             =   120
      Width           =   3852
      Begin VB.CommandButton TodayButton 
         Height          =   372
         Left            =   3120
         Picture         =   "frmMain.frx":0442
         Style           =   1  'Graphical
         TabIndex        =   37
         TabStop         =   0   'False
         ToolTipText     =   "היום"
         Top             =   1680
         Width           =   252
      End
      Begin VB.CommandButton NextMonthButton 
         Height          =   252
         Left            =   3120
         Picture         =   "frmMain.frx":0884
         Style           =   1  'Graphical
         TabIndex        =   36
         TabStop         =   0   'False
         ToolTipText     =   "חודש הבא"
         Top             =   1440
         Width           =   252
      End
      Begin VB.CommandButton NextDayButton 
         Height          =   372
         Left            =   3360
         Picture         =   "frmMain.frx":0CC6
         Style           =   1  'Graphical
         TabIndex        =   35
         TabStop         =   0   'False
         ToolTipText     =   "מחר"
         Top             =   1680
         Width           =   252
      End
      Begin VB.CommandButton PrevDayButton 
         Height          =   372
         Left            =   2880
         Picture         =   "frmMain.frx":1108
         Style           =   1  'Graphical
         TabIndex        =   34
         TabStop         =   0   'False
         ToolTipText     =   "אתמול"
         Top             =   1680
         Width           =   252
      End
      Begin VB.CommandButton PrevMonthButton 
         Height          =   252
         Left            =   3120
         Picture         =   "frmMain.frx":154A
         Style           =   1  'Graphical
         TabIndex        =   33
         TabStop         =   0   'False
         ToolTipText     =   "חודש קודם"
         Top             =   2040
         Width           =   252
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   31
         Left            =   1320
         Style           =   1  'Graphical
         TabIndex        =   31
         TabStop         =   0   'False
         Top             =   2040
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   30
         Left            =   960
         Style           =   1  'Graphical
         TabIndex        =   30
         TabStop         =   0   'False
         Top             =   2040
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   29
         Left            =   600
         Style           =   1  'Graphical
         TabIndex        =   29
         TabStop         =   0   'False
         Top             =   2040
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   28
         Left            =   240
         Style           =   1  'Graphical
         TabIndex        =   28
         TabStop         =   0   'False
         Top             =   2040
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   27
         Left            =   2400
         Style           =   1  'Graphical
         TabIndex        =   27
         TabStop         =   0   'False
         Top             =   1680
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   26
         Left            =   2040
         Style           =   1  'Graphical
         TabIndex        =   26
         TabStop         =   0   'False
         Top             =   1680
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   25
         Left            =   1680
         Style           =   1  'Graphical
         TabIndex        =   25
         TabStop         =   0   'False
         Top             =   1680
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   24
         Left            =   1320
         Style           =   1  'Graphical
         TabIndex        =   24
         TabStop         =   0   'False
         Top             =   1680
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   23
         Left            =   960
         Style           =   1  'Graphical
         TabIndex        =   23
         TabStop         =   0   'False
         Top             =   1680
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   22
         Left            =   600
         Style           =   1  'Graphical
         TabIndex        =   22
         TabStop         =   0   'False
         Top             =   1680
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   21
         Left            =   240
         Style           =   1  'Graphical
         TabIndex        =   21
         TabStop         =   0   'False
         Top             =   1680
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         BackColor       =   &H00C0C0C0&
         Caption         =   "##"
         Height          =   372
         Index           =   20
         Left            =   2400
         Style           =   1  'Graphical
         TabIndex        =   20
         TabStop         =   0   'False
         Top             =   1320
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   19
         Left            =   2040
         Style           =   1  'Graphical
         TabIndex        =   19
         TabStop         =   0   'False
         Top             =   1320
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   18
         Left            =   1680
         Style           =   1  'Graphical
         TabIndex        =   18
         TabStop         =   0   'False
         Top             =   1320
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   17
         Left            =   1320
         Style           =   1  'Graphical
         TabIndex        =   17
         TabStop         =   0   'False
         Top             =   1320
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   16
         Left            =   960
         Style           =   1  'Graphical
         TabIndex        =   16
         TabStop         =   0   'False
         Top             =   1320
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   15
         Left            =   600
         Style           =   1  'Graphical
         TabIndex        =   15
         TabStop         =   0   'False
         Top             =   1320
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   14
         Left            =   240
         Style           =   1  'Graphical
         TabIndex        =   14
         TabStop         =   0   'False
         Top             =   1320
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   13
         Left            =   2400
         Style           =   1  'Graphical
         TabIndex        =   13
         TabStop         =   0   'False
         Top             =   960
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   12
         Left            =   2040
         Style           =   1  'Graphical
         TabIndex        =   12
         TabStop         =   0   'False
         Top             =   960
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   11
         Left            =   1680
         Style           =   1  'Graphical
         TabIndex        =   11
         TabStop         =   0   'False
         Top             =   960
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   10
         Left            =   1320
         Style           =   1  'Graphical
         TabIndex        =   10
         TabStop         =   0   'False
         Top             =   960
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   9
         Left            =   960
         Style           =   1  'Graphical
         TabIndex        =   9
         TabStop         =   0   'False
         Top             =   960
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   8
         Left            =   600
         Style           =   1  'Graphical
         TabIndex        =   8
         TabStop         =   0   'False
         Top             =   960
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   7
         Left            =   240
         Style           =   1  'Graphical
         TabIndex        =   7
         TabStop         =   0   'False
         Top             =   960
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   6
         Left            =   1680
         Style           =   1  'Graphical
         TabIndex        =   6
         TabStop         =   0   'False
         Top             =   2040
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         BackColor       =   &H00C0C0C0&
         Caption         =   "##"
         Height          =   372
         Index           =   5
         Left            =   2040
         Style           =   1  'Graphical
         TabIndex        =   5
         TabStop         =   0   'False
         Top             =   2040
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   4
         Left            =   2400
         Style           =   1  'Graphical
         TabIndex        =   4
         TabStop         =   0   'False
         Top             =   2040
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   3
         Left            =   2400
         Style           =   1  'Graphical
         TabIndex        =   3
         TabStop         =   0   'False
         Top             =   2400
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         Caption         =   "##"
         Height          =   372
         Index           =   2
         Left            =   2040
         Style           =   1  'Graphical
         TabIndex        =   2
         TabStop         =   0   'False
         Top             =   2400
         Width           =   372
      End
      Begin VB.CommandButton DayButton 
         Appearance      =   0  'Flat
         BackColor       =   &H00C0C0C0&
         Caption         =   "##"
         Height          =   372
         Index           =   1
         Left            =   240
         Style           =   1  'Graphical
         TabIndex        =   1
         TabStop         =   0   'False
         Top             =   600
         Width           =   372
      End
      Begin VB.Label DaysLabel 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "ו"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   252
         Index           =   6
         Left            =   2040
         TabIndex        =   46
         Top             =   360
         Width           =   372
      End
      Begin VB.Label DaysLabel 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "ה"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00008000&
         Height          =   252
         Index           =   5
         Left            =   1680
         TabIndex        =   45
         Top             =   360
         Width           =   372
      End
      Begin VB.Label DaysLabel 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "ד"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00008000&
         Height          =   252
         Index           =   4
         Left            =   1320
         TabIndex        =   44
         Top             =   360
         Width           =   372
      End
      Begin VB.Label DaysLabel 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "ג"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00008000&
         Height          =   252
         Index           =   3
         Left            =   960
         TabIndex        =   43
         Top             =   360
         Width           =   372
      End
      Begin VB.Label DaysLabel 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "ב"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00008000&
         Height          =   252
         Index           =   2
         Left            =   600
         TabIndex        =   42
         Top             =   360
         Width           =   372
      End
      Begin VB.Label DaysLabel 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "א"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00008000&
         Height          =   252
         Index           =   1
         Left            =   240
         TabIndex        =   41
         Top             =   360
         Width           =   372
      End
      Begin VB.Label TimeLabel 
         Alignment       =   2  'Center
         BackColor       =   &H00004000&
         Caption         =   "TimeLabel"
         ForeColor       =   &H0080FFFF&
         Height          =   252
         Left            =   3000
         TabIndex        =   39
         Top             =   960
         Width           =   612
      End
      Begin VB.Label DaysLabel 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "שבת"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   177
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000C0&
         Height          =   252
         Index           =   0
         Left            =   2400
         TabIndex        =   32
         Top             =   360
         Width           =   372
      End
      Begin VB.Image Image1 
         Height          =   912
         Left            =   2880
         Picture         =   "frmMain.frx":198C
         Stretch         =   -1  'True
         Top             =   360
         Width           =   828
      End
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
      Left            =   9600
      TabIndex        =   40
      ToolTipText     =   "גינה רוני saharon@t2.technion.ac.il"
      Top             =   0
      Width           =   1332
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Sub ClearData()
    Dim a, b As Integer
    For a = 1 To 31
        For b = 0 To 9
            Memo(a, b) = ""
            MemoDone(a, b) = 0
        Next b
        For b = 0 To 17
            Action(a, b) = ""
        Next b
    Next a
End Sub
Sub DrawMonth()
    'drawing the month
    Dim a, b, Mflag As Integer
    Dim s1 As String
    For a = 1 To 31
        DayButton(a).Visible = False
        DayButton(a).Caption = a
        DayButton(a).BackColor = &HC0C0C0       'LightGray for regular paint
        'will check for memos to paint it gray
        Mflag = 0
        For b = 0 To 9
            If Memo(a, b) <> "" And MemoDone(a, b) <> 1 Then Mflag = 1  'dark gray for busy
        Next b
        For b = 0 To 9
            s1 = Memo(a, b)
            If InStr(s1, "@") > 0 And MemoDone(a, b) <> 1 Then Mflag = 2
        Next b
        For b = 0 To 9
            s1 = Memo(a, b)
            If InStr(s1, "!") > 0 And MemoDone(a, b) <> 1 Then Mflag = 3
        Next b
        If Mflag = 1 Then DayButton(a).BackColor = &H808080
        If Mflag = 2 Then DayButton(a).BackColor = &H80FF&
        If Mflag = 3 Then DayButton(a).BackColor = &HFF0
        'will check for Today on date to paint it LightPurple
        If a = Day(Date) And TheMonth = Month(Date) And TheYear = Year(Date) Then
            DayButton(a).BackColor = &HFF8080   'LightPurple for ToDay
        End If
        'will check for current day and paint it LightGreen
        If a = TheDay Then
            DayButton(a).BackColor = &H80FF80   'LightGreen for current
            'If Mflag = 1 Then DayButton(a).BackColor = DayButton(a).BackColor + 30
        End If
        DayButton(a).Left = 200 + (372 * Int((a + FirstDay - 1) - Int((a + FirstDay - 1) / 7) * 7))
        DayButton(a).Top = 600 + 372 * Int(Int(a + FirstDay - 1) / 7)
        If a <= LastDay Then DayButton(a).Visible = True
    Next a
    SetDayDataOnScreen
    SetMemoList
    SetHeaders
End Sub
Sub SaveFile(WhereTo As String)
    'save TheYear+TheMonth file
    Dim a, b As Integer
    Open WhereTo & ":\MustBeDone\" & TheYear & TheMonth & ".MbD" For Output As #1
    For a = 1 To 31
        For b = 0 To 9
            Write #1, Memo(a, b)
            Write #1, MemoDone(a, b)
        Next b
        For b = 0 To 17
            Write #1, Action(a, b)
        Next b
    Next a
    Close #1
End Sub
Sub LoadFile(WhereFrom As String)
    'check for exist TheYear+TheMonth file in not creat one
    'then load it
    Dim a, b As Integer
    On Error GoTo NoFile
    Open WhereFrom & ":\MustBeDone\" & TheYear & TheMonth & ".MbD" For Input As #1
    For a = 1 To 31
        For b = 0 To 9
            Input #1, Memo(a, b)
            Input #1, MemoDone(a, b)
        Next b
        For b = 0 To 17
            Input #1, Action(a, b)
        Next b
    Next a
    Close #1
    SetDayDataOnScreen
    Exit Sub
NoFile:
    SaveFile ("c")
    SetDayDataOnScreen
End Sub
Sub SetCalendar()
'will set and draw the calendar according to : TheDay,TheMonth,TheYear
'will set FirstDay & LasDay values
'Importest !, no check is made on input values !
    Dim YearCnt As Integer
    Dim MonthCnt As Integer
    Dim DayCnt As Integer
    Dim FirstDayCnt As Integer
    Dim WeekDayCnt As Integer
        MaxDays(1) = 31
        MaxDays(2) = 28
        MaxDays(3) = 31
        MaxDays(4) = 30
        MaxDays(5) = 31
        MaxDays(6) = 30
        MaxDays(7) = 31
        MaxDays(8) = 31
        MaxDays(9) = 30
        MaxDays(10) = 31
        MaxDays(11) = 30
        MaxDays(12) = 31
    YearCnt = 1996
    MonthCnt = 1                'set to jenuary
    DayCnt = 1
    FirstDayCnt = 1             'set on monday
        While YearCnt < TheYear Or MonthCnt < TheMonth
            DayCnt = DayCnt + 1
            FirstDayCnt = FirstDayCnt + 1
            If FirstDayCnt > 6 Then FirstDayCnt = 0     'next week
            MaxDays(2) = 28
            'will check for 29 days in february
            If Int(YearCnt / 4) * 4 = YearCnt Then MaxDays(2) = 29
            If DayCnt > MaxDays(MonthCnt) Then
                DayCnt = 1
                MonthCnt = MonthCnt + 1
                If MonthCnt > 12 Then
                    MonthCnt = 1
                    YearCnt = YearCnt + 1
                End If
            End If
        Wend
     'will set values
    FirstDay = FirstDayCnt
    LastDay = MaxDays(TheMonth)
End Sub
Sub SetDayDataOnScreen()
'will put data from Arrays to screen components
    Dim b As Integer
    For b = 0 To 9
        MemoText(b).Text = Memo(TheDay, b)
        MemoDoneCheck(b) = MemoDone(TheDay, b)
        If MemoDone(TheDay, b) = 1 Then MemoText(b).Enabled = False Else MemoText(b).Enabled = True
    Next b
    For b = 0 To 17
        ActionText(b) = Action(TheDay, b)
    Next b
End Sub

Sub SetMemoList()
    'will write to MemoList
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
        
        For b = 0 To 9
            If Memo(DayCnt, b) <> "" And MemoDone(DayCnt, b) <> 1 Then MemoList.AddItem Memo(DayCnt, b)
        Next b
        MemoList.AddItem "                         "
        DayCnt = DayCnt + 1
        Cnt = Cnt + 1
    Wend
End Sub


Private Sub ActionText_Change(Index As Integer)
    Action(TheDay, Index) = ActionText(Index).Text
    SetMemoList
    SetDayDataOnScreen
End Sub
Private Sub CopyToA_Click()
    Dim Response As VbMsgBoxResult
    Response = MsgBox("Will save data to disk a:, continue?", vbYesNo, "Save data to a:\MustBeDone")
    If Response = vbYes Then
        On Error GoTo DirExist
        MkDir "a:\MustBeDone"
DirExist:
        WriteToA
    End If
End Sub
Sub WriteToA()
    'On Error GoTo AnotReady
    'Shell "c:", "copy c:\mustbedone\ a:\mustbedone"
    GoTo Finish
AnotReady:
    MsgBox "A: not ready", vbCritical
Finish:
End Sub


Private Sub DayButton_Click(Index As Integer)
    'change TheDay
    TheDay = Index
    SetCalendar
    DrawMonth
    SetMemoList
    SetDayDataOnScreen
End Sub

Private Sub ExitButton_Click()
    Unload frmMain
End Sub



Private Sub Form_Load()
    'init global vars
    TheDay = Day(Date)
    TheMonth = Month(Date)
    TheYear = Year(Date)
    frmMain.Caption = "MustBeDone " & Date

'will check for directory "MustBeDone"
    On Error GoTo fileexist
    MkDir "c:\MustBeDone"
    'will do next line only if no error accured - creat new dir
    MsgBox "First run, will make new directory and file", vbOKOnly, "Congratulation!"
    ClearData
    SaveFile ("c")
fileexist:
    LoadFile ("c")
    SetCalendar
    DrawMonth
    SetDayDataOnScreen
    SetMemoList
End Sub
Sub SetHeaders()
    NewCalendar.Caption = TheDay & "/" & TheMonth & "/" & TheYear
End Sub

Private Sub Form_Unload(Cancel As Integer)
    SaveFile ("c")
End Sub


Private Sub HelpView_Click()
    frmHelp.Visible = True
End Sub

Private Sub MemoDoneCheck_Click(Index As Integer)
    MemoDone(TheDay, Index) = MemoDoneCheck(Index).Value
    SetDayDataOnScreen
    SetMemoList
End Sub

Private Sub MemoText_Change(Index As Integer)
    Memo(TheDay, Index) = MemoText(Index)
    SetMemoList
End Sub
Private Sub NextDayButton_Click()
    TheDay = TheDay + 1
    If TheDay > LastDay Then
        SaveFile ("c")
        TheDay = 1
        ClearData                   'clear month data
        TheMonth = TheMonth + 1
        If TheMonth > 12 Then
            TheMonth = 1
            TheYear = TheYear + 1
            If TheYear > 2004 Then TheYear = 2004
        End If
        LoadFile ("c")
    End If
    SetCalendar
    DrawMonth
    SetDayDataOnScreen
    SetMemoList
End Sub

Private Sub NextMonthButton_Click()
    SaveFile ("c")
    ClearData                   'clear month data
    TheMonth = TheMonth + 1
    If TheMonth > 12 Then
        TheMonth = 1
        TheYear = TheYear + 1
        If TheYear > 2004 Then TheYear = 2004
    End If
    TheDay = 1
    LoadFile ("c")
    SetCalendar
    DrawMonth
    SetDayDataOnScreen
    SetMemoList
End Sub

Private Sub PrevDayButton_Click()
    TheDay = TheDay - 1
    If TheDay < 1 Then
        SaveFile ("c")
        ClearData                   'clear month data
        TheMonth = TheMonth - 1
        If TheMonth < 1 Then
            TheMonth = 12
            TheYear = TheYear - 1
            If TheYear < 1998 Then TheYear = 1998
        End If
    LoadFile ("c")
    SetCalendar
    TheDay = LastDay
    End If
    SetCalendar
    DrawMonth
    SetDayDataOnScreen
    SetMemoList
End Sub

Private Sub PrevMonthButton_Click()
    SaveFile ("c")
    ClearData                   'clear month data
    TheMonth = TheMonth - 1
    If TheMonth < 1 Then
        TheMonth = 12
        TheYear = TheYear - 1
        If TheYear < 1998 Then TheYear = 1998
    End If
    LoadFile ("c")
    SetCalendar
    TheDay = LastDay
    SetCalendar
    DrawMonth
    SetDayDataOnScreen
    SetMemoList
End Sub

Private Sub PrintFrmMain_Click()
    frmPrint.Visible = True
End Sub

Private Sub Run_Timer()
    TimeLabel.Caption = Time
End Sub

Private Sub TodayButton_Click()
    SaveFile ("c")
    TheDay = Day(Date)
    TheMonth = Month(Date)
    TheYear = Year(Date)
    LoadFile ("c")
    SetCalendar
    DrawMonth
    SetDayDataOnScreen
    SetMemoList
End Sub


