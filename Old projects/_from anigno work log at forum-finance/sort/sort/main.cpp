
//29024783//

#include<iostream.h>
#include<fstream.h>
#include<time.h>
#include"c_clock.h"
#include"heapSort.h"
#include"quickSort.h"
#include"mergeSort.h"
int main(){
	int *a1,*a2,*a3;
	const unsigned int ARRAYSIZE=99999;
	//create 3 arrays
	a1=new int[ARRAYSIZE+1];
	a2=new int[ARRAYSIZE+1];
	a3=new int[ARRAYSIZE+1];
	c_clock myClock;			//c_clock class for counting clock ticks
	//loading data from file into 3 arrays
	int a=1;
	ifstream inputFile("data.txt");
	while(a<=ARRAYSIZE){
		inputFile>>a1[a];
		a2[a]=a3[a]=a1[a];
		a++;
	}
//start merge sorting
	mergeSort myMerge(a3,ARRAYSIZE);
	myClock.reset();
	myMerge.runSort();
	myClock.printClock("merge sort time");
//end merge sorting

//start heap sorting
	heap myHeap(a1,ARRAYSIZE);
	myClock.reset();
	myHeap.buildHeap();
	myClock.printClock("build heap time");
	myClock.reset();
	myHeap.runSort();
	myClock.printClock("heap sort time");
//end of heap sorting

//start quick sorting
	quickSort myQuick(a2,ARRAYSIZE);
	myClock.reset();
	myQuick.runSort();
	myClock.printClock("quickSort time");
//end quick sorting

	int answer,low,high;
	unsigned int cnt=0;
	cout<<"which sorting methode would you like to test (1-merge 2-heap 3-quick)"<<endl;
	cin>>answer;
	cout<<"please enter range to print (2 integers LOW HIGH)"<<endl;
	cin>>low>>high;
	for(a=1;a<=ARRAYSIZE;a++){
		if(answer==1){
			if(a1[a]>=low&&a1[a]<=high){
				cout<<a1[a]<<" ";
				cnt++;
			}
		}
		if(answer==2){
			if(a2[a]>=low&&a1[a]<=high){
				cout<<a2[a]<<" ";
				cnt++;
			}
		}
		if(answer==3){
			if(a3[a]>=low&&a1[a]<=high){
				cout<<a3[a]<<" ";
				cnt++;
			}
		}
	}
	cout<<endl<<"numbers in range="<<cnt<<endl;
	return 0;
}

