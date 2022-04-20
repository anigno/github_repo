using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AnignoLibrary.UI.Forms;
using LoggingProvider;
using System.Xml.Serialization;
using System.Drawing;

namespace AnignoAudioJukeBox
{
    public partial class FormMain : Form
    {

		#region (------  Const Fields  ------)

        private const string DEFAULT_PLAY_LIST_FILE = "AnignoAudioJukeBoxDefaultPlayList.xml";
        private const string DROP_FORMAT_STRING_ARRAY = "System.String[]";
        private const string DROP_FORMAT_FILEDROP = "FileDrop";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        ListViewItem _hoveredItem;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public FormMain()
        {
            Logger.LogUIAction("");
            InitializeComponent();
            anignoIrrKlangMp3PlayerControlLeft.OnPreFinishPlaying += anignoIrrKlangMp3PlayerControlLeft_OnPreFinishPlaying;
            anignoIrrKlangMp3PlayerControlRight.OnPreFinishPlaying += anignoIrrKlangMp3PlayerControlRight_OnPreFinishPlaying;
            anignoIrrKlangMp3PlayerControlLeft.OnFinishPlaying += anignoIrrKlangMp3PlayerControlLeft_OnFinishPlaying;
            anignoIrrKlangMp3PlayerControlRight.OnFinishPlaying += anignoIrrKlangMp3PlayerControlRight_OnFinishPlaying;
            anignoCrossFadeMain.OnFaderMoveEnded += anignoCrossFadeMain_OnFaderMoveEnded;
        }

		#endregion (------  Constructors  ------)

		#region (------  Event Handlers  ------)

        private void anignoCheckBoxAutoPlaylist_OnAfterCheckedChanged(AnignoLibrary.UI.CheckBoxs.AnignoCheckBox checkBox, bool checkState)
        {
            Logger.LogUIAction("checkState={0}", checkState);
            if (listViewPlaylist.Items.Count == 0)
            {
                Logger.LogDebug("Playlist is empty");
                anignoCheckBoxAutoPlaylist.Checked = false;
                return;
            }
            if(!anignoCheckBoxAutoPlaylist.Checked)return;
            //load songs to empty decks
            if (anignoIrrKlangMp3PlayerControlLeft.SongFilename == null)
            {
                string nextSong = GetNextSongAndRequeue();
                anignoIrrKlangMp3PlayerControlLeft.SongFilename = nextSong;
                Logger.LogDebug("Loading next song");
            }
            if (anignoIrrKlangMp3PlayerControlRight.SongFilename == null)
            {
                string nextSong = GetNextSongAndRequeue();
                anignoIrrKlangMp3PlayerControlRight.SongFilename = nextSong;
                Logger.LogDebug("Loading next song");
            }
        }

        private void anignoCrossFadeMain_OnFaderMoved(float valuef)
        {
            float v = anignoCrossFadeMain.ValueF;
            float vl = (v < 0 ? 1 : (1 - v));
            float vr = (v > 0 ? 1 : (1 + v));
            
            anignoIrrKlangMp3PlayerControlLeft.VolumeCrossFade=vl;
            anignoIrrKlangMp3PlayerControlRight.VolumeCrossFade=vr;
        }

        void anignoCrossFadeMain_OnFaderMoveEnded(float valuef)
        {
            Logger.LogUIAction("valuF={0}", valuef);
            //verifies if automaticaly load new song
            if (anignoCheckBoxAutoPlaylist.Checked)
            {
                string nextSong = GetNextSongAndRequeue();
                if (anignoCrossFadeMain.ValueF == 1)
                {
                    //Change song in left deck
                    anignoIrrKlangMp3PlayerControlLeft.Stop();
                    anignoIrrKlangMp3PlayerControlLeft.SongFilename = nextSong;
                    Logger.LogDebug("Replace song in deck left");
                }
                else
                {
                    //Change song in right deck
                    anignoIrrKlangMp3PlayerControlRight.Stop();
                    anignoIrrKlangMp3PlayerControlRight.SongFilename = nextSong;
                    Logger.LogDebug("Replace song in deck right");
                }
            }
        }

        private void anignoIrrKlangMp3PlayerControlLeft_DragDrop(object sender, DragEventArgs e)
        {
            if (anignoIrrKlangMp3PlayerControlLeft.IsPlaying)
            {
                MessageBoxNotification.Show("Player is playing, cannot change song.");
                return;
            }
            string songFileName = (string)e.Data.GetData("System.String");
            anignoIrrKlangMp3PlayerControlLeft.SongFilename = songFileName;
            MoveSelectedSongItemToEnd();
        }

        private void anignoIrrKlangMp3PlayerControlLeft_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.String"))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        void anignoIrrKlangMp3PlayerControlLeft_OnFinishPlaying(string playerName)
        {
            Logger.LogUIAction("{0}",playerName);
            anignoIrrKlangMp3PlayerControlLeft.SongFilename = null;
        }

        void anignoIrrKlangMp3PlayerControlLeft_OnPreFinishPlaying(string playerName)
        {
            Logger.LogUIAction("{0}", playerName);
            if (anignoCheckBoxAutoPlaylist.Checked)
            {
                anignoCrossFadeMain.FadeSmooth(1, true);
                anignoIrrKlangMp3PlayerControlRight.Play();
            }
        }

        private void anignoIrrKlangMp3PlayerControlRight_DragDrop(object sender, DragEventArgs e)
        {
            if (anignoIrrKlangMp3PlayerControlRight.IsPlaying)
            {
                MessageBoxNotification.Show("Player is playing, cannot change song.");
                return;
            }
            string songFileName = (string)e.Data.GetData("System.String");
            anignoIrrKlangMp3PlayerControlRight.SongFilename = songFileName;
            MoveSelectedSongItemToEnd();
        }

        private void anignoIrrKlangMp3PlayerControlRight_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.String"))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        void anignoIrrKlangMp3PlayerControlRight_OnFinishPlaying(string playerName)
        {
            Logger.LogUIAction("{0}", playerName);
            anignoIrrKlangMp3PlayerControlRight.SongFilename = null;
        }

        void anignoIrrKlangMp3PlayerControlRight_OnPreFinishPlaying(string playerName)
        {
            Logger.LogUIAction("{0}", playerName);
            if (anignoCheckBoxAutoPlaylist.Checked)
            {
                anignoCrossFadeMain.FadeSmooth(-1, true);
                anignoIrrKlangMp3PlayerControlLeft.Play();
            }
        }

        private void buttonCrossFade_Click(object sender, EventArgs e)
        {
            Logger.LogUIAction("");
            //Check if right deck has a song loaded
            if (anignoCrossFadeMain.ValueF <= 0 && anignoIrrKlangMp3PlayerControlRight.SongFilename == null)
            {
                Logger.LogDebug("Right deck is empty, CrossFade aborted");
                MessageBoxNotification.Show("Right deck is empty");
                return;
            }
            //Check if left deck has a song loaded
            if (anignoCrossFadeMain.ValueF <= 0 && anignoIrrKlangMp3PlayerControlLeft.SongFilename == null)
            {
                Logger.LogDebug("Left deck is empty, CrossFade aborted");
                MessageBoxNotification.Show("Left deck is empty");
                return;
            }
            //Check if autoplaylist is on to start the not playing deck
            if (anignoCheckBoxAutoPlaylist.Checked)
            {
                if (anignoCrossFadeMain.ValueF < 0)
                {
                    anignoIrrKlangMp3PlayerControlRight.Play();
                }
                else
                {
                    anignoIrrKlangMp3PlayerControlLeft.Play();
                }
            }
            RunCrossFade();
        }

        private void buttonHelp_MouseClick(object sender, MouseEventArgs e)
        {
            FormHelp fh=new FormHelp();
            fh.ShowDialog(this);
        }

        private void buttonLoadPlaylist_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.Filter = "Playlist XML files |*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadPlaylist(ofd.FileName);
            }
            ofd.Dispose();
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            Logger.LogUIAction("");
            foreach (ListViewItem item in listViewPlaylist.SelectedItems)
            {
                int index = item.Index;
                if (index != listViewPlaylist.Items.Count - 1)
                {
                    listViewPlaylist.Items.Remove(item);
                    listViewPlaylist.Items.Insert(index + 1, item);
                    item.EnsureVisible();
                }
            }
        }

        private void buttonMoveToButtom_Click(object sender, EventArgs e)
        {
            Logger.LogUIAction("");
            foreach (ListViewItem item in listViewPlaylist.SelectedItems)
            {
                int index = item.Index;
                if (index != listViewPlaylist.Items.Count - 1)
                {
                    listViewPlaylist.Items.Remove(item);
                    listViewPlaylist.Items.Add(item);
                    item.EnsureVisible();
                }
            }
        }

        private void buttonMoveToTop_Click(object sender, EventArgs e)
        {
            Logger.LogUIAction("");
            foreach (ListViewItem item in listViewPlaylist.SelectedItems)
            {
                int index = item.Index;
                if (index != 0)
                {
                    listViewPlaylist.Items.Remove(item);
                    listViewPlaylist.Items.Insert(0, item);
                    item.EnsureVisible();
                }
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            Logger.LogUIAction("");
            foreach (ListViewItem item in listViewPlaylist.SelectedItems)
            {
                int index = item.Index;
                if (index != 0)
                {
                    listViewPlaylist.Items.Remove(item);
                    listViewPlaylist.Items.Insert(index - 1, item);
                    item.EnsureVisible();
                }
            }
        }

        private void buttonRemoveFromPlaylist_Click(object sender, EventArgs e)
        {
            Logger.LogUIAction("");
            if (listViewPlaylist.SelectedItems.Count == 0) return;
            if (MessageBox.Show("Are you sure you want to remove these songs from the playlist?", "Anigno Mp3 JukeBox", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
            List<ListViewItem> removeList = new List<ListViewItem>();
            foreach (ListViewItem item in listViewPlaylist.SelectedItems)
            {
                removeList.Add(item);
            }
            foreach (ListViewItem item in removeList)
            {
                listViewPlaylist.Items.Remove(item);
            }
        }

        private void buttonSavePlaylist_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd=new SaveFileDialog();
            sfd.Filter = "Playlist XML files |*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SavePlaylist(sfd.FileName);
            }
            sfd.Dispose();
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            Logger.LogUIAction("");
            List<ListViewItem> shuffleList = new List<ListViewItem>();
            Random RND=new Random(DateTime.Now.Millisecond);
            for (int a = 0; a < listViewPlaylist.Items.Count; a++)
            {
                int index = RND.Next(0, listViewPlaylist.Items.Count);
                ListViewItem item = listViewPlaylist.Items[index];
                listViewPlaylist.Items.RemoveAt(index);
                shuffleList.Add(item);
            }
            foreach (ListViewItem item in shuffleList)
            {
                listViewPlaylist.Items.Add(item);
            }
        }

        private void filesAndFoldersBrowserMain_OnAfterSelect(string selectedItem)
        {
            Logger.LogUIAction("");
            DirectoryInfo di = new DirectoryInfo(filesAndFoldersBrowserMain.SelectedItem);
            FileInfo[] songs = di.GetFiles("*.mp3", SearchOption.TopDirectoryOnly);
            listViewBrowse.Items.Clear();
            foreach (FileInfo fi in songs)
            {
                listViewBrowse.Items.Add(fi.Name).Tag = fi.FullName;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (anignoIrrKlangMp3PlayerControlLeft.IsPlaying || anignoIrrKlangMp3PlayerControlRight.IsPlaying)
            {
                MessageBoxNotification.Show("Please stop playing decks before closing.");
                e.Cancel=true;
                return;
            }
            SavePlaylist(DEFAULT_PLAY_LIST_FILE);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Loading default parameters
            if (File.Exists(DEFAULT_PLAY_LIST_FILE)) LoadPlaylist(DEFAULT_PLAY_LIST_FILE);
            anignoCrossFadeMain.FadeSmooth(-1,false);
            numericUpDownCrossFadeInterval.Value = 3;
            numericUpDownAutoCrossFadeStartInterval.Value = 10;
            anignoIrrKlangMp3PlayerControlLeft.VolumePower = 0.5f;
            anignoIrrKlangMp3PlayerControlRight.VolumePower = 0.5f;
        }

        private void listViewBrowse_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listViewBrowse.SelectedItems.Count == 0) return;
                List<string> transferList = new List<string>();
                foreach (ListViewItem item in listViewBrowse.SelectedItems)
                {
                    transferList.Add((string)item.Tag);
                }
                listViewBrowse.DoDragDrop(transferList.ToArray(), DragDropEffects.Copy);
            }
        }

        private void listViewPlaylist_DoubleClick(object sender, EventArgs e)
        {
            if (_hoveredItem == null) return;
            LoadSpecificSongToFreePlayer((string)_hoveredItem.Tag);
        }

        private void listViewPlaylist_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DROP_FORMAT_FILEDROP))
            {
                string[] files = (string[])e.Data.GetData(DROP_FORMAT_FILEDROP);
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".mp3")
                    {
                        AddSongToPlaylist(file);
                    }
                }
            }


            if (e.Data.GetDataPresent(DROP_FORMAT_STRING_ARRAY))
            {
                string[] songs = (string[]) e.Data.GetData(DROP_FORMAT_STRING_ARRAY);
                foreach (string song in songs)
                {
                    AddSongToPlaylist(song);
                }
            }
        }

        private void AddSongToPlaylist(string songFilename)
        {
            string songName = Path.GetFileNameWithoutExtension(songFilename);
            if (!IsSongExistsInPlaylist(songName))
            {
                ListViewItem newItem = new ListViewItem(songName);
                newItem.Tag = songFilename;
                listViewPlaylist.Items.Add(newItem);
            }
        }

        private void listViewPlaylist_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DROP_FORMAT_FILEDROP))
            {
                e.Effect = DragDropEffects.Copy;
            }
            if (e.Data.GetDataPresent(DROP_FORMAT_STRING_ARRAY))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        
        private void listViewPlaylist_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            _hoveredItem = e.Item;
        }

        private void listViewPlaylist_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listViewPlaylist.SelectedItems.Count == 0) return;
                listViewPlaylist.DoDragDrop(listViewPlaylist.SelectedItems[0].Tag, DragDropEffects.Copy);
            }
        }

        private void numericUpDownAutoCrossFade_ValueChanged(object sender, EventArgs e)
        {
            anignoIrrKlangMp3PlayerControlLeft.PreFinishPlayingInterval = (uint)numericUpDownAutoCrossFadeStartInterval.Value;
            anignoIrrKlangMp3PlayerControlRight.PreFinishPlayingInterval = (uint)numericUpDownAutoCrossFadeStartInterval.Value;
        }

        private void numericUpDownCrossFade_ValueChanged(object sender, EventArgs e)
        {
            anignoCrossFadeMain.FadeTime = (int)numericUpDownCrossFadeInterval.Value * 1000;
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Private Methods  ------)

        private string GetNextSongAndRequeue()
        {
            Logger.LogUIAction("");
            if (listViewPlaylist.Items.Count == 0) return null;
            string nextSong;
            int tries = 0;
            do
            {
                tries++;
                ListViewItem songItem = listViewPlaylist.Items[0];
                listViewPlaylist.Items.RemoveAt(0);
                listViewPlaylist.Items.Add(songItem);
                nextSong = (string)songItem.Tag;
                if (!File.Exists(nextSong))
                {
                    songItem.BackColor = Color.RosyBrown;
                    nextSong = null;
                }
                else
                {
                    songItem.BackColor = listViewPlaylist.BackColor;
                }
            } while (nextSong==null && tries<listViewPlaylist.Items.Count);
            if (nextSong == null) MessageBoxNotification.Show("Could not find existing next song.");
            return nextSong;
        }

        private bool IsSongExistsInPlaylist(string filename)
        {
            string songName=Path.GetFileNameWithoutExtension(filename);
            foreach (ListViewItem item in listViewPlaylist.Items)
            {
                if(item.Text==songName)return true;
            }
            return false;
        }

        private void LoadPlaylist(string filename)
        {
            Logger.LogUIAction("filename={0}",filename);
            FileStream fs=null;
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<string>));
                fs = new FileStream(filename, FileMode.Open);
                object o=xs.Deserialize(fs);
                List<string> loadedPlaylist = (List<string>)o;
                listViewPlaylist.Items.Clear();
                foreach (string songFilename in loadedPlaylist)
                {
                    ListViewItem item=new ListViewItem(Path.GetFileNameWithoutExtension(songFilename));
                    item.Tag=songFilename;
                    listViewPlaylist.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBoxNotification.Show("Could not load playlist from file: "+filename);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        private void LoadSpecificSongToFreePlayer(string filename)
        {
            if (!anignoIrrKlangMp3PlayerControlLeft.IsPlaying)
            {
                anignoIrrKlangMp3PlayerControlLeft.SongFilename = filename;
                return;
            }
            if (!anignoIrrKlangMp3PlayerControlRight.IsPlaying)
            {
                anignoIrrKlangMp3PlayerControlRight.SongFilename = filename;
                return;
            }
            MessageBoxNotification.Show("No free player, no song is loaded!");
        }

        private void MoveSelectedSongItemToEnd()
        {
            if(listViewPlaylist.SelectedItems.Count==0)return;
            ListViewItem selectedItem = listViewPlaylist.SelectedItems[0];
            listViewPlaylist.Items.Remove(selectedItem);
            listViewPlaylist.Items.Add(selectedItem);
        }

        private void RunCrossFade()
        {
            Logger.LogUIAction("anignoCrossFadeMain.ValueF={0}", anignoCrossFadeMain.ValueF);
            if (anignoCrossFadeMain.ValueF < 0)
            {
                anignoCrossFadeMain.FadeSmooth(1,true);
            }
            else
            {
                anignoCrossFadeMain.FadeSmooth(-1,true);
            }
        }

        private void SavePlaylist(string filename)
        {
            Logger.LogUIAction("filename={0}", filename);
            FileStream fs = null;
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<string>));
                fs = new FileStream(filename, FileMode.Create);
                List<string> savedPlaylist = new List<string>();
                foreach (ListViewItem item in listViewPlaylist.Items)
                {
                    savedPlaylist.Add((string)item.Tag);
                }
                xs.Serialize(fs, savedPlaylist);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBoxNotification.Show("Could not load playlist from file: " + filename);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

		#endregion (------  Private Methods  ------)

    }
}