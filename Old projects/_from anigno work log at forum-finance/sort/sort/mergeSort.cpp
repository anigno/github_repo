#include<iostream.h>
#include"mergeSort.h"

mergeSort::mergeSort(int *array,unsigned int arrayLength){
	this->array=array;
	this->size=arrayLength;
}

void mergeSort::printArray(){
	for(unsigned int a=1;a<=size;a++){
		cout<<array[a]<<" ";
	}
	cout<<endl;
}

//merge array[low,middle-1]  and array[middle,high]
void mergeSort::merge(unsigned int low,unsigned int middle,unsigned int high){
	int *a=new int[high-low+1];
	unsigned int l=low,m=middle,t=0;
	while(l<middle&&m<=high){
		if(array[m]<array[l]){
			a[t]=array[m];
			m++;t++;
		}else{
			a[t]=array[l];
			l++;t++;
		}
	}
	if(l==middle){
		//l has riched middle, copy rest of m to a[]
		for(unsigned int k=m;k<=high;k++,t++){
			a[t]=array[k];
		}
	}else{
		//m has riched high, copy rest of l to a[]
		for(unsigned int k=l;k<middle;k++,t++){
			a[t]=array[k];
		}
	}
	//copy t[] to array[]
	for(unsigned int k=low,t=0;k<=high;k++,t++){
		array[k]=a[t];
	}
}//merge()

void mergeSort::sort(unsigned int low,unsigned int high){
	unsigned int middle=(low+high)/2+1;
	if(low>=high)return;
	sort(low,middle-1);
	sort(middle,high);
	merge(low,middle,high);

}//sort()

void mergeSort::runSort(){
	sort(1,size);
}//runSort()


