Attribute VB_Name = "mdlMain"
Option Explicit
'-----------------------------------------------------------------
Type JOYINFO
  wXpos As Long
  wYpos As Long
  wZpos As Long
  wButtons As Long
End Type

Declare Function joyGetPos Lib "winmm.dll" (ByVal uJoyID As Long, pji As JOYINFO) As Long
'-----------------------------------------------------------------
Type POINT_TYPE
  X As Long
  Y As Long
End Type

'GetCursorPos reads the current position of the mouse cursor.
'The x and y coordinates of the cursor (relative to the screen)
'are put into the variable passed as lpPoint.
'The function returns 0 if an error occured or 1 if it is successful.

Declare Function GetCursorPos Lib "user32.dll" (lpPoint As POINT_TYPE) As Long
'-----------------------------------------------------------------
'SetCursorPos sets the position of the mouse cursor.
'If you try to set the coordinates outside of the range of the display
'(for example, to (700,40) on a 640x480 display)
'or outside the confining rectangle (set by ClipCursor), the cursor
'will just go to the edge of the screen or the rectangle.
'The function returns 0 if an error occured, or 1 if successful.

Declare Function SetCursorPos Lib "user32.dll" (ByVal X As Long, ByVal Y As Long) As Long
'-----------------------------------------------------------------
'mouse_event synthesizes mouse input by placing mouse input
'information into the input stream. A single mouse input event
'consists of either a move of the mouse or the change of the button
'state. For mouse movement, the coordinates can be given in either
'absolute or relative form. Only changes in mouse position or button
'state should be send via this function. For example, if the left
'mouse button is already down, the program should not send another
'left-button-down input.

Declare Sub mouse_event Lib "user32.dll" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)

Public Const MOUSEEVENTF_ABSOLUTE = &H8000
Public Const MOUSEEVENTF_LEFTDOWN = &H2
Public Const MOUSEEVENTF_LEFTUP = &H4
Public Const MOUSEEVENTF_MIDDLEDOWN = &H20
Public Const MOUSEEVENTF_MIDDLEUP = &H40
Public Const MOUSEEVENTF_MOVE = &H1
Public Const MOUSEEVENTF_RIGHTDOWN = &H8
Public Const MOUSEEVENTF_RIGHTUP = &H10
Public Const MOUSEEVENTF_WHEEL = &H80
Public Const MOUSEEVENTF_XDOWN = &H100
Public Const MOUSEEVENTF_XUP = &H200
Public Const WHEEL_DELTA = 120
Public Const XBUTTON1 = &H1
Public Const XBUTTON2 = &H2
'-----------------------------------------------------------------
'joyGetDevCaps reads various information about a joystick. This
'information is put into the variable passed as lpCaps.
'This function does not, however, give you the current position of
'the joystick. The function returns 0 if the joystick is connected
'and working and a non-zero error code if it isn't.

Declare Function joyGetDevCaps Lib "winmm.dll" Alias "joyGetDevCapsA" (ByVal id As Long, lpCaps As JOYCAPS, ByVal uSize As Long) As Long

Type JOYCAPS
  wMid As Integer
  wPid As Integer
  szPname As String * 32
  wXmin As Long
  wXmax As Long
  wYmin As Long
  wYmax As Long
  wZmin As Long
  wZmax As Long
  wNumButtons As Long
  wPeriodMin As Long
  wPeriodMax As Long
  wRmin As Long
  wRmax As Long
  wUmin As Long
  wUmax As Long
  wVmin As Long
  wVmax As Long
  wMaxAxes As Long
  wNumAxes As Long
  wMaxButtons As Long
  szRegKey As String * 32
  szOEMVxD As String * 240
End Type
'JOYCAPS-type variables hold information about a joystick (not to be
'confused with the current position of the joystick). Namely, this
'structure holds the axes' ranges and the number of buttons the
'joystick has.

'-----------------------------------------------------------------


