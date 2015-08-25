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

namespace ZhuJi.Modules.SinglePageModule.WebUI
{
    public partial class SinglePageShow : ZhuJi.Portal.WebUI.BaseWebControl
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
				{					
					_identity = int.Parse(Request.QueryString["Id"]);
					Initialize();
				}
			}
		}

		/// <summary>
		/// 初始化表单
		/// </summary>
		public void Initialize()
		{
			try
			{
				ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage singlePage = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.SinglePageModule.NHibernateDAL.SinglePage)) as ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage;
				ZhuJi.Modules.SinglePageModule.Domain.SinglePage domainSinglePage = singlePage.GetObjectByChannelId(_identity);
				if (domainSinglePage != null)
				{
					UIMapping.BindObjectToControls(domainSinglePage, this);
					UIMapping.BindObjectToControls(domainSinglePage.ContentBaseInfo, this);
				}
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

