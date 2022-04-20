using System;
using System.Drawing;
using System.Windows.Forms;
using AnignoLibrary.Misc.TextToSpeech;
using System.Speech.Synthesis;
using AnignoLibrary.Helpers.InvokationHelpers;

namespace AnignoSayItLoad2
{
    public partial class FormMain : Form
    {
		#region (------------------  Fields  ------------------)
        private readonly TextToSpeechProducer tts=new TextToSpeechProducer();
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public FormMain()
        {
            InitializeComponent();
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Delegates  ------------------)
        private delegate void SelectTextDelegate(int start,int count);
		#endregion (------------------  Delegates  ------------------)


		#region (------------------  Event Handlers  ------------------)
        private void buttonPause_Click(object sender, EventArgs e)
        {
            tts.Pause();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            tts.Play(richTextBoxMain.Text,null);
        }

        private void buttonPlayToFile_Click(object sender, EventArgs e)
        {
            tts.Stop();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "WAV|*.wav";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tts.Play(richTextBoxMain.Text,sfd.FileName);
                labelTimedMessageMain.Show("Creating: " + sfd.FileName, Color.Black, Color.White);
                checkBoxClipboard.Checked = false;
                checkBoxClipboard.Enabled = false; numericUpDownRate.Enabled = false;
                buttonPlay.Enabled = false;
                buttonPlayToFile.Enabled=false;
                listBoxVoices.Enabled=false;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            tts.Stop();
        }

        private void checkBoxClipboard_CheckedChanged(object sender, EventArgs e)
        {
            timerClipboard.Enabled = checkBoxClipboard.Checked;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            tts.Stop();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Text += " " + Program.Version;
            foreach (string voice in tts.InstalledVoices)
            {
                listBoxVoices.Items.Add(voice);
            }
            if (listBoxVoices.Items.Count > 0) listBoxVoices.SelectedIndex = 0;
            tts.SpeakErrorOccured += tts_SpeakErrorOccured;
            tts.SpeakProgress += tts_SpeakProgress;
            tts.SpeakCompleted += tts_SpeakCompleted;
            tts.SpeakStateChanged += tts_SpeakStateChanged;
            timerClipboard.Tick += timerClipboard_Tick;
        }

        private void listBoxVoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedVoiceName=listBoxVoices.SelectedItem.ToString();
            tts.SelectedVoice = selectedVoiceName;
            PlayIntro();
        }

        private void notifyIconMain_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = true;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                Visible = false;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void numericUpDownRate_ValueChanged(object sender, EventArgs e)
        {
            tts.Rate = (int) numericUpDownRate.Value;
            PlayIntro();
        }

        void timerClipboard_Tick(object sender, EventArgs e)
        {
            timerClipboard.Stop();
            if (Clipboard.ContainsText())
            {

                string ct = Clipboard.GetText();
                string text = GetCharsOnlyString(Clipboard.GetText());
                string rtfText = GetCharsOnlyString(richTextBoxMain.Text);
                if(text!=rtfText)
                {
                    tts.Stop();
                    richTextBoxMain.Text = text;
                    richTextBoxMain.SelectionStart = 0;
                    richTextBoxMain.SelectionLength = 0;
                    tts.Play(text,null);
                }
            }
            timerClipboard.Start();
        }

        void tts_SpeakCompleted(object sender,SpeakCompletedEventArgs e)
        {
            SelectTextInvoked(0, 0);
            GenericInvoker.GenericInvoke(labelTimedMessageMain, c => c.Show("Speech completed", Color.Black, Color.White));
            GenericInvoker.GenericInvoke(checkBoxClipboard, c => c.Enabled = true);
            GenericInvoker.GenericInvoke(buttonPlay, c => c.Enabled = true);
            GenericInvoker.GenericInvoke(buttonPlayToFile, c => c.Enabled = true);
            GenericInvoker.GenericInvoke(listBoxVoices, c => c.Enabled = true);
            GenericInvoker.GenericInvoke(numericUpDownRate, c => c.Enabled = true);
        }

        void tts_SpeakErrorOccured(object sender, System.IO.ErrorEventArgs e)
        {
            labelTimedMessageMain.Show(e.GetException().Message,Color.Red,Color.Black);
        }

        void tts_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            SelectTextInvoked(e.CharacterPosition,e.CharacterCount);
        }

        void tts_SpeakStateChanged(object sender, StateChangedEventArgs e)
        {
            GenericInvoker.GenericInvoke(labelState, c => c.Text = e.State.ToString());
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Overridden Methods  ------------------)
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (WindowState == FormWindowState.Minimized) Visible = false;
        }
		#endregion (------------------  Overridden Methods  ------------------)


		#region (------------------  Private Methods  ------------------)
        private string GetCharsOnlyString(string stringInput)
        {
            const string pattern = "[^a-zA-Z.,'\n']";
            string result = System.Text.RegularExpressions.Regex.Replace(stringInput, pattern, " ");
            return result;
        }

        private void PlayIntro()
        {
            string selectedVoiceName = listBoxVoices.SelectedItem.ToString(); 
            tts.Play("I am " + selectedVoiceName,null);
        }

        private void SelectTextInvoked(int start, int count)
        {
            if (InvokeRequired)
            {
                Invoke(new SelectTextDelegate(SelectTextInvoked), start,count);
            }
            else
            {
                richTextBoxMain.SelectionStart = start;
                richTextBoxMain.SelectionLength = count;
            }
        }
		#endregion (------------------  Private Methods  ------------------)
    }
}
