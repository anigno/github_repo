void beeps(int a){
sound(a*15+70);
delay(70);
nosound();
delay(60);
}//beeps


void kav(){
int i;
setcolor(100);
for(i=0;i<480;i=i+60){
line(320,i,300,i+30);
line(300,i+30,340,i+30);
line(340,i+30,320,i+60);
				 }//for
}//void



void batten(int x , int y , int c , char *n ){
setcolor(150);
setfillpattern(full,c*8);
bar(x,y,x+60,y+60);
int p1=17,p2=0;
setcolor(0);
settextstyle(7,0,6);
outtextxy(x+p1,y+p2,n);
}//batten



void figurs(int h_num){
int e1,e2,e3,e4,t=60;
e4=h_num;
if((e1==1) || (e2==1) || (e3==1) || (e4==1)){
beeps(e4);
batten(380,150,13,"1");
delay(t);
batten(380,150,7,"1");
										  }//if
if((e1==2) || (e2==2) || (e3==2) || (e4==2)){
beeps(e4);
batten(460,150,13,"2");
delay(t);
batten(460,150,7,"2");
										  }//if
if((e1==3) || (e2==3) || (e3==3) || (e4==3)){
beeps(e4);
batten(540,150,13,"3");
delay(t);
batten(540,150,7,"3");
										  }//if
if((e1==4) || (e2==4) || (e3==4) || (e4==4)){
beeps(e4);
batten(380,230,13,"4");
delay(t);
batten(380,230,7,"4");
										  }//if
if((e1==5) || (e2==5) || (e3==5) || (e4==5)){
beeps(e4);
batten(460,230,13,"5");
delay(t);
batten(460,230,7,"5");
										  }//if
if((e1==6) || (e2==6) || (e3==6) || (e4==6)){
beeps(e4);
batten(540,230,13,"6");
delay(t);
batten(540,230,7,"6");
										  }//if
if((e1==7) || (e2==7) || (e3==7) || (e4==7)){
beeps(e4);
batten(380,310,13,"7");
delay(t);
batten(380,310,7,"7");
										  }//if
if((e1==8) || (e2==8) || (e3==8) || (e4==8)){
beeps(e4);
batten(460,310,13,"8");
delay(t);
batten(460,310,7,"8");
										  }//if
if((e1==9) || (e2==9) || (e3==9) || (e4==9)){
beeps(e4);
batten(540,310,13,"9");
delay(t);
batten(540,310,7,"9");
										  }//if
if((e1==0) || (e2==0) || (e3==0) || (e4==0)){
beeps(e4);
batten(460,390,13,"0");
delay(t);
batten(460,390,7,"0");
										  }//if

}//figurs






//**************************************************************************

int safe(){
char key;
int a,b,c;



VgaOn(2);
showimage_xy("safe1.im2",70,100,10,100,4);

kav();

//int p1=17,p2=0;
batten(380,150,7,"1");
batten(460,150,7,"2");
batten(540,150,7,"3");
batten(380,230,7,"4");
batten(460,230,7,"5");
batten(540,230,7,"6");
batten(380,310,7,"7");
batten(460,310,7,"8");
batten(540,310,7,"9");
batten(460,390,7,"0");


figurs(8);
figurs(7);
figurs(8);
figurs(7);
figurs(8);
figurs(4);
figurs(6);
figurs(5);
figurs(3);

figurs(3);
figurs(3);
figurs(3);
figurs(3);

figurs(3);
figurs(5);
figurs(3);
figurs(6);

figurs(6);
figurs(6);
figurs(6);
figurs(6);

figurs(3);
figurs(5);
figurs(3);
figurs(4);

figurs(4);
figurs(4);
figurs(4);
figurs(4);


closegraph();
return 1;
}//end safe

