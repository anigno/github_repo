Attribute VB_Name = "Module1"
Function ucalcAverage() As Double
     Dim x As Long, Total As Double

     For x = 1 To ucParamCount
          Total = Total + ucParam(x)
     Next

     ucalcAverage = Total / ucParamCount
End Function

Function ucalcLen() As Double
    ucalcLen = Len(ucParamStr(1))
End Function

Function ucalcLeft() As Double
    ucParamStr(0) = Left$(ucParamStr(1), ucParam(2))
End Function

Function ucalcInStr() As Double
    ucalcInStr = InStr(ucParam(1), ucParamStr(2), ucParamStr(3))
End Function

Function PreParseInStr() As Long
    If ucParamCount = 2 Then
       String1$ = ucParamStr(1)
       String2$ = ucParamStr(2)
       
       ucParamStr(1) = "1"
       ucParamStr(2) = String1$
       ucParamStr(3) = String2$
    End If
    If ucParamCount < 2 Or ucParamCount > 3 Then
       ucError = 12
       ucErrorData(0) = "InStr"
    End If
End Function

Function ucalcSum() As Double
    Dim ExpressionPtr As Long, VariablePtr As Long, x As Double
    Dim sstep As Double, Start As Double, Finish As Double, Total As Double
    
    ExpressionPtr = ucParam(1)
    Start = ucParam(2)
    Finish = ucParam(3)
    sstep = ucParam(4)
    VariablePtr = ucParam(5)
    
    For x = Start To Finish Step sstep
        ucSetVariableValue VariablePtr, x
        Total = Total + ucEvaluate(ExpressionPtr)
    Next

    ucalcSum = Total
End Function
