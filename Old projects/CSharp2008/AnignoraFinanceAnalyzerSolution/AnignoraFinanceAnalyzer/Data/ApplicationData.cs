using System;
using System.Windows.Forms;

namespace AnignoraFinanceAnalyzer.Data
{
    [Serializable]
    public class ApplicationData
    {
        #region (------------------  Properties  ------------------)

        internal readonly string Version = Application.ProductVersion;
        internal string LoginPassword { get; set; }
        #endregion

        #region (------------------  Constructors  ------------------)

        internal ApplicationData()
        {
            LoginPassword = "anignora";
        }

        #endregion
    }
}
