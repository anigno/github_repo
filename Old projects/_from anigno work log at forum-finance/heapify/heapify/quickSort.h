void printArray(int a[],char* s,int start,int end){
	int b;
	cout<<s<<"->";
	for(b=start;b<=end;b++)cout<<a[b]<<" ";
	cout<<endl;
}

void swap(int a[],int i,int j){
	int t=a[i];
	static int cnt=0;
	cnt++;
	cout<<"swap #"<<cnt<<" "<<a[i]<<"<>"<<a[j]<<" ";
	  a[i]=a[j];
	  a[j]=t;
	printArray(a,"after swap",0,5);
  }


int partition( int *a, int low, int high ){
	int pivot=a[low];
	int h=high,l=low;
	cout<<"pivot="<<pivot<<" ";
	printArray(a,"before partition",l,h);
	while(true){
		while(a[low]<pivot)low++;
		while(a[high]>pivot)high--;
		if(low<high){
			swap(a,low,high);
		}else{
			printArray(a,"after partition",l,h);
			return high;
		}
	}
}



  void quicksort( int *a, int low, int high )
  {
	int pivot;
	if ( high > low ){
		pivot = partition( a, low, high );
		quicksort( a, low, pivot-1 );
		quicksort( a, pivot+1, high );
	}
  }

/*
pivot=5 before partition->5 4 6 3 8 1
swap 5<>1 after swap->1 4 6 3 8 5
swap 6<>5 after swap->1 4 5 3 8 6
swap 5<>3 after swap->1 4 3 5 8 6
after partition->1 4 3 5 8 6
pivot=1 before partition->1 4 3
after partition->1 4 3
pivot=4 before partition->4 3
swap 4<>3 after swap->1 3 4 5 8 6
after partition->3 4
pivot=8 before partition->8 6
swap 8<>6 after swap->1 3 4 5 6 8
after partition->6 8
sorted->1 3 4 5 6 8
*/
