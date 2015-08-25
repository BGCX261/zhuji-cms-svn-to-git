using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZhuJi.Library.Web;

namespace ZhuJi.Portal.WebUI.Admin
{
    public partial class ContentItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (ViewState["ChannelId"] != null)
                {
                    ShowControl((int)ViewState["ChannelId"]);
                }
            }
            else
            {
                ViewState["ChannelId"] = int.Parse(RequestHelper.Param("ChannelId"));
                ShowControl((int)ViewState["ChannelId"]);
            }
        }

        private void ShowControl(int id)
        {
            ZhuJi.Portal.IDAL.IChannel channel = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Channel)) as ZhuJi.Portal.IDAL.IChannel;
            ZhuJi.Portal.Domain.Channel domainChannel = channel.GetObject(id);
            if (domainChannel != null)
            {
                Control control = this.LoadControl(domainChannel.ContentItemInfo.Operate);
                phContent.Controls.Add(control);
            }
        }
    }
}
