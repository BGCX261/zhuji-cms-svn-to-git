<%@ Control Language="C#" AutoEventWireup="True" Codebehind="CountBackList.ascx.cs"
	Inherits="ZhuJi.Modules.CountModule.WebUI.CountBackList" %>
<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td>
					回头客</td>
				<td>
					统计人数</td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Visits")%>
				次回头客
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.C")%>
			</td>
		</tr>
	</ItemTemplate>
	<FooterTemplate>
		</table>
	</FooterTemplate>
</asp:Repeater>
