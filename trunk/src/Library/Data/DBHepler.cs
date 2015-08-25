using System;
using System.Data;
using System.Data.Common;

namespace ZhuJi.Library.Data
{
    /// <summary>
    /// ���ݿⳣ�ò�����
    /// </summary>
    public abstract class DBHepler : IDBHelper
    {
        #region ExecuteNonQuery

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        public int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(ConnectionString, cmdText);
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        public int ExecuteNonQuery(string connectionString, string cmdText)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, cmdText);
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        public int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, cmdText, null);
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        public abstract int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms);

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        public int ExecuteNonQuery(DbConnection conn, string cmdText)
        {
            return ExecuteNonQuery(conn, CommandType.Text, cmdText);
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        public int ExecuteNonQuery(DbConnection conn, CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(conn, CommandType.Text, cmdText, null);
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        public abstract int ExecuteNonQuery(DbConnection conn, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms);

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="trans">���ݿ��������</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        public int ExecuteNonQuery(DbTransaction trans, string cmdText)
        {
            return ExecuteNonQuery(trans, CommandType.Text, cmdText);
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="trans">���ݿ��������</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        public int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(trans, cmdType, cmdText, null);
        }

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="trans">���ݿ��������</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        public abstract int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText,
                                            params DbParameter[] cmdParms);

        #endregion

        #region ExecuteScalar

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        public object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(ConnectionString, cmdText);
        }

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        public object ExecuteScalar(string connectionString, string cmdText)
        {
            return ExecuteScalar(connectionString, CommandType.Text, cmdText);
        }

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        public object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText)
        {
            return ExecuteScalar(connectionString, cmdType, cmdText, null);
        }

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns></returns>
        public abstract object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText,
                                             params DbParameter[] cmdParms);

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        public object ExecuteScalar(DbConnection conn, string cmdText)
        {
            return ExecuteScalar(conn, CommandType.Text, cmdText);
        }

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        public object ExecuteScalar(DbConnection conn, CommandType cmdType, string cmdText)
        {
            return ExecuteScalar(conn, cmdType, cmdText, null);
        }

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns></returns>
        public abstract object ExecuteScalar(DbConnection conn, CommandType cmdType, string cmdText,
                                             params DbParameter[] cmdParms);

        #endregion

        #region ExecuteReader

        /// <summary>
        /// ִ��һ��SQL���,����IDataReader��
        /// </summary>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string cmdText)
        {
            return ExecuteReader(ConnectionString, cmdText);
        }

        /// <summary>
        /// ִ��һ��SQL���,����IDataReader��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string connectionString, string cmdText)
        {
            return ExecuteReader(connectionString, CommandType.Text, cmdText);
        }

        /// <summary>
        /// ִ��һ��SQL���,����IDataReader��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText)
        {
            return ExecuteReader(connectionString, cmdType, cmdText, null);
        }

        /// <summary>
        /// ִ��һ��SQL���,����IDataReader��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns></returns>
        public abstract IDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText,
                                                  params DbParameter[] cmdParms);

        #endregion

        #region ExecuteDataSet

        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string cmdText)
        {
            return ExecuteDataSet(ConnectionString, cmdText, "Table");
        }

        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="tableName">���ݱ���</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string cmdText, string tableName)
        {
            return ExecuteDataSet(ConnectionString, cmdText, tableName);
        }

        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="tableName">���ݱ���</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string connectionString, string cmdText, string tableName)
        {
            return ExecuteDataSet(connectionString, CommandType.Text, cmdText, tableName);
        }

        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="tableName">���ݱ���</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, string tableName)
        {
            return ExecuteDataSet(connectionString, cmdType, cmdText, tableName, null);
        }


        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="tableName">���ݱ���</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns></returns>
        public abstract DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText,
                                               string tableName, params DbParameter[] cmdParms);

        #endregion

        #region Transaction

        /// <summary>
        /// ��ʼ����
        /// </summary>
        /// <param name="conn">DbConnection ����</param>
        /// <returns>DbTransaction�������</returns>
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
        /// �ӹ���״̬�ع�����
        /// </summary>
        /// <param name="tran">DbTransaction�������</param>
        public void RollbackTransaction(DbTransaction tran)
        {
            if (tran == null)
            {
                throw new ArgumentNullException("tran");
            }

            tran.Rollback();
        }

        /// <summary>
        /// �ύ���ݿ�����
        /// </summary>
        /// <param name="tran">DbTransaction�������</param>
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
        /// �������ݿ�����
        /// </summary>
        /// <returns>DbConnection ����</returns>
        public abstract DbConnection CreateConnection();

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        /// <returns>DbConnection ����</returns>
        public abstract DbConnection OpenConnection();

        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        public string ConnectionString
        {
            set { _connectionString = value; }
            get { return _connectionString; }
        }

        #endregion
    }
}