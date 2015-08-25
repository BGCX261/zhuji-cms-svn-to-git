<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="AdsInforManage.ascx.cs" Inherits="ZhuJi.Modules.AdsModule.WebUI.AdsInforManage"  %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<%@ Register Src="AdsInforList.ascx" TagName="AdsInforList" TagPrefix="uc1" %>
<%@ Register Src="AdsInforEdit.ascx" TagName="AdsInforEdit" TagPrefix="uc2" %>
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
<asp:Panel ID="pnlSearch" runat="server" Width="100%">
<fieldset>
<legend><asp:Literal ID="ltrSearch" runat="server" Text="搜索栏"></asp:Literal></legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
     <td>
		 &nbsp;开播日期：<cc1:DateTimeControl ID="txtBeginTime" runat="server" Format="yyyy-MM-dd"></cc1:DateTimeControl>
		 到<cc1:DateTimeControl ID="txtEndTime" runat="server" Format="yyyy-MM-dd"></cc1:DateTimeControl>
		 </td>
  </tr>
	<tr>
		<td>
			&nbsp;广告名称：<asp:TextBox ID="txtName" runat="server" Width="284px"></asp:TextBox>
		 <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" /></td>
	</tr>
</table>
	<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
		ShowSummary="False" />
	<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="开播结束日期必须大于开播开始日期！" ControlToCompare="txtBeginTime" ControlToValidate="txtEndTime" Display="None" Operator="GreaterThan" SetFocusOnError="True" Type="Date"></asp:CompareValidator></fieldset>
</asp:Panel>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:AdsInforList id="AdsInforList1" runat="server"></uc1:AdsInforList>
</fieldset>
</asp:Panel>
<asp:Panel ID="pnlEdit" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrEdit" runat="server" Text="数据管理"></asp:Literal></legend>
    <uc2:AdsInforEdit Id="AdsInforEdit1" runat="server" />
</fieldset>
</asp:Panel>

