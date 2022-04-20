enum toolType{
	king=0,
	queen=1,
	bishop=2,
	rook=3,
	knight=4,
	pawn=5
};

enum GameType{
	compComp=0,
	compHuman=1,
	humanComp=2,
	compNet=3,
	netComp=4
};

enum PlayerType{
	compPlayer=0,
	humanPlayer=1,
	netPlayer=2
};



#include <iostream>
#include <string>
#include "cTimer.h"
#include "cListNode.h"
#include "cList.h"
#include "cMove.h"
#include "cBoardData.h"
#include "cTool.h"
#include "cUtils.h"
#include "cState.h"
#include "cSolver.h"
#include "socket.h"
#include "cGameManagment.h"



