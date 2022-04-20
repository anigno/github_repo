using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace netUploadTest
{
	public class _default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if( File1.PostedFile.ContentLength!=0)
			{
				//int a=1;int b=0;
				//a=a/b;
				String uploadPath="uploadsnet";
				string fileName = File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf("\\")+1);
				String fileExtention=File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf("."));
				String serverPath=Server.MapPath("\\")+uploadPath+"\\";
				String timeStemp=""+DateTime.Now.Day+"."+DateTime.Now.Month+"."+DateTime.Now.Year+" "+DateTime.Now.Hour+"."+DateTime.Now.Minute+"."+DateTime.Now.Second+" ##";
				String fullPath=serverPath+timeStemp+TextBox1.Text+fileExtention;
				Label2.Text=fullPath;
				File1.PostedFile.SaveAs(fullPath);
				TextBox1.Text="";
			}//if( File1.PostedFile.ContentLength!=0)
		}//private void Button1_Click(object sender, System.EventArgs e)
	}//public class _default : System.Web.UI.Page
}//namespace netUploadTest
