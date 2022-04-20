using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoggingProvider;

namespace AnignoLibrary.UI.Multimedia.Mp3Players
{
    public abstract class Mp3PlayerBase
    {

		#region (------  Const Fields  ------)

        public const string DEFAULT_PLAYER_NAME = "No Name";

		#endregion (------  Const Fields  ------)

		#region (------  Static Fields  ------)

        public static uint _instances;
        public static object SyncRootStatic=new object();

		#endregion (------  Static Fields  ------)

		#region (------  Fields  ------)


        private string _playerName;
        private string _songFilename;

        private int _periodicInterval;

        protected readonly object _syncRoot = new object();
        private uint _preFinishPlayingIntervalMs;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        protected Mp3PlayerBase(string playerName)
        {
            Instances++;
            PlayerName = playerName;
            if (PlayerName == DEFAULT_PLAYER_NAME) PlayerName += Instances;
            Logger.LogDebug("{0}, instances={1}",PlayerName,Instances);
            PreFinishPlayingIntervalMs = 6000;
        }

        ~Mp3PlayerBase()
        {
            Instances--;
        }

		#endregion (------  Constructors  ------)

		#region (------  Read only Properties  ------)

        public abstract uint DurationMs { get; }

        public abstract bool IsPlaying { get; }

		#endregion (------  Read only Properties  ------)

		#region (------  Properties  ------)


        public string PlayerName
        {
            get
            {
                lock (_syncRoot)
                {
                    if (_playerName == DEFAULT_PLAYER_NAME)
                    {
                    }
                    return _playerName;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _playerName = value;
                    Logger.LogDebug("{0}, Player name changed",PlayerName);
                }
            }
        }

        public string SongFilename
        {
            get
            {
                lock (_syncRoot)
                {
                    return _songFilename;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _songFilename = value;
                }
            }
        }


        public abstract float VolumePower { get; set; }

        public abstract float VolumePlayer { get; set; }

        public abstract float VolumeCrossFade { get; set; }

        public int PeriodicInterval
        {
            get
            {
                lock (_syncRoot)
                {
                    return _periodicInterval;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _periodicInterval = value;
                }
            }
        }


        public uint PreFinishPlayingIntervalMs
        {
            get
            {
                lock (_syncRoot)
                {
                    return _preFinishPlayingIntervalMs;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _preFinishPlayingIntervalMs = value;
                }
            }
        }

        public static uint Instances
        {
            get
            {
                lock (SyncRootStatic)
                {
                    return _instances;
                }
            }
            set
            {
                lock (SyncRootStatic)
                {
                    _instances = value;
                }
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Events  ------)

        public event Mp3PlayerEventHandler OnFinishPlaying;

        public event Mp3PlayerEventHandler OnPeriodicIntervalElapsed;

        public event Mp3PlayerEventHandler OnPreFinishPlaying;

		#endregion (------  Events  ------)

		#region (------  Delegates  ------)

        public delegate void Mp3PlayerEventHandler(string playerName);

		#endregion (------  Delegates  ------)

		#region (------  Public Methods  ------)

        public abstract uint GetPlayPositionMs();

        public abstract bool Load(string filename);

        public abstract bool Pause();

        public abstract bool Play();

        public void RaiseOnFinishPlaying()
        {
            if (OnFinishPlaying != null) OnFinishPlaying(PlayerName);
        }

        public abstract bool SetPlayPositionMs(uint positionMs);

        public abstract bool Stop();

		#endregion (------  Public Methods  ------)

		#region (------  Protected Methods  ------)

        protected void RaiseOnPeriodicIntervalElapsed()
        {
            if (OnPeriodicIntervalElapsed != null) OnPeriodicIntervalElapsed(PlayerName);
        }

        protected void RaisePreFinishPlaying()
        {
            Logger.LogDebug("{0}, ", PlayerName);
            if (OnPreFinishPlaying != null) OnPreFinishPlaying(PlayerName);
        }

		#endregion (------  Protected Methods  ------)

    }
}