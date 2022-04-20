using namespace std;
class cMove{
public:
	static long count;	//used for cleaning checking of the damn cpp
	void* tool;			//the actual tool that do the move
	void* killedTool;	//if not NULL, it is the killed tool by the moving tool
	char oldY,oldX;		//old tool position on board
	char newY,newX;		//new tool position on board
	char pawnChanged;	//if >1, pawn has reached tuch down, and changed to queen
	
	//ctor
	cMove(void* tool,char oldY,char oldX,char newY,char newX){
		count++;
		this->tool=tool;
		killedTool=NULL;
		this->oldY=oldY;
		this->oldX=oldX;
		this->newY=newY;
		this->newX=newX;
		this->pawnChanged=0;
	}//cMove()

	//dtor
	~cMove(){
		count--;
	}//~cMove()

};//class cMove
long cMove::count=0;