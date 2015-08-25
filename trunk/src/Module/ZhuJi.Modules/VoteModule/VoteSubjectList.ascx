<%@ Control Language="C#" AutoEventWireup="True" Codebehind="VoteSubjectList.ascx.cs"
	Inherits="ZhuJi.Modules.VoteModule.WebUI.VoteSubjectList" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0" class="nfgrid">
			<tr class="nfgridheader">
				<td>
					标识</td>
				<td>
					投票类型</td>
				<td>
					投票标题</td>
				<td>
					开始时间</td>
				<td>
					结束时间</td>
				<td>
					是否IP限制</td>
				<td>
					验证通过</td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr class="nfgriditem">
			<td>
				<asp:CheckBox ID="chkId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>'>
				</asp:CheckBox></td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.VoteSubjectTypeInfo.Text")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Title")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.BeginTime")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.EndTime")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.IsIp")%>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Passed")%>
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
