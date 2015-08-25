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

namespace ZhuJi.Modules.ArticleModule.WebUI
{
    public partial class ArticleEdit : ZhuJi.Portal.WebUI.BaseWebControl
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

        private int _cId;
        /// <summary>
        /// 频道编号
        /// </summary>
        public int CId
        {
            set { _cId = value; }
            get { return _cId; }
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
            ChannelId.Text = _cId.ToString();
            CreatedByIp.Text = GlobalHelper.IP;
            CreatedByUser.Text = GlobalHelper.User;
            CreatedByDate.Text = GlobalHelper.Time.ToString();
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
                ZhuJi.Modules.ArticleModule.IDAL.IArticle article = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.ArticleModule.NHibernateDAL.Article)) as ZhuJi.Modules.ArticleModule.IDAL.IArticle;
                ZhuJi.Modules.ArticleModule.Domain.Article domainArticle = article.GetObject(_identity);
                UIMapping.BindObjectToControls(domainArticle, this);
                UIMapping.BindObjectToControls(domainArticle.ContentBaseInfo, this);
                ContentBaseId.Text = domainArticle.ContentBaseInfo.Id.ToString();
                Id.Text = domainArticle.Id.ToString();
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
                    ZhuJi.Modules.ArticleModule.Domain.Article domainArticle = new ZhuJi.Modules.ArticleModule.Domain.Article();
                    ZhuJi.Modules.Core.Domain.ContentBase domainContentBase = new ZhuJi.Modules.Core.Domain.ContentBase();
                    UIMapping.BindControlsToObject(domainArticle, this);
                    UIMapping.BindControlsToObject(domainContentBase, this);
                    domainArticle.ContentBaseInfo = domainContentBase;

                    ZhuJi.Modules.ArticleModule.IDAL.IArticle article = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.ArticleModule.NHibernateDAL.Article)) as ZhuJi.Modules.ArticleModule.IDAL.IArticle;
                    article.Insert(domainArticle);

					_identity = domainArticle.Id;
					Edit();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex);
                    return;
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
                    ZhuJi.Modules.ArticleModule.Domain.Article domainArticle = new ZhuJi.Modules.ArticleModule.Domain.Article();
                    ZhuJi.Modules.Core.Domain.ContentBase domainContentBase = new ZhuJi.Modules.Core.Domain.ContentBase();
                    UIMapping.BindControlsToObject(domainArticle, this);
                    UIMapping.BindControlsToObject(domainContentBase, this);
                    domainContentBase.Id = int.Parse(ContentBaseId.Text.Trim());
                    domainArticle.ContentBaseInfo = domainContentBase;

                    ZhuJi.Modules.ArticleModule.IDAL.IArticle article = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.ArticleModule.NHibernateDAL.Article)) as ZhuJi.Modules.ArticleModule.IDAL.IArticle;
                    article.Update(domainArticle);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex);
                    return;
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
                ZhuJi.Modules.ArticleModule.Domain.Article domainArticle = new ZhuJi.Modules.ArticleModule.Domain.Article();

                domainArticle.Id = int.Parse(Id.Text);

                ZhuJi.Modules.ArticleModule.IDAL.IArticle article = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.ArticleModule.NHibernateDAL.Article)) as ZhuJi.Modules.ArticleModule.IDAL.IArticle;
                article.Delete(domainArticle);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
                return;
            }

            Response.Redirect(Request.Url.ToString(),true);
        }
    }
}

