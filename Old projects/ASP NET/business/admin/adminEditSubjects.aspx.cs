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
using System.IO;

namespace business.admin
{
	public class adminEditSubjects : System.Web.UI.Page
	{
		
		cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,"");
		string businessKey="";
		string subjectPictureFile="";

		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblWebName;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ListBox lstSubjects;
		protected System.Web.UI.WebControls.TextBox txtText;
		protected System.Web.UI.WebControls.Button btnNew;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.TextBox txtAddNewSubject;
		protected System.Web.UI.WebControls.Button btnAddNewSubject;
		protected System.Web.UI.WebControls.Button btnRemoveSelected;
		protected System.Web.UI.WebControls.Button btnRemoveCancel;
		protected System.Web.UI.WebControls.Button btnCancelAddNew;
		protected System.Web.UI.WebControls.Panel pnlAddNew;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Button btnUploadPicture;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.Panel pnlRemove;

		private void reloadPage(string message)
		{
			Response.Redirect("adminEditSubjects.aspx?message="+message);
		}//reloadPage()

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			businessKey=Session["businessKey"].ToString();
			if(!IsPostBack)
			{
				lblMessage.Text=Request.QueryString.Get("message");
				lblWebName.Text=Request.QueryString.Get("webName");
				//reload subjects
				conn.createSelect("tblSubjects","*","fldBusinessKey='"+businessKey+"'","","");
				DataTable table1=conn.runSelect();
				lstSubjects.DataSource=table1;
				lstSubjects.DataTextField="fldName";
				lstSubjects.DataValueField="fldKey";
				lstSubjects.DataBind();
				if(lstSubjects.Items.Count>0)
				{
					if(Request.QueryString.Get("number")==null)
					{
						lstSubjects.SelectedIndex=0;
					}
					else
					{
						lstSubjects.SelectedIndex=int.Parse("0"+Request.QueryString.Get("number").ToString());
					}//if else
					lstSubjects_SelectedIndexChanged(null,null);
				}//if
			}//if
		}//Page_Load()

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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnUploadPicture.Click += new System.EventHandler(this.btnUploadPicture_Click);
			this.btnAddNewSubject.Click += new System.EventHandler(this.btnAddNewSubject_Click);
			this.btnCancelAddNew.Click += new System.EventHandler(this.btnCancelAddNew_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);
			this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
			this.btnRemoveCancel.Click += new System.EventHandler(this.btnRemoveCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			pnlAddNew.Visible=true;
			pnlRemove.Visible=false;
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			conn.createUpdate("tblSubjects","fldKey="+lstSubjects.SelectedValue);
			conn.addToUpdate("fldText",txtText.Text);
			conn.runUpdate();
			lblMessage.Text="Data updated";
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			pnlAddNew.Visible=false;
			pnlRemove.Visible=true;
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adminEditBusiness.aspx");
		}

		private void lstSubjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.createSelect("tblSubjects","*","fldKey="+lstSubjects.SelectedValue,"","");
			DataTable table=conn.runSelect();
			txtText.Text=table.Rows[0]["fldText"].ToString();
			try
			{
				Image1.ImageUrl=Global.picturePath+table.Rows[0]["fldPicture"].ToString();
				//use FileStream to get image properties
				FileStream fs=new FileStream(Image1.ImageUrl,FileMode.Open,FileAccess.Read,FileShare.Read);
				System.Drawing.Image image=System.Drawing.Image.FromStream(fs);
				double heightFactor=Global.MAX_SMALL_IMAGE_HEIGHT/(double)image.Height;
				double width=(double)(image.Width*heightFactor);
				double height=(double)(image.Height*heightFactor);
				fs.Close();
				Image1.Width=(int)width;
				Image1.Height=(int)height;
				//add "?image=" to image name to force browser to download image from server
				Image1.ImageUrl=Image1.ImageUrl+"?image="+DateTime.Now.Ticks.ToString();
			}
			catch(Exception ex)
			{
				//no image uploaded yet, or image not found, possible default image?
				string s=ex.Message;
			}//catch
		}

		private void btnAddNewSubject_Click(object sender, System.EventArgs e)
		{
			conn.createInsert("tblSubjects");
			conn.addToInsert("fldName",txtAddNewSubject.Text);
			conn.addToInsert("fldBusinessKey",businessKey);
			conn.runInsert();
			reloadPage("New subject added");
		}

		private void btnCancelAddNew_Click(object sender, System.EventArgs e)
		{
			pnlAddNew.Visible=false;
			pnlRemove.Visible=false;
		}

		private void btnRemoveSelected_Click(object sender, System.EventArgs e)
		{
			if(lstSubjects.SelectedIndex>-1)
			{
				conn.createDelete("tblSubjects","fldKey="+lstSubjects.SelectedValue);
				conn.runDelete();
				reloadPage("Subject was removed");
			}
			else
			{
				reloadPage("Select subject to remove!");
			}//if else
		}

		private void btnUploadPicture_Click(object sender, System.EventArgs e)
		{
			string pictureMessage="";
			string fileToDelete="";
			try
			{
				//set filename for later remove previous picture
				int indexOf=Image1.ImageUrl.LastIndexOf("?");
				if(indexOf>-1)
				{
					fileToDelete=Image1.ImageUrl.Substring(0,indexOf);
				}//if
				//upload new picture
				string fileName="subjectPicture"+DateTime.Now.Ticks.ToString();
				string fileExtention=File1.Value.Substring(File1.Value.LastIndexOf("."));
				fileName=businessKey+"_"+fileName+fileExtention;
				//upload new picture
				File1.PostedFile.SaveAs(Global.picturePath+fileName);
				File1.Dispose();
				//update image in database
				conn.createUpdate("tblSubjects","fldKey="+lstSubjects.SelectedValue);
				conn.addToUpdate("fldPicture",fileName);
				conn.runUpdate();
				pictureMessage="Picture uploaded!&number="+lstSubjects.SelectedIndex.ToString();
				//remove previous picture
				File.Delete(fileToDelete);
			}
			catch(Exception ex)
			{
				//no file, or file error
				pictureMessage="Upload error!&number="+lstSubjects.SelectedIndex.ToString();
			}//catch
			finally
			{
				reloadPage(pictureMessage);
			}//finally

		}

		private void btnRemoveCancel_Click(object sender, System.EventArgs e)
		{
			pnlAddNew.Visible=false;
			pnlRemove.Visible=false;
		}
	}//class
}//namespace
