class heap{
private:
	//swap two keys
	void swap(unsigned int i,unsigned int j);

	//recieve an index and slide it down the heap
	void heapify(int index);
public:
	unsigned int arraySize;		//init array size
	unsigned int size;			//actual size of heap
	int *array;					//pointer to heap array (first item is in array[1]

	//heap only constructor
	heap(int* array,unsigned int size){
		this->arraySize=size;
		this->size=size;
		this->array=array;
	}//heap()
	
	~heap(){
	}//~heap()

	//return and remove the root of the heap
	int extractMax();

	//build the heap from an array
	void buildHeap();

	//run heap sort on array
	void runSort();

	//print the heap
	void printHeapArray();
};//class heap

