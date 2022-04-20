VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Bimap Bits Example"
   ClientHeight    =   2760
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   3135
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   184
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   209
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdNegative 
      Caption         =   "Negative"
      Height          =   315
      Left            =   75
      TabIndex        =   1
      Top             =   2400
      Width           =   1140
   End
   Begin VB.PictureBox Picture1 
      AutoRedraw      =   -1  'True
      AutoSize        =   -1  'True
      BackColor       =   &H00000000&
      BorderStyle     =   0  'None
      Height          =   2250
      Left            =   75
      Picture         =   "Form1.frx":0000
      ScaleHeight     =   150
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   200
      TabIndex        =   0
      Top             =   75
      Width           =   3000
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'* CODED BY: BattleStorm
'* EMAIL: battlestorm@cox.net
'* UPDATED: 08/06/2002
'* PURPOSE: Demonstrates how to use
'*     GetBitmapBits and SetBitmapBits.
'*     Also shows how to make a Negative
'*     of a picture.
'* COPYRIGHT: This program and source
'*     code is freeware and can be copied
'*     and/or distributed as long as you
'*     mention the original author. I am
'*     not responsible for any harm as the
'*     outcome of using any of this code.
'* CREDITS: Special thanks go out to
'*     www.allapi.net for their wonderful
'*     API Guide that I use all the time as
'*     my only API reference. Some of this
'*     code is borrowed from their examples
'*     and modified slightly for X, Y coor-
'*     dinate manipulation of pixels.

'API declarations
Private Declare Function GetBitmapBits Lib "gdi32" (ByVal hBitmap As Long, ByVal dwCount As Long, lpBits As Any) As Long
Private Declare Function SetBitmapBits Lib "gdi32" (ByVal hBitmap As Long, ByVal dwCount As Long, lpBits As Any) As Long

'Class declarations
Private CodeTimer As clsTimer

'Private variable declarations
Private bmWidth As Long
Private bmHeight As Long
Private bmSize As Long
Private bmBits() As Byte

'This sub uses GetBitmapBits and SetBitmapBits to grab the
'pixels from a picturebox and turn each Red, Blue and Green
'value to its negative color. It then repaints the picture.
Private Sub cmdNegative_Click()
    'Initialize CodeTimer
    Set CodeTimer = New clsTimer
    
    'Start CodeTimer
    CodeTimer.StartTimer
    
    'Get picture's Width and Height
    bmWidth = Picture1.Width
    bmHeight = Picture1.Height

    'ReDefine Bit array to hold all pixels from picture box
    ReDim Bits(0 To 2, 0 To bmWidth - 1, 0 To bmHeight - 1) As Byte
    
    'Store size of bitmap in total pixels
    bmSize = 3 * bmWidth * bmHeight
    
    'Grab picture's pixels and load to Bit array
    GetBitmapBits Picture1.Image, bmSize, Bits(0, 0, 0)
    
    'Loop thru each Red, Green and Blue portion of each
    'pixel and turn it to it's negative color
    For Y = 0 To bmHeight - 1
        For X = 0 To bmWidth - 1
            Bits(2, X, Y) = 255 - Bits(2, X, Y) 'Red Bits
            Bits(1, X, Y) = 255 - Bits(1, X, Y) 'Green Bits
            Bits(0, X, Y) = 255 - Bits(0, X, Y) 'Blue Bits
        Next X
    Next Y
    
    'Load Bit array to picture box
    SetBitmapBits Picture1.Image, bmSize, Bits(0, 0, 0)
    
    'SetBitmapBits normally triggers a redraw event,
    'but just in case it doesn't, we'll do one now
    Picture1.Refresh
    
    'Stop CodeTimer
    CodeTimer.StopTimer
    
    'Display CodeTimer results in Form's caption
    Me.Caption = CodeTimer.Elasped & " ms"
End Sub

Private Sub Form_Load()
  'Inform user that program will run alot faster when compiled
  If App.LogMode = 0 Then
    MsgBox "Compile Me - I'll Run Alot Faster!"
  End If
End Sub
