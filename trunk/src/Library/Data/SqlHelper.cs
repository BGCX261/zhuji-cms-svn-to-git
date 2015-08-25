using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace ZhuJi.Library.Data
{
    /// <summary>
    /// SQL数据库数据库常用操作功能类
    /// </summary>
    public class SqlHelper : DBHepler
    {
        #region ExecuteNonQuery

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        public override int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms)
        {
            return ExecuteNonQuery(connectionString, cmdType, cmdText, (SqlParameter[]) cmdParms);
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText,
                                          params SqlParameter[] cmdParms)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        public override int ExecuteNonQuery(DbConnection conn, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms)
        {
            return ExecuteNonQuery((SqlConnection) conn, cmdType, cmdText, (SqlParameter[]) cmdParms);
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        public static int ExecuteNonQuery(SqlConnection conn, CommandType cmdType, string cmdText,
                                          params SqlParameter[] cmdParms)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="trans">数据库事务对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        public override int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms)
        {
            return ExecuteNonQuery((SqlTransaction) trans, cmdType, cmdText, (SqlParameter[]) cmdParms);
        }

        /// <summary>
        /// 执行一条SQL语句,返回受影响行数
        /// </summary>
        /// <param name="trans">数据库事务对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>受影响行数</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText,
                                          params SqlParameter[] cmdParms)
        {
            if (trans == null)
            {
                throw new ArgumentNullException("trans");
            }

            using (SqlCommand cmd = new SqlCommand())
            {
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        #endregion

        #region ExecuteScalar

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>第一列第一行值</returns>
        public override object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText,
                                             params DbParameter[] cmdParms)
        {
            return ExecuteScalar(connectionString, cmdType, cmdText, (SqlParameter[]) cmdParms);
        }

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>第一列第一行值</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText,
                                           params SqlParameter[] cmdParms)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>第一列第一行值</returns>
        public override object ExecuteScalar(DbConnection conn, CommandType cmdType, string cmdText,
                                             params DbParameter[] cmdParms)
        {
            return ExecuteScalar((SqlConnection) conn, cmdType, cmdText, (SqlParameter[]) cmdParms);
        }

        /// <summary>
        /// 执行一条SQL语句,返回第一列第一行值
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>第一列第一行值</returns>
        public static object ExecuteScalar(SqlConnection conn, CommandType cmdType, string cmdText,
                                           params SqlParameter[] cmdParms)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        #endregion

        #region ExecuteReader

        /// <summary>
        /// 执行一条SQL语句,返回SqlDataReader集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>SqlDataReader集</returns>
        public override IDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText,
                                                  params DbParameter[] cmdParms)
        {
            return ExecuteReader(connectionString, cmdType, cmdText, (SqlParameter[]) cmdParms);
        }

        /// <summary>
        /// 执行一条SQL语句,返回SqlDataReader集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>SqlDataReader集</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText,
                                                  params SqlParameter[] cmdParms)
        {
			SqlCommand cmd = new SqlCommand();
			SqlConnection conn = new SqlConnection(connectionString);

			try
			{
				PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
				SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				cmd.Parameters.Clear();
				return rdr;
			}
			catch
			{
				conn.Close();
				throw;
			}
        }

        #endregion

        #region ExecuteDataSet

        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>DataSet集</returns>
        public override DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText,
                                               string tableName, params DbParameter[] cmdParms)
        {
            return ExecuteDataSet(connectionString, cmdType, cmdText, tableName, (SqlParameter[]) cmdParms);
        }

        /// <summary>
        /// 执行一条SQL语句,返回DataSet集
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="cmdType">CommandText 属性</param>
        /// <param name="cmdText">T-SQL命令</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="cmdParms">Command 的参数</param>
        /// <returns>DataSet集</returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText,
                                             string tableName, params SqlParameter[] cmdParms)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    DataSet ds = new DataSet();
                    ds.Locale = CultureInfo.InvariantCulture;
                    try
                    {
                        PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                        SqlDataAdapter sqlDA = new SqlDataAdapter();
                        sqlDA.SelectCommand = cmd;
                        sqlDA.Fill(ds, tableName);
                    }
                    catch
                    {
                        conn.Close();
                        throw;
                    }
                    return ds;
                }
            }
        }

        ///// <summary>
        ///// 执行一条SQL语句,返回DataSet集
        ///// </summary>
        ///// <param name="conn">数据库连接对象</param>
        ///// <param name="cmd">DbConnection 对象</param>
        ///// <param name="ds">DataSet 对象</param>
        ///// <param name="tableName">数据表</param>
        ///// <returns>DataSet集</returns>
        //public static DataSet ExecuteDataSet(DbConnection conn, DbCommand cmd, DataSet ds, string tableName)
        //{
        //    return ExecuteDataSet((SqlConnection)conn, (SqlCommand)cmd, ds, tableName);
        //}
        ///// <summary>
        ///// 执行一条SQL语句,返回DataSet集
        ///// </summary>
        ///// <param name="conn">数据库连接对象</param>
        ///// <param name="cmd">SqlCommand 对象</param>
        ///// <param name="ds">DataSet 对象</param>
        ///// <param name="tableName">数据表</param>
        ///// <returns>DataSet集</returns>
        //public static DataSet ExecuteDataSet(SqlConnection conn, SqlCommand cmd, DataSet ds, string tableName)
        //{
        //    SqlDataAdapter sqlDA = new SqlDataAdapter();
        //    try
        //    {
        //        PrepareCommand(cmd, conn, null, cmd.CommandType, cmd.CommandText, null);
        //        sqlDA.SelectCommand = cmd;
        //        sqlDA.Fill(ds, tableName);
        //    }
        //    catch
        //    {
        //        conn.Close();
        //        throw;
        //    }
        //    return ds;
        //}

        #endregion

        #region Transaction

        ///// <summary>
        ///// 开始事务
        ///// </summary>
        ///// <param name="conn">DbConnection 对象。</param>
        ///// <returns>DbTransaction事务对象</returns>
        //public override DbTransaction BeginTransaction(DbConnection conn)
        //{
        //    return BeginTransaction((SqlConnection)conn);
        //}
        ///// <summary>
        ///// 开始事务
        ///// </summary>
        ///// <param name="conn">DbConnection 对象。</param>
        ///// <returns>DbTransaction事务对象</returns>
        //public static DbTransaction BeginTransaction(SqlConnection conn)
        //{
        //    SqlTransaction tran = conn.BeginTransaction();
        //    return tran;
        //}

        ///// <summary>
        ///// 从挂起状态回滚事务。
        ///// </summary>
        ///// <param name="tran">DbTransaction事务对象</param>
        //public override void RollbackTransaction(DbTransaction tran)
        //{
        //    RollbackTransaction((SqlTransaction)tran);
        //}
        ///// <summary>
        ///// 从挂起状态回滚事务。
        ///// </summary>
        ///// <param name="tran">DbTransaction事务对象</param>
        //public static void RollbackTransaction(SqlTransaction tran)
        //{
        //    tran.Rollback();
        //}


        ///// <summary>
        ///// 提交数据库事务。
        ///// </summary>
        ///// <param name="tran">DbTransaction事务对象</param>
        //public override void CommitTransaction(DbTransaction tran)
        //{
        //    CommitTransaction((SqlTransaction)tran);
        //}
        ///// <summary>
        ///// 提交数据库事务。
        ///// </summary>
        ///// <param name="tran">DbTransaction事务对象</param>
        //public static void CommitTransaction(SqlTransaction tran)
        //{
        //    tran.Commit();
        //}

        #endregion

        #region Connection

        /// <summary>
        /// 建立数据库连接
        /// </summary>
        /// <returns>DbConnection 对象</returns>
        public override DbConnection CreateConnection()
        {
            return CreateSqlConnection(ConnectionString);
        }

        /// <summary>
        /// 建立数据库连接
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns>SqlConnection 对象</returns>
        public static SqlConnection CreateSqlConnection(string connectionString)
        {
            SqlConnection newConnection = new SqlConnection(connectionString);
            return newConnection;
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns>DbConnection 对象</returns>
        public override DbConnection OpenConnection()
        {
            return OpenSqlConnection(ConnectionString);
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns>SqlConnection 对象</returns>
        public static SqlConnection OpenSqlConnection(string connectionString)
        {
            SqlConnection conn = null;
            try
            {
                conn = CreateSqlConnection(connectionString);
                conn.Open();
            }
            catch
            {
                if (conn != null)
                    conn.Close();

                throw;
            }

            return conn;
        }

        #endregion

        #region Parameters

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] cmdParms)
        {
            parmCache[cacheKey] = cmdParms;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[]) parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter) ((ICloneable) cachedParms[i]).Clone();

            return clonedParms;
        }

        #endregion

        #region PrepareCommand

        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        public static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType,
                                          string cmdText, SqlParameter[] cmdParms)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException("cmd");
            }

            if (conn == null)
            {
                throw new ArgumentNullException("conn");
            }

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #endregion

        #region private

        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        #endregion
    }
}