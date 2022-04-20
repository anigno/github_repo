using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPhotoAlbum.WebControls
{
    public partial class Albums : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButtonAddAlbum_Click1(object sender, ImageClickEventArgs e)
        {
            PanelNewAlbum.Visible = true;

        }

        protected void ImageButtonOkAddAlbum_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ImageButtonCancelAddAlbum_Click(object sender, ImageClickEventArgs e)
        {
            PanelNewAlbum.Visible=false;
        }
    }
}