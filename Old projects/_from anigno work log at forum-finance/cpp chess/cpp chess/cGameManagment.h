#include <fstream>
using namespace std;

class cGameManagment{
public:
	GameType gameType;
	long totalGameTime;
	long totalTimeLeft;
	long moveTime;
	PlayerType playerType[2];
	int playingPlayer;
	bool gameOver;
	cMove* nextMove;
	cState* state;
	cSolver* solver;
	cTimer timer;
	int winner;
	SocketClient* client;
	ofstream* fout;
	
	cGameManagment(GameType gameType,long gameTime){
		fout=new ofstream();
		fout->open("2.txt");
		gameOver=false;
		state=new cState();
		solver=new cSolver(state,0,fout);
		playingPlayer=0;
		this->gameType=gameType;
		this->totalGameTime=gameTime;
		winner=0;
		initGame();
	}//cGameManagment()

	string waitForMessage(string message){
		string s;
		if(message=="move"){
			do{
				s=client->ReceiveLine();
			}while(s.length()<5);
			return s;
		}//if
		do{
			s=client->ReceiveLine();
		}while(s.substr(0,message.length())!=message);
		return message;
	}//waiyForMessage();

	void initNetConnection(){
		string s;
		client=new SocketClient("127.0.0.1",2000);
		s=waitForMessage("Welcome");
		s=waitForMessage("Begin");
	}//initNetConnection

	void initGame(){
		if(gameType==compComp){
			playerType[0]=compPlayer;
			playerType[1]=compPlayer;
		}//if
		if(gameType==netComp){
			playerType[0]=netPlayer;
			playerType[1]=compPlayer;
			initNetConnection();
		}//if
		if(gameType==compNet){
			playerType[0]=compPlayer;
			playerType[1]=netPlayer;
			initNetConnection();
		}//if
		if(gameType==compHuman){
			playerType[0]=compPlayer;
			playerType[1]=humanPlayer;
		}//if
		if(gameType==humanComp){
			playerType[0]=humanPlayer;
			playerType[1]=compPlayer;
		}//if
		timer.reset();
	}//initGame()

	long getMoveTime(){
		return totalTimeLeft/140;
	}//getMoveTime()

	cMove* createMoveFromInput(const char* input){
		char oy=11-(input[1]-49+2);
		char ox=input[0]-65+2;
		char ny=11-(input[4]-49+2);
		char nx=input[3]-65+2;
		cTool* tool=(cTool*)state->boardData->toolData[oy][ox];
		cMove* retMove=new cMove(tool,oy,ox,ny,nx);
		retMove->killedTool=state->boardData->toolData[ny][nx];
		if(ny==2 || ny==9)tool->type=queen;
		return retMove;
	}//createMoveFromInput()

	void runner(){
		totalTimeLeft=totalGameTime;
		long moveSliceTime;
		string s;
		while(!gameOver){
			cout<<state->toolString()<<endl;
			*fout<<state->toolString()<<endl;
			
			if(playerType[playingPlayer]==compPlayer){
				solver->setPlayingPlayer(playingPlayer);
				moveSliceTime=getMoveTime()*1000;
				nextMove=solver->runAlphaBeta(15,moveSliceTime);
			}//if

			if(playerType[playingPlayer]==humanPlayer){
				cout<<"enter your move:"<<endl;
				char input[10];
				cin>>input;
				if(strcmp(input,"quit")==0)exit(1);
				nextMove=createMoveFromInput(input);
			}//if

			if(playerType[playingPlayer]==netPlayer){
				s=client->ReceiveLine();
				s=s.substr(0,5);
				nextMove=createMoveFromInput(s.c_str());
			}//if

			
//			totalTimeLeft=totalGameTime-timer.get()/1000;
			solver->makeMove(nextMove);
			
			//check for mat
			if(state->toolList[0][0]->alive==false){
				winner=1;
				gameOver=true;
			}//if
			if(state->toolList[1][0]->alive==false){
				winner=0;
				gameOver=true;
			}//if
			//cout<<"time left: "<<totalTimeLeft<<endl;
			//printMove(nextMove);
			//cout<<"depth="<<solver->currentDepth-4<<endl;
			playingPlayer=(playingPlayer+1)%2;
		}//while
		cout<<"winner: "<<winner<<endl;
		*fout<<"winner: "<<winner<<endl;

	}//runner()
	

};//class cGameManagment