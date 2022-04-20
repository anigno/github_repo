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

namespace webName.admin
{
	public class editWebName : basePage
	{

		cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,Global.adminPassword);
		string webName="";
		
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList drpWebType;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList drpWebColor;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Button btnEditSubjects;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtSecondText;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtMainText;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.TextBox txtCellPhone;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Image imgMain;
		protected System.Web.UI.WebControls.Image imgLogo;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileLogoImage;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileMainImage;
		protected System.Web.UI.WebControls.TextBox txtAbout;
		protected System.Web.UI.WebControls.Button btnUploadMainImage;
		protected System.Web.UI.WebControls.Button btnUploadLogoImage;
		protected System.Web.UI.WebControls.Button btnDummie;
		protected System.Web.UI.WebControls.TextBox txtRealName;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label lblWebName;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			PageUrl="editWebName.aspx";
			lblMessage.Text=getReloadMessage();
			webName=Session["webName"].ToString();
			lblWebName.Text=webName;
			getReloadMessage();
			if(!IsPostBack)
			{
				//get webName data
				conn.createSelect("tblMain","*","","","");
				DataTable table=conn.runSelect();
				//fill dropDownLists
				string selectedColorValue=table.Rows[0]["fldColor"].ToString();
				string selectedTypeValue=table.Rows[0]["fldType"].ToString();
				cUtils.fillDropDownListFromDataArray(drpWebType,Global.webTypeArray,selectedTypeValue);
				cUtils.fillDropDownListFromDataArray(drpWebColor,Global.webColorArray,selectedColorValue);
				//fill other textBoxes
				txtAddress.Text=table.Rows[0]["fldAddress"].ToString();
				txtCellPhone.Text=table.Rows[0]["fldCellPhone"].ToString();
				txtEmail.Text=table.Rows[0]["fldEmail"].ToString();
				txtFax.Text=table.Rows[0]["fldFax"].ToString();
				txtMainText.Text=table.Rows[0]["fldMainText"].ToString();
				txtSecondText.Text=table.Rows[0]["fldSecondText"].ToString();
				txtPhone.Text=table.Rows[0]["fldPhone"].ToString();
				txtAbout.Text=table.Rows[0]["fldAbout"].ToString();
				txtRealName.Text=table.Rows[0]["fldRealName"].ToString();
				//load images
				try
				{
					//mainImage
					imgMain.ImageUrl=Global.imagesPath+table.Rows[0]["fldMainImage"].ToString();
					cUtils.setImageWidth(imgMain,Global.PREVIEW_IMAGE_HEIGHT);
					//logoImage
					imgLogo.ImageUrl=Global.imagesPath+table.Rows[0]["fldLogoImage"].ToString();
					cUtils.setImageWidth(imgLogo,Global.PREVIEW_IMAGE_HEIGHT);
				}
				catch
				{
				}
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
			this.btnUploadLogoImage.Click += new System.EventHandler(this.btnUploadLogoImage_Click);
			this.btnUploadMainImage.Click += new System.EventHandler(this.btnUploadMainImage_Click);
			this.btnEditSubjects.Click += new System.EventHandler(this.btnEditSubjects_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("webName.aspx");
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			conn.createUpdate("tblMain","fldWebName='"+webName+"'");
			conn.addToUpdate("fldType",drpWebType.SelectedValue);
			conn.addToUpdate("fldColor",drpWebColor.SelectedValue);
			conn.addToUpdate("fldAddress",txtAddress.Text);
			conn.addToUpdate("fldPhone",txtPhone.Text);
			conn.addToUpdate("fldCellPhone",txtCellPhone.Text);
			conn.addToUpdate("fldFax",txtFax.Text);
			conn.addToUpdate("fldEmail",txtEmail.Text);
			conn.addToUpdate("fldMainText",txtMainText.Text);
			conn.addToUpdate("fldSecondText",txtSecondText.Text);
			conn.addToUpdate("fldAbout",txtAbout.Text);
			conn.addToUpdate("fldRealName",txtRealName.Text);
			conn.runUpdate();
			reloadPage("Updated!");

		}

		private void btnUploadMainImage_Click(object sender, System.EventArgs e)
		{
			string message="";
			try
			{
				if(fileMainImage.PostedFile.FileName!="")
				{
					string fileName=webName+"_mainImage"+cUtils.getFileExtention(fileMainImage.PostedFile.FileName);
					fileMainImage.PostedFile.SaveAs(Global.imagesPath+fileName);
					conn.createUpdate("tblMain","fldWebName='"+webName+"'");
					conn.addToUpdate("fldMainImage",fileName);
					conn.runUpdate();
					message="Main image uploaded!";
				}//if
			}
			catch
			{
				message="Error uploading main image";
			}
			finally
			{
				reloadPage(message);
			}
		}

		private void btnUploadLogoImage_Click(object sender, System.EventArgs e)
		{
			string message="";
			try
			{
				if(fileLogoImage.PostedFile.FileName!="")
				{
					string fileName=webName+"_logoImage"+cUtils.getFileExtention(fileLogoImage.PostedFile.FileName);
					fileLogoImage.PostedFile.SaveAs(Global.imagesPath+fileName);
					conn.createUpdate("tblMain","fldWebName='"+webName+"'");
					conn.addToUpdate("fldLogoImage",fileName);
					conn.runUpdate();
					message="Logo image uploaded";
				}//if
			}
			catch
			{
				message="Error uploading logo image!";
			}
			finally
			{
				reloadPage(message);
			}
		}

		private void btnEditSubjects_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("editSubjects.aspx");
		}
	}//class
}//namespace
