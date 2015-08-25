<%@ Control Language="C#" AutoEventWireup="True" Codebehind="AdsInforList.ascx.cs"
	Inherits="ZhuJi.Modules.AdsModule.WebUI.AdsInforList" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0" class="nfgrid">
			<tr class="nfgridheader">
				<td>
					标识</td>
				<td>
					所属版位</td>
				<td>
					广告名称</td>
				<td>
					开播日期</td>
				<td>
					停播日期</td>
				<td>
					客户</td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr class="nfgriditem">
			<td>
				<asp:CheckBox ID="chkId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>'>
				</asp:CheckBox></td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.AdsLocationInfo.Name")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Name")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.BeginTime","{0:yyyy-MM-dd}")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.EndTime", "{0:yyyy-MM-dd}")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.CustomerUnits")%>
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
