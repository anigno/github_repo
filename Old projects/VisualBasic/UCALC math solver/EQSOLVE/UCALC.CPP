// ucalc.cpp : Implementation file
// Designed to work with 32-bit MS Visual C++ and Borland C++ Builder.
//
// UCalc Fast Math Parser 2.0
// Copyright (c) 1998-1999 by Daniel Corbier.  All rights reserved.
// http://www.ucalc.com/mathparser

#include <wtypes.h>
#include "ucalc.h"

// FastMath Construction
FastMath::FastMath()
{
#ifdef _WIN32
   hDLL = LoadLibrary("ucalc32.dll");
#else
   hDLL = LoadLibrary("ucalc16.dll");
#endif

   ucAlias = (UCALIAS)GetProcAddress(hDLL,"ucAlias");
   ucDefineVariableTmp = (UCDEFINEVARIABLETMP)GetProcAddress(hDLL,"ucDefineVariable");
   ucEval = (UCEVAL)GetProcAddress(hDLL,"ucEval");
   ucEvalStr = (UCEVALSTR)GetProcAddress(hDLL,"ucEvalStrPtr");
   ucEvaluate = (UCEVALUATE)GetProcAddress(hDLL,"ucEvaluate");
   ucEvaluateStr = (UCEVALUATESTR)GetProcAddress(hDLL,"ucEvaluateStrPtr");
   ucGetTrigMode = (UCGETTRIGMODE)GetProcAddress(hDLL,"ucGetTrigMode");
   ucSetTrigMode = (UCSETTRIGMODE)GetProcAddress(hDLL,"ucSetTrigMode");
   ucGetError = (UCGETERROR)GetProcAddress(hDLL,"ucGetError");
   ucGetErrorData = (UCGETERRORDATA)GetProcAddress(hDLL,"ucGetErrorDataPtr");
   ucSetErrorData = (UCSETERRORDATA)GetProcAddress(hDLL,"ucSetErrorData");
   ucGetParamStr = (UCGETPARAMSTR)GetProcAddress(hDLL,"ucGetParamStrPtr");
   ucSetParamStr = (UCSETPARAMSTR)GetProcAddress(hDLL,"ucSetParamStr");
   ucGetVariableValue = (UCGETVARIABLEVALUE)GetProcAddress(hDLL,"ucGetVariableValue");
   ucGetVariableValueStr = (UCGETVARIABLEVALUESTR)GetProcAddress(hDLL,"ucGetVariableValueStrPtr");
   ucSetVariableValueStr = (UCSETVARIABLEVALUESTR)GetProcAddress(hDLL,"ucSetVariableValueStr");
   ucIsString = (UCISSTRING)GetProcAddress(hDLL,"ucIsString");
   ucParse = (UCPARSE)GetProcAddress(hDLL, "ucParse");
   ucPreParse = (UCPREPARSE)GetProcAddress(hDLL,"ucPreParse");
   ucReleaseExprTmp = (UCRELEASEEXPRTMP)GetProcAddress(hDLL,"ucReleaseExpr");
   ucReleaseVariable = (UCRELEASEVARIABLE)GetProcAddress(hDLL,"ucReleaseVariable");
   ucResetTmp = (UCRESETTMP)GetProcAddress(hDLL,"ucReset");
   ucLicense = (UCLICENSE)GetProcAddress(hDLL,"ucLicense");

#if defined(__BORLANDC__) || !defined(_WIN32)
// For C++ compilers which support long double (80 bit precision).
// This includes Borland C++ Builder, and 16-bit versions of MS C++.

   ucDefineFunctionTmp = (UCDEFINEFUNCTIONTMP)GetProcAddress(hDLL,"ucDefineFunction");
   ucGetParamAddress = (UCGETPARAMADDRESS)GetProcAddress(hDLL,"ucGetParamAddress");
   ucSetVariableValue = (UCSETVARIABLEVALUE)GetProcAddress(hDLL,"ucSetVariableValue");

#else
// For MS Visual C++ 6.0 and other compilers which do not support 80 bit
// precision.  Microsoft's "long double" is really the same as "double".

   ucDefineFunctionTmp = (UCDEFINEFUNCTIONTMP)GetProcAddress(hDLL,"ucDefineFunctionDbl");
   ucGetParamAddress = (UCGETPARAMADDRESS)GetProcAddress(hDLL,"ucGetParamAddressDbl");
   ucSetVariableValue = (UCSETVARIABLEVALUE)GetProcAddress(hDLL,"ucSetVariableValueDbl");
#endif

   ucGetParamAddress(ucParam[0],ucParamCount,ucMaxParamPerFunction,ucSetError);
}

// FastMath Deconstruction
FastMath::~FastMath()
{
   FreeLibrary(hDLL);
}

long ucError(void)
{
	return ucGetError();    
}

// Functions with optional parameters

long ucDefineVariable(char* VariableDef,char* StringDef = NULL)
{
    static char TmpString[128] = "";

    strcpy(TmpString,VariableDef);
    if(StringDef != NULL)
    {
       strcat(TmpString,"$=");
       strcat(TmpString,StringDef);
    }
    return ucDefineVariableTmp(TmpString);
}

void ucReleaseExpr(long Num = 1)
{
    ucReleaseExprTmp(Num);
}

void ucDefineFunction(char* FunctionDef,long FunctionAddress = 0)
{
    ucDefineFunctionTmp(FunctionDef,FunctionAddress);
}

void ucReset(char* InitString = "")
{
    ucResetTmp(InitString);
}

char* ucParamStr(long ParamIndex = 0)
{
    return ucGetParamStr(ParamIndex);
}

char* ucErrorData(long errIndex = 0)
{
    return ucGetErrorData(errIndex);
}

char* ucErrorMessage(long ErrorNumber = -1)
{
    long ucErr;
    static char ErrMsg[128] = "";

    if(ErrorNumber == -1)
        ucErr = ucError();
    else
        ucErr = ErrorNumber;

    switch(ucErr)
    {
        case 1:
            strcpy(ErrMsg,ucErrorData(0));
            break;
        case 2:
            strcpy(ErrMsg,"Mismatched parenthesis");
            break;
        case 3:
            strcpy(ErrMsg,"Undefined variable: ");
            strcat(ErrMsg, ucErrorData(0));
            break;
        case 4:
            strcpy(ErrMsg,"Invalid binary number");
            break;
        case 5:
            strcpy(ErrMsg,"Invalid octal number");
            break;
        case 6:
            strcpy(ErrMsg,"Invalid hexadecimal number");
            break;
        case 7:
            strcpy(ErrMsg,"Factorial overflow");
            break;
        case 8:
            strcpy(ErrMsg,"Mismatched quotes");
            break;			
        case 9:
            strcpy(ErrMsg,"Invalid expression");
            break;
        case 10:
            strcpy(ErrMsg,"Definition space is full");
            break;
        case 11:
            strcpy(ErrMsg,"Undefined function: ");
            strcat(ErrMsg,ucErrorData(0));
            break;
        case 12:
            strcpy(ErrMsg,"Invalid number of function arguments for ");
            strcat(ErrMsg,ucErrorData(0));
            break;
        case 13:
            strcpy(ErrMsg,"Incorrect argument type for ");
            strcat(ErrMsg,ucErrorData(0));
            break;
        case 14:
            strcpy(ErrMsg,"Division by 0");
            break;
        case 15:
            strcpy(ErrMsg,"Integer division by 0 (with \\ or DIV)");
            break;
        case 16:
            strcpy(ErrMsg,"Invalid exponent value");
            break;
        case 17:
            strcpy(ErrMsg,"Invalid value for SQR");
            break;
        case 18:
            strcpy(ErrMsg,"Invalid value for LOG2");
            break;
        case 19:
            strcpy(ErrMsg,"Invalid value for LOG10");
            break;
        case 20:
            strcpy(ErrMsg,"Invalid value for LOG or LN");
            break;
        case 21:
            strcpy(ErrMsg,"Invalid value for ASIN");
            break;
        case 22:
            strcpy(ErrMsg,"Invalid value for ACOS");
            break;
        case 23:
            strcpy(ErrMsg,"Invalid value for SEC");
            break;
        case 24:
            strcpy(ErrMsg,"Invalid value for CSC");
            break;
        case 25:
            strcpy(ErrMsg,"Invalid value for COT");
            break;
        case 26:
            strcpy(ErrMsg,"Invalid value for COTH");
            break;
        case 27:
            strcpy(ErrMsg,"Invalid value for CSCH");
            break;
        case 28:
            strcpy(ErrMsg,"Invalid value for ACOSH");
            break;
        case 29:
            strcpy(ErrMsg,"Invalid value for ATANH");
            break;
        case 30:
            strcpy(ErrMsg,"Invalid value for ACOTH");
            break;
        case 31:
            strcpy(ErrMsg,"Invalid value for ASECH");
            break;
        case 32:
            strcpy(ErrMsg,"Invalid value for ACSCH");
            break;
        // case 33-500 reserved for future use by UCalc
        // Use case 501 and beyond for user defined errors
    }

    return ErrMsg;
}
