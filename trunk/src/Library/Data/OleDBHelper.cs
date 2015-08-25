using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Globalization;

namespace ZhuJi.Library.Data
{
    /// <summary>
    /// ֧��OleDbִ�е����ݿⳣ�ò���������
    /// </summary>
    public class OleDBHelper : DBHepler
    {
        #region ExecuteNonQuery

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        public override int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms)
        {
            return ExecuteNonQuery(connectionString, cmdType, cmdText, (OleDbParameter[]) cmdParms);
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText,
                                          params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Dispose();
                return val;
            }
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        public override int ExecuteNonQuery(DbConnection conn, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms)
        {
            return ExecuteNonQuery((OleDbConnection) conn, cmdType, cmdText, (OleDbParameter[]) cmdParms);
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        public static int ExecuteNonQuery(OleDbConnection conn, CommandType cmdType, string cmdText,
                                          params OleDbParameter[] cmdParms)
        {
            OleDbCommand cmd = new OleDbCommand();

            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Dispose();
            return val;
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="trans">���ݿ��������</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        public override int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms)
        {
            return ExecuteNonQuery((OleDbTransaction) trans, cmdType, cmdText, (OleDbParameter[]) cmdParms);
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="trans">���ݿ��������</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        public static int ExecuteNonQuery(OleDbTransaction trans, CommandType cmdType, string cmdText,
                                          params OleDbParameter[] cmdParms)
        {
            if (trans == null)
            {
                throw new ArgumentNullException("trans");
            }

            using (OleDbCommand cmd = new OleDbCommand())
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
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��һ�е�һ��ֵ</returns>
        public override object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText,
                                             params DbParameter[] cmdParms)
        {
            return ExecuteScalar(connectionString, cmdType, cmdText, (OleDbParameter[]) cmdParms);
        }

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��һ�е�һ��ֵ</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText,
                                           params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��һ�е�һ��ֵ</returns>
        public override object ExecuteScalar(DbConnection conn, CommandType cmdType, string cmdText,
                                             params DbParameter[] cmdParms)
        {
            return ExecuteScalar((OleDbConnection) conn, cmdType, cmdText, (OleDbParameter[]) cmdParms);
        }

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��һ�е�һ��ֵ</returns>
        public static object ExecuteScalar(OleDbConnection conn, CommandType cmdType, string cmdText,
                                           params OleDbParameter[] cmdParms)
        {
            using (OleDbCommand cmd = new OleDbCommand())
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
        /// ִ��һ��SQL���,����OleDbDataReader��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>OleDbDataReader��</returns>
        public override IDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText,
                                                  params DbParameter[] cmdParms)
        {
            return ExecuteReader(connectionString, cmdType, cmdText, (OleDbParameter[]) cmdParms);
        }

        /// <summary>
        /// ִ��һ��SQL���,����OleDbDataReader��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>OleDbDataReader��</returns>
        public static OleDbDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText,
                                                    params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                        OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        cmd.Parameters.Clear();
                        return rdr;
                    }
                    catch
                    {
                        conn.Close();
                        throw;
                    }
                }
            }
        }

        #endregion

        #region ExecuteDataSet

        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="tableName">���ݱ���</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>DataSet��</returns>
        public override DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText,
                                               string tableName, params DbParameter[] cmdParms)
        {
            return ExecuteDataSet(connectionString, cmdType, cmdText, tableName, (OleDbParameter[]) cmdParms);
        }

        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="tableName">���ݱ���</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>DataSet��</returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText,
                                             string tableName, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                DataSet ds = new DataSet();
                ds.Locale = CultureInfo.InvariantCulture;
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter sqlDA = new OleDbDataAdapter();
                try
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    sqlDA.SelectCommand = cmd;
                    sqlDA.Fill(ds, tableName);
                }
                catch
                {
                    conn.Close();
                    throw;
                }
                cmd.Dispose();
                return ds;
            }
        }

        #endregion

        #region Transaction

        ///// <summary>
        ///// ��ʼ����
        ///// </summary>
        ///// <param name="conn">DbConnection ����</param>
        ///// <returns>DbTransaction�������</returns>
        //public override DbTransaction BeginTransaction(DbConnection conn)
        //{
        //    return BeginTransaction((OleDbConnection)conn);
        //}
        ///// <summary>
        ///// ��ʼ����
        ///// </summary>
        ///// <param name="conn">DbConnection ����</param>
        ///// <returns>DbTransaction�������</returns>
        //public static DbTransaction BeginTransaction(OleDbConnection conn)
        //{
        //    OleDbTransaction tran = conn.BeginTransaction();
        //    return tran;
        //}

        ///// <summary>
        ///// �ӹ���״̬�ع�����
        ///// </summary>
        ///// <param name="tran">DbTransaction�������</param>
        //public override void RollbackTransaction(DbTransaction tran)
        //{
        //    RollbackTransaction((OleDbTransaction)tran);
        //}
        ///// <summary>
        ///// �ӹ���״̬�ع�����
        ///// </summary>
        ///// <param name="tran">DbTransaction�������</param>
        //public static void RollbackTransaction(OleDbTransaction tran)
        //{
        //    tran.Rollback();
        //}


        ///// <summary>
        ///// �ύ���ݿ�����
        ///// </summary>
        ///// <param name="tran">DbTransaction�������</param>
        //public override void CommitTransaction(DbTransaction tran)
        //{
        //    CommitTransaction((OleDbTransaction)tran);
        //}
        ///// <summary>
        ///// �ύ���ݿ�����
        ///// </summary>
        ///// <param name="tran">DbTransaction�������</param>
        //public static void CommitTransaction(OleDbTransaction tran)
        //{
        //    tran.Commit();
        //}

        #endregion

        #region Connection

        /// <summary>
        /// �������ݿ�����
        /// </summary>
        /// <returns>DbConnection ����</returns>
        public override DbConnection CreateConnection()
        {
            return CreateOleDBConnection(ConnectionString);
        }

        /// <summary>
        /// �������ݿ�����
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <returns>OleDbConnection ����</returns>
        public static OleDbConnection CreateOleDBConnection(string connectionString)
        {
            OleDbConnection newConnection = new OleDbConnection(connectionString);
            return newConnection;
        }

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        /// <returns>DbConnection ����</returns>
        public override DbConnection OpenConnection()
        {
            return OpenOleDBConnection(ConnectionString);
        }

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        /// <returns>OleDbConnection ����</returns>
        public static OleDbConnection OpenOleDBConnection(string connectionString)
        {
            OleDbConnection conn = null;
            try
            {
                conn = CreateOleDBConnection(connectionString);
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
        /// <param name="cmdParms">an array of OleDbParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params OleDbParameter[] cmdParms)
        {
            parmCache[cacheKey] = cmdParms;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached OleDbParamters array</returns>
        public static OleDbParameter[] GetCachedParameters(string cacheKey)
        {
            OleDbParameter[] cachedParms = (OleDbParameter[]) parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (OleDbParameter) ((ICloneable) cachedParms[i]).Clone();

            return clonedParms;
        }

        #endregion

        #region private

        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">OleDbCommand object</param>
        /// <param name="conn">OleDbConnection object</param>
        /// <param name="trans">OleDbTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">OleDbParameters to use in the command</param>
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans,
                                           CommandType cmdType, string cmdText, OleDbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #endregion
    }
}