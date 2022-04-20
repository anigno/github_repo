using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnignoLibrary.Helpers.InvokationHelpers;
using ComponentAce.Compression.Archiver;
using ComponentAce.Compression.ZipForge;
using System.IO;
using System.Threading;
using LoggingProvider;

namespace AnignoLibrary.UI.Utils
{
    public partial class AnignoZipForgeControl : UserControl
    {
		#region (------  Const Fields  ------)

        const string CATEGORY_STRING = " AnignoZipForgeControl";
        public const long DEFAULT_VOLUME_SIZE_BYTES = 100000000;

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)

        private readonly Brush _brushProgressText;
        private readonly Graphics _progressBarGraphics;
        private Thread _archivingThread;
        private readonly ZipForge _zipForge = new ZipForge();
        private bool _isRunning;

		#endregion (------  Fields  ------)

		#region (------  Events  ------)

        [Category(CATEGORY_STRING)]
        public event AnignoZipForgeEventHandler OnErrorOccured;

        [Category(CATEGORY_STRING)]
        public event AnignoZipForgeEventHandler OnFinishedSuccessfuly;

        [Category(CATEGORY_STRING)]
        public event AnignoZipForgeEventHandler OnProgress;

		#endregion (------  Events  ------)

		#region (------  Delegates  ------)

        public delegate void AnignoZipForgeEventHandler(string progressData);

		#endregion (------  Delegates  ------)

		#region (------  Constructors  ------)

        public AnignoZipForgeControl()
        {
            InitializeComponent();
            _zipForge.OnFileProgress += _zipForge_OnFileProgress;
            _zipForge.SpanningOptions.AdvancedNaming = false;
            _zipForge.SpanningOptions.VolumeSize = VolumeSize.Custom;
            _zipForge.SpanningMode = SpanningMode.Splitting;
            _zipForge.SpanningOptions.FirstVolumeSize = _zipForge.SpanningOptions.CustomVolumeSize = VolumeSizeMax;
            _zipForge.Options.Recurse = true;
            _progressBarGraphics=progressBarTotal.CreateGraphics();
            _brushProgressText = new SolidBrush(base.BackColor);
            VolumeSizeMax = DEFAULT_VOLUME_SIZE_BYTES;
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        [Category(CATEGORY_STRING)]
        public long VolumeSizeMax { get; set; }

        [Category(CATEGORY_STRING)]
        public string DestinationFile { get; set; }

        [Category(CATEGORY_STRING)]
        public string Password { get; set; }

        [Category(CATEGORY_STRING)]
        public string SourceDirectory { get; set; }

        #endregion (------  Properties  ------)

		#region (------  Event Handlers  ------)

        void _zipForge_OnFileProgress(object sender, string fileName, double progress, TimeSpan timeElapsed, TimeSpan timeLeft, ProcessOperation operation, ProgressPhase progressPhase, ref bool cancel)
        {
            try
            {
                if (OnProgress != null) OnProgress(progress.ToString());
                ProgressBarInvokationHelper.SetValue(progressBarTotal, InvokationTypeEnum.Synch, (int)progress);
                ControlInvokationHelper.SetText(labelCurrentFile, InvokationTypeEnum.Synch, fileName);
                string sTimeLeft = ((int)timeLeft.TotalSeconds / 60) + ":" + ((int)timeLeft.TotalSeconds % 60).ToString("00");
                _progressBarGraphics.DrawString(sTimeLeft, Font, _brushProgressText, 0, 0);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                if (OnErrorOccured != null) OnErrorOccured(ex.Message);
            }
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Public Methods  ------)

        public void Abort()
        {
            if (_archivingThread != null && _archivingThread.IsAlive) _archivingThread.Abort();
            _isRunning=false;
        }

        public void Start()
        {
            Logger.LogDebug("Source directory: {0}", SourceDirectory);
            if (_isRunning)
            {
                if (OnErrorOccured != null) OnErrorOccured("Archiver is running, SourceDirectory: " + SourceDirectory);
                return;
            }
            _archivingThread = new Thread(ThreadRunnerThreadStart);
            _archivingThread.Start();
        }

		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)

        private void ThreadRunnerThreadStart()
        {
            try
            {
                Logger.LogDebug("Source directory: {0}",SourceDirectory);
                _isRunning=true;
                _zipForge.SpanningOptions.CustomVolumeSize = VolumeSizeMax;
                _zipForge.SpanningOptions.FirstVolumeSize = VolumeSizeMax;
                _zipForge.FileName = DestinationFile;
                _zipForge.BaseDir = Path.GetDirectoryName(DestinationFile);
                _zipForge.Password = Password;
                _zipForge.OpenArchive(FileMode.Create);
                _zipForge.AddFiles(SourceDirectory);
                _zipForge.CloseArchive();
                if (OnFinishedSuccessfuly != null) OnFinishedSuccessfuly(DestinationFile);
            }
            catch (Exception ex)
            {
                Logger.LogError("Source directory: {0} {1}", SourceDirectory,ex.Message);
                if (OnErrorOccured != null) OnErrorOccured(ex.Message);
            }
            _isRunning = false;
        }

		#endregion (------  Private Methods  ------)
    }
}