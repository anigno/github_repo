using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

namespace WebEncryptedXmlDataManager
{
    public partial class _Default : System.Web.UI.Page
    {
        private const string DATA_FILE = "DataFile.xml";
        private string _path;
        private string _dataFileName;
        private MainData _mainData=new MainData();

        protected void Page_Load(object sender, EventArgs e)
        {
            _path = Server.MapPath("\\");
            _dataFileName = _path + "\\" + DATA_FILE;
            LoadData();
            ListBoxSubjects.Items.Clear();
            foreach (string subject in _mainData.Subjects)
            {
                ListBoxSubjects.Items.Add(subject);
            }
        }

        protected void ListBoxSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveData();
            TextBoxData.Text = _mainData.DataItems[ListBoxSubjects.SelectedIndex];
        }

        private void SaveData()
        {
            XmlSerializer xs = new XmlSerializer(typeof(MainData));
            FileStream fs = new FileStream(_dataFileName, FileMode.Create);
            xs.Serialize(fs, _mainData);
            fs.Close();
        }

        private void LoadData()
        {
            if (!File.Exists(_dataFileName)) return;
            XmlSerializer xs = new XmlSerializer(typeof(MainData));
            FileStream fs = new FileStream(DATA_FILE, FileMode.Create);
            object o=xs.Deserialize(fs);
            _mainData=(MainData)o;
            fs.Close();
            
        }

        protected void TextBoxData_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonAddSubject_Click(object sender, EventArgs e)
        {
            if (TextBoxSubject.Text != string.Empty)
            {
                _mainData.Subjects.Add(TextBoxSubject.Text);
                _mainData.DataItems.Add("");
                SaveData();
            }
        }

    }
}
