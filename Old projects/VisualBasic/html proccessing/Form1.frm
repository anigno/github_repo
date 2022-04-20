VERSION 5.00
Object = "{48E59290-9880-11CF-9754-00AA00C00908}#1.0#0"; "MSINET.OCX"
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   5472
   ClientLeft      =   48
   ClientTop       =   348
   ClientWidth     =   8220
   LinkTopic       =   "Form1"
   ScaleHeight     =   5472
   ScaleWidth      =   8220
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox List1 
      Height          =   2736
      Left            =   480
      TabIndex        =   2
      Top             =   1800
      Width           =   972
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   372
      Left            =   480
      TabIndex        =   1
      Top             =   1080
      Width           =   972
   End
   Begin RichTextLib.RichTextBox RTF 
      Height          =   1572
      Left            =   2880
      TabIndex        =   0
      Top             =   3480
      Width           =   3132
      _ExtentX        =   5525
      _ExtentY        =   2773
      _Version        =   393217
      Enabled         =   -1  'True
      ScrollBars      =   3
      TextRTF         =   $"Form1.frx":0000
   End
   Begin InetCtlsObjects.Inet Inet1 
      Left            =   480
      Top             =   360
      _ExtentX        =   804
      _ExtentY        =   804
      _Version        =   393216
      Protocol        =   4
      RemoteHost      =   "www.start.co.il"
      URL             =   "http://www.start.co.il"
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
    RTF.Text = Inet1.OpenURL
    s = "1 דולר"
    Dim sq As String
    sq = RTF.Text
    For a = 1 To Len(RTF.Text)
        If Mid(sq, a, Len(s)) = s Then
            List1.AddItem a
            RTF.SelStart = a
            RTF.SelLength = Len(s)
            RTF.SelColor = vbRed
            b = a - 31
            List1.AddItem "1$ = " & Mid(sq, b, 5)
            
        End If
    DoEvents
    Next a
    Command1.Caption = "done"
End Sub

