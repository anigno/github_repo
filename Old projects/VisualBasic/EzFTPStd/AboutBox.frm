VERSION 5.00
Begin VB.Form AboutBox 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "About Easy FTP OLE Control"
   ClientHeight    =   2952
   ClientLeft      =   3876
   ClientTop       =   2820
   ClientWidth     =   4644
   Icon            =   "AboutBox.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   2952
   ScaleWidth      =   4644
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton OK 
      Caption         =   "OK"
      Default         =   -1  'True
      Enabled         =   0   'False
      Height          =   375
      Left            =   3480
      TabIndex        =   3
      Top             =   2460
      Width           =   1035
   End
   Begin VB.OLE OLE1 
      AutoActivate    =   1  'GetFocus
      Class           =   "SoundRec"
      DisplayType     =   1  'Icon
      Height          =   555
      Left            =   3660
      OleObjectBlob   =   "AboutBox.frx":0442
      OLETypeAllowed  =   1  'Embedded
      SourceDoc       =   "C:\WINDOWS\MEDIA\tada.wav"
      TabIndex        =   5
      Top             =   120
      Visible         =   0   'False
      Width           =   615
   End
   Begin VB.Label Label4 
      Caption         =   "http://www.intr.net/coolstf"
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   360
      TabIndex        =   4
      Top             =   2520
      Width           =   2895
   End
   Begin VB.Label Label3 
      Caption         =   "EZFTP.OCX and this demo program are © 1996 by Rod Hewitt"
      Height          =   375
      Left            =   360
      TabIndex        =   2
      Top             =   1860
      Width           =   4035
   End
   Begin VB.Label Label2 
      Caption         =   $"AboutBox.frx":965A
      Height          =   855
      Left            =   360
      TabIndex        =   1
      Top             =   840
      Width           =   4035
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "Easy FTP OLE Control Module"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   195
      Left            =   780
      TabIndex        =   0
      Top             =   300
      Width           =   2580
   End
   Begin VB.Image Image1 
      Height          =   384
      Left            =   180
      Picture         =   "AboutBox.frx":971D
      Top             =   180
      Width           =   384
   End
End
Attribute VB_Name = "AboutBox"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Activate()
    
    DoEvents
    On Error Resume Next
    OLE1.Action = 7
    Do Until OLE1.AppIsRunning = False
        DoEvents
    Loop
    OK.Enabled = True
    
End Sub

Private Sub Form_Load()

    Me.Move (Screen.Width \ 2) - (Me.Width \ 2), (Screen.Height \ 2) - (Me.Height \ 2)
    
End Sub

Private Sub OK_Click()

    Unload Me
    
End Sub


