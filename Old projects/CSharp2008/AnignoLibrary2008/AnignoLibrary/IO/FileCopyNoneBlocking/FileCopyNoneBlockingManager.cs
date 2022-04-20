using System;
using System.IO;
using System.Threading;
using AnignoLibrary.Helpers;
using LoggingProvider;

namespace AnignoLibrary.IO.FileCopyNoneBlocking
{
    /// <summary>
    /// Copy file without blocking caller, else if caller tries to call copy while already copping. block caller
    /// untill end of previous copy process.
    /// </summary>
    public class FileCopyNoneBlockingManager 
    {
		#region (------------------  Enums  ------------------)
        public enum FileCopyOperationResultEnum
        {
            Succedded,
            Failed,
        }
		#endregion (------------------  Enums  ------------------)


		#region (------------------  Fields  ------------------)
        private readonly AutoResetEvent AR_Copy = new AutoResetEvent(true);
private bool _isAborted;
        private readonly int _bufferSize;
        private long _currentTotalBytes;
        private long _currentCopiedBytes;
        private readonly object _syncRoot=new object();
        private string _currentSourceFile;
        private string _currentDestinationFile;
        private Thread _copyThread;
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public FileCopyNoneBlockingManager(int bufferSize)
        {
            Logger.LogInfo("BufferSize={0}", bufferSize);
            _bufferSize = bufferSize;
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Properties  ------------------)
        public long CurrentTotalBytes
        {
            get
            {
                lock (_syncRoot)
                {
                    return _currentTotalBytes;
                }
            }
            private set
            {
                lock (_syncRoot)
                {
                    _currentTotalBytes = value;
                }
            }
        }

        public long CurrentCopiedBytes
        {
            get
            {
                lock (_syncRoot)
                {
                    return _currentCopiedBytes;
                }
            }
            private set
            {
                lock (_syncRoot)
                {
                    _currentCopiedBytes = value;
                }
            }
        }
		#endregion (------------------  Properties  ------------------)


		#region (------------------  Events  ------------------)
        public event FileCopyNoneBlockingEventHandler OnFileCopyAborted;

        public event FileCopyNoneBlockingEventHandler OnFileCopyEnded;

        public event FileCopyNoneBlockingEventHandler OnFileCopyError;

        public event FileCopyNoneBlockingEventHandler OnFileCopyInProgress;

        public event FileCopyNoneBlockingEventHandler OnFileCopyStarted;
		#endregion (------------------  Events  ------------------)


		#region (------------------  Delegates  ------------------)
        public delegate void FileCopyNoneBlockingEventHandler(string sourceFile, string destinationFile, FileCopyOperationResultEnum result, string message);
		#endregion (------------------  Delegates  ------------------)


		#region (------------------  Private Methods  ------------------)
        private void CopyThreadStart(object o)
        {
            FileInfo fi;
            FileStream fsSource = null;
            FileStream fsDest = null;
            string source = null;
            string dest = null;
            try
            {
                string[] stringArray = (string[])o;
                source = stringArray[0];
                dest = stringArray[1];
                Logger.LogDebug("Starting, source: {0} dest: {0}", source, dest);
                //Create directory if no exists
                string destDirectory = FilesAndFoldersHelper.GetDirectoryNameEx(dest);
                if (!Directory.Exists(destDirectory))
                {
                    Directory.CreateDirectory(destDirectory);
                }
                fi = new FileInfo(source);
                fsSource = new FileStream(source, FileMode.Open);
                fsDest = new FileStream(dest, FileMode.Create);
                RaiseEvent(OnFileCopyStarted, source, dest, FileCopyOperationResultEnum.Succedded, "Bytes to copy: " + CurrentTotalBytes);
                byte[] buffer = new byte[_bufferSize];
                CurrentCopiedBytes = 0;
                CurrentTotalBytes = fi.Length;
                while (CurrentCopiedBytes < CurrentTotalBytes && _isAborted == false)
                {
                    long readSize = buffer.Length;
                    if (fsSource.Position + readSize > CurrentTotalBytes) readSize = CurrentTotalBytes - fsSource.Position;
                    fsSource.Read(buffer, 0, (int)readSize);
                    fsDest.Write(buffer, 0, (int)readSize);
                    CurrentCopiedBytes += readSize;
                    RaiseEvent(OnFileCopyInProgress, source, dest, FileCopyOperationResultEnum.Succedded, "Bytes copied: " + CurrentCopiedBytes);
                }
                fsSource.Close();
                fsDest.Close();
                if (_isAborted)
                {
                    RaiseEvent(OnFileCopyEnded, source, dest, FileCopyOperationResultEnum.Failed, "Aborted");
                    if (File.Exists(_currentDestinationFile))
                    {
                        File.Delete(_currentDestinationFile);
                    }
                    Logger.LogDebug("Aborted, source: {0} dest: {0}", source, dest);
                }
                _isAborted = false;
                File.SetLastWriteTime(dest, File.GetLastWriteTime(source));
                File.SetCreationTime(dest, File.GetCreationTime(source));
                RaiseEvent(OnFileCopyEnded, source, dest, FileCopyOperationResultEnum.Succedded, "Bytes copied: " + CurrentCopiedBytes);
                Logger.LogDebug("Ended, source: {0} dest: {0}", source, dest);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Source: {0} Dest: {0}", source, dest);
                if (fsSource != null) fsSource.Close();
                if (fsDest != null) fsDest.Close();
                RaiseEvent(OnFileCopyError, source, dest, FileCopyOperationResultEnum.Failed, ex.Message);
            }
            finally
            {
                AR_Copy.Set();
            }
        }

        private void RaiseEvent(FileCopyNoneBlockingEventHandler fileCopyEventHandler,string source,string destination,FileCopyOperationResultEnum result,string message)
        {
            if (fileCopyEventHandler != null) fileCopyEventHandler(source, destination, result, message);
        }
		#endregion (------------------  Private Methods  ------------------)


		#region (------------------  Public Methods  ------------------)
        public void Abort()
        {
            lock (_syncRoot)
            {
                Logger.LogWarning("Aborted. Source={0} Dest={1}", _currentSourceFile, _currentDestinationFile);
                _isAborted = true;
                RaiseEvent(OnFileCopyAborted, _currentSourceFile, _currentDestinationFile,FileCopyOperationResultEnum.Failed, "Aborted");
            }
        }

        public void Copy(string source, string dest)
        {
            Logger.LogDebug("Waiting for Copy, Source: {0} Dest: {0}", source, dest);
            AR_Copy.WaitOne();
            AR_Copy.Reset();
            Logger.LogDebug("Starting Copy, Source: {0} Dest: {0}", source, dest);
            _isAborted = false;
            _copyThread = new Thread(CopyThreadStart);
            _copyThread.Name = "CopyThread " + DateTime.Now.Ticks;
            _currentSourceFile = source;
            _currentDestinationFile = dest;
            _copyThread.Start(new[] {source, dest});
        }
		#endregion (------------------  Public Methods  ------------------)
    }
}