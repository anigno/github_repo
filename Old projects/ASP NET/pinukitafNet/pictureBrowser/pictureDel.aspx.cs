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

namespace pinukitafNet.pictureBrowser
{
	public class pictureDel : System.Web.UI.Page
	{
		int pictureKey=-1;
		int subjectKey=-1;
		cData myData=new cData(cGeneralData.dbPath,cGeneralData.dbFile);
		private void Page_Load(object sender, System.EventArgs e)
		{
			//get the picture key and the subject key
			pictureKey=int.Parse(Request.QueryString.Get("key"));
			subjectKey=int.Parse(Request.QueryString.Get("subject"));
			//delete the picture
			myData.createDeleteCommand("tblPictures","iKey="+pictureKey);
			myData.commandExecute(myData.deleteCommand.getSql());
			Response.Redirect("picturesView.aspx?key="+subjectKey);
		}//private void Page_Load(object sender, System.EventArgs e)

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
	}
}
