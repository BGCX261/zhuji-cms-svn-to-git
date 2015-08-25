<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="SinglePageManage.ascx.cs" Inherits="ZhuJi.Modules.SinglePageModule.WebUI.SinglePageManage"  %>
<%@ Register Src="SinglePageEdit.ascx" TagName="SinglePageEdit" TagPrefix="uc2" %>
<asp:Panel ID="pnlTool" runat="server" Width="100%">
<fieldset>
<legend><asp:Literal ID="ltrTool" runat="server" Text="工具栏"></asp:Literal></legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
     <td>
         <asp:Button ID="btnFlush" runat="server" Text="列表" OnClick="btnFlush_Click" CausesValidation="False"/>
         <asp:TextBox ID="ChannelId" runat="server" Visible="False" Width="1px">0</asp:TextBox></td>
  </tr>
</table>
</fieldset>
</asp:Panel>
<asp:Panel ID="pnlEdit" runat="server" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrEdit" runat="server" Text="数据管理"></asp:Literal></legend>
    <uc2:SinglePageEdit Id="SinglePageEdit1" runat="server" />
</fieldset>
</asp:Panel>

