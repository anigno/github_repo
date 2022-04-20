// last edition 21/5/98

void cursor(int *mx,int *my,int *btn,void *psave){
	readmouse(my,mx,btn);
	if (*mx>=609) *mx=609;
	if (*my>=359) *my=359;
	getimage(*mx,*my,*mx+30,*my+30,psave);
	setcolor(140);
	circle(*mx+15,*my+15,10);
	putpixel(*mx+15,*my+15,15);
	setcolor(130);
	line(*mx+15,*my,*mx+15,*my+10);
	line(*mx+15,*my+20,*mx+15,*my+30);
	line(*mx,*my+15,*mx+10,*my+15);
	line(*mx+20,*my+15,*mx+30,*my+15);
 }

void curdel(void *psave,int mx,int my)
 {
  putimage(mx,my,psave,0);
 }


void enemy(void *rsave,int *mx,int *my,int *btn,int *life,int *score,void *dsave,void *ricsave,void *cop,void *shootcop)
 {
  static int enecount=0,x,y,ran,flag=0,x1,y1,count2=0,fl=0,flric=0,
  xric,yric,ricount=0,xrictemp,yrictemp;
  if (enecount==0)
	{
	 ran=random(7)+1;
	 switch (ran)
	  {
		case 1: {x=60; y=20; break;}
		case 2: {x=60; y=200; break;}
		case 3: {x=220; y=120; break;}
		case 4: {x=330; y=60; break;}
		case 5: {x=540; y=200; break;}
		case 6: {x=290; y=200; break;}
		case 7: {x=30; y=150; break;}
	  }
	 getimage(x,y,x+20,y+30,rsave);
	 setfillstyle(1,15);
	 putimage(x,y,cop,0); //cop
	}
	enecount=enecount+1;
	if (enecount%100==0)
	 {
	  setfillstyle(1,4);
	  putimage(x,y,shootcop,0);  //shooting cop
	  sound(140);delay(30);nosound();
	  flag=1;
	  ran=random(2)+1;
	  if (ran==2)
		{
		 *life=*life-5;
		}
		else
		 {
		  flric=1;
		  xric=random(641);
		  yric=random(100)+380;
		  getimage(xric,yric,xric+10,yric+10,ricsave);
		 }
	 }
	if (flric==1)
	 {
	  xrictemp=xric;
	  yrictemp=yric;
	  ricount=ricount+1;
	  if (ricount<50)
		{
		 setcolor(14);
		 line(xrictemp,yrictemp,xrictemp+10,yrictemp+10);
		 line(xrictemp+4,yrictemp,xrictemp+10,yrictemp+10);
		}
		else
		 {
		  putimage(xrictemp,yrictemp,ricsave,0);
		  ricount=0;
		  flric=0;
		 }
	 }
	if ((enecount%125==0) && (flag==1))
	 {
	  setfillstyle(1,15);
	  //bar(x,y,x+20,y+30);
	  flag=0;
	 }
	if ((enecount==1000) || (click(x,y,x+20,y+30,*mx+15,*my+15,*btn)==1))
	 {
	  if (enecount<1000)
		{
		 x1=x;
		 y1=y;
//		 fl=1;
		 *score=*score+1;
		}
		putimage(x,y,rsave,0);
		enecount=0;
//		if (fl==1)
//		 {
//		  getimage(x1,y1,x1+20,y1+30,dsave);
//		 }
	 }
//	if (fl==1)
//	 {
//	  setfillstyle(1,14);
//	  bar(x1,y1,x1+20,y1+30);
//	  count2=count2+1;
//	  if (count2==20)
//		{
//		 count2=0;
//		 putimage(x1,y1,dsave,0);
//		 fl=0;
//		}
//	 }

fl=fl;
 count2=count2;
 dsave=dsave;
 }

void status(int *life,int *score)
 {
  setcolor(172);
  settextstyle(0,0,2);
  outtextxy(10,460,"life:");
  settextstyle(0,0,2);
  outtextxy(200,460,"kills:");
  write_num(100,460,2,168,*life);
  write_num(300,460,2,168,*score);
 }


void stadel(void *ssave)
 {
  putimage(100,460,ssave,0);
  putimage(300,460,ssave,0);
 }

void hand(void *hsave,int mx,void *hands)
 {
  getimage(mx,370,mx+30,450,hsave);
  setfillstyle(1,2);
  putimage(mx,370,hands,0); //hand
 }


void handel(void *hsave,int mx)
 {
  putimage(mx,370,hsave,0);
 }

//*****************************************************************
int shooting()
{
 char quit;
 int *mx,*my,*btn,life=100,score=0;
 unsigned int size,sizeenemy,sizehand,sizestatus,sizeric,c,s,h;
 void far *psave,*rsave,*hsave,*ssave,*dsave,*ricsave,*hands,*cop,*shootcop;
 randomize();

// init();
VgaOn(2);
cleardevice();
showimage_xy("shoot-p.im2",100,60,0,0,1);
//  bar(0,0,20,30);               //cop
//setcolor(255);
//rectangle(30,0,95,30);


void *police1;
unsigned int psize1=imagesize(30,0,95,30);
police1=malloc(psize1);
getimage(30,0,95,30,police1);

  c=imagesize(0,0,20,30);
  cop=malloc(c);
  getimage(73,30,73+20,26+30,cop);

//  bar(50,0,70,30);                 //shooting cop
setcolor(23);//shooting color
circle(80,50,1);
circle(80,50,2);
  s=imagesize(0,0,20,30);
  shootcop=malloc(s);
  getimage(73,30,73+20,26+30,shootcop);

//  setcolor(255);
//  rectangle(0,0,30,80);


//  bar(100,370,130,450);                         //hand
  h=imagesize(100,370,130,450);
  hands=malloc(h);
  getimage(0,0,29,80,hands);

//	putimage(100,100,hands,1);
//	getch();
//	closegraph();
//	exit(1);


  cleardevice();

/*
  bar(325,55,355,95);         //
  bar(535,195,565,235);       //
  bar(285,195,315,235);       //
  bar(25,145,55,185);        //windows
*/

  putimage(35,45,police1,1);
  putimage(35,225,police1,1);
  putimage(195,145,police1,1);
  putimage(305,85,police1,1);
  putimage(515,225,police1,1);
  putimage(265,225,police1,1);
  putimage(5,175,police1,1);
  putimage(500,105,police1,1);

/*
showimage_xy("city2.im2",160,110,0,0,4);
showimage_xy("city2.im2",160,110,1,0,4);
showimage_xy("city2.im2",160,110,0,1,4);
showimage_xy("city2.im2",160,110,1,1,4);
showimage_xy("shoot-p.im2",100,60,0,380,1);
*/
 size=imagesize(0,0,30,30);
 psave=malloc(size);

 sizeenemy=imagesize(0,0,20,30);
 rsave=malloc(sizeenemy);
 dsave=malloc(sizeenemy);

 sizehand=imagesize(0,0,30,80);
 hsave=malloc(sizehand);

 sizestatus=imagesize(0,0,55,20);
 ssave=malloc(sizestatus);

 sizeric=imagesize(0,0,10,10);
 ricsave=malloc(sizeric);

 setfillstyle(1,0);
 bar(0,380,640,450);
 bar(0,450,640,480);
 getimage(400,460,455,480,ssave);

 while ((life>0) && (score<30))
  {
	if (kbhit()) quit=getch();
	 if (quit==27) life=0;
	 if (quit=='+') score=30;
	cursor(mx,my,btn,psave);
	hand(hsave,*mx,hands);
	status(&life,&score);

	delay(1);
	handel(hsave,*mx);
	curdel(psave,*mx,*my);
	stadel(ssave);
	enemy(rsave,mx,my,btn,&life,&score,dsave,ricsave,cop,shootcop);

  }//while
free(cop);
free(shootcop);
free(police1);
free(psave);
free(rsave);
free(hsave);
free(ssave);
free(dsave);
free(hands);
free(ricsave);


closegraph();
if (life==0)
 {
  return 0;
 }
 else
  {
	return 1;
  }
}//shooting