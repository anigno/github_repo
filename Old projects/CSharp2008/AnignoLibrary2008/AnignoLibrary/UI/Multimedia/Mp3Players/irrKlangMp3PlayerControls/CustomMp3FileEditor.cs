using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControls
{
    public class CustomMp3FileEditor : UITypeEditor
    {

        #region (------  Fields  ------)


        private string _customFilter = "mp3 audio files|*.mp3";

        #endregion (------  Fields  ------)

        #region (------  Properties  ------)


        public string CustomFilter
        {

            get { return _customFilter; }

            set { _customFilter = value; }

        }


        #endregion (------  Properties  ------)

        #region (------  Overridden Methods  ------)

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {

            using (OpenFileDialog dialog = new OpenFileDialog())
            {

                dialog.Filter = CustomFilter;



                if (dialog.ShowDialog() == DialogResult.OK)

                    value = dialog.FileName;

            }

            return value;

        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {

            // We'll show modal dialog (OpenFileDialog)

            return UITypeEditorEditStyle.Modal;

        }

        #endregion (------  Overridden Methods  ------)

    }

}