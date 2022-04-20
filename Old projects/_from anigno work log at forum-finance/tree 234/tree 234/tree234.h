#include"node.h"

class c_tree234{
public:
	c_node* root;

public:
//-----------------------------------------
	c_tree234(){
		root=NULL;
	}//ctor
//-----------------------------------------
	~c_tree234(){
		while(root)remove(root->key[0]);
	}//dtor
//-----------------------------------------
	bool insert(long iKey){
		//check if key exist, return false if exist
		if(find(iKey))return false;
		//run recourse function to insert key
		return runInsert(root,iKey);	
	}//insert()
//-----------------------------------------
	//recourse function to insert key
	bool runInsert(c_node *node,long iKey){
		c_node *searchNext;				//next node to search at
		//check for empty root (NULL)
		if(node==NULL){
			//node is empty root
			root=new c_node();
			root->key[0]=iKey;
			root->keys=1;
			return true;
		}//if
		//node is not empty root
		//check keys for split
		if(node->keys==3){
			//node need to split
			c_node *temp=node->parent;	//save for later decission where to go
			if(temp==NULL)temp=root;	// root, no parent
			splitNode(node);			//split the node (split will call join() )
			//the new key will be added, must increase children counter of the branch
			temp->children[temp->keyIndex(iKey)]++;
			searchNext=temp->nextNode(iKey);	//next node to search in
			return runInsert(searchNext,iKey);	//recourse call
		}else{
			//no need to split
			//check if key is in node (hamsa hamsa hamsa)
			//if(node->keyInNode(iKey))return false;
			//key is not in node, check if node is leaf to insert key
			if(node->isLeaf()){
				//node is leaf, insert key
				node->insertKeyToLeaf(iKey);
				return true;
			}//if
			//node is not leaf, will try next node
			node->children[node->keyIndex(iKey)]++;
			//recourse call
			return runInsert(node->nextNode(iKey),iKey);
		}//if else
		return true;	//never really gets here, but still, nevermind
	}//runInsert()
//-----------------------------------------
	//join node with his parent, parent has 1 or 2 keys
	void joinNodes(c_node *node){
		long a,b=0;		//general porpose, nothing special
		if(node==root)return;
		//calculate node position in parent node (parent is 1 to 2 keys)
		for(a=0;(a<node->parent->keys)&&(node->key[0]>node->parent->key[a]);a++);
		//choose the right case to deal with, transfering pointers and data
		if(node->parent->keys==2){
			if(a==0){
				//case of Naa (N=child node, a=key of parent node)
				node->parent->key[2]=node->parent->key[1];
				node->parent->key[1]=node->parent->key[0];
				node->parent->key[0]=node->key[0];
				node->parent->keys=3;
				node->parent->child[3]=node->parent->child[2];
				node->parent->child[2]=node->parent->child[1];
				node->parent->children[3]=node->parent->children[2];
				node->parent->children[2]=node->parent->children[1];
				node->parent->child[1]=node->child[1];
				node->parent->child[0]=node->child[0];
				node->parent->children[0]=node->children[0];
				node->parent->children[1]=node->children[1];
				node->child[0]->parent=node->parent;
				node->child[1]->parent=node->parent;
				delete node;
				return;
			}//if
			if(a==1){
				//case of aNa
				node->parent->key[2]=node->parent->key[1];
				node->parent->key[1]=node->key[0];
				node->parent->keys++;
				node->parent->child[3]=node->parent->child[2];
				node->parent->children[3]=node->parent->children[2];
				node->parent->child[2]=node->child[1];
				node->parent->child[1]=node->child[0];
				node->parent->children[1]=node->children[0];
				node->parent->children[2]=node->children[1];
				node->child[0]->parent=node->parent;
				node->child[1]->parent=node->parent;
				delete node;
				return;
			}//if
			if(a==2){
				//case of aaN
				node->parent->key[2]=node->key[0];
				node->parent->keys++;
				node->parent->child[2]=node->child[0];
				node->parent->child[3]=node->child[1];
				node->parent->children[2]=node->children[0];
				node->parent->children[3]=node->children[1];
				node->child[0]->parent=node->parent;
				node->child[1]->parent=node->parent;
				delete node;
				return;
			}//if
		}//if
		if(node->parent->keys==1){
			if(a==0){
				//case of Na
				node->parent->key[1]=node->parent->key[0];
				node->parent->key[0]=node->key[0];
				node->parent->keys++;
				node->parent->child[2]=node->parent->child[1];
				node->parent->children[2]=node->parent->children[1];
				node->parent->child[1]=node->child[1];
				node->parent->child[0]=node->child[0];
				node->parent->children[0]=node->children[0];
				node->parent->children[1]=node->children[1];
				node->child[0]->parent=node->parent;
				node->child[1]->parent=node->parent;
				delete node;
				return;
			}//if
			if(a==1){
				//case of aN
				node->parent->key[1]=node->key[0];
				node->parent->keys++;
				node->parent->child[2]=node->child[1];
				node->parent->child[1]=node->child[0];
				node->parent->children[1]=node->children[0];
				node->parent->children[2]=node->children[1];
				node->child[0]->parent=node->parent;
				node->child[1]->parent=node->parent;
				delete node;
				return;
			}//if
		}//if
	}//joinNodes()
//-----------------------------------------
	//change node (abc) to be the parent of 2 new nodes ( (b),(a)&(c) )
	void splitNode(c_node *node){
		//create 2 new nodes
		c_node *node1,*node2;
		node1=new c_node();
		node2=new c_node();
		//copy values from current node to new nodes
		node1->keys=1;
		node1->key[0]=node->key[0];
		node1->child[0]=node->child[0];
		node1->child[1]=node->child[1];
		node1->children[0]=node->children[0];
		node1->children[1]=node->children[1];
		if(node1->child[0]!=NULL)node1->child[0]->parent=node1;
		if(node1->child[1]!=NULL)node1->child[1]->parent=node1;

		node2->keys=1;
		node2->key[0]=node->key[2];
		node2->child[0]=node->child[2];
		node2->child[1]=node->child[3];
		node2->children[0]=node->children[2];
		node2->children[1]=node->children[3];
		if(node2->child[0]!=NULL)node2->child[0]->parent=node2;
		if(node2->child[1]!=NULL)node2->child[1]->parent=node2;
		
		//setting current node to hold middle key and the 2 new nodes
		node->keys=1;
		node->key[0]=node->key[1];
		node->key[1]=-9999;		//for debug
		node->key[2]=-9999;		//for debug
		node->child[0]=node1;
		node->child[1]=node2;
		node->child[2]=NULL;
		node->child[3]=NULL;
		node->children[0]=node->child[0]->children[0]+node->child[0]->children[1]+1;
		node->children[1]=node->child[1]->children[0]+node->child[1]->children[1]+1;
		//setting parents to new nodes
		node1->parent=node;
		node2->parent=node;
		//pushing node to parent (node is the parent of new node1 and new node 2)
		joinNodes(node);
	}//splitNode()
//-----------------------------------------
	//go over the tree and return number of nodes (nlog(n))
	long countNodes(c_node *node,bool tReset){
		static long t=0;
		if(tReset)t=0;
		if(node!=NULL){
			t++;
			for(int a=0;(node->child[a]!=NULL)&&(a<4);a++)
				countNodes(node->child[a],false);
		}//if
		return t;
	}//countNodes()
//-----------------------------------------
	//go over the tree and insert all nodes and line number to arrays (nlog(n)),
	//	return number of lines in the tree
	long getAllNodes(c_node *node,long i,c_node *nodeArray[],long nodeLineArray[],bool tReset){
		static long j=1;	//count lines
		static long t=1;	//count nodes
		if(tReset){
			j=1;
			t=1;
		}//if
		if(node!=NULL){
			//insert data
			nodeArray[t]=node;
			nodeLineArray[t]=i;
			t++;
			if(i>j)j=i;
			for(int a=0;(node->child[a]!=NULL)&&(a<4);a++)
				getAllNodes(node->child[a],i+1,nodeArray,nodeLineArray,false);	//recoursive call
		}//if
		return j;
	}//getAllNodes()
//-----------------------------------------
	//print the tree, by lines
	void printTree(){
		long nCnt=countNodes(root,true);			//count number of nodes, to allocate memory
		if(nCnt==0)return;
		c_node **node=new c_node*[nCnt+1];		//to hold nodes
		long *nodeLine=new long[nCnt+1];		//to hols line number
		//insert all nodes and line numbers to arrays
		long lines=getAllNodes(root,1,node,nodeLine,true);
		//print by lines, 
		for(int b=1;b<=lines;b++){
            for(int a=1;a<=nCnt;a++){
				if(nodeLine[a]==b){
					node[a]->printNode();
					cout<<"";
				}//if
			}//for
			cout<<endl;
			cout<<endl;
		}//for
		//cout<<"-------------------"<<endl;
	}//printTree()
//-----------------------------------------
	bool find(long iKey){
		c_node *node=root;
		if(root==NULL)return false;
		while(node!=NULL){
			if(node->keyInNode(iKey))return true;
			node=node->nextNode(iKey);
		}//while
		return false;
	}//find()
//-----------------------------------------
	long findPos(long iKey){
		//check in key exist
		if(!find(iKey))return -1;
		//go to node with iKey, when move right, count all smaller keys
		c_node *node=root;
		long value=0;	
		while(!node->keyInNode(iKey)){
			for(int a=0;a<node->keyIndex(iKey);a++)
				value+=node->children[a];
			value+=node->keyIndex(iKey);
			node=node->child[node->keyIndex(iKey)];
		}//while
		value+=node->keyIndex(iKey);
		for(int a=0;a<=node->keyIndex(iKey);a++)
			value+=node->children[a];
		value+=1;
		return value;
	}//findPos()
//-----------------------------------------
	//return minimum in tree
	long min(c_node *node){
		while(!node->isLeaf()){
			node=node->child[0];
		}//while
		return node->key[0];
	}//min()
//-----------------------------------------
	//return maximum in tree
	long max(c_node *node){
		//right all the way
		while(!node->isLeaf()){
			node=node->child[node->keys];
		}//while
		return node->key[node->keys-1];
	}//max()
//-----------------------------------------
	long successor(long iKey){
		//check for successor exist
		if(max(root)<=iKey)return -1;
		//check that key exist
		if(find(iKey)==false)return -1;
		c_node *node;
		//find node with key
		for(node=root;!node->keyInNode(iKey);node=node->nextNode(iKey));
		//check for right child
		if(node->child[node->keyIndex(iKey)+1]!=NULL){
			//right child exist, get the minimum of right child
			return min(node->child[node->keyIndex(iKey)+1]);
		}else{
			//no right child,check right key
			if(node->keyIndex(iKey)<node->keys-1){
				//right key exist
				return node->key[node->keyIndex(iKey)+1];
			}else{
				//no right key, go up until larger key found
				while(node->parent->keyIndex(iKey)>node->parent->keys-1)
					node=node->parent;
				return node->parent->key[node->parent->keyIndex(iKey)];
			}//if else

		}//if else
	return node->key[node->keyIndex(iKey)];
	}//successor()
//-----------------------------------------
	long predecessor(long iKey){
		//check for predecessor exist
		if(min(root)>=iKey)return -1;
		//check that key exist
		if(find(iKey)==false)return -1;
		c_node *node;
		//find node with key
		for(node=root;!node->keyInNode(iKey);node=node->nextNode(iKey));
		//check for left child
		if(node->child[node->keyIndex(iKey)]!=NULL){
			//left child exist
			return max(node->child[node->keyIndex(iKey)]);
		}else{
			//no left child, check for left key
			if(node->keyIndex(iKey)>0){
				//left key exist
				return node->key[node->keyIndex(iKey)-1];
			}else{
				//no left key, try going up, until smaller key found
				while(node->parent->keyIndex(iKey)==0)
					node=node->parent;
				return node->parent->key[node->parent->keyIndex(iKey)-1];
			}//if else
		}//if else
	return -1;
	}//predecessor()
//-----------------------------------------

//-----------------------------------------
	bool remove(long iKey){
		//check that key exist
		if(find(iKey)==false)return false;
		//key exist
		c_node *node;	
		c_node *iSucNode=root;
		//find node with key
		for(node=root;!node->keyInNode(iKey);node=node->nextNode(iKey));
		//check for key in leaf
		if(!node->isLeaf()){
			//not leaf, replace key with successor key(must be on leaf)
			long iSuc=successor(iKey);
			//find node with iSuc
			for(iSucNode=root;!iSucNode->keyInNode(iSuc);iSucNode=iSucNode->nextNode(iSuc));
			//replace key with successor key
			node->key[node->keyIndex(iKey)]=iSuc;
			iSucNode->key[iSucNode->keyIndex(iSuc)]=iKey;
			node=iSucNode;	//to continue with node
		}//if

		return runRemove(node,iKey);
	}//remove()
//-----------------------------------------
	//remove key from leaf, call fixTree()
	bool runRemove(c_node* node,long iKey){
		//remove the key from the leaf
		for(int a=node->keyIndex(iKey);a<node->keys-1;a++){
			node->key[a]=node->key[a+1];
		}//for
		node->key[a]=-9999;		//for debug, replace deleted key
		node->keys--;
		//check number of keys remain in node, if keys>0 then return
		if(node->keys>0)return true;
		//0 keys,check if node is empty root leaf
		if(node==root){
			delete node;
			root=NULL;
			return true;
		}//if
		//node is not empty root, just empty node leaf
		//go up to look for help
		c_node **cNode=new c_node*;
		fixTree(node,cNode);

		//go back down to node
	}//runRemove();
//-----------------------------------------
	//return node index in parent
	long getNodePos(c_node *node){
		for(int a=0;a<=3;a++){
			if(node==node->parent->child[a]){
				return a;
			}//if
		}//if
	}//getNodePos()
//-----------------------------------------
	c_node *getRetNode(c_node *node){
		for(int a=0;a<=3;a++){
			if(node->retChild[a]==true){
				node->retChild[a]=false;
				return node->child[a];
			}//if
		}//for
	}//getRetChild()
//-----------------------------------------
	//fix empty node(not root), nodePos=position of node(child) in parent(0,1,2,3)
	//	return if there was a fix
	bool fixTree(c_node *node,c_node **cNode){
		//fix up
		//calculate node position from parent
		long nodePos=getNodePos(node);
		//check for left brother
		if(nodePos>0){
			//node has left brother
			if(node->parent->child[nodePos-1]->keys>1){
				//left brother has more then 1 key
				c_node *leftBrother=node->parent->child[nodePos-1];
				scrollKeysToRight(node);
				moveKey(node->parent,nodePos-1,node,0);
				moveChild(leftBrother,leftBrother->keys,node,0);
				moveKey(leftBrother,leftBrother->keys-1,node->parent,nodePos-1);
//				*cNode=node->child[prevPos+1];
				*cNode=getRetNode(node);
				return node->isLeaf();
			}//if
		}//if
		//check for right brother
		if(nodePos<node->parent->keys){
			//node has right brother
			if(node->parent->child[nodePos+1]->keys>1){
                //right brother has more then 1 key
				c_node *rightBrother=node->parent->child[nodePos+1];
				moveKey(node->parent,nodePos,node,node->keys);
				moveKey(rightBrother,0,node->parent,nodePos);
				moveChild(rightBrother,0,node,node->keys);
				scrollKeysToLeft(rightBrother);
//				*cNode=node->child[prevPos];
				*cNode=getRetNode(node);
				return node->isLeaf();
			}//if
		}//if
		//check for parent
		if(node->parent->keys>1){
			//parent has more then 1 key
			if(nodePos>0){
				//has parent key to the left
				c_node *leftBrother=node->parent->child[nodePos-1];
				moveChild(node,0,leftBrother,2);
				moveChild(node,1,leftBrother,3);
				moveKey(node->parent,nodePos-1,leftBrother,1);
				if(node->keys>0)moveKey(node,0,leftBrother,2);

				//scroll right-keys to the left
				for(int a=nodePos-1;a<node->parent->keys;a++){
					node->parent->key[a]=node->parent->key[a+1];
					node->parent->key[a+1];
				}//if
				node->parent->key[node->parent->keys]=-9999;

				//scroll right-child's to the left
				for(int a=nodePos;a<node->parent->keys+1;a++){
					node->parent->child[a]=node->parent->child[a+1];
					node->parent->child[a+1]=NULL;
				}//for
				node->parent->child[node->parent->keys+1]=NULL;

				delete node;
				//generate child to continue fix
//				*cNode=leftBrother->child[prevPos+2];
				*cNode=getRetNode(leftBrother);
				return leftBrother->isLeaf();
			}else{
				//has parent key to the right
				c_node *rightBrother=node->parent->child[nodePos+1];
				scrollKeysToRight(rightBrother);
				scrollKeysToRight(rightBrother);
				moveChild(node,0,rightBrother,0);
				moveChild(node,1,rightBrother,1);
				moveKey(node->parent,nodePos,rightBrother,1);
				if(node->keys>0){
					moveKey(node,0,rightBrother,0);
				}else{
					scrollKeysToLeft(rightBrother);
				}//if else
				//scroll right-keys to the left
				for(int a=nodePos;a<node->parent->keys;a++){
					node->parent->key[a]=node->parent->key[a+1];
					node->parent->key[a+1];
				}//if
				node->parent->key[node->parent->keys]=-9999;

				//scroll right-child's to the left
				for(int a=nodePos;a<node->parent->keys+1;a++){
					node->parent->child[a]=node->parent->child[a+1];
					node->parent->child[a+1]=NULL;
				}//for
				node->parent->child[node->parent->keys+1]=NULL;

				//generate child to continue fix
//				*cNode=rightBrother->child[prevPos];
				*cNode=getRetNode(rightBrother);
				delete node;
				return rightBrother->isLeaf();
			}//if else
		}//if
		//check if parent is root (with 1 key only)
		if(node->parent==root){
			//parent is root with 1 key
			//	(otherwise it was being treated like parent with 2 or more keys)
			if(nodePos>0){
				//has parent key to the left
				c_node *leftBrother=node->parent->child[nodePos-1];
				moveChild(node,0,leftBrother,2);
				moveChild(node,1,leftBrother,3);
				moveKey(node->parent,nodePos-1,leftBrother,1);
				if(node->keys>0)moveKey(node,0,leftBrother,2);
				delete root;
				delete node;
				leftBrother->parent=NULL;
				root=leftBrother;
				//generate child to continue fix
//				*cNode=leftBrother->child[prevPos+2];
				*cNode=getRetNode(leftBrother);
				return leftBrother->isLeaf();
			}else{
				//has parent key to the right
				c_node *rightBrother=node->parent->child[nodePos+1];
				scrollKeysToRight(rightBrother);
				scrollKeysToRight(rightBrother);
				moveChild(node,0,rightBrother,0);
				moveChild(node,1,rightBrother,1);
				moveKey(node->parent,nodePos,rightBrother,1);
				if(node->keys>0){
					moveKey(node,0,rightBrother,0);
				}else{
					scrollKeysToLeft(rightBrother);
				}//if else
				//scroll right-keys to the left
				for(int a=nodePos;a<node->parent->keys;a++){
					node->parent->key[a]=node->parent->key[a+1];
					node->parent->key[a+1];
				}//if
				node->parent->key[node->parent->keys]=-9999;

				//scroll right-child's to the left
				for(int a=nodePos;a<node->parent->keys+1;a++){
					node->parent->child[a]=node->parent->child[a+1];
					node->parent->child[a+1]=NULL;
				}//for
				node->parent->child[node->parent->keys+1]=NULL;

				delete root;
				delete node;
				rightBrother->parent=NULL;
				root=rightBrother;
				//generate child to continue fix
//				*cNode=rightBrother->child[prevPos];
				*cNode=getRetNode(rightBrother);
				return rightBrother->isLeaf();
			}//if else
		}//if

		//no fix, go up
		node->parent->retChild[nodePos]=true;
		bool returnValue=fixTree(node->parent,cNode);
        
		//go down to leaf, to finish fix
		while(!returnValue){
            returnValue=fixTree(*cNode,cNode);
		}//while
	}//fixTree()
//-----------------------------------------
	//scroll keys and childs in node to the right
	void scrollKeysToRight(c_node *node){
		for(int a=2;a>0;a--){
			node->key[a]=node->key[a-1];
			node->key[a-1]=-9999;
		}//for
		for(int a=3;a>0;a--){
			node->child[a]=node->child[a-1];
			node->retChild[a]=node->retChild[a-1];
			node->child[a-1]=NULL;
			node->retChild[a-1]=false;
		}//for
	}//scrollKeysToRight
//-----------------------------------------
	//scroll keys and childs in node to the left (loose left most key and child)
	void scrollKeysToLeft(c_node *node){
		for(int a=0;a<2;a++){
			node->key[a]=node->key[a+1];
			node->key[a+1]=-9999;
		}//for
		for(int a=0;a<3;a++){
			node->child[a]=node->child[a+1];
			node->retChild[a]=node->retChild[a+1];
			node->child[a+1]=NULL;
			node->retChild[a+1]=false;
		}//for
	}//scrollKeysToLeft
//-----------------------------------------
	//move key between nodes,update keys
	void moveKey(c_node *fromNode,long fromIndex,c_node *toNode,long toIndex){
		toNode->key[toIndex]=fromNode->key[fromIndex];
		fromNode->key[fromIndex]=-9999;
		toNode->keys++;
		fromNode->keys--;
	}//moveKey()

	//move child between nodes
	void moveChild(c_node *fromNode,long fromIndex,c_node *toNode,long toIndex){
		toNode->child[toIndex]=fromNode->child[fromIndex];
		toNode->retChild[toIndex]=fromNode->retChild[fromIndex];
		if(fromNode->child[fromIndex]!=NULL){
			fromNode->child[fromIndex]->parent=toNode;
		}//if
		fromNode->child[fromIndex]=NULL;
		fromNode->retChild[fromIndex]=false;
	}//moveChild()
};//class tree234
