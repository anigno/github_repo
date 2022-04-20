


void police_get_carlos()
{
	VgaOn(1);
	cleardevice();
	showimage_xy("1kar-ct.im2",150,100,100,100,2);
	showimage_xy("1kar-ct.im2",150,100,101,101,2);
	settextstyle(1,0,3);
	setrgbpalette(240,50,40,50);
	setcolor(240);
	outtextxy(0,70,"PUT YOUR HANDS WHERE I CAN SEE THEM, KARLOS!");
	setrgbpalette(241,50,30,50);
	setcolor(241);
	outtextxy(100,300,"ITS ALL OVER, KILLER !");
	delay(3500);
	closegraph();
}//void police_get_karlos


//************* walk function
//********************************************************************
int walk(int tarx,int tary,char m[90][150],int num){

char music2[100]={"o0l1 r"};
for(int qq1=0;qq1<=5;qq1++)music(music2,1);
char music1[1000]={
//"fabfabfabpppbcdbcdbcdpppadeadeadeppppppppppppppppppppppppppppppppppppppppr"
" bababfageppppefegpppefeeppppppbababfageppppefegpppefec pppp defg pp efga pp fgab pp gabb ppp bababfageppppefegpppeffeee ppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppr"
};

//svga 16 colors
int gd=9,gm=1;
initgraph(&gd,&gm,"");

if(kbhit())getch();

int a,b,c,d,e,f,g;//general use
char key;//for getch();
int thepage=0;//Active or Visual page
char ch;//for shortcut of map chars
int dx=0,dy=0;//carlos direction
int cx,cy;//carlos location on map
int sx=0,sy=0;//top& left corner of the view port
int px[20],py[20];//policemen location
int i,j,n;//counters
int flag=0;//flag use with policeman
int col;//color of road
int nx,ny;//policeman direction

//graphic init with svga16
setbkcolor(black);


//carlos start location on map and view port start location
cx=1;cy=1;
sx=cx-24;sy=cx-14;
if(sx<0)sx=0;
if(sx>124)sx=124;
if(sy<0)sy=0;
if(sx>60)sx=60;


//policemen start location on map
i=-1;
do{
i++;
flag=0;
do{
	px[i]=random(175)+20;
	py[i]=random(75)+20;
	for (j=0;j<=num-1;j++)
		if (m[py[i]][px[i]]==m[py[j]][px[j]]) flag=1;
}while( (m[py[i]][px[i]]!='2')||(flag==0) );
}while(i<num-1);

//**************   main loop of the chase ****************
do{
music(music1,2);
//change visual and active page;
thepage++;
if(thepage>1)thepage=0;
setactivepage(thepage);
setvisualpage(abs(thepage-1));
delay(10);
cleardevice();
setfillpattern(half,green);
bar(40,40,540,440);

//draw carlos view port 50*30
//***************************
settextstyle(1,0,3);
setcolor(lightblue);
outtextxy(100,10,"KARLOS. INTERNATIONAL TERRORIST.");
settextstyle(1,1,2);
setcolor(lightred);outtextxy(0,10,"RUN AWAY FROM THE POLICE !");
if(random(5)!=0){
	setcolor(random(16));
	outtextxy(560,100,"WATCH OUT !!!");
}//if
for(b=0;b<=29;b++){
	for(a=0;a<=49;a++){
		ch=m[sy+b][sx+a];
			//border drawing
			if(ch=='n'){
				setfillpattern(qurt,6);
				bar((a+4)*10,(b+4)*10,(a+4)*10+9,(b+4)*10+9);
			}//if

			//road drawing
			if(ch=='2'){
						  if ( (sy+b==tary)&&(sx+a==tarx) ) col=lightmagenta;
						  else col=darkgray;
						  setfillpattern(full,col);
						  bar((a+4)*10,(b+4)*10,(a+4)*10+9,(b+4)*10+9);
						  }//if
			if(ch=='1'){
				setcolor(darkgray);
				for(d=0;d<=9;d++){
					line((a+4)*10+d,(b+4)*10+9,(a+4)*10+9,(b+4)*10+d);
				}//for
			}//if
			if(ch=='3'){
			setcolor(darkgray);
				for(d=0;d<=9;d++){
					line((a+4)*10+d,(b+4)*10,(a+4)*10,(b+4)*10+d);
				}//for
			}//if

			//objects drawing from "object.h" file

			if(ch=='A')house1(a*10+40,b*10+40);
			if(ch=='B')house2(a*10+40,b*10+40);
			if(ch=='C')house3(a*10+40,b*10+40);
			if(ch=='D')house4(a*10+40,b*10+40);
			if(ch=='E')house5(a*10+40,b*10+40);
			if(ch=='p')pool(a*10+40,b*10+40);
			if(ch=='T')tree(a*10+40,b*10+40);
			if(ch=='t')tree2(a*10+40,b*10+40);
			if(ch=='b')draw_bus(a*10+40,b*10+40);
			if(ch=='c')draw_car(a*10+40,b*10+40);


			//draw carlos
			if( (a+sx==cx)&&(b+sy==cy) ){
				draw_karlos(a+4,b+4,cx,cy,dx);
//				setcolor(lightred);
//				rectangle((a+4)*10,(b+4)*10-10,(a+4)*10+9,(b+4)*10+9);
			}//if


			//draw policemen
			for(i=0;i<=num-1;i++){
				if( (a+sx==px[i])&&(b+sy==py[i]) ){
				draw_policeman(a+4,b+4,px[i],py[i],cx,px[i]);
//					setcolor(blue);
//					rectangle((a+4)*10,(b+4)*10-10,(a+4)*10+9,(b+4)*10+9);
				}//if
			}//for


	}//for
}//for
//end of drawing view port

//set carlos to move;
if(kbhit())key=getch();else key='!';
//dx=0;dy=0;
if(key=='H'){dx=1;dy=-1;}//up key
if(key=='P'){dx=-1;dy=1;}//down key
if(key=='K'){dx=-1;dy=0;}//left key
if(key=='M'){dx=1;dy=0;}//right key
if(key==' '){dx=dy=0;}

  //carlos move
	if(m[cy+dy][cx+dx]=='2'){
		cx=cx+dx;
		cy=cy+dy;
	} else
	if(m[cy+dy][cx]=='2'){
		cy=cy+dy;
	} else
	if(m[cy][cx+dx]=='2'){
		cx=cx+dx;
	}//if else else


	 //policeman chase carlos
	 for(i=0;i<=num-1;i++){
		//distance check and luck
		if ( ((abs(px[i]-cx))*(abs(px[i]-cx))+(abs(py[i]-cy))*(abs(py[i]-cy))<400 )&&((random(10))!=0) ){
		if ( (px[i]<cx)&&(m[py[i]][px[i]+1]=='2') ){
							nx=1;
							ny=0;
							}//if
		else{
		if ( (px[i]>cx)&&(m[py[i]][px[i]+(-1)]=='2') ){
							nx=(-1);
							ny=0;
							}//if
		else{
		if ( (py[i]<cy)&&(m[py[i]+1][px[i]+(-1)]=='2') ){
							nx=(-1);
							ny=1;
							}//if
		else{
		if ( (py[i]>cy)&&(m[py[i]+(-1)][px[i]+1]=='2') ){
							nx=1;
							ny=(-1);
							}//if
							}//else
							}//else
							}//else
		flag=0;
		for(n=1;n<=num-1;n++){
									//police man stand condition
									if ( (px[i]+nx==px[n])&&(py[i]+ny==py[n])||(m[py[i]+ny][px[i]+nx]!='2') ) flag=1;
									}//for
		if( flag==0 ){//police is moving
						 px[i]=px[i]+nx;
						 py[i]=py[i]+ny;
						 }//if
	 }//if
	 }//for




sx=cx-24;
sy=cy-14;


if(sx<0)sx=0;
if(sx>100)sx=100;
if(sy<0)sy=0;
if(sy>60)sy=60;


if(cx<0)cx=0;
if(cx>149)cx=149;
if(cy<0)cy=0;
if(cy>89)cy=89;


//check if policeman catch karlos
flag=2;
for(i=0;i<=num-1;i++){
	if((px[i]==cx)&&(py[i]==cy))flag=0;}

//check if karlos got to target
if ( (cx==tarx)&&(cy==tary) ) flag=1;
if(key=='+')flag=1;

number_box(600,10,cx);
number_box(600,20,cy);

}while(flag==2);
//******* end of main loop of the chase ********

beep();
delay(2000);
closegraph();
//exit(1);
//if police get karlos

if(flag==0)police_get_carlos();
return flag;
}//int walk
//*******************************************



//*******************************************
void circle3d(){
int cnt=0;
int pointx[2000];//x angle of apoint
int pointy[2000];//y angle of apoint
int color[2000];//color of apoint
int an;//angle
int a,b,c;
for(a=0;a<=1999;a++){
	pointx[a]=random(360);
	pointy[a]=random(480);
	color[a]=random(16)+1;
}//for
settextstyle(0,0,2);
while( (!kbhit())&&(cnt++<900) ){
cnt++;
for(a=0;a<=499;a++){
	putpixel(320+280*cos((pointx[a])/57.3),pointy[a]+50*sin(pointx[a]/57.3),0);
	if(pointx[a]>180)putpixel(320+280*cos((pointx[a])/57.3),1+pointy[a]+50*sin(pointx[a]/57.3),0);

	pointx[a]++;
	if(pointx[a]>359)pointx[a]=0;
	putpixel(320+280*cos((pointx[a])/57.3),pointy[a]+50*sin(pointx[a]/57.3),color[a]);
	if(pointx[a]>180)putpixel(320+280*cos((pointx[a])/57.3),1+pointy[a]+50*sin(pointx[a]/57.3),color[a]);
}//for
setcolor(darkgray);
outtextxy(60,100,".‰‚…Œ…‹ˆ ƒ€ ‡…‹ …ƒ‰—Œ š‰‹…š„");
setcolor(lightgray);
outtextxy(60,200,"     €š€ š‰˜— ‰†…‚…˜ ˜”‘ š‰");
setcolor(lightred);
outtextxy(60,300,"          98 …‰‘ ˆ—‰‰…˜”");
for(a=500;a<=999;a++){
	putpixel(320+80*cos((pointx[a])/57.3),pointy[a]+50*sin(pointx[a]/57.3),0);
	if(pointx[a]>180)putpixel(320+80*cos((pointx[a])/57.3),1+pointy[a]+50*sin(pointx[a]/57.3),0);

	pointx[a]=pointx[a]+2;
	if(pointx[a]>359)pointx[a]=0;
	putpixel(320+80*cos((pointx[a])/57.3),pointy[a]+50*sin(pointx[a]/57.3),color[a]);
	if(pointx[a]>180)putpixel(320+80*cos((pointx[a])/57.3),1+pointy[a]+50*sin(pointx[a]/57.3),color[a]);
}//for

}//while
if(kbhit())getch();
}//void circle3d
//*******************************************




//*******************************************
void ptype(char text[20][80],int x,int y,int textcolor){
char c[2]={" "};
int a=0,b;
settextstyle(2,0,7);
do{
	for(b=0;(c[0]!='#')&&(b<=strlen(text[a]));b++){
		c[0]=text[a][b];
	if(c[0]!='#'){
		setcolor(darkgray);
		outtextxy(x+b*10-1,y+a*18-1,c);
		outtextxy(x+b*10+1,y+a*18-1,c);
		outtextxy(x+b*10-1,y+a*18+1,c);
		outtextxy(x+b*10+1,y+a*18+1,c);
		setcolor(textcolor);
		outtextxy(x+b*10,y+a*18,c);
	}//if
		if(c[0]!=' '){
			sound(30);
			delay(8);
			nosound();
		}//if
		if(!kbhit())delay(70);

	}//for
	a++;
	if(!kbhit())delay(100);
}while(c[0]!='#');
free(text);
}//void ptype
//*******************************************




//*******************************************
void play_movie(char leter[2],int st,int en,int dly,char text[40]){
VgaOn(0);
char filename[11];
char s1[10],s2[10];
int a;
settextstyle(2,0,4);
strcpy(filename,leter);
for(a=st;a<=en;a++){
	itoa(a,s1,10);
	if(a<10)strncat(filename,"0",1);
	if(a<100)strncat(filename,"0",1);
	strncat(filename,s1,3);
	strncat(filename,".im2",4);
//	printf("%s \n",filename);
	showimage_xy(filename,176,144,60,50,1);
	if(a==st){
		setrgbpalette(255,50,50,50);
		setcolor(255);
		outtextxy(50,30,text);
	}//if
	delay(dly);
	strcpy(filename,leter);
}//for
delay(1000);
closegraph();
}//void play_movie
//*******************************************



//*******************************************
void show_all(){
VgaOn(0);
int dly=700;

showimage_xy("rafi.im2",103,132,50,0,2);
delay(dly);
cleardevice();
showimage_xy("mor.im2",130,118,30,0,2);
delay(dly);
cleardevice();
showimage_xy("izik.im2",142,99,0,0,2);
delay(dly);
cleardevice();
showimage_xy("zvika.im2",110,89,40,0,2);
delay(dly);
cleardevice();
showimage_xy("eli.im2",113,111,50,0,2);
delay(dly);
cleardevice();
showimage_xy("moshe.im2",102,171,50,0,2);
delay(dly);
cleardevice();
showimage_xy("gal.im2",187,111,0,0,2);
delay(dly);
cleardevice();
showimage_xy("tal.im2",100,88,50,20,2);
delay(dly);
cleardevice();
showimage_xy("rony.im2",164,118,0,0,2);
delay(dly);
cleardevice();
showimage_xy("karlos-i.im2",59,139,100,0,2);
delay(dly);
cleardevice();
closegraph();
}//show_all
//*******************************************




//*******************************************
void opening(){
//need karlos3.im2
int x,y,a,b;
char text1[30][80]={
"--------------------------------------------------------------",
"In 1976, boeing 747 belong to TOWER AIR, has exploded over ",
"the pacific ocean.",
"one terrorist group took responsibility for this action.",
"Thy were - The 13 donkeys.",
"A young man named Karlos, was one of them.",
"              ",
"In 1987, the C.I.A, interpol and the israeli MOSAD succeeded",
"in catching the worst terrorist ever, Karlos, after along ",
"trucking over several countries.",
"              ",
"At the 5th of july 1998, Karlos managed to escape maximum",
"security prison in nevada, and with the help of computer ",
"students from ROGOZIN school in kiriat ata, his free and ",
"dangerous again.					 ",
"                                          ",
"Your duty as a commander is to send instructions to karlos,",
"and assist him to destroy world peace.",
"                                                                          ",
"GOOD LUCK !!!#",
"--------------------------------------------------------------"
};

//showing karlos international terrorist in acage
VgaOn(1);
circle3d();
closegraph();
show_all();
VgaOn(1);
showimage_larg("1kar.im2",150,100);

delay(2000);
//drawing bars
/*
for(y=0;(!kbhit())&&(y<=40);y=y+4){
	setcolor(70);
	line(15,y*10,620,y*10);
	setcolor(20);
	line(15,1+y*10,620,1+y*10);
	line(15,2+y*10,620,2+y*10);
	setcolor(50);
	line(15,3+y*10,620,3+y*10);
	sound(20);delay(40);nosound();
	sound(30);delay(30);nosound();
	delay(300);
}//for
*/
delay(1500);
closegraph();
play_movie("t",0,19,500,"KARLOS ESCAPED FROM PRISON.");

//setrgbpalette(250,15,63 ,60);
VgaOn(1);
showimage_larg("1kar.im2",150,100);
ptype(text1,5,5,250);
delay(2000);
closegraph();

}//opening
//*******************************************



//*******************************************
void load_map(char map[90][150],char filename[11]){
	int a,b;
	FILE *f;
	f=fopen(filename,"r");
	for(b=0;b<=89;b++){
		for(a=0;a<=149;a++){
			map[b][a]=fgetc(f);
		}//for
		fgetc(f);
	}//for
	fclose(f);
}//void load_map
//*******************************************


//*******************************************
void the_end(){
char kar_end[20][80]={
"KARLOS, THE INTERNATIONAL TERRORIST WAS KILLED .",
"YOU FAILED IN YOUR MISSION !!!   #"
};
play_movie("m",20,41,500,"KARLOS WAS KILLED BY THE POLICE.");

VgaOn(1);
showimage_xy("kar-end.im2",150,100,200,100,2);
setrgbpalette(250,50,50,40);
setcolor(250);
rectangle(200,100,500,300);
settextstyle(1,0,2);
outtextxy(210,230,"karlos is dead !");
settextstyle(2,0,5);
outtextxy(220,250,"was killed by the police.");
delay(3000);
ptype(kar_end,5,50,250);
delay(2000);
closegraph();
}//void the_end
//*******************************************

