//general utillities functions
#include <fstream>
using namespace std;
void printMove(cMove* move){
	cTool* tool=(cTool*)move->tool;
	cTool* killedTool=(cTool*)move->killedTool;
	cout<<"tool:"<<tool->toolLetter<<tool->player+0<<" id:"<<tool->id+0;
	if(killedTool!=NULL)
		cout<<" "<<"killedTool:"<<killedTool->toolLetter<<killedTool->player+0<<" id:"<<killedTool->id+0<<" ";
	else
		cout<<" "<<"killedTool:"<<"__ id:__ ";
	cout<<"old(y,x):"<<move->oldY-2<<","<<move->oldX-2<<" ";
	cout<<"new(y,x):"<<move->newY-2<<","<<move->newX-2<<" ";
	cout<<endl;
}//printMove()

void fPrintMove(cMove* move,ofstream* fout){
	cTool* tool=(cTool*)move->tool;
	cTool* killedTool=(cTool*)move->killedTool;
	*fout<<"tool:"<<tool->toolLetter<<tool->player+0<<" id:"<<tool->id+0;
	if(killedTool!=NULL)
		*fout<<" "<<"killedTool:"<<killedTool->toolLetter<<killedTool->player+0<<" id:"<<killedTool->id+0<<" ";
	else
		*fout<<" "<<"killedTool:"<<"__ id:__ ";
	*fout<<"old(y,x):"<<move->oldY-2<<","<<move->oldX-2<<" ";
	*fout<<"new(y,x):"<<move->newY-2<<","<<move->newX-2<<" ";
	*fout<<endl;
}//fPrintMove()


void printMoveList(cList* list){
	cMove* move;
	for(cListNode* it=list->startNode;it!=NULL;it=it->next){
		move=(cMove*)it->data;
		printMove(move);
	}//for
	cout<<"move count:"<<move->count<<endl;
}//printMoveList()

int getRand(int min,int max){
	double ret=rand();
	ret=min+ret*(max-min+1)/32768;
	return (int)ret;
}//getRand();