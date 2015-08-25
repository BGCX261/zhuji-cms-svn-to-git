<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="PermissionByCommonEdit.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.PermissionByCommonEdit" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
	 <td style="width: 96px"><asp:Literal ID="ltrRolesId" runat="server" Text="RolesId"></asp:Literal></td>
	 <td><asp:TextBox ID="RolesId" runat="server" Width="150px"></asp:TextBox>
         <asp:RequiredFieldValidator ID="rfvRolesId" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="RolesId"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
	 <td style="width: 96px"><asp:Literal ID="ltrSearchALL" runat="server" Text="SearchALL"></asp:Literal></td>
	 <td><asp:TextBox ID="SearchALL" runat="server" Width="150px"></asp:TextBox>
         <asp:RequiredFieldValidator ID="rfvSearchALL" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="SearchALL"></asp:RequiredFieldValidator></td>
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

