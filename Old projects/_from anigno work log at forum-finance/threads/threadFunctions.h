#include<iostream>
using namespace std;

DWORD WINAPI thread01(LPVOID lpParam)
{
	unsigned long cnt=0;
	while(cnt<5){
		cout<<cnt++<<" ";
		Sleep(500);
	}//while
	ExitThread(1);
}//thread01()
