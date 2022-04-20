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

namespace business.visitors
{
	/// <summary>
	/// Summary description for content.
	/// </summary>
	public class content : System.Web.UI.Page
	{
		
		cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,"");
		public string BusinessKey="";
		protected System.Web.UI.WebControls.Label lblTable;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			BusinessKey=Request.QueryString.Get("key");
			conn.createSelect("tblSubjects","*","fldBusinessKey='"+BusinessKey+"'","","");
			DataTable table=conn.runSelect();
			string subjectTable="&nbsp&nbsp&nbsp<a target=frameMain href=main.aspx?key="+BusinessKey+">עמוד ראשי</a>";
			string val="";
			subjectTable+="<table cellSpacing=8 cellPadding=0 border=0 width=155 background=../flashFiles/contentTable04.jpg>";
			subjectTable+="<tr height=30><td>&nbsp</td></tr>";
			foreach(DataRow row in table.Rows)
			{
				val="<tr><td>";
				val+="<a target=frameMain href=subject.aspx?subjectKey="+row["fldKey"].ToString()+">";
				val+=row["fldName"].ToString();
				val+="</a>";
				val+="</td></tr>";
				subjectTable+=val;
			}//foreach
			subjectTable+="<tr height=10><td><img width=140 src=../flashFiles/contentTable02_1.jpg></td></tr>";
			subjectTable+="</table>";
			lblTable.Text=subjectTable;

			

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
