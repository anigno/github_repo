#include <afx.h>
#include <limits.h>
#include "Versions.h"

#define PROTECTION_DEFAULT_RESULT -99
#define PROTECTION_SUCCEEDED 0
#define PROTECTION_FAILED_BY_KEY -1
#define PROTECTION_FAILED_BY_KEY_LENGTH -2
#define PROTECTION_FAILED_BY_DATE -3
#define PROTECTION_FAILED_CALCULATION_RESULT -9999

bool isAuthenticated=false;
int falseTriesCounter=0;

///////////////////////////
//Private inner functions//
///////////////////////////

bool AuthenticateByDate()
{
	CTime t=CTime::GetCurrentTime();
	long lTime=t.GetYear()*10000+t.GetMonth()*100+t.GetDay();
	if(lTime>maxYearMonthDay)return false;
	return true;
}

int GetAuthenticationResultKey(char* username,int length)
{
	int resultKey=0;
	for(int a=0;a<length;a++)
	{
		char c=username[a];
		int d=c<<1;
		int e=c^d;
		int f=e*e;
		resultKey=(resultKey+f)%10000;
	}
	if(resultKey<1000)resultKey+=1000;
	return resultKey;
}

////////////////////
//Extern functions//
////////////////////

//Call this function to authenticate, all functions calls by using a global var, 
// after it will be authenticated
// if another call for this function fail to authenticate, all other functions will fail
extern "C" __declspec(dllexport)
int AuthenticateUsername(char* username,int length,int key)
{
	if(AuthenticateByDate()==false)return PROTECTION_FAILED_BY_DATE;
	int result=PROTECTION_DEFAULT_RESULT;
	if(length>4)
	{
		if(AuthenticateByDate())
		{
			int resultKey=GetAuthenticationResultKey(username,length);
			if(key==resultKey)
			{
				falseTriesCounter=0;
				isAuthenticated=true;
				return PROTECTION_SUCCEEDED;
			}
			else
			{
				result=PROTECTION_FAILED_BY_KEY;
			}
		}
		else
		{
			result=PROTECTION_FAILED_BY_DATE;
		}
	}
	else
	{
		result=PROTECTION_FAILED_BY_KEY_LENGTH;
	}
	isAuthenticated=false;
	Sleep(1000*falseTriesCounter++);
	return result;
}


//Special example for authentication with username and key
extern "C" __declspec(dllexport)
float ProtectedFunctionByUsername(char* username,int length,int key,float a,float b)
{
	if(AuthenticateUsername(username,length,key)==PROTECTION_SUCCEEDED)
	{
		return a+b;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

//Example using authentication global var
extern "C" __declspec(dllexport)
float ProtectedFunctionByVar(float a,float b)
{
	if(isAuthenticated)
	{
		return a+b;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}



///////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////Real functions//////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////

extern "C" __declspec(dllexport)
int GetLicensedDate()
{
	return maxYearMonthDay;
}

extern "C" __declspec(dllexport)
float ProtectedFuncA(float* array,int length)
{
	if(isAuthenticated)
	{
		float max=array[0];
		for(int a=1;a<length;a++)
		{
			if(array[a]>max)max=array[a];
		}
		return max;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
float ProtectedFuncB(float* array,int length)
{
	if(isAuthenticated)
	{
		float min=array[0];
		for(int a=1;a<length;a++)
		{
			if(array[a]<min)min=array[a];
		}
		return min;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
float ProtectedFuncC(float * array,int length)
{
	if(isAuthenticated)
	{
		float sum=0;
		for(int a=0;a<length;a++)
		{
			sum+=array[a];
		}
		return sum/length;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
float ProtectedFuncD(float a,float b)
{
	if(isAuthenticated)
	{
		return a+b;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
float ProtectedFuncE(float a,float b)
{
	if(isAuthenticated)
	{
		return a-b;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
float ProtectedFuncF(float a,float b)
{
	if(isAuthenticated)
	{
		return a*b;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
float ProtectedFuncG(float a,float b)
{
	if(isAuthenticated)
	{
		return a/b;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
int ProtectedFuncH(int a,int b)
{
	if(isAuthenticated)
	{
		return a+b;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
int ProtectedFuncI(int a,int b)
{
	if(isAuthenticated)
	{
		return a-b;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
int ProtectedFuncJ(int a,int b)
{
	if(isAuthenticated)
	{
		return a*b;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
int ProtectedFuncK(int a,int b)
{
	if(isAuthenticated)
	{
		return a/b;
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
float ProtectedFormula1(float v0,float v1,float v2)
{
	if(isAuthenticated)
	{
		return (v0 - v1)/(v2 - v1)*100;
		
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
int ProtectedFuncL(float v0,float v1)
{
	if(isAuthenticated)
	{
		return v0>v1?-1:0;
		
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
int ProtectedFuncM(float v0,float v1)
{
	if(isAuthenticated)
	{
		return v0<v1?1:0;
		
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

extern "C" __declspec(dllexport)
int ProtectedFuncN(int v0,int v1)
{
	if(isAuthenticated)
	{
		return v0==1?v1:0;
		
	}
	return PROTECTION_FAILED_CALCULATION_RESULT;
}

