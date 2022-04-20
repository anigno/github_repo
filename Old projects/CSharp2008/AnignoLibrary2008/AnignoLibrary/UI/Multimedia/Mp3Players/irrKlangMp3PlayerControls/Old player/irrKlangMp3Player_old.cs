using System;
using System.ComponentModel;
using System.Windows.Forms;

using System.IO;
using LoggingProvider;
using System.Threading;

namespace AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControl
{
    public partial class irrKlangMp3Player_old : UserControl
    {

		#region (------  Enums  ------)

        public enum StatusEnum
        {
            Playing,
            Paused,
            Stoped,
        }

		#endregion (------  Enums  ------)

		#region (------  Const Fields  ------)

public const string CATEGORY_STRING=" irrKlangMp3Player";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private string _lastFilename;

        private bool _songAboutToEndNotified;

        //private ISound _previousSound;
        private ISound _currentSound;
        private ISoundEngine _soundEngine;
        private StatusEnum _status = StatusEnum.Stoped;
        private Thread _smoothPositionSetThread;
        private uint _songEndAlertMs = 6000;
        private uint _songDefaultStartMs = 1;
        private uint _FF_RW_intervalMS = 10000;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public irrKlangMp3Player_old()
        {
            InitializeComponent();
        }

		#endregion (------  Constructors  ------)

		#region (------  Read only Properties  ------)

        public uint DurationMs
        {
            get
            {
                if (_currentSound == null) return 0;
                return _currentSound.PlayLength;
            }
        }

        public StatusEnum Status
        {
            get { return _status; }
        }

		#endregion (------  Read only Properties  ------)

		#region (------  Properties  ------)


        [Browsable(false)]
        public string PlayerName { get; private set; }


        [Browsable(false)]
        public float Volume
        {
            get
            {
                if (_soundEngine == null) return 0;
                return _soundEngine.SoundVolume;
            }
            set
            {
                if (_soundEngine == null)
                {
                    Logger.LogDebug("{0}, Volume setter, _soundEngine==null", PlayerName);
                    return;
                }
                if (value < 0 || value > 1)
                {
                    Logger.LogDebug("{0}, Volume setter, value is out of range. value={1}", PlayerName, value);
                    return;
                }
                _soundEngine.SoundVolume = value;
                trackBarVolume.Value = (int) (value * 100);
            }
        }


        [Browsable(false)]
        public uint PlayPositionMs
        {
            get
            {
                if (_currentSound == null) return 0;
                return _currentSound.PlayPosition;
            }
            set
            {
                if (_currentSound == null)
                {
                    Logger.LogWarning("{0}, PlayPositionMs setter, _currentSound==null",PlayerName);
                    return;
                }
                if (value < 0 || value > DurationMs)
                {
                    Logger.LogWarning("{0}, PlayPositionMs setter, value is out of range, value={1} Duration={2}",PlayerName,value,DurationMs);
                    return;
                }
                if (_smoothPositionSetThread != null) _smoothPositionSetThread.Abort();
                _smoothPositionSetThread = new Thread(SmoothPositionSetThreadStart);
                _smoothPositionSetThread.Start(value);
                _currentSound.PlayPosition = value;
            }
        }

        [Category(CATEGORY_STRING)]
        public uint SongEndAlertMs
        {
            get { return _songEndAlertMs; }
            set { _songEndAlertMs = value; }
        }

        [Category(CATEGORY_STRING)]
        public uint SongDefaultStartMs
        {
            get { return _songDefaultStartMs; }
            set { _songDefaultStartMs = value; }
        }


		#endregion (------  Properties  ------)

		#region (------  Events  ------)

        [Category(CATEGORY_STRING)]
        public event SongAboutToEndEventHandler OnSongAboutToEnd;

        [Category(CATEGORY_STRING)]
        public event StatusChangedEventHandler OnStatusChanged;

		#endregion (------  Events  ------)

		#region (------  Delegates  ------)

        private delegate void ChangeVolumeHandler(float dv);
        public delegate void SongAboutToEndEventHandler(uint remainMs);
		public delegate void StatusChangedEventHandler(StatusEnum status);

		#endregion (------  Delegates  ------)

		#region (------  Event Handlers  ------)

        private void buttonForward_Click(object sender, EventArgs e)
        {
            Logger.LogDebug("{0}",PlayerName);
            PlayPositionMs += _FF_RW_intervalMS;
            progressBarPosition.Focus();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            Logger.LogDebug("{0}", PlayerName);
            Pause();
            progressBarPosition.Focus();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Logger.LogDebug("{0}", PlayerName);
            Play();
            progressBarPosition.Focus();
        }

        private void buttonRewind_Click(object sender, EventArgs e)
        {
            Logger.LogDebug("{0}", PlayerName);
            
            PlayPositionMs -= _FF_RW_intervalMS;
            progressBarPosition.Focus();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Logger.LogDebug("{0}", PlayerName);
            Stop();
            progressBarPosition.Focus();
        }

        private void progressBarPosition_MouseClick(object sender, MouseEventArgs e)
        {
            PlayPositionMs = (uint)(DurationMs * e.X / progressBarPosition.Width);
            Logger.LogDebug("progressBarPosition_MouseClick, New positionMs={0}",PlayPositionMs);
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            progressBarPosition.Maximum = (int) (DurationMs / 1000);
            progressBarPosition.Value = (int)PlayPositionMs / 1000;
            if (_currentSound != null)
            {
                if (_currentSound.Paused || _currentSound.Finished)
                {
                    buttonPlay.FlatAppearance.BorderSize = 0;
                }
                else
                {
                    buttonPlay.FlatAppearance.BorderSize += 1;
                    if (buttonPlay.FlatAppearance.BorderSize > 2) buttonPlay.FlatAppearance.BorderSize = 1;
                }
                labelTime.Text = string.Format("{4} {0}:{1:00} / {2}:{3:00} [{5}:{6:00}]", PlayPositionMs/1000/60, PlayPositionMs/1000%60, DurationMs/1000/60, DurationMs/1000%60, Status,(DurationMs-PlayPositionMs)/1000/60,(DurationMs-PlayPositionMs)/1000%60);
                //Check if song is about to end
                if (DurationMs - PlayPositionMs < SongEndAlertMs)
                {
                    if (OnSongAboutToEnd != null && !_songAboutToEndNotified)
                    {
                        Logger.LogDebug("{1}, Song is about to end in: {0}ms",SongEndAlertMs,PlayerName);
                        Invoke(new SongAboutToEndEventHandler(OnSongAboutToEnd), SongEndAlertMs);
                        _songAboutToEndNotified=true;
                    }
                    if (DurationMs == PlayPositionMs)
                    {
                        Logger.LogDebug("{0}, Song ended",PlayerName);
                        Stop();
                    }

                }
            }
        }

        private void trackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            //Volume = trackBarVolume.Value / 100f;
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Private Methods  ------)

        private void ChangeVolumeInvoked(float dv)
        {
            if (InvokeRequired)
            {
                Invoke(new ChangeVolumeHandler(ChangeVolumeInvoked), dv);
            }
            else
            {
                Volume +=dv;
            }
        }

        private void SetStatus(StatusEnum status)
        {
            if (Status != status)
            {
                Logger.LogDebug("{2}, Status changed from: {0} to: {1}",Status,status,PlayerName);
                _status = status;
                if (OnStatusChanged != null) OnStatusChanged(status);
            }
        }

        private void SmoothPositionSetThreadStart(object oPosition)
        {
            uint position = (uint)oPosition;
            Logger.LogDebug("{0}, SmoothPositionSetThreadStart, oldPosition={1} newPosition={2}", PlayerName, PlayPositionMs, position);
            int factor = 20;
            int smoothTime = 250;
            float dv = 1f / factor;
            for (int a = 0; a < factor; a++)
            {
                ChangeVolumeInvoked(-dv);
                Thread.Sleep(smoothTime/factor);
            }
            if (_currentSound != null) _currentSound.PlayPosition = position;
            for (int a = 0; a < factor; a++)
            {
                ChangeVolumeInvoked(dv);
                Thread.Sleep(smoothTime*4 / factor);
            }
        }

		#endregion (------  Private Methods  ------)

		#region (------  Public Methods  ------)

        public void Init(string playerName,AudioDevice device)
        {
            PlayerName=playerName;
            Logger.LogDebug("{1}, Init, Device description: {0}", device.DeviceDescription,playerName);
            _soundEngine = new ISoundEngine(SoundOutputDriver.AutoDetect, SoundEngineOptionFlag.DefaultOptions, device.DeviceId);
            SetStatus(StatusEnum.Stoped);
        }

        private FileStream _currentFileStream;



        public void LoadFile(string filename)
        {
            try
            {
                Logger.LogDebug("{1}, LoadFile, filename: {0}", filename, PlayerName);
                    _lastFilename = filename;
                    //Using FileStream to load hebrew contained file names.
                    if (_currentFileStream != null) _currentFileStream.Close(); 
                    _currentFileStream = new FileStream(filename, FileMode.Open);
                Stop();
                _soundEngine.StopAllSounds();

                //Removing all SoundSource(s) because using the same SoundSource name, old FileStream will be free after assigning new one
                _soundEngine.RemoveAllSoundSources();
                ISoundSource s = _soundEngine.AddSoundSourceFromIOStream(_currentFileStream, "Current"+DateTime.Now.Ticks);
                _currentFileStream.Close();
                _currentSound = _soundEngine.Play2D(s, false, true, false);
                labelSongName.BorderStyle = BorderStyle.None;
                if (_currentSound == null)
                {
                    Logger.LogError("{0}, LoadFile, _currentSound is null", PlayerName);
                    labelSongName.BorderStyle = BorderStyle.FixedSingle;
                }
                labelSongName.Text = Path.GetFileNameWithoutExtension(filename);
            }
            catch (Exception ex)
            {
                //Usually when FileStream is in use
                Stop();
                _soundEngine.StopAllSounds();
                Logger.LogError("(1),LoadFile,{0}", ex.Message, PlayerName);
            }
            finally
            {
                if (_currentFileStream != null) _currentFileStream.Close();
            }
        }

        public void Pause()
        {
            Logger.LogDebug("{0}", PlayerName);
            if (_currentSound == null) return;
            _currentSound.Paused = true;
            SetStatus(StatusEnum.Paused);
        }

        public void Play()
        {
            Logger.LogDebug("{0}", PlayerName);
            if (_currentSound == null) return;
            _songAboutToEndNotified = false;
            if (_currentSound.Finished) LoadFile(_lastFilename);
            _currentSound.Paused = false;
            SetStatus(StatusEnum.Playing);
        }

        public void Stop()
        {
            Logger.LogDebug("{0}", PlayerName);
            if (_currentSound != null)
            {
                Logger.LogDebug("{0}, Stop, Stoping all sounds",PlayerName);
                _currentSound.Stop();
                _currentSound.Dispose();
            }
            SetStatus(StatusEnum.Stoped);
            //Pause();
            //PlayPositionMs = 0;
        }

		#endregion (------  Public Methods  ------)

    }
}
