using System;
using System.Data;

namespace FinanceAnalizer2.DAL
{
    public class DalResult
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public DataTable Table { get; set; }

        public DalResult()
        {
            IsSucceeded = true;
        }

        public DalResult(bool isSucceeded, string message)
        {
            IsSucceeded = isSucceeded;
            Message = message;
        }

        public DalResult(bool isSucceeded, string message, DataTable table)
            : this(isSucceeded, message)
        {
            Table = table;
        }

        public DalResult(Exception ex)
        {
            IsSucceeded = false;
            Message = ex.Message;
        }
    }
}