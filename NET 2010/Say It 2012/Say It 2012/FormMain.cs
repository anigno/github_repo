using System;
using System.Collections.Generic;
using System.Drawing;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using AnignoraDataTypes.Configurations;
using AnignoraUI.Common;

namespace Say_It_2012
{
    public partial class FormMain : Form
    {
		#region (------  Fields  ------)
        private ConfiguratorXml<SayItConfiguration> m_configurator = new ConfiguratorXml<SayItConfiguration>("SayItConfiguration.XML");
        private readonly SpeechSynthesizer m_speechSynthesizer = new SpeechSynthesizer();
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public FormMain()
        {
            InitializeComponent();
            m_configurator.Load();
        }
		#endregion (------  Constructors  ------)

		#region (------  Events Handlers  ------)
        private void listViewVoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewVoices.SelectedIndices.Count == 0) return;
            if (m_speechSynthesizer.State == SynthesizerState.Speaking)
            {
                m_speechSynthesizer.SpeakAsyncCancelAll();
            }
            InstalledVoice v = (InstalledVoice)listViewVoices.SelectedItems[0].Tag;
            m_speechSynthesizer.SelectVoice(v.VoiceInfo.Name);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            m_speechSynthesizer.SpeakAsyncCancelAll();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Speak();
        }

        private void numericUpDownRate_ValueChanged(object sender, EventArgs e)
        {
            m_speechSynthesizer.Rate = (int)numericUpDownRate.Value;
        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            richTextBoxInput.Font = new Font(Font.FontFamily, (float)numericUpDownFontSize.Value);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (m_speechSynthesizer.State == SynthesizerState.Speaking)
            {
                m_speechSynthesizer.Pause();
                return;
            }
            if (m_speechSynthesizer.State == SynthesizerState.Paused) m_speechSynthesizer.Resume();
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    m_speechSynthesizer.SetOutputToWaveFile(saveFileDialog.FileName);
                    Speak();
                }
            }
        }

        private void checkBoxMonitorClipboard_CheckedChanged(object sender, EventArgs e)
        {
            timerCheckClipboard.Enabled = checkBoxMonitorClipboard.Checked;
        }

        private void timerCheckClipboard_Tick(object sender, EventArgs e)
        {
            string t = Clipboard.GetText().Replace("\r", "");
            t = changeKnownTextIssues(t);
            string s = richTextBoxInput.Text;
            if (t != s)
            {
                richTextBoxInput.Text = t;
                Speak();
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (InstalledVoice voice in m_speechSynthesizer.GetInstalledVoices())
            {
                ListViewItem item = new ListViewItem(new string[] { voice.VoiceInfo.Name });
                item.Tag = voice;
                listViewVoices.Items.Add(item);
            }
            m_speechSynthesizer.SpeakProgress += onSpeechSynthesizerSpeakProgress;
            m_speechSynthesizer.SpeakCompleted += onSpeechSynthesizerSpeakCompleted;
            if (listViewVoices.Items.Count == 0) return;
            listViewVoices.Items[0].Selected = true;
            Text += string.Format(" [{0}]", Application.ProductVersion);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            m_speechSynthesizer.SpeakAsyncCancelAll();
        }
        void onSpeechSynthesizerSpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            if (m_speechSynthesizer.State == SynthesizerState.Speaking)
            {
                m_speechSynthesizer.SpeakAsyncCancelAll();
            }
            if (m_speechSynthesizer.State == SynthesizerState.Speaking) return;
            m_speechSynthesizer.SetOutputToDefaultAudioDevice();
        }

        void onSpeechSynthesizerSpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            richTextBoxInput.Select(e.CharacterPosition, e.CharacterCount);
        }
		#endregion (------  Events Handlers  ------)

		#region (------  Private Methods  ------)
        private string changeKnownTextIssues(string s)
        {
            foreach (StringPair pair in m_configurator.Configuration.TextPairs)
            {
                s = Regex.Replace(s, pair.OldString,pair.NewString, RegexOptions.IgnoreCase);
            }
            return s;
        }

        private void Speak()
        {
            m_speechSynthesizer.Rate = (int)numericUpDownRate.Value;
            if (m_speechSynthesizer.State == SynthesizerState.Paused) m_speechSynthesizer.Resume();
            if (m_speechSynthesizer.State == SynthesizerState.Speaking)
            {
                m_speechSynthesizer.SpeakAsyncCancelAll();
            }
            Thread t = new Thread(delegate()
            {
                CrossThreadActivities.Do(this, delegate
                {
                    m_speechSynthesizer.SpeakAsync(richTextBoxInput.Text);
                });
            });
            t.Start();
        }
		#endregion (------  Private Methods  ------)
    }

    public class StringPair
    {
		#region (------  Constructors  ------)
        public StringPair(string p_oldString, string p_newString)
        {
            OldString = p_oldString;
            NewString = p_newString;
        }

        public StringPair()
        {
        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public string NewString { get; set; }

        public string OldString { get; set; }
		#endregion (------  Properties  ------)
    }

    public class SayItConfiguration : IConfiguration
    {
		#region (------  Constructors  ------)
        public SayItConfiguration()
        {
            TextPairs = new List<StringPair>();
        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public List<StringPair> TextPairs { get; set; }
		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)
        public void SetDefaults()
        {
            TextPairs.Add(new StringPair("WinRT", "Win R T"));
            TextPairs.Add(new StringPair(".NET", "Dot Net"));
            TextPairs.Add(new StringPair("UI", "U I"));
            TextPairs.Add(new StringPair("C#", "C Sharp"));
            TextPairs.Add(new StringPair("CLI", "C.L.I."));
            TextPairs.Add(new StringPair("API", "A.P.I."));
        }
		#endregion (------  Public Methods  ------)
    }
}
