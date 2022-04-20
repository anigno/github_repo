class c_node{
public:
	long key[3];		//keys of the node
	long keys;			//number of keys
	c_node* child[4];	//next children
	bool retChild[4];	//return child when removing (down tree)
	long children[4];	//how many keys in current child
	c_node* parent;		//parent to node
public:
//-----------------------------------------
	c_node(){
		for(int a=0;a<4;a++){
			child[a]=NULL;		//no childs yet
			children[a]=0;		//no children yet
			retChild[a]=false;	
		}//for
		for(int a=0;a<3;a++){
			key[a]=-9999;		//just for debuging
		}//for
		parent=NULL;			//parent unknown yet
		keys=0;					//no keys yet
	}//ctor
//-----------------------------------------
	~c_node(){
		this->key[0]=-1111;
		//nothing to delete
	}//dtor
//-----------------------------------------
	//insert key to leaf, sort keys o(1)
	void insertKeyToLeaf(long iKey){
		long a;
		for(a=keys-1;(a>=0)&&(iKey<key[a]);a--)
            key[a+1]=key[a];
		key[a+1]=iKey;
		keys++;
	}//insertKeyToLeaf()
//-----------------------------------------
	//check if key is in node, return false if not
	bool keyInNode(long iKey){
		if(this==NULL)return false;
		for(int a=0;a<keys;a++)
			if(iKey==key[a])return true;
		return false;
	}//keyInNode()
//-----------------------------------------
	//check if node is a leaf, return false if not
	bool isLeaf(){
		for(int a=0;a<=keys;a++)
			if(child[a]!=NULL)return false;	//if any child[] exist, not leaf
		return true;
	}//isLeaf()
//-----------------------------------------
	//return the next node to look at
	c_node* nextNode(long iKey){
		c_node* next=child[0];
		for(int a=0;a<keys;a++)
			if(iKey>key[a])next=child[a+1];
		return next;
	}//nextNode()
//-----------------------------------------
	//print the node (x,x,x)
	void printNode(){
		if(this->keys==0){
			cout<<"()";
			return;
		}
		cout<<"(";
		for(int a=0;a<keys-1;a++)
			cout<<this->key[a]<<",";
		cout<<this->key[keys-1];
		cout<<")";

//		for(a=0;a<=3;a++){
//			if(this->child[a]==NULL)cout<<"N"; else cout<<"X";
//		}
//		cout<<"[";
//		for(int a=0;a<keys+1;a++)
//			cout<<this->children[a]<<",";
//		cout<<"]";
	}//printNode()
//-----------------------------------------
	//return key index in node->key[]
	long keyIndex(long iKey){
		for(int a=0;(a<this->keys)&&(iKey>this->key[a]);a++);
		return a;
	}//keyIndex()

//-----------------------------------------
//-----------------------------------------
//-----------------------------------------


};//class c_node
