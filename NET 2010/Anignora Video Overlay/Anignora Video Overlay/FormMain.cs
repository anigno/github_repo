using System;
using System.IO;
using System.Windows.Forms;
using Anignora_Video_Overlay.VideoOverlay;
using AnignoraDataTypes.Configurations;
using AnignoraDataTypes;
using System.Linq;
using AnignoraUI.Common;


namespace Anignora_Video_Overlay
{
    public partial class FormMain : Form
    {
		#region (------  Fields  ------)

        public const string CONFIGURATION_FILE = "VideoOverlayConfig.xml";
        public readonly ConfiguratorXml<OverlayData> Configurator = new ConfiguratorXml<OverlayData>(CONFIGURATION_FILE);
        private FormVideo m_formVideo;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public FormMain()
        {
            InitializeComponent();
            Configurator.Load();
        }

		#endregion (------  Constructors  ------)

		#region (------  Protected Methods  ------)

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            closeFormVideo();
            saveDataFromControl();
            base.OnClosing(e);
        }

		#endregion (------  Protected Methods  ------)

		#region (------  Private Methods  ------)

        private void buttonBrowseDedicatedVideoPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = false;
                if (fbd.ShowDialog() != DialogResult.OK) return;
                labelDedicatedVideoPath.Text = fbd.SelectedPath;
            }
        }

        private void buttonBrowseGenericVideoPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = false;
                if (fbd.ShowDialog() != DialogResult.OK) return;
                labelGenericVideoPath.Text = fbd.SelectedPath;
            }
        }

        private void buttonBrowseLogoFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.RestoreDirectory = true;
                ofd.CheckFileExists = true;
                ofd.Filter = "Images|*.gif;*.jpg;*.bmp";
                if (ofd.ShowDialog() != DialogResult.OK) return;
                labelLogoFile.Text = ofd.FileName;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonForceVideo_Click(object sender, EventArgs e)
        {
            if (m_formVideo == null) return;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.RestoreDirectory = true;
                ofd.CheckFileExists = true;
                ofd.Filter = "Video Files|*.avi";
                if (ofd.ShowDialog() != DialogResult.OK) return;
                m_formVideo.SelectAndPlayVideo(ofd.FileName);
            }
        }

        private void buttonMaxVideo_Click(object sender, EventArgs e)
        {
            if (m_formVideo == null) return;
            m_formVideo.ChangeWindowState();
        }

        private void buttonSkipVideo_Click(object sender, EventArgs e)
        {
            if (m_formVideo == null) return;
            m_formVideo.SelectAndPlayVideo();
        }

        private void buttonSpecialText_Click(object sender, EventArgs e)
        {
            if(m_formVideo==null)return;
            Label label = m_formVideo.LabelSpecialText;
            label.Text=textBoxSpecialText.Text;
            label.Visible = !label.Visible;
            label.Left = m_formVideo.Width / 2 - label.Width / 2;
            label.Top = m_formVideo.Height / 2 - label.Height / 2;
        }

        private void buttonStartVideo_Click(object sender, EventArgs e)
        {
            if (m_formVideo != null) return;
            saveDataFromControl();
            int videoScreenIndex = getVideoScreenIndex();
            m_formVideo=new FormVideo(Configurator.Configuration,trackBarVideoVolume.Value);
            m_formVideo.Closed += m_formVideo_Closed;
            m_formVideo.Show();
            m_formVideo.Left = Screen.AllScreens[videoScreenIndex].Bounds.Left;
            m_formVideo.ChangeWindowState();
        }

        private void buttonStopVideo_Click(object sender, EventArgs e)
        {
            closeFormVideo();
        }

        private void checkBoxScrollTextVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (m_formVideo == null) return;
            m_formVideo.SetScrollVisible(checkBoxScrollTextVisible.Checked);
        }

        private void closeFormVideo()
        {
            if (m_formVideo == null) return;
            m_formVideo.Closing -= m_formVideo_Closed;
            m_formVideo.Close();
            m_formVideo = null;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Text += " " + Application.ProductVersion;
            Configurator.Load();
            loadDataToControls();
        }

        //Get the index of the screen to setup video form at
        private int getVideoScreenIndex()
        {
            if (Screen.AllScreens.Length < 2) return 0;
            var currentScreenName = ScreenHelper.GetScreenSimpleName(Screen.FromControl(this));
            var otherScreenName = ScreenHelper.GetScreenSimpleName(Screen.AllScreens[1]);
            if (currentScreenName == otherScreenName) return 0;
            return 1;
        }

        private void loadDataToControls()
        {
            textBoxGeneric.Lines = (string[])Configurator.Configuration.ScrollingTextGeneric.Clone();
            textBoxDedicated.Lines = (string[])Configurator.Configuration.ScrollingTextDedicated.Clone();
            labelDedicatedVideoPath.Text = Configurator.Configuration.VideoFilesDirectoryDedicated;
            labelGenericVideoPath.Text = Configurator.Configuration.VideoFilesDirectoryGeneric;
            labelLogoFile.Text = Configurator.Configuration.LogoImagePath;

        }

        void m_formVideo_Closed(object sender, EventArgs e)
        {
            m_formVideo = null;
        }

        private void saveDataFromControl()
        {
            Configurator.Configuration.ScrollingTextGeneric = (string[]) textBoxGeneric.Lines.Clone();
            Configurator.Configuration.ScrollingTextDedicated = (string[]) textBoxDedicated.Lines.Clone();
            Configurator.Configuration.VideoFilesDirectoryDedicated = labelDedicatedVideoPath.Text;
            Configurator.Configuration.VideoFilesDirectoryGeneric = labelGenericVideoPath.Text;
            Configurator.Configuration.LogoImagePath = labelLogoFile.Text;
            Configurator.Save();
        }

        private void trackBarVideoVolume_Scroll(object sender, EventArgs e)
        {
            if (m_formVideo == null) return;
            m_formVideo.VideoVolume = trackBarVideoVolume.Value;
        }

		#endregion (------  Private Methods  ------)
    }
}
