using System;
using System.Windows.Forms;
using AnignoLibrary.DataTypes;
using AnignoLibrary.DataTypes.DataManager;
using System.Threading;
using LoggingProvider;
using AnignoLibrary.Helpers.InvokationHelpers;
using System.IO;
using AnignoLibrary.Communication.Email;
using NUnit.Framework;
using System.Drawing;
using AnignoLibrary.UI.Misc;

namespace AnignoBackupToEmail
{
    [TestFixture]
    public partial class FormMain : Form
    {
		#region (------  Const Fields  ------)

        public const string ITEM_STATE_ARCHIVING = "ARCHIVING";
        public const string ITEM_STATE_QUEUED = "QUEUED";
        private const string TempPath = @"c:\_AnignoBacupToEmailTemp\";
        private readonly QueueThreaded<string> _archiveQueue = new QueueThreaded<string>(2000);
        private readonly QueueThreaded<string> _senderQueue = new QueueThreaded<string>(2000);

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)

        private readonly AnignoBackupToEmailData _data = DataManagerContractBased<AnignoBackupToEmailData>.DataItem;

		#endregion (------  Fields  ------)

		#region (------  Delegates  ------)

        private delegate void SetProgressBarDisplayDataDelegate(int value,int maximum,bool timerEnabled);

		#endregion (------  Delegates  ------)

		#region (------  Constructors  ------)

        public FormMain()
        {
            Thread.CurrentThread.Name = "UI Thread";
            Logger.LogInfo("Starting AnignoBackupToEmail");
            InitializeComponent();
            _archiveQueue.AutoDequeueOnEvent=false;
            _archiveQueue.OnQueueThreadedPeriodicEvent += archiveQueue_OnQueueThreadedPeriodicEvent;
            _senderQueue.AutoDequeueOnEvent = false;
            _senderQueue.OnQueueThreadedPeriodicEvent += _senderQueue_OnQueueThreadedPeriodicEvent;
            anignoZipForgeControlMain.OnFinishedSuccessfuly += anignoZipForgeControlMain_OnFinishedSuccessfuly;
            anignoZipForgeControlMain.OnErrorOccured += anignoZipForgeControlMain_OnErrorOccured;
        }

		#endregion (------  Constructors  ------)

		#region (------  Event Handlers  ------)

        void _senderQueue_OnQueueThreadedPeriodicEvent(string firstItem)
        {
            try
            {
                FileInfo fi = new FileInfo(firstItem);
                long fileLengthKb = fi.Length / 1024;
                int timeToUploadSec = (int)(fileLengthKb / _data.UploadSpeedKps) * 2 + 60;
                _senderQueue.EnablePeriodicEvent = false;
                string messageSubject = string.Format("[{0}] Sent on: {1} File: {2}", _data.EmailSubjectPrefix, DateTime.Now.ToShortDateString(), Path.GetFileName(firstItem).Substring(19));
                ListViewItem itemAdd = new ListViewItem(new[] { timeToUploadSec / 2 / 60 + "m", "Uploading: " + firstItem });
                itemAdd.BackColor = UIHelper.COLOR_IS_VALID_LIGHT_GREEN;
                ListViewInvokationHelper.ListView_ItemAdd_Invoked(listViewExtLog, InvokationTypeEnum.Synch, itemAdd, true);
                SetProgressBarDisplayDataInvoked(0, timeToUploadSec / 2, true);
                SmtpClientByGmail client = new SmtpClientByGmail(_data.SenderGmailAddress, _data.SenderGmailPassword, timeToUploadSec);
                int result = EmailSender.SendEmailSync(client, _data.EmailSubjectPrefix, _data.SenderGmailAddress, _data.SenderGmailAddress, messageSubject, messageSubject, firstItem);
                _senderQueue.EnablePeriodicEvent = true;
                if (result < 0)
                {
                    //Display error message but do not dequeue
                    Logger.LogError("Error while sending email. {0} {1}", messageSubject,EmailSender.LastError);
                    ListViewItem itemError = new ListViewItem(new[] { "", "Error uploading: " + firstItem + " ,Will retry. Error was: "+EmailSender.LastError });
                    itemError.BackColor = UIHelper.COLOR_NOT_VALID_LIGHT_RED;
                    ListViewInvokationHelper.ListView_ItemAdd_Invoked(listViewExtLog, InvokationTypeEnum.Synch, itemError, true);
                    return;
                }
                ListViewItem itemDone = new ListViewItem(new[] { "", "Done Uploading: " + firstItem });
                itemDone.BackColor = UIHelper.COLOR_IS_VALID_LIGHT_GREEN;

                ListViewInvokationHelper.ListView_ItemAdd_Invoked(listViewExtLog, InvokationTypeEnum.Synch, itemDone, true);
                _senderQueue.Dequeue();
                ListViewInvokationHelper.ListView_ItemRemove_Invoked(listViewExtSender, InvokationTypeEnum.Synch, 0);
                SetProgressBarDisplayDataInvoked(0, 0, false);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK);
            }
        }

        void anignoZipForgeControlMain_OnErrorOccured(string progressData)
        {
            Logger.LogError("Error with archiver: {0}",progressData);
            MessageBox.Show("Error with archiver: " + progressData, "", MessageBoxButtons.OK);
            _archiveQueue.EnablePeriodicEvent = false;
        }

        void anignoZipForgeControlMain_OnFinishedSuccessfuly(string progressData)
        {
            Logger.LogDebug("End archiving, baseFile: {0}",progressData);
            _archiveQueue.Dequeue();
            _archiveQueue.EnablePeriodicEvent = true;
            ListViewInvokationHelper.ListView_ItemRemove_Invoked(listViewExtArchiveQueue, InvokationTypeEnum.Synch, 0);
            EnqueueAllArchivedFilesToSender(progressData);
        }

        void archiveQueue_OnQueueThreadedPeriodicEvent(string firstItem)
        {
            Logger.LogDebug("Archiving: {0}", firstItem);
            ListViewInvokationHelper.ListView_SubItemSetText_Invoked(listViewExtArchiveQueue, InvokationTypeEnum.Synch, 0, 2, ITEM_STATE_ARCHIVING);
            ArchiveDirectory(firstItem);
        }

        private void buttonAddFolders_Click(object sender, EventArgs e)
        {
            Logger.Log();
            AddSelectedFoldersToArchiveQueue();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logger.Log();
            _archiveQueue.AbortPeriodicThread();
            anignoZipForgeControlMain.Abort();
            _senderQueue.AbortPeriodicThread();
            //TODO: Save queues
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            foreach (string s in _archiveQueue)
            {
                listViewExtArchiveQueue.Items.Add(s);
            }
            foreach (string s in _senderQueue)
            {
                listViewExtSender.Items.Add(s);
            }
            //TODO: Load queues
            LoadSettings();
        }

        private void numericUpDownMaximumAttachmentSizeMb_ValueChanged(object sender, EventArgs e)
        {
            _data.MaximumAttachmentSizeMb = numericUpDownMaximumAttachmentSizeMb.Value;
        }

        private void numericUpDownSendTimeout_ValueChanged(object sender, EventArgs e)
        {
            _data.UploadSpeedKps = numericUpDownUploadSpeed.Value;
            labelAverageForMega.Text = GetCalcAverageForMega((float)_data.UploadSpeedKps);
        }

        private void textBoxEmailSubjectPrefix_TextChanged(object sender, EventArgs e)
        {
            _data.EmailSubjectPrefix=textBoxEmailSubjectPrefix.Text;
        }

        private void textBoxGmailPassword_TextChanged(object sender, EventArgs e)
        {
            _data.SenderGmailPassword = textBoxGmailPassword.Text;
        }

        private void TextBoxsArchivesPassword_PasswordChanged(object sender, EventArgs e)
        {
            _data.ArchivesPassword = TextBoxsArchivesPassword.Password;
        }

        private void textBoxValidatedEmail_TextChanged(object sender, EventArgs e)
        {
            if (textBoxValidatedEmail.IsValid)
            {
                _data.SenderGmailAddress = textBoxValidatedEmail.Text;
            }
        }

        private void TvFoldersSelect_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //To prevent sub folders from being archived when parent folder is already selected
            // check is removed from child sub folders when parent is checked and sub folder cannot
            // be checked when parent folder is already checked
            if (e.Node.Checked)
            {
                if (TvFoldersSelect.IsAnyParentChecked(e.Node)) e.Node.Checked = false;
                TvFoldersSelect.SetCheckAllChildNodes(e.Node, false);
            }

        }

		#endregion (------  Event Handlers  ------)

		#region (------  Private Methods  ------)

        private void AddSelectedFoldersToArchiveQueue()
        {
            Logger.Log();
            foreach (TreeNode node in TvFoldersSelect.CheckedTreeNodes)
            {
                node.Checked=false;
                node.BackColor = Color.Gray;
                if (!_archiveQueue.Exists(node.FullPath))
                {
                    Logger.LogDebug("Adding folder: {0}", node.FullPath);
                    _archiveQueue.Enqueue(node.FullPath);
                    listViewExtArchiveQueue.Items.Add(new ListViewItem(new[] { (listViewExtArchiveQueue.Items.Count + 1).ToString(), node.FullPath, ITEM_STATE_QUEUED }));
                }
                else
                {
                    //Folder already exists in queue
                    MessageBox.Show("Folder: "+node.FullPath+" already exists in archiving queue", "", MessageBoxButtons.OK);
                }
            }
        }

        private void ArchiveDirectory(string directory)
        {
            if (!Directory.Exists(TempPath)) Directory.CreateDirectory(TempPath);
            string destFilename = TempPath + DateTime.Now.Ticks + "_" + Path.GetFileName(directory) + ".zip";
            Logger.LogDebug("Directory to archive: {0} to: {1}", directory,destFilename);
            anignoZipForgeControlMain.SourceDirectory = directory;
            anignoZipForgeControlMain.DestinationFile = destFilename;
            anignoZipForgeControlMain.VolumeSizeMax = (long)(_data.MaximumAttachmentSizeMb * 1024 * 1024);
            anignoZipForgeControlMain.Password = _data.ArchivesPassword;
            _archiveQueue.EnablePeriodicEvent = false;
            anignoZipForgeControlMain.Start();
        }

        private void EnqueueAllArchivedFilesToSender(string filenameBase)
        {
            string path = Path.GetDirectoryName(filenameBase);
            string filename=Path.GetFileNameWithoutExtension(filenameBase);
            DirectoryInfo di=new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles(filename + ".*");
            foreach (FileInfo fi in files)
            {
                _senderQueue.Enqueue(fi.FullName);
                ListViewItem item=new ListViewItem(new []{fi.FullName,(fi.Length/1024)+"kb"});
                ListViewInvokationHelper.ListView_ItemAdd_Invoked(listViewExtSender, InvokationTypeEnum.Synch, item, false);
            }
        }

        private string GetCalcAverageForMega(float maxUploadKb)
        {
            return (1024f/(maxUploadKb)).ToString("#.00") + " sec";
        }

        private void LoadSettings()
        {
            textBoxValidatedEmail.Text = _data.SenderGmailAddress;
            textBoxGmailPassword.Text = _data.SenderGmailPassword;
            TextBoxsArchivesPassword.Password = _data.ArchivesPassword;
            numericUpDownMaximumAttachmentSizeMb.Value = _data.MaximumAttachmentSizeMb;
            numericUpDownUploadSpeed.Value = _data.UploadSpeedKps;
            textBoxEmailSubjectPrefix.Text = _data.EmailSubjectPrefix;
            labelAverageForMega.Text = GetCalcAverageForMega((float) _data.UploadSpeedKps);
        }

        private void SetProgressBarDisplayDataInvoked(int value, int maximum, bool timerEnabled)
        {
            if (anignoProgressBarAutoIncreamentTimeout.InvokeRequired)
            {
                anignoProgressBarAutoIncreamentTimeout.Invoke(new SetProgressBarDisplayDataDelegate(SetProgressBarDisplayDataInvoked), value,maximum,timerEnabled);
            }
            else
            {
                anignoProgressBarAutoIncreamentTimeout.Value = value;
                anignoProgressBarAutoIncreamentTimeout.Maximum = maximum;
                anignoProgressBarAutoIncreamentTimeout.MaximumRange = maximum;
                anignoProgressBarAutoIncreamentTimeout.TimerEnabled = timerEnabled;
                anignoProgressBarAutoIncreamentTimeout.Text = (value / 60) + ":" + (value % 60).ToString("00");
            }
        }

		#endregion (------  Private Methods  ------)
    }
}