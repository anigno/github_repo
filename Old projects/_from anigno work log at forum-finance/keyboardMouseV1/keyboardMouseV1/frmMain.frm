VERSION 5.00
Begin VB.Form frmMain 
   Caption         =   "keyboardMouse v1.0"
   ClientHeight    =   615
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   3165
   Icon            =   "frmMain.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   ScaleHeight     =   41
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   211
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer Timer1 
      Interval        =   50
      Left            =   240
      Top             =   120
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim mx, my
Dim iPnt As POINT_TYPE
Dim curSpeed As Integer
Dim k1, k2, k3, k4, k5, tk5
Dim lBtnState As Boolean

Private Sub Form_Load()
    GetCursorPos iPnt
    mx = iPnt.x
    my = iPnt.y
    curSpeed = 1
    frmMain.Left = 0
    frmMain.Top = 0
End Sub

Private Sub Form_LostFocus()
    frmMain.SetFocus
End Sub

Private Sub Form_MouseDown(Button As Integer, Shift As Integer, x As Single, y As Single)
    Timer1_Timer
End Sub

Private Sub Timer1_Timer()
    k1 = GetKeyState(37)
    k2 = GetKeyState(38)
    k3 = GetKeyState(39)
    k4 = GetKeyState(40)
    k5 = GetKeyState(32)
    k6 = GetKeyState(VK_SHIFT)
    If k6 = 1 Then
        If k1 + k2 + k3 + k4 < 0 Then
            curSpeed = curSpeed + 1
            If curSpeed > 10 Then curSpeed = 10
        Else
            curSpeed = 1
        End If
        frmMain.WindowState = vbNormal
        frmMain.Width = 4000
        frmMain.Height = 100
        SetForegroundWindow frmMain.hwnd
        If k1 < 0 Then
            mx = mx - curSpeed
            SetCursorPos mx, my
        End If
        If k2 < 0 Then
            my = my - curSpeed
            SetCursorPos mx, my
        End If
        If k3 < 0 Then
            mx = mx + curSpeed
            SetCursorPos mx, my
        End If
        If k4 < 0 Then
            my = my + curSpeed
            SetCursorPos mx, my
        End If
        If k5 < 0 Then
            If lBtnState = False Then
                mouse_event MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0
                mouse_event MOUSEEVENTF_LEFTUP, 0, 0, 0, 0
                lBtnState = True
            End If
        End If
        If lBtnState = True And k5 >= 0 Then
             lBtnState = False
        End If
    Else
        SetWindowPos frmMain.hwnd, 1, 0, 0, 0, 0, Flags
        frmMain.WindowState = vbMinimized
    End If
End Sub
