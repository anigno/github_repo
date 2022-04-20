VERSION 5.00
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.2#0"; "COMCTL32.OCX"
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Begin VB.Form frmTelnet 
   BackColor       =   &H80000017&
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Ian's Telnet Client"
   ClientHeight    =   5970
   ClientLeft      =   -225
   ClientTop       =   3000
   ClientWidth     =   8220
   FillColor       =   &H00800000&
   BeginProperty Font 
      Name            =   "Fixedsys"
      Size            =   9
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H0000FFFF&
   Icon            =   "telnet.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   5970
   ScaleWidth      =   8220
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin MSWinsockLib.Winsock WinsockClient 
      Left            =   6120
      Top             =   600
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   327681
   End
   Begin VB.Timer cursor_timer 
      Enabled         =   0   'False
      Interval        =   300
      Left            =   6600
      Top             =   600
   End
   Begin ComctlLib.StatusBar stbStatusBar 
      Align           =   2  'Align Bottom
      Height          =   495
      Left            =   0
      TabIndex        =   0
      Top             =   5475
      Width           =   8220
      _ExtentX        =   14499
      _ExtentY        =   873
      SimpleText      =   ""
      _Version        =   327682
      BeginProperty Panels {0713E89E-850A-101B-AFC0-4210102A8DA7} 
         NumPanels       =   4
         BeginProperty Panel1 {0713E89F-850A-101B-AFC0-4210102A8DA7} 
            Object.Width           =   2822
            MinWidth        =   2822
            Text            =   "No Connection"
            TextSave        =   "No Connection"
            Key             =   "Mode"
            Object.Tag             =   ""
            Object.ToolTipText     =   "Operating Mode"
         EndProperty
         BeginProperty Panel2 {0713E89F-850A-101B-AFC0-4210102A8DA7} 
            Text            =   "None"
            TextSave        =   "None"
            Key             =   "Lip"
            Object.Tag             =   ""
            Object.ToolTipText     =   "Local IP"
         EndProperty
         BeginProperty Panel3 {0713E89F-850A-101B-AFC0-4210102A8DA7} 
            Text            =   "None"
            TextSave        =   "None"
            Key             =   "Rip"
            Object.Tag             =   ""
            Object.ToolTipText     =   "Remote IP"
         EndProperty
         BeginProperty Panel4 {0713E89F-850A-101B-AFC0-4210102A8DA7} 
            AutoSize        =   1
            Object.Width           =   6456
            Text            =   "Welcome to Ian's Telnet Client"
            TextSave        =   "Welcome to Ian's Telnet Client"
            Key             =   "Status"
            Object.Tag             =   ""
            Object.ToolTipText     =   "Last Status Message"
         EndProperty
      EndProperty
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin VB.Menu mFile 
      Caption         =   "File"
      Begin VB.Menu mExit 
         Caption         =   "Exit"
      End
   End
   Begin VB.Menu mConnection 
      Caption         =   "Connection"
      Begin VB.Menu mSettings 
         Caption         =   "Settings"
      End
      Begin VB.Menu mOpen 
         Caption         =   "Open"
      End
      Begin VB.Menu mClose 
         Caption         =   "Close"
      End
   End
End
Attribute VB_Name = "frmTelnet"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit

Const GO_NORM = 0

Const GO_ESC1 = 1
Const GO_ESC2 = 2
Const GO_ESC3 = 3
Const GO_ESC4 = 4
Const GO_ESC5 = 5

Const GO_IAC1 = 6
Const GO_IAC2 = 7
Const GO_IAC3 = 8
Const GO_IAC4 = 9
Const GO_IAC5 = 10
Const GO_IAC6 = 11


Const SUSP = 237
Const ABORT = 238      'Abort
Const SE = 240         'End of Subnegotiation
Const NOP = 241
Const DM = 242         'Data Mark
Const BREAK = 243      'BREAK
Const IP = 244         'Interrupt Process
Const AO = 245         'Abort Output
Const AYT = 246        'Are you there
Const EC = 247         'Erase character
Const EL = 248         'Erase Line
Const GOAHEAD = 249    'Go Ahead
Const SB = 250         'What follows is subnegotiation
Const WILLTEL = 251
Const WONTTEL = 252
Const DOTEL = 253
Const DONTTEL = 254
Const IAC = 255

Const BINARY = 0
Const ECHO = 1
Const RECONNECT = 2
Const SGA = 3
Const AMSN = 4
Const STATUS = 5
Const TIMING = 6
Const RCTAN = 7
Const OLW = 8
Const OPS = 9
Const OCRD = 10
Const OHTS = 11
Const OHTD = 12
Const OFFD = 13
Const OVTS = 14
Const OVTD = 15
Const OLFD = 16
Const XASCII = 17
Const LOGOUT = 18
Const BYTEM = 19
Const DET = 20
Const SUPDUP = 21
Const SUPDUPOUT = 22
Const SENDLOC = 23
Const TERMTYPE = 24
Const EOR = 25
Const TACACSUID = 26
Const OUTPUTMARK = 27
Const TERMLOCNUM = 28
Const REGIME3270 = 29
Const X3PAD = 30
Const NAWS = 31
Const TERMSPEED = 32
Const TFLOWCNTRL = 33
Const LINEMODE = 34
Const DISPLOC = 35
Const ENVIRON = 36
Const AUTHENTICATION = 37
Const UNKNOWN39 = 39
Const EXTENDED_OPTIONS_LIST = 255
Const RANDOM_LOSE = 256




'------------------------------------------------------------
Private Operating       As Boolean
Private Connected       As Boolean
Public Receiving        As Boolean

Private parsedata(10)   As Integer
Private ppno            As Integer


Private control_on      As Boolean


Public RemoteIPAd  As String
Public RemotePort  As Integer

Public TraceTelnet As Boolean
Public Tracevt100   As Boolean

Private sw_ugoahead As Boolean
Private sw_igoahead As Boolean
Private sw_echo     As Boolean
Private sw_linemode As Boolean
Private sw_termsent As Boolean
Private substate    As Boolean


Private Sub cursor_timer_Timer()


If Not Receiving Then
   ' Debug.Print "Timer"
    term_DriveCursor
End If

End Sub


Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
  Dim CH As String
    
  CH = Chr$(0)
    
  'Translate keycodes to VT100 escape sequences
  
  Select Case KeyCode
    Case vbKeyControl
      control_on = True
    Case vbKeyEnd
      CH = Chr$(27) + "[K"
    Case vbKeyHome
      CH = Chr$(27) + "[H"
    Case vbKeyLeft
      CH = Chr$(27) + "[D"
    Case vbKeyUp
      CH = Chr$(27) + "[A"
    Case vbKeyRight
      CH = Chr$(27) + "[C"
    Case vbKeyDown
      CH = Chr$(27) + "[B"
    Case vbKeyF1
      CH = Chr$(27) + "OP"
    Case vbKeyF2
      CH = Chr$(27) + "OQ"
    Case vbKeyF3
      CH = Chr$(27) + "OR"
    Case vbKeyF4
      CH = Chr$(27) + "OS"
    Case Else
      If control_on And KeyCode > 63 Then
        CH = Chr$(KeyCode - 64)
      End If
  End Select

  If CH > Chr$(0) And Connected Then
    WinsockClient.SendData CH
  If TraceTelnet Then Debug.Print CH
  
  End If


End Sub

Private Sub Form_KeyPress(KeyAscii As Integer)
Dim CH As String
    
    If Connected Then
        CH = Chr$(KeyAscii)
        If control_on Then
          If KeyAscii > 63 Then
            CH = Chr$(KeyAscii - 64)
          Else
            CH = Chr$(0)
          End If
        End If
        
        If CH > Chr$(0) Then
              If CH = Chr$(13) Then
                CH = CH & Chr$(10)
              End If
              WinsockClient.SendData CH
        End If
    End If


End Sub

Private Sub Form_KeyUp(KeyCode As Integer, Shift As Integer)
    Select Case KeyCode
      Case vbKeyControl
        control_on = False
    End Select

End Sub

Private Sub Form_Load()
    RemoteIPAd = "fastlane.net"
    RemotePort = 23
    stbStatusBar.Panels(2).Text = WinsockClient.LocalIP
    term_init
End Sub

Private Sub Form_Paint()
 term_redrawscreen
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    With WinsockClient
        .Close                            ' Clear any errors...
        .RemoteHost = "0.0.0.0"
        .RemotePort = 0
    End With
    Operating = False
    Connected = False
End Sub
Private Sub Form_Unload(Cancel As Integer)
    End                                  ' End program forcefully
End Sub


Private Sub mClose_Click()
    WinsockClient_Close
End Sub

Private Sub mExit_Click()
    End
End Sub

Private Sub mOpen_Click()
   On Error Resume Next                                   ' Handle errors...
'------------------------------------------------------------
    If Not Operating Then
        Operating = True
      If TraceTelnet Then Debug.Print Int(Timer) & " - [DoConnect] : " & vbCrLf
        With WinsockClient
            If .State <> 0 Then
                .Close
                .RemotePort = 0
                .LocalPortPort = 0
                Do
                Loop Until .State = 0
            End If
            
            .RemoteHost = RemoteIPAd
            .RemotePort = RemotePort
            .Connect ' Attempt new connection
            term_init
            frmTelnet.stbStatusBar.Panels(4).Text = "Connecting to Remote Host"
            
        End With
    End If

End Sub

Private Sub mSettings_Click()
    frmTCPIP.Show vbModal, frmTelnet
End Sub

Private Sub WinsockClient_Close()
        
        frmTelnet.stbStatusBar.Panels(1).Text = "Closed"
        frmTelnet.stbStatusBar.Panels(3).Text = WinsockClient.LocalIP
        frmTelnet.stbStatusBar.Panels(2).Text = ""
        frmTelnet.stbStatusBar.Panels(4).Text = "Connection Reset"
        
      If TraceTelnet Then Debug.Print Int(Timer) & " - [Closed  ] : Connection Reset By Peer "
        With WinsockClient
            .Close                                     ' Clear any errors...
            .RemotePort = 0
            .LocalPort = 0
        End With
        Operating = False
        Connected = False
 
End Sub

Private Sub WinsockClient_Connect()

Dim ConnectString As String

'------------------------------------------------------------
        
      If TraceTelnet Then Debug.Print Int(Timer) & " - [Connect] : " & _
                    "[" & WinsockClient.RemoteHost & "] " & _
                    "[" & WinsockClient.RemoteHostIP & "] " & _
                    "[" & CStr(WinsockClient.RemotePort) & "]"  ' Display connection info
        
         
        sw_ugoahead = True
        sw_igoahead = False
        sw_echo = True
        sw_linemode = False
        sw_termsent = False
        substate = False
         
         ConnectString = Chr$(IAC) & Chr$(DOTEL) & Chr$(ECHO) _
                       & Chr$(IAC) & Chr$(DOTEL) & Chr$(SGA) _
                       & Chr$(IAC) & Chr$(WILLTEL) & Chr$(NAWS) _
                       & Chr$(IAC) & Chr$(WILLTEL) & Chr$(TERMTYPE) _
                       & Chr$(IAC) & Chr$(WILLTEL) & Chr$(TERMSPEED)

        
        WinsockClient.SendData ConnectString
        
        If TraceTelnet Then Debug.Print "SENT: DOTEL  ECHO SGA"
        If TraceTelnet Then Debug.Print "SENT: WILL NAWS TERMTYPE TERMSPEED"
        
        Connected = True
        frmTelnet.stbStatusBar.Panels(1).Text = "Connected"
        frmTelnet.stbStatusBar.Panels(3).Text = WinsockClient.LocalIP
        frmTelnet.stbStatusBar.Panels(2).Text = WinsockClient.RemoteHostIP
        frmTelnet.stbStatusBar.Panels(4).Text = "Connection Accepted By Remote Host"
        
End Sub

Private Sub WinsockClient_DataArrival(ByVal bytesTotal As Long)
    
    Dim CH()     As Byte
    Dim Test()   As Integer
    Dim I        As Integer
    Static cmd   As Byte
'------------------------------------------------------------
        
    If Not Receiving Then
        Receiving = True
        term_CaretControl True
    Else
        Exit Sub
    End If
    
    If (bytesTotal > 0) Then  ' If there is any data...
        
        
        WinsockClient.GetData CH, vbByte + vbArray, bytesTotal
        
       ' CH = Buf
        For I = 0 To bytesTotal - 1
            Select Case cmd
                Case GO_NORM
                  cmd = term_process_char(CH(I))
                Case GO_IAC1
                  cmd = iac1(CH(I))
                Case GO_IAC2
                  cmd = iac2(CH(I))
                Case GO_IAC3
                  cmd = iac3(CH(I))
                Case GO_IAC4
                  cmd = iac4(CH(I))
                Case GO_IAC5
                  cmd = iac5(CH(I))
                Case GO_IAC6
                  cmd = iac6(CH(I))
                Case Else
                 If TraceTelnet Then Debug.Print "Invalid 'next (" + Str$(cmd) + ")' processing routine in cmd loop"
            End Select
        Next I
    End If
    
    term_CaretControl False
    Receiving = False
End Sub



Private Function iac1(CH As Byte) As Integer

  ' Debug.Print "IAC : ";
  iac1 = GO_NORM

  Select Case CH
    Case DOTEL
      iac1 = GO_IAC2
    Case DONTTEL
      iac1 = GO_IAC6
    Case WILLTEL
      iac1 = GO_IAC3
    Case WONTTEL
      iac1 = GO_IAC4
    Case SB
      iac1 = GO_IAC5
      ppno = 0
    Case SE
      ' End of negotiation string, string is in parsedata()
      Select Case parsedata(0)
        Case TERMTYPE
          If parsedata(1) = 1 Then
               If TraceTelnet Then Debug.Print "SENT: SB TERMTYPE VT100"
                WinsockClient.SendData Chr$(IAC) & Chr$(SB) & Chr$(TERMTYPE) & "DEC-VT100" & Chr$(0) & Chr$(IAC) & Chr$(SE)
          End If
        Case TERMSPEED
          If parsedata(1) = 1 Then
                ' Debug.Print "TERMSPEED"
                If TraceTelnet Then Debug.Print "SENT: SB TERMSPEED 38400"
                WinsockClient.SendData Chr$(IAC) & Chr$(WILLTEL) & Chr$(CH)
                WinsockClient.SendData Chr$(IAC) & Chr$(SB) _
                                & Chr$(TERMSPEED) & Chr$(0) _
                                & "57600,57600" _
                                & Chr$(IAC) & Chr$(SE)
          End If
      End Select
  End Select

End Function

Private Function iac2(CH As Byte) As Integer

  'DO Processing Respond with WILL or WONT

  If TraceTelnet Then Debug.Print "                                                                   RECEIVED DO : ";
  iac2 = GO_NORM

  Select Case CH
    Case BINARY
        If TraceTelnet Then Debug.Print "BINARY"
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(BINARY)
        If TraceTelnet Then Debug.Print "SENT: WONT BINARY"
    Case ECHO
        If TraceTelnet Then Debug.Print "ECHO"
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(ECHO)
        If TraceTelnet Then Debug.Print "SENT: WONT ECHO"
    Case NAWS
        If TraceTelnet Then Debug.Print "WINDOW SIZE"
        WinsockClient.SendData Chr$(IAC) & Chr$(SB) & Chr$(NAWS) & Chr$(0) & Chr$(80) & Chr$(0) & Chr$(24) & Chr$(IAC) & Chr$(SE)
        If TraceTelnet Then Debug.Print "SENT: SB WINDOW SIZE 80x24"
    Case SGA
        If TraceTelnet Then Debug.Print "SGA"
        If Not sw_igoahead Then
            If TraceTelnet Then Debug.Print "SENT: WILL SGA"
            WinsockClient.SendData Chr$(IAC) & Chr$(WILLTEL) & Chr$(SGA)
            sw_igoahead = True
        Else
           If TraceTelnet Then Debug.Print "DID NOT RESPOND"
        End If
    Case TERMTYPE
        If TraceTelnet Then Debug.Print "TERMTYPE"
        If Not sw_termsent Then
            If TraceTelnet Then Debug.Print "SENT: WILL TERMTYPE"
              sw_termsent = True
              WinsockClient.SendData Chr$(IAC) & Chr$(WILLTEL) & Chr$(TERMTYPE)
            If TraceTelnet Then Debug.Print "SENT: SB TERMTYPE VT100"
              WinsockClient.SendData Chr$(IAC) & Chr$(SB) & Chr$(TERMTYPE) & _
              Chr$(0) & "VT100" & Chr$(IAC) & Chr$(SE)
         Else
            If TraceTelnet Then Debug.Print "DID NOT RESPOND"
         End If
 
    Case TERMSPEED
        If TraceTelnet Then Debug.Print "TERMSPEED"
        If TraceTelnet Then Debug.Print "SENT: WILL TERMSPEED"
        WinsockClient.SendData Chr$(IAC) & Chr$(WILLTEL) & Chr$(TERMSPEED)
      
    If TraceTelnet Then Debug.Print "SENT: SB TERMSPEED 57600"
        WinsockClient.SendData Chr$(IAC) & Chr$(SB) & Chr$(TERMSPEED) & Chr$(0)
        WinsockClient.SendData "57600,57600"
        WinsockClient.SendData Chr$(IAC) & Chr$(SE)
      
    Case TFLOWCNTRL
        If TraceTelnet Then Debug.Print "TFLOWCNTRL"
        If TraceTelnet Then Debug.Print "SENT: WONT FLOWCONTROL"
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
      
    Case LINEMODE
        If TraceTelnet Then Debug.Print "LINEMODE"
        If TraceTelnet Then Debug.Print "SENT: WONT LINEMODE"
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
      
    Case STATUS
        If TraceTelnet Then Debug.Print "STATUS"
        If TraceTelnet Then Debug.Print "SENT: WONT STATUS"
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
      
    Case TIMING
        If TraceTelnet Then Debug.Print "TIMING"
        If TraceTelnet Then Debug.Print "SENT: WONT TIMING"
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
      
    Case DISPLOC
        If TraceTelnet Then Debug.Print "DISPLOC"
        If TraceTelnet Then Debug.Print "SENT: WONT DISPLOC"
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
    
    Case ENVIRON
        If TraceTelnet Then Debug.Print "ENVIRON"
        If TraceTelnet Then Debug.Print "SENT: WONT ENVIRON"
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
    
    Case UNKNOWN39
        If TraceTelnet Then Debug.Print "UNKNOWN39"
        If TraceTelnet Then Debug.Print "SENT: WONT " & Asc(CH)
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
    
    Case AUTHENTICATION
        If TraceTelnet Then Debug.Print "AUTHENTICATION"
        If TraceTelnet Then Debug.Print "SENT: WILL "; AUTHENTICATION; ""
        WinsockClient.SendData Chr$(IAC) & Chr$(WILLTEL) & Chr$(CH)
      
        If TraceTelnet Then Debug.Print "SENT: SB AUTHENTICATION"
        WinsockClient.SendData Chr$(IAC) & _
                          Chr$(SB) & _
                          Chr$(AUTHENTICATION) & _
                          Chr$(0) & Chr$(0) & Chr$(0) & Chr$(0) & _
                          Chr$(IAC) & _
                          Chr$(SE)
    Case Else
        If TraceTelnet Then Debug.Print "UNKNOWN CMD " & Asc(CH)
        If TraceTelnet Then Debug.Print "SENT: WONT UNKNOWN CMD " & CH
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
  End Select

End Function

Private Function iac3(CH As Byte) As Integer

  ' WILL Processing - Respond with DO or DONT
  
If TraceTelnet Then Debug.Print "                                                                   RECEIVED WILL : ";

  iac3 = GO_NORM

  Select Case CH
    Case ECHO
    If TraceTelnet Then Debug.Print "ECHO"
      If Not sw_echo Then
        sw_echo = True
        WinsockClient.SendData Chr$(IAC) & Chr$(DOTEL) & Chr$(ECHO)
      If TraceTelnet Then Debug.Print "SENT: DO ECHO"
      End If
    Case SGA
    If TraceTelnet Then Debug.Print "SGA"
      If Not sw_ugoahead Then
        sw_ugoahead = True
        WinsockClient.SendData Chr$(IAC) & Chr$(DOTEL) & Chr$(SGA)
      If TraceTelnet Then Debug.Print "SENT: DOTEL SGA"
      End If
    
    Case TERMSPEED
    If TraceTelnet Then Debug.Print "TERMSPEED"
    If TraceTelnet Then Debug.Print "SENT: DONT TERMSPEED"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
      
    Case TFLOWCNTRL
    If TraceTelnet Then Debug.Print "TFLOWCNTRL"
    If TraceTelnet Then Debug.Print "SENT: DONT FLOWCONTROL"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
      
    Case LINEMODE
    If TraceTelnet Then Debug.Print "LINEMODE"
    If TraceTelnet Then Debug.Print "SENT: DONT LINEMODE"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
      
    Case STATUS
    If TraceTelnet Then Debug.Print "STATUS"
    If TraceTelnet Then Debug.Print "SENT: DONT STATUS"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
      
    Case TIMING
    If TraceTelnet Then Debug.Print "TIMING"
    If TraceTelnet Then Debug.Print "SENT: DONT TIMING"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
      
    Case DISPLOC
    If TraceTelnet Then Debug.Print "DISPLOC"
    If TraceTelnet Then Debug.Print "SENT: WONT DISPLOC"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
    
    Case ENVIRON
    If TraceTelnet Then Debug.Print "ENVIRON"
    If TraceTelnet Then Debug.Print "SENT: WONT ENVIRON"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
    
    Case UNKNOWN39
    If TraceTelnet Then Debug.Print "UNKNOWN39"
    If TraceTelnet Then Debug.Print "SENT: WONT " & Asc(CH)
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
    
    
    Case Else
    If TraceTelnet Then Debug.Print "UNKNOWN CMD " & Asc(CH)
    If TraceTelnet Then Debug.Print "SENT: WONT UNKNOWN CMD " & Asc(CH)
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
  End Select

End Function

Private Function iac4(CH As Byte) As Integer

  ' WONT Processing
  
    If TraceTelnet Then Debug.Print "                                                                   RECEIVED WONT : ";

  iac4 = GO_NORM

  Select Case CH
    
    Case ECHO
    If TraceTelnet Then Debug.Print "ECHO"
      If sw_echo = True Then
        WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(ECHO)
      If TraceTelnet Then Debug.Print "SENT: DONTEL ECHO"
        sw_echo = False
      End If
      
    Case SGA
    If TraceTelnet Then Debug.Print "SGA"
    If TraceTelnet Then Debug.Print "SENT: DONT SGA"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(SGA)
      sw_igoahead = False
    
    Case TERMSPEED
    If TraceTelnet Then Debug.Print "TERMSPEED"
    If TraceTelnet Then Debug.Print "SENT: DONT TERMSPEED"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
    
    Case TFLOWCNTRL
    If TraceTelnet Then Debug.Print "FLOWCONTROL"
    If TraceTelnet Then Debug.Print "SENT: DONT FLOWCONTROL"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
      
    Case LINEMODE
    If TraceTelnet Then Debug.Print "LINEMODE"
    If TraceTelnet Then Debug.Print "SENT: DONT LINEMODE"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
      
    Case STATUS
    If TraceTelnet Then Debug.Print "STATUS"
    If TraceTelnet Then Debug.Print "SENT: DONT STATUS"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
      
    Case TIMING
    If TraceTelnet Then Debug.Print "TIMING"
    If TraceTelnet Then Debug.Print "SENT: DONT TIMING"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
      
    Case DISPLOC
    If TraceTelnet Then Debug.Print "DISPLOC"
    If TraceTelnet Then Debug.Print "SENT: DONT DISPLOC"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
    
    Case ENVIRON
    If TraceTelnet Then Debug.Print "ENVIRON"
    If TraceTelnet Then Debug.Print "SENT: DONT ENVIRON"
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
    
    Case UNKNOWN39
    If TraceTelnet Then Debug.Print "UNKNOWN39"
    If TraceTelnet Then Debug.Print "SENT: DONT " & Asc(CH)
      WinsockClient.SendData Chr$(IAC) & Chr$(DONTTEL) & Chr$(CH)
    
    Case Else
    If TraceTelnet Then Debug.Print "UNKNOWN CMD " & Asc(CH)
    If TraceTelnet Then Debug.Print "SENT: DONT UNKNOWN CMD " & Asc(CH)
      WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
  End Select

End Function

Private Function iac5(CH As Byte) As Integer

Dim ich As Integer
  ' Collect parms after SB and until another IAC

  
    ich = CH
    If ich = IAC Then
      iac5 = GO_IAC1
      Exit Function
    End If
    
    If TraceTelnet Then Debug.Print "                                                                   RECEIVED : ";
    If TraceTelnet Then Debug.Print "SB("; ppno; ") = " & ich
    
    parsedata(ppno) = ich
    ppno = ppno + 1
    
    iac5 = GO_IAC5

End Function


Private Function iac6(CH As Byte) As Integer

  'DONT Processing

 
  iac6 = GO_NORM
        

  Select Case CH
    Case SE
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED SE"
      If TraceTelnet Then Debug.Print "SENT: SE_ACK " & CH

    Case ECHO
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED DONT : ";
      If TraceTelnet Then Debug.Print "ECHO"
      If Not sw_echo Then
        sw_echo = True
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(ECHO)
        If TraceTelnet Then Debug.Print "SENT: WONT ECHO"
      End If
    Case SGA
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED DONT : ";
      If TraceTelnet Then Debug.Print "SGA"
      If Not sw_ugoahead Then
        sw_ugoahead = True
        WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(SGA)
        If TraceTelnet Then Debug.Print "SENT: WONT SGA"
      End If
    
    Case TERMSPEED
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED DONT : ";
      If TraceTelnet Then Debug.Print "TERMSPEED"
      If TraceTelnet Then Debug.Print "SENT: WONT TERMSPEED"
      WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
      
    Case TFLOWCNTRL
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED DONT : ";
      If TraceTelnet Then Debug.Print "TFLOWCNTRL"
      If TraceTelnet Then Debug.Print "SENT: WONT FLOWCONTROL"
      WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
      
    Case LINEMODE
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED DONT : ";
      If TraceTelnet Then Debug.Print "LINEMODE"
      If TraceTelnet Then Debug.Print "SENT: WONT LINEMODE"
      WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
      
    Case STATUS
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED DONT : ";
      If TraceTelnet Then Debug.Print "STATUS"
      If TraceTelnet Then Debug.Print "SENT: WONT STATUS"
      WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
      
    Case TIMING
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED DONT : ";
      If TraceTelnet Then Debug.Print "TIMING"
      If TraceTelnet Then Debug.Print "SENT: WONT TIMING"
      WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
      
    Case DISPLOC
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED DONT : ";
      If TraceTelnet Then Debug.Print "DISPLOC"
      If TraceTelnet Then Debug.Print "SENT: WONT DISPLOC"
      WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
    
    Case ENVIRON
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED DONT : ";
      If TraceTelnet Then Debug.Print "ENVIRON"
      If TraceTelnet Then Debug.Print "SENT: WONT ENVIRON"
      WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
    
    Case UNKNOWN39
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED DONT : ";
      If TraceTelnet Then Debug.Print "UNKNOWN39"
      If TraceTelnet Then Debug.Print "SENT: WONT " & Asc(CH)
      WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
        
    Case Else
      If TraceTelnet Then Debug.Print "                                                                   RECEIVED DONT : ";
      If TraceTelnet Then Debug.Print "UNKNOWN CMD " & Asc(CH)
      If TraceTelnet Then Debug.Print "SENT: WONT UNKNOWN CMD " & Asc(CH)
      WinsockClient.SendData Chr$(IAC) & Chr$(WONTTEL) & Chr$(CH)
  End Select

End Function


Private Sub WinsockClient_Error(ByVal Number As Integer, Description As String, ByVal Scode As Long, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)
        
    frmTelnet.stbStatusBar.Panels(4).Text = Number & " - " & Description
    Operating = False
    Connected = False
End Sub
