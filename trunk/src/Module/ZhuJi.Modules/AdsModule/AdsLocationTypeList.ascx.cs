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

namespace ZhuJi.Modules.AdsModule.WebUI
{
	public partial class AdsLocationTypeList : ZhuJi.Portal.WebUI.BaseWebControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindGrid();
			}
		}

		/// <summary>
		/// 初始化查询列表
		/// </summary>
		public void BindGrid()
		{
			try
			{
				ZhuJi.Modules.AdsModule.IDAL.IAdsLocationType adsLocationType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.AdsModule.NHibernateDAL.AdsLocationType)) as ZhuJi.Modules.AdsModule.IDAL.IAdsLocationType;
				gvList.DataSource = adsLocationType.GetObjects(base.Where, base.OrderNo);
				gvList.DataBind();
			}
			catch (Exception ex)
			{
				ShowMessage(ex);
			}
		}

		protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				ZhuJi.Modules.AdsModule.Domain.AdsLocationType domainAdsLocationType = new ZhuJi.Modules.AdsModule.Domain.AdsLocationType();

				domainAdsLocationType.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);

				ZhuJi.Modules.AdsModule.IDAL.IAdsLocationType adsLocationType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.AdsModule.NHibernateDAL.AdsLocationType)) as ZhuJi.Modules.AdsModule.IDAL.IAdsLocationType;
				adsLocationType.Delete(domainAdsLocationType);

				gvList.EditIndex = -1;
				BindGrid();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
		{
			gvList.EditIndex = e.NewEditIndex;
			BindGrid();
		}

		protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				ZhuJi.Modules.AdsModule.Domain.AdsLocationType domainAdsLocationType = new ZhuJi.Modules.AdsModule.Domain.AdsLocationType();
				TextBox txtText = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtText");
				TextBox txtValue = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtValue");
				TextBox txtOrderBy = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtOrderBy");

				domainAdsLocationType.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);
				domainAdsLocationType.Text = txtText.Text.Trim();
				domainAdsLocationType.Value = int.Parse(txtValue.Text.Trim());
				domainAdsLocationType.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.Modules.AdsModule.IDAL.IAdsLocationType adsLocationType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.AdsModule.NHibernateDAL.AdsLocationType)) as ZhuJi.Modules.AdsModule.IDAL.IAdsLocationType;
				adsLocationType.Update(domainAdsLocationType);

				gvList.EditIndex = -1;
				BindGrid();
			}
			catch (Exception ex)
			{
				ShowMessage(ex);
			}
		}

		protected void gvList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			gvList.EditIndex = -1;
			BindGrid();
		}

		protected void gvList_RowInserting(object sender, EventArgs e)
		{
			try
			{
				ZhuJi.Modules.AdsModule.Domain.AdsLocationType domainAdsLocationType = new ZhuJi.Modules.AdsModule.Domain.AdsLocationType();
				TextBox txtText = (TextBox)gvList.FooterRow.FindControl("txtText");
				TextBox txtValue = (TextBox)gvList.FooterRow.FindControl("txtValue");
				TextBox txtOrderBy = (TextBox)gvList.FooterRow.FindControl("txtOrderBy");

				domainAdsLocationType.Text = txtText.Text.Trim();
				domainAdsLocationType.Value = int.Parse(txtValue.Text.Trim());
				domainAdsLocationType.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.Modules.AdsModule.IDAL.IAdsLocationType adsLocationType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.AdsModule.NHibernateDAL.AdsLocationType)) as ZhuJi.Modules.AdsModule.IDAL.IAdsLocationType;
				adsLocationType.Insert(domainAdsLocationType);

				gvList.EditIndex = -1;
				BindGrid();
			}
			catch (Exception ex)
			{
				ShowMessage(ex);
			}
		}
	}
}

