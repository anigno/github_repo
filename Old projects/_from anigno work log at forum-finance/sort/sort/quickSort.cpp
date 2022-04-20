#include<iostream.h>
#include"quickSort.h"


quickSort::quickSort(int *array,unsigned int arrayLength){
	size=arrayLength;
	this->array=array;
}

void quickSort::swap(unsigned int i,unsigned int j){
	int t=array[i];
	array[i]=array[j];
	array[j]=t;
}

void quickSort::printArray(){
	for(unsigned int b=1;b<=size;b++)cout<<array[b]<<" ";
	cout<<endl;
}

unsigned int quickSort::partition(unsigned int low,unsigned int high){
	int pivot=array[low];
	unsigned int i=low-1;
	unsigned int j=high+1;
	while(true){
		do{
			j--;
		}while(array[j]>pivot);
		do{
			i++;
		}while(array[i]<pivot);
		if(i<j){
			swap(i,j);
		}else{
			return j;
		}
	}
}

void quickSort::sort(unsigned int low,unsigned int high){
	unsigned int pivotIndex;
	if (low<high){
		pivotIndex=partition(low, high );
		sort(low,pivotIndex);
		sort(pivotIndex+1,high);
	}
}

void quickSort::runSort(){
	sort(1,size);
}