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
    public partial class ResourcesList : ZhuJi.Portal.WebUI.BaseWebControl
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
				ZhuJi.UUMS.IDAL.IResources resources = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Resources)) as ZhuJi.UUMS.IDAL.IResources;
				gvList.DataSource = resources.GetObjects(base.Where, base.OrderNo);
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
				ZhuJi.UUMS.Domain.Resources domainResources = new ZhuJi.UUMS.Domain.Resources();

				domainResources.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);

				ZhuJi.UUMS.IDAL.IResources resources = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Resources)) as ZhuJi.UUMS.IDAL.IResources;
				resources.Delete(domainResources);

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
				ZhuJi.UUMS.Domain.Resources domainResources = new ZhuJi.UUMS.Domain.Resources();
				TextBox txtResourceName = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtResourceName");
				TextBox txtOrderBy = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtOrderBy");

				domainResources.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);
				domainResources.ResourceName = txtResourceName.Text.Trim();
				domainResources.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.UUMS.IDAL.IResources resources = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Resources)) as ZhuJi.UUMS.IDAL.IResources;
				resources.Update(domainResources);

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
				ZhuJi.UUMS.Domain.Resources domainResources = new ZhuJi.UUMS.Domain.Resources();
				TextBox txtResourceName = (TextBox)gvList.FooterRow.FindControl("txtResourceName");
				TextBox txtOrderBy = (TextBox)gvList.FooterRow.FindControl("txtOrderBy");

				domainResources.ResourceName = txtResourceName.Text.Trim();
				domainResources.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.UUMS.IDAL.IResources resources = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Resources)) as ZhuJi.UUMS.IDAL.IResources;
				resources.Insert(domainResources);

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

