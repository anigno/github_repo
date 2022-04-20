#include<iostream.h>
#include<string.h>
#include<conio.h>
#include<stdio.h>
#include<stdlib.h>
#include<graphics.h>
#include<dos.h>
#include<mouse.h>
#include<ctype.h>
#include<math.h>
#include <stat.h>
#include <fcntl.h>
#include <io.h>
#define black 0
#define blue 1
#define green 2
#define cyan 3
#define red 4
#define magenta 5
#define brown 6
#define lightgray 7
#define darkgray 8
#define lightblue 9
#define lightgreen 10
#define lightcyan 11
#define lightred 12
#define lightmagenta 13
#define yellow 14
#define white 15

#define yes 1
#define no 0


//************************************************************************
char qurt[8]={0x92,0x24,0x49,0x92,0x24,0x49,0x92,0x24};
char half[8]={0xaa,0x55,0xaa,0x55,0xaa,0x55,0xaa,0x55};
char full[8]={0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff};
//************************************************************************

//**************************************************************************
void beep(){
sound(400);
delay(100);
nosound();
}//void beep
//**************************************************************************


//**************************************************************************
int instr(char *c,char *s){
	int p1=0,p2=0;
	while(p1<strlen(s)){
		while(*(s+p1)==*(c+p2)){
			p1++;
			p2++;
			if(p2==strlen(c))return p1-strlen(c)+1;
		}//while
	p1++;
    p2=0;
	}//while
	return 0;
}//int instr
//**************************************************************************


//**************************************************************************
void make_window(int x1,int y1,int x2,int y2,char *s){
hidemouse();
int a;
setcolor(darkgray);
/*
for(a=y1;a<=y2;a++){
	line(x1,a,x2,a);
	delay(2);
}//for
*/
setfillpattern(full,lightgray);
bar(x1-1,y1-1,x2+1,y2+1);
setfillpattern(full,white);
bar(x1+2,y1+2,x2+1,y2+1);
if(*(s)==' ')setfillpattern(half,darkgray); else setfillpattern(full,darkgray);
bar(x1,y1,x2,y2);
setfillpattern(full,lightgray);
bar(x1+1,y1+10,x2-1,y1+13);
settextstyle(0,0,1);
setcolor(yellow);
outtextxy((x2-x1)/2+x1-strlen(s)*4,y1+1,s);
showmouse();
}//void make_window
//**************************************************************************


//**************************************************************************
void press_box(int x,int y,char *s){
hidemouse();
settextstyle(0,0,1);
setfillpattern(full,white);
bar(x-1,y-1,1+x+strlen(s)*8,y+11);
setfillpattern(full,black);
bar(x,y,2+x+strlen(s)*8,y+12);
setfillpattern(full,darkgray);
bar(x,y,1+x+strlen(s)*8,y+11);
setfillpattern(full,lightgray);
bar(x,y,x+strlen(s)*8,y+10);
setcolor(black);
outtextxy(x,y+2,s);
showmouse();
}//void press_box
//**************************************************************************


//**************************************************************************
void tbox(int x,int y,char *s){
hidemouse();
settextstyle(0,0,1);
setfillpattern(full,black);
bar(x-2,y-2,1+x+strlen(s)*8,y+11);
setfillpattern(full,darkgray);
bar(x-1,y-1,1+x+strlen(s)*8,y+11);
setfillpattern(full,white);
bar(x,y,1+x+strlen(s)*8,y+11);
setfillpattern(full,lightgray);
bar(x,y,x+strlen(s)*8,y+10);
setcolor(black);
outtextxy(x,y+2,s);
showmouse();
}//void text_box
//**************************************************************************

//**************************************************************************
void number_box(int x,int y,int num){
hidemouse();
char s[50];
int a;
itoa(num,s,10);
settextstyle(0,0,1);
setfillpattern(full,black);
bar(x-2,y-2,1+x+strlen(s)*8,y+11);
setfillpattern(full,darkgray);
bar(x-1,y-1,1+x+strlen(s)*8,y+11);
setfillpattern(full,white);
bar(x,y,1+x+strlen(s)*8,y+11);
setfillpattern(full,lightgray);
bar(x,y,x+strlen(s)*8,y+10);
setcolor(black);
outtextxy(x,y+2,s);
showmouse();
}//void number_box
//**************************************************************************



//**************************************************************************
void number_box2(int x,int y,int num,int c){
hidemouse();
char s[50];
int a;
c++;
itoa(num,s,10);
settextstyle(0,0,1);
setfillpattern(full,black);
bar(x-2,y-2,1+x+strlen(s)*8,y+11);
setfillpattern(full,170);
bar(x-1,y-1,1+x+strlen(s)*8,y+11);
setfillpattern(full,180);
bar(x,y,1+x+strlen(s)*8,y+11);
setfillpattern(full,190);
bar(x,y,x+strlen(s)*8,y+10);
setcolor(black);
outtextxy(x,y+2,s);
showmouse();
}//void number_box
//**************************************************************************

//**************************************************************************
void text_box(int x,int y,char *s){
hidemouse();
setfillpattern(full,0);
bar(x-1,y-1,x+3+strlen(s)*8+8,y+3+8);
setfillpattern(full,15);
bar(x,y,x+3+strlen(s)*8+8,y+3+8);
setfillpattern(full,7);
bar(x,y,x+2+strlen(s)*8+8,y+2+8);
setcolor(0);
settextstyle(0,0,1);
outtextxy(x+5,y+2,s);
showmouse();
}//void tbox
//**************************************************************************

//**************************************************************************
void text_box2(int x,int y,int l){
hidemouse();
setfillpattern(full,0);
bar(x-1,y-1,x+3+l*8+8,y+3+8);
setfillpattern(full,15);
bar(x,y,x+3+l*8+8,y+3+8);
setfillpattern(full,7);
bar(x,y,x+2+l*8+8,y+2+8);
showmouse();
}//void tbox
//**************************************************************************

//**************************************************************************
void ibox(int x,int y,int i){
hidemouse();
char s[10];
itoa(i,s,10);
tbox(x,y,s);
showmouse();
}//void ibox
//**************************************************************************



//**************************************************************************
void get_date(int *year,int *month,int *day)
{
   struct date d;
	getdate(&d);
	*year=d.da_year;
	*day=d.da_day;
	*month=d.da_mon;
}//void get_date
//**************************************************************************


//**************************************************************************
void write_date(int x,int y,int year,int month,int day){
	hidemouse();
	char yr[5],mn[3],dy[3];
	itoa(year,yr,10);
	itoa(month,mn,10);
	itoa(day,dy,10);
	if(day<=9){dy[1]=dy[0];dy[0]=' ';dy[2]=0;}
	if(month<=9){mn[1]=mn[0];mn[0]=' ';mn[2]=0;}
	text_box(x,y,dy);
	text_box(x+25,y,mn);
	text_box(x+50,y,yr);
showmouse();
}//void write_date
//**************************************************************************

//*************************************************************************
int check_in(int x1,int y1,int x2,int y2){
	int mx,my,btn,ret=0;
	readmouse(&my,&mx,&btn);
	if( (mx>=x1)&&(mx<=x2)&&(my>=y1)&&(my<=y2) ){
		ret=btn;
		while(btn!=0)readmouse(&my,&mx,&btn);
	}//if
	if(ret==1){sound(400);delay(30);nosound();}
	if(ret==2){sound(600);delay(30);nosound();}
	return ret;
}//int check_in
//*************************************************************************





//***************************************************************************
void hebread(int x,int y,int l,char *s){
hidemouse();
int hebrew[255];
char hebline[40]="tcdsvuzjyhfknbxgpmera,lo.;i ";
char numline[60]="ABCDEFGHIJKLMNOP-1234567890/=:*+()!#^&";
char key;
char n[50]="";
char ch[2];
int p=1,a;
ch[0]=key;
ch[1]=0;
hebrew[33]=33;
hebrew[94]=94;
hebrew[35]=35;
hebrew[38]=38;
hebrew[42]=42;
hebrew[40]=40;
hebrew[41]=41;
hebrew[43]=43;
hebrew[61]=61;
hebrew[58]=58;
hebrew[61]=61;
hebrew[47]=47;
hebrew[34]=34;
hebrew[116]=128;
hebrew[99]=129 ;
hebrew[100]=130;
hebrew[115]=131;
hebrew[118]=132;
hebrew[117]=133;
hebrew[122]=134;
hebrew[106]=135;
hebrew[121]=136;
hebrew[104]=137;
hebrew[102]=139;
hebrew[107]=140;
hebrew[110]=142;
hebrew[98]=144;
hebrew[120]=145;
hebrew[103]=146;
hebrew[112]=148;
hebrew[109]=150;
hebrew[101]=151;
hebrew[114]=152;
hebrew[97]=153;
hebrew[44]=154;
hebrew[111]=141;
hebrew[105]=143;
hebrew[108]=138;
hebrew[46]=149;
hebrew[59]=147;
hebrew[48]=48;
hebrew[49]=49;
hebrew[50]=50;
hebrew[51]=51;
hebrew[52]=52;
hebrew[53]=53;
hebrew[54]=54;
hebrew[55]=55;
hebrew[56]=56;
hebrew[57]=57;
hebrew[32]=95;
hebrew[45]=45;

text_box2(x,y,l);
key='`';
while( (key!=13)&&(key!=27)&&(p<45) ){
	key=getch();
	ch[0]=key;
  if(p<=l){
	if(instr(ch,hebline)!=0){
		for(a=strlen(n);a>=0;a--)n[a+1]=n[a];
		n[0]=hebrew[key];
		n[p+1]=0;
		p++;
	}//if
	if(instr(ch,numline)!=0){
		for(a=strlen(n);a>=0;a--)n[a+1]=n[a];
		n[0]=key;
		n[p+1]=0;
		p++;
	}//if
  }//if
	if(key==8){
		for(a=0;a<=strlen(n);a++)n[a]=n[a+1];
		p--;
		if(p<1)p=1;
	}//if
	text_box(x+l*8-strlen(n)*8,y,n);
}//while
if(key!=27){
	for(a=strlen(n);a>=0;a--)n[a+1]=n[a];
	for(a=1;a<=strlen(n);a++)s[a-1]=n[a];
	s[a-2]=0;
}//if
text_box(x+l*8-strlen(s)*8,y,s);
showmouse();
}//void hebread
//*************************************************************************



//*************************************************************************
void month_data(int year,int month,int *the_max_day,int *the_first_day){
	// max_day[year-1990][month], first_day[year-1990][month]
	int max_day[21][13],first_day[21][13];
	int a;
for(a=0;a<=20;a++){
	max_day[a][1]=31;
	max_day[a][2]=28;
	max_day[a][3]=31;
	max_day[a][4]=30;
	max_day[a][5]=31;
	max_day[a][6]=30;
	max_day[a][7]=31;
	max_day[a][8]=31;
	max_day[a][9]=30;
	max_day[a][10]=31;
	max_day[a][11]=30;
	max_day[a][12]=31;

	first_day[a][1]=1;
	first_day[a][2]=1;
	first_day[a][3]=1;
	first_day[a][4]=1;
	first_day[a][5]=1;
	first_day[a][6]=1;
	first_day[a][7]=1;
	first_day[a][8]=1;
	first_day[a][9]=1;
	first_day[a][10]=1;
	first_day[a][11]=1;
	first_day[a][12]=1;
}//for

//first input first_day[year-1990][1] then input february max_day and run the for
//1998
first_day[8][1]=4;
for(a=2;a<=12;a++){
	first_day[8][a]=(first_day[8][a-1]+max_day[8][a-1])%7;
}//for
//1999
first_day[9][1]=5;
for(a=2;a<=12;a++){
	first_day[9][a]=(first_day[9][a-1]+max_day[9][a-1])%7;
}//for

*the_first_day=first_day[year-1990][month];
*the_max_day=max_day[year-1990][month];

}//int month_data
//***************************************************************************


//***************************************************************************
void outnumberxy(int x,int y,long int number){
	char s[20];
	itoa(number,s,10);
	outtextxy(x,y,s);
}//void outnumberxy
//***************************************************************************

//************************************************************************
void initgraphics(){
int gd,gm;//graphic init vars
	gd=DETECT;
	gm=0;
	initgraph(&gd,&gm,"");
	setbkcolor(black);
	cleardevice();
	activmouse();
	resetmouse();
}//void initgraphics
//************************************************************************


void music(char m[1000],int length_mul){
/*
octave change: o0 - o4
length change: l1 - l8
notes : c c# d d# e f f# g g# a a# b
other: r - restart, p - no music for last length

*/
int n[5][12]={
268,284,301,318,337,358,379,401,425,451,477,506,
536,568,602,637,675,716,758,803,851,902,955,1012,
1072,1136,1204,1275,1351,1432,1517,1607,1703,1804,1911,2025,
2145,2273,2408,2551,2703,2864,3034,3215,3406,3608,3823,4050,
4291,4547,4817,5103,5407,5728,6069,6430,6812,7217,7647,8101
};

int a,b;
//change start-up setting of notes
for(a=0;a<=4;a++)for(b=0;b<=11;b++)n[a][b]=n[a][b]/3;

//length_mul  //1/8 of a note
static int lcnt=0;//length counter of note
static int cnt=0;//string counter
static int octave=1;
static int length=2;
//static int play_mode=1;//(0 - no playing,1-playing)
static int wlength=0;

if(cnt>strlen(m))cnt=0;
if(m[cnt]=='r')cnt=-1;
//change octave
if(m[cnt]=='o'){
	cnt++;
	octave=m[cnt]-48;
}//if

//set length to next note
if(m[cnt]=='l'){
	cnt++;
	wlength=m[cnt]-48;
}//if

if(m[cnt]==' ' ){
	//space
}//if


//check if note length is passed to change note
if(lcnt>=length*length_mul){
	nosound();
	if(wlength!=0){
		length=wlength;
		wlength=0;
	}//if
	cnt++;
//printf("%c",m[cnt]);

	if(m[cnt]=='p'){
		nosound();
		lcnt=0;
	}//if

	if(m[cnt]=='c'){
		lcnt=0;
		if(m[cnt+1]=='#'){
			sound(n[octave][1]);
			cnt++;
		} else sound(n[octave][0]);
	}//if


	if(m[cnt]=='d'){
		lcnt=0;
		if(m[cnt+1]=='#'){
			sound(n[octave][3]);
			cnt++;
		} else sound(n[octave][2]);
	}//if

	if(m[cnt]=='e'){
		lcnt=0;
		if(m[cnt+1]=='#'){
			sound(n[octave][4]);
			cnt++;
		} else sound(n[octave][4]);
	}//if

	if(m[cnt]=='f'){
		lcnt=0;
		if(m[cnt+1]=='#'){
			sound(n[octave][6]);
			cnt++;
		} else sound(n[octave][5]);
	}//if

	if(m[cnt]=='g'){
		lcnt=0;
		if(m[cnt+1]=='#'){
			sound(n[octave][8]);
			cnt++;
		} else sound(n[octave][7]);
	}//if


	if(m[cnt]=='a'){
		lcnt=0;
		if(m[cnt+1]=='#'){
			sound(n[octave][10]);
			cnt++;
		} else sound(n[octave][9]);
	}//if

	if(m[cnt]=='b'){
		lcnt=0;
		if(m[cnt+1]=='#'){
			sound(n[octave][11]);
			cnt++;
		} else sound(n[octave][11]);
	}//if

}//if


lcnt++;
}//void music
