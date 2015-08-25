<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="PermissionByCommonList.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.PermissionByCommonList" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<asp:Repeater ID="rptList" runat="server">
	<headertemplate>
      <table width="100%" border="0" cellpadding="0" cellspacing="0">
    </headertemplate>
    <itemtemplate>
      <tr>
         <td><asp:checkbox id="chkId" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>'></asp:checkbox></td>
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

