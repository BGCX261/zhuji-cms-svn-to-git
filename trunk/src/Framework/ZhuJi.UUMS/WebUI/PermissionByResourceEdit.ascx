<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="PermissionByResourceEdit.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.PermissionByResourceEdit" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
	 <td style="width: 96px"><asp:Literal ID="ltrRolesId" runat="server" Text="选择角色"></asp:Literal></td>
	 <td>
         <asp:DropDownList ID="RolesId" runat="server">
         </asp:DropDownList></td>
  </tr>
  <tr>
	 <td style="width: 96px"><asp:Literal ID="ltrResourcesId" runat="server" Text="选择资源"></asp:Literal></td>
	 <td>
         <asp:DropDownList ID="ResourcesId" runat="server">
         </asp:DropDownList></td>
  </tr>
  <tr>
	 <td style="width: 96px"><asp:Literal ID="ltrAllowed" runat="server" Text="是否允许"></asp:Literal></td>
	 <td>
         <asp:CheckBox ID="Allowed" runat="server" Text="是否允许" /></td>
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

