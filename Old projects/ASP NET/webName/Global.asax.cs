using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using anignoLibrary.ClassLibraryMdbConnection;

namespace webName 
{
	public class Global : System.Web.HttpApplication
	{
		public static string serverPath="";
		public static string mdbFile="";
		public static string imagesPath="";
		public static string sitesPath="";
		public const string adminPassword="29024783";
		public const int PREVIEW_IMAGE_HEIGHT=90;
		public const int PREVIEW_IMAGE_WIDTH=90;

		public static cDataItem[] webTypeArray;
		public static cDataItem[] webColorArray;
		
		
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			serverPath=Server.MapPath(@"..\");
			mdbFile=serverPath+@"admin\DB\webName.mdb";
			imagesPath=serverPath+@"admin\IMAGES\";
			sitesPath=serverPath;
		}//Application_Start();
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			//read data arrays
			webTypeArray=cUtils.fillDataArrayFromDb("tblType");
			webColorArray=cUtils.fillDataArrayFromDb("tblColor");
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

