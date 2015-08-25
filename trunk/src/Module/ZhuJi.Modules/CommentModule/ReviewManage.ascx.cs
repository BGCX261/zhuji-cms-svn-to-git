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

namespace ZhuJi.Modules.CommentModule.WebUI
{
    public partial class ReviewManage : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //初始化显示列表表单
                pnlList.Visible = true;
                ReviewList1.IsShowPager = true;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            pnlList.Visible = false;
            btnDel.Visible = false;
        }

        /// <summary>
        /// 点击刷新按钮
        /// </summary>
        protected void btnFlush_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString(),true);
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            Repeater list = (Repeater)ReviewList1.FindControl("rptList");
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
                ZhuJi.Modules.CommentModule.Domain.Review domainReview = new ZhuJi.Modules.CommentModule.Domain.Review();

                domainReview.Id = int.Parse(id);

                ZhuJi.Modules.CommentModule.IDAL.IReview review = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.CommentModule.NHibernateDAL.Review)) as ZhuJi.Modules.CommentModule.IDAL.IReview;
                review.Delete(domainReview);

                Response.Redirect(Request.Url.ToString(), true);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }

        }

		/// <summary>
		/// 点击搜索
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				if (txtBeginTime.Text.Trim().Length > 0 && txtEndTime.Text.Trim().Length > 0)
				{
					ReviewList1.Where = string.Format("tmp.PostDate between {0} and {1}", txtBeginTime.Text.Trim(), txtEndTime.Text.Trim());
				}
				if (txtTitle.Text.Length > 0)
				{
					if (ReviewList1.Where != null && ReviewList1.Where.Length > 0)
					{
						ReviewList1.Where += string.Format(" and tmp.Title like '%{0}%'", txtTitle.Text.Trim());
					}
					else
					{
						ReviewList1.Where = string.Format("tmp.Title like '%{0}%'", txtTitle.Text.Trim());
					}
				}
				ReviewList1.List();
			}
		}
    }
}

