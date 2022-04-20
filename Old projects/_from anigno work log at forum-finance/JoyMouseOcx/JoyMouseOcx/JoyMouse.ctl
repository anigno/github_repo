VERSION 5.00
Begin VB.UserControl JoyMouse 
   ClientHeight    =   1008
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   1428
   ScaleHeight     =   1008
   ScaleWidth      =   1428
   Begin VB.Timer tmrJoyStick 
      Interval        =   50
      Left            =   480
      Top             =   480
   End
   Begin VB.Timer tmrMouse 
      Interval        =   10
      Left            =   840
      Top             =   480
   End
   Begin VB.Label Label1 
      Caption         =   "JoyMouse"
      Height          =   372
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   852
   End
End
Attribute VB_Name = "JoyMouse"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Dim LeftButton, RightButton, MiddleButton, WheelButton As Integer
Dim JoyMouseEnable As Boolean
Dim Joy As JOYINFO
Dim Pnt As POINT_TYPE
Dim JoyData As JOYCAPS
Dim RetVal As Long
Dim Mx As Long, My As Long  ' JoyMose coords
Dim tMx, tMy                'JoyMouse temp coords
Dim Btn(4) As Boolean       'joystick button last position
Dim JoyMouseSpeed As Long
Dim Acc As Double

Private Sub tmrJoyStick_Timer()
    Dim X, Y, B As Long
    Dim a, c As Integer
    RetVal = joyGetPos(0, Joy)
    If RetVal = 0 Then
        X = Joy.wXpos
        Y = Joy.wYpos
        B = Joy.wButtons
        'joystick move check
        If X < 31500 Or X < 35000 Or Y < 31500 Or Y > 35000 Then
            Acc = Acc + 1
        Else
            Acc = 0
        End If
        If X < 31500 Then Mx = Mx - JoyMouseSpeed
        If X > 35000 Then Mx = Mx + JoyMouseSpeed
        If X < 31500 Then Mx = My - JoyMouseSpeed
        If X > 35000 Then Mx = My + JoyMouseSpeed
        
'        If X < 35000 Or X > 31500 Then Mx = Mx + ((X - 32767) / JoyMouseSpeed) ^ 3
'        If Y < 34000 Or Y > 31500 Then My = My + ((Y - 32767) / JoyMouseSpeed) ^ 3
        'will check if joystick has moved the mouse
        If tMx <> Mx Or tMy <> My Then
            RetVal = SetCursorPos(Mx, My)
        End If
        If tMx <> Mx Then tMx = Mx
        If tMy <> My Then tMy = My
        
        'joystick button check 0=left 1=right 2=middle
        
        'check if Button releaced
        If B = 0 And Btn(0) = True Then
            mouse_event MOUSEEVENTF_LEFTUP, 0, 0, 0, 0
            Btn(0) = False
        End If
        If B = 0 And Btn(1) = True Then
            mouse_event MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0
            Btn(1) = False
        End If
        If B = 0 And Btn(2) = True Then
            mouse_event MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0
            Btn(2) = False
        End If
        'check for button press
        If B = LeftButton And Btn(0) = False Then
            mouse_event MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0
            Btn(0) = True
        End If
        If B = RightButton And Btn(1) = False Then
            mouse_event MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0
            Btn(1) = True
        End If
        If B = MiddleButton And Btn(2) = False Then
            mouse_event MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0
            Btn(2) = True
        End If
        'check for wheel move
     End If
End Sub

Private Sub tmrMouse_Timer()
    GetCursorPos Pnt
    If Pnt.X <> Mx Or Pnt.Y <> My Then
        Mx = Pnt.X
        My = Pnt.Y
    End If
End Sub

Private Sub UserControl_Initialize()
    'init mouse position to JoyMouse Vars
    RetVal = GetCursorPos(Pnt)
    Mx = Pnt.X
    My = Pnt.Y
    tMx = Pnt.X
    tMy = Pnt.Y
    JoyMouseSpeed = 10
    LeftButton = 4
    RightButton = 8
    MiddleButton = 2
    WheelButton = 1
    JoyMouseEnable = True
End Sub


Public Property Get Speed() As Variant
    Speed = JoyMouseSpeed
End Property

Public Property Let Speed(ByVal vNewValue As Variant)
    JoyMouseSpeed = vNewValue
End Property


Public Property Get Enable() As Variant
    Enable = JoyMouseEnable
End Property

Public Property Let Enable(ByVal vNewValue As Variant)
    If vNewValue = True Then
        tmrJoyStick.Enabled = True
        tmrMouse.Enabled = True
    Else
        tmrJoyStick.Enabled = False
        tmrMouse.Enabled = False
    End If
End Property

Public Property Get GetX() As Variant
    GetX = Mx
End Property


Public Property Get GetY() As Variant
    GetY = My
End Property

Public Property Get GetButtons() As Variant
    RetVal = joyGetPos(0, Joy)
    GetButtons = Joy.wButtons
End Property

