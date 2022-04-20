VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   6810
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6840
   LinkTopic       =   "Form1"
   ScaleHeight     =   6810
   ScaleWidth      =   6840
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "Insert Code"
      Height          =   495
      Left            =   2760
      TabIndex        =   1
      Top             =   6240
      Width           =   1215
   End
   Begin Project1.rtbSyntax rtbSyntax1 
      Height          =   6135
      Left            =   120
      TabIndex        =   0
      Top             =   0
      Width           =   6615
      _ExtentX        =   11668
      _ExtentY        =   10821
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Courier New"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MouseIcon       =   "Form1.frx":0000
      RightMargin     =   1.00000e5
      Text            =   "' enter some code ..."
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Command1_Click()
    
    Dim s As String
    s = s & "'" & vbCrLf
    s = s & "' Sample Code" & vbCrLf
    s = s & "'" & vbCrLf
    s = s & "Dim s" & vbCrLf
    s = s & "s = "" nuzaga "" ' nonsense text" & vbCrLf
    s = s & "" & vbCrLf
    s = s & "If Trim(s) = ""nuzaga"" Then" & vbCrLf
    s = s & "   ' alert user to presence of nonsense" & vbCrLf
    s = s & "   MsgBox ""Nonsense""" & vbCrLf
    s = s & "End If" & vbCrLf

    rtbSyntax1.Text = s & rtbSyntax1.Text
    
    
End Sub

