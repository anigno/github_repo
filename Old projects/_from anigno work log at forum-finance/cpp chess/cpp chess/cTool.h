using namespace std;

class cTool{
public:
	static char uniqueId;	//id generator
	char id;			//tool unique id within all tools
	char player;		//the owner of this tool
	char otherPlayer;	//the other player
	toolType type;		//the type of this tool (may change during game!)
	int cost;			//the heuristics value for this tool
	char y,x;			//tool's position
	bool alive;			//is this tool alive
	char pawnZeroPos;	//if pawn, is it in it's zero position or already moved
	char toolLetter;	//printing letter for this tool
private:
	char ty[8];char tx[8];bool tb[8];	//move generator vars
public:
	
	//set the tool's type and cost
	void setToolType(toolType type){
		switch(type){
			case king:
				type=king;
				toolLetter='K';
				cost=1000;
				break;
			case queen:
				this->type=queen;
				this->toolLetter='Q';
				this->cost=30;
				break;
			case bishop:
				this->type=bishop;
				toolLetter='B';
				cost=20;
				break;
			case knight:
				this->type=knight;
				toolLetter='H';
				cost=20;
				break;
			case rook:
				this->type=rook;
				toolLetter='R';
				cost=20;
				break;
			case pawn:
				this->type=pawn;
				toolLetter='P';
				cost=10;
				break;
		}//switch
	}//setToolType()

	//ctor
	cTool(char player,toolType type,char y,char x){
		this->id=uniqueId++;
		this->player=player;
		this->otherPlayer=(player+1)%2;
		this->type=type;
		this->cost=cost;
		this->y=y;
		this->x=x;
		alive=true;
		pawnZeroPos=0;
		setToolType(type);
	}//cTool()

	//return printable string for this tool
	string toString(){
		string ret="";
		ret+=toolLetter;
		if(player==0)ret+='0';else ret+='1';
		return ret;
	}//toString()

private:
	//all unique move generators for the different tools
	cList* kingMoveGenerator(cBoardData* boardData){
		cList* ret=new cList();
		ty[0]=y-1;tx[0]=x-1;
		ty[1]=y-1;tx[1]=x;
		ty[2]=y-1;tx[2]=x+1;
		ty[3]=y;tx[3]=x-1;
		ty[4]=y;tx[4]=x+1;
		ty[5]=y+1;tx[5]=x-1;
		ty[6]=y+1;tx[6]=x;
		ty[7]=y+1;tx[7]=x+1;
		for(int i=0;i<=7;i++){
			if(boardData->posData[ty[i]][tx[i]]==5){
				cMove* move=new cMove(this,y,x,ty[i],tx[i]);
				ret->add(move);
			}//if
			if(boardData->posData[ty[i]][tx[i]]==otherPlayer){
				cMove* move=new cMove(this,y,x,ty[i],tx[i]);
				move->killedTool=boardData->toolData[ty[i]][tx[i]];
				ret->add(move);
			}//if
		}//for
		return ret;
	}//kingMoveGenerator()
	
	cList* knightMoveGenerator(cBoardData* boardData){
		cList* ret=new cList();
		ty[0]=y-1;tx[0]=x-2;
		ty[1]=y-2;tx[1]=x-1;
		ty[2]=y-2;tx[2]=x+1;
		ty[3]=y-1;tx[3]=x+2;
		ty[4]=y+1;tx[4]=x+2;
		ty[5]=y+2;tx[5]=x+1;
		ty[6]=y+2;tx[6]=x-1;
		ty[7]=y+1;tx[7]=x-2;
		for(int i=0;i<=7;i++){
			if(boardData->posData[ty[i]][tx[i]]==5){
				cMove* move=new cMove(this,y,x,ty[i],tx[i]);
				ret->add(move);
			}//if
			if(boardData->posData[ty[i]][tx[i]]==otherPlayer){
				cMove* move=new cMove(this,y,x,ty[i],tx[i]);
				move->killedTool=boardData->toolData[ty[i]][tx[i]];
				ret->add(move);
			}//if
		}//for
		return ret;
	}//knightMoveGenerator()

	cList* pawnMoveGenerator(cBoardData* boardData){
		cList* ret=new cList();
		int dir=player*2-1;
		ty[0]=y+dir;tx[0]=x;
		ty[1]=y+2*dir;tx[1]=x;
		ty[2]=y+dir;tx[2]=x-1;
		ty[3]=y+dir;tx[3]=x+1;
		//one step to free (5) space
		if(boardData->posData[ty[0]][tx[0]]==5){
			cMove* move=new cMove(this,y,x,ty[0],tx[0]);
			ret->add(move);
			//two step to free (5) space on zero pos
			if(pawnZeroPos==0){
				if(boardData->posData[ty[1]][tx[1]]==5){
					cMove* move=new cMove(this,y,x,ty[1],tx[1]);
					ret->add(move);
				}//if
			}//if
		}//if
		//left and right diagonal
		if(boardData->posData[ty[2]][tx[2]]==otherPlayer){
			cMove* move=new cMove(this,y,x,ty[2],tx[2]);
			move->killedTool=boardData->toolData[ty[2]][tx[2]];
			ret->add(move);
		}//if
		if(boardData->posData[ty[3]][tx[3]]==otherPlayer){
			cMove* move=new cMove(this,y,x,ty[3],tx[3]);
			move->killedTool=boardData->toolData[ty[3]][tx[3]];
			ret->add(move);
		}//if
		return ret;
	}//pawnMoveGenerator

	cList* QueenMoveGenerator(cBoardData* boardData){
		cList* ret=new cList();
		tb[0]=tb[1]=tb[2]=tb[3]=tb[4]=tb[5]=tb[6]=tb[7]=true;
		for(int i=1;i<=8;i++){
			ty[0]=y,tx[0]=x-i;
			ty[1]=y-i,tx[1]=x-i;
			ty[2]=y-i,tx[2]=x;
			ty[3]=y-i,tx[3]=x+i;
			ty[4]=y,tx[4]=x+i;
			ty[5]=y+i,tx[5]=x+i;
			ty[6]=y+i,tx[6]=x;
			ty[7]=y+i,tx[7]=x-i;
			for(int j=0;j<=7;j++){
				if(tb[j]==true){
					if(boardData->posData[ty[j]][tx[j]]==5){
						//new move to free space
						cMove* move=new cMove(this,y,x,ty[j],tx[j]);
						ret->add(move);
					}//for
					if(boardData->posData[ty[j]][tx[j]]==player){
						//blocked by player
						tb[j]=false;
					}//for
					if(boardData->posData[ty[j]][tx[j]]==otherPlayer){
						tb[j]=false;
						//new kill
						cMove* move=new cMove(this,y,x,ty[j],tx[j]);
						move->killedTool=boardData->toolData[ty[j]][tx[j]];
						ret->add(move);
					}//for
					if(boardData->posData[ty[j]][tx[j]]==9){
						//out of boundries
						tb[j]=false;
					}//for
				}//if
			}//for
		}//for
		return ret;
	}//QueenMoveGenerator()

	cList* BishopMoveGenerator(cBoardData* boardData){
		cList* ret=new cList();
		tb[0]=tb[1]=tb[2]=tb[3]=tb[4]=tb[5]=tb[6]=tb[7]=true;
		for(int i=1;i<=8;i++){
			ty[0]=y-i,tx[0]=x-i;
			ty[1]=y-i,tx[1]=x+i;
			ty[2]=y+i,tx[2]=x+i;
			ty[3]=y+i,tx[3]=x-i;
			for(int j=0;j<=3;j++){
				if(tb[j]==true){
					if(boardData->posData[ty[j]][tx[j]]==5){
						//new move to free space
						cMove* move=new cMove(this,y,x,ty[j],tx[j]);
						ret->add(move);
					}//for
					if(boardData->posData[ty[j]][tx[j]]==player){
						//blocked by player
						tb[j]=false;
					}//for
					if(boardData->posData[ty[j]][tx[j]]==otherPlayer){
						tb[j]=false;
						//new kill
						cMove* move=new cMove(this,y,x,ty[j],tx[j]);
						move->killedTool=boardData->toolData[ty[j]][tx[j]];
						ret->add(move);
					}//for
					if(boardData->posData[ty[j]][tx[j]]==9){
						//out of boundries
						tb[j]=false;
					}//for
				}//if
			}//for
		}//for
		return ret;
	}//BishopMoveGenerator()

	cList* RookMoveGenerator(cBoardData* boardData){
		cList* ret=new cList();
		tb[0]=tb[1]=tb[2]=tb[3]=tb[4]=tb[5]=tb[6]=tb[7]=true;
		for(int i=1;i<=8;i++){
			ty[0]=y,tx[0]=x-i;
			ty[1]=y-i,tx[1]=x;
			ty[2]=y,tx[2]=x+i;
			ty[3]=y+i,tx[3]=x;
			for(int j=0;j<=3;j++){
				if(tb[j]==true){
					if(boardData->posData[ty[j]][tx[j]]==5){
						//new move to free space
						cMove* move=new cMove(this,y,x,ty[j],tx[j]);
						ret->add(move);
					}//for
					if(boardData->posData[ty[j]][tx[j]]==player){
						//blocked by player
						tb[j]=false;
					}//for
					if(boardData->posData[ty[j]][tx[j]]==otherPlayer){
						tb[j]=false;
						//new kill
						cMove* move=new cMove(this,y,x,ty[j],tx[j]);
						move->killedTool=boardData->toolData[ty[j]][tx[j]];
						ret->add(move);
					}//for
					if(boardData->posData[ty[j]][tx[j]]==9){
						//out of boundries
						tb[j]=false;
					}//for
				}//if
			}//for
		}//for
		return ret;
	}//RookMoveGenerator()

public:
	//global move generator function
	cList* generateLegalMoves(cBoardData* boardData){
		switch(type){
			case king:
				return kingMoveGenerator(boardData);
				break;
			case queen:
				return QueenMoveGenerator(boardData);
				break;
			case bishop:
				return BishopMoveGenerator(boardData);
				break;
			case knight:
				return knightMoveGenerator(boardData);
				break;
			case rook:
				return RookMoveGenerator(boardData);
				break;
			case pawn:
				return pawnMoveGenerator(boardData);
				break;
		}//switch
		return NULL;
	}//generateLegalMoves()
};//class cTool
char cTool::uniqueId=10;