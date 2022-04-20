VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "UCalc Fast Math Parser 2.0 VB demo   (See source code in DEMOVB.FRM)"
   ClientHeight    =   5280
   ClientLeft      =   60
   ClientTop       =   348
   ClientWidth     =   7788
   LinkTopic       =   "Form1"
   ScaleHeight     =   5280
   ScaleWidth      =   7788
   StartUpPosition =   3  'Windows Default
   Begin VB.ComboBox Combo4 
      Height          =   315
      Left            =   840
      TabIndex        =   35
      Text            =   "MyVariable*area(5,10)+max(5,9,3)"
      Top             =   3720
      Width           =   2775
   End
   Begin VB.ComboBox Combo3 
      Height          =   315
      Left            =   840
      TabIndex        =   34
      Text            =   "area(length,width)=length*width"
      Top             =   3240
      Width           =   2775
   End
   Begin VB.ComboBox Combo2 
      Height          =   315
      Left            =   840
      TabIndex        =   33
      Text            =   "MyVariable = 100"
      Top             =   2760
      Width           =   2775
   End
   Begin VB.ComboBox Combo1 
      Height          =   315
      Left            =   840
      TabIndex        =   32
      Text            =   "3+4/5-8"
      Top             =   480
      Width           =   2775
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Start"
      Height          =   375
      Left            =   3840
      TabIndex        =   30
      Top             =   4440
      Width           =   495
   End
   Begin VB.TextBox Text10 
      Height          =   285
      Left            =   5760
      TabIndex        =   27
      Top             =   4920
      Width           =   1935
   End
   Begin VB.TextBox Text8 
      Height          =   285
      Left            =   5760
      TabIndex        =   26
      Text            =   "x^2+5x-10"
      Top             =   4560
      Width           =   1935
   End
   Begin VB.TextBox Text9 
      Height          =   285
      Left            =   2880
      TabIndex        =   24
      Text            =   "100000"
      Top             =   4920
      Width           =   855
   End
   Begin VB.TextBox Text7 
      Height          =   285
      Left            =   3840
      TabIndex        =   16
      Text            =   "-sin(x)/2"
      Top             =   480
      Width           =   3015
   End
   Begin VB.TextBox Text2 
      Height          =   285
      Left            =   840
      TabIndex        =   15
      Text            =   "(result)"
      Top             =   4200
      Width           =   2775
   End
   Begin VB.CommandButton btnPlot 
      Caption         =   "Plot"
      Height          =   375
      Left            =   6960
      TabIndex        =   9
      Top             =   480
      Width           =   615
   End
   Begin VB.PictureBox Picture1 
      Height          =   1215
      Left            =   3840
      ScaleHeight     =   1164
      ScaleWidth      =   2964
      TabIndex        =   8
      Top             =   840
      Width           =   3015
   End
   Begin VB.CommandButton btnCalc 
      Caption         =   "Calculate"
      Height          =   375
      Left            =   3720
      TabIndex        =   5
      Top             =   3720
      Width           =   1335
   End
   Begin VB.CommandButton btnFunction 
      Caption         =   "Define Function"
      Height          =   375
      Left            =   3720
      TabIndex        =   4
      Top             =   3240
      Width           =   1335
   End
   Begin VB.CommandButton btnVariable 
      Caption         =   "Define Variable"
      Height          =   375
      Left            =   3720
      TabIndex        =   3
      Top             =   2760
      Width           =   1335
   End
   Begin VB.CommandButton btnEval 
      Caption         =   "Calculate"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   1320
      Width           =   1095
   End
   Begin VB.TextBox Text1 
      Height          =   285
      Left            =   840
      TabIndex        =   0
      Text            =   "(result)"
      ToolTipText     =   "Text2 = ucEval(Text1)"
      Top             =   840
      Width           =   2775
   End
   Begin VB.Label Label16 
      Alignment       =   2  'Center
      BackColor       =   &H00FFFFC0&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Speed Test"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.6
         Charset         =   177
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   120
      TabIndex        =   31
      Top             =   4800
      Width           =   1695
   End
   Begin VB.Label Label19 
      Caption         =   "Elapsed (sec) / Answer:"
      Height          =   255
      Left            =   3960
      TabIndex        =   29
      Top             =   4920
      Width           =   1695
   End
   Begin VB.Label Label18 
      Caption         =   "User Expression:"
      Height          =   255
      Left            =   4440
      TabIndex        =   28
      Top             =   4560
      Width           =   1215
   End
   Begin VB.Line Line17 
      BorderWidth     =   2
      X1              =   120
      X2              =   3720
      Y1              =   4680
      Y2              =   4680
   End
   Begin VB.Label Label17 
      Caption         =   "Summation from 1 to:"
      Height          =   375
      Left            =   2040
      TabIndex        =   25
      Top             =   4800
      Width           =   855
   End
   Begin VB.Line Line16 
      BorderWidth     =   2
      X1              =   3720
      X2              =   3720
      Y1              =   4680
      Y2              =   4320
   End
   Begin VB.Line Line14 
      BorderWidth     =   2
      X1              =   3720
      X2              =   7680
      Y1              =   4320
      Y2              =   4320
   End
   Begin VB.Label Label15 
      Caption         =   "Text2:"
      Height          =   255
      Left            =   120
      TabIndex        =   23
      Top             =   4200
      Width           =   495
   End
   Begin VB.Label Label14 
      Caption         =   "Combo4:"
      Height          =   255
      Left            =   120
      TabIndex        =   22
      Top             =   3720
      Width           =   735
   End
   Begin VB.Label Label13 
      Caption         =   "Combo3:"
      Height          =   255
      Left            =   120
      TabIndex        =   21
      Top             =   3240
      Width           =   735
   End
   Begin VB.Label Label12 
      Caption         =   "Combo2:"
      Height          =   255
      Left            =   120
      TabIndex        =   20
      Top             =   2760
      Width           =   615
   End
   Begin VB.Line Line13 
      X1              =   5160
      X2              =   5520
      Y1              =   3960
      Y2              =   3960
   End
   Begin VB.Line Line12 
      X1              =   5520
      X2              =   5400
      Y1              =   3960
      Y2              =   3840
   End
   Begin VB.Line Line11 
      X1              =   5520
      X2              =   5400
      Y1              =   3960
      Y2              =   4080
   End
   Begin VB.Line Line10 
      X1              =   5160
      X2              =   5520
      Y1              =   3480
      Y2              =   3480
   End
   Begin VB.Line Line9 
      X1              =   5520
      X2              =   5400
      Y1              =   3480
      Y2              =   3360
   End
   Begin VB.Line Line8 
      X1              =   5520
      X2              =   5400
      Y1              =   3480
      Y2              =   3600
   End
   Begin VB.Line Line7 
      X1              =   5160
      X2              =   5520
      Y1              =   3000
      Y2              =   3000
   End
   Begin VB.Line Line6 
      X1              =   5520
      X2              =   5400
      Y1              =   3000
      Y2              =   2880
   End
   Begin VB.Line Line5 
      X1              =   5520
      X2              =   5400
      Y1              =   3000
      Y2              =   3120
   End
   Begin VB.Label Label11 
      Caption         =   "Text2 = ucEval(Combo4)"
      Height          =   255
      Left            =   5640
      TabIndex        =   19
      Top             =   3840
      Width           =   1935
   End
   Begin VB.Label Label10 
      Caption         =   "Source Code:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   5880
      TabIndex        =   18
      Top             =   2400
      Width           =   1575
   End
   Begin VB.Label Label3 
      Caption         =   "Source Code:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   1800
      TabIndex        =   17
      Top             =   1440
      Width           =   1095
   End
   Begin VB.Line Line15 
      BorderWidth     =   2
      X1              =   7680
      X2              =   120
      Y1              =   2280
      Y2              =   2280
   End
   Begin VB.Line Line1 
      BorderWidth     =   2
      X1              =   3720
      X2              =   3720
      Y1              =   120
      Y2              =   2280
   End
   Begin VB.Label Label9 
      Caption         =   "ucDefineFunction Combo3"
      Height          =   255
      Left            =   5640
      TabIndex        =   14
      Top             =   3360
      Width           =   1935
   End
   Begin VB.Label Label8 
      Caption         =   "ucDefineVariable Combo2"
      Height          =   255
      Left            =   5640
      TabIndex        =   13
      Top             =   2880
      Width           =   1935
   End
   Begin VB.Label Label7 
      Caption         =   "Text1:"
      Height          =   255
      Left            =   240
      TabIndex        =   12
      Top             =   840
      Width           =   495
   End
   Begin VB.Label Label6 
      Caption         =   "Combo1:"
      Height          =   255
      Left            =   120
      TabIndex        =   11
      Top             =   480
      Width           =   615
   End
   Begin VB.Label Label5 
      Caption         =   "Text1 = ucEvalStr(Combo1)"
      Height          =   255
      Left            =   1320
      TabIndex        =   10
      Top             =   1680
      Width           =   2055
   End
   Begin VB.Label Label4 
      Caption         =   "Example usng ucEvaluate() in a loop"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   3840
      TabIndex        =   7
      Top             =   120
      Width           =   3495
   End
   Begin VB.Label Label2 
      Caption         =   "Examples with user-defined variables and functions"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   840
      TabIndex        =   6
      Top             =   2400
      Width           =   3735
   End
   Begin VB.Label Label1 
      Caption         =   "Example using the one-step ucEvalStr()"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   177
         Weight          =   400
         Underline       =   -1  'True
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   840
      TabIndex        =   1
      Top             =   120
      Width           =   2895
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Sub PopulateComboBoxes()
    Combo1.AddItem "3+4/5-8"
    Combo1.AddItem "5*(((10+3)!-1) MOD 7)^2"
    Combo1.AddItem "#b1101 OR #b1010"
    Combo1.AddItem "#hAE.B1 * #b1110.1001"
    Combo1.AddItem ""
    Combo1.AddItem "'// sum(), average(), InStr()"
    Combo1.AddItem "'// Len() and Left() are"
    Combo1.AddItem "'// defined in the source code."
    Combo1.AddItem "'// See DEMOVB.BAS."
    Combo1.AddItem ""
    Combo1.AddItem "sum(x^2+5,1,10)"
    Combo1.AddItem "sum(2y-3,1,10,,y)"
    Combo1.AddItem "sum(x+10,2,5,.5)"
    Combo1.AddItem "average(5,min(2,5),8)-max(2,5,9,1)"
    Combo1.AddItem "Len('String Length')"
    Combo1.AddItem "Left('Hello there', 6) + 'World'"
    Combo1.AddItem "InStr('This is my string','my')"
    Combo1.AddItem "InStr(10,'This is my string','i')"
    
    Combo2.AddItem "MyVariable = 100"
    Combo2.AddItem "MyString = 'This is my string' "
    
    Combo3.AddItem "area(length,width)=length*width"
    Combo3.AddItem "frac(x)=abs(abs(x)-int(abs(x)))"
    Combo3.AddItem "shl[x,y] = x + 2^y"
    
    Combo4.AddItem "MyVariable*area(5,10)+max(5,9,3)"
    Combo4.AddItem "frac(150/17)"
    Combo4.AddItem "#b01101 shl 1"
    Combo4.AddItem "Len(MyString)"
    Combo4.AddItem "InStr(MyString,'is')"
End Sub

Private Sub Form_Load()
ucLicense = "387715451073568104795717"  'add this line
PopulateComboBoxes
    
    ' The code body for the following functions is
    ' found in the DEMOVB.BAS module file.
    ucDefineFunction "Average()", AddressOf ucalcAverage
    ucDefineFunction "InStr(start,text1$,text2$)", AddressOf ucalcInStr
    ucDefineFunction "Left$(text$,length)", AddressOf ucalcLeft
    ucDefineFunction "Len(text$)", AddressOf ucalcLen
    ucDefineFunction "Sum(Expr&,start,finish,step=1,var@=x)", AddressOf ucalcSum
    
    ucPreParse "InStr", AddressOf PreParseInStr
End Sub

' Demonstrates the use of the one-step ucEvalStr() function.
Private Sub btnEval_Click()
    Text1 = ucEvalStr(Combo1)
    If ucError Then MsgBox ucErrorMessage, vbExclamation
End Sub

' Demonstrates the use of ucEvaluate() in a loop.
' An equation given by the user is plotted.
Private Sub btnPlot_Click()
    Dim x As Double, UserEq As Long, VariableX As Long
    
    Picture1.Cls
    Picture1.Scale (-10, 2)-(10, -2)
    Picture1.PSet (-10, 0)

    VariableX = ucDefineVariable("x")
    
    UserEq = ucParse(Text7)
    
    For x = -10 To 10 Step 0.5
        ucSetVariableValue VariableX, x
        Picture1.Line -(x, ucEvaluate(UserEq))
    Next
    ucReleaseExpr
End Sub

' Defines a function or operator at runtime
Private Sub btnFunction_Click()
    ucDefineFunction Combo3
    If ucError Then MsgBox ucErrorMessage, vbExclamation
End Sub

' Defines a variable at runtime
Private Sub btnVariable_Click()
    ucDefineVariable Combo2
    If ucError Then MsgBox ucErrorMessage, vbExclamation
End Sub

' Example using the one-step ucEval() function.
Private Sub btnCalc_Click()
    Text2 = ucEval(Combo4)
    If ucError Then MsgBox ucErrorMessage, vbExclamation
End Sub

' This example demonstrates the speed of the parser
' by calculating the summation of a user-given expression.
Private Sub Command1_Click()
    Dim x As Double, Finish As Double, UserEq As Long, VariableX As Long
    Dim Sum As Double, TimerStart As Single, Elapsed As Single
    
    Text10 = ""
    Text10.Refresh
    Finish = Text9
    
    TimerStart = Timer
    
    VariableX = ucDefineVariable("x")
    UserEq = ucParse(Text8)
    
    For x = 1 To Finish
        ucSetVariableValue VariableX, x
        Sum = Sum + ucEvaluate(UserEq)
    Next
    
    Elapsed = Timer - TimerStart
    Text10 = Int(Elapsed * 100) / 100 & " / " & Sum
    ucReleaseExpr
End Sub
