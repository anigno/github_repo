VERSION 5.00
Begin VB.Form frmMain 
   Caption         =   "Form1"
   ClientHeight    =   6228
   ClientLeft      =   48
   ClientTop       =   336
   ClientWidth     =   8568
   LinkTopic       =   "Form1"
   ScaleHeight     =   519
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   714
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox lstResults 
      Height          =   2928
      Left            =   720
      TabIndex        =   5
      Top             =   1200
      Width           =   1572
   End
   Begin VB.TextBox txtFormula 
      Height          =   288
      Left            =   2400
      TabIndex        =   4
      Text            =   "1/x"
      Top             =   804
      Width           =   6012
   End
   Begin VB.CommandButton btnRun 
      Caption         =   "Run"
      Height          =   252
      Left            =   6360
      TabIndex        =   3
      Top             =   4320
      Width           =   612
   End
   Begin VB.PictureBox picGraph 
      Height          =   3012
      Left            =   2400
      ScaleHeight     =   247
      ScaleMode       =   0  'User
      ScaleWidth      =   497
      TabIndex        =   2
      Top             =   1200
      Width           =   6012
   End
   Begin VB.TextBox txtUBorder 
      Height          =   288
      Left            =   7800
      TabIndex        =   1
      Text            =   "100"
      Top             =   4320
      Width           =   612
   End
   Begin VB.TextBox txtLBorder 
      Height          =   288
      Left            =   7080
      TabIndex        =   0
      Text            =   "-100"
      Top             =   4320
      Width           =   612
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub btnRun_Click()
    Dim a As Integer
    Dim x As Double
    Dim px As Integer
    Dim py As Integer
    Dim result As Double
    Dim maxY As Double
    Dim minY As Double
    maxY = -999999
    minY = 999999
    uBorder = txtUBorder.Text
    lBorder = txtLBorder.Text
    picGraph.Cls
    lstResults.Clear
    For a = 0 To 500
        x = (uBorder - lBorder) / 500 * a + lBorder
        ucDefineVariable "x=" & Str(x)
        result = ucEvalStr(txtFormula.Text)
        'If ucError Then MsgBox ucErrorMessage, vbExclamation
        If result > maxY Then maxY = result
        If result < minY Then minY = result
        lstResults.AddItem "f(" & x & ")=" & result
        px = a
        If maxY <> minY Then
            py = (100 * result / (maxY - minY)) + 125
            If a = 1 Then picGraph.Line (px, 250 - py)-(px, 250 - py), vbRed
            picGraph.Line -(px, 250 - py), vbRed
        End If
    Next a
    picGraph.Line (0, 125)-(500, 125), vbBlue
End Sub

Private Sub Form_Load()
    ucLicense = "387715451073568104795717"  'add this line
End Sub
