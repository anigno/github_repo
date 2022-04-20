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
	public class pictureBrowser : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Repeater rptSubjects;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button1;

		cData myData=new cData(cGeneralData.dbPath,cGeneralData.dbFile);

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//bind repeater for subjects
			myData.createSelectCommand("tblSubjects","","");
			DataTable subjects=myData.selectCommand.getTable();
			rptSubjects.DataSource=subjects;
			rptSubjects.DataBind();
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
			//insert new subject
			if(TextBox1.Text!="")
			{
				myData.createInsertCommand("tblSubjects");
				myData.insertCommand.add("iSubject",TextBox1.Text);
				myData.commandExecute(myData.insertCommand.getSql());
				Response.Redirect("pictureBrowser.aspx");
			}//if
		}//private void Button1_Click(object sender, System.EventArgs e)

		


	}//public class pictureBrowser : System.Web.UI.Page
}//namespace pinukitafNet.pictureBrowser
