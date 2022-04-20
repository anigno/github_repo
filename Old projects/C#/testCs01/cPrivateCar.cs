using System;

namespace testCs01
{
	public class cPrivateCar:cVehicle
	{
		private int _numberOfSeats;
		
		public cPrivateCar(String licNumber):base(licNumber)
		{
			
		}//public cPrivateCar(String licNumber):base(licNumber)

		public int numberOfSeats
		{
			get
			{
				return _numberOfSeats;
			}//get
			set
			{
				try
				{
					_numberOfSeats=value;
				}
				catch(Exception e)
				{
					Console.WriteLine(e.Message);
					_numberOfSeats=0;
				}//catch
			}//set
		}//public String numberOfSeats

		public override String ToString()
		{
			
			return base.ToString() +
				   "\ncPrivateCar:" +
				   "\nnumbetofSeats: " + numberOfSeats;
		}//public String toString()
	}//public class cPrivateCar
}//namespace testCs01
