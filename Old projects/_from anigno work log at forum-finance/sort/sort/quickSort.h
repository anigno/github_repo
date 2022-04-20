class quickSort{
private:
	//swap two index's
	void swap(unsigned int i,unsigned int j);

	//make partition
	unsigned int partition(unsigned int low,unsigned int high);	

	//run quick sort on array[low,high]
	void sort(unsigned int low,unsigned int high);
public:
	int *array;			//the array for the keys, first key is array[1]
	unsigned int size;	//size of array
	
	//quickSort only constrator
	quickSort(int *array,unsigned int arrayLength);

	~quickSort(){
	}
		
	//run quick sort
	void runSort();

	//print array
	void printArray();
};//class quickSort

