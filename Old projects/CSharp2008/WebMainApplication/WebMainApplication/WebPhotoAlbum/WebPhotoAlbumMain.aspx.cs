using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMainApplication.WebPhotoAlbum
{
    public partial class WebPhotoAlbumMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TableAlbums1.PrivacyDescriptor = 1;
            TableAlbums1.AddAlbum("album01", "desc", DateTime.Now, 1);
        }
    }
}
