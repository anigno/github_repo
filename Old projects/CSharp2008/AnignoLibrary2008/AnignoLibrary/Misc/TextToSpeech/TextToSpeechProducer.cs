using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Synthesis;

namespace AnignoLibrary.Misc.TextToSpeech
{
    public class TextToSpeechProducer
    {
		#region (------------------  Fields  ------------------)
        private readonly SpeechSynthesizer speakRBox = new SpeechSynthesizer();
        private string selectedVoice;
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public TextToSpeechProducer()
        {
            //Init list of installed voices
            List<string> lRet = new List<string>();
            foreach (InstalledVoice voice in speakRBox.GetInstalledVoices())
            {
                lRet.Add(voice.VoiceInfo.Name);
            }
            InstalledVoices = lRet.ToArray();
            speakRBox.SpeakCompleted += speakRBox_SpeakCompleted;
            speakRBox.SpeakProgress += speakRBox_SpeakProgress;
            speakRBox.StateChanged += speakRBox_StateChanged;
        }

        void speakRBox_StateChanged(object sender, StateChangedEventArgs e)
        {
            if (SpeakStateChanged != null) SpeakStateChanged(this, e);
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Properties  ------------------)
        public int Rate
        {
            get { return speakRBox.Rate; }
            set { speakRBox.Rate = value; }
        }

        public string SelectedVoice
        {
            get { return selectedVoice; }
            set
            {
                foreach (string voiceString in InstalledVoices)
                {
                    if (value == voiceString)
                    {
                        selectedVoice = value;
                        return;
                    }
                    selectedVoice = null;
                }
            }
        }

        public string[] InstalledVoices { get; private set; }

        public SynthesizerState State
        {
            get { return speakRBox.State; }
        }
		#endregion (------------------  Properties  ------------------)


		#region (------------------  Events  ------------------)
        public event EventHandler<SpeakCompletedEventArgs> SpeakCompleted;

        public event EventHandler<ErrorEventArgs> SpeakErrorOccured;

        public event EventHandler<SpeakProgressEventArgs> SpeakProgress;

        public event EventHandler<StateChangedEventArgs> SpeakStateChanged;
		#endregion (------------------  Events  ------------------)


		#region (------------------  Event Handlers  ------------------)
        void speakRBox_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            if (SpeakCompleted != null) SpeakCompleted(this, e);
        }

        void speakRBox_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            if (SpeakProgress != null) SpeakProgress(this, e);
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Public Methods  ------------------)
        public void Play(string text,string filename)
        {
            try
            {
                if (speakRBox.State == SynthesizerState.Ready)
                {
                    speakRBox.SelectVoice(SelectedVoice);
                    if (filename == null)
                    {
                        speakRBox.SetOutputToDefaultAudioDevice();
                    }
                    else
                    {
                        speakRBox.SetOutputToWaveFile(filename);
                    }
                    speakRBox.SpeakAsync(text);
                    return;
                }

                if (speakRBox.State == SynthesizerState.Paused)
                {
                    speakRBox.Resume();
                }
            }
            catch (Exception ex)
            {
                if (SpeakErrorOccured != null) SpeakErrorOccured(this, new ErrorEventArgs(ex));
            }
        }

        public void Stop()
        {
            if (speakRBox.State != SynthesizerState.Ready)
            {
                speakRBox.SpeakAsyncCancelAll();
            }
        }

        public void Pause()
        {
            if (speakRBox.State == SynthesizerState.Speaking)
            {
                speakRBox.Pause();
            }
            else if (speakRBox.State == SynthesizerState.Paused)
            {
                speakRBox.Resume();
            }
        }

        #endregion (------------------  Public Methods  ------------------)
    }
}