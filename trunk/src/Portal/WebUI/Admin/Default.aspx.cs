using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ZhuJi.Portal.WebUI.Admin
{
    public partial class Default : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateNodes1(TreeView1.Nodes, 0);
                PopulateNodes2(TreeView2.Nodes, 0);
            }
        }

        private void PopulateNodes1(TreeNodeCollection nodes, int parent)
        {
            ZhuJi.Portal.IDAL.IChannel channel = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Channel)) as ZhuJi.Portal.IDAL.IChannel;
            IList<ZhuJi.Portal.Domain.Channel> list = channel.GetObjects();

            ZhuJi.Portal.Domain.ChannelCollection channels = new ZhuJi.Portal.Domain.ChannelCollection();
            DataTable dt = channels.CreateDateTable(list);

            DataRow[] drs = dt.Select(string.Format("[Parent] = {0}", parent));
            if (drs.Length == 0)
            {
                return;
            }
            else
            {
                foreach (DataRow dr in drs)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = dr["Title"].ToString();
                    tn.Value = dr["Id"].ToString();
                    if (dt.Select(string.Format("[Parent] = {0}", tn.Value)).Length > 0)
                    {
                        tn.PopulateOnDemand = true;
                    }
                    tn.NavigateUrl = string.Format("ContentItem.aspx?ChannelId={0}", dr["Id"]);
                    nodes.Add(tn);
                }
            }

        }

        protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateNodes1(e.Node.ChildNodes, int.Parse(e.Node.Value));
        }

        protected void TreeView2_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateNodes2(e.Node.ChildNodes, int.Parse(e.Node.Value));
        }

        private void PopulateNodes2(TreeNodeCollection nodes, int parent)
        {
            ZhuJi.Portal.IDAL.IPlugin plugin = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Plugin)) as ZhuJi.Portal.IDAL.IPlugin;
            IList<ZhuJi.Portal.Domain.Plugin> list = plugin.GetObjects();

            ZhuJi.Portal.Domain.PluginCollection plugins = new ZhuJi.Portal.Domain.PluginCollection();
            DataTable dt = plugins.CreateDateTable(list);

            DataRow[] drs = dt.Select(string.Format("[Parent] = {0}", parent));
            if (drs.Length == 0)
            {
                return;
            }
            else
            {
                foreach (DataRow dr in drs)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = dr["Title"].ToString();
                    tn.Value = dr["Id"].ToString();
                    if (dt.Select(string.Format("[Parent] = {0}", tn.Value)).Length > 0)
                    {
                        tn.PopulateOnDemand = true;
                    }
                    tn.NavigateUrl = string.Format("AddIn.aspx?PluginId={0}", dr["Id"]);
                    nodes.Add(tn);
                }
            }

        }
    }
}
