using System.Collections.Generic;
using NHibernate;
using System.Text;

namespace ZhuJi.NH
{
	/// <summary>
	/// ���ݲ����
	/// </summary>
	/// <typeparam name="T">ʵ������</typeparam>
    public class BaseDAL<T> : IBaseDAL<T>
    {
		/// <summary>
		/// ������¼
		/// </summary>
		/// <param name="t">ʵ��</param>
		public virtual void Insert(T t)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                session.Save(t);
				_getIdentity = (int)session.GetIdentifier(t);
                session.Flush();

                tx.Commit();
            }
            catch (HibernateException ex)
            {
                if (tx != null) tx.Rollback();
                throw ex;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }

		/// <summary>
		/// ���¼�¼
		/// </summary>
		/// <param name="t">ʵ��</param>
		public virtual void Update(T t)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                session.Update(t);
                session.Flush();

                tx.Commit();
            }
            catch (HibernateException ex)
            {
                if (tx != null) tx.Rollback();
                throw ex;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }

		/// <summary>
		/// ɾ����¼
		/// </summary>
		/// <param name="t">ʵ��</param>
		public virtual void Delete(T t)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                session.Delete(t);
                session.Flush();

                tx.Commit();
            }
            catch (HibernateException ex)
            {
                if (tx != null) tx.Rollback();
                throw ex;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }

		/// <summary>
		/// ��ȡ��¼
		/// </summary>
		/// <param name="id">����</param>
		/// <returns>��¼</returns>
		public virtual T GetObject(int id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                T t = (T)session.Get(typeof(T), id);

                tx.Commit();

                return t;
            }
            catch (HibernateException ex)
            {
                if (tx != null) tx.Rollback();
                throw ex;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
		}
		#region ��ȡ��¼����
		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		/// <returns>��¼����</returns>
		public virtual IList<T> GetObjects()
        {
            string hql = string.Format("From {0} as tmp", typeof(T).Name);
            return GetObjects(hql);
        }

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		/// <param name="hql">��ѯ���</param>
		/// <returns>��¼����</returns>
		public virtual IList<T> GetObjects(string hql)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                IList<T> list = session.CreateQuery(hql).List<T>();

                tx.Commit();

                return list;
            }
            catch (HibernateException ex)
            {
                if (tx != null) tx.Rollback();
                throw ex;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		/// <param name="start">�����׸����󷵻ص�λ��</param>
		/// <param name="max">���÷��ص��������</param>
		/// <returns>��¼����</returns>
		public virtual IList<T> GetObjects(int start, int max)
        {
            string hql = string.Format("From {0} as tmp", typeof(T).Name);
            return GetObjects(hql, start, max);
        }

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		/// <param name="hql">��ѯ���</param>
		/// <param name="start">�����׸����󷵻ص�λ��</param>
		/// <param name="max">���÷��ص��������</param>
		/// <returns>��¼����</returns>
		public virtual IList<T> GetObjects(string hql, int start, int max)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                _getRowCount = session.CreateQuery(hql).List().Count;

                IList<T> list = session.CreateQuery(hql).SetFirstResult(start).SetMaxResults(max).List<T>();
                tx.Commit();

                return list;
            }
            catch (HibernateException ex)
            {
                if (tx != null) tx.Rollback();
                throw ex;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
		}

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		/// <param name="where">��ѯ����</param>
		/// <param name="orderBy">����</param>
		/// <returns>��¼����</returns>
		public virtual IList<T> GetObjects(string where, string orderBy)
		{
			StringBuilder hql = new StringBuilder();
			hql.AppendFormat("from {0} as tmp", typeof(T).Name);
			if (!string.IsNullOrEmpty(where))
			{
				hql.AppendFormat(" where {0}", where);
			}
			if (!string.IsNullOrEmpty(orderBy))
			{
				hql.AppendFormat(" order by {0}", orderBy);
			}

			return GetObjects(hql.ToString());
		}

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		/// <param name="where">��ѯ����</param>
		/// <param name="orderBy">����</param>
		/// <param name="pageNo">��ǰҳ��</param>
		/// <param name="pageSize">ҳ��</param>
		/// <returns>��¼����</returns>
		public virtual IList<T> GetObjects(string where, string orderBy, int pageNo, int pageSize)
		{
			int start = (pageNo - 1) * pageSize;
			int max = pageSize;
			StringBuilder hql = new StringBuilder();
			hql.AppendFormat("from {0} as tmp", typeof(T).Name);
			if (!string.IsNullOrEmpty(where))
			{
				hql.AppendFormat(" where {0}", where);
			}
			if (!string.IsNullOrEmpty(orderBy))
			{
				hql.AppendFormat(" order by {0}", orderBy);
			}

			return GetObjects(hql.ToString(), start, max);
		}
		#endregion

		private int _getRowCount;
		/// <summary>
		/// ��ȡ��¼������ֻ�з�ҳʱ����ֵ������Ϊ0
		/// </summary>
		public int GetRowCount
        {
            get { return _getRowCount; }
        }

		private int _getIdentity;
		/// <summary>
		/// ��ȡ����
		/// </summary>
		public int GetIdentity
		{
			get { return _getIdentity; }
		}
    }
}
