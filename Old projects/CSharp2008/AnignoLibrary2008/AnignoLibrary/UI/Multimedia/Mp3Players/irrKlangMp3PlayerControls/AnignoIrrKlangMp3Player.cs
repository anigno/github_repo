using System;
using System.IO;

using LoggingProvider;
using Timer=System.Windows.Forms.Timer;

namespace AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControls
{
    public class AnignoIrrKlangMp3Player : Mp3PlayerBase
    {

		#region (------  Static Fields  ------)

        private static readonly ISoundDeviceList _soundDeviceList = new ISoundDeviceList(SoundDeviceListType.PlaybackDevice);

		#endregion (------  Static Fields  ------)

		#region (------  Fields  ------)


        private bool _raisePreFinishEvent = true;
        private bool _raiseFinishEvent = true;
        private float _volumePower = 1;
        private float _volumePlayer = 1;
        private float _volumeCrossFade = 1;

        private ISound _currentSound;
        private readonly ISoundEngineEx _currentSoundEngine;
        private readonly Timer _periodicTimer = new Timer();

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public AnignoIrrKlangMp3Player(string playerName, string deviceId, int periodicInterval):base(playerName)
        {
            Logger.LogDebug("{0},", playerName);
            try
            {
                PeriodicInterval = periodicInterval;
                _currentSoundEngine = new ISoundEngineEx("CurrentSoundEngine", deviceId);
                _periodicTimer.Interval = periodicInterval;
                _periodicTimer.Tick += _periodicTimer_Tick;
                _periodicTimer.Enabled = true;
                _periodicTimer.Start();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0},", playerName);
            }
        }

		#endregion (------  Constructors  ------)

		#region (------  Overridden Properties  ------)

        public override uint DurationMs
        {
            get
            {
                try
                {
                    lock (_syncRoot)
                    {
                        if (CurrentSound == null) return 0;
                        if (CurrentSound.Finished) return 0;
                        return CurrentSound.PlayLength;
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "{0},", PlayerName);
                    return 0;
                }
            }
        }

        public override bool IsPlaying
        {
            get
            {
                try
                {
                    lock (_syncRoot)
                    {
                        if (CurrentSound == null) return false;
                        return !CurrentSound.Paused;
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "{0},", PlayerName);
                    return false;
                }
            }
        }

        public override float VolumeCrossFade
        {
            get
            {
                lock (_syncRoot)
                {
                    return _volumeCrossFade;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _volumeCrossFade = value;
                    if (_volumeCrossFade < 0)
                    {
                        Logger.LogWarning("{0}, VolumeCrossFade cannot be less then zero. value={1}", PlayerName, value);
                        _volumeCrossFade = 0;
                    }
                    if (_volumeCrossFade > 1)
                    {
                        Logger.LogWarning("{0}, VolumeCrossFade cannot be greater then one. value={1}", PlayerName, value);
                        _volumeCrossFade = 1;
                    }
                    //Forces Volume to be updated according to Power value
                    VolumePlayer = VolumePlayer;
                }
            }
        }

        public override float VolumePlayer
        {
            get
            {
                lock (_syncRoot)
                {
                    return _volumePlayer;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    if (CurrentSound == null) return;
                    try
                    {
                        if (CurrentSound == null) return;
                        float v = value * VolumePower * VolumeCrossFade;
                        if (v < 0)
                        {
                            Logger.LogWarning("{0}, VolumePlayer cannot be less then zero. value={1}", PlayerName, value);
                            v = 0;
                        }
                        if (v > 1)
                        {
                            Logger.LogWarning("{0}, VolumePlayer cannot be greater then one. value={1}", PlayerName, value);
                            v = 1;
                        }
                        _volumePlayer = value;
                        CurrentSound.Volume = v;
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex, "{0},", PlayerName);
                    }
                }
            }
        }

        public override float VolumePower
        {
            get
            {
                lock (_syncRoot)
                {
                    return _volumePower;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _volumePower = value;
                    if (_volumePower < 0)
                    {
                        Logger.LogWarning("{0}, VolumeMax cannot be less then zero. value={1}", PlayerName, value);
                        _volumePower = 0;
                    }
                    if (_volumePower > 1)
                    {
                        Logger.LogWarning("{0}, VolumeMax cannot be greater then one. value={1}", PlayerName, value);
                        _volumePower = 1;
                    }
                    //Forces Volume to be updated according to Power value
                    VolumePlayer = VolumePlayer;
                }
            }
        }

		#endregion (------  Overridden Properties  ------)

		#region (------  Read only Properties  ------)

        private ISoundEngineEx CurrentSoundEngine
        {
            get
            {
                lock (_syncRoot)
                {
                    return _currentSoundEngine;
                }
            }
        }

        public static ISoundDeviceList SoundDeviceList
        {
            get { return _soundDeviceList; }
        }

		#endregion (------  Read only Properties  ------)

		#region (------  Properties  ------)


        private bool RaisePreFinishEvent
        {
            get
            {
                lock (_syncRoot)
                {
                    return _raisePreFinishEvent;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _raisePreFinishEvent = value;
                    Logger.LogDebug("{0}, RaisePreFinishEvent={1}", PlayerName, _raisePreFinishEvent);
                }
            }
        }

        private bool RaiseFinishEvent
        {
            get
            {
                lock (_syncRoot)
                {
                    return _raiseFinishEvent;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _raiseFinishEvent = value;
                }
            }
        }


        private ISound CurrentSound
        {
            get
            {
                lock (_syncRoot)
                {
                    if (_currentSound == null)
                    {
                    }
                    return _currentSound;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _currentSound = value;
                }
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Event Handlers  ------)

        void _periodicTimer_Tick(object sender, EventArgs e)
        {
            RaiseOnPeriodicIntervalElapsed();
            uint t = GetPlayPositionMs() + PreFinishPlayingIntervalMs;
            if (IsPlaying && t >= DurationMs & RaisePreFinishEvent)
            {
                RaisePreFinishEvent = false;
                RaisePreFinishPlaying();
            }
            if (CurrentSound != null && CurrentSound.Finished && RaiseFinishEvent)
            {
                RaiseFinishEvent = false;
                RaiseOnFinishPlaying();
                CurrentSound.Paused = true;
                SongFilename = null;
                CurrentSoundEngine.RemoveAllSoundSources();
            }
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Overridden Methods  ------)

        public override uint GetPlayPositionMs()
        {
            if (CurrentSound == null) return 0;
            try
            {
                return CurrentSound.PlayPosition;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return 0;
            }
        }

        public override bool Load(string filename)
        {
            lock (_syncRoot)
            {
                Logger.LogDebug("{0}, filename={1}", PlayerName, filename);
                try
                {
                    if (!File.Exists(filename))
                    {
                        CurrentSoundEngine.StopAllSounds();
                        CurrentSoundEngine.RemoveAllSoundSources();
                        return false;
                    }
                    SongFilename = filename;
                    CurrentSound = CreateSound(CurrentSoundEngine, filename);
                    RaiseFinishEvent = RaisePreFinishEvent = true;
                    Logger.LogDebug("{0}, load succeeded, filename={1}", PlayerName, filename);
                    if (CurrentSound != null) return true;
                    Logger.LogError("{0}, Failed to load, filename={1}", PlayerName, filename);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
                return false;
            }
        }

        public override bool Pause()
        {
            try
            {
                Logger.LogDebug("{0}, songFileName={1}", PlayerName, SongFilename);
                if (CurrentSound == null) return false;
                CurrentSound.Paused = true;
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("{0}, Could not pause songFilename={1} {2}", PlayerName, _soundDeviceList, ex.Message);
                return false;
            }
        }

        public override bool Play()
        {
            try
            {
                Logger.LogDebug("{0}, songFileName={1}", PlayerName, SongFilename);
                if (CurrentSound == null || SongFilename == null) return false;
                //Force player volume update according to power and crossFade
                VolumePlayer = VolumePlayer;
                CurrentSound.Paused = false;
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("{0}, Could not play songFilename={1} {2}", PlayerName, _soundDeviceList, ex.Message);
                return false;
            }
        }

        public override bool SetPlayPositionMs(uint positionMs)
        {
            try
            {
                Logger.LogDebug("{0}, songFileName={1} positionMs={2}", PlayerName, SongFilename, positionMs);
                if (positionMs > DurationMs) return true;
                if (positionMs < 0) positionMs = 0;
                if (CurrentSound == null) return false;
                CurrentSound.PlayPosition = positionMs;
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return false;
            }
        }

        public override bool Stop()
        {
            try
            {
                Logger.LogDebug("{0}, songFileName={1}", PlayerName, SongFilename);
                if (CurrentSound == null) return false;
                CurrentSound.Paused = true;
                SetPlayPositionMs(0);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0}, Could not stop songFilename={1}", PlayerName, _soundDeviceList);
                return false;
            }
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private ISound CreateSound(ISoundEngineEx soundEngine, string filename)
        {
            try
            {
                Logger.LogDebug("{0}, SoundEngineDescriptor={1} filename={2}", PlayerName, soundEngine.EngineDescriptor, filename);
                soundEngine.StopAllSounds();
                soundEngine.RemoveAllSoundSources();
                FileStream songFileStream = new FileStream(filename, FileMode.Open);
                string sourceUniqueName = "Source_" + DateTime.Now.Ticks;
                ISoundSource soundSource = CurrentSoundEngine.AddSoundSourceFromIOStream(songFileStream, sourceUniqueName);
                songFileStream.Close();
                ISound sound = soundEngine.Play2D(soundSource, false, true, false);
                return sound;
            }
            catch (Exception ex)
            {
                Logger.LogError("{0}, Could not create sound for filename={1} {2}", PlayerName, filename, ex.Message);
                return null;
            }
        }

		#endregion (------  Private Methods  ------)

		#region (------  Public Methods  ------)

        public void Dispose()
        {
            lock (_syncRoot)
            {
                _periodicTimer.Stop();
                if (CurrentSound != null)
                {
                    CurrentSound.Stop();
                    CurrentSound.Dispose();
                }
                CurrentSoundEngine.StopAllSounds();
                CurrentSoundEngine.RemoveAllSoundSources();
                PlayerName = "Disposed";
            }

        }

		#endregion (------  Public Methods  ------)

    }
}