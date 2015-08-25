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
    public partial class ControlsAttributeList : ZhuJi.Portal.WebUI.BaseWebControl
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
				ZhuJi.UUMS.IDAL.IControlsAttribute controlsAttribute = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.ControlsAttribute)) as ZhuJi.UUMS.IDAL.IControlsAttribute;
				gvList.DataSource = controlsAttribute.GetObjects(base.Where, base.OrderNo);
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
				ZhuJi.UUMS.Domain.ControlsAttribute domainControlsAttribute = new ZhuJi.UUMS.Domain.ControlsAttribute();

				domainControlsAttribute.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);

				ZhuJi.UUMS.IDAL.IControlsAttribute controlsAttribute = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.ControlsAttribute)) as ZhuJi.UUMS.IDAL.IControlsAttribute;
				controlsAttribute.Delete(domainControlsAttribute);

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
				ZhuJi.UUMS.Domain.ControlsAttribute domainControlsAttribute = new ZhuJi.UUMS.Domain.ControlsAttribute();
				TextBox txtText = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtText");
				TextBox txtValue = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtValue");
				TextBox txtOrderBy = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtOrderBy");

				domainControlsAttribute.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);
				domainControlsAttribute.Text = txtText.Text.Trim();
				domainControlsAttribute.Value = txtValue.Text.Trim();
				domainControlsAttribute.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.UUMS.IDAL.IControlsAttribute controlsAttribute = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.ControlsAttribute)) as ZhuJi.UUMS.IDAL.IControlsAttribute;
				controlsAttribute.Update(domainControlsAttribute);

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
				ZhuJi.UUMS.Domain.ControlsAttribute domainControlsAttribute = new ZhuJi.UUMS.Domain.ControlsAttribute();
				TextBox txtText = (TextBox)gvList.FooterRow.FindControl("txtText");
				TextBox txtValue = (TextBox)gvList.FooterRow.FindControl("txtValue");
				TextBox txtOrderBy = (TextBox)gvList.FooterRow.FindControl("txtOrderBy");

				domainControlsAttribute.Text = txtText.Text.Trim();
				domainControlsAttribute.Value = txtValue.Text.Trim();
				domainControlsAttribute.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.UUMS.IDAL.IControlsAttribute controlsAttribute = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.ControlsAttribute)) as ZhuJi.UUMS.IDAL.IControlsAttribute;
				controlsAttribute.Insert(domainControlsAttribute);

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

