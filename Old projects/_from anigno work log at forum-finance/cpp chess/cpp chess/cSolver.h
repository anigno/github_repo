//best move
//worst move
//selected move
//evaluation differentioal between prev board and after selected move board
//if selected move is less then 50% from best move, do best selected average move
//if best move is bigger then average move alot, do best move

class cSolver{

public:
	cState* state;
	char currentPlayer;
	char otherPlayer;
	cMove* selectedMove;
	int initialDepth;
	bool kingDanger;
	int maxDepth;
	int currentDepth;
	bool terminate;
	cTimer timer;
	long maxTime;
	cMove* gameQueue[1000];
	int gameQueueIndex;
	int winner;
	ofstream *fout;

	cSolver(cState* state,int currentPlayer,ofstream* fout){
		this->fout=fout;
		this->state=state;
		this->currentPlayer=currentPlayer;
		this->otherPlayer=(currentPlayer+1)%2;
		selectedMove=NULL;
		gameQueueIndex=0;
		winner=0;
	}//cSolver()

	//change current state player
	void changePlayer(){
		currentPlayer=(currentPlayer+1)%2;
		otherPlayer=(otherPlayer+1)%2;
	}//changePlayer()

	void setPlayingPlayer(char player){
		currentPlayer=player;
		otherPlayer=(player+1)%2;
	}//setPlayingPlayer

	cList* generateLegalMoves(char player){
		cList* ret=new cList();
		for(int i=0;i<16;i++){
			if(state->toolList[player][i]->alive==true){
				ret->join(state->toolList[player][i]->generateLegalMoves(state->boardData));
			}//if
		}//for
		return ret;
	}//generateLegalMoves()

	void makeMove(cMove* move){
		if(move==NULL){
			int t=0;
		};
		cTool* tool=(cTool*)move->tool;
		cTool* killedTool=(cTool*)move->killedTool;
		//move the tool
		tool->y=move->newY;
		tool->x=move->newX;
		tool->pawnZeroPos++;
		if(tool->type==pawn){
			if( (tool->y==0+2)||(tool->y==7+2) ){
				//must ask user to choose new tool
				tool->setToolType(queen);
				move->pawnChanged++;
			}//if
		}//if
		if(killedTool!=NULL){
			killedTool->alive=false;
		}//if
		//change posData
		state->boardData->posData[move->oldY][move->oldX]=5;
		state->boardData->posData[move->newY][move->newX]=tool->player;
		//change toolData
		state->boardData->toolData[move->oldY][move->oldX]=NULL;
		state->boardData->toolData[move->newY][move->newX]=tool;

		//printMove(move);
		//cout<<state->toolString();
	}//makeMove()

	void unMakeMove(cMove* move){
		cTool* tool=(cTool*)move->tool;
		cTool* killedTool=(cTool*)move->killedTool;
		//move the tool
		tool->y=move->oldY;
		tool->x=move->oldX;
		if(move->pawnChanged>0){
			move->pawnChanged--;
			tool->setToolType(pawn);
		}//if
		if(killedTool!=NULL)killedTool->alive=true;
		//change posData
		state->boardData->posData[move->oldY][move->oldX]=tool->player;
		state->boardData->posData[move->newY][move->newX]=5;
		if(killedTool!=NULL)state->boardData->posData[move->newY][move->newX]=killedTool->player;
		//change toolData
		state->boardData->toolData[move->oldY][move->oldX]=tool;
		state->boardData->toolData[move->newY][move->newX]=killedTool;
	}//unMakeMove()

	
	double evaluate(){
		int ret=0;
			//king dead is very bad
			if(state->toolList[currentPlayer][0]->alive==false)ret=ret-9999;
			for(int i=0;i<16;i++)
			{
				//how many player in my team alive
				if(state->toolList[currentPlayer][i]->alive==true)
				{
					ret+=(state->toolList[currentPlayer][i]->cost);//*2;
				}
				//how many players did i kill
				if(state->toolList[otherPlayer][i]->alive==true)
				{
					ret-=state->toolList[otherPlayer][i]->cost;
				}
				//pawn forward is good (other pawn forward is bad!)
				if(state->toolList[currentPlayer][i]->type==pawn){
					if(currentPlayer==0){
						ret+=(8-state->toolList[0][i]->y)*4;
						ret-=(state->toolList[1][i]->y-2);
					}else{
						ret-=(8-state->toolList[0][i]->y)*4;
						ret+=(state->toolList[1][i]->y-1);
					}//if else
				}//if
				//diagonal pawns to gard each other
				if(state->toolList[currentPlayer][i]->type==pawn){
					if(currentPlayer==0){
						int gy=state->toolList[currentPlayer][i]->y;
						int gx=state->toolList[currentPlayer][i]->x;
						if(state->boardData->posData[gy+1][gx-1]==currentPlayer)ret+=1;
						if(state->boardData->posData[gy+1][gx+1]==currentPlayer)ret+=1;
					}else{
						int gy=state->toolList[currentPlayer][i]->y;
						int gx=state->toolList[currentPlayer][i]->x;
						if(state->boardData->posData[gy-1][gx-1]==currentPlayer)ret+=1;
						if(state->boardData->posData[gy-1][gx+1]==currentPlayer)ret+=1;
					}//if else
				}//if

			//king is making defence
				int maxD=0;
				int d;
				if(state->toolList[currentPlayer][i]->type==pawn){
					if(currentPlayer==0){
						//ret+=state->toolList[otherPlayer][i]->x-state->toolList[currentPlayer][0]->x*rand()/16000;
					}else{
						//ret+=-state->toolList[otherPlayer][i]->x+state->toolList[currentPlayer][0]->x;
					}//if else
				}//if
			}//for
			return ret;
	}//evaluate()

	cMove* runAlphaBeta(int maxDepth,long maxTime){
		cMove* returnMove;
		this->currentDepth=1;
		this->maxTime=maxTime;
		terminate=false;
		this->maxDepth=maxDepth;
		selectedMove=NULL;
		kingDanger=false;
		timer.reset();
		//minimum move generator
		runAlpha(this->currentDepth,-9999,9999);
		returnMove=selectedMove;
		while(terminate==false){
			runAlpha(currentDepth,-9999,9999);
			if(terminate==false){
				returnMove=selectedMove;
				if(returnMove!=NULL){
					*fout<<currentDepth<<" ";
					printMove(returnMove);
					fPrintMove(returnMove,fout);
				}//if
			}//if
			this->currentDepth+=2;	//iterative deepening
		}//while
		//gameQueue[gameQueueIndex++]=returnMove;
		//three same steps
		if(gameQueueIndex>3){
			//cTool* t=(cTool*)gameQueue[gameQueueIndex-1]->tool;
		}//if
		return returnMove;
	}//runAlphaBeta()
	
	double runAlpha(int depth,int alpha,int beta){
		int ret;
		cList* legalMoves;
		cMove* move;
		if(depth==0)return evaluate();
		legalMoves=generateLegalMoves(currentPlayer);
		if(legalMoves->count==0)return -9999;
		for(cListNode* it=legalMoves->startNode;it!=NULL;it=it->next){
			if(timer.get()>maxTime)terminate=true;
			if(terminate==true)return -9999;
			move=(cMove*)it->data;
			makeMove(move);
			ret=runBeta(depth-1,alpha,beta);
			if(ret>alpha){
				alpha=ret;
				if(depth==currentDepth){
					//delete selectedMove;
					selectedMove=new cMove(move->tool,move->oldY,move->oldX,move->newY,move->newX);
					selectedMove->killedTool=move->killedTool;
					selectedMove->pawnChanged=move->pawnChanged;
				}//if
			}//if
			unMakeMove(move);
			if(alpha>=beta)break;
		}//for
		for(cListNode* it=legalMoves->startNode;it!=NULL;it=it->next){
			delete (cMove*)it->data;
		}//for
		delete legalMoves;
		return alpha;
	}//runAlpha()

	double runBeta(int depth,int alpha,int beta){
		int ret;
		cList* legalMoves;
		cMove* move;
		if(depth==0)return evaluate();
		legalMoves=generateLegalMoves(otherPlayer);
		if(legalMoves->count==0)return -9999;
		for(cListNode* it=legalMoves->startNode;it!=NULL;it=it->next){
			if(timer.get()>maxTime)terminate=true;
			if(terminate==true)return -9999;
			move=(cMove*)it->data;
			makeMove(move);
			if (state->toolList[currentPlayer][0]->alive==false)
			{
				unMakeMove(move);
				return -9999; 
			}
			
			ret=runAlpha(depth-1,alpha,beta);
			if(ret<=beta){
				beta=ret;
			}//if
			unMakeMove(move);
			if(alpha>=beta)break;
		}//for
		for(cListNode* it=legalMoves->startNode;it!=NULL;it=it->next){
			delete (cMove*)it->data;
		}//for
		delete legalMoves;
		return beta;
	}//runBeta()



};//class cSolver