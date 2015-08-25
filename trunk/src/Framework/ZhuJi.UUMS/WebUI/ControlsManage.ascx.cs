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

namespace ZhuJi.UUMS.WebUI
{
    public partial class ControlsManage : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //初始化显示列表表单
                pnlList.Visible = true;
                ControlsList1.IsShowPager = true;
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
            Response.Redirect(Request.Url.ToString());
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
            ControlsEdit1.Command = "ADD";
            ControlsEdit1.Initialize();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Repeater list = (Repeater)ControlsList1.FindControl("rptList");
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
            ControlsEdit1.Identity = int.Parse(id);
            ControlsEdit1.Command = "EDIT";
            ControlsEdit1.Initialize();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            Repeater list = (Repeater)ControlsList1.FindControl("rptList");
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
                ZhuJi.UUMS.Domain.Controls domainControls = new ZhuJi.UUMS.Domain.Controls();

                domainControls.Id = int.Parse(id);

                ZhuJi.UUMS.IDAL.IControls controls = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Controls)) as ZhuJi.UUMS.IDAL.IControls;
                controls.Delete(domainControls);

                Response.Redirect(Request.Url.ToString(), true);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }

        }
    }
}

