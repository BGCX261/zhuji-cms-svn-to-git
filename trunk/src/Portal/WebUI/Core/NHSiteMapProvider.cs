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
        // �ڵ�
        private SiteMapNode _node;

        // �ڵ��ֵ��
        private Dictionary<int, SiteMapNode> _nodes = new Dictionary<int, SiteMapNode>();

        // ���ڵ���ģʽ
        private readonly object _lock = new object();

        /// <summary>
        /// �ӳ־��Դ洢������վ���ͼ��Ϣ�������ڴ��й�������
        /// </summary>
        /// <returns>վ���ͼ�����ṹ�ĸ� SiteMapNode</returns>
        public override SiteMapNode BuildSiteMap()
        {
            lock (_lock)
            {
                // ����ģʽ��ʵ��
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
                        // �ѵ�һ����¼��Ϊ���ڵ����
						_node = new SiteMapNode(this, "0", "/", "��ҳ", "��ҳ");
						_nodes.Add(0, _node);
                        AddNode(_node, null);

                        // ����ڵ���
                        for (int i = 0; i < list.Count; i++)
                        {
                            // ��վ���ͼ������һ���ڵ�
                            SiteMapNode node = CreateSiteMapNode(list[i]);
                            AddNode(node, GetParentNode(list[i]));
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw (ex);
                }

                // ����SiteMapNode
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
        /// ��ʼ��
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="config">config</param>
        public override void Initialize(string name, NameValueCollection config)
        {
            // ��֤�Ƿ���config
            if (config == null)
                throw new ArgumentNullException("config������null");

            // û��provider������ΪĬ�ϵ�
            if (string.IsNullOrEmpty(name))
                name = "NHSiteMapProvider";

            // û������������һ������
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NHSiteMapProvider");
            }

            // ���û���ĳ�ʼ������
            base.Initialize(name, config);
        }

        private SiteMapNode CreateSiteMapNode(ZhuJi.Portal.Domain.Channel domainChannel)
        {
            int id = domainChannel.Id;

            if (_nodes.ContainsKey(id))
                throw new ProviderException("�������ظ�ID");

            string title = domainChannel.Title;
			string url = domainChannel.SiteInfo.Url+string.Format(domainChannel.Url.ToString(), domainChannel.Id.ToString());
            string description = domainChannel.Remarks;
            string target = domainChannel.Target;

            // �½�һ��SiteMapNode
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

            // �����SiteMapNode��ӽ��ڵ��ֵ����
            _nodes.Add(id, node);

            // �������SiteMapNode
            return node;
        }

        private SiteMapNode GetParentNode(ZhuJi.Portal.Domain.Channel domainChannel)
        {
            int pid = domainChannel.Parent;
            if (!_nodes.ContainsKey(pid))
            {
                throw new ProviderException("���ظ��ڵ�ID");
            }

            // ���ظ��ڵ��SiteMapNode
            return _nodes[pid];
        }


    }
}
