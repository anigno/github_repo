
// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the DREAMS_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// DREAMS_API functions as being imported from a DLL, wheras this DLL sees symbols
// defined with this macro as being exported.
#ifdef DREAMS_EXPORTS
#define DREAMS_API __declspec(dllexport)
#else
#define DREAMS_API __declspec(dllimport)
#endif

// This class is exported from the Dreams.dll
class DREAMS_API CDreams {
public:
	CDreams(void);
	// TODO: add your methods here.
};

extern DREAMS_API int nDreams;

DREAMS_API int fnDreams(void);


extern "C" __declspec(dllexport) int FuscatedOne(int v);

int FuscatedOne(int v)
{
	return v;
}

extern "C" __declspec(dllexport) float FuscatedTwo(float v0,float v1,float v2);

float FuscatedTwo(float v0,float v1,float v2)
{
	return (v0 - v1) / (v2 - v1) * 100;
}

extern "C" __declspec(dllexport) float Analize(float v0,float v1);

float Analize(float v0,float v1)
{
	for(int a=0;a<v1;a+=v0)
	{
		v0=v0+v1;
	}	return v0+v1;
}

extern "C" __declspec(dllexport) float Analize2(float v0,float v1);

float Analize2(float v0,float v1)
{
	for(int a=0;a<v0;a+=v1)
	{
		v1=v0+v1;
	}
	return v0+v1;
}


