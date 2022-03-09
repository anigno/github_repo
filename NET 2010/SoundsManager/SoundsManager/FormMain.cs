using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using AnignoraUI.Common;

namespace SoundsManager
{
    public partial class FormMain : Form
    {
		#region (------  Fields  ------)

        private readonly ThreadSafeElement<bool> m_isWithinInterval=new ThreadSafeElement<bool>();
        private readonly Random m_random=new Random(DateTime.Now.Millisecond);
        private const string SOUNDS_FOLDER = "Sounds";

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public FormMain()
        {
            InitializeComponent();
            readSoundFiles();
        }

		#endregion (------  Constructors  ------)

		#region (------  Private Methods  ------)

        private void buttonIntervalAllClick(object sender, EventArgs e)
        {
            setCollectionChecked(checkedListBoxInterval, true);
        }

        private void buttonIntervalNoneClick(object sender, EventArgs e)
        {
            setCollectionChecked(checkedListBoxInterval, false);
        }

        private void buttonSoundsAllClick(object sender, EventArgs e)
        {
            setCollectionChecked(checkedListBoxSounds, true);
        }

        private void buttonSoundsNoneClick(object sender, EventArgs e)
        {
            setCollectionChecked(checkedListBoxSounds, false);
        }
        private bool m_operationStarted;

        private void checkPlaying()
        {
            if (mp3PlayerMciControlMain.IsPlaying)
            {
                return;
            }
            else
            {
                m_operationStarted = false;
            }
            if (m_operationStarted) return;
            int soundsCount = checkedListBoxSounds.CheckedItems.Count;
            if (soundsCount == 0) return;
            if (!m_isWithinInterval.Value || !checkBoxActive.Checked)
            {
                mp3PlayerMciControlMain.Stop();
                return;
            }
            int silenceFactor = int.Parse(comboBoxSilence.Text);

            Thread t = new Thread(() =>
            {
                //play next sound
                m_operationStarted = true;
                Thread.Sleep(1000*silenceFactor);
                if (!mp3PlayerMciControlMain.IsPlaying)
                {
                    CrossThreadActivities.Do(this, p =>
                    {
                        int i = m_random.Next(0, soundsCount);
                        string songFileName = checkedListBoxSounds.CheckedItems[i].ToString();
                        mp3PlayerMciControlMain.LoadSong(songFileName);
                        checkedListBoxSounds.SetSelected(i, true);
                        mp3PlayerMciControlMain.Play();
                    });
                }
            });
            t.IsBackground = true;
            t.Start();
        }

        private void formMainLoad(object sender, EventArgs e)
        {
            setCollectionChecked(checkedListBoxInterval, true);
            setCollectionChecked(checkedListBoxSounds, true);
            comboBoxSilence.SelectedIndex = 0;

        }

        private void onLabelDateTimeNowMainTick(LabelDateTimeNow p_sender, DateTime p_dateTime)
        {
            m_isWithinInterval.Value = false;
            foreach (TimeInterval interval in checkedListBoxInterval.CheckedIntervalItems)
            {
                if (interval.IsTimeOnlyWithin(p_dateTime))
                {
                    m_isWithinInterval.Value = true;
                    radioButtonPlaying.Checked = m_isWithinInterval.Value;
                    checkPlaying();
                    return;
                }
            }
            radioButtonPlaying.Checked = m_isWithinInterval.Value;
            //checkPlaying();
        }

        private void readSoundFiles()
        {
            string[] mp3Files = Directory.GetFiles(SOUNDS_FOLDER, "*.mp3");
            string[] wavFiles = Directory.GetFiles(SOUNDS_FOLDER, "*.wav");
            IEnumerable<string> songFiles = mp3Files.Union(wavFiles);
            foreach (string songFile in songFiles)
            {
                checkedListBoxSounds.Items.Add(songFile);
            }
        }

        private void setCollectionChecked(CheckedListBox p_checkedListBox, bool p_checked)
        {
            for (int a = 0; a < p_checkedListBox.Items.Count; a++)
            {
                p_checkedListBox.SetItemChecked(a, p_checked);
            }
        }

        private void trackBarVolumeScroll(object sender, EventArgs e)
        {
            mp3PlayerMciControlMain.SetVolume(trackBarVolume.Value);
        }

		#endregion (------  Private Methods  ------)
    }
}
