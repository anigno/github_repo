using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using LoggingProvider;

namespace AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControls
{
    public partial class AnignoIrrKlangMp3PlayerControl : UserControl
    {

		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoIrrKlangMp3PlayerControl";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private int _deviceNumber=-1;
        private int _periodicInterval = 250;

        private AnignoIrrKlangMp3PlayerEx _playerEx;
        private uint _positionDeltaMs = 10000;
        private uint _positionSmoothChangeIntervalMs = 3000;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public AnignoIrrKlangMp3PlayerControl()
        {
            InitializeComponent();
            _playerEx = CreatePlayerEx(Mp3PlayerBase.DEFAULT_PLAYER_NAME, AnignoIrrKlangMp3Player.SoundDeviceList.getDeviceID(0), 250);
        }

		#endregion (------  Constructors  ------)

		#region (------  Read only Properties  ------)

        [Category(CATEGORY_STRING)]
        public bool IsPlaying
        {
            get { return _playerEx.IsPlaying; }
        }

		#endregion (------  Read only Properties  ------)

		#region (------  Properties  ------)


        [Category(CATEGORY_STRING)]
        public string DeviceDescription { get; private set; }

        [Category(CATEGORY_STRING)]
        public string DeviceId { get; private set; }

        [Category(CATEGORY_STRING)]
        public string PlayerName
        {
            get { return _playerEx.PlayerName; }
            set { _playerEx.PlayerName = value; }
        }

        [Category(CATEGORY_STRING)]
        [Editor(typeof(CustomMp3FileEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SongFilename
        {
            get { return _playerEx.SongFilename; }
            set
            {
                _playerEx.Load(value);
            }
        }


        public float VolumePlayer
        {
            get { return _playerEx.VolumePlayer; }
            set { _playerEx.VolumePlayer = value; }
        }

        public float VolumeCrossFade
        {
            get { return _playerEx.VolumeCrossFade; }
            set { _playerEx.VolumeCrossFade = value; }
        }

        public float VolumePower
        {
            get { return _playerEx.VolumePower; }
            set
            {
                _playerEx.VolumePower = value;
                trackBarVolumeMax.Value = (int) (value*100);
            }
        }

        [Category(CATEGORY_STRING)]
        public int DeviceNumber
        {
            get { return _deviceNumber; }
            set
            {
                int maxDevices = AnignoIrrKlangMp3Player.SoundDeviceList.DeviceCount;
                try
                {
                    _playerEx.Stop();
                    _deviceNumber = value%maxDevices;
                    ReleasePlayerEx(_playerEx);
                    DeviceId = AnignoIrrKlangMp3Player.SoundDeviceList.getDeviceID(value);
                    DeviceDescription = AnignoIrrKlangMp3Player.SoundDeviceList.getDeviceDescription(_deviceNumber);
                    _playerEx = CreatePlayerEx(_playerEx.PlayerName, DeviceId, PeriodicInterval);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    _deviceNumber = -1;
                }
            }
        }

        [Category(CATEGORY_STRING)]
        public int PeriodicInterval
        {
            get { return _periodicInterval; }
            set
            {
                _periodicInterval = value;
                _playerEx.Stop();
                ReleasePlayerEx(_playerEx);
                _playerEx = CreatePlayerEx(_playerEx.PlayerName, DeviceId, PeriodicInterval);
            }
        }


        [Category(CATEGORY_STRING)]
        public uint PreFinishPlayingInterval
        {
            get { return _playerEx.PreFinishPlayingIntervalMs / 1000; }
            set { _playerEx.PreFinishPlayingIntervalMs = value * 1000; }
        }

        [Category(CATEGORY_STRING)]
        public uint PositionDeltaMs
        {
            get { return _positionDeltaMs; }
            set { _positionDeltaMs = value; }
        }

        [Category(CATEGORY_STRING)]
        public uint PositionSmoothChangeIntervalMs
        {
            get { return _positionSmoothChangeIntervalMs; }
            set { _positionSmoothChangeIntervalMs = value; }
        }


		#endregion (------  Properties  ------)

		#region (------  Events  ------)

        public event Mp3PlayerBase.Mp3PlayerEventHandler OnFinishPlaying;

        public event Mp3PlayerBase.Mp3PlayerEventHandler OnPreFinishPlaying;

		#endregion (------  Events  ------)

		#region (------  Event Handlers  ------)

        void _player_OnPeriodicIntervalElapsed(string playerName)
        {
            progressBarPosition.Maximum = _playerEx.DurationMs;
            progressBarPosition.Value = _playerEx.GetPlayPositionMs();
            progressBarPosition.MinimumRange = 10;
            progressBarPosition.MaximumRange = _playerEx.DurationMs - PreFinishPlayingInterval*1000;
            uint PlayPositionMs = _playerEx.GetPlayPositionMs();
            uint DurationMs = _playerEx.DurationMs;
            labelSongName.Text = Path.GetFileNameWithoutExtension(SongFilename);
            labelTime.Text = string.Format("Song time [{0}:{1:00}]  ", DurationMs / 1000 / 60, DurationMs / 1000 % 60)  ;
            progressBarPosition.ProgressBarText = string.Format("[{0}:{1:00}]", (DurationMs - PlayPositionMs) / 1000 / 60, (DurationMs - PlayPositionMs) / 1000 % 60);
            if (_playerEx.IsPlaying)
            {
                buttonPlay.FlatAppearance.BorderSize = (buttonPlay.FlatAppearance.BorderSize + 1) % 3+1;
            }
            else
            {
                buttonPlay.FlatAppearance.BorderSize = 0;
            }
        }

        void _playerEx_OnFinishPlaying(string playerName)
        {
            if (OnFinishPlaying != null) OnFinishPlaying(playerName);
        }

        void _playerEx_OnPreFinishPlaying(string playerName)
        {
            if (OnPreFinishPlaying != null) OnPreFinishPlaying(playerName);
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            uint pos = _playerEx.GetPlayPositionMs();
            _playerEx.SetPlayPositionMsSmooth(pos + PositionDeltaMs,PositionSmoothChangeIntervalMs);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            _playerEx.Pause();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            _playerEx.Play();
        }

        private void buttonRewind_Click(object sender, EventArgs e)
        {
            uint pos=_playerEx.GetPlayPositionMs();
            _playerEx.SetPlayPositionMsSmooth(pos - PositionDeltaMs, PositionSmoothChangeIntervalMs);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            _playerEx.Stop();
        }

        private void progressBarPosition_MouseClick(object sender, MouseEventArgs e)
        {
            float p = e.X / (float)progressBarPosition.Width;
            _playerEx.SetPlayPositionMs((uint)(p * _playerEx.DurationMs));
        }

        private void trackBarVolumeMax_Scroll(object sender, EventArgs e)
        {
            _playerEx.VolumePower = trackBarVolumeMax.Value / 100f;
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Private Methods  ------)

        private AnignoIrrKlangMp3PlayerEx CreatePlayerEx(string playerName,string deviceId,int periodicInterval)
        {
            AnignoIrrKlangMp3PlayerEx playerEx = new AnignoIrrKlangMp3PlayerEx(playerName, deviceId, periodicInterval);
            playerEx.OnPeriodicIntervalElapsed += _player_OnPeriodicIntervalElapsed;
            playerEx.OnPreFinishPlaying += _playerEx_OnPreFinishPlaying;
            playerEx.OnFinishPlaying += _playerEx_OnFinishPlaying;
            return playerEx;
        }

        private void ReleasePlayerEx(AnignoIrrKlangMp3PlayerEx playerEx)
        {
            playerEx.OnPeriodicIntervalElapsed -= _player_OnPeriodicIntervalElapsed;
            playerEx.OnPreFinishPlaying -= _playerEx_OnPreFinishPlaying;
            playerEx.OnFinishPlaying -= _playerEx_OnFinishPlaying;
            playerEx.Dispose();
        }

		#endregion (------  Private Methods  ------)

		#region (------  Public Methods  ------)

        public void Play()
        {
            _playerEx.Play();
        }

        public void Stop()
        {
            _playerEx.Stop();
        }

		#endregion (------  Public Methods  ------)

    }
}