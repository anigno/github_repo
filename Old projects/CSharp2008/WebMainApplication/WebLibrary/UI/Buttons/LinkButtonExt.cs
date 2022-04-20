using System.Web.UI.WebControls;

namespace WebLibrary.UI.Buttons
{
    public class LinkButtonExt :LinkButton
    {

		#region Fields (1) 


        private object mTag;

		#endregion Fields 

		#region Properties (1) 


        public object Tag
        {
            get { return mTag; }
            set { mTag = value; }
        }


		#endregion Properties 

    }
}
