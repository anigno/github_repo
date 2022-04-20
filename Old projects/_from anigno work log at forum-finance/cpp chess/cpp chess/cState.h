using namespace std;
class cState{
public:
	char currentPlayer;
	char otherPlayer;
	cTool* toolList[2][16];	//the tools of both players
	cBoardData* boardData;	//data matrix's that holds the state
	
	//ctor
	cState(){
		currentPlayer=0;
		otherPlayer=1;
		boardData=new cBoardData();
		//init board boundries (9) and toolData (NULL)
		for(int y=0;y<12;y++){
			for(int x=0;x<12;x++){
				boardData->posData[y][x]=9;
				boardData->toolData[y][x]=NULL;
			}//for
		}//for
		//init inner board to free (5)
		for(int y=2;y<10;y++){
			for(int x=2;x<10;x++){
				boardData->posData[y][x]=5;
			}//for
		}//for
		//init toolList data (NULL)
		for(int i=0;i<16;i++){
			toolList[0][i]=NULL;
			toolList[1][i]=NULL;
		}//for
		toolList[0][0]=new cTool(0,king,7+2,4+2);	toolList[0][0]->alive=true;
		toolList[0][1]=new cTool(0,queen,7+2,3+2);	toolList[0][1]->alive=false;
		toolList[0][2]=new cTool(0,bishop,7+2,2+2);	toolList[0][2]->alive=false;
		toolList[0][3]=new cTool(0,bishop,7+2,5+2);	toolList[0][3]->alive=false;
		toolList[0][4]=new cTool(0,knight,7+2,1+2);	toolList[0][4]->alive=false;
		toolList[0][5]=new cTool(0,knight,7+2,6+2);	toolList[0][5]->alive=false;
		toolList[0][6]=new cTool(0,rook,7+2,7+2);	toolList[0][6]->alive=false;
		toolList[0][7]=new cTool(0,rook,7+2,0+2);	toolList[0][7]->alive=false;
		for(int i=0;i<=7;i++){
			toolList[0][i+8]=new cTool(0,pawn,6+2,i+2);
			toolList[0][i+8]->alive=true;
		}//for

		toolList[1][0]=new cTool(1,king,0+2,4+2);	toolList[1][0]->alive=true;
		toolList[1][1]=new cTool(1,queen,0+2,3+2);	toolList[1][1]->alive=false;
		toolList[1][2]=new cTool(1,bishop,0+2,2+2);	toolList[1][2]->alive=false;
		toolList[1][3]=new cTool(1,bishop,0+2,5+2);	toolList[1][3]->alive=false;
		toolList[1][4]=new cTool(1,knight,0+2,1+2);	toolList[1][4]->alive=false;
		toolList[1][5]=new cTool(1,knight,0+2,6+2);	toolList[1][5]->alive=false;
		toolList[1][6]=new cTool(1,rook,0+2,7+2);	toolList[1][6]->alive=false;
		toolList[1][7]=new cTool(1,rook,0+2,0+2);	toolList[1][7]->alive=false;
		for(int i=0;i<=7;i++){
			toolList[1][i+8]=new cTool(1,pawn,1+2,i+2);
			toolList[1][i+8]->alive=true;
		}//for

		//test
			//toolList[0][1+8]->alive=true;
			//toolList[0][1+8]->y=2+7;
			//toolList[0][1+8]->x=2+0;
			//toolList[0][1+8]->pawnZeroPos=1;

			//toolList[0][2+8]->alive=true;
			//toolList[0][2+8]->y=2+4;
			//toolList[0][2+8]->x=2+4;
			//toolList[0][2+8]->pawnZeroPos=1;

			//toolList[1][2+8]->alive=true;
			//toolList[1][2+8]->y=2+0;
			//toolList[1][2+8]->x=2+0;
			//toolList[1][2+8]->pawnZeroPos=1;

			//toolList[1][1+8]->alive=true;
			//toolList[1][1+8]->y=2+2;
			//toolList[1][1+8]->x=2+3;
			//toolList[1][1+8]->pawnZeroPos=1;
			




		//copy tool data to board data
		for(int i=0;i<16;i++){
			cTool* t=toolList[0][i];
			if( (t!=NULL)&&(t->alive==true)){
				boardData->posData[t->y][t->x]=0;
				boardData->toolData[t->y][t->x]=t;
			}//if
			t=toolList[1][i];
			if((t!=NULL)&&(t->alive==true)){
				boardData->posData[t->y][t->x]=1;
				boardData->toolData[t->y][t->x]=t;
			}//if
		}//for
	}//cState()

	//change current state player
	void changePlayer(){
		currentPlayer=(currentPlayer+1)%2;
		otherPlayer=(otherPlayer+1)%2;
	}//changePlayer()

	//return printable string of the board tools
	string toolString(){
		string ret="";
		for(int y=0;y<12;y++){
			for(int x=0;x<12;x++){
				if(boardData->posData[y][x]==9)ret+="** ";
				if(boardData->posData[y][x]==5){
					if( (y%2)!=(x%2) )
						ret+="|| ";
					else
						ret+="-- ";
				}//if
				if(boardData->posData[y][x]==0)ret+=((cTool*)boardData->toolData[y][x])->toString()+" ";
				if(boardData->posData[y][x]==1)ret+=((cTool*)boardData->toolData[y][x])->toString()+" ";
			}//for
			ret+="\n";
		}//for
		ret+="\n";
		return ret;
	}//toString()

	//return printable string of the board tools owners
	string posString(){
		string ret="";
		for(int y=0;y<12;y++){
			for(int x=0;x<12;x++){
				if(boardData->posData[y][x]==9)ret+="** ";
				if(boardData->posData[y][x]==5)ret+="-- ";
				if(boardData->posData[y][x]==0)ret+="0  ";
				if(boardData->posData[y][x]==1)ret+="1  ";
			}//for
			ret+="\n";
		}//for
		ret+="\n";
		return ret;
	}//toString()

};//class cState