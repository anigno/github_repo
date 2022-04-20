#include"rony.h"
#include"vga2.cpp"
void write_num(int x,int y,int s,int c,int n){ //gets x and y,the size,color and a number
 char st[3];		                       //and writes the number in the
 itoa(n,st,10);                         //x,y.  all data is integer
 setcolor(c);
 settextstyle(0,0,s);
 outtextxy(x,y,st);
}

void init(){              //initialises graphic mode and mouse
 int gd=9,gm=1;        //doesn't get parameters
 initgraph(&gd,&gm,"");
 resetmouse();
}

void button(int x,int y,char t[20])    //gets x and y (integer) and a text
 {                                    //draws a button in the x,y
  setcolor(2);                        //and places the text in it
  setfillstyle(1,1);
  bar3d(x,y,x+strlen(t)*8+10,y+15,5,1);
  settextstyle(0,0,1);
  outtextxy(x+5,y+5,t);
 }

int click(int x,int y,int x1,int y1,int mx,int my,int b)
 {
  if ((mx>=x) && (mx<=x1) && (my>=y) && (my<=y1) && (b==1))
	{
	 return 1;           //gets x,y (integer) and the text of the wanted button
	}                    //and x,y (integer) and button of the mouse
	else                 //returns 1 if the mouse is clicked in the button
	 {
	  return 0;
	 }
 }

void mousepos(int mx,int my)
 {
  setcolor(15);
  write_num(1,1,1,15,mx);
  write_num(1,10,1,15,my);
  setfillstyle(1,0);
  bar(1,1,25,25);
 }



