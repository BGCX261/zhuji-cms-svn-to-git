using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Provider;

namespace ZhuJi.Portal.WebUI.Core
{
    public class NHSiteMapProvider : StaticSiteMapProvider
    {
        // 节点
        private SiteMapNode _node;

        // 节点字典表
        private Dictionary<int, SiteMapNode> _nodes = new Dictionary<int, SiteMapNode>();

        // 用于单例模式
        private readonly object _lock = new object();

        /// <summary>
        /// 从持久性存储区加载站点地图信息，并在内存中构建它。
        /// </summary>
        /// <returns>站点地图导航结构的根 SiteMapNode</returns>
        public override SiteMapNode BuildSiteMap()
        {
            lock (_lock)
            {
                // 单例模式的实现
                if (_node != null)
                {
                    return _node;
                }

                try
                {
                    ZhuJi.Portal.IDAL.IChannel channel = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Channel)) as ZhuJi.Portal.IDAL.IChannel;

                    IList<ZhuJi.Portal.Domain.Channel> list = channel.GetObjects("from Channel");

                    if (list.Count > 0)
                    {
                        // 把第一条记录作为根节点添加
						_node = new SiteMapNode(this, "0", "/", "首页", "首页");
						_nodes.Add(0, _node);
                        AddNode(_node, null);

                        // 构造节点树
                        for (int i = 0; i < list.Count; i++)
                        {
                            // 在站点地图中增加一个节点
                            SiteMapNode node = CreateSiteMapNode(list[i]);
                            AddNode(node, GetParentNode(list[i]));
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw (ex);
                }

                // 返回SiteMapNode
                return _node;
            }
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            lock (_lock)
            {
                return BuildSiteMap();
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="config">config</param>
        public override void Initialize(string name, NameValueCollection config)
        {
            // 验证是否有config
            if (config == null)
                throw new ArgumentNullException("config不能是null");

            // 没有provider则设置为默认的
            if (string.IsNullOrEmpty(name))
                name = "NHSiteMapProvider";

            // 没有描述就增加一个描述
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NHSiteMapProvider");
            }

            // 调用基类的初始化方法
            base.Initialize(name, config);
        }

        private SiteMapNode CreateSiteMapNode(ZhuJi.Portal.Domain.Channel domainChannel)
        {
            int id = domainChannel.Id;

            if (_nodes.ContainsKey(id))
                throw new ProviderException("不能有重复ID");

            string title = domainChannel.Title;
			string url = domainChannel.SiteInfo.Url+string.Format(domainChannel.Url.ToString(), domainChannel.Id.ToString());
            string description = domainChannel.Remarks;
            string target = domainChannel.Target;

            // 新建一个SiteMapNode
            SiteMapNode node;

            if (target.Length == 0)
            {
                node = new SiteMapNode(this, id.ToString(), url, title, description);
            }
            else
            {
                NameValueCollection attributes = new NameValueCollection();
                attributes.Add("target", target);

                node = new SiteMapNode(this, id.ToString(), url, title, description, null, attributes, null, null);
            }

            // 把这个SiteMapNode添加进节点字典表里
            _nodes.Add(id, node);

            // 返回这个SiteMapNode
            return node;
        }

        private SiteMapNode GetParentNode(ZhuJi.Portal.Domain.Channel domainChannel)
        {
            int pid = domainChannel.Parent;
            if (!_nodes.ContainsKey(pid))
            {
                throw new ProviderException("有重复节点ID");
            }

            // 返回父节点的SiteMapNode
            return _nodes[pid];
        }


    }
}
