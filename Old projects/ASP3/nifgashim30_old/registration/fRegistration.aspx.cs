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

namespace nifgashim30.registration
{
	public class fRegistration : System.Web.UI.Page
	{
		cDatabaseConnection conRegisteredUsers=new cDatabaseConnection(Global.registeredUsersMdbFilePath,"");
		string username="";
		string registrationAction="";
		#region Form controls
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtUserName;
		protected System.Web.UI.WebControls.DropDownList drpSex;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList drpRegion;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox txtSelfDescription;
		protected System.Web.UI.WebControls.DropDownList drpSport;
		protected System.Web.UI.WebControls.DropDownList drpOrigin;
		protected System.Web.UI.WebControls.DropDownList drpLuck;
		protected System.Web.UI.WebControls.DropDownList drpChangeHome;
		protected System.Web.UI.WebControls.DropDownList drpBody;
		protected System.Web.UI.WebControls.DropDownList drpHeight;
		protected System.Web.UI.WebControls.DropDownList drpSmoke;
		protected System.Web.UI.WebControls.DropDownList drpChildren;
		protected System.Web.UI.WebControls.DropDownList drpFamilyState;
		protected System.Web.UI.WebControls.DropDownList drpReligion;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.DropDownList drpMonth;
		protected System.Web.UI.WebControls.DropDownList drpDay;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtPassword2;
		protected System.Web.UI.WebControls.TextBox txtPassword1;
		protected System.Web.UI.WebControls.Button btnContinue;
		protected System.Web.UI.WebControls.DropDownList drpRequiredSex;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator7;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator9;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator5;
		protected System.Web.UI.WebControls.DropDownList drpEducation;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.TextBox txtStudy;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtWork;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.DropDownList drpAconomicState;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator6;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator7;
		protected System.Web.UI.WebControls.DropDownList drpYear;
		protected System.Web.UI.WebControls.DropDownList drpRelationshipCause;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.DropDownList drpMinAge;
		protected System.Web.UI.WebControls.DropDownList drpMaxAge;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.CheckBox chkSingle;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.CheckBox chkSeperated;
		protected System.Web.UI.WebControls.CheckBox chkDevoursed;
		protected System.Web.UI.WebControls.CheckBox chkWiddow;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.CheckBox chkDoctorate;
		protected System.Web.UI.WebControls.CheckBox chkSecondDegree;
		protected System.Web.UI.WebControls.CheckBox chkFirstDegree;
		protected System.Web.UI.WebControls.CheckBox chkSomeDegree;
		protected System.Web.UI.WebControls.CheckBox chkHighScholl;
		protected System.Web.UI.WebControls.TextBox txtOtherPersonDescription;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator8;
		protected System.Web.UI.WebControls.DropDownList drpRequestedRegion;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator8;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Button btnMainPage;
		protected System.Web.UI.WebControls.Button btnDummy;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label2;
		#endregion
        	
		private void fillControlsFromDataArrays()
		{
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayAconomicState,drpAconomicState);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayBody,drpBody);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayChangeHome,drpChangeHome);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayChildren,drpChildren);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayEducation,drpEducation);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayFamilyState,drpFamilyState);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayLuck,drpLuck);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayOrigin,drpOrigin);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayRegion,drpRegion);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayRelationshipCouse,drpRelationshipCause);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayReligion,drpReligion);
			cListBoxManipulation.fillListControlFromDataArray(Global.arraySex,drpSex);
			cListBoxManipulation.fillListControlFromDataArray(Global.arraySex,drpRequiredSex);
			cListBoxManipulation.fillListControlFromDataArray(Global.arraySmoke,drpSmoke);
			cListBoxManipulation.fillListControlFromDataArray(Global.arraySport,drpSport);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayHeight,drpHeight);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayYear,drpYear);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayMonth,drpMonth);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayDay,drpDay);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayRegion,drpRequestedRegion);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayAge,drpMinAge);
			cListBoxManipulation.fillListControlFromDataArray(Global.arrayAge,drpMaxAge);
		}//fillControlsFromDataArrays()
		
		private void registerNewUser()
		{
			lblMessage.Visible=false;
			//check for username not already exist
			conRegisteredUsers.createSelect("tblRegisteredUsers","*","fldUsername='"+txtUserName.Text+"'","","");
			DataTable table=conRegisteredUsers.runSelect();
			if(table.Rows.Count>0)
			{
				//username exist
				lblMessage.Text="!שם משתמש תפוס";
				lblMessage.Visible=true;
			}
			else
			{
				//username does not exist, will add username
				conRegisteredUsers.createInsert("tblRegisteredUsers");
				conRegisteredUsers.addToInsert("fldRegistrationDate",DateTime.Now.ToOADate());
				conRegisteredUsers.addToInsert("fldUsername",txtUserName.Text);
				conRegisteredUsers.addToInsert("fldPassword",txtPassword1.Text);
				conRegisteredUsers.addToInsert("fldEmail",txtEmail.Text);
				conRegisteredUsers.addToInsert("fldSex",int.Parse(drpSex.SelectedValue));
				conRegisteredUsers.addToInsert("fldRequiredSex",int.Parse(drpRequiredSex.SelectedValue));
				conRegisteredUsers.addToInsert("fldRelationshipCause",int.Parse(drpRelationshipCause.SelectedValue));
				DateTime birthDate=new DateTime(int.Parse(drpYear.SelectedValue),int.Parse(drpMonth.SelectedValue),int.Parse(drpDay.SelectedValue));
				conRegisteredUsers.addToInsert("fldBirthDate",birthDate.ToOADate());
				conRegisteredUsers.addToInsert("fldRegion",int.Parse(drpRegion.SelectedValue));
				conRegisteredUsers.addToInsert("fldCity",txtCity.Text);
				conRegisteredUsers.addToInsert("fldReligion",int.Parse(drpReligion.SelectedValue));
				conRegisteredUsers.addToInsert("fldFamilyState",int.Parse(drpFamilyState.SelectedValue));
				conRegisteredUsers.addToInsert("fldChildren",int.Parse(drpChildren.SelectedValue));
				conRegisteredUsers.addToInsert("fldSelfDescription",txtSelfDescription.Text);
				conRegisteredUsers.addToInsert("fldSmoke",int.Parse(drpSmoke.SelectedValue));
				conRegisteredUsers.addToInsert("fldHeight",int.Parse(drpHeight.SelectedValue));
				conRegisteredUsers.addToInsert("fldBody",int.Parse(drpBody.SelectedValue));
				conRegisteredUsers.addToInsert("fldChangeHome",int.Parse(drpChangeHome.SelectedValue));
				conRegisteredUsers.addToInsert("fldLuck",int.Parse(drpLuck.SelectedValue));
				conRegisteredUsers.addToInsert("fldOrigin",int.Parse(drpOrigin.SelectedValue));
				conRegisteredUsers.addToInsert("fldSport",int.Parse(drpSport.SelectedValue));
				conRegisteredUsers.addToInsert("fldEducation",int.Parse(drpEducation.SelectedValue));
				conRegisteredUsers.addToInsert("fldStudy",txtStudy.Text);
				conRegisteredUsers.addToInsert("fldWork",txtWork.Text);
				conRegisteredUsers.addToInsert("fldAconomicState",int.Parse(drpAconomicState.SelectedValue));
				conRegisteredUsers.addToInsert("fldOtherPersonDescription",txtOtherPersonDescription.Text);
				conRegisteredUsers.addToInsert("fldWantedRegion",int.Parse(drpRequestedRegion.SelectedValue));
				conRegisteredUsers.addToInsert("fldFromAge",int.Parse(drpMinAge.SelectedValue));
				conRegisteredUsers.addToInsert("fldToAge",int.Parse(drpMaxAge.SelectedValue));
				conRegisteredUsers.addToInsert("fldwantSingle",chkSingle.Checked);
				conRegisteredUsers.addToInsert("fldWantSeperated",chkSeperated.Checked);
				conRegisteredUsers.addToInsert("fldWantDevoursed",chkDevoursed.Checked);
				conRegisteredUsers.addToInsert("fldWantWiddow",chkWiddow.Checked);
				conRegisteredUsers.addToInsert("fldWantHighschool",chkHighScholl.Checked);
				conRegisteredUsers.addToInsert("fldWantSomeDegree",chkSomeDegree.Checked);
				conRegisteredUsers.addToInsert("fldWantFirstDegree",chkFirstDegree.Checked);
				conRegisteredUsers.addToInsert("fldWantSecondDegree",chkSecondDegree.Checked);
				conRegisteredUsers.addToInsert("fldWantDoctorate",chkDoctorate.Checked);
				//try again username for error with duplicate (multi teir?)
				try
				{
					conRegisteredUsers.runInsert();
					Session["username"]=txtUserName.Text;
					Response.Redirect("fAddPictures.aspx",true);
				}
				catch
				{
					lblMessage.Text="!שם משתמש תפוס";
					lblMessage.Visible=true;
				}//catch
			}//if else
		}//registerNewUser()

		private void updateUserData()
		{
			//username does not exist, will add username
			conRegisteredUsers.createUpdate("tblRegisteredUsers","fldUsername='"+txtUserName.Text+"'");
			conRegisteredUsers.addToUpdate("fldRegistrationDate",DateTime.Now.ToOADate());
			conRegisteredUsers.addToUpdate("fldUsername",txtUserName.Text);
			conRegisteredUsers.addToUpdate("fldPassword",txtPassword1.Text);
			conRegisteredUsers.addToUpdate("fldEmail",txtEmail.Text);
			conRegisteredUsers.addToUpdate("fldSex",int.Parse(drpSex.SelectedValue));
			conRegisteredUsers.addToUpdate("fldRequiredSex",int.Parse(drpRequiredSex.SelectedValue));
			conRegisteredUsers.addToUpdate("fldRelationshipCause",int.Parse(drpRelationshipCause.SelectedValue));
			DateTime birthDate=new DateTime(int.Parse(drpYear.SelectedValue),int.Parse(drpMonth.SelectedValue),int.Parse(drpDay.SelectedValue));
			conRegisteredUsers.addToUpdate("fldBirthDate",birthDate.ToOADate());
			conRegisteredUsers.addToUpdate("fldRegion",int.Parse(drpRegion.SelectedValue));
			conRegisteredUsers.addToUpdate("fldCity",txtCity.Text);
			conRegisteredUsers.addToUpdate("fldReligion",int.Parse(drpReligion.SelectedValue));
			conRegisteredUsers.addToUpdate("fldFamilyState",int.Parse(drpFamilyState.SelectedValue));
			conRegisteredUsers.addToUpdate("fldChildren",int.Parse(drpChildren.SelectedValue));
			conRegisteredUsers.addToUpdate("fldSelfDescription",txtSelfDescription.Text);
			conRegisteredUsers.addToUpdate("fldSmoke",int.Parse(drpSmoke.SelectedValue));
			conRegisteredUsers.addToUpdate("fldHeight",int.Parse(drpHeight.SelectedValue));
			conRegisteredUsers.addToUpdate("fldBody",int.Parse(drpBody.SelectedValue));
			conRegisteredUsers.addToUpdate("fldChangeHome",int.Parse(drpChangeHome.SelectedValue));
			conRegisteredUsers.addToUpdate("fldLuck",int.Parse(drpLuck.SelectedValue));
			conRegisteredUsers.addToUpdate("fldOrigin",int.Parse(drpOrigin.SelectedValue));
			conRegisteredUsers.addToUpdate("fldSport",int.Parse(drpSport.SelectedValue));
			conRegisteredUsers.addToUpdate("fldEducation",int.Parse(drpEducation.SelectedValue));
			conRegisteredUsers.addToUpdate("fldStudy",txtStudy.Text);
			conRegisteredUsers.addToUpdate("fldWork",txtWork.Text);
			conRegisteredUsers.addToUpdate("fldAconomicState",int.Parse(drpAconomicState.SelectedValue));
			conRegisteredUsers.addToUpdate("fldOtherPersonDescription",txtOtherPersonDescription.Text);
			conRegisteredUsers.addToUpdate("fldWantedRegion",int.Parse(drpRequestedRegion.SelectedValue));
			conRegisteredUsers.addToUpdate("fldFromAge",int.Parse(drpMinAge.SelectedValue));
			conRegisteredUsers.addToUpdate("fldToAge",int.Parse(drpMaxAge.SelectedValue));
			conRegisteredUsers.addToUpdate("fldwantSingle",chkSingle.Checked);
			conRegisteredUsers.addToUpdate("fldWantSeperated",chkSeperated.Checked);
			conRegisteredUsers.addToUpdate("fldWantDevoursed",chkDevoursed.Checked);
			conRegisteredUsers.addToUpdate("fldWantWiddow",chkWiddow.Checked);
			conRegisteredUsers.addToUpdate("fldWantHighschool",chkHighScholl.Checked);
			conRegisteredUsers.addToUpdate("fldWantSomeDegree",chkSomeDegree.Checked);
			conRegisteredUsers.addToUpdate("fldWantFirstDegree",chkFirstDegree.Checked);
			conRegisteredUsers.addToUpdate("fldWantSecondDegree",chkSecondDegree.Checked);
			conRegisteredUsers.addToUpdate("fldWantDoctorate",chkDoctorate.Checked);
			conRegisteredUsers.runUpdate();
			Response.Redirect("../main/fMain.aspx");
		}//updateUserData();

		private void Page_Load(object sender, System.EventArgs e)
		{
			//check for register new user or edit exist user
			registrationAction=Session["registrationAction"].ToString();
			//get username from session, must be real username or "noUser"
			username=Session["username"].ToString();
			if(!IsPostBack)
			{
				fillControlsFromDataArrays();
				if(registrationAction=="edit")
				{
					//not allow username change
					txtUserName.Enabled=false;
					//set controls to user data
					conRegisteredUsers.createSelect("tblRegisteredUsers","*","fldUsername='"+username+"'","","");
					DataTable table=conRegisteredUsers.runSelect();
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arraySex,table.Rows[0]["fldSex"].ToString(),drpSex);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arraySex,table.Rows[0]["fldRequiredSex"].ToString(),drpRequiredSex);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayRelationshipCouse,table.Rows[0]["fldRelationshipCause"].ToString(),drpRelationshipCause);
					string s=table.Rows[0]["fldBirthDate"].ToString();
					DateTime birthDate=DateTime.Parse(s);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayYear,birthDate.Year,drpYear);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayMonth,birthDate.Month,drpMonth);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayDay,birthDate.Day,drpDay);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayRegion,table.Rows[0]["fldRegion"].ToString(),drpRegion);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayReligion,table.Rows[0]["fldReligion"].ToString(),drpReligion);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayFamilyState,table.Rows[0]["fldFamilyState"].ToString(),drpFamilyState);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayChildren,table.Rows[0]["fldChildren"].ToString(),drpChildren);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arraySmoke,table.Rows[0]["fldSmoke"].ToString(),drpSmoke);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayHeight,table.Rows[0]["fldHeight"].ToString(),drpHeight);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayBody,table.Rows[0]["fldBody"].ToString(),drpBody);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayChangeHome,table.Rows[0]["fldChangeHome"].ToString(),drpChangeHome);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayLuck,table.Rows[0]["fldLuck"].ToString(),drpLuck);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayOrigin,table.Rows[0]["fldOrigin"].ToString(),drpOrigin);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arraySport,table.Rows[0]["fldSport"].ToString(),drpSport);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayEducation,table.Rows[0]["fldEducation"].ToString(),drpEducation);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayAconomicState,table.Rows[0]["fldAconomicState"].ToString(),drpAconomicState);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayRegion,table.Rows[0]["fldWantedRegion"].ToString(),drpRequestedRegion);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayAge,table.Rows[0]["fldFromAge"].ToString(),drpMinAge);
					cListBoxManipulation.setListControlIndexFromDataArray(Global.arrayAge,table.Rows[0]["fldToAge"].ToString(),drpMaxAge);
					txtUserName.Text=table.Rows[0]["fldUsername"].ToString();
					txtPassword1.TextMode=TextBoxMode.SingleLine;
					txtPassword1.Text=table.Rows[0]["fldPassword"].ToString();
					txtPassword2.TextMode=TextBoxMode.SingleLine;
					txtPassword2.Text=table.Rows[0]["fldPassword"].ToString();
					txtEmail.Text=table.Rows[0]["fldEmail"].ToString();
					txtSelfDescription.Text=table.Rows[0]["fldSelfDescription"].ToString();
					txtStudy.Text=table.Rows[0]["fldStudy"].ToString();
					txtWork.Text=table.Rows[0]["fldWork"].ToString();
					txtCity.Text=table.Rows[0]["fldCity"].ToString();
					txtOtherPersonDescription.Text=table.Rows[0]["fldOtherPersonDescription"].ToString();
					chkSingle.Checked=bool.Parse(table.Rows[0]["fldwantSingle"].ToString());
					chkSeperated.Checked=bool.Parse(table.Rows[0]["fldWantSeperated"].ToString());
					chkDevoursed.Checked=bool.Parse(table.Rows[0]["fldWantDevoursed"].ToString());
					chkWiddow.Checked=bool.Parse(table.Rows[0]["fldWantWiddow"].ToString());
					chkHighScholl.Checked=bool.Parse(table.Rows[0]["fldWantHighschool"].ToString());
					chkSomeDegree.Checked=bool.Parse(table.Rows[0]["fldWantSomeDegree"].ToString());
					chkFirstDegree.Checked=bool.Parse(table.Rows[0]["fldWantFirstDegree"].ToString());
					chkSecondDegree.Checked=bool.Parse(table.Rows[0]["fldWantSecondDegree"].ToString());
					chkDoctorate.Checked=bool.Parse(table.Rows[0]["fldWantDoctorate"].ToString());
				}//if
			}//if !isPostBack
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
			this.btnDummy.Click += new System.EventHandler(this.btnDummy_Click);
			this.btnMainPage.Click += new System.EventHandler(this.btnMainPage_Click);
			this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnContinue_Click(object sender, System.EventArgs e)
		{
			if(registrationAction=="newUser")
			{
				registerNewUser();
			}//if
			if(registrationAction=="edit")
			{
				updateUserData();
			}//if

		}//btnContinue_Click()

		private void btnMainPage_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../main/fMain.aspx");
		}

		private void btnDummy_Click(object sender, System.EventArgs e)
		{
			//do nothing
		}


		
		Random rnd=new Random((int)DateTime.Now.Ticks);

		private string simulateString()
		{
			string groupA="qwertyuiopasdfghjklzxcvbnm";
			string groupB="eioa";
			int b=(int)(rnd.NextDouble()*4+2);
			string ret="";
			for(int c=0;c<b;c++)
			{
				int r=(int)(rnd.NextDouble()*(groupA.Length-1));
				ret=ret+groupA.Substring(r,1);
				r=(int)(rnd.NextDouble()*(groupB.Length-1));
				ret=ret+groupB.Substring(r,1);
			}//for
			return ret;
		}//simulateString()

		private int simulatedInt(int max)
		{
			double d=rnd.NextDouble();
			int b=(int)(d*max+0.5);
			return b;
		}//simulatedInt()
		
		private void Button1_Click(object sender, System.EventArgs e)
		{
			txtUserName.Text=simulateString();
			txtPassword1.TextMode=TextBoxMode.SingleLine;
			txtPassword2.TextMode=TextBoxMode.SingleLine;
			txtPassword1.Text="1234";
			txtPassword2.Text="1234";
			txtEmail.Text=simulateString()+"@"+"walla.co.il";
			drpSex.SelectedIndex=simulatedInt(Global.arraySex.Count-1);
			drpRequiredSex.SelectedIndex=simulatedInt(Global.arraySex.Count-1);
			drpRelationshipCause.SelectedIndex=simulatedInt(Global.arrayRelationshipCouse.Count-1);
			drpYear.SelectedIndex=simulatedInt(Global.arrayYear.Count-1);
			drpMonth.SelectedIndex=simulatedInt(Global.arrayMonth.Count-1);
			drpDay.SelectedIndex=simulatedInt(Global.arrayDay.Count-1);
			drpRegion.SelectedIndex=simulatedInt(Global.arrayRegion.Count-1);
			txtCity.Text="לא צויין";
			txtSelfDescription.Text="א";
			txtOtherPersonDescription.Text="ב";
			drpSmoke.SelectedIndex=simulatedInt(Global.arraySmoke.Count-1);
			drpHeight.SelectedIndex=simulatedInt(Global.arrayHeight.Count-1);
			drpBody.SelectedIndex=simulatedInt(Global.arrayBody.Count-1);
			drpLuck.SelectedIndex=simulatedInt(Global.arrayLuck.Count-1);
			drpReligion.SelectedIndex=simulatedInt(Global.arrayReligion.Count-1);
			drpOrigin.SelectedIndex=simulatedInt(Global.arrayOrigin.Count-1);
			drpChangeHome.SelectedIndex=simulatedInt(Global.arrayChangeHome.Count-1);
			drpSport.SelectedIndex=simulatedInt(Global.arraySport.Count-1);
			drpFamilyState.SelectedIndex=simulatedInt(Global.arrayFamilyState.Count-1);
			drpChildren.SelectedIndex=simulatedInt(Global.arrayChildren.Count-1);
			drpEducation.SelectedIndex=simulatedInt(Global.arrayEducation.Count-1);
			txtStudy.Text="מ";
			txtWork.Text="ע";
			drpAconomicState.SelectedIndex=simulatedInt(Global.arrayAconomicState.Count-1);
			drpRequestedRegion.SelectedIndex=simulatedInt(Global.arrayRegion.Count-1);
			int f=int.Parse(drpYear.SelectedItem.Value);
			int g=int.Parse(drpYear.SelectedValue);
			if(drpYear.SelectedIndex-5>=0)
				drpMinAge.SelectedIndex=drpYear.SelectedIndex-5;
			else
				drpMinAge.SelectedIndex=drpYear.SelectedIndex;
			drpMaxAge.SelectedIndex=drpYear.SelectedIndex;
			chkDevoursed.Checked=true;
			chkDoctorate.Checked=true;
			chkFirstDegree.Checked=true;
			chkHighScholl.Checked=true;
			chkSecondDegree.Checked=true;
			chkSeperated.Checked=true;
			chkSingle.Checked=true;
			chkSomeDegree.Checked=true;
			chkWiddow.Checked=true;


		}
	}//class
}//namespace
