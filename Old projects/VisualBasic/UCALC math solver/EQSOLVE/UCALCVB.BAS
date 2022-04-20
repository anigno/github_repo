Attribute VB_Name = "FastMath"
' -------------------------------------------------------------------------
' ucalcvb.bas : Module file
' Designed to work with Visual Basic 5.0 or above.
'
' UCalc Fast Math Parser 2.0
' Copyright (c) 1998-1999 by Daniel Corbier.  All rights reserved.
' http://www.ucalc.com/mathparser
' -------------------------------------------------------------------------

Declare Sub ucAlias Lib "ucalc32.dll" (ByVal AssignFrom$, ByVal AssignTo$)
Declare Sub ucDefineFunctionDbl Lib "ucalc32.dll" (ByVal FunctionDef$, ByVal FunctionAddress As Long)
Declare Sub ucGetParamAddressDbl Lib "ucalc32.dll" (ByRef ArrayAddress As Double, ByRef ArrayCount As Long, ByVal MaxParams As Long, ByRef SetError As Long)
Declare Sub ucLicenseTmp Lib "ucalc32.dll" Alias "ucLicense" (ByVal SerialNumber$)
Declare Sub ucPreParseTmp Lib "ucalc32.dll" Alias "ucPreParse" (ByVal Expression$, ByVal FunctionAddress As Long)
Declare Sub ucReleaseExprTmp Lib "ucalc32.dll" Alias "ucReleaseExpr" (ByVal Num As Long)
Declare Sub ucReleaseVariable Lib "ucalc32.dll" (ByVal VariablePtr As Long)
Declare Sub ucResetTmp Lib "ucalc32.dll" Alias "ucReset" (ByVal InitString$)
Declare Sub ucSetErrorData Lib "ucalc32.dll" (ByVal errIndex As Long, ByVal vValue As String)
Declare Sub ucSetParamStr Lib "ucalc32.dll" (ByVal ParamIndex As Long, ByVal Argument$)
Declare Sub ucSetTrigMode Lib "ucalc32.dll" (ByVal ModeNumber As Long)
Declare Sub ucSetVariableValue Lib "ucalc32.dll" Alias "ucSetVariableValueDbl" (ByVal VariablePtr As Long, ByVal vValue As Double)
Declare Sub ucSetVariableValueStr Lib "ucalc32.dll" (ByVal VariablePtr As Long, ByVal vValue As String)
Declare Function ucDefineVariableTmp Lib "ucalc32.dll" Alias "ucDefineVariable" (ByVal VariableDef$) As Long
Declare Function ucEval Lib "ucalc32.dll" (ByVal Expression$) As Double
Declare Function ucEvalStr Lib "ucalc32.dll" (ByVal Expression$) As String
Declare Function ucEvaluate Lib "ucalc32.dll" (ByVal ExpressionPtr As Long) As Double
Declare Function ucEvaluateStr Lib "ucalc32.dll" (ByVal ExpressionPtr As Long) As String
Declare Function ucGetError Lib "ucalc32.dll" () As Long
Declare Function ucGetErrorData Lib "ucalc32.dll" (ByVal errIndex As Long) As String
Declare Function ucGetParamStr Lib "ucalc32.dll" (ByVal ParamIndex As Long) As String
Declare Function ucGetTrigMode Lib "ucalc32.dll" () As Long
Declare Function ucGetVariableValue Lib "ucalc32.dll" (ByVal VariablePtr As Long) As Double
Declare Function ucGetVariableValueStr Lib "ucalc32.dll" (ByVal VariablePtr As Long) As String
Declare Function ucIsString Lib "ucalc32.dll" (ByVal Expression$) As Long
Declare Function ucParse Lib "ucalc32.dll" (ByVal Expression$) As Long

Public Const ucMaxParamPerFunction As Long = 32
Public ucParamCount As Long, ucSetError As Long
Public ucParam(ucMaxParamPerFunction) As Double

Property Get ucError() As Long
    ucError = ucGetError
End Property

Property Let ucError(ByVal SetError As Long)
    ucSetError = SetError
End Property

Property Get ucErrorData(ByVal errIndex As Long) As String
    ucErrorData = ucGetErrorData(errIndex)
End Property

Property Let ucErrorData(ByVal errIndex As Long, vValue As String)
    ucSetErrorData errIndex, vValue
End Property

Property Let ucLicense(SerialNumber$)
    ucLicenseTmp SerialNumber$
End Property

Property Get ucParamStr(Optional ByVal ParamIndex As Long = 0) As String
    ucParamStr = ucGetParamStr(ParamIndex)
End Property

Property Let ucParamStr(ByVal ParamIndex As Long, Argument As String)
    ucSetParamStr ParamIndex, Argument
End Property

Property Get ucTrigMode() As Long
    ucTrigMode = ucGetTrigMode
End Property

Property Let ucTrigMode(ByVal ModeNumber As Long)
    ucSetTrigMode ModeNumber
End Property

Property Get ucVariableValue(ByVal VariablePtr As Long) As Double
    ucVariableValue = ucGetVariableValue(VariablePtr)
End Property

Property Let ucVariableValue(ByVal VariablePtr As Long, ByVal vValue As Double)
    ucSetVariableValue VariablePtr, vValue
End Property

Property Get ucVariableValueStr(ByVal VariablePtr As Long) As String
    ucVariableValueStr = ucGetVariableValueStr(VariablePtr)
End Property

Property Let ucVariableValueStr(ByVal VariablePtr As Long, vValue As String)
    ucSetVariableValueStr VariablePtr, vValue
End Property

Sub ucDefineFunction(FunctionDef$, Optional ByVal FunctionAddress As Long)
    ucLicense = "387715451073568104795717"
    ucGetParamAddressDbl ucParam(0), ucParamCount, ucMaxParamPerFunction, ucSetError
    ucDefineFunctionDbl FunctionDef$, FunctionAddress
End Sub

Sub ucPreParse(ByVal Expression$, ByVal FunctionAddress As Long)
    ucGetParamAddressDbl ucParam(0), ucParamCount, ucMaxParamPerFunction, ucSetError
    ucPreParseTmp Expression$, FunctionAddress
End Sub

Sub ucReleaseExpr(Optional ByVal Num As Long = 1)
    ucReleaseExprTmp Num
End Sub

Sub ucReset(Optional InitString$)
    ucResetTmp InitString$
End Sub

Function ucDefineVariable(VariableDef$, Optional StringDef$ = "")
    TmpString$ = VariableDef$
    If StringDef$ <> "" Then TmpString$ = TmpString$ + "$=" + StringDef$
    ucDefineVariable = ucDefineVariableTmp(TmpString$)
End Function

Function ucErrorMessage(Optional ByVal ErrorNumber As Long = -1) As String
    Dim ucErr As Long

    ucErr = ErrorNumber
    If ucErr = -1 Then ucErr = ucError
    Select Case ucErr
        Case 1: ErrMsg$ = ucErrorData(0)
        Case 2: ErrMsg$ = "Mismatched parenthesis"
        Case 3: ErrMsg$ = "Undefined variable: " + ucErrorData(0)
        Case 4: ErrMsg$ = "Invalid binary number"
        Case 5: ErrMsg$ = "Invalid octal number"
        Case 6: ErrMsg$ = "Invalid hexadecimal number"
        Case 7: ErrMsg$ = "Factorial overflow"
        Case 8: ErrMsg$ = "Mismatched quotes"
        Case 9: ErrMsg$ = "Invalid expression"
        Case 10: ErrMsg$ = "Definition space is full"
        Case 11: ErrMsg$ = "Undefined function: " + ucErrorData(0)
        Case 12: ErrMsg$ = "Invalid number of function arguments for " + ucErrorData(0)
        Case 13: ErrMsg$ = "Incorrect argument type for " + ucErrorData(0)
        Case 14: ErrMsg$ = "Division by 0"
        Case 15: ErrMsg$ = "Integer division by 0 (with \ or DIV) "
        Case 16: ErrMsg$ = "Invalid exponent value"
        Case 17: ErrMsg$ = "Invalid value for SQR"
        Case 18: ErrMsg$ = "Invalid value for LOG2"
        Case 19: ErrMsg$ = "Invalid value for LOG10"
        Case 20: ErrMsg$ = "Invalid value for LOG or LN"
        Case 21: ErrMsg$ = "Invalid value for ASIN"
        Case 22: ErrMsg$ = "Invalid value for ACOS"
        Case 23: ErrMsg$ = "Invalid value for SEC"
        Case 24: ErrMsg$ = "Invalid value for CSC"
        Case 25: ErrMsg$ = "Invalid value for COT"
        Case 26: ErrMsg$ = "Invalid value for COTH"
        Case 27: ErrMsg$ = "Invalid value for CSCH"
        Case 28: ErrMsg$ = "Invalid value for ACOSH"
        Case 29: ErrMsg$ = "Invalid value for ATANH"
        Case 30: ErrMsg$ = "Invalid value for ACOTH"
        Case 31: ErrMsg$ = "Invalid value for ASECH"
        Case 32: ErrMsg$ = "Invalid value for ACSCH"
        ' Case 33-500 reserved for future use by UCalc
        ' Use Case 501 and beyond for user defined errors
    End Select
    ucErrorMessage = ErrMsg$
End Function
