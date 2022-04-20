
void printArray(char *s,int b[],int size){
	cout<<s<<"->";
	for(int a=1;a<=size;a++)cout<<b[a]<<" ";
	cout<<endl;
}

void swap(int a[],int i,int j){
	cout<<"swap "<<a[i]<<"<>"<<a[j]<<endl;
	int t=a[i];
	a[i]=a[j];
	a[j]=t;
}

void heapify(int a[],int size,int i){
	int l=i*2;
	int r=i*2+1;
	int largest;
	if(l<=size&&a[l]>a[i]){
		largest=l;
	}else{
		largest=i;
	}
	if(r<=size&&a[r]>a[largest]){
		largest=r;
	}
	if(largest!=i){
		swap(a,i,largest);
		heapify(a,size,largest);
	}
}

/*
start->6 2 3 8 9 4 1 5 7
after heapify->6 2 3 8 9 4 1 5 7
swap 3<>4
after heapify->6 2 4 8 9 3 1 5 7
swap 2<>9
after heapify->6 9 4 8 2 3 1 5 7
swap 6<>9
swap 6<>8
swap 6<>7
after heapify->9 8 4 7 2 3 1 5 6
*/