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
    public partial class RolesList : ZhuJi.Portal.WebUI.BaseWebControl
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
				ZhuJi.UUMS.IDAL.IRoles roles = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Roles)) as ZhuJi.UUMS.IDAL.IRoles;
				gvList.DataSource = roles.GetObjects(base.Where, base.OrderNo);
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
				ZhuJi.UUMS.Domain.Roles domainRoles = new ZhuJi.UUMS.Domain.Roles();

				domainRoles.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);

				ZhuJi.UUMS.IDAL.IRoles roles = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Roles)) as ZhuJi.UUMS.IDAL.IRoles;
				roles.Delete(domainRoles);

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
				ZhuJi.UUMS.Domain.Roles domainRoles = new ZhuJi.UUMS.Domain.Roles();
				TextBox txtRoleName = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtRoleName");
				TextBox txtOrderBy = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtOrderBy");

				domainRoles.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);
				domainRoles.RoleName = txtRoleName.Text.Trim();
				domainRoles.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.UUMS.IDAL.IRoles roles = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Roles)) as ZhuJi.UUMS.IDAL.IRoles;
				roles.Update(domainRoles);

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
				ZhuJi.UUMS.Domain.Roles domainRoles = new ZhuJi.UUMS.Domain.Roles();
				TextBox txtRoleName = (TextBox)gvList.FooterRow.FindControl("txtRoleName");
				TextBox txtOrderBy = (TextBox)gvList.FooterRow.FindControl("txtOrderBy");

				domainRoles.RoleName = txtRoleName.Text.Trim();
				domainRoles.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.UUMS.IDAL.IRoles roles = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Roles)) as ZhuJi.UUMS.IDAL.IRoles;
				roles.Insert(domainRoles);

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

