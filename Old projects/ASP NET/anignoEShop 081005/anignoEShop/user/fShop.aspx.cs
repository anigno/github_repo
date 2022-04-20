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
using anignoEShop.classes;

namespace anignoEShop.user
{
	public class fShop : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox lstSubjects;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgProducts;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DataGrid dgBasket;
		protected System.Web.UI.WebControls.Label lblBasket;
		protected System.Web.UI.WebControls.Label lblSum;
		protected System.Web.UI.WebControls.Button btnBuy;
	
		cDatabaseConnection con=new cDatabaseConnection(cUtil.publicDB,"");

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				//update subjects list
				bool hasItems=cUtil.updateSubjectsList(con,lstSubjects);
				if(hasItems)
				{
					lstSubjects.SelectedIndex=0;
					lstSubjects_SelectedIndexChanged(lstSubjects,null);
				}
				//check if has session basket, if not create it
				if(Session["basket"]==null)buildBasketSession();
				//force refresh basket, if return from cancel at fUserData
				refreshBasket();
			}
		}

		//create dataTable and session for basket
		private void buildBasketSession()
		{
			DataTable basketTable=new DataTable();
			basketTable=new DataTable();
			basketTable.Columns.Add("fldBasketKey");
			basketTable.Columns.Add("fldKey");
			basketTable.Columns.Add("fldName");
			basketTable.Columns.Add("fldCount");
			basketTable.Columns.Add("fldPrise");
			Session["basket"]=basketTable;
			Session.Timeout=3600;
		}
		//refresh dgBasket, if has items, calculate sum and show btnBuy
		private void refreshBasket()
		{
			//check if has session basket, if not create it
			if(Session["basket"]==null)buildBasketSession();
			DataTable basketTable=(DataTable)(Session["basket"]);
			if(basketTable.Rows.Count>0)
			{
				dgBasket.DataSource=basketTable;
				dgBasket.DataBind();
				lblBasket.Visible=true;
				lblSum.Visible=true;
				btnBuy.Visible=true;
				dgBasket.Visible=true;
			}
			else
			{
				lblBasket.Visible=false;
				lblSum.Visible=false;
				btnBuy.Visible=false;
				dgBasket.Visible=false;
			}
		}

		//return total prise sum of products, prise*count
		private double calculateBasketSum()
		{
			DataTable basketTable=(DataTable)(Session["basket"]);
			double sum=0;
			for(int i=0;i<basketTable.Rows.Count;i++)
			{
				double productPrise=Double.Parse(basketTable.Rows[i]["fldPrise"].ToString());
				double productCount=Double.Parse(basketTable.Rows[i]["fldCount"].ToString());
				sum+=productPrise*productCount;
			}
			return sum;
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
			this.dgProducts.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgProducts_ItemCommand);
			this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);
			this.dgBasket.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgBasket_ItemCommand);
			this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lstSubjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cUtil.updateProductsDataGrid(con,dgProducts,lstSubjects);
		}

		//dgProducts row events
		private void dgProducts_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string key=e.Item.Cells[0].Text;
			string commandName=e.CommandName.ToString();
			DropDownList ddl=(DropDownList)e.Item.Cells[5].Controls[1];
			string addCount=ddl.SelectedValue;
			string addPrise=e.Item.Cells[3].Text;
			string addName=e.Item.Cells[2].Text;
			
			//add product to basket
			if(commandName.Equals("add"))
			{
				//check if has session basket, if not create it
				if(Session["basket"]==null)buildBasketSession();
				//get the dataTable and create new row
				DataTable basketTable=(DataTable)(Session["basket"]);
				DataRow row=basketTable.NewRow();
				row["fldBasketKey"]=DateTime.Now.Ticks;
				row["fldKey"]=key;
				row["fldCount"]=addCount;
				row["fldPrise"]=addPrise;
				row["fldName"]=addName;
				basketTable.Rows.Add(row);
				//refresh basket and calculate total sum
				refreshBasket();
				lblSum.Text=calculateBasketSum().ToString();
			}

		}

		//dgBasket row events
		private void dgBasket_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//remove product row from basket
			if(e.CommandName.Equals("remove"))
			{
				//check if has session basket, if not create it
				if(Session["basket"]==null)buildBasketSession();
				DataTable basketTable=(DataTable)(Session["basket"]);
				int index=e.Item.DataSetIndex;
				//protect from browser refresh at remove from basket
				try
				{
					basketTable.Rows.RemoveAt(index);
				}
				catch(Exception ex)
				{
					System.Console.WriteLine(ex.Message);
				}
				refreshBasket();
				lblSum.Text=calculateBasketSum().ToString();
			}
		}

		private void btnBuy_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("fUserData.aspx");
		}
	}//class fUser
}//namespace
