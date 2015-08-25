<%@ Control Language="C#" AutoEventWireup="True" Codebehind="CountHourList.ascx.cs"
	Inherits="ZhuJi.Modules.CountModule.WebUI.CountHourList" %>
<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td>
					统计时间（单位小时）</td>
				<td>
					PV访问量</td>
				<td>
					独立访客</td>
				<td>
					唯一IP</td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Addtime")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Pvs")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Cookies")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Ips")%>
			</td>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>
