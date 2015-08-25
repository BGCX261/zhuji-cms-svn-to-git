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

namespace ZhuJi.Portal.WebUI.DesktopModule.CommonModule
{
    public partial class ContentItemList : ZhuJi.Portal.WebUI.BaseWebControl
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
                ZhuJi.Portal.IDAL.IContentItem contentItem = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.ContentItem)) as ZhuJi.Portal.IDAL.IContentItem;
                rptList.DataSource = contentItem.GetObjects(base.Where, base.OrderNo, base.PageNo, base.PageSize);
                rptList.DataBind();
                if (base.IsShowPager)
                {
                    simplePager.Visible = true;
                    simplePager.CurrentPage = base.PageNo;
                    simplePager.PageSize = base.PageSize;
                    simplePager.PageUrl = Request.Url.ToString();
                    simplePager.RecordCount = contentItem.GetRowCount;
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

