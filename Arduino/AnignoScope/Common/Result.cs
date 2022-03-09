using System;

namespace Common
{

    #region Enums

    public enum ResultEnum
    {
        None = 0,
        Failed = 1,
        Passed = 2
    }

    #endregion

    public class Result
    {
        #region Constructors

        public Result(ResultEnum p_resultAnswer, string p_description = "", Exception p_exception = null)
        {
            ResultAnswer = p_resultAnswer;
            Description = p_description;
            Exception = p_exception;
        }

        #endregion

        #region Public Properties

        public ResultEnum ResultAnswer { get; private set; }
        public string Description { get; private set; }
        public Exception Exception { get; set; }

        #endregion
    }
}