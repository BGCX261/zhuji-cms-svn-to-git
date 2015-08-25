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

namespace ZhuJi.Portal.WebUI.Page
{
	public partial class Default : System.Web.UI.Page
	{
		private ZhuJi.Portal.Domain.Channel domainChannel;
		protected void Page_PreInit(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				if (ViewState["Id"] != null)
				{
					GetChannel((int)ViewState["Id"]);
				}
			}
			else
			{
				ViewState["Id"] = int.Parse(RequestHelper.Param("Id"));
				GetChannel((int)ViewState["Id"]);
			}
			SetSkin();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			ShowControl();
		}

		/// <summary>
		/// 获取栏目信息
		/// </summary>
		/// <param name="id"></param>
		private void GetChannel(int id)
		{
			ZhuJi.Portal.IDAL.IChannel channel = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Channel)) as ZhuJi.Portal.IDAL.IChannel;
			domainChannel = channel.GetObject(id);
		}

		/// <summary>
		/// 设置样式
		/// </summary>
		private void SetSkin()
		{
			if (domainChannel != null)
			{
				this.MasterPageFile = domainChannel.SkinInfo.Master;
				this.Theme = domainChannel.SkinInfo.Style;
			}
		}

		/// <summary>
		/// 显示用户控件
		/// </summary>
		private void ShowControl()
		{			
			if (domainChannel != null)
			{
				Control control = this.LoadControl(domainChannel.ContentItemInfo.View);
				phContent.Controls.Add(control);
			}
		}
	}
}
