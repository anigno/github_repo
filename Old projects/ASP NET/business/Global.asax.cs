using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace business 
{
	public class Global : System.Web.HttpApplication
	{
		private System.ComponentModel.IContainer components = null;
		public static string serverPath="";
		public static string mdbFile="";
		public static string picturePath="";
		public static string[] regionTextField={"אילת","גולן","גליל","דרום","השרון","חיפה","ירושליים","כנרת","נגב","עמק בית שאן","עמק הירדן","עמק ישראל","קריות","שומרון","שפלת החוף","תל אביב"};
		public static string[] regionValueField={"0","1","2","3","4","5","6","7","8","9","10","11","12","13","14","15"};
		public const int MAX_SMALL_IMAGE_HEIGHT=100;
		public const int MAX_BIG_IMAGE_WIDTH=240;
		public const int MAX_LOGO_IMAGE_HEIGHT=60;
		public const int MAX_SUBJECT_IMAGE_WIDTH=180;
		public const int MAX_SUBJECT_IMAGE_HEIGHT=200;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			serverPath=Server.MapPath(@"..\");
			mdbFile=serverPath+@"DB\business.mdb";
			picturePath=serverPath+@"PICTURES\";
		}
 
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

