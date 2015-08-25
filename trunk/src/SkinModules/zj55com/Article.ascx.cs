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

namespace ZhuJi.SkinModules.zj55com
{
	public partial class Article : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ArticleList1.Visible = false;
                ArticleShow1.Visible = false;
                string _command = Request.QueryString["cmd"];
				if (string.IsNullOrEmpty(_command))
				{
					List();
				}
				else
				{
					switch (_command.ToUpper())
					{
						case "LIST":
							List();
							break;
						case "SHOW":
							Show();
							break;
						default:
							List();
							break;
					}
				}
            }
        }

        /// <summary>
        /// 列表
        /// </summary>
        private void List()
        {
            ArticleList1.Visible = true;
			ArticleList1.IsShowPager = true;
			ArticleList1.Where = string.Format("tmp.ContentBaseInfo.ChannelId={0} And tmp.ContentBaseInfo.Passed = 1", Request.QueryString["Id"]);
        }

        /// <summary>
        /// 显示
        /// </summary>
        private void Show()
        {
            string _identity = Request.QueryString["aid"];
            ArticleShow1.Identity = int.Parse(_identity);
            ArticleShow1.Initialize();
            ArticleShow1.Visible = true;
        }
    }
}