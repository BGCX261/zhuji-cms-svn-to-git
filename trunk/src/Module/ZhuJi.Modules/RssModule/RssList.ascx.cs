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

namespace ZhuJi.Modules.RssModule.WebUI
{
	public partial class RssList : ZhuJi.Portal.WebUI.BaseWebControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
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
		/// 初始化查询列表
		/// </summary>
		public void List()
		{
			try
			{
				ZhuJi.Modules.RssModule.IDAL.IRssChannel rssChannel = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.RssModule.SQLServerDAL.RssChannel)) as ZhuJi.Modules.RssModule.IDAL.IRssChannel;
				ZhuJi.Modules.RssModule.Domain.RssChannel domainRssChannel = rssChannel.GetObject(_identity);
				if (domainRssChannel != null)
				{
					UIMapping.BindObjectToControls(domainRssChannel, this);
					rptList.DataSource = domainRssChannel.RssItems;
					rptList.DataBind();
				}
			}
			catch (Exception ex)
			{
				ShowMessage(ex);
			}
		}
	}
}