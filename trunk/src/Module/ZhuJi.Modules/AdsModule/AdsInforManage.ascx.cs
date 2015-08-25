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

namespace ZhuJi.Modules.AdsModule.WebUI
{
    public partial class AdsInforManage : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //初始化显示列表表单
                pnlList.Visible = true;
                AdsInforList1.IsShowPager = true;
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
            AdsInforEdit1.Command = "ADD";
            AdsInforEdit1.Initialize();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Repeater list = (Repeater)AdsInforList1.FindControl("rptList");
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
            AdsInforEdit1.Identity = int.Parse(id);
            AdsInforEdit1.Command = "EDIT";
            AdsInforEdit1.Initialize();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            Repeater list = (Repeater)AdsInforList1.FindControl("rptList");
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
                ZhuJi.Modules.AdsModule.Domain.AdsInfor domainAdsInfor = new ZhuJi.Modules.AdsModule.Domain.AdsInfor();

                domainAdsInfor.Id = int.Parse(id);

                ZhuJi.Modules.AdsModule.IDAL.IAdsInfor adsInfor = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.AdsModule.NHibernateDAL.AdsInfor)) as ZhuJi.Modules.AdsModule.IDAL.IAdsInfor;
                adsInfor.Delete(domainAdsInfor);

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
				if(txtBeginTime.Text.Trim().Length>0 && txtEndTime.Text.Trim().Length>0)
				{
					AdsInforList1.Where = string.Format("tmp.BeginTime between {0} and {1}", txtBeginTime.Text.Trim(), txtEndTime.Text.Trim());
				}
				if (txtName.Text.Length > 0)
				{
					if (AdsInforList1.Where!=null && AdsInforList1.Where.Length > 0)
					{
						AdsInforList1.Where += string.Format(" and tmp.Name like '%{0}%'", txtName.Text.Trim());
					}
					else
					{
						AdsInforList1.Where = string.Format("tmp.Name like '%{0}%'", txtName.Text.Trim());
					}
				}
				AdsInforList1.List();
			}
		}
    }
}

