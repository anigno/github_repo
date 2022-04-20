using System;
using System.ComponentModel;
using WebLibrary.Helpers;
using WebLibrary.UI.Buttons;
using WebLibrary.UI.TableDynamicControl;

namespace WebMainApplication.WebPhotoAlbum
{
    public class TableAlbums : TableDynamic
    {

		#region Fields (2) 


        private string mSelectedAlbumKeyString;

        private int mPrivacyDescriptor = 1;

		#endregion Fields 

		#region Constructors (1) 

        public TableAlbums()
        {
            SetHeadersRow();
        }

		#endregion Constructors 

		#region Properties (2) 


        [Browsable(false)]
        public string SelectedAlbumKey
        {
            get { return mSelectedAlbumKeyString; }
            set { mSelectedAlbumKeyString = value; }
        }


        [Browsable(false)]
        public int PrivacyDescriptor
        {
            get { return mPrivacyDescriptor; }
            set { mPrivacyDescriptor = value; }
        }


		#endregion Properties 

		#region Events (1) 

        public event OnSelectedDelegate OnSelected;

		#endregion Events 

		#region Delegates (1) 

        public delegate void OnSelectedDelegate(string selectedAlbumKeyString);

		#endregion Delegates 

		#region Event Handlers (1) 

        void button_Click(object sender, EventArgs e)
        {
            SelectedAlbumKey = (sender as LinkButtonExt).Tag.ToString();
            if (OnSelected != null) OnSelected(SelectedAlbumKey);
        }

		#endregion Event Handlers 

		#region Private Methods (1) 

        private void SetHeadersRow()
        {
            Caption = "Albums";
            SetHeaders(new[] {"Name","Description","Date" }, new[] {100,200,100 });
        }

		#endregion Private Methods 

		#region Public Methods (1) 

        public void AddAlbum(string name, string description, DateTime date, int privcyDescriptor)
        {
            string albumKey=name;
            if (SearchKeyString(name))
            {
                JavascriptHelper.CreateAlertDialog(Page, "Name already exists");
                return;
            }
            if (privcyDescriptor <= PrivacyDescriptor)
            {
                LinkButtonExt button = new LinkButtonExt();
                button.Text=name;
                button.Tag=name;
                button.Click += button_Click;
                AddRow(null, albumKey,button, description, StringHelper.GetDateString(date));
            }
        }

		#endregion Public Methods 

    }
}