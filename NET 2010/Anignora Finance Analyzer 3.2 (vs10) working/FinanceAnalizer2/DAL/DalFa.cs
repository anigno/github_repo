using System;
using System.Data;
using System.Data.OleDb;
using LoggingProvider;
using FinanceAnalizer2.Data;
using System.Collections.Generic;

namespace FinanceAnalizer2.DAL
{
    public class DalFa
    {
        public const string CONNECTION_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"DAL\\FA2DB.mdb\"";
        private static readonly object rootSync = new object();
        private static readonly OleDbConnection connection = new OleDbConnection(CONNECTION_STRING);

        public const string STOCK_NAME_FIELD = "fldStockName";
        public const string STOCK_DATE_FIELD = "fldDate";
        private const string SELECT_STOCK_DATA = "SELECT * FROM tblStocksData WHERE fldStockName='{0}'";
        private const string INSERT_STOCK_NAME = "INSERT INTO tblStocks (fldStockName) VALUES ('{0}')";
        private const string DELETE_STOCK_NAME = "DELETE FROM tblStocks where fldStockName='{0}'";
        private const string INSERT_STOCK_DATA = "INSERT INTO tblStocksData (fldStockName,fldDate,fldOpen,fldHigh,fldLow,fldClose) VALUES ('{0}',{1},{2},{3},{4},{5})";
        private const string DELETE_ALL_STOCK_DATA = "DELETE FROM tblStocksData WHERE fldStockName='{0}'";
        private const string UPDATE_STOCK_DATA = "UPDATE tblStocksData SET fldUpdateTime={0}, fldAnalyzeOne={1}, fldAnalyzeTwo={2}, fldAnalyzeTwoPer={3}, fldIsHit={4}, fldChange={5} WHERE fldStockName='{6}' AND fldDate={7}";
        private const string UPDATE_STOCK_NAME = "UPDATE tblStocks SET fldUpdateTime={0}, fldAnalyzeOne={1}, fldAnalyzeTwo={2}, fldAnalyzeTwoPer={3}";

        public delegate void StockNamesTabelChangedDelegate(string change);
        public static event StockNamesTabelChangedDelegate StockNamesTabelChanged;

        public static void RaiseStockNamesTabelChanged(string stockName)
        {
            if (StockNamesTabelChanged != null) StockNamesTabelChanged(stockName);
        }

        public static DalResult UpdateStockName(string stockName, DateTime updateTime, int analyzeOne, int analyzeTwo, float analyzeTwoPer)
        {
            lock (rootSync)
            {
                OleDbCommand cmd = null;
                try
                {
                    connection.Open();
                    cmd = new OleDbCommand(string.Format(UPDATE_STOCK_NAME, updateTime.ToOADate(), analyzeOne, analyzeTwo, analyzeTwoPer), connection);
                    cmd.Transaction = connection.BeginTransaction();
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    connection.Close();
                    RaiseStockNamesTabelChanged(stockName);
                    return new DalResult();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    cmd.Transaction.Rollback();
                    return new DalResult(ex);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }

        public static DalResult UpdateStockData(string stockName, DateTime date, DateTime updateTime, int analyzeOne, int analyzeTwo, float analyzeTwoPer, bool isHit, float change)
        {
            lock (rootSync)
            {
                OleDbCommand cmd = null;
                try
                {
                    connection.Open();
                    cmd = new OleDbCommand(string.Format(UPDATE_STOCK_DATA, updateTime.ToOADate(), analyzeOne, analyzeTwo, analyzeTwoPer, isHit, change, stockName, date.ToOADate()), connection);
                    cmd.Transaction = connection.BeginTransaction();
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    connection.Close();
                    return new DalResult();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    cmd.Transaction.Rollback();
                    return new DalResult(ex);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }

        public static DalResult DeleteAllStockData(string stockName)
        {
            lock (rootSync)
            {
                OleDbCommand cmd = null;
                try
                {
                    connection.Open();
                    cmd = new OleDbCommand(string.Format(DELETE_ALL_STOCK_DATA, stockName), connection);
                    cmd.Transaction = connection.BeginTransaction();
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    connection.Close();
                    return new DalResult();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    cmd.Transaction.Rollback();
                    return new DalResult(ex);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }


        public static DalResult InsertStockData(string stockName, List<DayChangeData> data)
        {
            lock (rootSync)
            {
                OleDbCommand cmd = null;
                try
                {
                    connection.Open();
                    cmd = new OleDbCommand("", connection);
                    cmd.Transaction = connection.BeginTransaction();

                    foreach (DayChangeData item in data)
                    {
                        cmd.CommandText = string.Format(INSERT_STOCK_DATA, stockName, item.Date.ToOADate(), item.Open, item.High, item.Low, item.Close);
                        cmd.ExecuteNonQuery();
                    }
                    cmd.Transaction.Commit();
                    connection.Close();
                    return new DalResult();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    cmd.Transaction.Rollback();
                    return new DalResult(ex);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }

        public static DalResult InsertStockData(string stockName, DateTime date, float open, float high, float low, float close)
        {
            lock (rootSync)
            {
                OleDbCommand cmd = null;
                try
                {
                    connection.Open();
                    cmd = new OleDbCommand(string.Format(INSERT_STOCK_DATA, stockName, date.ToOADate(), open, high, low, close), connection);
                    cmd.Transaction = connection.BeginTransaction();
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    connection.Close();
                    return new DalResult();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    cmd.Transaction.Rollback();
                    return new DalResult(ex);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }

        private const string SELECT_STOCKS_NAMES_JOIN_BY_NAME = "SELECT DISTINCT  tblStocks.fldStockName,fldDate,fldUpdateTime,fldAnalyzeOne,fldAnalyzeTwo,fldAnalyzeTwoPer FROM tblStocks LEFT JOIN tblStocksData ON tblStocks.fldStockName=tblStocksData.fldStockName ORDER BY tblStocks.fldStockName ASC";
        private const string SELECT_STOCKS_NAMES_JOIN_BY_DATE = "SELECT tblStocks.fldStockName,fldUpdateTime,fldDate FROM tblStocks LEFT JOIN tblStocksData ON tblStocks.fldStockName=tblStocksData.fldStockName ORDER BY fldDate DESC";
        //private const string SELECT_STOCKS_NAMES_JOIN_BY_NAME = "SELECT tblStocks.fldStockName FROM (Select tblStocksData.fldStockName
        public static DateTime GetStockLastUpdated(string stockName)
        {
            return DateTime.MinValue;
        }

        public static DataTable GetStocksNames()
        {
            lock (rootSync)
            {
                try
                {
                    connection.Open();
                    //OleDbDataAdapter a = new OleDbDataAdapter(SELECT_STOCKS_NAMES_JOIN_BY_NAME, connection);
                    //string s = "SELECT MAX(fldDate) from tblStocksData AS MAX_DATE";
                    string s = "select tblStocks.fldStockName, MAX(fldDate) AS LastDate FROM (tblStocks LEFT JOIN tblStocksData ON tblStocks.fldStockName=tblStocksData.fldStockName) Group by tblStocks.fldStockName";
                    OleDbDataAdapter a = new OleDbDataAdapter(s, connection);
                    DataTable ret = new DataTable();
                    a.Fill(ret);
                    return ret;
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    return null;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }

        public static DataTable GetStockData(string stockName)
        {
            lock (rootSync)
            {
                try
                {
                    connection.Open();
                    OleDbDataAdapter a = new OleDbDataAdapter(string.Format(SELECT_STOCK_DATA, stockName), connection);
                    DataTable ret = new DataTable();
                    a.Fill(ret);
                    return ret;
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    return null;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }

        public static DalResult InsertStockName(string stockName)
        {
            lock (rootSync)
            {
                OleDbCommand cmd = null;
                try
                {
                    connection.Open();
                    cmd = new OleDbCommand(string.Format(INSERT_STOCK_NAME, stockName), connection);
                    cmd.Transaction = connection.BeginTransaction();
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    connection.Close();
                    RaiseStockNamesTabelChanged(stockName);
                    return new DalResult();
                }
                catch (OleDbException oleEx)
                {
                    Logger.LogError(oleEx);
                    cmd.Transaction.Rollback();
                    return new DalResult(oleEx);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    return new DalResult(ex);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }

        public static DalResult DeleteStockName(string stockName)
        {
            lock (rootSync)
            {
                OleDbCommand cmd;
                try
                {
                    connection.Open();
                    cmd = new OleDbCommand(string.Format(DELETE_STOCK_NAME, stockName), connection);
                    cmd.Transaction = connection.BeginTransaction();
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    connection.Close();
                    RaiseStockNamesTabelChanged(stockName);
                    return new DalResult();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    return new DalResult(ex);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }


        public static DataTable GetStocksNamesByDate()
        {
            lock (rootSync)
            {
                try
                {
                    connection.Open();
                    OleDbDataAdapter a = new OleDbDataAdapter(string.Format(SELECT_STOCKS_NAMES_JOIN_BY_DATE), connection);
                    DataTable ret = new DataTable();
                    a.Fill(ret);
                    return ret;
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    return null;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }



    }
}