using System;
using System.Web;
using System.Web.Security;
using System.Security.Principal;

namespace ZhuJi.SSO.Core
{
	/// <summary>
	/// 单点登录验证
	/// </summary>
	public class Authenticate : IHttpModule
	{

		#region IHttpModule 成员
		/// <summary>
		/// 处置由实现 IHttpModule 的模块使用的资源（内存除外）。
		/// </summary>
		public void Dispose()
		{
		}
		/// <summary>
		/// 初始化模块，并使其为处理请求做好准备。
		/// </summary>
		/// <param name="context"></param>
		public void Init(HttpApplication context)
		{
			context.BeginRequest += new EventHandler(context_BeginRequest);
			context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
		}
		#endregion

		/// <summary>
		/// 在 ASP.NET 响应请求时作为 HTTP 执行管线链中的第一个事件发生。 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void context_BeginRequest(object sender, EventArgs e)
		{
			HttpApplication application = (HttpApplication)sender;
			HttpContext context = application.Context;
			HttpResponse Response = context.Response;
			//防止在Iframe的时间Cookie丢失
			Response.AddHeader("P3P", "CP=CAO PSA OUR");
		}

		/// <summary>
		/// 当安全模块已建立用户标识时发生。
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

			//如果不是/WebAuth.aspx网页,就不管他了
			if (!Request.Url.AbsolutePath.EndsWith("/WebAuth.aspx", StringComparison.OrdinalIgnoreCase))
				return ;

			//如果当前用户为空
			if (context.User == null)
			{
				//s表示签名后的信息
				string s = Request.QueryString["s"];

				//表示真正要传的信息 如果需要,可以把此部分信息也加密
				string v = Request.QueryString["v"];

				if (!string.IsNullOrEmpty(s) && !string.IsNullOrEmpty(v))
				{
					Client client = new Client();

					v = client.DecodeBase64(v);

					//UrlDecode会把 + 号变成 ''
					s = s.Replace(' ', '+');


					#region 通过之前存的Cookie判断是不是最近的验证信息,防止别人Copy Url 地址
					HttpCookie ticksCookie = application.Request.Cookies["Ticks"];
					string authTicks = string.Empty;
					if (ticksCookie != null)
					{
						authTicks = ticksCookie.Value;
					}
					v = v + "$" + authTicks;
					#endregion

					//判断签名
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
						//签名无效,重定向到登陆页
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
