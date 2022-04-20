' demopb.bas
' UCalc Fast Math Parser demonstration for PowerBASIC/DLL.
' To run this program, compile this file to an EXE first.

$Compile Exe
$Include "ucalcpb.bas"

Function WinMain (ByVal hCurInstance  As Long, _
                  ByVal hPrevInstance As Long, _
                  lpszCmdLine         As Asciiz Ptr, _
                  ByVal nCmdShow      As Long) Export As Long

    Dim VariableX As Long, ExpressionPtr As Long
    Dim x As Ext, Total As Ext, Answer As String
    Dim Example$(11)

    NewLine$ = Chr$(10,13)

    Example$(0) = "3+4/5-8"
    Example$(1) = "5*(((10+3)!-1) MOD 7)^2 + MyVar"
    Example$(2) = "#b1101 OR #b1010"
    Example$(3) = "#hAE.B1 * #b1110.1001"
    Example$(4) = "average(5,2,8)-max(2,5,10,11)"
    Example$(5) = "sum(x^2+5,1,10)"
    Example$(6) = "sum(2y-3,1,10,,y)"
    Example$(7) = "sum(x+10,2,5,.5)"
    Example$(8) = "Len('String Length')"
    Example$(9) = "Left('Hello there', 6) + 'World'"
    Example$(10) = "InStr(5,'This is my string','is')"
    Example$(11) = "InStr(MyString,'is')"

    ucDefineVariable "MyString = 'This is my string' "
    ucDefineVariable "pi = atn(1) * 4"
    ucDefineVariable "MyVar = pi + 10"

    ucDefineFunction "area(length,width) = length*width", 0
    ucDefineFunction "Average()", CodePtr(ucalcAverage)
    ucDefineFunction "Len(text$)", CodePtr(ucalcLen)
    ucDefineFunction "Left$(text$,length)", CodePtr(ucalcLeft)
    ucDefineFunction "InStr(start,text1$,text2$)", CodePtr(ucalcInStr)
    ucDefineFunction "Sum(Expr&,start,finish,step=1,var@=x)", CodePtr(ucalcSum)

    ucPreParse "", CodePtr(MySyntax)
    ucPreParse "InStr", CodePtr(PreParseInStr)

    For x = 0 To 11
        EqPrompt$ = "Enter an expression ("+Str$(x)+" of 11)"
        Expression$ = InputBox$(EqPrompt$,,Example$(x))
        Answer = ucEvalStr(Expression$)

        If ucError Then
              MsgBox Expression$ + NewLine$ + _
                     ucErrorMessage
           Else
              MsgBox "Expression:  "+Expression$ + NewLine$ + _
                     "Answer: " +Answer
        End If
    Next

    EqPrompt$ = "This final example demonstrates ucParse()"+ _
                " and ucEvaluate(), by doing a summation"+ _
                " of the expression from 1 to 10000. See source code."
    Expression$ = InputBox$(EqPrompt$,, "x^2+5x+14")
    VariableX = ucDefineVariable("x")
    ExpressionPtr = ucParse(Expression$)
    ucReleaseExpr 1

    For x = 1 To 10000
        ucVariableValue(VariableX) = x
        Total = Total + ucEvaluate(ExpressionPtr)
    Next
    MsgBox "Total: " + Str$(Total)
End Function

Function ucalcAverage() As Ext
    Dim x As Long, Total As Ext

    For x = 1 To ucParamCount
        Total = Total + ucParam(x)
    Next

    ucalcAverage = Total / ucParamCount
End Function

Function ucalcSum() As Ext
    Dim ExpressionPtr As Long, VariablePtr As Long, x As Ext
    Dim sstep As Ext, Start As Ext, Finish As Ext, Total As Ext

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

Function ucalcLen() As Ext
    ucalcLen = Len(ucParamStr(1))
End Function

Function ucalcLeft() As Double
    ucSetParamStr 0, Left$(ucGetParamStr(1), ucParam(2))
End Function

Function ucalcInStr() As Ext
    ucalcInStr = Instr(ucParam(1), ucParamStr(2), ucParamStr(3))
End Function

Function PreParseInStr() As Long
    If ucParamCount = 2 Then
       arglist$ = ucGetParamStr(0)
       ucSetParamStr 0, "1," + arglist$
    End If
    If ucParamCount < 2 Or ucParamCount > 3 Then
       ucSetError = 12
       ucSetErrorData 0, "InStr"
    End If
End Function

Function MySyntax As Long
     Expression$ = ucParamStr(0)
     If Instr(Expression$, "$") Then
        ucSetError = 1
        ucSetErrorData 0, "The $ character is not allowed"
     End If
End Function

