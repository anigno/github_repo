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
using anignoLibrary.ClassLibraryMdbConnection;
using System.IO;

namespace business.visitors
{
	public class main : System.Web.UI.Page
	{
		cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,"");
		string key="";
		public string textAbout="";
		protected System.Web.UI.WebControls.Image Image1;
		public string textAddress="";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			key=Request.QueryString.Get("key");
			conn.createSelect("tblBusinesses","*","fldKey='"+key+"'","","");
			DataTable table=conn.runSelect();
			textAddress=table.Rows[0]["fldCity"].ToString()+"<br>";
			textAddress+=table.Rows[0]["fldAddress"].ToString()+"<br>";
			textAddress+=table.Rows[0]["fldPhone"].ToString()+"<br>";
			textAddress+=table.Rows[0]["fldCellPhone"].ToString()+"<br>";
			if(table.Rows[0]["fldFax"].ToString()!="")
                textAddress+="פקס: "+table.Rows[0]["fldFax"].ToString()+"<br>";
//			int regionIndex=int.Parse("0"+table.Rows[0]["fldRegion"].ToString());
//			textAddress+="אזור: "+Global.regionTextField[regionIndex];
			textAbout=table.Rows[0]["fldAbout"].ToString();
			textAbout=cUtils.convertToHtmlString(textAbout);
			Image1.ImageUrl=Global.picturePath+table.Rows[0]["fldMainPicture"].ToString();
			//use FileStream to get image properties
			FileStream fs=new FileStream(Image1.ImageUrl,FileMode.Open,FileAccess.Read,FileShare.Read);
			System.Drawing.Image image=System.Drawing.Image.FromStream(fs);
			double widthFactor=Global.MAX_SUBJECT_IMAGE_WIDTH/(double)image.Width;
			double width=(double)(image.Width*widthFactor);
			double height=(double)(image.Height*widthFactor);
			fs.Close();
			Image1.Width=(int)width;
			Image1.Height=(int)height;
			//add "?image=" to image name to force browser to download image from server
			Image1.ImageUrl=Image1.ImageUrl+"?image="+DateTime.Now.Ticks.ToString();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}//class
}//namespace
