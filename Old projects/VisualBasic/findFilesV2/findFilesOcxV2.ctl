VERSION 5.00
Begin VB.UserControl findFilesOcxV2 
   ClientHeight    =   5232
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   7860
   ScaleHeight     =   5232
   ScaleWidth      =   7860
   Begin VB.ListBox List1 
      Height          =   2160
      Left            =   0
      TabIndex        =   4
      Top             =   2160
      Width           =   6252
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   372
      Left            =   2760
      TabIndex        =   3
      Top             =   1680
      Width           =   972
   End
   Begin VB.DirListBox Dir1 
      Height          =   504
      Left            =   0
      TabIndex        =   1
      Top             =   360
      Visible         =   0   'False
      Width           =   2652
   End
   Begin VB.FileListBox File1 
      Height          =   1224
      Left            =   0
      TabIndex        =   0
      Top             =   840
      Visible         =   0   'False
      Width           =   2652
   End
   Begin VB.Label Label1 
      Caption         =   "findFilesOcxV2"
      Height          =   252
      Left            =   0
      TabIndex        =   2
      Top             =   0
      Width           =   1092
   End
End
Attribute VB_Name = "findFilesOcxV2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Private Sub Command1_Click()
    Dim a As Integer
    List1.Clear
    iSearchWord = "txt"
    runFindFiles
    For a = 0 To UBound(FileList) - 1
        List1.AddItem FileList(a)
    Next a
    
End Sub

Private Sub Dir1_Change()
    File1.path = Dir1.path
End Sub

Public Property Get listCount() As Variant
    listCount = UBound(FileList)
End Property


Public Property Get files() As Variant
    files = FileList
End Property

Public Property Get directories() As Variant
    directories = dirList
End Property

Public Property Get searchWord() As Variant
    searchWord = iSearchWord
End Property

Public Property Let searchWord(ByVal vNewValue As Variant)
    iSearchWord = vNewValue
End Property

Public Function runFindFiles()
    Dim a As Integer
    setArrays
    runFind Dir1, File1
End Function

Public Property Get path() As Variant
    path = iPath
End Property

Public Property Let path(ByVal vNewValue As Variant)
    iPath = vNewValue
    Dir1.path = iPath
End Property
