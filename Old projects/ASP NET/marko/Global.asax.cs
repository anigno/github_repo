using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace marko 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		public const string DB_NAME="marko.mdb";
		public static string serverPath;
		public static string dbFile;
		public static string imagesPath;
		public static System.Threading.Mutex mutex=new System.Threading.Mutex();
		
		public static string getRandomFilename(string filename)
		{
			string ret="";
			DateTime d=new DateTime(DateTime.Now.Ticks);
			
			ret=""+d.Year+d.Month+d.Day+d.Hour+d.Minute+d.Second+d.Millisecond;
			string extention=filename.Substring(filename.LastIndexOf("."));
			ret+=extention;
			return ret;
		}

		public static string getFileExtention(string filename)
		{
			return filename.Substring(filename.LastIndexOf("."));
		}
		
		
		
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			//mutex protected static members dbPath,imagePath
			mutex.WaitOne();
			serverPath=Server.MapPath("\\");
			dbFile=serverPath+"\\dbnet\\"+DB_NAME;
			imagesPath=serverPath+"\\images";
			mutex.ReleaseMutex();
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

