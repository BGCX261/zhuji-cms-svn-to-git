using System.Collections.Generic;

namespace ZhuJi.NH
{
    /// <summary>
    /// 数据层接口
    /// </summary>
	/// <typeparam name="T">实体类型</typeparam>
    public interface IBaseDAL<T>
    {
        /// <summary>
        /// 新增记录
        /// </summary>
		/// <param name="t">实体</param>
        void Insert(T t);

        /// <summary>
        /// 更新记录
        /// </summary>
		/// <param name="t">实体</param>
        void Update(T t);

        /// <summary>
        /// 删除记录
        /// </summary>
		/// <param name="t">实体</param>
        void Delete(T t);

		#region 获取记录集合
		/// <summary>
        /// 获取记录
        /// </summary>
        /// <returns>记录</returns>
        T GetObject(int id);

        /// <summary>
        /// 获取记录集合
        /// </summary>
        /// <returns>记录集合</returns>
        IList<T> GetObjects();

        /// <summary>
        /// 获取记录集合
        /// </summary>
        /// <param name="hql">查询语句</param>
        /// <returns>记录集合</returns>
        IList<T> GetObjects(string hql);

        /// <summary>
        /// 获取记录集合
        /// </summary>
        /// <param name="start">设置首个对象返回的位置</param>
        /// <param name="max">设置返回的最大结果数</param>
        /// <returns>记录集合</returns>
        IList<T> GetObjects(int start, int max);

        /// <summary>
        /// 获取记录集合
        /// </summary>
        /// <param name="hql">查询语句</param>
        /// <param name="start">设置首个对象返回的位置</param>
        /// <param name="max">设置返回的最大结果数</param>
        /// <returns>记录集合</returns>
		IList<T> GetObjects(string hql, int start, int max);

		/// <summary>
		/// 获取记录集合
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="orderBy">排序</param>
		/// <returns>记录集合</returns>
		IList<T> GetObjects(string where, string orderBy);

		/// <summary>
		/// 获取记录集合
		/// </summary>
		/// <param name="where">查询条件</param>
		/// <param name="orderBy">排序</param>
		/// <param name="pageNo">当前页码</param>
		/// <param name="pageSize">页长</param>
		/// <returns>记录集合</returns>
		IList<T> GetObjects(string where, string orderBy, int pageNo, int pageSize);
		#endregion

        /// <summary>
		/// 获取记录总数，只有分页时有数值，其它为0
        /// </summary>
		int GetRowCount { get;}

		/// <summary>
		/// 获取主键
		/// </summary>
		int GetIdentity { get;}
    }
}
