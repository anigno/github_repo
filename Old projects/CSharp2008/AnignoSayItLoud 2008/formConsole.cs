using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpeechLib;

namespace AnignoSayItLoud
{
    public partial class formConsole : Form
    {
       
        public formConsole()
        {
            InitializeComponent();
        }

        private void formConsole_Load(object sender, EventArgs e)
        {
            UpdateEnginesListBox();
            TTSEngineAdapter.OnVolumeChanged += TTSEngineAdapter_OnVolumeChanged;
            TTSEngineAdapter.OnWordRead += TTSEngineAdapter_OnWordRead;
            TTSEngineAdapter.OnEndStream += TTSEngineAdapter_OnEndStream;
            TTSEngineAdapter.OnStartSaving += TTSEngineAdapter_OnStartSaving;
            TTSEngineAdapter.OnEndSaving += TTSEngineAdapter_OnEndSaving;
        }

        void TTSEngineAdapter_OnEndSaving()
        {
            MessageBox.Show("End saving to file", "Save text to file", MessageBoxButtons.OK);
        }

        void TTSEngineAdapter_OnStartSaving()
        {
            
        }

        void TTSEngineAdapter_OnEndStream(int StreamNumber, object StreamPosition)
        {
            rtfTextToSpeak.SelectionBackColor = rtfTextToSpeak.BackColor;
            rtfTextToSpeak.SelectionColor = rtfTextToSpeak.ForeColor;
        }

        void TTSEngineAdapter_OnWordRead(int StreamNumber, object StreamPosition, int CharacterPosition, int Length)
        {
            rtfTextToSpeak.SelectionBackColor = rtfTextToSpeak.BackColor;
            rtfTextToSpeak.SelectionColor = rtfTextToSpeak.ForeColor;
            rtfTextToSpeak.SelectionStart = CharacterPosition;
            rtfTextToSpeak.SelectionLength = Length;
            rtfTextToSpeak.SelectionBackColor = rtfTextToSpeak.ForeColor;
            rtfTextToSpeak.SelectionColor = rtfTextToSpeak.BackColor;
        }

        void TTSEngineAdapter_OnVolumeChanged(int StreamNumber, object StreamPosition, int AudioLevel)
        {
            UpdateVolumeMeterInvoked(AudioLevel);
        }

        #region Private invoked
        private delegate void UpdateVolumeMeterDelegate(int volume);
        private void UpdateVolumeMeterInvoked(int volume)
        {
            if (InvokeRequired)
            {
                Invoke((UpdateVolumeMeterDelegate)UpdateVolumeMeterInvoked, new object[] { volume });
            }
            else
            {
                progressBarVolume.Value=volume;
            }
        }

        #endregion

        #region Private
        private void UpdateEnginesListBox()
        {
            listBoxEngines.Items.Clear();
            foreach (string s in TTSEngineAdapter.InstalledSpeechEngines)
            {
                listBoxEngines.Items.Add(s);
            }
        }

        private void SetSelectedVoice(int index)
        {
            TTSEngineAdapter.SpeechEngine = TTSEngineAdapter.GetSpeechEngine(index);
        }
        #endregion

        private void buttonSpeak_Click(object sender, EventArgs e)
        {
            TTSEngineAdapter.StartSpeak(rtfTextToSpeak.Text);
        }

        private void listBoxEngines_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSelectedVoice(listBoxEngines.SelectedIndex);
        }


        private void buttonStop_Click(object sender, EventArgs e)
        {
            TTSEngineAdapter.StopSpeak();
            rtfTextToSpeak.SelectionBackColor = rtfTextToSpeak.BackColor;
            rtfTextToSpeak.SelectionColor = rtfTextToSpeak.ForeColor;
        }

        private void trackBarRate_Scroll(object sender, EventArgs e)
        {
            TTSEngineAdapter.Rate = trackBarRate.Value;
            Console.WriteLine("rate {0}",trackBarRate.Value);
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd=new SaveFileDialog();
            sfd.Filter="WAV|*.wav";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                TTSEngineAdapter.StartSpeakToStream(rtfTextToSpeak.Text,sfd.FileName);
            }
        }

        private void checkBoxClipboardCapture_CheckedChanged(object sender, EventArgs e)
        {
            timerClipboardMonitor.Enabled = checkBoxClipboardCapture.Checked;
        }

        private void timerClipboardMonitor_Tick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();
                if (rtfTextToSpeak.Text != text)
                {
                    TTSEngineAdapter.StopSpeak();
                    rtfTextToSpeak.Text=text;
                    Clipboard.Clear();
                    TTSEngineAdapter.StartSpeak(rtfTextToSpeak.Text);
                }
            }
        }
    
    }
}