using System;

namespace pinukitafNet
{
	public class cGeneralData
	{
		public static String serverPath;					//real server path
		public static String uploadPath="uploadsnet\\";		//used to upload images to real server path
		public static String reloadPath="\\uploadsnet\\";	//used to load images from server using http path
		public static String dbPath="dbnet\\";
		public static String dbFile="pinukitafnet.mdb";
		public static System.Threading.Mutex adminMutex=new System.Threading.Mutex();
		public const String FILE_NAME_MARKER="___";
		public const String USER_COOKIE="pinukitafUserId";

		public cGeneralData()
		{
		}//public cGeneralData()

		public static String getTimeStemp()
		{
			return ""+DateTime.Now.Day+"."+DateTime.Now.Month+"."+DateTime.Now.Year+"___"+DateTime.Now.Hour+"."+DateTime.Now.Minute+"."+DateTime.Now.Second+FILE_NAME_MARKER;
		}//public String getTimeStemp()

		public static String stringToDateString(String s)
		{
			String ret=s.Substring(6,2)+"/";
			ret+=s.Substring(4,2)+"/";
			ret+=s.Substring(0,4);
			return ret;
		}//public static String stringToDateString(String s)

		public static String dateToString(DateTime date)
		{
			String ret="";
			ret=""+date.Year;
			if(date.Month<10)ret+="0";
			ret+=date.Month;
			if(date.Day<10)ret+="0";
			ret+=date.Day;
			return ret;
		}//public static String dateToString()

		public static String timeToString(DateTime time)
		{
			String ret="";
			if(time.Hour<10)ret+=0;
			ret+=time.Hour+":";
			if(time.Minute<10)ret+=0;
			ret+=time.Minute;
			return ret;
		}//public static String timeToString(DateTime time)
	}//public class cGeneralData
}//namespace pinukitafNet
