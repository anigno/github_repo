#include<iostream.h>
#include<stdlib.h>
#include<fstream.h>
#include"tree234.h"

void main(){
c_tree234 tree;
ifstream inputFile("action.txt");
long action,data;
bool fileIsOpen=true;
while(1){
	if(inputFile.eof())fileIsOpen=false;
	//check if file is still open, if not take commands from keyboard 
	if(fileIsOpen){
		inputFile>>action;
	}else{
		cout<<"command:"<<endl;
		cin>>action;
	}//if else
	if(action==1||action==2||action==3||action==4||action==5||action==7||action==9){
		if(fileIsOpen){
			inputFile>>data;
		}else{
			cout<<"data:"<<endl;
			cin>>data;
		}//if else
	}//if
	if(action==0)return;
	if(action==1)tree.insert(data);
	if(action==2)tree.remove(data);
	if(action==3){
		if(tree.find(data)){
            cout<<data<<" is in tree"<<endl;
		}else{
			cout<<data<<" is not in tree"<<endl;
		}//if else
	}//if
	if(action==4){
		cout<<"successor of "<<data<<" is "<<tree.successor(data)<<endl;
	}
	if(action==5)cout<<"predecessor of "<<data<<" is "<<tree.predecessor(data)<<endl;
	if(action==6)cout<<"minimum is "<<tree.min(tree.root)<<endl;
	if(action==7)cout<<"maximum is "<<tree.max(tree.root)<<endl;
	if(action==8)tree.printTree();
	if(action==9)cout<<"sorry, no findPos!"<<endl;
}//while(1)
}//main()