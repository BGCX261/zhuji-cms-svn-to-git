<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="PluginManage.ascx.cs" Inherits="ZhuJi.Portal.WebUI.DesktopModule.CommonModule.PluginManage"  %>
<%@ Register Src="PluginList.ascx" TagName="PluginList" TagPrefix="uc1" %>
<%@ Register Src="PluginEdit.ascx" TagName="PluginEdit" TagPrefix="uc2" %>
<asp:Panel ID="pnlTool" runat="server" Width="100%">
<fieldset>
<legend><asp:Literal ID="ltrTool" runat="server" Text="工具栏"></asp:Literal></legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
     <td>
         <asp:Button ID="btnFlush" runat="server" Text="列表" OnClick="btnFlush_Click" CausesValidation="False"/>
         <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" CausesValidation="False"/>
         <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click" CausesValidation="False"/>&nbsp;
     </td>
  </tr>
</table>
</fieldset>
</asp:Panel>
</asp:Panel>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:PluginList id="PluginList1" runat="server"></uc1:PluginList>
</fieldset>
</asp:Panel>
<asp:Panel ID="pnlEdit" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrEdit" runat="server" Text="数据管理"></asp:Literal></legend>
    <uc2:PluginEdit Id="PluginEdit1" runat="server" />
</fieldset>
</asp:Panel>

