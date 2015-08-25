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
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace ZhuJi.Modules.CountModule.WebUI
{
	public partial class CountStat : ZhuJi.Portal.WebUI.BaseWebControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				CountAll();
			}
		}

		/// <summary>
		/// 统计记录
		/// </summary>
		private void CountAll()
		{
			NameValueCollection variables = Request.ServerVariables;

			int id = 0;
			string ip = variables["REMOTE_ADDR"];
			int pvs = 1;
			int ips = 1;
			int cookies = 1;
			string area = string.Empty;
			string province = string.Empty;
			string city = string.Empty;
			int visits = 1;
			DateTime addTime = DateTime.Now;
			string referUrl = Request.QueryString["refer"];
			string referSite = string.Empty;
			if (!string.IsNullOrEmpty(referUrl))
			{
				Regex r = new Regex(@"^http://(?<site>.+)?/", RegexOptions.Compiled);
				referSite = r.Match(referUrl).Result("${site}");
			}
			string os = string.Empty;
			string browser = string.Empty;
			string resolution = Request.QueryString["resolution"];
			string[] arrTemp = variables["HTTP_USER_AGENT"].Split(';');
			if (arrTemp.Length > 2)
			{
				browser = arrTemp[1];
				os = arrTemp[2];
			}
			string respondents = Request.QueryString["url"];
			if (Session["CountCookies"] == null)
			{
				Session["CountCookies"] = "1";
			}
			else
			{
				cookies = 0;
				visits = 0;
			}

			ZhuJi.Modules.CountModule.IDAL.ICountStat countStat = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.CountModule.SQLServerDAL.CountStat)) as ZhuJi.Modules.CountModule.IDAL.ICountStat;
			countStat.Insert(id, ip, pvs, ips, cookies, area, province, city, visits, addTime, referSite, referUrl, os, browser, resolution, respondents);

		}
	}
}