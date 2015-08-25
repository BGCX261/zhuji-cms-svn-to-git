<%@ Control Language="C#" AutoEventWireup="True" Codebehind="CountRespondentsList.ascx.cs"
	Inherits="ZhuJi.Modules.CountModule.WebUI.CountRespondentsList" %>
<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td>
					受访页</td>
				<td>
					访问量</td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td>
				<%# EvalEmpty(DataBinder.Eval(Container, "DataItem.Respondents"))%>
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
