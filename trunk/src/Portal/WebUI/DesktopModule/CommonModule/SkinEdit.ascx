<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SkinEdit.ascx.cs" Inherits="ZhuJi.Portal.WebUI.DesktopModule.CommonModule.SkinEdit" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="width: 96px">
			&nbsp;</td>
		<td>
			&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
				ShowSummary="False" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name"
				Display="None" ErrorMessage="皮肤名称不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Style"
				Display="None" ErrorMessage="系统样式不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Master"
				Display="None" ErrorMessage="系统母版页不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="OrderBy"
				Display="None" ErrorMessage="排序不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
	</tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><span style="color: #ff0000">*</span><asp:Literal ID="ltrName" runat="server" Text="皮肤名称："></asp:Literal></td>
	 <td><asp:TextBox ID="Name" runat="server" Width="150px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><asp:Literal ID="ltrXsl" runat="server" Text="XSL皮肤："></asp:Literal></td>
	 <td><asp:TextBox ID="Xsl" runat="server" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; height: 36px; text-align: right;"><span style="color: #ff0000">*</span><asp:Literal ID="ltrStyle" runat="server" Text="系统的样式："></asp:Literal></td>
	 <td style="height: 36px"><asp:TextBox ID="Style" runat="server" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; height: 36px; text-align: right;"><span style="color: #ff0000">*</span><asp:Literal ID="ltrMaster" runat="server" Text="系统母版页："></asp:Literal></td>
	 <td style="height: 36px"><asp:TextBox ID="Master" runat="server" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><span style="color: #ff0000">*</span><asp:Literal ID="ltrOrderBy" runat="server" Text="排序："></asp:Literal></td>
	 <td><asp:TextBox ID="OrderBy" runat="server" Width="80px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px">&nbsp;</td>
	 <td>
         <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="False"/>
         <asp:Button ID="btnEdit" runat="server" Text="更新" OnClick="btnEdit_Click" Visible="False"/>
         <asp:Button ID="btnDel" runat="server" Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;" OnClick="btnDel_Click" Visible="False" CausesValidation="False"/>
         <asp:TextBox ID="Id" runat="server" Visible="False" Width="31px"></asp:TextBox></td>
  </tr>
</table>

