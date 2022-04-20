#include<time.h>
#ifndef __cTimer__
#define __cTimer__

class cTimer{
private:
	long start;
	long end;
public:
	
	cTimer(){
		start=clock();
	}//cTimer()

	void reset(){
		start=clock();
	}//reset()

	long get(){
		end=clock();
		return end-start;
	}//get


};//class cTimer

#endif