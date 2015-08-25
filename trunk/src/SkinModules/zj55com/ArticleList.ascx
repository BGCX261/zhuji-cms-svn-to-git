<%@ Control Language="C#" AutoEventWireup="True" Inherits="ZhuJi.Modules.ArticleModule.WebUI.ArticleList" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<asp:Repeater ID="rptList" runat="server">
	<headertemplate>
      <table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr class="title01">
         <td>标题</td>
         <td>日期</td>
      </tr>
    </headertemplate>
    <itemtemplate>
      <tr>
         <td height="25px"><img src="~/App_Themes/page/dian2.gif" runat="server" /><a href="s<%=Request["Id"] %>.aspx?aid=<%# DataBinder.Eval(Container, "DataItem.Id") %>"><%# DataBinder.Eval(Container, "DataItem.Title") %></a></td>
         <td width="80px" align="center"><%# DataBinder.Eval(Container, "DataItem.ContentBaseInfo.CreatedByDate","{0:yyyy-MM-dd}")%></td>         
      </tr>
      <tr class="line01"><td colspan="2"></td></tr>
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