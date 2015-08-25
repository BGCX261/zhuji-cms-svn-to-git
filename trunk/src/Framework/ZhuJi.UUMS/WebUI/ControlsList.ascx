<%@ Control Language="C#" AutoEventWireup="True" Codebehind="ControlsList.ascx.cs"
	Inherits="ZhuJi.UUMS.WebUI.ControlsList" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0" class="nfgrid">
			<tr class="nfgridheader">
				<td>
					标识</td>
				<td>
					资源名称</td>
				<td>
					页名称</td>
				<td>
					控件名称</td>
				<td>
					控件类型</td>
				<td>
					控件属性</td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr class="nfgriditem">
			<td>
				<asp:CheckBox ID="chkId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>'>
				</asp:CheckBox></td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.ResourcesInfo.ResourceName")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.PageName")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.ControlName")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.ControlsTypeInfo.Text")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.ControlsAttributeInfo.Text")%>
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
