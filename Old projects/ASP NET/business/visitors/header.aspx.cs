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
	public class header : System.Web.UI.Page
	{
		cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,"");
		string key="";

		protected System.Web.UI.WebControls.Label lblBusinessName;
		protected System.Web.UI.WebControls.Label lblEmail;
		protected System.Web.UI.WebControls.Label lblCounter;
		protected System.Web.UI.WebControls.Image imgLogo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			key=Request.QueryString.Get("key");
			conn.createSelect("tblBusinesses","*","fldKey='"+key+"'","","");
			DataTable table=conn.runSelect();
			lblBusinessName.Text=table.Rows[0]["fldName"].ToString();
			if(table.Rows[0]["fldEmail"].ToString()!="")
				lblEmail.Text="<a href=mailto:"+table.Rows[0]["fldEmail"].ToString()+">"+table.Rows[0]["fldEmail"].ToString()+"</a>";
			int counter=int.Parse("0"+table.Rows[0]["fldCounter"].ToString());
			counter++;
			//update counter
			conn.createUpdate("tblBusinesses","fldKey='"+key+"'");
			conn.addToUpdate("fldCounter",counter.ToString());
			conn.runUpdate();
			lblCounter.Text=counter.ToString();
			//logo picture
			string logoImageFile=table.Rows[0]["fldLogoPicture"].ToString();
			imgLogo.ImageUrl=Global.picturePath+logoImageFile;
			//use FileStream to get image properties
			FileStream fs=new FileStream(imgLogo.ImageUrl,FileMode.Open,FileAccess.Read,FileShare.Read);
			System.Drawing.Image image=System.Drawing.Image.FromStream(fs);
			double heightFactor=Global.MAX_LOGO_IMAGE_HEIGHT/(double)image.Height;
			double width=(double)(image.Width*heightFactor);
			double height=(double)(image.Height*heightFactor);
			fs.Close();
			imgLogo.Width=(int)width;
			imgLogo.Height=(int)height;
			//add "?image=" to image name to force browser to download image from server
			imgLogo.ImageUrl=imgLogo.ImageUrl+"?image="+DateTime.Now.Ticks.ToString();

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
