using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using WebLibrary.Helpers;

namespace WebPhotoAlbum
{
    public partial class _Default : System.Web.UI.Page
    {
        string mServerPath;

        protected void Page_Load(object sender, EventArgs e)
        {
            //TableAlbums1.OnSelected += new WebPhotoAlbum.WebControls.TableAlbums.OnSelectedDelegate(TableAlbums1_OnSelectedHandler);
            //TableAlbums1.PrivacyDescriptor = 1;
            //TableAlbums1.AddAlbum("album01", "desc", DateTime.Now, 1);
            //TableAlbums1.AddAlbum("album02", "desc", DateTime.Now, 1);

            mServerPath = Server.MapPath("//");
            if (!IsPostBack)
            {
            }
            else
            {
            }
        }

        void TableAlbums1_OnSelectedHandler(string selectedAlbumKeyString)
        {
            Response.Write(selectedAlbumKeyString);
        }


    }
}
