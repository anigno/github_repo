int rafi2(){
VgaOn(1);
showimage("rafi_d.im2",150,100);

void *p1,*p2,*p3,*p4;
unsigned int s1,s2,s3,s4;
s1=imagesize(0,0,50,68);
s2=imagesize(50,0,120,40);
s3=imagesize(50,40,150,90);
s4=s2;
p1=malloc(s1);
p2=malloc(s2);
p3=malloc(s3);
p4=malloc(s4);
getimage(0,0,50,68,p1);//rpg
getimage(50,0,120,40,p2);//plain1
int qx,qy;
for(qy=0;qy<=40;qy++)for(qx=50;qx<=120;qx++)putpixel(400-qx,qy,getpixel(qx,qy));
getimage(280,0,350,40,p4);//plain2
getimage(50,40,150,90,p3);//chopper

cleardevice();

int a,b,c;//general use
int px,py;//position of the plain and chopper and angle
double ma=0;
int kx=320;//karlos position
int stop=1;//stop game flag(0 - stop, 1 - continue)
int master=0;//(0 - plain 1 - chopper)
char key;
int rpg_shoot=0;//flag for rpg shoot
int rpg_onway=0;//flag for rpg is on way, no rpg avliable
int rx,ry;//rpg position
int hits=0;//number of plain and choper hits
int life=3;//karlos lifes left
int bom_shoot=0;//flag for bom shoot
int bom_onway=0;//flag for bom is on way, no bom avliable
int by,bx;
//main loop
do{
if(kbhit())key=getch(); else key='`';
setfillpattern(full,0);
bar(kx-25,270,kx+25,350);//eraze karlos with rpg
if(key=='+')stop=0;
if(key=='K')kx=kx-40;
if(key=='M')kx=kx+40;
if( (key==' ')&(rpg_onway==0) )rpg_shoot=1;
if(kx<40)kx=40;
if(kx>600)kx=600;
putimage(kx-25,270,p1,1);//draw karlos with rpg


if( (random(400)<32)&(bom_onway==0) )bom_shoot=1;
if(bom_shoot==1){//set bom to fall
	sound(250);
	delay(30);
	nosound();
	bom_onway=1;
	bom_shoot=0;
	bx=px;
	by=py+30;
}//if

if(bom_onway==1){//bom is falling
	setcolor(0);
	ellipse(bx,by,0,360,3,10);
	by=by+1;
	if(by<200){
		if(kx<bx)bx--;
		if(kx>bx)bx++;
	}//if
	if(by>330)bom_onway=0;
	if( (by>280)&(abs(bx-kx)<15) ){//karlos got hit
	life--;
	sound(70);
	delay(50);
	nosound();
	bom_onway=0;
	}//if
	if(bom_onway==1){
		setcolor(200);
		ellipse(bx,by,0,360,3,10);
	}//if
}//if


if(rpg_shoot==1){//set rpg lunch
	rpg_onway=1;
	rpg_shoot=0;
	rx=kx;
	ry=260;
}//if

if(rpg_onway==1){//rpg_going up
	sound(200);
	setcolor(0);//eraze rpg
	rectangle(rx,ry,rx+2,ry+10);
	if( (abs(ry-py-30)<20)&&(abs(rx-px-35)<20) ){//plain or chopper got hit
		rpg_onway=0;
		hits++;
		if(hits>3)master=1;
		setcolor(100);
		for(a=0;a<=30;a++){//explosion
			circle(rx,ry,a);
			sound(a+50);
			delay(10);
			nosound();
		}//for
		setcolor(0);
		for(a=0;a<=30;a++){
			circle(rx,ry,a);
			sound(a+50);
			delay(10);
			nosound();
		}//for
	}//if
	if( (ry<10) )rpg_onway=0;//rpg miss
	ry=ry-2;
	if(rpg_onway==1){//draw rpg if needed
		setcolor(170);
		rectangle(rx,ry,rx+2,ry+10);
	}//if
	nosound();
}//if

//plain attacks
if(master==0){
	setfillpattern(full,0);
	bar(px,py,px+70,py+50);
	ma=ma+0.4;if(ma>360)ma=ma-360;
	px=290+280*cos(ma/57.3);
	py=40+30*sin(ma/57.3);
	if(ma>=180)putimage(px,py,p2,1); else putimage(px,py,p4,1);
}//if(master=0)

//chopper attacks
if(master==1){
	setfillpattern(full,0);
	bar(px,py,px+100,py+50);
	ma=ma+.6;if(ma>360)ma=ma-360;
	px=280+260*cos(ma/57.3);
	py=70+60*sin(ma/57.3);
//	if(ma>=180)putimage(px,py,p2,1); else putimage(px,py,p4,1);
	putimage(px,py,p3,1);
}//if(master=1)

number_box(10,300,life);
number_box(10,320,hits);
if(life==0)stop=0;
if(hits==8)stop=0;

}while(stop==1);
//end of main loop
free(p1);
free(p2);
free(p3);
free(p4);
closegraph();
if(life==0)return 0;
if(hits==8)return 1;
if(key=='+')return 1;

return 0;
}//rafi

