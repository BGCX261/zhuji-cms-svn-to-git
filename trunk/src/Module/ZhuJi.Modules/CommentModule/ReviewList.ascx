<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ReviewList.ascx.cs" Inherits="ZhuJi.Modules.CommentModule.WebUI.ReviewList" %>
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
	<headertemplate>
      <table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr>
         <td>标识</td>
         <td>主题类型</td>
         <td>标题</td>
         <td>发表时间</td>
         <td>是否隐藏</td>
         <td>用户</td>
         <td>IP</td>
         <td>&nbsp;</td>
      </tr>
    </headertemplate>
    <itemtemplate>
      <tr>
         <td><asp:checkbox id="chkId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>'></asp:checkbox></td>
         <td><%# DataBinder.Eval(Container, "DataItem.TopicType") %></td>
         <td><%# DataBinder.Eval(Container, "DataItem.Title") %></td>
         <td><%# DataBinder.Eval(Container, "DataItem.PostDate") %></td>
         <td><%# DataBinder.Eval(Container, "DataItem.IsHidden") %></td>
         <td><%# DataBinder.Eval(Container, "DataItem.CreatedByUser") %></td>
         <td><%# DataBinder.Eval(Container, "DataItem.CreatedByIp") %></td>
         <td width="48px"><a href="#" onclick="dsp('tr<%# DataBinder.Eval(Container, "DataItem.Id") %>',this)"><span>隐藏详细</span></a></td>
      </tr>
      <tr style="display:block;" id="tr<%# DataBinder.Eval(Container, "DataItem.Id") %>">
         <td colspan="8"><%# DataBinder.Eval(Container, "DataItem.Description") %></td>
      </tr>
	</itemtemplate>
	<footertemplate>
	  </table>
	</footertemplate>
</asp:Repeater>
<cc1:SimplePager ID="simplePager" runat="server" Visible="false">
    <ItemTemplate>
       <%#Container.FirstPage%>
       <%#Container.PrevPage%>
       <%#Container.ListPages%>
       <%#Container.NextPage%>
       <%#Container.LastPage%>
       <%#Container.PageSize%>记录/页
       共<%#Container.RecordCount%>记录
       <%#Container.CurrentPage%>/<%#Container.PageCount%>页
       </ItemTemplate>
</cc1:SimplePager>

