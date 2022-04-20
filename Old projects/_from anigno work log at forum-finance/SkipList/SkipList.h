#define INF 999999999		//Infinity setting for all keys

template <class P>
class SkipNode			//of template <P>
{
public:
	long Key;
	P Data;				//<Data> as template
	SkipNode* Right;
	SkipNode* Down;
//-----------------------------------------------------------------------------------
	SkipNode()
	{
		Key=0;
		Down=NULL;
		Right=NULL;
	}//SkipNode constructor
};//class SkipNode
//-----------------------------------------------------------------------------------
template<class T>
class SkipList			//of template <T>
{
public:
	SkipNode<T>* StartSkipNode;
	SkipNode<T>* EndSkipNode;
	SkipList();
	~SkipList();
	//Insert() function
	//will insert NewSkipNode into SkipList in position <sKey>, will set <Data>
	//into <InputData> pointer, and update all levels with posibility 1/2 if requested
	//return <StartSkipNode> as success or NULL as fail (key exist)
	SkipNode<T>* Insert(long sKey,T InputData);
	//Insert1() recoursive function
	SkipNode<T>* Insert1(SkipNode<T>* StartSearch,long sKey,T InputData);
	//AddSkipNode() function
	//will add new <SkipNode> after <Position>
	SkipNode<T>* AddSkipNode(SkipNode<T>* Position,long sKey,T InputData);
	int Toss();
	//Search() function
	//will search for <sKey> and return &<T> (&Data)
	T Search(long sKey);
	//Remove() function
	//will remove <SkipNode> with <sKey> from all levels
	//return StartSkipNode as success or NULL as fail (not found)
	SkipNode<T>* Remove(long sKey);
	//Remove1() recoursive function
	//will remove sKey from all levels
	void Remove1(SkipNode<T>* Start,long sKey);
};//class SkipList
//-----------------------------------------------------------------------------------
	//SkipList constructor
template<class T>
SkipList<T>::SkipList()
	{
		//will set StartNode & EndNode
		StartSkipNode=new SkipNode<T>;		//SkipNode<P>=<T>
		EndSkipNode=new SkipNode<T>;		//SkipNode<P>=<T>
		StartSkipNode->Key=-INF;
		EndSkipNode->Key=INF;
		StartSkipNode->Right=EndSkipNode;	//connect start to end in SkipList
	}//SkipList constructor
//-----------------------------------------------------------------------------------
	//SkipList distructor
template<class T>
SkipList<T>::~SkipList()
	{
		//will delete <SkipList> structure (the empty levels)
		SkipNode<T>* DelIterator;
		//will delete <StartSkipNode> until only one level is left
		//		this is used to free memory from additional levels added by program
		for(/*none*/;StartSkipNode->Down!=NULL;/*none*/)
		{
			DelIterator=StartSkipNode;
			StartSkipNode=StartSkipNode->Down;
			delete DelIterator;
		}//for
		//will delete the lest level left
		delete StartSkipNode;
		delete EndSkipNode;
	}//SkipList distructor
//-----------------------------------------------------------------------------------
	//Insert() function
	//will insert NewSkipNode into SkipList in position <sKey>, will set <Data>
	//into <InputData> pointer, and update all levels with posibility 1/2 if requested
	//return <StartSkipNode> as success or NULL as fail (key exist)
template<class T>
SkipNode<T>* SkipList<T>::Insert(long sKey,T InputData)
	{
		//will check if sKey exist
		if(Search(sKey)==NULL)
		{
			//not found
			SkipNode<T>* ReturnSkipNode;
			//will call Insert1() recoursive function
			ReturnSkipNode=Insert1(StartSkipNode,sKey,InputData);
			//will check if NewSkipNode was added in lower level
			if( ReturnSkipNode!=NULL )
			{
				//yes, will add level with posibilty 1/2
				if(Toss()==1)
				{
					//add upper level
					SkipNode<T>* NewLevel;
					NewLevel=new SkipNode<T>;
					NewLevel->Down=StartSkipNode;
					NewLevel->Right=EndSkipNode;
					NewLevel->Key=-INF;
					StartSkipNode=NewLevel;
				}//if
			}//if
			return StartSkipNode;	//simply to flag that NewSkipNode inserted
		}//if
		return NULL;				//simply to flag that sKey exist
	}//Insert()
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	//Insert1() recoursive function
template<class T>
	SkipNode<T>* SkipList<T>::Insert1(SkipNode<T>* StartSearch,long sKey,T InputData)
	{
		SkipNode<T>* Iterator;
		SkipNode<T>* LastSkipNode;
		//will move right untill <sKey> > <Key>
		for(Iterator=StartSearch;sKey>Iterator->Right->Key;Iterator=Iterator->Right);
		//will check for last level
		if(Iterator->Down==NULL)
		{
			//last level, will add NewSkipNode, and return it to last call to Insert1()
			return AddSkipNode(Iterator,sKey,InputData);
		}
		else
		{
			//not last level, will call Insert1() again with <Iterator->Down>
			LastSkipNode=Insert1(Iterator->Down,sKey,InputData);
		
		//*** THE PLACE WHERE THE RECOURCE RETURN FROM Insert1() ***

			//will check if NewSkipNode was added to lower level
			if(LastSkipNode!=NULL)
			{
				//yes,will add NewSkipNode to this level with posibility 1/2
				if( Toss()==1)
				{
					//will add NewNode
					Iterator=AddSkipNode(Iterator,sKey,InputData);
					Iterator->Down=LastSkipNode;	//conect to lower level 
					//will return NewSkipNode that was created to previous call Insert1()
					return Iterator;
				}//if
			}//if

		}//if else
		//will return NULL to previous call of Insert1() or Insert()
		return NULL;
	}//Insert1()
//-----------------------------------------------------------------------------------
	//AddSkipNode() function
	//will add new <SkipNode> after <Position>
template<class T>
	SkipNode<T>* SkipList<T>::AddSkipNode(SkipNode<T>* Position,long sKey,T InputData)
	{
		SkipNode<T>* NewSkipNode;
		NewSkipNode=new SkipNode<T>;
		NewSkipNode->Right=Position->Right;
		NewSkipNode->Key=sKey;
		NewSkipNode->Data=InputData;
		Position->Right=NewSkipNode;
		return NewSkipNode;
	}//AddSkipNode()
//-----------------------------------------------------------------------------------
template<class T>
	int SkipList<T>::Toss()
	{
		rand();
		if(rand()<16384)return 0; else return 1;
	}//Toss()
//-----------------------------------------------------------------------------------
	//Search() function
	//will search for <sKey> and return &<T> (&Data)
template<class T>
	T SkipList<T>::Search(long sKey)
	{
		SkipNode<T>* Iterator;
		//will search from upper level to lower level
		for(Iterator=StartSkipNode;Iterator!=NULL;Iterator=Iterator->Down)
		{
			//will search for <sKey> or smaller in this level
			for(/*none*/;Iterator->Right->Key<sKey;Iterator=Iterator->Right);
			if(Iterator->Down==NULL)
			{
				//will check for <sKey>
				if(Iterator->Right->Key==sKey)
					return Iterator->Right->Data;	//return <T> pointer
				else
					return NULL;					//return NULL (not found)
			}//if
		}//for
		// <sKey> not found will return NULL
		return NULL;
	}//Search()
//-----------------------------------------------------------------------------------
	//Remove() function
	//will remove <SkipNode> with <sKey> from all levels
	//return StartSkipNode as success or NULL as fail (not found)
template<class T>
	SkipNode<T>* SkipList<T>::Remove(long sKey)
	{
		//will search if <sKey> exist
		if(Search(sKey)!=NULL)
		{
			//yes, will start remove with Remove1() recoursive function
			Remove1(StartSkipNode,sKey);
			return StartSkipNode;	//as flag for success
		}//if
		//not found, will return NULL as not found
		return NULL;
	}//Remove()
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	//Remove1() recoursive function
	//will remove sKey from all levels
template<class T>
	void SkipList<T>::Remove1(SkipNode<T>* Start,long sKey)
	{
		SkipNode<T>* Iterator;
		SkipNode<T>* DelIterator;
		//will move right to search for previous SkipNode to <sKey>
		for(Iterator=Start;Iterator->Right->Key<sKey;Iterator=Iterator->Right);
		//will check if not in last level and call Remove1() again from ->Down pointer
		if(Iterator->Down!=NULL)
		{
			Remove1(Iterator->Down,sKey);
		}//if

		//*** THE PLACE WHERE RETURN FROM Remove1() ***
		
		//will check if <sKey> was found in this level

		if(Iterator->Right->Key==sKey)
		{
			//yes, will delete the <SkipNode>
			DelIterator=Iterator->Right;
			Iterator->Right=Iterator->Right->Right;
			delete DelIterator;
		}//if

		return ;
	}//Remove1()
//-----------------------------------------------------------------------------------




