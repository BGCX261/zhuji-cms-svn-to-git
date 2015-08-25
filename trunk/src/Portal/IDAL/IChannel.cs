using System.Collections.Generic;

namespace ZhuJi.Portal.IDAL
{
    /// <summary>
	/// 网站栏目数据层接口
    /// </summary>
    public interface IChannel : ZhuJi.NH.IBaseDAL<ZhuJi.Portal.Domain.Channel>
    {
        /// <summary>
        /// 新增栏目记录
        /// </summary>
        /// <param name="currentNode">参考节点</param>
        /// <param name="domainChannel">栏目对象</param>
        void Insert(int currentNode, ZhuJi.Portal.Domain.Channel domainChannel);

        /// <summary>
        /// 更新栏目记录
        /// </summary>
        /// <param name="currentNode">参考节点</param>
        /// <param name="domainChannel">栏目对象</param>
        void Update(int currentNode, ZhuJi.Portal.Domain.Channel domainChannel);

        /// <summary>
        /// 获取树型栏目记录集合
        /// </summary>
        /// <returns>树型栏目记录集合</returns>
        IList<ZhuJi.Portal.Domain.Channel> TreeNodes();
    }
}