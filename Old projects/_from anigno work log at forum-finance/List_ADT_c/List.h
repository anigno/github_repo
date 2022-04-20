enum Answer{YES=1,NO=0};		//deleration of enum
typedef enum Answer Answer;		//set enum Answer to be a type
//---------------------------------------------------------
struct Node
{
	void* Element;
	struct Node* Next;
};typedef struct Node Node;

//---------------------------------------------------------
struct tagList
{
	Node* First;
	int(*ElementCompare)(void* Element,void* Key);
};typedef struct tagList List;
//---------------------------------------------------------
ListInit(List** aList,						//User List
		 int(*EC)(void* Element,void *Key))	//get from User
{
	Node* aNode;					//set First Node
	(*aList)=malloc(sizeof(List));	//allocating memory for List
	(*aList)->ElementCompare=EC;	//setting User function ElementCompare
	aNode=malloc(sizeof(Node));		//allocate memory for Node
	aNode->Element=NULL;			//First Node->Element init to NULL
	aNode->Next=NULL;
	(*aList)->First=aNode;			//set First Node item
}//ListInit
//---------------------------------------------------------
void* AddElement(List* aList,void* Element)
{
	Node* Iterator;			//creat Iterator pointer
	Node* NewNode;			//creat new Node
	NewNode=malloc(sizeof(Node));	//allocating memory
	NewNode->Element=Element;		//set NewNode Element
	NewNode->Next=NULL;				//set NewNode->Next to NULL
	Iterator=aList->First;			//set Iterator to First Node	
	//will check if List is empty
	if(Iterator->Element==NULL)
	{
		//the List is empty
		printf("empty\n");
		//will add Node to List
		Iterator->Element=NewNode->Element;
		Iterator->Next=NULL;
		return NewNode->Element;
	}
	else
	{
		//the List is not empty
		printf("not empty\n");
		//will goto last Node in List
		while(Iterator->Next!=NULL)Iterator=Iterator->Next;
		//will add Node to List
		Iterator->Next=NewNode;
		return NewNode->Element;
	}//if else
	return NULL;
}//AddList
//---------------------------------------------------------
void* GetElement(List* aList,void* Key)
{
	//will pass over List to find Key
	Node* Iterator;				//set Node Iterator pointer
	Iterator=aList->First;		//set Iterator to First Node
	//will pass on all Nodes
	while(Iterator!=NULL)
	{
		//will check for Key
		if(aList->ElementCompare(Iterator->Element,Key)==1)
			return Iterator->Element;	//Key found, return Node->Element
		Iterator=Iterator->Next;		//goto Next Node
	}//while
	return NULL;
}//GetElement
