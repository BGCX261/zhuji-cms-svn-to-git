<%@ Control Language="C#" AutoEventWireup="True" Codebehind="ArticleList.ascx.cs"
	Inherits="ZhuJi.Modules.ArticleModule.WebUI.ArticleList" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0" class="nfgrid">
			<tr class="nfgridheader">
				<td>
					标识</td>
				<td>
					标题</td>
				<td>
					录入日期</td>
				<td>
					录入用户</td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr class="nfgriditem">
			<td>
				<asp:CheckBox ID="chkId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>'>
				</asp:CheckBox></td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Title") %>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.ContentBaseInfo.CreatedByDate","{0:yyyy-MM-dd}")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.ContentBaseInfo.CreatedByUser")%>
			</td>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>
<cc1:SimplePager ID="simplePager" runat="server" Visible="false">
	<ItemTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr class="nfgridpager">
				<td>
					<%#Container.FirstPage%>
					<%#Container.PrevPage%>
					<%#Container.ListPages%>
					<%#Container.NextPage%>
					<%#Container.LastPage%>
					<%#Container.PageSize%>
					记录/页 共<%#Container.RecordCount%>记录
					<%#Container.CurrentPage%>
					/<%#Container.PageCount%>页
				</td>
			</tr>
		</table>
	</ItemTemplate>
</cc1:SimplePager>
