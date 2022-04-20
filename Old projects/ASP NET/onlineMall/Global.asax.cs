using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace onlineMall 
{
	public class Global : System.Web.HttpApplication
	{
        public static string serverPath="";
		public static string storeDataMdb="";
		public static string imagesPath="";
		public const string ADMIN_PASSWORD="";
		public const int PREV_IMAGE_HEIGHT=100;
		public const int MAX_IMAGE_SIZE=200000;
		
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			serverPath=Server.MapPath(@"..\");
			storeDataMdb=serverPath+@"\admin\db\storeData.mdb";
			imagesPath=serverPath+@"\admin\images\";
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			Session.Timeout=1000;
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

