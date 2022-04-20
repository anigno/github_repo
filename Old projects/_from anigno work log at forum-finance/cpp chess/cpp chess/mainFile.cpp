#include"includeFiles.h"
using namespace std;

void main(int argc,char* argv[]){

	long gameTime=atoi(argv[2])*60;
	char* gt=argv[1];
	GameType gameType=compComp;
	if(strcmp(argv[1],"compComp")==0)gameType=compComp;
	if(strcmp(argv[1],"compHuman")==0)gameType=compHuman;
	if(strcmp(argv[1],"humanComp")==0)gameType=humanComp;
	if(strcmp(argv[1],"compNet")==0)gameType=compNet;
	if(strcmp(argv[1],"netComp")==0)gameType=netComp;
	cGameManagment game(gameType,gameTime);
	game.runner();

	//string ret;
	//SocketClient client1("127.0.0.1",2000);
	//ret=client1.ReceiveLine();
	//cout<<ret<<endl;
	//SocketClient client2("127.0.0.1",2000);
	//ret=client2.ReceiveLine();
	//cout<<ret<<endl;
	//do{
	//	ret=client1.ReceiveLine();
	//}while(ret.substr(0,5)!="Begin");
	//cout<<ret.substr(0,5)<<endl;
	//do{
	//	ret=client2.ReceiveLine();
	//}while(ret.substr(0,5)!="Begin");
	//
	//client1.SendLine("A1-A2");
	//	ret=client2.ReceiveLine();
	//	cout<<ret<<endl;
	//cout<<"wait";
	//getchar();



	cout<<"\nPress enter to continue";
	getchar();
}//main()