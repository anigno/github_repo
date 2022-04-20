#ifndef __cThread__
#define __cThread__

class cThread
{
private:
	DWORD _threadID;
	HANDLE _threadHandle;
	LPVOID _threadParam;
	LPTHREAD_START_ROUTINE _threadStartRoutine;
	DWORD _stackSize;

public:
	cThread(DWORD stackSize,LPTHREAD_START_ROUTINE threadStartRoutine,LPVOID threadParam)
	{
		_threadParam=threadParam;
		_stackSize=stackSize;
		_threadStartRoutine=threadStartRoutine;
		if(_threadStartRoutine==NULL)_threadStartRoutine=defaultThreadFunction;
		_threadHandle=CreateThread(NULL,_stackSize,_threadStartRoutine,_threadParam,CREATE_SUSPENDED,&_threadID);
	}//cThread()

	~cThread(){
		exitThread(1);
	}//~cThread()

	static DWORD WINAPI defaultThreadFunction(LPVOID lpParam)
	{
		return 0;
	}//threadFunction()

	DWORD resumeThread(){
		return ResumeThread(_threadHandle);
	}//resumeThread()

	DWORD suspendThread(){
		return SuspendThread(_threadHandle);
	}//suspendThread()

	BOOL terminateThread(DWORD exitCode){
		return TerminateThread(_threadHandle,exitCode);
	}//terminateThread()
	
	void exitThread(DWORD exitCode)
	{
		ExitThread(exitCode);
	}//exitThread()
};//class cThread

#endif