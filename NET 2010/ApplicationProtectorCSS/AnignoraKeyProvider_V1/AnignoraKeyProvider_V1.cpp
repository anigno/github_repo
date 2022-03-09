// AnignoraKeyProvider_V1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "AnignoraKeyProvider_V1.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// The one and only application object

CWinApp theApp;

using namespace std;


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


int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
	int nRetCode = 0;

	// initialize MFC and print and error on failure
	if (!AfxWinInit(::GetModuleHandle(NULL), NULL, ::GetCommandLine(), 0))
	{
		// TODO: change error code to suit your needs
		cerr << _T("Fatal Error: MFC initialization failed") << endl;
		nRetCode = 1;
	}
	else
	{
		cout<<"Enter username: ";
		char name[50];
		cin>>name;
		CString sName=name;
		int length=sName.GetLength();
		int key=GetAuthenticationResultKey(name,length);
		cout<<"Key: "<<key;
		getchar();
		getchar();
	}

	return nRetCode;
}


