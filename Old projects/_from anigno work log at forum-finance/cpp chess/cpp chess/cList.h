//linked list implementation with add and jion in o(1)
class cList{
public:
	static long count;
	cListNode* startNode;
	cListNode* endNode;

	cList(){
		count++;
		startNode=NULL;
		endNode=NULL;
	}//cList()

	//dtor will remove only the cListNode(s) o(n)
	~cList(){
		count--;
		cListNode* temp;
		for(cListNode* it=startNode;it!=NULL;){
			temp=it;
			it=it->next;
			delete temp;
		}//for
	}//~cList()

	//add data item to list o(1)
	void add(void* dataItem){
		cListNode* node=new cListNode();
		node->data=dataItem;
		if(startNode==NULL){
			startNode=node;
			endNode=node;
		}else{
			endNode->next=node;
			endNode=node;
		}//if else
	}//add()

	//join other list o(1)
	void join(cList* list){
		if(list->startNode==NULL)return;
		if(startNode==NULL){
            startNode=list->startNode;
			endNode=list->endNode;
		}else{
			endNode->next=list->startNode;
			endNode=list->endNode;
		}//if else
		count--;
	}//join()

	long countElements(){
		long ret=0;
		for(cListNode* it=startNode;it!=NULL;it=it->next)ret+=1;
		return ret;
	}//countElements()
	
	void* getElement(int index){
		void* ret=NULL;
		int c=0;
		for(cListNode* it=startNode;it!=NULL;it=it->next){
			if(c==index)return it->data;
			c++;
		}//for
		return ret;
	}//getElement()

};//class cList
long cList::count=0;