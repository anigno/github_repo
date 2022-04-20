#include<time.h>
#include<iostream.h>

class c_clock{
private:
	unsigned int start;
public:
	c_clock(){
		start=clock();
	}
	void printClock(char* text){
		cout<<text<<"="<<clock()-start<<endl;
	}

	void reset(){
		start=clock();
	}
};//class c_clock

	