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

namespace ZhuJi.Log.WebUI
{
    public partial class LoggingManage : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //初始化显示列表表单
                pnlList.Visible = true;
                LoggingList1.IsShowPager = true;
            }
        }

        /// <summary>
        /// 点击刷新按钮
        /// </summary>
        protected void btnFlush_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }
        

        protected void btnDel_Click(object sender, EventArgs e)
        {
            Repeater list = (Repeater)LoggingList1.FindControl("rptList");
            string id = UIControlHelper.GetCheckBoxByRepeater(list, "chkId");
            if (id.Length == 0)
            {
                MessageHelper.ShowAndBack(Page, MessageHelper.GetMessage("NOCHECK"));
                return;
            }
            if (id.Split(',').Length > 1)
            {
                MessageHelper.ShowAndBack(Page, MessageHelper.GetMessage("MORECHECK"));
                return;
            }

            try
            {
                ZhuJi.Log.Domain.Logging domainLogging = new ZhuJi.Log.Domain.Logging();

                domainLogging.Id = int.Parse(id);

				ZhuJi.Log.IDAL.ILogging logging = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Log.NHibernateDAL.Logging)) as ZhuJi.Log.IDAL.ILogging;
                logging.Delete(domainLogging);

                Response.Redirect(Request.Url.ToString(), true);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }

        }
    }
}

