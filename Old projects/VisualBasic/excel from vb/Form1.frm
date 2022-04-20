VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   5652
   ClientLeft      =   48
   ClientTop       =   348
   ClientWidth     =   7944
   LinkTopic       =   "Form1"
   ScaleHeight     =   5652
   ScaleWidth      =   7944
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox List1 
      Height          =   4272
      Left            =   5880
      TabIndex        =   1
      Top             =   240
      Width           =   1572
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   372
      Left            =   3480
      TabIndex        =   0
      Top             =   2640
      Width           =   972
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
    Dim x As New Excel.Application
    x.Workbooks.Open "c:\book1.xls"
    For c = 1 To 10
        x.Worksheets(1).Cells(c, 1).Value = c
        x.Worksheets(1).Cells(c, 2).Value = "=A" & c & "*2"
        List1.AddItem x.Worksheets(1).Cells(c, 2).Value
    Next c
End Sub


