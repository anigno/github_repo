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
	public class picturesView : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Repeater rptPictures;
		cData myData=new cData(cGeneralData.dbPath,cGeneralData.dbFile);
		public int subjectKey=-1;
		private void Page_Load(object sender, System.EventArgs e)
		{
			//get subject's key
			subjectKey=int.Parse(Request.QueryString.Get("key"));
			//get pictures into repeater
			myData.createSelectCommand("tblPictures","iSubject="+subjectKey,"iKey DESC");
			DataTable pictures=myData.selectCommand.getTable();
			//add path to repeater's "iFileName" data
			foreach(DataRow picture in pictures.Rows)
			{
				String s=cGeneralData.reloadPath+picture["iFileName"].ToString();
				picture["iFileName"]=s;
			}//foreach
			rptPictures.DataSource=pictures;
			rptPictures.DataBind();
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if( File1.PostedFile.ContentLength!=0)
			{
				//upload the file
				string fileName = File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf("\\")+1);
				String fileExtention=File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf("."));
				String fullPath=cGeneralData.serverPath+cGeneralData.uploadPath+cGeneralData.getTimeStemp()+fileExtention;
				File1.PostedFile.SaveAs(fullPath);
				//update DB
				myData.createInsertCommand("tblPictures");
				myData.insertCommand.add("iFileName",cGeneralData.getTimeStemp()+fileExtention);
				myData.insertCommand.add("iPictureName",TextBox1.Text);
				myData.insertCommand.add("iSubject",subjectKey);
				myData.commandExecute(myData.insertCommand.getSql());
				//reload this page
				Response.Redirect("picturesView.aspx?key="+subjectKey);
			}//if( File1.PostedFile.ContentLength!=0)
		}//private void Button1_Click(object sender, System.EventArgs e)
	}//public class picturesView : System.Web.UI.Page
}//namespace pinukitafNet.pictureBrowser
