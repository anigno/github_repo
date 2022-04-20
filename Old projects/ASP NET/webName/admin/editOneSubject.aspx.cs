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
using System.IO;
using anignoLibrary.ClassLibraryMdbConnection;

namespace webName.admin
{
	public class editOneSubject : basePage
	{
		string webName="";
		string subjectKey="";
		cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,Global.adminPassword);

		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.ListBox lstProducts;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.Label lblWebName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Panel panelAddNew;
		protected System.Web.UI.WebControls.Button btnCancelAddNew;
		protected System.Web.UI.WebControls.Panel panelRemove;
		protected System.Web.UI.WebControls.Button btnRemoveYes;
		protected System.Web.UI.WebControls.Button btnRemoveNo;
		protected System.Web.UI.WebControls.TextBox txtAddNew;
		protected System.Web.UI.WebControls.TextBox txtText;
		protected System.Web.UI.WebControls.Image imgProduct;
		protected System.Web.UI.WebControls.Button btnUpload;
		protected System.Web.UI.WebControls.Button btnDummie;
		protected System.Web.UI.WebControls.Panel panelEdit;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.Button btnAddNewProduct;

		private void panelOff()
		{
			panelAddNew.Visible=false;
			panelRemove.Visible=false;
		}//panelOff()
		
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			PageUrl="editOneSubject.aspx";
			webName=Session["webName"].ToString();
			subjectKey=Session["subjectKey"].ToString();
			lblMessage.Text=getReloadMessage();
			lblWebName.Text=webName;
			panelOff();
			if(!IsPostBack)
			{
				//get subject name
				conn.createSelect("tblSubjects","*","fldKey="+subjectKey,"","");
				DataTable table=conn.runSelect();
				lblSubject.Text=table.Rows[0]["fldName"].ToString();
				//get products for subject
				conn.createSelect("tblProducts","*","fldSubjectKey="+subjectKey,"","");
				table=conn.runSelect();
				lstProducts.DataSource=table;
				lstProducts.DataTextField="fldName";
				lstProducts.DataValueField="fldKey";
				lstProducts.DataBind();

			}//if

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
			this.btnAddNewProduct.Click += new System.EventHandler(this.btnAddNewProduct_Click);
			this.btnCancelAddNew.Click += new System.EventHandler(this.btnCancelAddNew_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.lstProducts.SelectedIndexChanged += new System.EventHandler(this.lstProducts_SelectedIndexChanged);
			this.btnRemoveYes.Click += new System.EventHandler(this.btnRemoveYes_Click);
			this.btnRemoveNo.Click += new System.EventHandler(this.btnRemoveNo_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			panelAddNew.Visible=true;
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			
			if(lstProducts.SelectedIndex>-1)
			{
				panelRemove.Visible=true;
			}
			else
			{
				lblMessage.Text="Select product to remove!";
			}//if else
		}

		private void btnCancelAddNew_Click(object sender, System.EventArgs e)
		{
			panelOff();
		}

		private void btnRemoveNo_Click(object sender, System.EventArgs e)
		{
			panelOff();
		}

		private void btnRemoveYes_Click(object sender, System.EventArgs e)
		{
			conn.createDelete("tblProducts","fldKey="+lstProducts.SelectedValue);
			conn.runDelete();
			reloadPage("Product removed!");
		}

		private void btnAddNewProduct_Click(object sender, System.EventArgs e)
		{
			conn.createInsert("tblProducts");
			conn.addToInsert("fldWebName",webName);
			conn.addToInsert("fldSubjectKey",subjectKey);
			conn.addToInsert("fldName",txtAddNew.Text);
			conn.runInsert();
			reloadPage("Product added!");
		}

		private void lstProducts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			panelEdit.Visible=true;
			conn.createSelect("tblProducts","*","fldKey="+lstProducts.SelectedValue,"","");
			DataTable table=conn.runSelect();
			txtText.Text=table.Rows[0]["fldText"].ToString();
			imgProduct.ImageUrl=Global.imagesPath+table.Rows[0]["fldImage"].ToString();
			cUtils.setImageWidth(imgProduct,Global.PREVIEW_IMAGE_HEIGHT);
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			conn.createUpdate("tblProducts","fldKey="+lstProducts.SelectedValue);
			conn.addToUpdate("fldText",txtText.Text);
			conn.runUpdate();
			reloadPage("Text updated!");
		}

		private void btnUpload_Click(object sender, System.EventArgs e)
		{
			string message="";
			try
			{
				string fileName=webName+"_subject"+subjectKey.ToString()+"_product"+lstProducts.SelectedValue;
				fileName+=cUtils.getFileExtention(File1.PostedFile.FileName);
				File1.PostedFile.SaveAs(Global.imagesPath+fileName);
				conn.createUpdate("tblProducts","fldKey="+lstProducts.SelectedValue);
				conn.addToUpdate("fldImage",fileName);
				conn.runUpdate();
				message="Image uploaded!";
			}
			catch
			{
				message="Image upload error!";
			}
			finally
			{
				lstProducts_SelectedIndexChanged(null,null);
				lblMessage.Text=message;
				//reloadPage(message);
			}
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("editSubjects.aspx");
		}
	}//class
}//namespace
