using System;

namespace testCs01
{
	public class cVehicle
	{
		private String		_licNumber;
		private DateTime	_date;
		private String		_color;

		public cVehicle(String licNumber)
		{
			_licNumber=licNumber;
		}//cVehicle()

		public String licNumber{
			get
			{
				return _licNumber;
			}//get
		}//public String licNumber
		public String date
		{
			get
			{
				return _date.ToString().Substring(0,10);
			}//get
			set
			{
				try
				{
					_date=DateTime.Parse(value);
				}
				catch(Exception e)
				{
					Console.WriteLine(e.Message);
					_date=DateTime.Now;
				}//catch
			}//set
		}//public String date

		public String color
		{
			get
			{
				return _color;
			}//get
			set
			{
				_color=value;
			}//set
		}//public String color
		public override String ToString()
		{
			return  "\ncVehicle:" +
					"\nlicNumber:" + licNumber +
					"\ndate: " + date +
					"\ncolor: " + color;
		}//public void toString()
	}//public class cVehicle
}//namespace testCs01
