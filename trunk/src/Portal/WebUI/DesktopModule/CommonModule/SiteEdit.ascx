<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="SiteEdit.ascx.cs" Inherits="ZhuJi.Portal.WebUI.DesktopModule.CommonModule.SiteEdit" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="width: 96px">
			&nbsp;</td>
		<td>
			&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
				ShowSummary="False" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Title"
				Display="None" ErrorMessage="网站标题不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Url"
				Display="None" ErrorMessage="网站地址不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="OrderBy"
				Display="None" ErrorMessage="排序不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
	</tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><span style="color: #ff0000">*</span><asp:Literal ID="ltrTitle" runat="server" Text="网站标题："></asp:Literal></td>
	 <td><asp:TextBox ID="Title" runat="server" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><span style="color: #ff0000">*</span><asp:Literal ID="ltrUrl" runat="server" Text="网站地址："></asp:Literal></td>
	 <td><asp:TextBox ID="Url" runat="server" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><span style="color: #ff0000">*</span><asp:Literal ID="ltrOrderBy" runat="server" Text="排序："></asp:Literal></td>
	 <td>
		 <cc1:NumericControl ID="OrderBy" runat="server" Width="68px"></cc1:NumericControl></td>
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

