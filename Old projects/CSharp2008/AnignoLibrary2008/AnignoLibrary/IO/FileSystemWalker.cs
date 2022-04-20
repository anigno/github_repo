using System;
using System.IO;
using System.Threading;
using LoggingProvider;

namespace AnignoLibrary.IO
{
    /// <summary>
    /// Asychronous directories and files walker
    /// </summary>
    public class FileSystemWalker
    {

		#region (------  Fields  ------)


        private string mRootPath;

        private Thread mWalkerThread;
        private Thread mMultiWalkerThread;

		#endregion (------  Fields  ------)

		#region (------  Events  ------)

        /// <summary>
        /// Occurs when entering new directory tree
        /// </summary>
        public event FileSystemWalkerDirectoryActionDelegate OnFileSystemWalkerDirectoryEnter;

        /// <summary>
        /// Occurs when leaving a directory to its parent
        /// </summary>
        public event FileSystemWalkerDirectoryActionDelegate OnFileSystemWalkerDirectoryLeave;

        /// <summary>
        /// Occurs when walker has ended all tree from root
        /// </summary>
        public event FileSystemWalkerDirectoryActionDelegate OnFileSystemWalkerEnded;

        /// <summary>
        /// Occurs when walker has ended on multiple roots
        /// </summary>
        public event FileSystemWalkerDirectoriesActionDelegate OnFileSystemWalkerEndedMultiple;

        /// <summary>
        /// Occurs when an exception was thrown during the walking, walking does not end
        /// </summary>
        public event FileSystemWalkerExceptionThrownDelegate OnFileSystemWalkerExceptionThrown;

        /// <summary>
        /// Occurs when new file was found
        /// </summary>
        public event FileSystemWalkerFileActionDelegate OnFileSystemWalkerFileFound;

		#endregion (------  Events  ------)

		#region (------  Delegates  ------)

        public delegate void FileSystemWalkerDirectoriesActionDelegate();
        public delegate void FileSystemWalkerDirectoryActionDelegate(DirectoryInfo dirInfo);
        public delegate void FileSystemWalkerExceptionThrownDelegate(DirectoryInfo dirInfo, Exception ex);
        public delegate void FileSystemWalkerFileActionDelegate(FileInfo fileInfo);

		#endregion (------  Delegates  ------)

		#region (------  Private Methods  ------)

        private void MultiWalkerThreadStart(object objStringArray)
        {
            Logger.Log();
            string[] rootPaths = (string[])objStringArray;
            foreach (string rootPath in rootPaths)
            {
                Logger.LogDebug("Starting {0}",rootPath);
                if (!Directory.Exists(rootPath))
                {
                    throw new Exception(string.Format("Root directory: {0} does not exists", mRootPath));
                }
                StartSync(rootPath);
            }
            if (OnFileSystemWalkerEndedMultiple != null) OnFileSystemWalkerEndedMultiple();
        }

        private void StartSync(string rootPath)
        {
            mRootPath = rootPath;
            WalkerThreadStart();
        }

        private void WalkerRecurse(DirectoryInfo dirInfo)
        {
            //Protect known issue of system folder
            if (dirInfo.Name == "System Volume Information") return;
            try
            {
                if (OnFileSystemWalkerDirectoryEnter != null) OnFileSystemWalkerDirectoryEnter(dirInfo);
                //Handle files
                foreach (FileInfo subFileInfo in dirInfo.GetFiles())
                {
                    if (!subFileInfo.Exists) continue;
                    if (OnFileSystemWalkerFileFound != null) OnFileSystemWalkerFileFound(subFileInfo);
                }
                //handle directories
                foreach (DirectoryInfo subDirInfo in dirInfo.GetDirectories())
                {
                    WalkerRecurse(subDirInfo);
                }
                if (OnFileSystemWalkerDirectoryLeave != null) OnFileSystemWalkerDirectoryLeave(dirInfo);
            }
            catch (Exception ex)
            {
                if (OnFileSystemWalkerExceptionThrown != null) OnFileSystemWalkerExceptionThrown(dirInfo, ex);
                if (OnFileSystemWalkerDirectoryLeave != null) OnFileSystemWalkerDirectoryLeave(dirInfo);
            }
        }

        private void WalkerThreadStart()
        {
            Logger.Log();
            if (!Directory.Exists(mRootPath))
            {
                throw new Exception(string.Format("Root directory: {0} does not exists", mRootPath));
            }
            DirectoryInfo di = new DirectoryInfo(mRootPath);
            WalkerRecurse(di);
            Logger.LogDebug("ended {0}",di.FullName);
            if (OnFileSystemWalkerEnded != null) OnFileSystemWalkerEnded(di);
        }

		#endregion (------  Private Methods  ------)

		#region (------  Public Methods  ------)

        /// <summary>
        /// Starts walking multiple root paths, one after the other
        /// </summary>
        /// <param name="rootPaths"></param>
        public void Start(string[] rootPaths)
        {
            Logger.Log();
            mMultiWalkerThread=new Thread(MultiWalkerThreadStart);
            mMultiWalkerThread.Name = "MultiWalkerThread " + DateTime.Now.Ticks;
            mMultiWalkerThread.Start(rootPaths);
        }

        /// <summary>
        /// Start walking a given root path asychronically
        /// </summary>
        /// <param name="rootPath"></param>
        public void Start(string rootPath)
        {
            Logger.Log();
            mRootPath = rootPath;
            mWalkerThread = new Thread(WalkerThreadStart);
            mWalkerThread.Name = "WalkerThread " + DateTime.Now.Ticks;
            mWalkerThread.Start();
        }

        /// <summary>
        /// Abort walking both multiple and single paths
        /// </summary>
        public void Stop()
        {
            Logger.Log();
            if (mMultiWalkerThread != null) mMultiWalkerThread.Abort();
            if (mWalkerThread != null) mWalkerThread.Abort();
            if (OnFileSystemWalkerEnded != null) OnFileSystemWalkerEnded(new DirectoryInfo(mRootPath));
            if (OnFileSystemWalkerEndedMultiple != null) OnFileSystemWalkerEndedMultiple();
        }

		#endregion (------  Public Methods  ------)

    }

  
}