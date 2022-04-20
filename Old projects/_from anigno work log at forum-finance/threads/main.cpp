#include <windows.h>
#include <conio.h>
#include "threadFunctions.h"
#include "cThread.h"


 
VOID main( VOID ) 
{ 

	cThread t1(0,thread01,"thread number 1");
	t1.resumeThread();
	Sleep(2000);
	t1.suspendThread();
	t1.terminateThread(1);



	cout<<"<<Stoped>>\n";
	getchar();
}//main()
