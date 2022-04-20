#include<stdio.h>
#include<string.h>
#include<stdlib.h>
#include<malloc.h>
#include"List.h"
#include"User.h"

void main()
{
List* CarList;
Car* car;
int tempModel;
int a;

ListInit(&CarList,*UserElementCompare);	//itit the new List

car=malloc(sizeof(Car));	//allocating memory for Car
SetCar(car,1983,4000);
AddElement(CarList,car);
viewCar(1,car);

car=malloc(sizeof(Car));	//allocating memory for new Car
SetCar(car,1988,8000);		
AddElement(CarList,car);
viewCar(2,car);

car=malloc(sizeof(Car));	//allocating memory for new Car
SetCar(car,1998,65000);		
AddElement(CarList,car);
viewCar(3,car);

printf("List of all cars\n");
for(a=0;a<2000;a++)
{
	tempModel=a;
	car=GetElement(CarList,&tempModel);
	if(car!=NULL)viewCar(99,car);
	
}//for

}//main()