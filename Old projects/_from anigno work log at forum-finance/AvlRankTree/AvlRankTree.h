//******************
//* AvlRankTree.h  *
//******************
template<class N>
class aNode
{
public:
	long Key;				//the key of this node
	N Data;					//Data template
	long HL;				//the Height of the Left branch
	long HR;				//the Height of the Right branch
	long BF;				//the Balance Factor
	long Rnum;				//number of nodes in right branch
	long Rsum;				//sum of Ranks in right branch
	long RankValue;			//the Rank value of the tree
	aNode<N>* Parent;		//the parent of current node
	aNode<N>* L;			//pointer to Left branch
	aNode<N>* R;			//pointer to right branch
	//*** functions ***
	aNode()
	{
		Key=0;
		HL=0;
		HR=0;
		BF=0;
		Rnum=0;
		Rsum=0;
		Parent=NULL;
		L=NULL;
		R=NULL;
	}//constructor
};//class aNode
//**********************************************************************








//**********************************************************************
template<class T>
class AvlRankTree
{
public:
	aNode<T>* Root;
	//*** functions ***
	AvlRankTree()
	{
		Root=NULL;
	}//constructor
//--------------------------------------------------------------------

//--------------------------------------------------------------------
//Search() function
//will search for sKey
//return pointer to aNode if found or NULL if not
	aNode<T>* Search(long sKey);
//--------------------------------------------------------------------
//Get() function
//will search for sKey
//return Data template if found or 0 if not
	T Get(long sKey);
//--------------------------------------------------------------------
//Height() function
//will return the Height of aNode, according to his childs
	long Height(aNode<T>* Node);
//--------------------------------------------------------------------
//Roll_LL
	void Roll_LL(aNode<T>* Node);
//--------------------------------------------------------------------
//Roll_LR
	void Roll_LR(aNode<T>* Node);
//--------------------------------------------------------------------
//Roll_RR
	void Roll_RR(aNode<T>* Node);
//--------------------------------------------------------------------
//Roll_RL
	void Roll_RL(aNode<T>* Node);
//--------------------------------------------------------------------
//InsertFix() function
//will fix BF, Rsum and Rnum from node to the root after insert new node
	void InsertFix(aNode<T>* iNode,long sKey);
//--------------------------------------------------------------------
//Insert() function
//will insert new sKey & Data
//will return pointer to aNode if inserted or NULL if not
	aNode<T>* Insert(long sKey,T Data,long iRankValue);
//--------------------------------------------------------------------
//RemoveFix()
//recieve the deleted node's parent and update parameters on path to Root
	void RemoveFix(aNode<T>* iNode,long sKey);
//--------------------------------------------------------------------
//Delete0() function
//will delete a node with no childs
	void Delete0(aNode<T>* Node);
//--------------------------------------------------------------------
//Delete1() function
//will delete a node with one child
	void Delete1(aNode<T>* Node);
//--------------------------------------------------------------------
//Delete2() function
//will delete a node with two child
	void Delete2(aNode<T>* Node);
//--------------------------------------------------------------------
//Remove() function
//will remove sKey from tree
//return 1 as success or 0 as fail
	int Remove(long sKey);
//--------------------------------------------------------------------
//Rank() function
//will return the Rsum of the P largest Keys in the tree
	long Rank(long K);
//--------------------------------------------------------------------
};//class AvlRankTree

















//--------------------------------------------------------------------
//Search() function
//will search for sKey
//return pointer to aNode if found or NULL if not
template<class T>
aNode<T>* AvlRankTree<T>::Search(long sKey)
	{
		aNode<T>* Iterator;
		Iterator=Root;
		//will check if root is empty
		if(Root==NULL)return NULL;
		//root is not empty, will continue
		while(Iterator->Key!=sKey)
		{
			if(sKey<Iterator->Key)
			{
				//will try to move left
				if(Iterator->L!=NULL)
					Iterator=Iterator->L;
				else
					return NULL;
			}
			else
			{
				//will try to move right
				if(Iterator->R!=NULL)
					Iterator=Iterator->R;
				else
					return NULL;
			}//if else
		}//while
		return Iterator;
	}//Search()
//--------------------------------------------------------------------








//--------------------------------------------------------------------
//Get() function
//will search for sKey
//return Data template if found or 0 if not
template<class T>
T AvlRankTree<T>::Get(long sKey)
	{
		aNode<T>* Iterator;
		Iterator=Search(sKey);
		if(Iterator==NULL)
			return 0;
		else
			return Iterator->Data;
	}//Get()
//--------------------------------------------------------------------






	
	
//--------------------------------------------------------------------
//Height() function
//will return the Height of aNode, according to his childs
template<class T>
long AvlRankTree<T>::Height(aNode<T>* Node)
	{
		//will check if recieved NULL Node
		if(Node==NULL)return 0;
		//not NULL will continue
		if(Node->HL>Node->HR)
			return Node->HL+1;
		else
			return Node->HR+1;
	}//Height()
//--------------------------------------------------------------------









//--------------------------------------------------------------------
//Roll_LL
template<class T>
void AvlRankTree<T>::Roll_LL(aNode<T>* Node)
	{
		aNode<T> *A,*B,*BR;
		A=Node;
		B=Node->L;
		BR=B->R;
		//------
		B->Parent=A->Parent;
		if(A->Parent!=NULL)
		{
			//A is not the root
			if(A->Parent->L==A)
				A->Parent->L=B;
			else
				A->Parent->R=B;
		}
		else
		{
			//A is the root
			Root=B;
			B->Parent=NULL;
		}//if else
		B->R=A;
		A->Parent=B;
		A->L=BR;
		if(BR!=NULL)BR->Parent=A;
		//------
		A->HL=Height(A->L);
		A->HR=Height(A->R);
		A->BF=A->HL-A->HR;
		B->HL=Height(B->L);
		B->HR=Height(B->R);
		B->BF=B->HL-B->HR;
		//------
		B->Rnum+=A->Rnum+1;
		B->Rsum+=A->Rsum+A->RankValue;
	}//Roll_LL;
//--------------------------------------------------------------------









//--------------------------------------------------------------------
//Roll_LR
template<class T>
void AvlRankTree<T>::Roll_LR(aNode<T>* Node)
	{
		aNode<T> *A,*B,*C,*CL,*CR;
		A=Node;
		B=Node->L;
		C=Node->L->R;
		CL=Node->L->R->L;
		CR=Node->L->R->R;
		//------
		C->Parent=A->Parent;
		if(A->Parent!=NULL)
		{
			//A is not the root
			if(A->Parent->L==A)
				A->Parent->L=C;
			else
				A->Parent->R=C;
		}
		else
		{
			//A is the root
			Root=C;
			C->Parent=NULL;
		}//if else
		C->L=B;
		B->Parent=C;
		B->R=CL;
		if(CL!=NULL) CL->Parent=B;
		C->R=A;
		A->Parent=C;
		A->L=CR;
		if(CR!=NULL) CR->Parent=A;
		//------
		A->HL=Height(A->L);
		A->HR=Height(A->R);
		A->BF=A->HL-A->HR;
		B->HL=Height(B->L);
		B->HR=Height(B->R);
		B->BF=B->HL-B->HR;
		C->HL=Height(C->L);
		C->HR=Height(C->R);
		C->BF=C->HL-C->HR;
		//------
		B->Rnum-=(C->Rnum+1);
		B->Rsum-=(C->Rsum+C->RankValue);
		C->Rnum+=(A->Rnum+1);
		C->Rsum+=(A->Rsum+A->RankValue);
	}//Roll_LR
//--------------------------------------------------------------------


	
	
	
	
	
	
	
	
//--------------------------------------------------------------------
//Roll_RR
template<class T>
void AvlRankTree<T>::Roll_RR(aNode<T>* Node)
	{
		aNode<T> *A,*B,*BL;
		A=Node;
		B=Node->R;
		BL=B->L;
		//------
		B->Parent=A->Parent;
		if(A->Parent!=NULL)
		{
			//A is not the root
			if(A->Parent->L==A)
				A->Parent->L=B;
			else
				A->Parent->R=B;
		}
		else
		{
			//A is the root
			Root=B;
			B->Parent=NULL;
		}//if else
		B->L=A;
		A->Parent=B;
		A->R=BL;
		if(BL!=NULL)BL->Parent=A;
		//------
		A->HL=Height(A->L);
		A->HR=Height(A->R);
		A->BF=A->HL-A->HR;
		B->HL=Height(B->L);
		B->HR=Height(B->R);
		B->BF=B->HL-B->HR;
		//------
		A->Rnum-=(B->Rnum+1);
		A->Rsum-=(B->Rsum+B->RankValue);
		
	}//Roll_RR
//--------------------------------------------------------------------
	

	
	

	
	
//--------------------------------------------------------------------
//Roll_RL
template<class T>
void AvlRankTree<T>::Roll_RL(aNode<T>* Node)
	{
		aNode<T> *A,*B,*C,*CL,*CR;
		A=Node;
		B=Node->R;
		C=Node->R->L;
		CL=C->L;
		CR=C->R;
		//------
		C->Parent=A->Parent;
		if(A->Parent!=NULL)
		{
			//A is not the root
			if(A->Parent->L==A)
				A->Parent->L=C;
			else
				A->Parent->R=C;
		}
		else
		{
			//A is the root
			Root=C;
			C->Parent=NULL;
		}//if else
		C->R=B;
		B->Parent=C;
		C->L=A;
		A->Parent=C;
		A->R=CL;
		if(CL!=NULL) CL->Parent=A;
		B->L=CR;
		if(CR!=NULL) CR->Parent=B;
		//------
		A->HL=Height(A->L);
		A->HR=Height(A->R);
		A->BF=A->HL-A->HR;
		B->HL=Height(B->L);
		B->HR=Height(B->R);
		B->BF=B->HL-B->HR;
		C->HL=Height(C->L);
		C->HR=Height(C->R);
		C->BF=C->HL-C->HR;
		//------
		A->Rnum-=(B->Rnum+1+C->Rnum+1);
		A->Rsum-=(B->Rsum+B->RankValue+C->Rsum+C->RankValue);
		C->Rnum+=(B->Rnum+1);
		C->Rsum+=(B->Rsum+B->RankValue);
	}//Roll_RL
//--------------------------------------------------------------------



//--------------------------------------------------------------------
//InsertFix() function
//will fix BF, Rsum and Rnum from node to the root after insert new node
template<class T>
void AvlRankTree<T>::InsertFix(aNode<T>* iNode,long sKey)
	{
		aNode<T>* Node;
		Node=iNode;
		while(Node!=NULL)
		{
			//fix node heights and BF
			Node->HL=Height(Node->L);		//calculate left branch height
			Node->HR=Height(Node->R);		//calculate right branch height
			Node->BF=Node->HL-Node->HR;		//calculate Balance Factor

			//check the node position
			if(sKey<Node->Key)
				{
					//node is left
				}
				else
				{
					Node->Rnum++;
					Node->Rsum+=sKey;
				}
			//will check for Rolls
			if(Node->BF==2)
			{
				if(Node->L->BF>=0)
					Roll_LL(Node);
				else
					Roll_LR(Node);
				Node=Node->Parent;
			}
			else
			{
				if(Node->BF==-2)
				{
					if(Node->R->BF<=0)
						Roll_RR(Node);
					else
						Roll_RL(Node);
					Node=Node->Parent;
				}//if
			}//if else
			Node=Node->Parent;
		}//while
	}//InsertFix()
//--------------------------------------------------------------------



//--------------------------------------------------------------------
//Insert() function
//will insert new sKey & Data
//will return pointer to aNode if inserted or NULL if not
template<class T>
aNode<T>* AvlRankTree<T>::Insert(long sKey,T Data,long iRankValue)
	{
		aNode<T>* Iterator;
		aNode<T>* NewNode;
		int EndSearch=0;			// a flag for ending the search


		NewNode=new aNode<T>;
		NewNode->Key=sKey;
		NewNode->Data=Data;
		NewNode->RankValue=iRankValue;

		//will check if root is empty
		if(Root==NULL)
		{
			//root is empty, will put New Node in root
			Root=NewNode;
			return NewNode;
		}//if

		//root is not empty,will search for place to put NewNode
		Iterator=Root;
		while(EndSearch==0)
		{
			if(sKey<Iterator->Key)
			{
				//move to left branch if posible
				if(Iterator->L!=NULL)
				{
					//left branch not empty, will move to left
					Iterator=Iterator->L;
				}
				else
				{
					//left branch empty, will end the search
					EndSearch=1;
				}//else
			}
			else
			{
				//move to right branch if posible
				if(Iterator->R!=NULL)
				{
					//right branch not empty, will move to right
					Iterator=Iterator->R;
				}
				else
				{
					//right branch empty, will end the search
					EndSearch=1;
				}//else
			}//if else
		}//while

		//the place found, will put NewNode
		if(sKey<Iterator->Key)
		{
			//in left branch
			Iterator->L=NewNode;
			Iterator->L->Parent=Iterator;
		}
		else
		{
			//in right branch
			Iterator->R=NewNode;
			Iterator->R->Parent=Iterator;
		}//if else
		
		InsertFix(Iterator,sKey);
		return NewNode;
	}//Insert()
//--------------------------------------------------------------------






	
	
	
//--------------------------------------------------------------------
//RemoveFix()
//recieve the deleted node's parent and update parameters on path to Root
template<class T>
void AvlRankTree<T>::RemoveFix(aNode<T>* iNode,long sKey)
	{
		aNode<T>* Node;
		Node=iNode;
		while(Node!=NULL)
		{
			//fix node heights and BF
			Node->HL=Height(Node->L);		//calculate left branch height
			Node->HR=Height(Node->R);		//calculate right branch height
			Node->BF=Node->HL-Node->HR;		//calculate Balance Factor

			//check the node position
			if(sKey<=Node->Key)
			{
				//node is left
			}
			else
			{
				Node->Rnum--;
				Node->Rsum-=sKey;
			}
			//will check for Rolls
			if(Node->BF==2)
			{
				if(Node->L->BF>=0)
					Roll_LL(Node);
				else
					Roll_LR(Node);
				Node=Node->Parent;
			}
			else
			{
				if(Node->BF==-2)
				{
					if(Node->R->BF<=0)
						Roll_RR(Node);
					else
						Roll_RL(Node);
					Node=Node->Parent;
				}//if
			}//if else
			Node=Node->Parent;
		}//while
	}//RemoveFix()
//--------------------------------------------------------------------









//--------------------------------------------------------------------
//Delete0() function
//will delete a node with no childs
template<class T>
void AvlRankTree<T>::Delete0(aNode<T>* Node)
	{
		aNode<T>* NodeParent;
		long sKey;
		//will check if node is the root
		if(Node==Root)
		{
			//delete the root
			delete Node;
			Root=NULL;
			return;
		}//if
		//the node is not the root will remove conection and delete node
		NodeParent=Node->Parent;
		sKey=Node->Key;
		//will remove conection
		if(Node==Node->Parent->L)
			Node->Parent->L=NULL;			//was left node
		else
			Node->Parent->R=NULL;			//was right node
		//will remove the node
		delete Node;
		//will fix the path from the parent to the root
		RemoveFix(NodeParent,sKey);
	}//Delete0()
//--------------------------------------------------------------------







//--------------------------------------------------------------------
//Delete1() function
//will delete a node with one child
template<class T>
void AvlRankTree<T>::Delete1(aNode<T>* Node)
	{
		aNode<T>* NodeParent;
		long sKey;

		//will check if node is the root
		if(Node==Root)
		{
			if(Node->L!=NULL)
			{
				//root with left child
				Root=Root->L;
				Root->Parent=NULL;
				delete Node;
			}
			else
			{
				//root with right child
				Root=Root->R;
				Root->Parent=NULL;
				delete Node;
			}//if else
		return;
		}//if
		
		//node is not the root will remove the node
		NodeParent=Node->Parent;
		sKey=Node->Key;
		//will check the nodes position and the nodes child position (left/right)

		if(Node->Parent->L==Node)
		{
			//node is a left child
			if(Node->L!=NULL)
			{
				//left child with a left child
				Node->Parent->L=Node->L;
				Node->L->Parent=Node->Parent;
			}
			else
			{
				//left child with a right child
				Node->Parent->L=Node->R;
				Node->R->Parent=Node->Parent;
			}//if else

		}
		else
		{
			//node is a right child
			if(Node->L!=NULL)
			{
				//right child with a left child
				Node->Parent->R=Node->L;
				Node->L->Parent=Node->Parent;
			}
			else
			{
				//right child with a right child
				Node->Parent->R=Node->R;
				Node->R->Parent=Node->Parent;
			}//if else
		}//if else
		delete Node;
		//will fix the path from the parent to the root
		RemoveFix(NodeParent,sKey);
	}//Delete1()
//--------------------------------------------------------------------




//--------------------------------------------------------------------
//Delete2() function
//will delete a node with two child
template<class T>
void AvlRankTree<T>::Delete2(aNode<T>* Node)
	{
		aNode<T>* Iterator;
		long temp;

		Iterator=Node;
		//will move one step right
		Iterator=Iterator->R;
		//will move all the way down
		while(Iterator->L!=NULL)
			Iterator=Iterator->L;
		//Iterator is the successor, will copy values
		temp=Node->Key;
		Node->Key=Iterator->Key;
		Iterator->Key=temp;
		temp=Node->RankValue;
		Node->RankValue=Iterator->RankValue;
		Iterator->RankValue=temp;
		Node->Data=Iterator->Data;
		Node->Rsum-=Node->RankValue;
		Node->Rnum--;

		//will delete the Iterator according to his childs
		if( (Iterator->L!=NULL)||(Iterator->R!=NULL) )
			Delete1(Iterator);
		else
			Delete0(Iterator);
	}//Delete2()
//--------------------------------------------------------------------








//--------------------------------------------------------------------
//Remove() function
//will remove sKey from tree
//return 1 as success or 0 as fail
template<class T>
int AvlRankTree<T>::Remove(long sKey)
	{
		aNode<T>* Node;
		int childs=0;			//the number of childs of a node
		
		Node=Search(sKey);
		//will check if sKey exist, if not return 0
		if(Node==NULL)return 0;
		//sKey exist will check his childs
		if(Node->L!=NULL)childs++;
		if(Node->R!=NULL)childs++;
		if(childs==0)Delete0(Node);	//delete with no childs
		if(childs==1)Delete1(Node);	//delete with one child
		if(childs==2)Delete2(Node);	//delete with two childs
		return 1;
	}//Remove()
//--------------------------------------------------------------------

	
	
	
	
	
	
	
	
	
	
	
	
//--------------------------------------------------------------------
//Rank() function
//will return the Rsum of the P largest Keys in the tree
template<class T>
long AvlRankTree<T>::Rank(long K)
	{
		aNode<T>* Node;
		long Sum=0;

		Node=Root;
		Sum=0;

		while(K!=Node->Rnum+1)
		{
			if(K<Node->Rnum+1)
			{
				Node=Node->R;
			}
			else
			{
				K=K-Node->Rnum-1;
				Node=Node->L;
			}//if else
		}//while
		Sum=Node->Key+Node->Rsum;
		
		//will move up until root, calculate Sum
		while(Node!=Root)
		{
			if(Node->Parent->L==Node)
			{
				//the Node is a left one
				Node=Node->Parent;
				Sum=Sum+Node->Key+Node->Rsum;
			}
			else
			{
				//the Node is a right one
				Node=Node->Parent;
			}//if else
		}//while
			return Sum;
	}//Rank()
//--------------------------------------------------------------------
