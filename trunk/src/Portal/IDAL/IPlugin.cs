using System.Collections.Generic;

namespace ZhuJi.Portal.IDAL
{
    /// <summary>
	/// 插件数据层接口
    /// </summary>
    public interface IPlugin : ZhuJi.NH.IBaseDAL<ZhuJi.Portal.Domain.Plugin>
    {
        /// <summary>
        /// 新增插件记录
        /// </summary>
        /// <param name="currentNode">参考节点</param>
        /// <param name="domainPlugin">插件对象</param>
        void Insert(int currentNode, ZhuJi.Portal.Domain.Plugin domainPlugin);

        /// <summary>
        /// 更新插件记录
        /// </summary>
        /// <param name="currentNode">参考节点</param>
        /// <param name="domainPlugin">插件对象</param>
        void Update(int currentNode, ZhuJi.Portal.Domain.Plugin domainPlugin);

        /// <summary>
        /// 获取树型插件记录集合
        /// </summary>
        /// <returns>树型插件记录集合</returns>
        IList<ZhuJi.Portal.Domain.Plugin> TreeNodes();
    }
}