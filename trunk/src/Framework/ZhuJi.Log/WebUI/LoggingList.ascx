<%@ Control Language="C#" AutoEventWireup="True" Codebehind="LoggingList.ascx.cs"
	Inherits="ZhuJi.Log.WebUI.LoggingList" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>

<script type="text/javascript">
<!--
function dsp(id,loc)
{
    var foc=loc.firstChild.innerHTML?loc.firstChild:loc.firstChild.nextSibling;
    foc.innerHTML=(foc.innerHTML=='显示详细')?'隐藏详细':'显示详细';
    var obj = document.getElementById(id);
    obj.style.display=obj.style.display=='block'?'none':'block';
    parent.document.all['mainFrame'].style.height=parent.mainFrame.document.body.scrollHeight
}
//-->
</script>

<asp:Repeater ID="rptList" runat="server">
	<HeaderTemplate>
		<table width="100%" border="0" cellpadding="0" cellspacing="0" class="nfgrid">
			<tr class="nfgridheader">
				<td>
					标识</td>
				<td>
					类型</td>
				<td>
					时间</td>
				<td>
					来源</td>
				<td>
					类别</td>
				<td>
					用户</td>
				<td>
					IP</td>
				<td>
					&nbsp;</td>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr class="nfgriditem">
			<td>
				<asp:CheckBox ID="chkId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>'>
				</asp:CheckBox></td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Type") %>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.CreatedByDate") %>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Source") %>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.Class") %>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.CreatedByUser") %>
			</td>
			<td>
				<%# DataBinder.Eval(Container, "DataItem.CreatedByIp") %>
			</td>
			<td width="48px">
				<a href="#" onclick="dsp('tr<%# DataBinder.Eval(Container, "DataItem.Id") %>',this)">
					<span>显示详细</span></a></td>
		</tr>
		<tr style="display: none;" id="tr<%# DataBinder.Eval(Container, "DataItem.Id") %>">
			<td colspan="8">
				<%# DataBinder.Eval(Container, "DataItem.Description") %>
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
