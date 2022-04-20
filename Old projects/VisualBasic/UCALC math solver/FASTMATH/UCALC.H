// ucalc.h : Header file
// Designed to work with 32-bit MS Visual C++ and Borland C++ Builder.
//
// UCalc Fast Math Parser 2.0
// Copyright (c) 1998-1999 by Daniel Corbier.  All rights reserved.
// http://www.ucalc.com/mathparser

#ifndef __UCALC__
#define __UCALC__

class FastMath
{
public:
   FastMath();
   ~FastMath();
private:
   HINSTANCE hDLL;
};

FastMath ucalc;

char* ucErrorData(long);
char* ucErrorMessage(long);
char* ucParamStr(long);
long ucDefineVariable(char*,char*);
long ucError(void);
void ucDefineFunction(char*,long);
void ucReleaseExpr(long);
void ucReset(char*);

const long ucMaxParamPerFunction = 32;
long ucParamCount;
long ucSetError;

typedef char* (CALLBACK* UCEVALSTR)(const char*);
typedef char* (CALLBACK* UCEVALUATESTR)(long);
typedef char* (CALLBACK* UCGETERRORDATA)(long);
typedef char* (CALLBACK* UCGETPARAMSTR)(long);
typedef char* (CALLBACK* UCGETVARIABLEVALUESTR)(long);
typedef long (CALLBACK* UCDEFINEVARIABLETMP)(const char*);
typedef long (CALLBACK* UCGETERROR)(void);
typedef long (CALLBACK* UCGETTRIGMODE)(void);
typedef long (CALLBACK* UCISSTRING)(const char*);
typedef long (CALLBACK* UCPARSE)(const char*);
typedef void (CALLBACK* UCALIAS)(const char*,const char*);
typedef void (CALLBACK* UCDEFINEFUNCTIONTMP)(const char*,long);
typedef void (CALLBACK* UCPREPARSE)(const char*,unsigned long);
typedef void (CALLBACK* UCRELEASEEXPRTMP)(long);
typedef void (CALLBACK* UCRELEASEVARIABLE)(long);
typedef void (CALLBACK* UCRESETTMP)(const char*);
typedef void (CALLBACK* UCSETERRORDATA)(long,const char*);
typedef void (CALLBACK* UCLICENSE)(const char*);
typedef void (CALLBACK* UCSETPARAMSTR)(long,const char*);
typedef void (CALLBACK* UCSETTRIGMODE)(long);
typedef void (CALLBACK* UCSETVARIABLEVALUESTR)(long,const char*);

#if defined(__BORLANDC__) || !defined(_WIN32)
// For C++ compilers which support long double (80-bit precision).
// This includes Borland C++ Builder, and 16-bit versions of MS C++.

long double ucParam[ucMaxParamPerFunction];

typedef long double (CALLBACK* UCEVAL)(const char*);
typedef long double (CALLBACK* UCEVALUATE)(long);
typedef long double (CALLBACK* UCGETVARIABLEVALUE)(long);
typedef void (CALLBACK* UCGETPARAMADDRESS)(long double&,long&,long,long&);
typedef void (CALLBACK* UCSETVARIABLEVALUE)(long,long double);

#else
// For MS Visual C++ 6.0 and other compilers which do not support 80 bit
// precision.  Microsoft's "long double" is really the same as "double".

double ucParam[ucMaxParamPerFunction];

typedef double (CALLBACK* UCEVAL)(const char*);
typedef double (CALLBACK* UCEVALUATE)(long);
typedef double (CALLBACK* UCGETVARIABLEVALUE)(long);
typedef void (CALLBACK* UCGETPARAMADDRESS)(double&,long&,long,long&);
typedef void (CALLBACK* UCSETVARIABLEVALUE)(long,double);

#endif /* 80-bit precision */

UCALIAS ucAlias;
UCDEFINEFUNCTIONTMP ucDefineFunctionTmp;
UCDEFINEVARIABLETMP ucDefineVariableTmp;
UCEVAL ucEval;
UCEVALSTR ucEvalStr;
UCEVALUATE ucEvaluate;
UCEVALUATESTR ucEvaluateStr;
UCGETERROR ucGetError;
UCGETERRORDATA ucGetErrorData;
UCGETPARAMADDRESS ucGetParamAddress;
UCGETPARAMSTR ucGetParamStr;
UCGETTRIGMODE ucGetTrigMode;
UCGETVARIABLEVALUE ucGetVariableValue;
UCGETVARIABLEVALUESTR ucGetVariableValueStr;
UCISSTRING ucIsString;
UCPARSE ucParse;
UCPREPARSE ucPreParse;
UCRELEASEEXPRTMP ucReleaseExprTmp;
UCRELEASEVARIABLE ucReleaseVariable;
UCRESETTMP ucResetTmp;
UCSETERRORDATA ucSetErrorData;
UCLICENSE ucLicense;
UCSETPARAMSTR ucSetParamStr;
UCSETTRIGMODE ucSetTrigMode;
UCSETVARIABLEVALUE ucSetVariableValue;
UCSETVARIABLEVALUESTR ucSetVariableValueStr;

#endif /* __UCALC__ */