using System.Data;
using System.Data.Common;

namespace ZhuJi.Library.Data
{
    /// <summary>
    /// 数据库常用操作接口类
    /// </summary>
    public interface IDBHelper
    {
        #region ExecuteNonQuery

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        int ExecuteNonQuery(string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        int ExecuteNonQuery(string connectionString, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] cmdParms);

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        int ExecuteNonQuery(DbConnection conn, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        int ExecuteNonQuery(DbConnection conn, CommandType cmdType, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        int ExecuteNonQuery(DbConnection conn, CommandType cmdType, string cmdText, params DbParameter[] cmdParms);

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="trans">数据库事务对象</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        int ExecuteNonQuery(DbTransaction trans, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="trans">数据库事务对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns>受影响行数</returns>
        int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="trans">数据库事务对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] cmdParms);

        #endregion

        #region ExecuteScalar

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        object ExecuteScalar(string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        object ExecuteScalar(string connectionString, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns></returns>
        object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] cmdParms);

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        object ExecuteScalar(DbConnection conn, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        object ExecuteScalar(DbConnection conn, CommandType cmdType, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns></returns>
        object ExecuteScalar(DbConnection conn, CommandType cmdType, string cmdText, params DbParameter[] cmdParms);

        #endregion

        #region ExecuteReader

        /// <summary>
        /// 执行一条SQL语句,返回IDataReader集
        /// </summary>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        IDataReader ExecuteReader(string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回IDataReader集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        IDataReader ExecuteReader(string connectionString, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回IDataReader集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        IDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回IDataReader集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns></returns>
        IDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText,
                                  params DbParameter[] cmdParms);

        #endregion

        #region ExecuteDataSet

        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="cmdText">T-SQL命令</param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string cmdText);

        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="tableName">数据表名</param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string cmdText, string tableName);

        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="tableName">数据表名</param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string connectionString, string cmdText, string tableName);

        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="tableName">数据表名</param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, string tableName);

        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, string tableName,
                               params DbParameter[] cmdParms);

        #endregion

        #region Transaction

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="conn">DbConnection 对象。</param>
        /// <returns>DbTransaction事务对象</returns>
        DbTransaction BeginTransaction(DbConnection conn);

        /// <summary>
        /// 从挂起状态回滚事务。
        /// </summary>
        /// <param name="tran">DbTransaction事务对象</param>
        void RollbackTransaction(DbTransaction tran);

        /// <summary>
        /// 提交数据库事务。
        /// </summary>
        /// <param name="tran">DbTransaction事务对象</param>
        void CommitTransaction(DbTransaction tran);

        #endregion

        #region Connection

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        string ConnectionString { set; get; }

        /// <summary>
        /// 建立数据库连接
        /// </summary>
        /// <returns>DbConnection 对象</returns>
        DbConnection CreateConnection();

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns>DbConnection 对象</returns>
        DbConnection OpenConnection();

        #endregion
    }
}