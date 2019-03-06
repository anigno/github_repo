using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using adimus.ertus.Logger;
using AnignoraCommonAndHelpers.Helpers;
using AnignoraFinanceAnalyzer5.UI.Forms;
using AnignoraIO;
using log4net;
using log4net.Config;

namespace AnignoraFinanceAnalyzer5
{
    static class Program
    {
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region (------  Private Methods  ------)
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //BlackAndScholes bs=new BlackAndScholes();
            //double calculatePut =  bs.Calculate(BlackAndScholes.CallPutEnum.Put , 127.5d, 127d, 2 / 365d, 0.01d, 0.2297d);
            //double calculateCall = bs.Calculate(BlackAndScholes.CallPutEnum.Call, 127.5d, 127d, 2 / 365d, 0.01d, 0.2297d);
            
            EventHalper.RegisterUnhandledExceptionHandlers(OnDomainExceptionAction,OnThreadExceptionAction, p_args => { });

            Logging.InitFromConfigFile(); 
            s_logger.Info("Application Started");

            //Starting UI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMdi());
        }

        private static void OnThreadExceptionAction(ThreadExceptionEventArgs p_args)
        {
            s_logger.FatalFormat("UnhandledException, ThreadException, {0}", p_args.Exception.Message);
        }

        private static void OnDomainExceptionAction(UnhandledExceptionEventArgs p_args)
        {
            s_logger.FatalFormat("UnhandledException, DomainException, {0}", ((Exception)p_args.ExceptionObject).Message);
        }

        #endregion (------  Private Methods  ------)
    }
}
