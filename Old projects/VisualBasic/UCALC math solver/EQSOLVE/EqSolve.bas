Attribute VB_Name = "EqSolve"
Sub swap(ByRef a As Double, ByRef b As Double)
    temp = a: a = b: b = temp
End Sub

Function Solve() As Double
    Dim ExpressionPtr As Long, VariablePtr As Long
    Dim a As Double, b As Double, Iterations As Long
    Dim fa As Double, fb As Double

    ExpressionPtr = ucParam(1)
    a = ucParam(2)
    b = ucParam(3)
    VariablePtr = ucParam(4)
    
    ucVariableValue(VariablePtr) = a: fa = ucEvaluate(ExpressionPtr)
    ucVariableValue(VariablePtr) = b: fb = ucEvaluate(ExpressionPtr)
    If fb < fa Then swap a, b
    
    Do While Abs(b - a) > 0.000000000000001
        ucVariableValue(VariablePtr) = (a + b) / 2
        If ucEvaluate(ExpressionPtr) < 0 _
           Then a = (a + b) / 2 _
           Else b = (a + b) / 2
        Iterations = Iterations + 1
        If Iterations = 100 Then Exit Do
    Loop
    
    Solve = a
    
    If Abs(ucEvaluate(ExpressionPtr)) > 0.0000000001 Then
        ucError = 1
        ucErrorData(0) = "Solution Not Found"
    End If
End Function

' The following PreParse function allows the equation to use the "=" sign.
' It basically changes the equation by subtracting the other side.  For
' instance, "2x+5 = x+1" is changed to "2x+5 - (x+1)"
Function ChangeEqualSign() As Long
    Dim Equation As String, Equal As Long
    
    Equation = ucParamStr(1)
    Equal = InStr(Equation, "=")
    If Equal Then Equation = Left$(Equation, Equal - 1) + "-(" + Mid$(Equation, Equal + 1) + ")"
    ucParamStr(1) = Equation
End Function

