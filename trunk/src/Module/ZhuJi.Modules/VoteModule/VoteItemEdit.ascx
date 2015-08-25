<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="VoteItemEdit.ascx.cs" Inherits="ZhuJi.Modules.VoteModule.WebUI.VoteItemEdit" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="width: 96px; height: 36px">
			&nbsp;</td>
		<td style="height: 36px">
			&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
				ShowSummary="False" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name"
				Display="None" ErrorMessage="选项标题不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Name"
				Display="None" ErrorMessage="投票数不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Name"
				Display="None" ErrorMessage="排序不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
	</tr>
	<tr>
		<td style="width: 96px; height: 36px; text-align: right;">
			<asp:Literal ID="ltrSubjectId" runat="server" Text="选择主题："></asp:Literal></td>
		<td style="height: 36px">
			<asp:DropDownList ID="SubjectId" runat="server">
			</asp:DropDownList></td>
	</tr>
  <tr>
	 <td style="width: 96px; height: 36px; text-align: right;">
		 <span style="color: #ff0000">*</span><asp:Literal ID="ltrTitle" runat="server" Text="选项标题："></asp:Literal></td>
	 <td style="height: 36px"><asp:TextBox ID="Title" runat="server" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; height: 36px; text-align: right;">
		 <span style="color: #ff0000">*</span><asp:Literal ID="ltrVotes" runat="server" Text="投票数："></asp:Literal></td>
	 <td>
		 <cc1:numericcontrol id="Votes" runat="server" width="68px"></cc1:numericcontrol>
	 </td>
  </tr>
  <tr>
	 <td style="width: 96px; height: 36px; text-align: right;">
		 <span style="color: #ff0000">*</span><asp:Literal ID="ltrOrders" runat="server" Text="排序："></asp:Literal></td>
	 <td>
		 <cc1:numericcontrol id="Orders" runat="server" width="68px"></cc1:numericcontrol>
	 </td>
  </tr>
  <tr>
	 <td style="width: 96px">&nbsp;</td>
	 <td>
         <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="False"/>
         <asp:Button ID="btnEdit" runat="server" Text="更新" OnClick="btnEdit_Click" Visible="False"/>
         <asp:Button ID="btnDel" runat="server" Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;" OnClick="btnDel_Click" Visible="False" CausesValidation="False"/>
         <asp:TextBox ID="Id" runat="server" Visible="False" Width="13px"></asp:TextBox></td>
  </tr>
</table>

