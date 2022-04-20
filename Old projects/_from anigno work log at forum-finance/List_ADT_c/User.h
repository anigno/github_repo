struct tagCar
{
	int Model;
	int Prise;
};typedef struct tagCar Car;

void SetCar(Car* car,int model,int prise)
{
	car->Model=model;
	car->Prise=prise;
}//SetCar

void viewCar(int a,Car* car)
{
	if(car!=NULL)
		printf("%d: Model=%d Prize=%d\n",a,car->Model,car->Prise);
	else
		printf("NULL\n");
}//viewCar()

int UserElementCompare(void* InCar,void* InModel)
{
	int* model;		//declaring int*
	Car* car;		//declaring Car*
	model=InModel;	//set int* from void*
	car=InCar;		//set Car* from void*
	if(car->Model==*model)return 1;
	return 0;
}//ElementCompare
