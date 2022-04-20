VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Begin VB.Form frmMain 
   Caption         =   "getFiles"
   ClientHeight    =   6036
   ClientLeft      =   48
   ClientTop       =   336
   ClientWidth     =   8976
   LinkTopic       =   "Form1"
   ScaleHeight     =   6036
   ScaleWidth      =   8976
   StartUpPosition =   3  'Windows Default
   Begin MSComctlLib.ImageList ImageList1 
      Left            =   8640
      Top             =   1080
      _ExtentX        =   804
      _ExtentY        =   804
      BackColor       =   -2147483643
      ImageWidth      =   20
      ImageHeight     =   20
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   2
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":0000
            Key             =   ""
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmMain.frx":0452
            Key             =   ""
         EndProperty
      EndProperty
   End
   Begin VB.FileListBox File1 
      Height          =   5064
      Left            =   3600
      TabIndex        =   3
      Top             =   240
      Width           =   2412
   End
   Begin VB.DirListBox Dir1 
      Height          =   2232
      Left            =   6360
      TabIndex        =   2
      Top             =   3720
      Width           =   2532
   End
   Begin VB.DriveListBox Drive1 
      Height          =   288
      Left            =   6360
      TabIndex        =   1
      Top             =   3360
      Width           =   2532
   End
   Begin MSComctlLib.TreeView TV 
      Height          =   5172
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   3372
      _ExtentX        =   5948
      _ExtentY        =   9123
      _Version        =   393217
      LabelEdit       =   1
      LineStyle       =   1
      PathSeparator   =   ""
      Style           =   5
      ImageList       =   "ImageList1"
      Appearance      =   1
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Dir1_Change()
    File1.Path = Dir1.Path
End Sub

Private Sub Form_Load()
    Dim a As Integer
    On Error Resume Next
    For a = 0 To Drive1.ListCount - 1
        TV.Nodes.Add , , , Left(Drive1.List(a), 2) & "\", 1
    Next a
End Sub

Private Sub TV_Click()
    File1.Path = TV.SelectedItem.fullPath
End Sub

Private Sub TV_DblClick()
    If TV.SelectedItem.Children = 0 Then
        expandNext TV.SelectedItem
        TV.SelectedItem.Expanded = True
    End If
End Sub

Public Sub expandNext(iNode As Node)
    Dim a As Integer
    On Error GoTo NOPATHERROR
    Dir1.Path = iNode.fullPath
    For a = 0 To Dir1.ListCount - 1
        TV.Nodes.Add iNode, tvwChild, , getDirName(Dir1.List(a)) & "\", 2
    Next a
NOPATHERROR:
End Sub

Public Function getDirName(fullPath As String) As String
    Dim a As Integer
    a = Len(fullPath)
    Do
        a = a - 1
    Loop Until Mid(fullPath, a, 1) = "\"
    getDirName = Mid(fullPath, a + 1)
End Function
