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
    public partial class MethodExplainList : ZhuJi.Portal.WebUI.BaseWebControl
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
                ZhuJi.UUMS.IDAL.IMethodExplain methodExplain = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.MethodExplain)) as ZhuJi.UUMS.IDAL.IMethodExplain;
				gvList.DataSource = methodExplain.GetObjects(base.Where, base.OrderNo);
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
				ZhuJi.UUMS.Domain.MethodExplain domainMethodExplain = new ZhuJi.UUMS.Domain.MethodExplain();

				domainMethodExplain.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);

				ZhuJi.UUMS.IDAL.IMethodExplain methodExplain = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.MethodExplain)) as ZhuJi.UUMS.IDAL.IMethodExplain;
				methodExplain.Delete(domainMethodExplain);

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
				ZhuJi.UUMS.Domain.MethodExplain domainMethodExplain = new ZhuJi.UUMS.Domain.MethodExplain();
				TextBox txtTitle = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtTitle");
				TextBox txtOrderBy = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtOrderBy");

				domainMethodExplain.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);
				domainMethodExplain.Title = txtTitle.Text.Trim();
				domainMethodExplain.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.UUMS.IDAL.IMethodExplain methodExplain = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.MethodExplain)) as ZhuJi.UUMS.IDAL.IMethodExplain;
				methodExplain.Update(domainMethodExplain);

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
				ZhuJi.UUMS.Domain.MethodExplain domainMethodExplain = new ZhuJi.UUMS.Domain.MethodExplain();
				TextBox txtTitle = (TextBox)gvList.FooterRow.FindControl("txtTitle");
				TextBox txtOrderBy = (TextBox)gvList.FooterRow.FindControl("txtOrderBy");

				domainMethodExplain.Title = txtTitle.Text.Trim();
				domainMethodExplain.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.UUMS.IDAL.IMethodExplain methodExplain = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.MethodExplain)) as ZhuJi.UUMS.IDAL.IMethodExplain;
				methodExplain.Insert(domainMethodExplain);

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

