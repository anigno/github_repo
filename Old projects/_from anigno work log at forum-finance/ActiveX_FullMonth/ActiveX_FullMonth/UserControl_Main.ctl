VERSION 5.00
Begin VB.UserControl FullMonth 
   ClientHeight    =   4296
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   5628
   FillColor       =   &H80000008&
   ScaleHeight     =   4296
   ScaleWidth      =   5628
   Begin VB.Timer Timer_Run 
      Interval        =   250
      Left            =   2400
      Top             =   120
   End
   Begin VB.Frame Frame_Month 
      Caption         =   "dd/mm/yy"
      ForeColor       =   &H00400000&
      Height          =   2052
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   2772
      Begin VB.Label Label1 
         Height          =   252
         Left            =   2160
         TabIndex        =   51
         ToolTipText     =   "Gina rony"
         Top             =   120
         Width           =   252
      End
      Begin VB.Image Image1 
         Height          =   372
         Left            =   1920
         Picture         =   "UserControl_Main.ctx":0000
         Stretch         =   -1  'True
         Top             =   1560
         Width           =   732
      End
      Begin VB.Label Label_Time 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "hh:mm:ss"
         ForeColor       =   &H00C00000&
         Height          =   252
         Left            =   1920
         TabIndex        =   50
         Top             =   1320
         Width           =   732
      End
      Begin VB.Image Image_DateChange 
         Height          =   264
         Index           =   4
         Left            =   2040
         Picture         =   "UserControl_Main.ctx":0BC2
         Stretch         =   -1  'True
         ToolTipText     =   "חודש הבא"
         Top             =   960
         Width           =   492
      End
      Begin VB.Image Image_DateChange 
         Height          =   264
         Index           =   3
         Left            =   2040
         Picture         =   "UserControl_Main.ctx":1004
         Stretch         =   -1  'True
         ToolTipText     =   "חודש קודם"
         Top             =   480
         Width           =   492
      End
      Begin VB.Image Image_DateChange 
         Height          =   492
         Index           =   2
         Left            =   2400
         Picture         =   "UserControl_Main.ctx":1446
         Stretch         =   -1  'True
         ToolTipText     =   "יום הבא"
         Top             =   600
         Width           =   252
      End
      Begin VB.Image Image_DateChange 
         Height          =   492
         Index           =   1
         Left            =   1920
         Picture         =   "UserControl_Main.ctx":1888
         Stretch         =   -1  'True
         ToolTipText     =   "יום קודם"
         Top             =   600
         Width           =   252
      End
      Begin VB.Image Image_DateChange 
         Height          =   264
         Index           =   0
         Left            =   2160
         Picture         =   "UserControl_Main.ctx":1CCA
         Stretch         =   -1  'True
         ToolTipText     =   "חזרה להיום"
         Top             =   720
         Width           =   252
      End
      Begin VB.Label Label_dayHeader 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "ש"
         ForeColor       =   &H000000FF&
         Height          =   252
         Index           =   6
         Left            =   1560
         TabIndex        =   49
         Top             =   240
         Width           =   252
      End
      Begin VB.Label Label_dayHeader 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "ו"
         ForeColor       =   &H00C00000&
         Height          =   252
         Index           =   5
         Left            =   1320
         TabIndex        =   48
         Top             =   240
         Width           =   252
      End
      Begin VB.Label Label_dayHeader 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "ה"
         ForeColor       =   &H00C00000&
         Height          =   252
         Index           =   4
         Left            =   1080
         TabIndex        =   47
         Top             =   240
         Width           =   252
      End
      Begin VB.Label Label_dayHeader 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "ד"
         ForeColor       =   &H00C00000&
         Height          =   252
         Index           =   3
         Left            =   840
         TabIndex        =   46
         Top             =   240
         Width           =   252
      End
      Begin VB.Label Label_dayHeader 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "ג"
         ForeColor       =   &H00C00000&
         Height          =   252
         Index           =   2
         Left            =   600
         TabIndex        =   45
         Top             =   240
         Width           =   252
      End
      Begin VB.Label Label_dayHeader 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "ב"
         ForeColor       =   &H00C00000&
         Height          =   252
         Index           =   1
         Left            =   360
         TabIndex        =   44
         Top             =   240
         Width           =   252
      End
      Begin VB.Label Label_dayHeader 
         Alignment       =   2  'Center
         BackStyle       =   0  'Transparent
         Caption         =   "א"
         ForeColor       =   &H00C00000&
         Height          =   252
         Index           =   0
         Left            =   120
         TabIndex        =   43
         Top             =   240
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   0
         Left            =   120
         TabIndex        =   42
         Top             =   480
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   1
         Left            =   360
         TabIndex        =   41
         Top             =   480
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   2
         Left            =   600
         TabIndex        =   40
         Top             =   480
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   3
         Left            =   840
         TabIndex        =   39
         Top             =   480
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00CA6A60&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   4
         Left            =   1080
         TabIndex        =   38
         Top             =   480
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00C0C0C0&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   5
         Left            =   1320
         TabIndex        =   37
         Top             =   480
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   6
         Left            =   1560
         TabIndex        =   36
         Top             =   480
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   7
         Left            =   120
         TabIndex        =   35
         Top             =   720
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   8
         Left            =   360
         TabIndex        =   34
         Top             =   720
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   9
         Left            =   600
         TabIndex        =   33
         Top             =   720
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   10
         Left            =   840
         TabIndex        =   32
         Top             =   720
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   11
         Left            =   1080
         TabIndex        =   31
         Top             =   720
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   12
         Left            =   1320
         TabIndex        =   30
         Top             =   720
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   13
         Left            =   1560
         TabIndex        =   29
         Top             =   720
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   14
         Left            =   120
         TabIndex        =   28
         Top             =   960
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   15
         Left            =   360
         TabIndex        =   27
         Top             =   960
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   16
         Left            =   600
         TabIndex        =   26
         Top             =   960
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   17
         Left            =   840
         TabIndex        =   25
         Top             =   960
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   18
         Left            =   1080
         TabIndex        =   24
         Top             =   960
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   19
         Left            =   1320
         TabIndex        =   23
         Top             =   960
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   20
         Left            =   1560
         TabIndex        =   22
         Top             =   960
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   21
         Left            =   120
         TabIndex        =   21
         Top             =   1200
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   22
         Left            =   360
         TabIndex        =   20
         Top             =   1200
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   23
         Left            =   600
         TabIndex        =   19
         Top             =   1200
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   24
         Left            =   840
         TabIndex        =   18
         Top             =   1200
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   25
         Left            =   1080
         TabIndex        =   17
         Top             =   1200
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   26
         Left            =   1320
         TabIndex        =   16
         Top             =   1200
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   27
         Left            =   1560
         TabIndex        =   15
         Top             =   1200
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   28
         Left            =   120
         TabIndex        =   14
         Top             =   1440
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   29
         Left            =   360
         TabIndex        =   13
         Top             =   1440
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   30
         Left            =   600
         TabIndex        =   12
         Top             =   1440
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00400000&
         Height          =   252
         Index           =   31
         Left            =   840
         TabIndex        =   11
         Top             =   1440
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   32
         Left            =   1080
         TabIndex        =   10
         Top             =   1440
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   33
         Left            =   1320
         TabIndex        =   9
         Top             =   1440
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   34
         Left            =   1560
         TabIndex        =   8
         Top             =   1440
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   35
         Left            =   120
         TabIndex        =   7
         Top             =   1680
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   36
         Left            =   360
         TabIndex        =   6
         Top             =   1680
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   37
         Left            =   600
         TabIndex        =   5
         Top             =   1680
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   38
         Left            =   840
         TabIndex        =   4
         Top             =   1680
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   39
         Left            =   1080
         TabIndex        =   3
         Top             =   1680
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   40
         Left            =   1320
         TabIndex        =   2
         Top             =   1680
         Width           =   252
      End
      Begin VB.Label Label_Day 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FF8080&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "00"
         ForeColor       =   &H00FFC0C0&
         Height          =   252
         Index           =   41
         Left            =   1560
         TabIndex        =   1
         Top             =   1680
         Width           =   252
      End
   End
End
Attribute VB_Name = "FullMonth"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public Event DateChange()
Public Event MonthChange()

Private Sub UserControl_Resize()
    UserControl.Width = 2772
    UserControl.Height = 2052
End Sub

Private Sub Image_DateChange_Click(Index As Integer)
    Dim tDate As Date
    With Image_DateChange
        Select Case Index
            Case 0
                DrawMonth (Date)
            Case 1
                DrawMonth (month1 - 1)
            Case 2
                DrawMonth (month1 + 1)
            Case 3
                tDate = month1
                While Month(tDate) = Month(month1)
                    month1 = month1 - 1
                Wend
                DrawMonth (month1)
            Case 4
                tDate = month1
                While Month(tDate) = Month(month1)
                    month1 = month1 + 1
                Wend
                DrawMonth (month1)
        End Select
    End With
End Sub

Private Sub Image_DateChange_DblClick(Index As Integer)
    'will call image_DateChange_click Sub (it's doing the same)
    Image_DateChange_Click (Index)
End Sub

Private Sub Label_Day_Click(Index As Integer)
    DrawMonth MonthData.DayDate(Index)
End Sub

Private Sub Timer_Run_Timer()
    Label_Time.Caption = Time
End Sub

Private Sub UserControl_Initialize()
    'will init month1 date as today
    month1 = Date
    DrawMonth Date
End Sub

Sub DrawMonth(ByVal aDate As Date)
'will draw the month
    Dim tDate As Date       'temp date
    Dim sDAte As Date       'start date
    Dim d As Integer        'day label counter
    Dim a As Integer        'general counter
    tDate = aDate
    sDAte = aDate
    month1 = aDate
    Frame_Month.Caption = aDate
    'will move to 1st on input month
    While Day(month1) > 1
        month1 = month1 - 1
    Wend
    'will move to sunday
    While WeekDay(month1) > vbSunday
        month1 = month1 - 1
    Wend
    'will set days date,labels and colors
    For d = 0 To 41
        MonthData.DayDate(d) = month1
        Label_Day(d).Caption = Day(month1)
        'check for active month (requested) or Prev/Next month ans set their fore colors
        If Month(month1) = Month(tDate) Then
            Label_Day(d).ForeColor = &H400000 'dark blue
        Else
            Label_Day(d).ForeColor = &HFFC0C0 'light blue
        End If
        'will check and set back color for all month's days
        If Label_Day(d).BackColor <> &HFF8080 Then Label_Day(d).BackColor = &HFF8080 'mid blue
        If MonthData.DayColor(d) <> 0 Then Label_Day(d).BackColor = MonthData.DayColor(d)
        'will check for current date
        If month1 = Date Then Label_Day(d).BackColor = &HCA6A60    'green
        'will check for active date
        If month1 = aDate Then Label_Day(d).BackColor = &HC0C0C0 'lightgray
        month1 = month1 + 1
    Next d
    month1 = tDate
    If Month(month1) = Month(sDAte) Then RaiseEvent MonthChange
    'will raise an event
    RaiseEvent DateChange
End Sub

Sub SetDayColor(ByVal aDate As Date)
'will change day background color
    Dim a As Integer
        For a = 0 To 41
            If MonthData.DayDate(a) = aDate Then
                MonthData.DayColor(a) = MonthData.SpecialColor
                DrawMonth month1
            End If
        Next a
    End Sub

'-----------------------------------------------------------------------------------
'Properties

Public Property Get Value() As Date
    Value = month1
End Property

Public Property Let Value(ByVal tDate As Date)
    DrawMonth (tDate)
    PropertyChanged "Value"
End Property

Public Property Let SpecialColor(ByVal aColor As Long)
    MonthData.SpecialColor = aColor
    PropertyChanged "SpecialColor"
End Property

Public Property Let DayColor(ByVal aDate As Date)
    SetDayColor aDate
    PropertyChanged "DayColor"
End Property
Public Property Get Refresh() As Date
    DrawMonth month1
    Refresh = month1
End Property

'-----------------------------------------------------------------------------------


