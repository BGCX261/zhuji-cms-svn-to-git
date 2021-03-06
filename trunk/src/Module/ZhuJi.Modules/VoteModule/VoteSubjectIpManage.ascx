﻿<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="VoteSubjectIpManage.ascx.cs" Inherits="ZhuJi.Modules.VoteModule.WebUI.VoteSubjectIpManage"  %>
<%@ Register Src="VoteSubjectIpList.ascx" TagName="VoteSubjectIpList" TagPrefix="uc1" %>
<asp:Panel ID="pnlTool" runat="server" Width="100%">
<fieldset>
<legend><asp:Literal ID="ltrTool" runat="server" Text="工具栏"></asp:Literal></legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
     <td>
         <asp:Button ID="btnFlush" runat="server" Text="列表" OnClick="btnFlush_Click" CausesValidation="False"/>
         <asp:Button ID="btnDel" runat="server" Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;" OnClick="btnDel_Click" CausesValidation="False"/>
     </td>
  </tr>
</table>
</fieldset>
</asp:Panel>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:VoteSubjectIpList id="VoteSubjectIpList1" runat="server"></uc1:VoteSubjectIpList>
</fieldset>
</asp:Panel>

