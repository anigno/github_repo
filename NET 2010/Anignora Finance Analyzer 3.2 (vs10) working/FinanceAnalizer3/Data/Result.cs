using System;

namespace FinanceAnalizer3.Data
{
    public struct Result
    {
        public const string BAD_UPDATING_DATE = "Bad updating date";

        public bool Succeeded;
        public string Message;

        public Result(bool succeeded,string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public Result(Exception ex)
        {
            Succeeded = false;
            Message = ex.Message;
        }

        public Result(bool succeeded)
        {
            Succeeded = succeeded;
            Message = "";
        }
    }
}
