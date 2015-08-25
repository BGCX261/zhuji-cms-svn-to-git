<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="VoteSubjectIpList.ascx.cs" Inherits="ZhuJi.Modules.VoteModule.WebUI.VoteSubjectIpList" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<asp:Repeater ID="rptList" runat="server">
	<headertemplate>
      <table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr>
         <td>标识</td>
         <td>投票主题</td>
         <td>IP地址</td>
         <td>更新时间</td>
      </tr>
    </headertemplate>
    <itemtemplate>
      <tr>
         <td><asp:checkbox id="chkId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>'></asp:checkbox></td>
         <td><%# DataBinder.Eval(Container, "DataItem.VoteSubjectInfo.Title")%></td>
         <td><%# DataBinder.Eval(Container, "DataItem.Ip")%></td>
         <td><%# DataBinder.Eval(Container, "DataItem.AddTime")%></td>
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

