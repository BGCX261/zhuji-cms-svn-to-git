﻿<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="PermissionByResourceManage.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.PermissionByResourceManage"  %>
<%@ Register Src="PermissionByResourceList.ascx" TagName="PermissionByResourceList" TagPrefix="uc1" %>
<%@ Register Src="PermissionByResourceEdit.ascx" TagName="PermissionByResourceEdit" TagPrefix="uc2" %>
<asp:Panel ID="pnlTool" runat="server" Width="100%">
<fieldset>
<legend><asp:Literal ID="ltrTool" runat="server" Text="工具栏"></asp:Literal></legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
     <td>
         <asp:Button ID="btnFlush" runat="server" Text="列表" OnClick="btnFlush_Click" CausesValidation="False"/>
         <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" CausesValidation="False"/>
         <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click" CausesValidation="False"/>
         <asp:Button ID="btnDel" runat="server" Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;" OnClick="btnDel_Click" CausesValidation="False"/>
     </td>
  </tr>
</table>
</fieldset>
</asp:Panel>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:PermissionByResourceList id="PermissionByResourceList1" runat="server"></uc1:PermissionByResourceList>
</fieldset>
</asp:Panel>
<asp:Panel ID="pnlEdit" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrEdit" runat="server" Text="数据管理"></asp:Literal></legend>
    <uc2:PermissionByResourceEdit Id="PermissionByResourceEdit1" runat="server" />
</fieldset>
</asp:Panel>

