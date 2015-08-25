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

namespace ZhuJi.Modules.VoteModule.WebUI
{
    public partial class VoteSubjectIpManage : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //初始化显示列表表单
                pnlList.Visible = true;
                VoteSubjectIpList1.IsShowPager = true;
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
            Repeater list = (Repeater)VoteSubjectIpList1.FindControl("rptList");
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
                ZhuJi.Modules.VoteModule.Domain.VoteSubjectIp domainVoteSubjectIp = new ZhuJi.Modules.VoteModule.Domain.VoteSubjectIp();

                domainVoteSubjectIp.Id = int.Parse(id);

                ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectIp voteSubjectIp = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteSubjectIp)) as ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectIp;
                voteSubjectIp.Delete(domainVoteSubjectIp);

                Response.Redirect(Request.Url.ToString(), true);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }

        }
    }
}

