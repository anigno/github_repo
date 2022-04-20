VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Begin VB.UserControl folderBrowser 
   ClientHeight    =   2880
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   2532
   ScaleHeight     =   2880
   ScaleWidth      =   2532
   ToolboxBitmap   =   "folderBrowser.ctx":0000
   Begin MSComctlLib.ImageList ImageList1 
      Left            =   1440
      Top             =   2400
      _ExtentX        =   804
      _ExtentY        =   804
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   6
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "folderBrowser.ctx":0312
            Key             =   ""
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "folderBrowser.ctx":0424
            Key             =   ""
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "folderBrowser.ctx":0536
            Key             =   ""
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "folderBrowser.ctx":0648
            Key             =   ""
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "folderBrowser.ctx":075A
            Key             =   ""
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "folderBrowser.ctx":086C
            Key             =   ""
         EndProperty
      EndProperty
   End
   Begin VB.DriveListBox Drive1 
      Height          =   288
      Left            =   0
      TabIndex        =   1
      Top             =   2520
      Visible         =   0   'False
      Width           =   1332
   End
   Begin MSComctlLib.TreeView TV1 
      Height          =   2172
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   2292
      _ExtentX        =   4043
      _ExtentY        =   3831
      _Version        =   393217
      Indentation     =   0
      LineStyle       =   1
      Sorted          =   -1  'True
      Style           =   7
      Checkboxes      =   -1  'True
      ImageList       =   "ImageList1"
      Appearance      =   0
   End
End
Attribute VB_Name = "folderBrowser"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public oList As New Collection

Private Sub UserControl_Initialize()
'    On Error Resume Next
    Dim a As Integer
    Dim tNode As Node
    Dim FSO As FileSystemObject
    For a = 1 To Drive1.ListCount - 1
        Set tNode = TV1.Nodes.Add(, , , Left(Drive1.List(a), 2))
        ExpandLeaf TV1, tNode
    Next a
End Sub

Private Sub UserControl_Resize()
    TV1.Width = UserControl.Width
    TV1.Height = UserControl.Height
End Sub

Private Sub TV1_Expand(ByVal Node As MSComctlLib.Node)
    Dim a As Integer
    Dim tNode As Node
    Set tNode = Node.Child
    If tNode.Children = 0 Then
        For a = 1 To Node.Children
            If tNode.Tag = "FOLDER" Then
                ExpandLeaf TV1, tNode
                Set tNode = tNode.Next
            End If
        Next a
    End If
End Sub

Private Sub TV1_NodeCheck(ByVal Node As MSComctlLib.Node)
    Dim a As Integer
    If Node.Checked = True Then
        Node.ForeColor = vbBlue
    Else
        Node.ForeColor = vbBlack
    End If
    For a = 1 To oList.Count
        oList.Remove 1
    Next a
    For a = 1 To TV1.Nodes.Count
        If TV1.Nodes.Item(a).Checked = True Then
            oList.Add TV1.Nodes.Item(a).FullPath
        End If
    Next a
End Sub


Public Function ListOfItems() As Collection
    Set ListOfItems = oList
End Function


Public Function selected()
    selected = TV1.SelectedItem.FullPath
End Function

