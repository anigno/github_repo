using System;
using System.Threading;
using System.Threading.Tasks;
using adimus.ertus.Logger;
using AnignoraCommonAndHelpers.Helpers;
using log4net;
using TalentCalc.BL;

namespace TalentCalc
{
    public class ApplicationInitializer
    {
        #region Public Methods

        public void Initialize()
        {
            Logging.InitFromConfigFile();
            s_logger.Info("Application Started");
            EventHalper.RegisterUnhandledExceptionHandlers(onDomainExceptionAction, onThreadExceptionAction, onTaskUnobservedExceptionHandlerAction);
            AppContainer.Instance.Init();
        }

        #endregion

        #region Private Methods

        private void onTaskUnobservedExceptionHandlerAction(UnobservedTaskExceptionEventArgs p_args)
        {
            s_logger.FatalFormat("UnhandledException, TaskUnobservedException, {0}", p_args.Exception.Message);
        }

        private static void onThreadExceptionAction(ThreadExceptionEventArgs p_args)
        {
            s_logger.FatalFormat("UnhandledException, ThreadException, {0}", p_args.Exception.Message);
        }

        private static void onDomainExceptionAction(UnhandledExceptionEventArgs p_args)
        {
            s_logger.FatalFormat("UnhandledException, DomainException, {0}", ((Exception) p_args.ExceptionObject).Message);
        }

        #endregion

        #region Fields

        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
    }
}