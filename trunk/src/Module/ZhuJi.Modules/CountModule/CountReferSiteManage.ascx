<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="CountReferSiteManage.ascx.cs" Inherits="ZhuJi.Modules.CountModule.WebUI.CountReferSiteManage"  %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<%@ Register Src="CountReferSiteList.ascx" TagName="CountReferSiteList" TagPrefix="uc1" %>
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
		 &nbsp;开始日期：<cc1:DateTimeControl ID="txtBeginTime" runat="server" Format="yyyy-MM-dd"></cc1:DateTimeControl>
		 结束日期：<cc1:DateTimeControl ID="txtEndTime" runat="server" Format="yyyy-MM-dd"></cc1:DateTimeControl>
		 <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" /></td>
  </tr>
</table>
	<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
		ShowSummary="False" />
	<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="结束日期必须大于开始日期！" ControlToCompare="txtBeginTime" ControlToValidate="txtEndTime" Display="None" Operator="GreaterThan" SetFocusOnError="True" Type="Date"></asp:CompareValidator></fieldset>
</asp:Panel>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:CountReferSiteList id="CountReferSiteList1" runat="server"></uc1:CountReferSiteList>
</fieldset>
</asp:Panel>
