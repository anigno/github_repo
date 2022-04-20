#ifndef vga_c
#define vga_c
#include<graphics.h>
#include <conio.h>
#include <dos.h>
#include <mem.h>
#include <stdio.h>
#include <stdlib.h>

typedef unsigned char palet[256][3];

void VgaOn(int MODE);    //Turns ON the 320x200 graphics screen
void setpal (palet plt);
void savepal(char *s); // S-filename
void loadpal(char *s);
void showpicture (palet plt); // Shows picture slowly from 0-palette to plt
void downpicture();           // Hides picture slowly from plt to 0-palette
void getpal (palet plt);
void setnormpal();            //Set palette of DefPal
void saveimage (char *fname,int x1,int y1,int x2,int y2);
/* saves image at(x1,y1,x2,y2) in "getimage" format */
void *loadimage (char *fname);
/* loads image saved by saveimage */
void hidecolor(int clr); // Slowly hides color clr
void showcolor(int clr,int r,int g,int b);//shows clr color from black
void clearcolor(int clr);// cleans color to black




struct REGPACK rg;
palet plet,DefPal,*pl,hplet;
void waitvrt(void)
        {
        asm mov dx,03DAh
ct1:    asm in al,dx
        asm test al,08h
        asm je ct1
ct2:    asm in al,dx
        asm test al,08h
        asm jne ct2
        }


static int huge TestDriver()
{
 return 1;
}

void VgaOn(int MODE)
{
	int gd,gm=MODE;
	 int errorcode;
	gd= installuserdriver ("SVGA256",TestDriver);

 /* read result of last graphics operation */
 restorecrtmode();
 getpal(DefPal);
 initgraph(&gd,&gm,"");
 errorcode = graphresult();
 if (errorcode != grOk)
 {
	 printf("Graphics error: %s\n", grapherrormsg(errorcode));
	 printf("Press any key to halt:");
	 getch();
	 exit(1);
 }

	gm=DETECT;
}
void setpal (palet plt)
{
// setrgbpalette(1,plt[1][0],plt[1][1],plt[1][2]);
 int i;
 delay(0);
/* rg.r_ax=0x1012;
 rg.r_bx=0;
 rg.r_cx=0xFE;
 rg.r_dx=FP_OFF(plt);
 rg.r_es=FP_SEG(plt);*/

 waitvrt();
 for (i=0;i<256;i++) {
  outp(0x3c8,i);
  outp(0x3c9,plt[i][0]);
  outp(0x3c9,plt[i][1]);
  outp(0x3c9,plt[i][2]);
 }
// intr(0x10,&rg);
}

void showimage(char *name,int x,int y)
{
 x--;y--;
 FILE *f;
 palet pa;
 int i,j;
 long a;
 //void *a;
 //char far *p=(char far *)MK_FP(0xa000,0x0000);
 setmem(pa,sizeof(pa),0);
 f=fopen(name,"rb");
 fread(&a,sizeof(a),1,f);
 fread(hplet,sizeof(palet),1,f);
// setpal(pa);
// for(;!feof(f);*p++=fgetc(f)); //Uncomment for 320x200
// downpicture();
 showpicture(hplet);
 for (i=0;i<=y;i++)//Comment this for 320x200
  for (j=0;j<=x;j++)
	putpixel(j,i,fgetc(f));
 fclose(f);
}


void showimage_larg(char *name,int x,int y)
{
 x--;y--;
 FILE *f;
 palet pa;
 int i,j;
 int q1,q2;
 int cc;
 long a;
 //void *a;
 //char far *p=(char far *)MK_FP(0xa000,0x0000);
 setmem(pa,sizeof(pa),0);
 f=fopen(name,"rb");
 fread(&a,sizeof(a),1,f);
 fread(hplet,sizeof(palet),1,f);
// setpal(pa);
// for(;!feof(f);*p++=fgetc(f)); //Uncomment for 320x200
// downpicture();
 showpicture(hplet);
 for (i=0;i<=y;i++)for (j=0;j<=x;j++)
 {
	cc=fgetc(f);
	setcolor(cc);
	circle(j*4+20,i*4,2);
	putpixel(j*4+20,i*4,cc);

 }
 fclose(f);
}





void showimage_xy(char *name,int x,int y,int a1,int b1,double mul1)
{
 FILE *f;
 palet pa;
 int i,j;
 int q1,q2;
 int cc;
 long a;
 x--;y--;
 //void *a;
 //char far *p=(char far *)MK_FP(0xa000,0x0000);
 setmem(pa,sizeof(pa),0);
 f=fopen(name,"rb");
 fread(&a,sizeof(a),1,f);
 fread(hplet,sizeof(palet),1,f);
// setpal(pa);
// for(;!feof(f);*p++=fgetc(f)); //Uncomment for 320x200
// downpicture();
 showpicture(hplet);
 for (i=0;i<=y;i++)for (j=0;j<=x;j++)
 {
	cc=fgetc(f);
	setcolor(cc);
	putpixel(j*mul1+a1,i*mul1+b1,cc);

 }
 fclose(f);
}



void showpicture (palet plt)
{
  int c1,c2,c3;
//  setmem(plet,sizeof(palet),0);
//  waitvrt();
  setpal(plt);
/*
  for (c1=0;c1<64;c1++)
  {
	for (c2=0;c2<256;c2++) for (c3=0;c3<3;c3++)
	if (plt[c2][c3]>plet[c2][c3]) plet[c2][c3]++;
//	waitvrt();
	setpal(plet);
  }
*/
}

void downpicture()
{
  int c1,c2,c3;
  getpal(plet);
  for (c1=0;c1<64;c1++)
  {
  for (c2=0;c2<256;c2++) for (c3=0;c3<3;c3++)
	if (plet[c2][c3]>0) plet[c2][c3]--;
	waitvrt();
	setpal(plet);
  }
}

void getpal (palet plt)
{
 rg.r_ax=0x1017;
 rg.r_bx=0;
 rg.r_cx=0xff;
 rg.r_es=FP_SEG(plt);
 rg.r_dx=FP_OFF(plt);
 intr(0x10,&rg);
// plt[0][2]=0;plt[0][0]=0;plt[0][1]=0;

}

void setnormpal()
{
 setpal(DefPal);
}

void hidecolor(int clr)
{
  getpal(plet);
  while (plet[clr][0] ||plet[clr][1] ||plet[clr][2]) {
	if (plet[clr][0])  plet[clr][0]--;
   if (plet[clr][1])  plet[clr][1]--;
   if (plet[clr][2])  plet[clr][2]--;
	setrgbpalette(clr,plet[clr][0],plet[clr][1],plet[clr][2]);
  }
}

void clearcolor(int clr)
{
 setrgbpalette(clr,0,0,0);
}

void showcolor(int clr,int r,int g,int b)
{
  getpal(plet);
  while (plet[clr][0]<r ||plet[clr][1]<g ||plet[clr][2]<b) {
   if (plet[clr][0]<r)  plet[clr][0]++;
   if (plet[clr][1]<g)  plet[clr][1]++;
   if (plet[clr][2]<b)  plet[clr][2]++;
   setrgbpalette(clr,plet[clr][0],plet[clr][1],plet[clr][2]);
  }
}

void *loadimage (char *fname)
{
 FILE *f;
 int *img,x,y;
 f=fopen(fname,"rb");
 fread(&x,sizeof(int),1,f);
 fread(&y,sizeof(int),1,f);
 fread(plet,sizeof(palet),1,f);
 img=(int  *)malloc(y*x+4);
// plet[0][2]=0;plet[0][0]=0;plet[0][1]=0;
 if (img==NULL) { printf("\n Memory error!!!\n");exit(1);}
 fread(img+2,y*x,1,f);
 img[1]=y-1;img[0]=x-1;
 fclose(f);
 return img;
}

/*void AddToScreen(palet plt)
{
 char freecolors[256];
 int lastfree=0;
 float dest;//dest between colors
 palet oldpal;
 getpal(oldpal);

 memset(freecolors,0,sizeof(palet));
 for (int i=0;i<getmaxx();i++) //Setting free colors
	for (int j=0;j<getmaxy();j++)
		freecolors[getpixel(i,j)]=1;
 for (i=0;i<256;i++) { //for each color in new palette
	 destn=dest=2000;
	 for (j=0;j<256;j++) { //for each color in old palette
		dest=min(sqrt((plt[i][1]-oldpal[j][1])*(plt[i][1]-oldpal[j][1]))+
						  (plt[i][2]-oldpal[j][2])*(plt[i][2]-oldpal[j][2]))+
						  (plt[i][0]-oldpal[j][0])*(plt[i][0]-oldpal[j][0]))),dest);
		if (destn>dest) {destn=dest;deston=j;};
	 }
	 if (destn != 0) {
		while (lastfree<256 && freecolors[lastfree]) lastfree++;
		if (lastfree<256) l
	 }

}*/
void saveimage (char *fname,int x1,int y1,int x2,int y2)
{
 FILE *f;
 int *img,x=x2-x1+1,y=y2-y1+1;
 img=(int  *)malloc(x*y+4);
 getpal(plet);
 getimage(x1,y1,x2,y2,img);
 f=fopen(fname,"wb");
 fwrite(&x,sizeof(int),1,f);
 fwrite(&y,sizeof(int),1,f);
 fwrite(plet,sizeof(palet),1,f);
 if (img==NULL) { printf("\n Memory error!!!\n");exit(1);}
 fwrite(img+4,y*x,1,f);
 free(img);
 fclose(f);
}

void savepal(char *s)
{
  FILE *f;
  getpal(plet);
  f=fopen(s,"wb");
  fwrite(plet,sizeof(palet),1,f);
  fclose(f);
}
void loadpal(char *s)
{
  FILE *f;
  f=fopen(s,"rb");
  fread(plet,sizeof(palet),1,f);
//  plet[0][2]=0;plet[0][0]=0;plet[0][1]=0;
  fclose(f);
  setpal(plet);
}

#endif