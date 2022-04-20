{ -------------------------------------------------------------------------}
{ ucalc.pas : Unit include file                                            }
{ Designed to work with Delphi 4.0 or above.                               }
{                                                                          }
{ UCalc Fast Math Parser 2.0                                               }
{ Copyright (c) 1998-1999 by Daniel Corbier.  All rights reserved.         }
{ http://www.ucalc.com/mathparser                                          }
{ -------------------------------------------------------------------------}

unit ucalc;

interface

const
  ucMaxParamPerFunction = 32;

var
  ucParamCount: Longint;
  ucSetError: Longint;
  ucParam: array[0..ucMaxParamPerFunction] of Extended;
  ucErrMsg: string;

function ucDefineVariableTmp(VariableDef: AnsiString): Longint; stdcall;
function ucEval(Expression: AnsiString): Extended; stdcall;
function ucEvalStr(Expression: AnsiString): PChar; stdcall;
function ucEvaluate(ExpressionPtr: Longint): Extended; stdcall;
function ucEvaluateStr(ExpressionPtr: Longint): PChar; stdcall;
function ucGetError: Longint; stdcall;
function ucGetErrorData(errIndex: Longint): PChar; stdcall;
function ucGetParamStr(ParamIndex: Longint): PChar; stdcall;
function ucGetTrigMode: Longint; stdcall;
function ucGetVariableValue(VariablePtr: Longint): Extended; stdcall;
function ucGetVariableValueStr(VariablePtr: Longint): PChar; stdcall;
function ucIsString(Expression: AnsiString): Longint; stdcall;
function ucParse(Expression: AnsiString): Longint; stdcall;
procedure ucAlias(AssignFrom, AssignTo: AnsiString); stdcall;
procedure ucDefineFunctionTmp(FunctionDef: AnsiString; FunctionAddress: Longword); stdcall;
procedure ucGetParamAddress(var ArrayAddress: Extended; var ArrayCount: Longint; ParamMax: Longint; var SetError: Longint); stdcall;
procedure ucLicense(SerialNumber: AnsiString); stdcall;
procedure ucPreParse(Expression: AnsiString; FunctionAddress: Longword); stdcall;
procedure ucReleaseExprTmp(Num: Longint); stdcall;
procedure ucReleaseVariable(VariablePtr: Longint); stdcall;
procedure ucResetTmp(InitString: AnsiString); stdcall;
procedure ucSetErrorData(errIndex: Longint; vValue: AnsiString); stdcall;
procedure ucSetParamStr(ParamIndex: Longint; Argument: AnsiString); stdcall;
procedure ucSetTrigMode(ModeNumber: Longint); stdcall;
procedure ucSetVariableValue(VariablePtr: Longint; vValue: Extended); stdcall;
procedure ucSetVariableValueStr(VariablePtr: Longint; vValue: AnsiString); stdcall;

{ Derived functions / procedures }
function ucDefineVariable(VariableDef: string; StringDef: string = ''): Longint;
function ucError: Longint;
function ucErrorData(errIndex: Longint = 0): PChar;
function ucErrorMessage(ErrorNumber: Longint = -1): PChar;
function ucParamStr(ParamIndex: Longint = 0): PChar;
procedure ucDefineFunction(FunctionDef: string; FunctionAddress: Longword = 0);
procedure ucReset(InitString: string = '');
procedure ucReleaseExpr(Num: Longint = 1);

implementation

function ucEval; external 'ucalc32.dll';
function ucEvalStr; external 'ucalc32.dll' name 'ucEvalStrPtr';
function ucEvaluate; external 'ucalc32.dll';
function ucEvaluateStr; external 'ucalc32.dll' name 'ucEvaluateStrPtr';
function ucDefineVariableTmp; external 'ucalc32.dll' name 'ucDefineVariable';
function ucGetError; external 'ucalc32.dll';
function ucGetErrorData; external 'ucalc32.dll' name 'ucGetErrorDataPtr';
function ucGetTrigMode; external 'ucalc32.dll';
function ucGetVariableValue; external 'ucalc32.dll';
function ucGetVariableValueStr; external 'ucalc32.dll' name 'ucGetVariableValueStrPtr';
function ucGetParamStr; external 'ucalc32.dll' name 'ucGetParamStrPtr';
function ucIsString; external 'ucalc32.dll';
function ucParse; external 'ucalc32.dll';
procedure ucAlias; external 'ucalc32.dll';
procedure ucDefineFunctionTmp; external 'ucalc32.dll' name 'ucDefineFunction';
procedure ucGetParamAddress; external 'ucalc32.dll';
procedure ucLicense; external 'ucalc32.dll';
procedure ucPreParse; external 'ucalc32.dll';
procedure ucReleaseExprTmp; external 'ucalc32.dll' name 'ucReleaseExpr';
procedure ucReleaseVariable; external 'ucalc32.dll';
procedure ucResetTmp; external 'ucalc32.dll' name 'ucReset';
procedure ucSetErrorData; external 'ucalc32.dll';
procedure ucSetParamStr; external 'ucalc32.dll';
procedure ucSetTrigMode; external 'ucalc32.dll';
procedure ucSetVariableValue; external 'ucalc32.dll';
procedure ucSetVariableValueStr; external 'ucalc32.dll';

{ Derived functions / procedures }
procedure ucDefineFunction(FunctionDef: string; FunctionAddress: Longword = 0);
begin
  ucDefineFunctionTmp(FunctionDef, FunctionAddress);
end;

procedure ucReset(InitString: string = '');
begin
  ucResetTmp(InitString);
end;

procedure ucReleaseExpr(Num: Longint = 1);
begin
  ucReleaseExprTmp(Num);
end;

function ucDefineVariable(VariableDef: string; StringDef: string = ''): Longint;
var
  TmpString: string;
begin
  TmpString := VariableDef;
  if StringDef <> '' then TmpString := TmpString + '$=' + StringDef;
  ucDefineVariable := ucDefineVariableTmp(TmpString);
end;

function ucError: Longint;
begin
  ucError := ucGetError;
end;

function ucParamStr(ParamIndex: Longint = 0): PChar;
begin
  ucParamStr := ucGetParamStr(ParamIndex);
end;

function ucErrorData(errIndex: Longint = 0): PChar;
begin
  ucErrorData := ucGetErrorData(errIndex);
end;

function ucErrorMessage(ErrorNumber: Longint = -1): PChar;
var
  ucErr: Longint;
begin
  ucErr := ErrorNumber;
  if ucErr = -1 then ucErr := ucGetError;

  case ucErr of
    1: ucErrMsg := ucErrorData(0);
    2: ucErrMsg := 'Mismatched parenthesis';
    3: ucErrMsg := 'Undefined variable: ' + ucErrorData(0);
    4: ucErrMsg := 'Invalid binary number';
    5: ucErrMsg := 'Invalid octal number';
    6: ucErrMsg := 'Invalid hexadecimal number';
    7: ucErrMsg := 'Factorial overflow';
    8: ucErrMsg := 'Mismatched quotes';
    9: ucErrMsg := 'Invalid expression';    
    10: ucErrMsg := 'Definition space is full';
    11: ucErrMsg := 'Undefined function: ' + ucErrorData(0);
    12: ucErrMsg := 'Invalid number of function arguments for ' + ucErrorData(0);
    13: ucErrMsg := 'Incorrect argument type for ' + ucErrorData(0);
    14: ucErrMsg := 'Division by 0';
    15: ucErrMsg := 'Integer division by 0 (with \ or DIV)';
    16: ucErrMsg := 'Invalid exponent value';
    17: ucErrMsg := 'Invalid value for SQR';
    18: ucErrMsg := 'Invalid value for LOG2';
    19: ucErrMsg := 'Invalid value for LOG10';
    20: ucErrMsg := 'Invalid value for LOG or LN';
    21: ucErrMsg := 'Invalid value for ASIN';
    22: ucErrMsg := 'Invalid value for ACOS';
    23: ucErrMsg := 'Invalid value for SEC';
    24: ucErrMsg := 'Invalid value for CSC';
    25: ucErrMsg := 'Invalid value for COT';
    26: ucErrMsg := 'Invalid value for COTH';
    27: ucErrMsg := 'Invalid value for CSCH';
    28: ucErrMsg := 'Invalid value for ACOSH';
    29: ucErrMsg := 'Invalid value for ATANH';
    30: ucErrMsg := 'Invalid value for ACOTH';
    31: ucErrMsg := 'Invalid value for ASECH';
    32: ucErrMsg := 'Invalid value for ACSCH';
    { Case 33-500 reserved for future use by UCalc }
    { Use Case 501 and beyond for user defined errors }
  end;
  ucErrorMessage := PChar(ucErrMsg);
end;

initialization
  ucGetParamAddress(ucParam[0], ucParamCount, ucMaxParamPerFunction, ucSetError);
end.