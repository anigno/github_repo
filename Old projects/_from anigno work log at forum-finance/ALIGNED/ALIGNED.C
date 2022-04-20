#include<malloc.h>
#include<stdio.h>

/*allocate aligned to 16 memory block*/
void* alignedMalloc(int sizeB){
	char* start=malloc(sizeB+16);
	long l=(long)(start+1)%16;		/*find shift to next %16*/
	char* ret;
	l=16-l+1;						/*calc the shift to next %16*/
	ret=start+l;
	*(ret-1)=(char)l;				/*write the shift as char*/
	printf("malloc=%x ret=%x\n",start,ret);
	return ret;
}

void freeAligned(void* ret){
	char* prev=(char*)ret;
	char shift=(char)*(prev-1);		/*read the shift*/
	char* start=(char*)ret-shift;	/*calc the real malloc*/
	printf("free=%x \n",start);
	free(start);
}
void main(){
	void* a;
	a=alignedMalloc(1017);
	freeAligned(a);
	a=alignedMalloc(1103);
	freeAligned(a);
	a=alignedMalloc(102);
	freeAligned(a);
	getchar();
}