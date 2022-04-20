class mergeSort{
private:
public:
	//merge array[low,middle-1]  and array[middle,high]
	void merge(unsigned int low,unsigned int middle,unsigned int high);	
	
	//run quick sort on array[low,high]
	void sort(unsigned int low,unsigned int high);

	int *array;			//the array for the keys, first key is array[1]
	unsigned int size;	//size of array
	
	//quickSort only constrator
	mergeSort(int *array,unsigned int arrayLength);

	~mergeSort(){
	}
		
	//run merge sort
	void runSort();
	//print array
	void printArray();
};//class mergeSort