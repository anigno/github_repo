Attribute VB_Name = "Module_FullMonth"
Option Explicit
Type FullMonthDataType
    Caption As String
    DayDate(0 To 41) As Date
    DayColor(0 To 41) As Long
    Month As Integer
    Year As Integer
    Day As Integer
    WeekDay As Integer
    SpecialColor As Long
End Type
Public MonthData As FullMonthDataType
Public month1 As Date
