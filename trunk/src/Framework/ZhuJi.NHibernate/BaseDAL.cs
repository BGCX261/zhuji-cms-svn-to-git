using System.Collections.Generic;
using NHibernate;
using System.Text;

namespace ZhuJi.NH
{
	/// <summary>
	/// 数据层基类
	/// </summary>
	/// <typeparam name="T">实体类型</typeparam>
    public class BaseDAL<T> : IBaseDAL<T>
    {
		/// <summary>
		/// 新增记录
		/// </summary>
		/// <param name="t">实体</param>
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
		/// 更新记录
		/// </summary>
		/// <param name="t">实体</param>
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
		/// 删除记录
		/// </summary>
		/// <param name="t">实体</param>
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
		/// 获取记录
		/// </summary>
		/// <param name="id">主键</param>
		/// <returns>记录</returns>
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
		#region 获取记录集合
		/// <summary>
		/// 获取记录集合
		/// </summary>
		/// <returns>记录集合</returns>
		public virtual IList<T> GetObjects()
        {
            string hql = string.Format("From {0} as tmp", typeof(T).Name);
            return GetObjects(hql);
        }

		/// <summary>
		/// 获取记录集合
		/// </summary>
		/// <param name="hql">查询语句</param>
		/// <returns>记录集合</returns>
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
		/// 获取记录集合
		/// </summary>
		/// <param name="start">设置首个对象返回的位置</param>
		/// <param name="max">设置返回的最大结果数</param>
		/// <returns>记录集合</returns>
		public virtual IList<T> GetObjects(int start, int max)
        {
            string hql = string.Format("From {0} as tmp", typeof(T).Name);
            return GetObjects(hql, start, max);
        }

		/// <summary>
		/// 获取记录集合
		/// </summary>
		/// <param name="hql">查询语句</param>
		/// <param name="start">设置首个对象返回的位置</param>
		/// <param name="max">设置返回的最大结果数</param>
		/// <returns>记录集合</returns>
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
		/// 获取记录集合
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="orderBy">排序</param>
		/// <returns>记录集合</returns>
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
		/// 获取记录集合
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="orderBy">排序</param>
		/// <param name="pageNo">当前页码</param>
		/// <param name="pageSize">页长</param>
		/// <returns>记录集合</returns>
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
		/// 获取记录行数，只有分页时有数值，其它为0
		/// </summary>
		public int GetRowCount
        {
            get { return _getRowCount; }
        }

		private int _getIdentity;
		/// <summary>
		/// 获取主键
		/// </summary>
		public int GetIdentity
		{
			get { return _getIdentity; }
		}
    }
}
