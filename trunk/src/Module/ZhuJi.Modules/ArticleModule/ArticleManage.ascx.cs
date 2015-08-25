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

namespace ZhuJi.Modules.ArticleModule.WebUI
{
    public partial class ArticleManage : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //初始化显示列表表单
                ChannelId.Text = Request.QueryString["ChannelId"];
                pnlList.Visible = true;
                ArticleList1.IsShowPager = true;
                ArticleList1.Where = string.Format("tmp.ContentBaseInfo.ChannelId={0}", ChannelId.Text);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            pnlList.Visible = false;
            pnlEdit.Visible = false;
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDel.Visible = false;
        }

        /// <summary>
        /// 点击刷新按钮
        /// </summary>
        protected void btnFlush_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString(),true);
        }

        /// <summary>
        /// 点击添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Initialize();
            pnlEdit.Visible = true;
            ArticleEdit1.Command = "ADD";
            ArticleEdit1.CId = int.Parse(ChannelId.Text);
            ArticleEdit1.Initialize();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Repeater list = (Repeater)ArticleList1.FindControl("rptList");
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
            Initialize();
            pnlEdit.Visible = true;
            ArticleEdit1.Identity = int.Parse(id);
            ArticleEdit1.Command = "EDIT";
            ArticleEdit1.Initialize();
        }

		protected void btnDel_Click(object sender, EventArgs e)
		{
			Repeater list = (Repeater)ArticleList1.FindControl("rptList");
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
				ZhuJi.Modules.ArticleModule.Domain.Article domainArticle = new ZhuJi.Modules.ArticleModule.Domain.Article();

				domainArticle.Id = int.Parse(id);

				ZhuJi.Modules.ArticleModule.IDAL.IArticle article = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.ArticleModule.NHibernateDAL.Article)) as ZhuJi.Modules.ArticleModule.IDAL.IArticle;
				article.Delete(domainArticle);

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
					ArticleList1.Where = string.Format("tmp.CreatedByDate between {0} and {1}", txtBeginTime.Text.Trim(), txtEndTime.Text.Trim());
				}
				if (txtTitle.Text.Length > 0)
				{
					if (ArticleList1.Where != null && ArticleList1.Where.Length > 0)
					{
						ArticleList1.Where += string.Format(" and tmp.Title like '%{0}%'", txtTitle.Text.Trim());
					}
					else
					{
						ArticleList1.Where = string.Format("tmp.Title like '%{0}%'", txtTitle.Text.Trim());
					}
				}
				ArticleList1.List();
			}
		}
    }
}

