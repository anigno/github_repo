using System.Web.UI.WebControls;

namespace WebLibrary.UI.TableDynamicControl
{
    public class TableRowDynamic : TableRow
    {

		#region Fields (2) 


        private string mRowKey;

        private object mTag;

		#endregion Fields 

		#region Properties (2) 


        public string RowKey
        {
            get { return mRowKey; }
            set { mRowKey = value; }
        }


        public object Tag
        {
            get { return mTag; }
            set { mTag = value; }
        }


		#endregion Properties 

    }
}
