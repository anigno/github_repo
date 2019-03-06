using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LoggingProvider;
using System.Threading;

namespace LogViewer.Managment
{
    public class LogViewerManager
    {

		#region (------  Fields  ------)


        private string _currentLogPath = string.Empty;
  //used log path
        private string _currentPrefix = string.Empty;
   //used prefix
        private string _requestedPrefix = string.Empty;
        private string _currentPageFile = string.Empty;

 //When not active, used to set prefix
        private bool _active = false;
        private int _pagesLoaded = 0;
        private int _currentPageErrors = 0;
        private int _currentPageWarnings = 0;

        private DateTime _currentPageStartTime = default(DateTime);
        private LogViewerConfig _config = null;
        private long _currentPageFileLengthRead = 0;
        private object _syncRoot = new object();
        private System.Windows.Forms.Timer _uiTimer = null;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public LogViewerManager(System.Windows.Forms.Timer uiTimer)
        {
            _uiTimer = uiTimer;
            _uiTimer.Interval = Common.DEFAULT_LOG_VIEWER_TIMER_INTERVAL;
            _uiTimer.Tick += uiTimer_Tick;
            _uiTimer.Start();
        }

		#endregion (------  Constructors  ------)

		#region (------  Read only Properties  ------)

        public LogViewerConfig Config
        {
            get { return _config; }
        }

		#endregion (------  Read only Properties  ------)

		#region (------  Properties  ------)


        public int ReadInterval
        {
            get
            {
                return _uiTimer.Interval;
            }
            set
            {
                _uiTimer.Interval = value;
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Events  ------)

        public event OnLoadOldPageDelegate OnLoadOldPage;

        public event OnNewLogMessagesReadDelegate OnNewLogMessagesRead;

        public event OnNewRunDetectedDelegate OnNewRunDetected;

        public event OnPageChangedDelegate OnPageChanged;

		#endregion (------  Events  ------)

		#region (------  Delegates  ------)

        public delegate void OnLoadOldPageDelegate(string pageFile, int errors, int warnings, DateTime startTime, DateTime endTime);
        public delegate void OnNewLogMessagesReadDelegate(string pageFile, LogMessage[] newLogMessages, DateTime startTime, DateTime endTime, int totalErrors, int totalWarnings);
        public delegate void OnNewRunDetectedDelegate(string exeFile);
        public delegate void OnPageChangedDelegate();

		#endregion (------  Delegates  ------)

		#region (------  Event Handlers  ------)

        private void uiTimer_Tick(object sender, EventArgs e)
        {
            _uiTimer.Stop();
            if (_active)
            {
                if (Directory.Exists(_currentLogPath))
                {
                    string newestLogPageFilePath = FileHelper.GetNewestFirstPage(_currentLogPath);
                    if (newestLogPageFilePath != null)
                    {
                        string newestLogPageFile = Path.GetFileName(newestLogPageFilePath);
                        _requestedPrefix = FileHelper.GetPrefix(newestLogPageFile);
                    }
                }
            }
            //Checks if prefix changed for new run
            if (_requestedPrefix != _currentPrefix)
            {
                _currentPrefix = _requestedPrefix;
                _currentPageFileLengthRead = 0;
                _pagesLoaded = 0;
                _currentPageWarnings = 0;
                _currentPageErrors = 0;
                _currentPageStartTime = default(DateTime);
                if (OnNewRunDetected != null) OnNewRunDetected(_currentPageFile);
            }
            if (Directory.Exists(_currentLogPath) && _currentPrefix != string.Empty)
            {
                //Get all pages for _currentPrefix
                string[] pages = Directory.GetFiles(_currentLogPath, _currentPrefix + "*", SearchOption.TopDirectoryOnly);
                //****** Read old pages
                for (int a = _pagesLoaded; a < pages.Length - 1; a++)
                {
                    TextReader tr = new StreamReader(pages[a]);
                    int errors = 0;
                    int warnings = 0;
                    bool startTimeSet = false;
                    DateTime pageStartTime = DateTime.Now;
                    DateTime pageEndTime = new DateTime();
                    LogMessage message = null;
                    while (tr.Peek() >= 0)
                    {
                        string messageString = tr.ReadLine();
                        message = LogMessage.FromString(messageString);
                        if (!startTimeSet)
                        {
                            pageStartTime = message.Time;
                            startTimeSet = true;
                        }
                        if (message.Severity == SeverityEnum.ERROR) errors++;
                        if (message.Severity == SeverityEnum.WARN) warnings++;
                    }
                    //Set last log message time to page end time
                    if (message != null) pageEndTime = message.Time;
                    tr.Close();
                    if (OnLoadOldPage != null) OnLoadOldPage(pages[a], errors, warnings, pageStartTime, pageEndTime);
                }
                _pagesLoaded = pages.Length - 1;



                //****** Read last page
                string lastPageFile = pages[pages.Length - 1];
                if (lastPageFile != _currentPageFile)
                {
                    _currentPageFile = lastPageFile;
                    _currentPageFileLengthRead = 0;
                    _currentPageWarnings = 0;
                    _currentPageErrors = 0;
                    _currentPageStartTime = default(DateTime);
                    if (OnPageChanged != null) OnPageChanged();
                }
                FileInfo fi = new FileInfo(lastPageFile);
                long lastPageFileLength = fi.Length;
                //Check if there are messages unread
                if (lastPageFileLength != _currentPageFileLengthRead)
                {
                    TextReader tr = null;
                    List<LogMessage> messages = new List<LogMessage>();
                    try
                    {
                        tr = new StreamReader(_currentPageFile, Encoding.GetEncoding("windows-1255"));
                        //skip _currentPageFileLengthRead chars
                        tr.ReadBlock(new char[_currentPageFileLengthRead], 0, (int)_currentPageFileLengthRead);
                        _currentPageFileLengthRead = lastPageFileLength;
                        LogMessage message = null;
                        DateTime pageEndTime = new DateTime();
                        while (tr.Peek() >= 0)
                        {
                            string messageString = tr.ReadLine();
                            //Console.WriteLine(messageString);
                            message = LogMessage.FromString(messageString);
                            if (message.Severity == SeverityEnum.ERROR) _currentPageErrors++;
                            if (message.Severity == SeverityEnum.WARN) _currentPageWarnings++;
                            if (_currentPageFileLengthRead == 0)
                            {
                                _currentPageStartTime = message.Time;
                            }
                            messages.Add(message);
                        }
                        if (message != null) pageEndTime = message.Time;
                        if (OnNewLogMessagesRead != null) OnNewLogMessagesRead(_currentPageFile, messages.ToArray(), _currentPageStartTime, pageEndTime, _currentPageErrors, _currentPageWarnings);
                    }
                    catch (Exception ex)
                    {
                        Thread.Sleep(Common.DEFAULT_LOG_VIEWER_TIMER_INTERVAL / 3);
                        LogMessage messageError=new LogMessage();
                        messageError.Time = DateTime.Now;
                        messageError.Text = "Internal logger error, " + ex.Message;
                        messages.Add(messageError);
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (tr != null) tr.Close();
                    }
                }
            }

            if(_active)_uiTimer.Start();
        }






        public static StreamReader GetNewStreamReader(string p_filename)
        {
            if (p_filename == null) return null;

            FileStream fileStream = new FileStream(p_filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream);
            return streamReader;
        }


      








		#endregion (------  Event Handlers  ------)

		#region (------  Public Methods  ------)

        public void LoadConfig()
        {
            lock (_syncRoot){
                _config = FileHelper.LoadConfig(Environment.CurrentDirectory + "\\" + Common.CONFIG_FILE_NAME_POSTFIX);
        }
    }

        public void SaveConfig()
        {
            lock (_syncRoot)
            {
                FileHelper.SaveConfig(Environment.CurrentDirectory + "\\" + Common.CONFIG_FILE_NAME_POSTFIX, _config);
            }
        }

        /// <summary>
        /// Sets real time logging for running process
        /// </summary>
        /// <param name="active"></param>
        public void SetActive(bool active)
        {
            _active = active;
            if(_active)_uiTimer.Start();
        }

        public void SetCurrentPageFile(string pageFile)
        {
            _currentLogPath = Path.GetDirectoryName(pageFile);
            _requestedPrefix = FileHelper.GetPrefix(Path.GetFileName(pageFile));

            //int a = _currentLogPath.LastIndexOf("\\");
            //_exeFilePath = _currentLogPath.Substring(0, a);
        }

        public void SetExeFile(string exeFilePath)
        {
            //_currentLogPath = Path.GetDirectoryName(exeFilePath) + "\\Log";
            _currentLogPath = Path.GetDirectoryName(exeFilePath) + "\\_Logs";
        }

		#endregion (------  Public Methods  ------)

    }
}