VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Begin VB.Form frmMain 
   Caption         =   "Form1"
   ClientHeight    =   5592
   ClientLeft      =   48
   ClientTop       =   336
   ClientWidth     =   8520
   LinkTopic       =   "Form1"
   ScaleHeight     =   5592
   ScaleWidth      =   8520
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdMake 
      Caption         =   "Make"
      Height          =   252
      Left            =   3840
      TabIndex        =   6
      Top             =   3000
      Width           =   852
   End
   Begin VB.CommandButton cmdRemoveDir 
      Caption         =   "Remove"
      Height          =   252
      Left            =   2880
      TabIndex        =   5
      Top             =   3000
      Width           =   852
   End
   Begin VB.ListBox lstBackup 
      BeginProperty Font 
         Name            =   "Small Fonts"
         Size            =   6.6
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2076
      ItemData        =   "frmMain.frx":0000
      Left            =   0
      List            =   "frmMain.frx":0002
      TabIndex        =   4
      Top             =   3240
      Width           =   8412
   End
   Begin VB.CommandButton cmdAddDir 
      Caption         =   "Add Dir"
      Height          =   252
      Left            =   1920
      TabIndex        =   3
      Top             =   3000
      Width           =   852
   End
   Begin VB.ListBox lstDrives 
      Height          =   2928
      Left            =   0
      TabIndex        =   2
      Top             =   0
      Width           =   1932
   End
   Begin VB.DriveListBox Drive1 
      Height          =   288
      Left            =   6840
      TabIndex        =   1
      Top             =   240
      Visible         =   0   'False
      Width           =   852
   End
   Begin MSComctlLib.TreeView Tview1 
      Height          =   2892
      Left            =   1920
      TabIndex        =   0
      Top             =   0
      Width           =   4812
      _ExtentX        =   8488
      _ExtentY        =   5101
      _Version        =   393217
      Style           =   7
      Appearance      =   1
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Sub List1_DblClick()
    a = List1.List(List1.ListIndex)
    List1.Clear
    List2.Clear
    For Each FLDR In FSO.GetFolder(a).SubFolders
        List1.AddItem FLDR
        List2.AddItem FSO.GetBaseName(FLDR)
    Next FLDR
    
End Sub

Private Sub cmdAddDir_Click()
    lstBackup.AddItem Tview1.SelectedItem.FullPath
End Sub

Private Sub cmdMake_Click()
    Dim a
    Open "c:\backup.bat" For Output As #1
        For a = 0 To lstBackup.ListCount - 1
            Print #1, "xcopy " & lstBackup.List(a)
        Next a
    Close #1
End Sub

Private Sub cmdRemoveDir_Click()
    On Error Resume Next
    lstBackup.RemoveItem lstBackup.ListIndex
End Sub

Private Sub Form_Load()
    Dim FSO As New FileSystemObject
    Dim a, DL, DRV, T
    Dim xNode As Node
    For a = 0 To Drive1.ListCount - 1
        DL = Left(Drive1.List(a), 2)
        Set DRV = FSO.GetDrive(DL)
        Tview1.Nodes.Add , , , DRV.Path & "\"
        Select Case DRV.DriveType
            Case 0: T = "Unknown"
            Case 1: T = "Removable"
            Case 2: T = "Fixed"
            Case 3: T = "Network  "
            Case 4: T = "CD-ROM   "
            Case 5: T = "RAM Disk "
        End Select
        lstDrives.AddItem T & " " & Drive1.List(a)
    Next a
End Sub

Public Sub expandLeaf(ByRef xNode As Node, n As Byte)
    Dim FSO As New FileSystemObject
    Dim FLDR As Folder
    On Error Resume Next
    For Each FLDR In FSO.GetFolder(xNode.FullPath).SubFolders
        Tview1.Nodes.Add xNode, tvwChild, , FLDR.Name
    Next FLDR
    xNode.Expanded = True
End Sub

Private Sub Tview1_DblClick()
    If Tview1.SelectedItem.Children = 0 Then
        expandLeaf Tview1.SelectedItem, 1
    End If
End Sub

