using System;
using System.Web;
using System.Web.Security;
using System.Security.Principal;

namespace ZhuJi.SSO.Core
{
	/// <summary>
	/// �����¼��֤
	/// </summary>
	public class Authenticate : IHttpModule
	{

		#region IHttpModule ��Ա
		/// <summary>
		/// ������ʵ�� IHttpModule ��ģ��ʹ�õ���Դ���ڴ���⣩��
		/// </summary>
		public void Dispose()
		{
		}
		/// <summary>
		/// ��ʼ��ģ�飬��ʹ��Ϊ������������׼����
		/// </summary>
		/// <param name="context"></param>
		public void Init(HttpApplication context)
		{
			context.BeginRequest += new EventHandler(context_BeginRequest);
			context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
		}
		#endregion

		/// <summary>
		/// �� ASP.NET ��Ӧ����ʱ��Ϊ HTTP ִ�й������еĵ�һ���¼������� 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void context_BeginRequest(object sender, EventArgs e)
		{
			HttpApplication application = (HttpApplication)sender;
			HttpContext context = application.Context;
			HttpResponse Response = context.Response;
			//��ֹ��Iframe��ʱ��Cookie��ʧ
			Response.AddHeader("P3P", "CP=CAO PSA OUR");
		}

		/// <summary>
		/// ����ȫģ���ѽ����û���ʶʱ������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void context_AuthenticateRequest(object sender, EventArgs e)
		{
			HttpApplication application = (HttpApplication)sender;
			HttpContext context = application.Context;

			HttpRequest Request = context.Request;
			HttpResponse Response = context.Response;

			FormsAuthentication.Initialize();

			//�������/WebAuth.aspx��ҳ,�Ͳ�������
			if (!Request.Url.AbsolutePath.EndsWith("/WebAuth.aspx", StringComparison.OrdinalIgnoreCase))
				return ;

			//�����ǰ�û�Ϊ��
			if (context.User == null)
			{
				//s��ʾǩ�������Ϣ
				string s = Request.QueryString["s"];

				//��ʾ����Ҫ������Ϣ �����Ҫ,���԰Ѵ˲�����ϢҲ����
				string v = Request.QueryString["v"];

				if (!string.IsNullOrEmpty(s) && !string.IsNullOrEmpty(v))
				{
					Client client = new Client();

					v = client.DecodeBase64(v);

					//UrlDecode��� + �ű�� ''
					s = s.Replace(' ', '+');


					#region ͨ��֮ǰ���Cookie�ж��ǲ����������֤��Ϣ,��ֹ����Copy Url ��ַ
					HttpCookie ticksCookie = application.Request.Cookies["Ticks"];
					string authTicks = string.Empty;
					if (ticksCookie != null)
					{
						authTicks = ticksCookie.Value;
					}
					v = v + "$" + authTicks;
					#endregion

					//�ж�ǩ��
					if (client.ValidataData(v, s))
					{
						string username = client.getUsername(v);
						string rolesId = client.getRolesId(v);

						FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
							1,
							username,
							DateTime.Now,
							DateTime.Now.AddDays(1d),
							false,
							rolesId,
							FormsAuthentication.FormsCookiePath);

						context.User = new GenericPrincipal(new FormsIdentity(ticket), new String[1]);

						FormsAuthentication.SetAuthCookie(username, false);

						HttpCookie usersInfo = new HttpCookie("UsersInfo");
						usersInfo["User"] = username;
						usersInfo["RolesId"] = rolesId;
						usersInfo.Expires = DateTime.Now.AddMinutes(30);
						HttpContext.Current.Response.Cookies.Add(usersInfo);

					}
					else
					{
						//ǩ����Ч,�ض��򵽵�½ҳ
						Response.Redirect(FormsAuthentication.DefaultUrl);
					}
				}
				else
				{
					string ticks = System.DateTime.Now.Ticks.ToString();
					HttpCookie cookie = new HttpCookie("Ticks", ticks);
					application.Response.Cookies.Add(cookie);
					Response.Redirect(FormsAuthentication.DefaultUrl + "?site=" + HttpUtility.UrlEncode(Request.Url.ToString()) + "&ticks=" + ticks);
				}
			}
		}
	}
}
