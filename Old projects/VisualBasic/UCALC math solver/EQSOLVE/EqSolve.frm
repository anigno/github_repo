VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Equation Solver example for UCalc Fast Math Parser 2.0"
   ClientHeight    =   2985
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6480
   LinkTopic       =   "Form1"
   ScaleHeight     =   2985
   ScaleWidth      =   6480
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "Find Answer"
      Height          =   495
      Left            =   1200
      TabIndex        =   2
      Top             =   1560
      Width           =   1215
   End
   Begin VB.ComboBox Combo1 
      Height          =   315
      Left            =   1200
      TabIndex        =   1
      Text            =   "SOLVE(x^2 = 25)"
      Top             =   360
      Width           =   3855
   End
   Begin VB.TextBox Text2 
      Height          =   285
      Left            =   1200
      TabIndex        =   0
      Top             =   960
      Width           =   3855
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Command1_Click()
    Text2 = ucEval(Combo1)
    If ucError Then MsgBox ucErrorMessage
End Sub

Private Sub Form_Load()
    ucDefineFunction "Solve(Expr&, a=-1000, b=1000, var@=x)", AddressOf Solve
    ucPreParse "SOLVE", AddressOf ChangeEqualSign
    ucDefineVariable "pi = 3.14"

    Combo1.AddItem "SOLVE(x^2 = 25)"
    Combo1.AddItem "SOLVE(x^2-3x-10, -50, 0)"
    Combo1.AddItem "Solve(2x-8 = x+6)"
    Combo1.AddItem "Solve(COS(x) = 0, pi, 2pi)"
    Combo1.AddItem "10*Solve(3y-54 = 6,,,y)"
    Combo1.AddItem "3+Solve(x^2 = Solve(x/2 = 128)) "
End Sub
