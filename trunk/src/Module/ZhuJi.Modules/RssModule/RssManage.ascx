<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="RssManage.ascx.cs" Inherits="ZhuJi.Modules.RssModule.WebUI.RssManage"  %>
<%@ Register Src="RssList.ascx" TagName="RssList" TagPrefix="uc1" %>
<asp:Panel ID="pnlTool" runat="server" Width="100%">
<fieldset>
<legend><asp:Literal ID="ltrTool" runat="server" Text="工具栏"></asp:Literal></legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
     <td>
         <asp:Button ID="btnFlush" runat="server" Text="列表" OnClick="btnFlush_Click" CausesValidation="False"/>
     </td>
  </tr>
</table>
</fieldset>
</asp:Panel>
<asp:Panel ID="pnlSearch" runat="server" Width="100%">
<fieldset>
<legend><asp:Literal ID="ltrSearch" runat="server" Text="搜索栏"></asp:Literal></legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
     <td>
     </td>
  </tr>
</table>
</fieldset>
</asp:Panel>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
	<uc1:RssList id="RssList1" runat="server">
	</uc1:RssList></fieldset>
</asp:Panel>

