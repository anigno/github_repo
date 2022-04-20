class cBoardData{
public:
	char posData[12][12];		//player 0 or 1, or 9 for out of boundries
	void* toolData[12][12];		//the cTool* at the position[y][x]

};//class cBoardData