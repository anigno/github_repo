//update 2/5/98
#include"karlos.h"
#include"objects.h"
#include"karlos2.h"
#include"vga2.cpp"
#include"rafi2.h"
#include"shooting.h"
#include"safe.h"

//*************************************************************************
//****** MAIN PROGRAM - KARLOS INTERNATIONAL TERRORIST.********************
//*************************************************************************

void main(){
randomize();
char map[90][150];
int continue_game=1;//flag


opening();

load_map(map,"map1.kar");
if(walk(148,88,map,12)==0)if(walk(148,88,map,8)==0)if(walk(148,88,map,6)==0)continue_game=0;

if(continue_game==1)continue_game=rafi2();

load_map(map,"map4.kar");
if(continue_game==1)if(walk(148,88,map,8)==0)if(walk(148,88,map,7)==0)if(walk(148,88,map,6)==0)continue_game=0;

if(continue_game==1)shooting();

safe();


the_end();

nosound();
delay(3000);
}//main program


