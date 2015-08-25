<%@ Control Language="C#" AutoEventWireup="True" Codebehind="AdsLocationList.ascx.cs"
	Inherits="ZhuJi.Modules.AdsModule.WebUI.AdsLocationList" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0" class="nfgrid">
			<tr class="nfgridheader">
				<td>
					标识</td>
				<td>
					版位名称</td>
				<td>
					版位类型</td>
				<td>
					版位宽高</td>
				<td>
					版位状态</td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr class="nfgriditem">
			<td>
				<asp:CheckBox ID="chkId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>'>
				</asp:CheckBox></td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Name") %>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.AdsLocationTypeInfo.Text")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Width") %>X<%# DataBinder.Eval(Container, "DataItem.Height") %></td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Ispass")%>
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
