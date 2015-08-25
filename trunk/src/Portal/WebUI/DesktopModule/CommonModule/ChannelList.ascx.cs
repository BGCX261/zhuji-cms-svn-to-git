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

namespace ZhuJi.Portal.WebUI.DesktopModule.CommonModule
{
    public partial class ChannelList : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateNodes(tvList.Nodes, 0);
            }
        }

        private void PopulateNodes(TreeNodeCollection nodes, int parent)
        {
            try
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
						tn.Text = string.Format("{0}({1})", dr["Title"].ToString(), dr["Id"].ToString());
                        tn.Value = dr["Id"].ToString();
                        if (dt.Select(string.Format("[Parent] = {0}", tn.Value)).Length > 0)
                        {
                            tn.PopulateOnDemand = true;
                        }
                        tn.SelectAction = TreeNodeSelectAction.Expand;
                        nodes.Add(tn);
                    }
                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }

        }

        protected void tvList_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulateNodes(e.Node.ChildNodes, int.Parse(e.Node.Value));
        }
    }
}

