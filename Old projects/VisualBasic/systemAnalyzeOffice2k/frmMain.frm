VERSION 5.00
Object = "{EAB22AC0-30C1-11CF-A7EB-0000C05BAE0B}#1.1#0"; "shdocvw.dll"
Object = "{48E59290-9880-11CF-9754-00AA00C00908}#1.0#0"; "MSINET.OCX"
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "RICHTX32.OCX"
Begin VB.Form frmMain 
   Caption         =   "System analyze V1.1"
   ClientHeight    =   7404
   ClientLeft      =   48
   ClientTop       =   348
   ClientWidth     =   11532
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   7404
   ScaleWidth      =   11532
   Begin VB.CommandButton cmdUpdate 
      Caption         =   "Update now"
      Height          =   372
      Left            =   120
      TabIndex        =   5
      Top             =   0
      Width           =   2052
   End
   Begin VB.CommandButton cmdClose 
      Caption         =   "Close"
      Height          =   372
      Left            =   120
      TabIndex        =   4
      Top             =   3120
      Width           =   1332
   End
   Begin VB.Timer tmrUpdate 
      Interval        =   1000
      Left            =   3120
      Top             =   2280
   End
   Begin RichTextLib.RichTextBox RTF 
      Height          =   732
      Left            =   7680
      TabIndex        =   1
      Top             =   5640
      Visible         =   0   'False
      Width           =   2412
      _ExtentX        =   4255
      _ExtentY        =   1291
      _Version        =   393217
      ScrollBars      =   3
      TextRTF         =   $"frmMain.frx":0000
   End
   Begin SHDocVwCtl.WebBrowser WebBrowser1 
      Height          =   3492
      Left            =   3600
      TabIndex        =   2
      Top             =   120
      Width           =   7812
      ExtentX         =   13779
      ExtentY         =   6159
      ViewMode        =   0
      Offline         =   0
      Silent          =   0
      RegisterAsBrowser=   0
      RegisterAsDropTarget=   1
      AutoArrange     =   0   'False
      NoClientEdge    =   0   'False
      AlignLeft       =   0   'False
      NoWebView       =   0   'False
      HideFileNames   =   0   'False
      SingleClick     =   0   'False
      SingleSelection =   0   'False
      NoFolders       =   0   'False
      Transparent     =   0   'False
      ViewID          =   "{0057D0E0-3573-11CF-AE69-08002B2E1262}"
      Location        =   "http:///"
   End
   Begin InetCtlsObjects.Inet Inet1 
      Left            =   3000
      Top             =   2760
      _ExtentX        =   804
      _ExtentY        =   804
      _Version        =   393216
   End
   Begin SHDocVwCtl.WebBrowser WebBrowser2 
      Height          =   3492
      Left            =   3600
      TabIndex        =   3
      Top             =   3720
      Width           =   7812
      ExtentX         =   13779
      ExtentY         =   6159
      ViewMode        =   0
      Offline         =   0
      Silent          =   0
      RegisterAsBrowser=   0
      RegisterAsDropTarget=   1
      AutoArrange     =   0   'False
      NoClientEdge    =   0   'False
      AlignLeft       =   0   'False
      NoWebView       =   0   'False
      HideFileNames   =   0   'False
      SingleClick     =   0   'False
      SingleSelection =   0   'False
      NoFolders       =   0   'False
      Transparent     =   0   'False
      ViewID          =   "{0057D0E0-3573-11CF-AE69-08002B2E1262}"
      Location        =   "http:///"
   End
   Begin VB.ListBox List1 
      Height          =   2736
      Left            =   120
      TabIndex        =   0
      Top             =   360
      Width           =   3372
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
    
Dim X As New Excel.Application
Dim s As Integer

Private Sub cmdClose_Click()
    X.ActiveWorkbook.Close True
    End
End Sub

Private Sub cmdUpdate_Click()
    If s > 1 Then s = 1
End Sub

Private Sub Form_Load()
    s = 1
    WebBrowser1.Navigate "http://web.bizportal.co.il/bizportalnew/bursagraph/thegraph.shtml?list=1a&code=00001334"
    WebBrowser2.Navigate "http://web.bizportal.co.il/bizportalnew/bizmadad.shtml?p_id=198"
List1.AddItem "open file"
X.Workbooks.Open App.Path & "\system2.xls"
List1.AddItem "file is open"
End Sub

Public Sub getData()
    Dim s As String
    Dim a As Long
    
    'get marketOpenValue
    List1.AddItem "getting open value"
    s = Inet1.OpenURL("http://web.bizportal.co.il/bizportalnew/bursagraph/thegraph.shtml?list=1a&code=00001334")
'RTF.Text = S
    a = getNextPos(s, "החיתפ", 1)
    
'RTF.SelStart = a
'RTF.SelLength = 6
'RTF.SelColor = vbRed
    
    a = getNextNpos(s, "<small><font face=", a, 4)
    a = a + 26
    marketOpenValue = Val(Mid(s, a, 6))
    List1.AddItem "open=" & marketOpenValue
    
    'get others values
    List1.AddItem "getting high,low & close values"
    s = Inet1.OpenURL("http://web.bizportal.co.il/bizportalnew/bizmadad.shtml?p_id=198")
'RTF.Text = S
    a = getNextPos(s, "סיסב", 1)
    a = getNextNpos(s, "<td height=", a, 2)
    a = a + 74
    marketCloseValue = Val(Mid(s, a, 6))
    List1.AddItem "current/close=" & marketCloseValue
    a = getNextNpos(s, "<td", a, 3)
    a = a + 42
    marketLowValue = Val(Mid(s, a, 6))
    List1.AddItem "low=" & marketLowValue
    a = getNextNpos(s, "<td", a, 3)
    a = a + 42
    marketHighValue = Val(Mid(s, a, 6))
    List1.AddItem "high=" & marketHighValue
    
'RTF.SelStart = a
'RTF.SelLength = 6
'RTF.SelColor = vbRed
End Sub

Public Sub updateData()
    Dim a As Long
    Dim iDate As String
    Dim willUpdate As Boolean
    
    cmdClose.Enabled = False
    a = 1
    List1.AddItem "calculate update pos"
    While X.Worksheets(3).Cells(a, 1) <> ""
        a = a + 1
        'DoEvents
    Wend
    'check date
    willUpdate = True
    iDate = X.Worksheets(3).Cells(a - 1, 100)
    If iDate = Date Then
        a = a - 1
        List1.AddItem "update again for " & Date
        willUpdate = False
    Else
        'check for new values
        Dim z1 As Double
        Dim z2 As Double
        Dim z3 As Double
        Dim z4 As Double
        z1 = X.Worksheets(3).Cells(a - 1, 1)
        z2 = X.Worksheets(3).Cells(a - 1, 2)
        z3 = X.Worksheets(3).Cells(a - 1, 3)
        z4 = X.Worksheets(3).Cells(a - 1, 4)
        If z1 = marketOpenValue _
            And z2 = marketHighValue _
            And z3 = marketLowValue _
            And z4 = marketCloseValue Then
            a = a - 1
            willUpdate = False
            List1.AddItem "no data change for " & Date
        End If
    End If
    
    If willUpdate = True Then
        X.Worksheets(3).Cells(a, 100) = Date
        X.Worksheets(3).Cells(a, 101) = Time
    End If
    
    'update
    List1.AddItem "empty row=" & a
    If marketCloseValue <> 0 Then
        X.Worksheets(3).Cells(a, 1) = marketOpenValue
        X.Worksheets(3).Cells(a, 2) = marketHighValue
        X.Worksheets(3).Cells(a, 3) = marketLowValue
        X.Worksheets(3).Cells(a, 4) = marketCloseValue
    Else
        List1.AddItem "no data input, check connection!"
    End If
    X.Worksheets(3).Range("E" & Trim(Str(a - 1)) & ":BB" & Trim(Str(a - 1))).Copy _
        Destination:=Worksheets(3).Range("E" & Trim(Str(a)) & ":BB" & Trim(Str(a)))
    'get system value
    List1.AddItem "************* system *************"
    List1.AddItem "result=" & X.Worksheets(3).Cells(a, 21).Value
    'List1.AddItem "first=" & X.Worksheets(3).Cells(a, 11).Value
    'List1.AddItem "second=" & X.Worksheets(3).Cells(a, 12).Value
    'List1.AddItem "third=" & X.Worksheets(3).Cells(a, 13).Value
    List1.AddItem "************* system *************"
    List1.AddItem "------------------ done! ------------------"
    'Set X = Nothing
    cmdClose.Enabled = True
End Sub

Private Sub tmrUpdate_Timer()
    If List1.ListCount > 30000 Then List1.Clear
    List1.ListIndex = List1.ListCount - 1
    List1.Refresh
    s = s - 1
    cmdUpdate.Caption = "update in " & s & " sec"
    If s < 1 Then
        getData
        updateData
        s = 3600
    End If
End Sub
