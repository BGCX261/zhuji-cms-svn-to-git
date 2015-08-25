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

namespace ZhuJi.Modules.VoteModule.WebUI
{
    public partial class VoteSubjectTypeList : ZhuJi.Portal.WebUI.BaseWebControl
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
				ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectType voteSubjectType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteSubjectType)) as ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectType;
				gvList.DataSource = voteSubjectType.GetObjects(base.Where, base.OrderNo);
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
				ZhuJi.Modules.VoteModule.Domain.VoteSubjectType domainVoteSubjectType = new ZhuJi.Modules.VoteModule.Domain.VoteSubjectType();

				domainVoteSubjectType.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);

				ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectType voteSubjectType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteSubjectType)) as ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectType;
				voteSubjectType.Delete(domainVoteSubjectType);

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
				ZhuJi.Modules.VoteModule.Domain.VoteSubjectType domainVoteSubjectType = new ZhuJi.Modules.VoteModule.Domain.VoteSubjectType();
				TextBox txtText = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtText");
				TextBox txtValue = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtValue");
				TextBox txtOrderBy = (TextBox)gvList.Rows[e.RowIndex].FindControl("txtOrderBy");

				domainVoteSubjectType.Id = int.Parse(gvList.Rows[e.RowIndex].Cells[0].Text);
				domainVoteSubjectType.Text = txtText.Text.Trim();
				domainVoteSubjectType.Value = int.Parse(txtValue.Text.Trim());
				domainVoteSubjectType.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectType voteSubjectType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteSubjectType)) as ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectType;
				voteSubjectType.Update(domainVoteSubjectType);

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
				ZhuJi.Modules.VoteModule.Domain.VoteSubjectType domainVoteSubjectType = new ZhuJi.Modules.VoteModule.Domain.VoteSubjectType();
				TextBox txtText = (TextBox)gvList.FooterRow.FindControl("txtText");
				TextBox txtValue = (TextBox)gvList.FooterRow.FindControl("txtValue");
				TextBox txtOrderBy = (TextBox)gvList.FooterRow.FindControl("txtOrderBy");

				domainVoteSubjectType.Text = txtText.Text.Trim();
				domainVoteSubjectType.Value = int.Parse(txtValue.Text.Trim());
				domainVoteSubjectType.OrderBy = int.Parse(txtOrderBy.Text.Trim());

				ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectType voteSubjectType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteSubjectType)) as ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectType;
				voteSubjectType.Insert(domainVoteSubjectType);

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

