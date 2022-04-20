using System;

namespace testCs01
{
	class Class1
	{
		[STAThread]
		static void Main(string[] args)
		{
			cPrivateCar myCar=new cPrivateCar("64735463");
			myCar.color="yellow";
			myCar.date="1/2/2004";
			myCar.numberOfSeats=5;
			Console.WriteLine(myCar.ToString());
			cVehicle v=new cVehicle("1234");
			cPrivateCar p=new cPrivateCar("4567");
			//cPrivateCar e=(cPrivateCar)v;
			v=(cVehicle)p;

			
			field
		
		}
	}
}
