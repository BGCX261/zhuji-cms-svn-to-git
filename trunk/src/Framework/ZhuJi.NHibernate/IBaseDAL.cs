using System.Collections.Generic;

namespace ZhuJi.NH
{
    /// <summary>
    /// ���ݲ�ӿ�
    /// </summary>
	/// <typeparam name="T">ʵ������</typeparam>
    public interface IBaseDAL<T>
    {
        /// <summary>
        /// ������¼
        /// </summary>
		/// <param name="t">ʵ��</param>
        void Insert(T t);

        /// <summary>
        /// ���¼�¼
        /// </summary>
		/// <param name="t">ʵ��</param>
        void Update(T t);

        /// <summary>
        /// ɾ����¼
        /// </summary>
		/// <param name="t">ʵ��</param>
        void Delete(T t);

		#region ��ȡ��¼����
		/// <summary>
        /// ��ȡ��¼
        /// </summary>
        /// <returns>��¼</returns>
        T GetObject(int id);

        /// <summary>
        /// ��ȡ��¼����
        /// </summary>
        /// <returns>��¼����</returns>
        IList<T> GetObjects();

        /// <summary>
        /// ��ȡ��¼����
        /// </summary>
        /// <param name="hql">��ѯ���</param>
        /// <returns>��¼����</returns>
        IList<T> GetObjects(string hql);

        /// <summary>
        /// ��ȡ��¼����
        /// </summary>
        /// <param name="start">�����׸����󷵻ص�λ��</param>
        /// <param name="max">���÷��ص��������</param>
        /// <returns>��¼����</returns>
        IList<T> GetObjects(int start, int max);

        /// <summary>
        /// ��ȡ��¼����
        /// </summary>
        /// <param name="hql">��ѯ���</param>
        /// <param name="start">�����׸����󷵻ص�λ��</param>
        /// <param name="max">���÷��ص��������</param>
        /// <returns>��¼����</returns>
		IList<T> GetObjects(string hql, int start, int max);

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		/// <param name="where">��ѯ����</param>
		/// <param name="orderBy">����</param>
		/// <returns>��¼����</returns>
		IList<T> GetObjects(string where, string orderBy);

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		/// <param name="where">��ѯ����</param>
		/// <param name="orderBy">����</param>
		/// <param name="pageNo">��ǰҳ��</param>
		/// <param name="pageSize">ҳ��</param>
		/// <returns>��¼����</returns>
		IList<T> GetObjects(string where, string orderBy, int pageNo, int pageSize);
		#endregion

        /// <summary>
		/// ��ȡ��¼������ֻ�з�ҳʱ����ֵ������Ϊ0
        /// </summary>
		int GetRowCount { get;}

		/// <summary>
		/// ��ȡ����
		/// </summary>
		int GetIdentity { get;}
    }
}
