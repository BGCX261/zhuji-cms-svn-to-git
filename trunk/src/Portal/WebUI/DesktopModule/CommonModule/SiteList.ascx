<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SiteList.ascx.cs" Inherits="ZhuJi.Portal.WebUI.DesktopModule.CommonModule.SiteList" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0" class="nfgrid">
			<tr class="nfgridheader">
				<td>
					标识</td>
				<td>
					站点标题</td>
				<td>
					站点地址</td>
				<td>
					排序</td>
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
				<%# DataBinder.Eval(Container, "DataItem.Url") %>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.OrderBy") %>
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
