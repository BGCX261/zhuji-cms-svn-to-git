<%@ Control Language="C#" AutoEventWireup="True" Codebehind="CountOsList.ascx.cs"
	Inherits="ZhuJi.Modules.CountModule.WebUI.CountOsList" %>
<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td>
					操作系统</td>
				<td>
					访问量</td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td>
				<%# EvalEmpty(DataBinder.Eval(Container, "DataItem.Os"))%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Visits")%>
			</td>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>
