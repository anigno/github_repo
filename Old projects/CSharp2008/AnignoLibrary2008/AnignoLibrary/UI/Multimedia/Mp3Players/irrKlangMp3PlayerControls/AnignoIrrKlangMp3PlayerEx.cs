using System.Threading;
using LoggingProvider;
using System.IO;

namespace AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControls
{
    public class AnignoIrrKlangMp3PlayerEx : Mp3PlayerBase
    {

		#region (------  Fields  ------)


        private AnignoIrrKlangMp3Player _playerMain;
        private AnignoIrrKlangMp3Player _playerSecond;
        private Thread SetPlayPositionSmoothThread;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public AnignoIrrKlangMp3PlayerEx(string playerName, string deviceId, int periodicInterval):base(playerName)
        {
            PlayerMain = new AnignoIrrKlangMp3Player(playerName, deviceId, periodicInterval);
            PlayerSecond = new AnignoIrrKlangMp3Player(playerName, deviceId, periodicInterval);
            PlayerMain.OnPeriodicIntervalElapsed += _playerMain_OnPeriodicIntervalElapsed;
            PlayerMain.OnPreFinishPlaying += _playerMain_OnPreFinishPlaying;
            PlayerMain.OnFinishPlaying += _playerMain_OnFinishPlaying;
            PlayerSecond.OnPeriodicIntervalElapsed += _playerMain_OnPeriodicIntervalElapsed;
            PlayerSecond.OnPreFinishPlaying += _playerMain_OnPreFinishPlaying;
            PlayerSecond.OnFinishPlaying += _playerMain_OnFinishPlaying;
        }

		#endregion (------  Constructors  ------)

		#region (------  Overridden Properties  ------)

        public override uint DurationMs
        {
            get
            {
                return PlayerMain.DurationMs;
            }
        }

        public override bool IsPlaying
        {
            get
            {
                return PlayerMain.IsPlaying;
            }
        }

        public override float VolumeCrossFade
        {
            get
            {
                return PlayerMain.VolumeCrossFade;
            }
            set
            {
                PlayerMain.VolumeCrossFade = value;
                PlayerSecond.VolumeCrossFade = value;
            }
        }

        public override float VolumePlayer
        {
            get
            {
                return PlayerMain.VolumePlayer;
            }
            set
            {
                PlayerMain.VolumePlayer = value;
                PlayerSecond.VolumePlayer = value;
            }
        }

        public override float VolumePower
        {
            get
            {
                return PlayerMain.VolumePower;
            }
            set
            {
                PlayerMain.VolumePower = value;
                PlayerSecond.VolumePower = value;
            }
        }

		#endregion (------  Overridden Properties  ------)

		#region (------  Properties  ------)


        public new string PlayerName
        {
            get
            {
                return base.PlayerName;
            }
            set
            {
                base.PlayerName = value;
                PlayerMain.PlayerName = value + " Main"; ;
                PlayerSecond.PlayerName = value + "Second";
            }
        }


        public AnignoIrrKlangMp3Player PlayerMain
        {
            get
            {
                lock (_syncRoot)
                {
                    return _playerMain;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _playerMain = value;
                }
            }
        }

        public AnignoIrrKlangMp3Player PlayerSecond
        {
            get
            {
                lock (_syncRoot)
                {
                    return _playerSecond;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _playerSecond = value;
                }
            }
        }

        public new uint PreFinishPlayingIntervalMs
        {
            set
            {
                PlayerMain.PreFinishPlayingIntervalMs = value;
                PlayerSecond.PreFinishPlayingIntervalMs = value;
            }
            get
            {
                return PlayerMain.PreFinishPlayingIntervalMs;
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Event Handlers  ------)

        void _playerMain_OnFinishPlaying(string playerName)
        {
            SongFilename = null;
            //Raises PlayerEx's event for the player's owning control to receive
            RaiseOnFinishPlaying();
        }

        void _playerMain_OnPeriodicIntervalElapsed(string playerName)
        {
            //Raises PlayerEx's event for the player's owning control to receive
            RaiseOnPeriodicIntervalElapsed();
        }

        void _playerMain_OnPreFinishPlaying(string playerName)
        {
            //Raises PlayerEx's event for the player's owning control to receive
            RaisePreFinishPlaying();
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Overridden Methods  ------)

        public override uint GetPlayPositionMs()
        {
            return PlayerMain.GetPlayPositionMs();
        }

        public override bool Load(string filename)
        {
            lock (_syncRoot)
            {
                Logger.LogDebug("{0},",PlayerName);
                if (SetPlayPositionSmoothThread != null) SetPlayPositionSmoothThread.Abort();
                SongFilename = filename;
                if (filename == null || !File.Exists(filename))
                {
                    SongFilename = null;
                    //return false;
                }
                return (PlayerMain.Load(filename) && PlayerSecond.Load(filename));
            }
        }

        public override bool Pause()
        {
            Logger.LogDebug("{0},", PlayerName);
            return PlayerMain.Pause() && PlayerSecond.Pause();
        }

        public override bool Play()
        {
            Logger.LogDebug("{0},", PlayerName);
            return PlayerMain.Play();
        }

        public override bool SetPlayPositionMs(uint positionMs)
        {
            Logger.LogDebug("{0},", PlayerName);
            return PlayerMain.SetPlayPositionMs(positionMs);
        }

        public override bool Stop()
        {
            Logger.LogDebug("{0},", PlayerName);
            return PlayerMain.Stop();
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void SetPlayPositionThreadStart(object o)
        {
                Logger.LogDebug("{0}, start", PlayerName);
                uint interval = (uint)o;
                float v = 1;
                float v2 = 0f;
                float v1 = v;
                for (int a = 0; a < 20; a++)
                {
                    v2 += v/20f;
                    if (v2 > 1) v2 = 1;
                    v1 -= v/20;
                    if (v1 < 0) v1 = 0;
                    //Must be atomic, use staic sync for atomic
                    PlayerMain.VolumePlayer = v1;
                    PlayerSecond.VolumePlayer = v2;
                    Thread.Sleep((int) interval/20);
                }
                lock (_syncRoot)
                {
                    AnignoIrrKlangMp3Player temp = PlayerMain;
                    PlayerMain = PlayerSecond;
                    PlayerSecond = temp;
                    Logger.LogDebug("{0}, end. PlayerMain={1} PlayerSecond={2}", PlayerName, PlayerMain.PlayerName, PlayerSecond.PlayerName);
                    PlayerSecond.Stop();
                }
        }

		#endregion (------  Private Methods  ------)

		#region (------  Public Methods  ------)

        public void Dispose()
        {
            Logger.LogDebug("{0},", PlayerName);
            lock (_syncRoot)
            {
                PlayerMain.Dispose();
                PlayerSecond.Dispose();
            }
        }

        public void SetPlayPositionMsSmooth(uint positionMs, uint transmitionIntervalMs)
        {
            Logger.LogDebug("{0},", PlayerName);
            if (positionMs < 0 || positionMs > DurationMs)
            {
                Logger.LogWarning("{0}, Cannot Set positionMs={1}", PlayerName, positionMs);
                return;
            }
            PlayerSecond.SetPlayPositionMs(positionMs);
            PlayerSecond.VolumePlayer = 0;
            PlayerSecond.Play();
            if (SetPlayPositionSmoothThread != null)
            {
                SetPlayPositionSmoothThread.Abort();
            }
            SetPlayPositionSmoothThread = new Thread(SetPlayPositionThreadStart);
            SetPlayPositionSmoothThread.Start(transmitionIntervalMs);
            //SetPlayPositionMs(positionMs);

        }

		#endregion (------  Public Methods  ------)

    }
}