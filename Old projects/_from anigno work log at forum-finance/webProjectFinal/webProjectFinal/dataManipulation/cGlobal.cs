using System;
using System.Threading;

namespace webProjectFinal
{
	/// <summary>
	/// hold Global logic data required for data manipulation
	/// </summary>
	public class cGlobal
	{
		public const string WORKERS_MDB_PASSWORD="29024783";
		public const string WORKERS_TABLE="PersonalInfo";
		public const string WORK_HOURS_TABLE="WorkHoursInfo";
		public const string FACTORY_DATA_TABLE="Definitions";
		public const string FACTORY_DATA_MDB_PASSWORD="29024783";
		public const string SECURITY_TABLE="tblPasswords";
		public const string SECURITY_MDB_PASSWORD="29024783";
		public const string ADMIN_STRING="admin_string";
		//mutext to protect static members
		private static Mutex serverPathMutex=new Mutex();
		//static members protected by mutex!
		public static string WORKERS_MDB_FILE;
		public static string FACTORY_DATA_MDB_FILE;
		public static string SECURITY_MDB_FILE;
		private static String _server_path;

		public cGlobal()
		{
		}//cGlobal

		//set the server real path, project is not depend on server location
		public static void setServerPath(string serverPath)
		{
			//mutex protect static members
			serverPathMutex.WaitOne();
				_server_path=serverPath;
				//"../" force path to go back one directory!
				WORKERS_MDB_FILE=_server_path+"../DB/webp.mdb";
				FACTORY_DATA_MDB_FILE=_server_path+"../DB/webpDefinitions.mdb";
				SECURITY_MDB_FILE=_server_path+"../DB/security.mdb";
			serverPathMutex.ReleaseMutex();
		}//setServerPath()
	
	
	}//class cGlobal
}//namespace
