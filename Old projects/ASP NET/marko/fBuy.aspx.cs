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

namespace marko
{
	/// <summary>
	/// Summary description for fBuy.
	/// </summary>
	public class fBuy : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblSum;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Label lblOrderNumber;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.DataGrid dgUser;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Label Label6;
	

		cDatabaseConnection con=new cDatabaseConnection(Global.dbFile,"");

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				//get order number from Ticks (will be string value)
				lblOrderNumber.Text=DateTime.Now.Ticks.ToString();
				//get basketTable from session and bind it to dgUser
				DataTable basketTable=(DataTable)(Session["basket"]);
				dgUser.DataSource=basketTable;
				dgUser.DataBind();
				//calculate total sum
				double totalSum=0;
				for(int i=0;i<basketTable.Rows.Count;i++)
				{
					double productPrise=Double.Parse(basketTable.Rows[i]["fldPrise"].ToString());
					double productCount=Double.Parse(basketTable.Rows[i]["fldCount"].ToString());
					totalSum+=productPrise*productCount;
				}
				lblSum.Text=totalSum.ToString();
			}


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
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			//update tblOrders
			con.createInsert("tblOrders");
			con.addToInsert("fldName",txtName.Text);
			con.addToInsert("fldAddress",txtAddress.Text);
			con.addToInsert("fldPhone",txtPhone.Text);
			con.addToInsert("fldDate",DateTime.Now.ToOADate());
			con.addToInsert("fldOrderNumber",lblOrderNumber.Text);
			con.runInsert();
			//update tblProductsOrder for each row in basketTable
			DataTable basketTable=(DataTable)(Session["basket"]);
			for(int i=0;i<basketTable.Rows.Count;i++)
			{
				con.createInsert("tblProductsOrder");
				con.addToInsert("fldOrderNumber",lblOrderNumber.Text);
				con.addToInsert("fldProductKey",basketTable.Rows[i]["fldKey"]);
				con.addToInsert("fldProductCount",basketTable.Rows[i]["fldCount"]);
				con.addToInsert("fldProductPrise",basketTable.Rows[i]["fldPrise"]);
				con.addToInsert("fldProductName",basketTable.Rows[i]["fldName"]);
				con.runInsert();
			}
			//disable OK button
			btnOK.Enabled=false;
			btnCancel.Enabled=false;
			btnReturn.Visible=true;
			lblMessage.Text="הזמנתכם נשלחה בהצלחה";
			//clear basket if not post back
			Session["basket"]=null;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("fShop.aspx");
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("fShop.aspx");
		}
	}
}
