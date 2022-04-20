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
	public class fAdmin : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.ListBox lstOrders;
		protected System.Web.UI.WebControls.DataGrid dgProducts;
		protected System.Web.UI.WebControls.CheckBox chkReady;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label lblAddress;
		protected System.Web.UI.WebControls.Label lblPhone;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.Label lblSum;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnRefrash;
	

		cDatabaseConnection con=new cDatabaseConnection(Global.dbFile,"");

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				//read tblOrders
				con.createSelect("tblOrders","*","","fldOrderNumber DESC","");
				DataTable table=con.runSelect();
				lstOrders.DataSource=table;
				lstOrders.DataTextField="fldName";
				lstOrders.DataValueField="fldOrderNumber";
				lstOrders.DataBind();
				if(lstOrders.Items.Count>0)
				{
					lstOrders.SelectedIndex=0;
					lstOrders_SelectedIndexChanged(lstOrders,null);
				}
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
			this.lstOrders.SelectedIndexChanged += new System.EventHandler(this.lstOrders_SelectedIndexChanged);
			this.chkReady.CheckedChanged += new System.EventHandler(this.chkReady_CheckedChanged);
			this.btnRefrash.Click += new System.EventHandler(this.btnRefrash_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lstOrders_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//read tblProductsOrder for selected order number
			con.createSelect("tblProductsOrder","*","fldOrderNumber='"+lstOrders.SelectedValue.ToString()+"'","","");
			DataTable table=con.runSelect();
			dgProducts.DataSource=table;
			dgProducts.DataBind();
			//calculate totalSum
			double totalSum=0;
			for(int i=0;i<table.Rows.Count;i++)
			{
				double productPrise=Double.Parse(table.Rows[i]["fldProductPrise"].ToString());
				double productCount=Double.Parse(table.Rows[i]["fldProductCount"].ToString());
				totalSum+=productPrise*productCount;
			}
			lblSum.Text=totalSum.ToString();
			//read selected order data and set to labels
			con.createSelect("tblOrders","*","fldOrderNumber='"+lstOrders.SelectedValue+"'","","");
			DataTable order=con.runSelect();
			lblAddress.Text=order.Rows[0]["fldAddress"].ToString();
			lblDate.Text=order.Rows[0]["fldDate"].ToString();
			lblName.Text=order.Rows[0]["fldName"].ToString();
			lblPhone.Text=order.Rows[0]["fldPhone"].ToString();
			chkReady.Checked=Boolean.Parse(order.Rows[0]["fldReady"].ToString());


		}

		private void chkReady_CheckedChanged(object sender, System.EventArgs e)
		{
			con.createUpdate("tblOrders","fldOrderNumber='"+lstOrders.SelectedValue+"'");
			con.addToUpdate("fldReady",chkReady.Checked);
			con.runUpdate();
		}

		private void btnRefrash_Click(object sender, System.EventArgs e)
		{
			//read tblOrders
			con.createSelect("tblOrders","*","","fldOrderNumber DESC","");
			DataTable table=con.runSelect();
			lstOrders.DataSource=table;
			lstOrders.DataTextField="fldName";
			lstOrders.DataValueField="fldOrderNumber";
			lstOrders.DataBind();
			if(lstOrders.Items.Count>0)
			{
				lstOrders.SelectedIndex=0;
				lstOrders_SelectedIndexChanged(lstOrders,null);
			}
		}

	}
}
