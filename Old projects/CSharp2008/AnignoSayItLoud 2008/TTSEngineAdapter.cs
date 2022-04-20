using System.Collections.Generic;
using System.Threading;
using SpeechLib;
using System.IO;

namespace AnignoSayItLoud
{
    public static class TTSEngineAdapter
    {
        #region Fields
        private static readonly Dictionary<string, ISpeechObjectToken> _installedEngines = new Dictionary<string, ISpeechObjectToken>();
        private static int _rate = 0;
        private static SpVoice _voice = null;
        private static bool _isSpeakRequested = false;
        #endregion

        #region Events decleration
        //SpeechVoiceEvents events
        public static event _ISpeechVoiceEvents_AudioLevelEventHandler OnVolumeChanged;
        public static event _ISpeechVoiceEvents_WordEventHandler OnWordRead;
        public static event _ISpeechVoiceEvents_EndStreamEventHandler OnEndStream;
        public static event _ISpeechVoiceEvents_StartStreamEventHandler OnStartStream;
        //TTSEngineAdapter events
        public delegate void TTSEngineAdapter_StartSaving();
        public delegate void TTSEngineAdapter_EndSaving();
        public static event TTSEngineAdapter_StartSaving OnStartSaving;
        public static event TTSEngineAdapter_EndSaving OnEndSaving;
        #endregion

        #region CTORs
        static TTSEngineAdapter()
        {
            UpdateInstalledEngines();
            _voice = CreateNewVoice();
        }
        #endregion

        #region Properties 
        public static string[] InstalledSpeechEngines
        {
            get
            {
                List<string> speechEnginesDescriptionList = new List<string>(_installedEngines.Keys);
                return speechEnginesDescriptionList.ToArray();
            }
        }

        public static int Rate
        {
            get { return _rate; }
            set
            {
                if (value >= -1 && value <= 10)
                {
                    _rate = value;
                    _voice.Rate = value;
                }
            }
        }

        public static SpObjectToken SpeechEngine
        {
            get { return _voice.Voice; }
            set { _voice.Voice = value; }
        }
        #endregion

        #region Public
        public static SpObjectToken GetSpeechEngine(int index)
        {
            SpVoice voice = new SpVoice();
            return voice.GetVoices("", "").Item(index);
        }

        public static ISpeechObjectToken GetSpeechEngine(string description)
        {
            return _installedEngines[description];
        }

        public static void StartSpeak(string text)
        {
            if (_isSpeakRequested)
            {
                StopSpeak();
            }
            _isSpeakRequested = true;
            _voice.Speak(text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        public static void StartSpeakToStream(string text,string fileName)
        {
            if (_isSpeakRequested)
            {
                StopSpeak();
            }
            _isSpeakRequested = true;
            if (OnStartSaving != null) OnStartSaving();
            SpeechStreamFileMode fileMode = SpeechStreamFileMode.SSFMCreateForWrite;
            SpFileStream fileStream = new SpFileStream();
            fileStream.Open(fileName, fileMode, false);
            _voice.AudioOutputStream = fileStream;
            _voice.Speak(text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
            _voice.WaitUntilDone(Timeout.Infinite);
            fileStream.Close();
            if (OnEndSaving != null) OnEndSaving();
        }

        /// <summary>
        /// Pause current voice and create a new one instead (stopping action)
        /// </summary>
        public static void StopSpeak()
        {
            if (_isSpeakRequested)
            {
                _voice.Pause();
                _voice = CreateNewVoice();
                _isSpeakRequested = false;
            }
        }

        /// <summary>
        /// Creates new SpVoice object and initialize it
        /// </summary>
        /// <returns></returns>
        private static SpVoice CreateNewVoice()
        {
            SpVoice newVoice = new SpVoice();
            newVoice.AlertBoundary = SpeechVoiceEvents.SVEWordBoundary;
            newVoice.Rate = _rate;
            newVoice.EventInterests = SpeechVoiceEvents.SVEAllEvents;
            newVoice.AudioLevel += Voice_AudioLevel;
            newVoice.Word += Voice_Word;
            newVoice.EndStream += Voice_EndStream;
            newVoice.StartStream += Voice_StartStream;
            newVoice.EventInterests = SpeechVoiceEvents.SVEAllEvents;
            if (_voice == null)
            {
                //set default speech engine
                if (_installedEngines.Count > 0) newVoice.Voice = GetSpeechEngine(0);
            }
            else
            {
                SpObjectToken oldVoiceToken = _voice.Voice;
                newVoice.Voice = oldVoiceToken;
            }
            return newVoice;
        }
        #endregion

        #region Private
        static private void UpdateInstalledEngines()
        {
            _installedEngines.Clear();
            SpVoice voice = new SpVoice();
            foreach (ISpeechObjectToken token in voice.GetVoices("", ""))
            {
                _installedEngines.Add(token.GetDescription(0), token);
            }
        }
        #endregion

        #region Events handlers
        static void Voice_StartStream(int StreamNumber, object StreamPosition)
        {
            if (OnStartStream != null) OnStartStream(StreamNumber, StreamPosition);
        }

        private static void Voice_EndStream(int StreamNumber, object StreamPosition)
        {
            if (OnEndStream != null) OnEndStream(StreamNumber, StreamPosition);
        }

        private static void Voice_Word(int StreamNumber, object StreamPosition, int CharacterPosition, int Length)
        {
            if (OnWordRead != null) OnWordRead(StreamNumber, StreamPosition, CharacterPosition, Length);
        }

        private static void Voice_AudioLevel(int StreamNumber, object StreamPosition, int AudioLevel)
        {
            if (OnVolumeChanged != null) OnVolumeChanged(StreamNumber, StreamPosition, AudioLevel);
        }
        #endregion

    }
}