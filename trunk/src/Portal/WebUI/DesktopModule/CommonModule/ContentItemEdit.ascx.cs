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

namespace ZhuJi.Portal.WebUI.DesktopModule.CommonModule
{
    public partial class ContentItemEdit : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化添加/编辑表单
        /// </summary>
        public void Initialize()
        {
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDel.Visible = false;

            switch (_command)
            {
                case "ADD":
                    Add();
                    break;
                case "EDIT":
                    Edit();
                    break;
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

        private string _command;
        /// <summary>
        /// 添加/编辑键
        /// </summary>
        public string Command
        {
            set { _command = value; }
            get { return _command; }
        }

        /// <summary>
        /// 初始化添加表单
        /// </summary>
        private void Add()
        {
            btnAdd.Visible = true;
        }

        /// <summary>
        /// 初始化编辑表单
        /// </summary>
        private void Edit()
        {
			btnAdd.Visible = true;
			btnAdd.Text = "另存为新记录";
            btnEdit.Visible = true;
            btnDel.Visible = true;
            try
            {
                ZhuJi.Portal.IDAL.IContentItem contentItem = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.ContentItem)) as ZhuJi.Portal.IDAL.IContentItem;
                ZhuJi.Portal.Domain.ContentItem domainContentItem = contentItem.GetObject(_identity);
                UIMapping.BindObjectToControls(domainContentItem, this);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
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
                    ZhuJi.Portal.Domain.ContentItem domainContentItem = new ZhuJi.Portal.Domain.ContentItem();
                    UIMapping.BindControlsToObject(domainContentItem, this);

                    ZhuJi.Portal.IDAL.IContentItem contentItem = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.ContentItem)) as ZhuJi.Portal.IDAL.IContentItem;
                    contentItem.Insert(domainContentItem);

					_identity = domainContentItem.Id;
					Edit();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex);
                }
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
                    ZhuJi.Portal.Domain.ContentItem domainContentItem = new ZhuJi.Portal.Domain.ContentItem();
                    UIMapping.BindControlsToObject(domainContentItem, this);

                    ZhuJi.Portal.IDAL.IContentItem contentItem = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.ContentItem)) as ZhuJi.Portal.IDAL.IContentItem;
                    contentItem.Update(domainContentItem);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex);
                }
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
                ZhuJi.Portal.Domain.ContentItem domainContentItem = new ZhuJi.Portal.Domain.ContentItem();

                domainContentItem.Id = int.Parse(Id.Text);

                ZhuJi.Portal.IDAL.IContentItem contentItem = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.ContentItem)) as ZhuJi.Portal.IDAL.IContentItem;
                contentItem.Delete(domainContentItem);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
            Response.Redirect(Request.Url.ToString(), true);
        }
    }
}

