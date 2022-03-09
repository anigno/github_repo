using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AnignoraCommonAndHelpers.Helpers;
using Anignora_LogViewer.UI;
using log4net;
using log4net.Config;

namespace Anignora_LogViewer
{
    static class Program
    {
		#region (------  Fields  ------)
        private static readonly ILog s_logger = LogManager.GetLogger(typeof(Program));
		#endregion (------  Fields  ------)

		#region (------  Events Handlers  ------)
        private static void onThreadExceptionAction(ThreadExceptionEventArgs p_args)
        {
            s_logger.FatalFormat("UnhandledException, ThreadException, {0}", p_args.Exception.Message);
        }

        private static void onDomainExceptionAction(UnhandledExceptionEventArgs p_args)
        {
            s_logger.FatalFormat("UnhandledException, DomainException, {0}", ((Exception)p_args.ExceptionObject).Message);
        }
		#endregion (------  Events Handlers  ------)

		#region (------  Public static Methods  ------)
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            EventHalper.RegisterUnhandledExceptionHandlers(onDomainExceptionAction, onThreadExceptionAction);

            //Log4net Using dedicated XML file
            XmlConfigurator.Configure(new FileInfo("AnignoraRollingFileAppender.xml"));
            s_logger.Info("Application Started");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
		#endregion (------  Public static Methods  ------)
    }
}
