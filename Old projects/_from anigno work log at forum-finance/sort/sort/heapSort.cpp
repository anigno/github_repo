#include<iostream.h>
#include"heapSort.h"

void heap::swap(unsigned int i,unsigned int j){
	int t=array[i];
	array[i]=array[j];
	array[j]=t;	
}//swap()

//heapify down the heap
void heap::heapify(int index){
	unsigned int l=index*2;
	unsigned int r=index*2+1;
	unsigned int smallest;
	if(l<=size&&array[l]<array[index]){
		smallest=l;
	}else{
		smallest=index;
	}
	if(r<=size&&array[r]<array[smallest]){
		smallest=r;
	}
	if(smallest!=index){
		swap(index,smallest);
			heapify(smallest);
	}
}//heapify()

void heap::buildHeap(){
	for(int a=size/2;a>=1;a--){
		heapify(a);
	}
}//buildHeap()

void heap::printHeapArray(){
	for(unsigned int a=1;a<=arraySize;a++){
		cout<<array[a]<<" ";
	}
	cout<<endl;
}//printHeapArray()

int heap::extractMax(){
	if(size>0){
		int t=array[1];
		array[1]=array[size];
		size--;
		heapify(1);
		return t;
	}
	return 0;
}//extractMax

void heap::runSort(){
	int *t=new int[size+1];
	for(unsigned int a=1;a<=arraySize;a++){
		t[a]=extractMax();
	}
	for(unsigned int a=1;a<=arraySize;a++){
		array[a]=t[a];
	}
	delete t;
}//runSort()


