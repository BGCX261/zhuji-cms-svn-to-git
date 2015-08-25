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
				ZhuJi.Library.Web.MessageHelper.ShowAndBack(Page, "��������������ѱ����� Cookies���������������������ʹ�� Cookies ѡ������ʹ�ñ�ϵͳ��");
				return;
			}

			if (String.Compare(Request.Cookies["CheckCode"].Value, txtCheckCode.Text, true) != 0)
			{
				ZhuJi.Library.Web.MessageHelper.ShowAndBack(Page, "��֤�������������ȷ����֤�롣");
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
		/// ��¼ϵͳ
		/// </summary>
		/// <param name="domainUsers">�û���Ϣ</param>
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
		/// ȡ����֤��Ϣ
		/// </summary>
		/// <returns></returns>
		private string getAuthInfo()
		{
			string ret = string.Empty;
			ret = string.Concat(Request.Cookies["UsersInfo"]["User"], "$", Request.Cookies["UsersInfo"]["RolesId"]);
			return ret;
		}

		/// <summary>
		/// ����������֤����վ
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

			//ȡ����֤��Ϣ
			string data = getAuthInfo();
			if (string.IsNullOrEmpty(data))
			{
				return;
			}
	
			#region д��ǩ����Ϣ
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
