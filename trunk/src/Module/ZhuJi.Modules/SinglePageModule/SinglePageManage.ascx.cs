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

namespace ZhuJi.Modules.SinglePageModule.WebUI
{
    public partial class SinglePageManage : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ChannelId.Text = Request.QueryString["ChannelId"];
                if (string.IsNullOrEmpty(ChannelId.Text))
                {
                    SinglePageEdit1.Identity = 0;
                    SinglePageEdit1.Initialize();
                }
                else
                {
                    SinglePageEdit1.Identity = int.Parse(ChannelId.Text);
                    SinglePageEdit1.Initialize();
                }
            }
        }

        /// <summary>
        /// 点击刷新按钮
        /// </summary>
        protected void btnFlush_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString(),true);
        }
    }
}

