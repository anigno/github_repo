using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;
using System.ComponentModel;
using System;
using System.IO;

namespace AnignoLibrary.UI.Multimedia
{
    public partial class DirectXAudioPlayer : UserControl
    {

		#region Const Fields (1) 

        private const string CATEGORY_STRING = " DirectXAudioPlayer";

		#endregion Const Fields 

		#region Fields (5) 

        private string mAudioFile;

        private int mVolume;
        private int mBallance;

        Audio mPlayer;
        private StateFlags mState;

		#endregion Fields 

		#region Constructors (1) 

        public DirectXAudioPlayer()
        {
            InitializeComponent();
            Volume = 80;
        }

		#endregion Constructors 

		#region Properties (4) 


        [Category(CATEGORY_STRING)]
        public string AudioFile
        {
            get { return mAudioFile; }
            set
            {
                try
                {
                    mAudioFile = value;
                    if (mPlayer == null)
                    {
                        mPlayer = new Audio(mAudioFile, false);
                        trackBarPosition.Maximum = (int)mPlayer.Duration + 1;
                    }
                    else
                    {
                        mPlayer.Open(mAudioFile);
                        trackBarPosition.Maximum = (int)mPlayer.Duration + 1;
                    }
                    labelSongFile.Text = Path.GetFileNameWithoutExtension(mAudioFile);
                }
                catch
                {
                    mAudioFile = null;
                }
            }
        }


        [Category(CATEGORY_STRING)]
        public int Volume
        {
            get { return mVolume; }
            set
            {
                if (mPlayer == null) return;
                if (value < 0 || value > 100) return;
                mVolume = value;
                trackBarVolume.Value = mVolume;
                mPlayer.Volume = (int)(-Math.Pow(value - 100, 2) / 2);
            }
        }

        [Category(CATEGORY_STRING)]
        public int Ballance
        {
            get { return mBallance; }
            set
            {
                if (mPlayer == null) return;
                if (value < -10 || value > 10) return;
                mBallance = value;
                trackBarBallance.Value = mBallance;
                mPlayer.Balance = -mBallance * 100;
            }
        }


        [Category(CATEGORY_STRING)]
        public StateFlags State
        {
            get { return mState; }
            set
            {
                if (mPlayer == null) return;
                mState = value;
                switch (mState)
                {
                    case StateFlags.Running:
                        mPlayer.Play();
                        break;
                    case StateFlags.Paused:
                        mPlayer.Pause();
                        break;
                    case StateFlags.Stopped:
                        mPlayer.Stop();
                        break;
                }
            }
        }


		#endregion Properties 

		#region Event Handlers (11) 

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (mPlayer == null) return;
            if (mPlayer.Duration - mPlayer.CurrentPosition >= 10)
            {
                mPlayer.CurrentPosition += 10;
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (mPlayer == null) return;
            mPlayer.Pause();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (mPlayer == null) return;
            State = StateFlags.Running;
        }

        private void buttonRewind_Click(object sender, EventArgs e)
        {
            if (mPlayer == null) return;
            if (mPlayer.CurrentPosition >= 10)
            {
                mPlayer.CurrentPosition -= 10;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (mPlayer == null) return;
            mPlayer.Stop();
        }

        private void DirectXAudioPlayer_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void DirectXAudioPlayer_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void timerDuretion_Tick(object sender, EventArgs e)
        {
            if (mPlayer == null) return;
            int position = (int)mPlayer.CurrentPosition;
            int duration = (int)mPlayer.Duration;
            labelDuretion.Text = string.Format("{0:00}:{1:00} / {2:00}:{3:00}", position / 60, position % 60, duration / 60, duration % 60);
            trackBarPosition.Value = (int)mPlayer.CurrentPosition;
            if (mPlayer.State == StateFlags.Running)
            {
                buttonPlay.FlatAppearance.BorderSize = (buttonPlay.FlatAppearance.BorderSize + 1) % 2;
            }
            else
            {
                buttonPlay.FlatAppearance.BorderSize = 0;
            }
        }

        private void trackBarBallance_Scroll(object sender, EventArgs e)
        {
            Ballance = trackBarBallance.Value;
        }

        private void trackBarPosition_Scroll(object sender, EventArgs e)
        {
            if (mPlayer == null) return;
            mPlayer.CurrentPosition = trackBarPosition.Value;
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            Volume = trackBarVolume.Value;
        }

		#endregion Event Handlers 

		#region Public Methods (3) 

        public void Pause()
        {
            if (mPlayer == null) return;
            mPlayer.Pause();
        }

        public void Play()
        {
            if (mPlayer == null) return;
            mPlayer.Play();
        }

        public void Stop()
        {
            if (mPlayer == null) return;
            mPlayer.Stop();
        }

		#endregion Public Methods 

    }
}