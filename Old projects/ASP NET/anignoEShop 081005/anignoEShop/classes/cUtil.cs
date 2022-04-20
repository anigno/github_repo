using System;
using System.Web.UI.WebControls;
using System.Data;
using anignoLibrary.ClassLibraryMdbConnection;

namespace anignoEShop.classes
{
	public class cUtil
	{
		private static System.Threading.Mutex initMutex=new System.Threading.Mutex();
		private static string _serverPath;
		//site's defined consts
		private const string SITE_NAME="anignoEShop";
		private const string PUBLIC_DB="publicDB.mdb";
		private const string UPLOAD_PATH="UPLOADS";
		/// <summary>
		/// the html client uploads path
		/// </summary>
		public const string UPLOAD_PATH_HTML="../"+UPLOAD_PATH+"/";
		public static bool adminLogin=false;

		/// <summary>
		/// set the server path, mutexed.
		/// </summary>
		/// <param name="serverPath"></param>
		public static void setPath(string serverPath)
		{
			initMutex.WaitOne();
			_serverPath=serverPath;
			initMutex.ReleaseMutex();
		}

		/// <summary>
		/// property, get publicDB file path
		/// </summary>
		public static string publicDB
		{
			get
			{
				//directory must have everyone full access
				return _serverPath+"\\"+SITE_NAME+"\\DB\\"+PUBLIC_DB;
			}
		}//publicDB

		/// <summary>
		/// property, get the NET upload path
		/// </summary>
		public static string uploads
		{
			get
			{
				//directory must have everyone full access
				return _serverPath+"/"+SITE_NAME+"/"+UPLOAD_PATH;
			}
		}

		/// <summary>
		/// return file extetion from filename
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static string getFileExtention(string filename)
		{
			return filename.Substring(filename.LastIndexOf("."));
		}

		/// <summary>
		/// update subjects listBox from cDatabase connection.
		/// return true if list has items
		/// </summary>
		/// <param name="con"></param>
		/// <param name="lstSubjects"></param>
		/// <returns>true, if list has items.</returns>
		public static bool updateSubjectsList(cDatabaseConnection con, ListBox lstSubjects)
		{
			con.createSelect("tblSubjects","*","","","");
			DataTable subjectsTable=con.runSelect();
			lstSubjects.DataSource=subjectsTable;
			lstSubjects.DataTextField="fldName";
			lstSubjects.DataValueField="fldKey";
			lstSubjects.DataBind();
			return (lstSubjects.Items.Count>0);
		}

		/// <summary>
		/// update products dataGrid from cDatabase connection.
		/// </summary>
		/// <param name="con"></param>
		/// <param name="dgProducts"></param>
		/// <param name="lstSubjects"></param>
		public static void updateProductsDataGrid(cDatabaseConnection con,DataGrid dgProducts,ListBox lstSubjects)
		{
			con.createSelect("tblProducts","*","fldSubjectKey="+lstSubjects.SelectedValue,"","");
			DataTable productsTable=con.runSelect();
			dgProducts.DataSource=productsTable;
			dgProducts.DataBind();
		}

	}//class cUtil
}//namespace
