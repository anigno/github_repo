using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMCSCRIPTINGLib;
using System.IO;

namespace AnignoLibrary.UI.Multimedia.AudioVolumeGraphing
{
    public partial class AudioFileVolumeGraph : UserControl
    {
		#region Const Fields (1) 

        private const string CATEGORY_STRING = " AudioFileVolumeGraph";

		#endregion Const Fields 

		#region Fields (2) 


        private string mFilename;

        #endregion Fields 

		#region Constructors (1) 

        public AudioFileVolumeGraph()
        {
            InitializeComponent();
            volumeGraphMain.BytesPerVerticalLine = 8000 * 60;
        }

		#endregion Constructors 

        

		#region Properties (1) 

        [Category(CATEGORY_STRING)]
        public float SkipVolume
        {
            get { return volumeGraphMain.SkipVolume; }
            set { volumeGraphMain.SkipVolume = value; }
        }


        [Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Category(CATEGORY_STRING)]
        public string Filename
        {
            get { return mFilename; }
            set
            {
                if (!File.Exists(value))
                {
                    mFilename = "";
                    volumeGraphMain.Header = Path.GetFileNameWithoutExtension(Filename);
                    volumeGraphMain.BytesBuffer = null;
                    return;
                }
                if(value==mFilename)return;
                mFilename = value;
                string convertedFilename=CovertToEightBitMonoWave(Filename);
                //WaveIO waveData = new WaveIO();
                //waveData.WaveHeaderIN(convertedFilename);
                FileStream fs = new FileStream(convertedFilename, FileMode.Open, FileAccess.Read);
                byte[] arrfile = new byte[fs.Length - 44];
                fs.Position = 44;
                fs.Read(arrfile, 0, arrfile.Length);
                fs.Close();
                volumeGraphMain.Header = Path.GetFileNameWithoutExtension( Filename);
                volumeGraphMain.BytesBuffer = arrfile;
            }
        }
       

		#endregion Properties 

		#region Private Methods (1) 

        private static string CovertToEightBitMonoWave(string filename)
        {
            if (!Directory.Exists("Converted")) Directory.CreateDirectory("Converted");
            string convertedFilename = "Converted\\__" + Path.GetFileName(filename) + "__.wav";
            if (File.Exists(convertedFilename)) return convertedFilename;
            Converter dmc = new ConverterClass();
            dmc.Convert(filename, convertedFilename, "Wave", "-bits=8 -freq=8000 -channels=1", "error.txt");
            return convertedFilename;
        }

        #endregion Private Methods 
        
    }
}
