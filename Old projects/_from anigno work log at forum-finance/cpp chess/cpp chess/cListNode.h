class cListNode{
public:
	static long counter;
	void* data;
	cListNode* next;
	
	cListNode(){
		counter++;
		data=NULL;
		next=NULL;
	}//cListNode()

	~cListNode(){
		counter--;
	}//~cListNode()

};//class cListNode
long cListNode::counter=0;