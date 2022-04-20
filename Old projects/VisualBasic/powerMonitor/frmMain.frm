VERSION 5.00
Object = "{B0770B31-BC21-11D2-94CF-004005455FAA}#1.0#0"; "ImpulsePower.ocx"
Begin VB.Form frmMain 
   Caption         =   "power monitor"
   ClientHeight    =   3972
   ClientLeft      =   48
   ClientTop       =   288
   ClientWidth     =   6432
   LinkTopic       =   "Form1"
   ScaleHeight     =   3972
   ScaleWidth      =   6432
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdDraw 
      Caption         =   "draw"
      Height          =   492
      Left            =   5880
      TabIndex        =   2
      Top             =   960
      Width           =   492
   End
   Begin VB.PictureBox Picture1 
      Height          =   3732
      Left            =   960
      ScaleHeight     =   3684
      ScaleWidth      =   4764
      TabIndex        =   1
      Top             =   0
      Width           =   4812
   End
   Begin VB.ListBox List1 
      Height          =   3696
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   972
   End
   Begin VB.Timer Timer1 
      Interval        =   1000
      Left            =   5880
      Top             =   480
   End
   Begin ImpulsePower.ISPower ISPower1 
      Left            =   5880
      Top             =   0
      _ExtentX        =   847
      _ExtentY        =   847
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim p() As Integer
Dim t As Integer
Dim dr As Boolean

Private Sub cmdDraw_Click()
    If dr = False Then
        dr = True
        cmdDraw.Caption = "stop"
    Else
        dr = False
        cmdDraw.Caption = "draw"
    End If
End Sub

Private Sub Form_Load()
    ReDim Preserve p(0)
End Sub

Private Sub Timer1_Timer()
    If t < 32000 Then
        p(t) = ISPower1.BatteryLifePercent
        List1.AddItem t & ": " & p(t), 0
        t = t + 1
        ReDim Preserve p(t)
    End If
    mx = UBound(p)
    If dr = True Then
        Picture1.Cls
        For a = 0 To 100 Step 10
            If a = 50 Then
                Picture1.ForeColor = vbBlue
            Else
                Picture1.ForeColor = vbGreen
            End If
    
            y = Picture1.Height - Picture1.Height / 100 * a
            Picture1.Line (0, y)-(Picture1.Width, y)
        Next a
    
        For a = 0 To mx
            x = Picture1.Width / mx * a
            y = Picture1.Height - Picture1.Height / 100 * p(a)
            Picture1.ForeColor = vbRed
            Picture1.PSet (x, y)
        Next a
    dr = False
    cmdDraw.Caption = "draw"
    End If
End Sub
