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
    public partial class ArticleShow : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 初始化表单
        /// </summary>
        public void Initialize()
        {
            try
            {
                ZhuJi.Modules.ArticleModule.IDAL.IArticle article = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.ArticleModule.NHibernateDAL.Article)) as ZhuJi.Modules.ArticleModule.IDAL.IArticle;
                ZhuJi.Modules.ArticleModule.Domain.Article domainArticle = article.GetObject(_identity);
                UIMapping.BindObjectToControls(domainArticle, this);
                UIMapping.BindObjectToControls(domainArticle.ContentBaseInfo, this);
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
    }
}

