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
using System.Collections.Generic;
using ZhuJi.Library.Security;

namespace ZhuJi.SSO
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.IsAuthenticated)
                {
					if (Request.Cookies["UsersInfo"] != null)
					{
						if (Request.Cookies["UsersInfo"]["RolesId"] != null)
						{
							ReturnUrl();
						}
					}
                }
            }

		}

		protected void bLogin_Click(object sender, EventArgs e)
		{
			if (Request.Cookies["CheckCode"] == null)
			{
				ZhuJi.Library.Web.MessageHelper.ShowAndBack(Page, "您的浏览器设置已被禁用 Cookies，您必须设置浏览器允许使用 Cookies 选项后才能使用本系统。");
				return;
			}

			if (String.Compare(Request.Cookies["CheckCode"].Value, txtCheckCode.Text, true) != 0)
			{
				ZhuJi.Library.Web.MessageHelper.ShowAndBack(Page, "验证码错误，请输入正确的验证码。");
				return;
			}

			ZhuJi.UUMS.Domain.Users domainUsers = new ZhuJi.UUMS.Domain.Users();
			domainUsers.CheckPassword = true;
			domainUsers.Username = tbUsername.Text;
			domainUsers.Password = tbPassword.Text;
			string where = string.Format("tmp.Username Like '{0}' And tmp.Password Like '{1}'", domainUsers.Username, domainUsers.Password);
			ZhuJi.UUMS.IDAL.IUsers users = new ZhuJi.UUMS.NHibernateDAL.Users();
			IList<ZhuJi.UUMS.Domain.Users> lists = users.GetObjects(where,string.Empty);
			if (lists.Count > 0)
			{
				Login(lists[0]);
			}
			else
			{
				ZhuJi.Library.Web.MessageHelper.ShowAndBack(Page, ZhuJi.Library.Web.MessageHelper.GetMessage("NotLogin"));
			}
			
		}

		/// <summary>
		/// 登录系统
		/// </summary>
		/// <param name="domainUsers">用户信息</param>
		private void Login(ZhuJi.UUMS.Domain.Users domainUsers)
		{
			FormsAuthentication.SetAuthCookie(domainUsers.Username, false);

			HttpCookie usersInfo = new HttpCookie("UsersInfo");
			usersInfo["User"] = domainUsers.Username;
			usersInfo["RolesId"] = domainUsers.RolesId.ToString();
			usersInfo.Expires = DateTime.Now.AddMinutes(30);
			HttpContext.Current.Response.Cookies.Add(usersInfo);

			ReturnUrl();
		}

		/// <summary>
		/// 取得认证信息
		/// </summary>
		/// <returns></returns>
		private string getAuthInfo()
		{
			string ret = string.Empty;
			ret = string.Concat(Request.Cookies["UsersInfo"]["User"], "$", Request.Cookies["UsersInfo"]["RolesId"]);
			return ret;
		}

		/// <summary>
		/// 返回请求认证的网站
		/// </summary>
        private void ReturnUrl()
        {
            string url = Request.QueryString["site"];
			if (string.IsNullOrEmpty(url))
			{
				return;
			}
			url = HttpUtility.UrlDecode(url);

			ZhuJi.SSO.Core.Server server = new ZhuJi.SSO.Core.Server();

			//取得认证信息
			string data = getAuthInfo();
			if (string.IsNullOrEmpty(data))
			{
				return;
			}
	
			#region 写入签名信息
			if (url.IndexOf('?') == -1)
			{
				url = url + "?s=" + server.SignatueData(data + "$" + Request.QueryString["ticks"]);
				url = url + "&v=" + server.EncodeBase64(data);
			}
			else
			{
				url = url + "&s=" + server.SignatueData(data + "$" + Request.QueryString["ticks"]);
				url = url + "&v=" + server.EncodeBase64(data);
			}
			#endregion

			Response.Redirect(url);
        }
    }
}
