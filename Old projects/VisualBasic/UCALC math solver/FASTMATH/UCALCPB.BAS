' -------------------------------------------------------------------------
' ucalcpb.bas : Include file
' Designed to work with 32-bit versions of PowerBASIC DLL and PB/CC.
'
' UCalc Fast Math Parser 2.0
' Copyright (c) 1998-1999 by Daniel Corbier.  All rights reserved.
' http://www.ucalc.com/mathparser
' -------------------------------------------------------------------------

Declare Sub ucAlias Lib "ucalc32.dll" Alias "ucAlias" (ByVal AssignFrom$, ByVal AssignTo$)
Declare Sub ucDefineFunctionTmp Lib "ucalc32.dll" Alias "ucDefineFunction" (ByVal FunctionDef$, ByVal FunctionAddress As DWORD)
Declare Sub ucGetParamAddress Lib "ucalc32.dll" Alias "ucGetParamAddress" (ArrayAddress As Ext, ArrayCount As Long, ByVal ParamMax As Long, SetError As Long)
Declare Sub ucLicense Lib "ucalc32.dll" Alias "ucLicense" (ByVal SerialNumber$)
Declare Sub ucPreParseTmp Lib "ucalc32.dll" Alias "ucPreParse" (ByVal Expression$, ByVal FunctionAddress As DWORD)
Declare Sub ucReleaseExpr Lib "ucalc32.dll" Alias "ucReleaseExpr" (ByVal Num As Long)
Declare Sub ucReleaseVariable Lib "ucalc32.dll" Alias "ucReleaseVariable" (ByVal VariablePtr As Long)
Declare Sub ucReset Lib "ucalc32.dll" Alias "ucReset" (ByVal InitString$)
Declare Sub ucSetErrorData Lib "ucalc32.dll" Alias "ucSetErrorData" (ByVal errIndex As Long, ByVal vValue$)
Declare Sub ucSetParamStr Lib "ucalc32.dll" Alias "ucSetParamStr" (ByVal ParamIndex As Long, ByVal Argument$)
Declare Sub ucSetTrigMode Lib "ucalc32.dll" Alias "ucSetTrigMode" (ByVal ModeNumber As Long)
Declare Sub ucSetVariableValue Lib "ucalc32.dll" Alias "ucSetVariableValue" (ByVal VariablePtr As Long, ByVal vValue As Ext)
Declare Sub ucSetVariableValueStr Lib "ucalc32.dll" Alias "ucSetVariableValueStr" (ByVal VariablePtr As Long, ByVal vValue$)
Declare Function ucDefineVariableTmp Lib "ucalc32.dll" Alias "ucDefineVariable" (ByVal VariableDef$) As Long
Declare Function ucEval Lib "ucalc32.dll" Alias "ucEval" (ByVal Expression$) As Ext
Declare Function ucEvalStr Lib "ucalc32.dll" Alias "ucEvalStr" (ByVal Expression$) As String
Declare Function ucEvaluate Lib "ucalc32.dll" Alias "ucEvaluate" (ByVal ExpressionPtr As Long) As Ext
Declare Function ucEvaluateStr Lib "ucalc32.dll" Alias "ucEvaluateStr" (ByVal ExpressionPtr As Long) As String
Declare Function ucGetError Lib "ucalc32.dll" Alias "ucGetError" () As Long
Declare Function ucGetErrorData Lib "ucalc32.dll" Alias "ucGetErrorData" (ByVal errIndex As Long) As String
Declare Function ucGetParamStr Lib "ucalc32.dll" Alias "ucGetParamStr" (ByVal ParamIndex As Long) As String
Declare Function ucGetTrigMode Lib "ucalc32.dll" Alias "ucGetTrigMode" () As Long
Declare Function ucGetVariableValue Lib "ucalc32.dll" Alias "ucGetVariableValue" (ByVal VariablePtr As Long) As Ext
Declare Function ucGetVariableValueStr Lib "ucalc32.dll" Alias "ucGetVariableValueStr" (ByVal VariablePtr As Long) As String
Declare Function ucIsString Lib "ucalc32.dll" Alias "ucIsString" (ByVal Expression$) As Long
Declare Function ucParse Lib "ucalc32.dll" Alias "ucParse" (ByVal Expression$) As Long
Declare Function ucVariableValueAddress Lib "ucalc32.dll" Alias "ucVariableValueAddress" (VariablePtr As Long) as DWORD

%ucMaxParamPerFunction = 32
' Compile Error: If you get an error on the line above, then
' you may have mistakenly loaded "UCALCPB.BAS" (for PowerBASIC)
' instead of UCALCVB.BAS (for Visual Basic).

Global ucParamCount As Long, ucSetError As Long
Global ucParam() As Ext, ucVariableValue() As Ext

Sub ucDefineFunction(ByVal FunctionDef$, ByVal FunctionAddress As DWORD)
    Static AddressAlreadySet As Long

    If AddressAlreadySet = 0 then
	Redim ucParam(%ucMaxParamPerFunction) As Ext
    	ucGetParamAddress ucParam(0), ucParamCount, %ucMaxParamPerFunction, ucSetError
	AddressAlreadySet = 1
    End If

    ucDefineFunctionTmp FunctionDef$, FunctionAddress
End Sub

Sub ucPreParse(ByVal Expression$, ByVal FunctionAddress As DWORD)
    Static AddressAlreadySet As Long

    If AddressAlreadySet = 0 then
	Redim ucParam(%ucMaxParamPerFunction) As Ext
    	ucGetParamAddress ucParam(0), ucParamCount, %ucMaxParamPerFunction, ucSetError
	AddressAlreadySet = 1
    End If

    ucPreParseTmp Expression$, FunctionAddress
End Sub

Function ucDefineVariable(ByVal VariableDef$) As Long
     Dim VariablePtr As Long

     VariablePtr = ucDefineVariableTmp(VariableDef$)
     ReDim ucVariableValue(VariablePtr) As Ext At ucVariableValueAddress(0)
     ucDefineVariable = VariablePtr
End Function

Function ucDefineVariableStr(ByVal VariableName$, ByVal VariableValue$) As Long
     ucDefineVariableStr = ucDefineVariableTmp(VariableName$ + "$=" + VariableValue$)
End Function

Function ucError() As Long
    ucError = ucGetError
End Function

Function ucErrorData(ByVal errIndex As Long) As String
    ucErrorData = ucGetErrorData(errIndex)
End Function

Function ucParamStr(ByVal ParamIndex As Long) As String
    ucParamStr = ucGetParamStr(ParamIndex)
End Function

Function ucErrMsg(ByVal ErrorNumber As Long) As String
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
    ucErrMsg = ErrMsg$
End Function

Function ucErrorMessage() As String
    ucErrorMessage = ucErrMsg(-1)
End Function