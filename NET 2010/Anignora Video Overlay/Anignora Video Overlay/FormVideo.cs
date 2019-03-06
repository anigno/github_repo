using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Anignora_Video_Overlay.VideoOverlay;
using PVS.AVPlayer;

namespace Anignora_Video_Overlay
{
    public partial class FormVideo : Form
    {
		#region (------  Fields  ------)

        private readonly Color DEDICATED_TEXT_COLOR = Color.Blue;
        private readonly Color GENERIC_TEXT_COLOR = Color.Black;
        int m_lastTextDedicated;
        int m_lastVideoDedicated;
        private readonly OverlayData m_overlayData;
        private Player m_player;
        private Random m_rnd;
        int m_textDedicatedCnt;
        int m_textGenericCnt;
        int m_videoDedicatedCnt;
        int m_videoGenericCnt;
        int m_videoVolume = 0;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public FormVideo(OverlayData p_overlayData,int p_videoVolume)
        {
            m_overlayData = p_overlayData;
            VideoVolume = p_videoVolume;
            InitializeComponent();
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        public Label LabelSpecialText
        {
            get { return labelSpecialText; }
        }

        public int VideoVolume
        {
            get
            {
                return m_videoVolume;
            }
            set
            {
                m_videoVolume=value;
                if (m_player == null) return;
                m_player.AudioVolume = m_videoVolume;
            }
        }

		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)

       public void ChangeWindowState()
       {
           if (FormBorderStyle == FormBorderStyle.None)
           {
               FormBorderStyle = FormBorderStyle.FixedToolWindow;
               WindowState = FormWindowState.Normal;
           }
           else
           {
               FormBorderStyle = FormBorderStyle.None;
               WindowState = FormWindowState.Maximized;
           }
           labelVideoName.Left = (Width / 2) - labelVideoName.Width / 2;
       }

        public void SelectAndPlayVideo(string p_forcedVideoFile=null)
        {
            try
            {
                string[] dedicatedVideoFiles = Directory.GetFiles(m_overlayData.VideoFilesDirectoryDedicated, "*.avi");
                string[] genericVideoFiles = Directory.GetFiles(m_overlayData.VideoFilesDirectoryGeneric, "*.avi");
                if (dedicatedVideoFiles.Length == 0) dedicatedVideoFiles = genericVideoFiles;
                if (genericVideoFiles.Length == 0) genericVideoFiles = dedicatedVideoFiles;
                string nextVideo="";
                if (p_forcedVideoFile != null)
                {
                    nextVideo = p_forcedVideoFile;
                }
                else
                {
                    if (m_videoGenericCnt < m_overlayData.VideoFilesGenericCount)
                    {
                        int index = m_rnd.Next(0, genericVideoFiles.Length);
                        nextVideo = genericVideoFiles[index];
                        m_videoGenericCnt++;
                    }
                    else
                    {
                        if (dedicatedVideoFiles.Length > 0)
                        {
                            nextVideo = dedicatedVideoFiles[m_lastVideoDedicated];
                            m_lastVideoDedicated++;
                            if (m_lastVideoDedicated >= dedicatedVideoFiles.Length) m_lastVideoDedicated = 0;
                            m_videoDedicatedCnt++;
                            if (m_videoDedicatedCnt >= m_overlayData.VideoFilesDedicatedCount)
                            {
                                m_videoGenericCnt = m_videoDedicatedCnt = 0;
                            }
                        }
                        else
                        {
                            m_videoGenericCnt = 0;
                        }
                    }
                }
                labelVideoName.Text =Path.GetFileNameWithoutExtension(nextVideo);
                labelVideoName.Left = (Width / 2) - labelVideoName.Width / 2;
                m_player.StopPlaying();
                m_player.AudioVolume = VideoVolume;
                m_player.Play(nextVideo, this);
                m_player.AudioVolume = VideoVolume;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message + " Retry?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    Application.Exit();
                    return;
                }
                SelectAndPlayVideo();
            }
        }

        public void SetScrollVisible(bool p_visible)
        {
            labelScroll.Visible = p_visible;
        }

		#endregion (------  Public Methods  ------)

		#region (------  Protected Methods  ------)

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            m_player.MediaEnd -= m_player_MediaEnd;
            var tPlayer = m_player;
            m_player = null;
            tPlayer.Dispose();
        }

		#endregion (------  Protected Methods  ------)

		#region (------  Private Methods  ------)

        private void FormVideo_Load(object sender, EventArgs e)
        {
            m_player = new Player();
            m_rnd = new Random(DateTime.Now.Millisecond);
            m_player.Overlay = this;
            m_player.MediaEnd += m_player_MediaEnd;
            string logoImagePath = m_overlayData.LogoImagePath;
            if (File.Exists(logoImagePath))
            {
                pictureBoxLogo.Image = Image.FromFile(logoImagePath);
            }
            SelectAndPlayVideo();
        }

       void m_player_MediaEnd(object sender)
        {
            SelectAndPlayVideo();
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            ChangeWindowState();
        }

        private void selectAndInitScrollText()
        {
            IEnumerable<string> linesDedicated = m_overlayData.ScrollingTextDedicated.Where(p => p.Length > 0);
            IEnumerable<string> linesGeneric = m_overlayData.ScrollingTextGeneric.Where(p => p.Length > 0);
            if (linesDedicated.Count() == 0) linesDedicated = linesGeneric;
            if (linesGeneric.Count() == 0) linesGeneric = linesDedicated;
            string nextLine;
            if (m_textGenericCnt < m_overlayData.ScrollingTextGenericCount)
            {
                int index = m_rnd.Next(0, linesGeneric.Count());
                nextLine = linesGeneric.ElementAt(index);
                m_textGenericCnt++;
                labelScroll.ForeColor = GENERIC_TEXT_COLOR;
            }
            else
            {
                nextLine = linesDedicated.ElementAt(m_lastTextDedicated);
                m_lastTextDedicated++;
                if (m_lastTextDedicated >= linesDedicated.Count()) m_lastTextDedicated = 0;
                m_textDedicatedCnt++;
                if (m_textDedicatedCnt >= m_overlayData.ScrollingTextDedicatedCount)
                {
                    m_textGenericCnt = m_textDedicatedCnt = 0;
                }
                labelScroll.ForeColor = DEDICATED_TEXT_COLOR;
            }
            labelScroll.Text = nextLine;
            labelScroll.Left =- labelScroll.Width;
            timerScroll.Start();
        }

        private void timerScroll_Tick(object sender, EventArgs e)
        {
            labelScroll.Left += m_overlayData.ScrollingTextSpeed;
            if(labelScroll.Left>Width)selectAndInitScrollText();
        }

		#endregion (------  Private Methods  ------)
    }
}
