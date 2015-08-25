<%@ Control Language="C#" AutoEventWireup="True" Codebehind="CountOnlineList.ascx.cs"
	Inherits="ZhuJi.Modules.CountModule.WebUI.CountOnlineList" %>
<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td>
					在线IP</td>
				<td>
					停留时间(单位分钟)</td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Ip")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Addtime")%>
			</td>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>
