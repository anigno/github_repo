namespace Common
{
    public abstract class StartableBase
    {
        #region Public Properties

        public bool IsStarted { get; private set; }

        #endregion

        #region Protected Methods

        protected Result Start()
        {
            if (IsStarted) return new Result(ResultEnum.Failed, "Already Started");
            Result result = StartInit();
            if (result.ResultAnswer == ResultEnum.Passed) IsStarted = true;
            return result;
        }

        protected abstract Result StartInit();

        protected void Stop()
        {
            IsStarted = false;
            StopInit();
        }

        protected abstract void StopInit();

        #endregion
    }
}