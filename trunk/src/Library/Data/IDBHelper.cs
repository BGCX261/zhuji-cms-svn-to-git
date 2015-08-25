using System.Data;
using System.Data.Common;

namespace ZhuJi.Library.Data
{
    /// <summary>
    /// ���ݿⳣ�ò����ӿ���
    /// </summary>
    public interface IDBHelper
    {
        #region ExecuteNonQuery

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        int ExecuteNonQuery(string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        int ExecuteNonQuery(string connectionString, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] cmdParms);

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        int ExecuteNonQuery(DbConnection conn, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        int ExecuteNonQuery(DbConnection conn, CommandType cmdType, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        int ExecuteNonQuery(DbConnection conn, CommandType cmdType, string cmdText, params DbParameter[] cmdParms);

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="trans">���ݿ��������</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        int ExecuteNonQuery(DbTransaction trans, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="trans">���ݿ��������</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns>��Ӱ������</returns>
        int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,������Ӱ������
        /// </summary>
        /// <param name="trans">���ݿ��������</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns>��Ӱ������</returns>
        int ExecuteNonQuery(DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] cmdParms);

        #endregion

        #region ExecuteScalar

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        object ExecuteScalar(string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        object ExecuteScalar(string connectionString, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns></returns>
        object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] cmdParms);

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        object ExecuteScalar(DbConnection conn, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        object ExecuteScalar(DbConnection conn, CommandType cmdType, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,���ص�һ�е�һ��ֵ
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns></returns>
        object ExecuteScalar(DbConnection conn, CommandType cmdType, string cmdText, params DbParameter[] cmdParms);

        #endregion

        #region ExecuteReader

        /// <summary>
        /// ִ��һ��SQL���,����IDataReader��
        /// </summary>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        IDataReader ExecuteReader(string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,����IDataReader��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        IDataReader ExecuteReader(string connectionString, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,����IDataReader��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        IDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,����IDataReader��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns></returns>
        IDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText,
                                  params DbParameter[] cmdParms);

        #endregion

        #region ExecuteDataSet

        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="cmdText">T-SQL����</param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string cmdText);

        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="tableName">���ݱ���</param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string cmdText, string tableName);

        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="tableName">���ݱ���</param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string connectionString, string cmdText, string tableName);

        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="tableName">���ݱ���</param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, string tableName);

        /// <summary>
        /// ִ��һ��SQL���,����DataSet��
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <param name="cmdType">CommandText ����</param>
        /// <param name="cmdText">T-SQL����</param>
        /// <param name="tableName">���ݱ���</param>
        /// <param name="cmdParms">Command �Ĳ���</param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, string tableName,
                               params DbParameter[] cmdParms);

        #endregion

        #region Transaction

        /// <summary>
        /// ��ʼ����
        /// </summary>
        /// <param name="conn">DbConnection ����</param>
        /// <returns>DbTransaction�������</returns>
        DbTransaction BeginTransaction(DbConnection conn);

        /// <summary>
        /// �ӹ���״̬�ع�����
        /// </summary>
        /// <param name="tran">DbTransaction�������</param>
        void RollbackTransaction(DbTransaction tran);

        /// <summary>
        /// �ύ���ݿ�����
        /// </summary>
        /// <param name="tran">DbTransaction�������</param>
        void CommitTransaction(DbTransaction tran);

        #endregion

        #region Connection

        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        string ConnectionString { set; get; }

        /// <summary>
        /// �������ݿ�����
        /// </summary>
        /// <returns>DbConnection ����</returns>
        DbConnection CreateConnection();

        /// <summary>
        /// �����ݿ�����
        /// </summary>
        /// <returns>DbConnection ����</returns>
        DbConnection OpenConnection();

        #endregion
    }
}