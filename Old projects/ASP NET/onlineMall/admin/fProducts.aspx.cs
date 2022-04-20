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
using anignoLibrary.utils;

namespace onlineMall.admin
{
	public class fProducts : System.Web.UI.Page
	{
		
		cDatabaseConnection conn=new cDatabaseConnection(Global.storeDataMdb,Global.ADMIN_PASSWORD);
		string currentSubjectKey="";
		string currentStoreKey="";

		protected System.Web.UI.WebControls.ListBox lstProducts;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.CheckBox chkShow;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Panel panelData;
		protected System.Web.UI.WebControls.Button btnUploadImage;
		protected System.Web.UI.WebControls.Panel panelImage;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtPrise;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Button btnUp;
		protected System.Web.UI.WebControls.Button btnDown;
		protected System.Web.UI.WebControls.Button btnNewSubjectCancel;
		protected System.Web.UI.WebControls.Button btnNewSubjectOK;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Panel panelAddNew;
		protected System.Web.UI.WebControls.TextBox txtNewName;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileProductImage;
		protected System.Web.UI.WebControls.Image imgProduct;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnRemoveOK;
		protected System.Web.UI.WebControls.Button btnRemoveNo;
		protected System.Web.UI.WebControls.Panel panelRemove;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void refreshList(int lastIndex)
		{
			conn.createSelect("tblProducts","*","fldSubjectKey="+currentSubjectKey,"fldIndex","");
			DataTable table=conn.runSelect();
			lstProducts.DataSource=table;
			lstProducts.DataTextField="fldName";
			lstProducts.DataValueField="fldKey";
			lstProducts.DataBind();
			lstProducts.SelectedIndex=lastIndex;
		}//refreshList()

		private void refreshData()
		{
			conn.createSelect("tblProducts","*","fldKey="+lstProducts.SelectedValue,"","");
			DataTable table=conn.runSelect();
			DataRow row=table.Rows[0];
			txtName.Text=row["fldName"].ToString();
			txtDescription.Text=row["fldDescription"].ToString();
			txtPrise.Text=row["fldPrise"].ToString();
			chkShow.Checked=bool.Parse(row["fldShow"].ToString());
			imgProduct.ImageUrl=Global.imagesPath+row["fldImage"].ToString();
			cImageManupulation.setImageWidthByHeight(imgProduct,Global.PREV_IMAGE_HEIGHT);
		}//refreshData()



		private void Page_Load(object sender, System.EventArgs e)
		{
			currentSubjectKey=Session["currentSubjectKey"].ToString();
			currentStoreKey=Session["currentStoreKey"].ToString();
			if(!IsPostBack)
			{
				refreshList(-1);
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
			this.btnNewSubjectOK.Click += new System.EventHandler(this.btnNewSubjectOK_Click);
			this.btnNewSubjectCancel.Click += new System.EventHandler(this.btnNewSubjectCancel_Click);
			this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.lstProducts.SelectedIndexChanged += new System.EventHandler(this.lstProducts_SelectedIndexChanged);
			this.btnRemoveOK.Click += new System.EventHandler(this.btnRemoveOK_Click);
			this.btnRemoveNo.Click += new System.EventHandler(this.btnRemoveNo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			panelData.Visible=false;
			panelImage.Visible=false;
			panelAddNew.Visible=true;
			panelRemove.Visible=false;
			txtNewName.Text="";
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("fSubjects.aspx");
		}

		private void btnNewSubjectOK_Click(object sender, System.EventArgs e)
		{
			conn.createInsert("tblProducts");
			conn.addToInsert("fldName",txtNewName.Text);
			conn.addToInsert("fldStoreKey",currentStoreKey);
			conn.addToInsert("fldSubjectKey",currentSubjectKey);
			conn.runInsert();
			refreshList(-1);
			panelAddNew.Visible=false;
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			conn.createUpdate("tblProducts","fldKey="+lstProducts.SelectedValue);
			conn.addToUpdate("fldName",txtName.Text);
			conn.addToUpdate("fldDescription",txtDescription.Text);
			conn.addToUpdate("fldPrise",txtPrise.Text);
			conn.addToUpdate("fldShow",chkShow.Checked);
			conn.runUpdate();
			refreshList(lstProducts.SelectedIndex);
		}

		private void btnNewSubjectCancel_Click(object sender, System.EventArgs e)
		{
			panelAddNew.Visible=false;
		}

		private void lstProducts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			panelData.Visible=true;
			panelImage.Visible=true;
			panelAddNew.Visible=false;
			panelRemove.Visible=false;
			refreshData();
		}

		private void btnUploadImage_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(fileProductImage.PostedFile.ContentLength<=Global.MAX_IMAGE_SIZE)
				{
					string extention=cFileManipulation.getExtention(fileProductImage.PostedFile.FileName);
					fileProductImage.PostedFile.SaveAs(Global.imagesPath+currentStoreKey+"subject"+currentSubjectKey+"product"+lstProducts.SelectedValue+extention);
					conn.createUpdate("tblProducts","fldKey="+lstProducts.SelectedValue);
					conn.addToUpdate("fldImage",currentStoreKey+"subject"+currentSubjectKey+"product"+lstProducts.SelectedValue+extention);
					conn.runUpdate();
					lblMessage.Text="Image uploaded successfully!";
					refreshData();
				}
				else
				{
					lblMessage.Text="Image exceed "+Global.MAX_IMAGE_SIZE.ToString()+" bytes!";
				}//if else
			}
			catch
			{
				lblMessage.Text="Image upload error!";
			}//catch
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if(lstProducts.SelectedIndex>-1)
			{
				panelAddNew.Visible=false;
				panelData.Visible=false;
				panelImage.Visible=false;
				panelRemove.Visible=true;
			}//if
		}

		private void btnRemoveOK_Click(object sender, System.EventArgs e)
		{
			conn.createDelete("tblProducts","fldKey="+lstProducts.SelectedValue);
			conn.runDelete();
			refreshList(-1);
		}

		private void btnRemoveNo_Click(object sender, System.EventArgs e)
		{
			panelRemove.Visible=false;
		}
	}//class
}//namespace
