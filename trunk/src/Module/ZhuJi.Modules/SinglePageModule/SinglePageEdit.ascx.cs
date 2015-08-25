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
using ZhuJi.Library.Globalization;

namespace ZhuJi.Modules.SinglePageModule.WebUI
{
    public partial class SinglePageEdit : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 初始化添加/编辑表单
        /// </summary>
        public void Initialize()
        {
            try
            {
                ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage singlePage = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.SinglePageModule.NHibernateDAL.SinglePage)) as ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage;
                ZhuJi.Modules.SinglePageModule.Domain.SinglePage domainSinglePage = singlePage.GetObjectByChannelId(_identity);
                if (domainSinglePage != null)
                {
                    UIMapping.BindObjectToControls(domainSinglePage, this);
                    UIMapping.BindObjectToControls(domainSinglePage.ContentBaseInfo, this);
                    ContentBaseId.Text = domainSinglePage.ContentBaseInfo.Id.ToString();
                    Id.Text = domainSinglePage.Id.ToString();
					btnAdd.Visible = false;
                    btnEdit.Visible = true;
                    btnDel.Visible = true;
                }
                else
                {
                    btnAdd.Visible = true;
                    btnEdit.Visible = false;
                    btnDel.Visible = false;
                    ChannelId.Text = _identity.ToString();
                    CreatedByIp.Text = GlobalHelper.IP;
                    CreatedByUser.Text = GlobalHelper.User;
                    CreatedByDate.Text = GlobalHelper.Time.ToString();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
        }

        private int _identity;
        /// <summary>
        /// 编号
        /// </summary>
        public int Identity
        {
            set { _identity = value; }
            get { return _identity; }
        }

        /// <summary>
        /// 点击添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    ZhuJi.Modules.SinglePageModule.Domain.SinglePage domainSinglePage = new ZhuJi.Modules.SinglePageModule.Domain.SinglePage();
                    ZhuJi.Modules.Core.Domain.ContentBase domainContentBase = new ZhuJi.Modules.Core.Domain.ContentBase();
                    UIMapping.BindControlsToObject(domainSinglePage, this);
                    UIMapping.BindControlsToObject(domainContentBase, this);
                    domainSinglePage.ContentBaseInfo = domainContentBase;

                    ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage singlePage = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.SinglePageModule.NHibernateDAL.SinglePage)) as ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage;

                    singlePage.Insert(domainSinglePage);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex);
                }
                Response.Redirect(Request.Url.ToString(), true);
            }
        }

        /// <summary>
        /// 点击编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    ZhuJi.Modules.SinglePageModule.Domain.SinglePage domainSinglePage = new ZhuJi.Modules.SinglePageModule.Domain.SinglePage();
                    ZhuJi.Modules.Core.Domain.ContentBase domainContentBase = new ZhuJi.Modules.Core.Domain.ContentBase();
                    UIMapping.BindControlsToObject(domainSinglePage, this);
                    UIMapping.BindControlsToObject(domainContentBase, this);
                    domainContentBase.Id = int.Parse(ContentBaseId.Text.Trim());
                    domainSinglePage.ContentBaseInfo = domainContentBase;

                    ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage singlePage = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.SinglePageModule.NHibernateDAL.SinglePage)) as ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage;

                    singlePage.Update(domainSinglePage);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex);
                }
                Response.Redirect(Request.Url.ToString(), true);
            }
        }

        /// <summary>
        /// 点击删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                ZhuJi.Modules.SinglePageModule.Domain.SinglePage domainSinglePage = new ZhuJi.Modules.SinglePageModule.Domain.SinglePage();
                ZhuJi.Modules.Core.Domain.ContentBase domainContentBase = new ZhuJi.Modules.Core.Domain.ContentBase();
                domainContentBase.Id = int.Parse(ContentBaseId.Text.Trim());
                domainSinglePage.Id = int.Parse(Id.Text);
                domainSinglePage.ContentBaseInfo = domainContentBase;

                ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage singlePage = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.SinglePageModule.NHibernateDAL.SinglePage)) as ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage;

                singlePage.Delete(domainSinglePage);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
            Response.Redirect(Request.Url.ToString(), true);
        }
    }
}

