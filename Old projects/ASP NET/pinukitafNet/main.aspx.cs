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

namespace pinukitafNet
{
	/// <summary>
	/// Summary description for main.
	/// </summary>
	public class main : System.Web.UI.Page
	{
		cData myData=new cData(cGeneralData.dbPath,cGeneralData.dbFile);
		protected System.Web.UI.WebControls.Repeater rptMessages2;
		protected System.Web.UI.WebControls.Button btnNewSubject;
		protected System.Web.UI.WebControls.Button btnNewMessage;
		protected System.Web.UI.WebControls.TextBox txtNewSubject;
		protected System.Web.UI.WebControls.TextBox txtNewMessage;
		public String weekSubject="";

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
			this.btnNewSubject.Click += new System.EventHandler(this.btnNewSubject_Click);
			this.btnNewMessage.Click += new System.EventHandler(this.btnNewMessage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			//get weekSubject
			myData.createSelectCommand("tblGeneral","iName='weekSubject'","");
			DataTable table=myData.selectCommand.getTable();
			foreach(DataRow row in table.Rows)
			{
				weekSubject=row["iData"].ToString();
			}//foreach
			//get messages
			myData.createSelectCommand("tblMessages","","iDate DESC");
			DataTable messages=myData.selectCommand.getTable();
			//set all dates to readble string
			foreach(DataRow row in messages.Rows)
			{
				row["iDate"]=cGeneralData.stringToDateString(row["iDate"].ToString());
			}//foreach
			rptMessages2.DataSource=messages;
			rptMessages2.DataBind();
		}//private void Page_Load(object sender, System.EventArgs e)

		private void btnNewMessage_Click(object sender, System.EventArgs e)
		{
			//update messages in db
			if(txtNewMessage.Text.Length>2)
			{
				myData.createInsertCommand("tblMessages");
				myData.insertCommand.add("iText",txtNewMessage.Text);
				myData.insertCommand.add("iDate",cGeneralData.dateToString(DateTime.Now));
				myData.commandExecute(myData.insertCommand.getSql());
				Response.Redirect("main.aspx");
			}//if
		}//private void btnNewMessage_Click(object sender, System.EventArgs e)

		private void btnNewSubject_Click(object sender, System.EventArgs e)
		{
			//update week subject
			myData.createUpdateCommand("tblGeneral","iName='weekSubject'");
			myData.updateCommand.add("iData",txtNewSubject.Text);
			myData.commandExecute(myData.updateCommand.getSql());
			Response.Redirect("main.aspx");
		}//private void btnNewSubject_Click(object sender, System.EventArgs e)
	}//public class main : System.Web.UI.Page
}//namespace pinukitafNet.main
