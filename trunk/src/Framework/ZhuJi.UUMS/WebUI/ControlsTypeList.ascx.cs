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

namespace ZhuJi.UUMS.WebUI
{
    public partial class ControlsTypeList : ZhuJi.Portal.WebUI.BaseWebControl
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
				ZhuJi.UUMS.IDAL.IControlsType controlsType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.ControlsType)) as ZhuJi.UUMS.IDAL.IControlsType;
				gvList.DataSource = controlsType.GetObjects(base.Where, base.OrderNo);
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
				ZhuJi.UUMS.Domain.ControlsType domainControlsType = new ZhuJi.UUMS.Domain.ControlsType();

				domainControlsType.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);

				ZhuJi.UUMS.IDAL.IControlsType controlsType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.ControlsType)) as ZhuJi.UUMS.IDAL.IControlsType;
				controlsType.Delete(domainControlsType);

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
				ZhuJi.UUMS.Domain.ControlsType domainControlsType = new ZhuJi.UUMS.Domain.ControlsType();
				TextBox txtText = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtText");
				TextBox txtValue = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtValue");
				TextBox txtOrderBy = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtOrderBy");

				domainControlsType.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);
				domainControlsType.Text = txtText.Text.Trim();
				domainControlsType.Value = txtValue.Text.Trim();
				domainControlsType.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.UUMS.IDAL.IControlsType controlsType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.ControlsType)) as ZhuJi.UUMS.IDAL.IControlsType;
				controlsType.Update(domainControlsType);

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
				ZhuJi.UUMS.Domain.ControlsType domainControlsType = new ZhuJi.UUMS.Domain.ControlsType();
				TextBox txtText = (TextBox)gvList.FooterRow.FindControl("txtText");
				TextBox txtValue = (TextBox)gvList.FooterRow.FindControl("txtValue");
				TextBox txtOrderBy = (TextBox)gvList.FooterRow.FindControl("txtOrderBy");

				domainControlsType.Text = txtText.Text.Trim();
				domainControlsType.Value = txtValue.Text.Trim();
				domainControlsType.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.UUMS.IDAL.IControlsType controlsType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.ControlsType)) as ZhuJi.UUMS.IDAL.IControlsType;
				controlsType.Insert(domainControlsType);

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

