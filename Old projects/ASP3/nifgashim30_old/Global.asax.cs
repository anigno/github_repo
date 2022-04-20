using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using anignoLibrary.ClassLibraryMdbConnection;

namespace nifgashim30 
{
	public class Global : System.Web.HttpApplication
	{
		
		//private const and static members
		private const int MIN_AGE=20;
		private const int MAX_AGE=60;
		private const string registeredUsersMdb="registeredUsers.mdb";
		private static string serverPath;
		//public const and static members
		public const int maxUploadSize=80000;
		public static string registeredUsersMdbFilePath;
		public static string imageUploadPath;
		//cDataItemArray collection
		public static cDataItemArray arrayAconomicState;
		public static cDataItemArray arrayBody;
		public static cDataItemArray arrayChangeHome;
		public static cDataItemArray arrayChildren;		
		public static cDataItemArray arrayEducation;
		public static cDataItemArray arrayFamilyState;		
		public static cDataItemArray arrayLuck;
		public static cDataItemArray arrayOrigin;		
		public static cDataItemArray arrayRegion;
		public static cDataItemArray arrayRelationshipCouse;		
		public static cDataItemArray arrayReligion;
		public static cDataItemArray arraySex;		
		public static cDataItemArray arraySmoke;
		public static cDataItemArray arraySport;		
		public static cDataItemArray arrayHeight;
		public static cDataItemArray arrayDay;		
		public static cDataItemArray arrayMonth;		
		public static cDataItemArray arrayYear;		
		public static cDataItemArray arrayAge;

		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			//set server and database pathes
			serverPath=Server.MapPath("");
			serverPath=serverPath.Substring(0,serverPath.LastIndexOf(@"\"))+@"\";
			registeredUsersMdbFilePath=serverPath+@"DB\registeredUsers.mdb";
			imageUploadPath=serverPath+@"uploads\";
			//create connection to RegisteredUsers.mdb and read application data
			cDatabaseConnection conRegisteredUsers;
			conRegisteredUsers=new cDatabaseConnection(serverPath+@"DB\"+registeredUsersMdb,"");
			//create all application data arrays
			arrayAconomicState=new cDataItemArray(conRegisteredUsers,"tblAconomicState");
			arrayBody=new cDataItemArray(conRegisteredUsers,"tblBody");
			arrayChangeHome=new cDataItemArray(conRegisteredUsers,"tblChangeHome");
			arrayChildren=new cDataItemArray(conRegisteredUsers,"tblChildren");
			arrayEducation=new cDataItemArray(conRegisteredUsers,"tblEducation");
			arrayFamilyState=new cDataItemArray(conRegisteredUsers,"tblFamilyState");
			arrayLuck=new cDataItemArray(conRegisteredUsers,"tblLuck");
			arrayOrigin=new cDataItemArray(conRegisteredUsers,"tblOrigin");
			arrayRegion=new cDataItemArray(conRegisteredUsers,"tblRegion");
			arrayRelationshipCouse=new cDataItemArray(conRegisteredUsers,"tblRelationshipCouse");
			arrayReligion=new cDataItemArray(conRegisteredUsers,"tblReligion");
			arraySex=new cDataItemArray(conRegisteredUsers,"tblSex");
			arraySmoke=new cDataItemArray(conRegisteredUsers,"tblSmoke");
			arraySport=new cDataItemArray(conRegisteredUsers,"tblSport");
			arrayHeight=new cDataItemArray(conRegisteredUsers,"tblHeight");
			arrayDay=new cDataItemArray(conRegisteredUsers,"tblDay");
			arrayMonth=new cDataItemArray(conRegisteredUsers,"tblMonth");
			//set arrayYear and arrayAge according to actual year (DateTime.Now) and requested ages
			arrayYear=new cDataItemArray();
			arrayAge=new cDataItemArray();
			int i=DateTime.Now.Year;
			for(int j=MIN_AGE;j<=MAX_AGE;j++)
			{
				cDataItem item;
				item=new cDataItem(i-j,((int)(i-j)).ToString());
				arrayYear.Add(item);
				item=new cDataItem(j,j.ToString());
				arrayAge.Add(item);
			}//for
		}//Application_Start()
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

