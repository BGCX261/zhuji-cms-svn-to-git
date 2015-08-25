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

namespace ZhuJi.Log.WebUI
{
    public partial class LoggingList : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["PageNo"]))
                {
                    base.PageNo = Convert.ToInt32(Request["PageNo"]);
                }

                List();
            }
        }

        /// <summary>
        /// 初始化查询列表
        /// </summary>
        public void List()
        {
            try
            {
                ZhuJi.Log.IDAL.ILogging logging = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Log.NHibernateDAL.Logging)) as ZhuJi.Log.IDAL.ILogging;
                rptList.DataSource = logging.GetObjects(base.Where, base.OrderNo, base.PageNo, base.PageSize);
                rptList.DataBind();
                if (base.IsShowPager)
                {
                    simplePager.Visible = true;
                    simplePager.CurrentPage = base.PageNo;
                    simplePager.PageSize = base.PageSize;
                    simplePager.PageUrl = Request.Url.ToString();
                    simplePager.RecordCount = logging.GetRowCount;
                    simplePager.DataBind();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
        }
    }
}

