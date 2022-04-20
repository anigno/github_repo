VERSION 5.00
Object = "{0ECD9B60-23AA-11D0-B351-00A0C9055D8E}#6.0#0"; "MSHFLXGD.OCX"
Begin VB.UserControl EditGrid 
   ClientHeight    =   2616
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   2952
   ScaleHeight     =   2616
   ScaleWidth      =   2952
   Begin VB.TextBox Text_Edit 
      Height          =   612
      Left            =   720
      MultiLine       =   -1  'True
      RightToLeft     =   -1  'True
      TabIndex        =   0
      Top             =   960
      Visible         =   0   'False
      Width           =   1812
   End
   Begin MSHierarchicalFlexGridLib.MSHFlexGrid Grid 
      Height          =   2412
      Left            =   0
      TabIndex        =   1
      Top             =   0
      Width           =   2652
      _ExtentX        =   4678
      _ExtentY        =   4255
      _Version        =   393216
      BackColor       =   7458781
      Rows            =   10
      BackColorFixed  =   2729888
      AllowUserResizing=   3
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      _NumberOfBands  =   1
      _Band(0).Cols   =   2
   End
End
Attribute VB_Name = "EditGrid"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit
Public Event AfterEdit()
Private Sub UserControl_Initialize()
'    Dim a As Integer
'    For a = 1 To 35
'    Grid.FormatString = Grid.FormatString + "                         |"
'    If a = 10 Then Grid.FormatString = Grid.FormatString + ";"
'    Next a
'    Grid.FormatString = Grid.FormatString + "                         "
End Sub

Private Sub UserControl_Resize()
    Grid.Width = UserControl.Width
    Grid.Height = UserControl.Height
End Sub

Private Sub Grid_KeyPress(KeyAscii As Integer)
    Dim W, H As Long
    With Text_Edit
        .Text = Grid.Text
        .Visible = True
        .SetFocus
        .Left = Grid.CellLeft + Grid.Left
        .Top = Grid.CellTop + Grid.Top
        W = Grid.CellWidth * (Abs(Grid.Col - Grid.ColSel) + 1)
        If .Left + W > Grid.Left + Grid.Width Then W = Grid.Width - Grid.ColPos(1) - 250
        .Width = W
        H = Grid.CellHeight * (Abs(Grid.Row - Grid.RowSel) + 1)
        If .Top + H > Grid.Top + Grid.Height Then H = Grid.Height - Grid.RowPos(1) - 250
        .Height = H
    End With
End Sub

Private Sub Grid_MouseDown(Button As Integer, Shift As Integer, x As Single, y As Single)
    If Button = 2 Then
        Grid_KeyPress (13)
    Else
        Text_Edit.Visible = False
    End If
End Sub

Private Sub Grid_Scroll()
    Text_Edit.Visible = False
End Sub

Private Sub Text_Edit_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then UpdateGrid
    If KeyAscii = 27 Then Text_Edit.Visible = False
End Sub

Sub UpdateGrid()
Dim x1, x2, y1, y2, x, y, tCol, tRow As Integer
    tCol = Grid.Col
    tRow = Grid.Row
    If Grid.Row > Grid.RowSel Then
        y1 = Grid.RowSel
        y2 = Grid.Row
    Else
        y1 = Grid.Row
        y2 = Grid.RowSel
    End If
    If Grid.Col > Grid.ColSel Then
        x1 = Grid.ColSel
        x2 = Grid.Col
    Else
        x1 = Grid.Col
        x2 = Grid.ColSel
    End If
    For x = x1 To x2
        For y = y1 To y2
            Grid.Col = x
            Grid.Row = y
            Grid.Text = Text_Edit.Text
        Next y
    Next x
    Grid.Col = tCol
    Grid.Row = tRow
    Text_Edit.Visible = False
    RaiseEvent AfterEdit
End Sub
'-----------------------------------------------------------------
'properties
Public Property Get Row() As Integer
    Row = Grid.Row
End Property
Public Property Let Row(ByVal aRow As Integer)
    Grid.Row = aRow
    PropertyChanged "Row"
End Property
Public Property Get Col() As Integer
    Col = Grid.Col
End Property
Public Property Let Col(ByVal aCol As Integer)
    Grid.Col = aCol
    PropertyChanged "Col"
End Property
Public Property Get Rows() As Integer
    Rows = Grid.Rows
End Property
Public Property Let Rows(ByVal aRows As Integer)
    Grid.Rows = aRows
    PropertyChanged "Rows"
End Property
Public Property Get Cols() As Integer
    Cols = Grid.Cols
End Property
Public Property Let Cols(ByVal aCols As Integer)
    Grid.Cols = aCols
    PropertyChanged "Cols"
End Property

Public Property Get Text() As String
    Text = Grid.Text
End Property
Public Property Let Text(ByVal aText As String)
    Grid.Text = aText
    PropertyChanged "Text"
End Property

Public Property Get FormatString() As String
    FormatString = Grid.FormatString
End Property
Public Property Let FormatString(ByVal aString As String)
    Grid.FormatString = aString
    PropertyChanged "FormatString"
End Property

