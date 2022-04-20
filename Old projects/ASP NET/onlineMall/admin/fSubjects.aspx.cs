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
	public class fSubjects : System.Web.UI.Page
	{
		cDatabaseConnection conn=new cDatabaseConnection(Global.storeDataMdb,Global.ADMIN_PASSWORD);
		string currentStoreKey="";

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ListBox lstSubjects;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.Button btnEditProducts;
		protected System.Web.UI.WebControls.Button btnUp;
		protected System.Web.UI.WebControls.Button btnDown;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.Image imgSubject;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileSubjectImage;
		protected System.Web.UI.WebControls.CheckBox chkShow;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Panel panelAddNew;
		protected System.Web.UI.WebControls.TextBox txtNewSubject;
		protected System.Web.UI.WebControls.Button btnNewSubjectOK;
		protected System.Web.UI.WebControls.Button btnNewSubjectCancel;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnUploadImage;
		protected System.Web.UI.WebControls.Panel panelData;
		protected System.Web.UI.WebControls.Panel panelImage;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label2;

		private void refreshList(int lastIndex)
		{
			conn.createSelect("tblSubjects","*","fldStoreKey="+currentStoreKey,"fldIndex","");
			DataTable table=conn.runSelect();
			lstSubjects.DataSource=table;
			lstSubjects.DataTextField="fldName";
			lstSubjects.DataValueField="fldKey";
			lstSubjects.DataBind();
			lstSubjects.SelectedIndex=lastIndex;
		}
		
		private void refreshSubjectData()
		{
			conn.createSelect("tblSubjects","*","fldKey="+lstSubjects.SelectedValue,"","");
			DataTable table=conn.runSelect();
			DataRow row=table.Rows[0];
			txtName.Text=row["fldName"].ToString();
			txtDescription.Text=row["fldDescription"].ToString();
			chkShow.Checked=bool.Parse(row["fldShow"].ToString());
			imgSubject.ImageUrl=Global.imagesPath+row["fldImage"].ToString();
			cImageManupulation.setImageWidthByHeight(imgSubject,Global.PREV_IMAGE_HEIGHT);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.btnEditProducts.Click += new System.EventHandler(this.btnEditProducts_Click);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);
			this.btnNewSubjectOK.Click += new System.EventHandler(this.btnNewSubjectOK_Click);
			this.btnNewSubjectCancel.Click += new System.EventHandler(this.btnNewSubjectCancel_Click);
			this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lstSubjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			panelData.Visible=true;
			panelImage.Visible=true;
			refreshSubjectData();
			Session["currentSubjectKey"]=lstSubjects.SelectedValue;
		}

		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			panelAddNew.Visible=true;
			panelData.Visible=false;
			panelImage.Visible=false;
			txtName.Text="";
			txtDescription.Text="";
			chkShow.Checked=true;
		}

		private void btnNewSubjectOK_Click(object sender, System.EventArgs e)
		{
			conn.createInsert("tblSubjects");
			conn.addToInsert("fldName",txtNewSubject.Text);
			conn.addToInsert("fldStoreKey",currentStoreKey);
			conn.runInsert();
			refreshList(-1);
			panelAddNew.Visible=false;
		}

		private void btnNewSubjectCancel_Click(object sender, System.EventArgs e)
		{
			panelAddNew.Visible=false;
			refreshList(-1);
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			conn.createUpdate("tblSubjects","fldKey="+lstSubjects.SelectedValue);
			conn.addToUpdate("fldName",txtName.Text);
			conn.addToUpdate("fldDescription",txtDescription.Text);
			conn.addToUpdate("fldShow",chkShow.Checked);
			conn.runUpdate();
			refreshList(lstSubjects.SelectedIndex);
		}

		private void btnUploadImage_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(fileSubjectImage.PostedFile.ContentLength<=Global.MAX_IMAGE_SIZE)
				{
					string extention=cFileManipulation.getExtention(fileSubjectImage.PostedFile.FileName);
					fileSubjectImage.PostedFile.SaveAs(Global.imagesPath+currentStoreKey+"subject"+lstSubjects.SelectedValue+extention);
					conn.createUpdate("tblSubjects","fldKey="+lstSubjects.SelectedValue);
					conn.addToUpdate("fldImage",currentStoreKey+"subject"+lstSubjects.SelectedValue+extention);
					conn.runUpdate();
					refreshSubjectData();
					lblMessage.Text="Image uploaded successfully!";
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
		
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("fStoreData.aspx");
		}

		private void btnEditProducts_Click(object sender, System.EventArgs e)
		{
			if(lstSubjects.SelectedIndex>-1)
			{
				Response.Redirect("fProducts.aspx");
			}//if
		}
	}//class
}//namespace
