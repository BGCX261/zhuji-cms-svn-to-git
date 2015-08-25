using System;
using System.Data;
using System.Data.Common;

namespace ZhuJi.Library.Data
{
    /// <summary>
    /// 数据库常用操作类
    /// </summary>
    public abstract class DBHepler : IDBHelper
    {
        #region ExecuteNonQuery

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(ConnectionString, cmdText);
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQuery(string connectionString, string cmdText)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, cmdText);
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, cmdText, null);
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        public abstract int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms);

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQuery(DbConnection conn, string cmdText)
        {
            return ExecuteNonQuery(conn, CommandType.Text, cmdText);
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQuery(DbConnection conn, CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(conn, CommandType.Text, cmdText, null);
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        public abstract int ExecuteNonQuery(DbConnection conn, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms);

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="trans">数据库事务对象</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQuery(DbTransaction trans, string cmdText)
        {
            return ExecuteNonQuery(trans, CommandType.Text, cmdText);
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="trans">数据库事务对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(trans, cmdType, cmdText, null);
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="trans">数据库事务对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        public abstract int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms);

        #endregion

        #region ExecuteScalar

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        public object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(ConnectionString, cmdText);
        }

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        public object ExecuteScalar(string connectionString, string cmdText)
        {
            return ExecuteScalar(connectionString, CommandType.Text, cmdText);
        }

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        public object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText)
        {
            return ExecuteScalar(connectionString, cmdType, cmdText, null);
        }

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns></returns>
        public abstract object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText,
                                             params DbParameter[] cmdParms);

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        public object ExecuteScalar(DbConnection conn, string cmdText)
        {
            return ExecuteScalar(conn, CommandType.Text, cmdText);
        }

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        public object ExecuteScalar(DbConnection conn, CommandType cmdType, string cmdText)
        {
            return ExecuteScalar(conn, cmdType, cmdText, null);
        }

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns></returns>
        public abstract object ExecuteScalar(DbConnection conn, CommandType cmdType, string cmdText,
                                             params DbParameter[] cmdParms);

        #endregion

        #region ExecuteReader

        /// <summary>
        /// 执行一条SQL语句,返回IDataReader集
        /// </summary>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string cmdText)
        {
            return ExecuteReader(ConnectionString, cmdText);
        }

        /// <summary>
        /// 执行一条SQL语句,返回IDataReader集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string connectionString, string cmdText)
        {
            return ExecuteReader(connectionString, CommandType.Text, cmdText);
        }

        /// <summary>
        /// 执行一条SQL语句,返回IDataReader集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText)
        {
            return ExecuteReader(connectionString, cmdType, cmdText, null);
        }

        /// <summary>
        /// 执行一条SQL语句,返回IDataReader集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns></returns>
        public abstract IDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText,
                                                  params DbParameter[] cmdParms);

        #endregion

        #region ExecuteDataSet

        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string cmdText)
        {
            return ExecuteDataSet(ConnectionString, cmdText, "Table");
        }

        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="tableName">数据表名</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string cmdText, string tableName)
        {
            return ExecuteDataSet(ConnectionString, cmdText, tableName);
        }

        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="tableName">数据表名</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string connectionString, string cmdText, string tableName)
        {
            return ExecuteDataSet(connectionString, CommandType.Text, cmdText, tableName);
        }

        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="tableName">数据表名</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, string tableName)
        {
            return ExecuteDataSet(connectionString, cmdType, cmdText, tableName, null);
        }


        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns></returns>
        public abstract DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText,
                                               string tableName, params DbParameter[] cmdParms);

        #endregion

        #region Transaction

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="conn">DbConnection 对象。</param>
        /// <returns>DbTransaction事务对象</returns>
        public DbTransaction BeginTransaction(DbConnection conn)
        {
            if (conn == null)
            {
                throw new ArgumentNullException("conn");
            }

            DbTransaction tran = conn.BeginTransaction();
            return tran;
        }

        /// <summary>
        /// 从挂起状态回滚事务。
        /// </summary>
        /// <param name="tran">DbTransaction事务对象</param>
        public void RollbackTransaction(DbTransaction tran)
        {
            if (tran == null)
            {
                throw new ArgumentNullException("tran");
            }

            tran.Rollback();
        }

        /// <summary>
        /// 提交数据库事务。
        /// </summary>
        /// <param name="tran">DbTransaction事务对象</param>
        public void CommitTransaction(DbTransaction tran)
        {
            if (tran == null)
            {
                throw new ArgumentNullException("tran");
            }

            tran.Commit();
        }

        #endregion

        #region Connection

        private string _connectionString = DBFactory.DBConnectionString;

        /// <summary>
        /// 建立数据库连接
        /// </summary>
        /// <returns>DbConnection 对象</returns>
        public abstract DbConnection CreateConnection();

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns>DbConnection 对象</returns>
        public abstract DbConnection OpenConnection();

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            set { _connectionString = value; }
            get { return _connectionString; }
        }

        #endregion
    }
}