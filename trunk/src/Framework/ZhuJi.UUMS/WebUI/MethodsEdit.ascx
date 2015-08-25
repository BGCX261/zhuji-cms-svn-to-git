<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="MethodsEdit.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.MethodsEdit" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="width: 96px; text-align: right">
			&nbsp;
		</td>
		<td>
			&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
				ShowSummary="False" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="MethodName"
				Display="None" ErrorMessage="方法名称不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ClassName"
				Display="None" ErrorMessage="类名不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
	</tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrExplainId" runat="server" Text="方法说明："></asp:Literal></td>
        <td>
            <asp:DropDownList ID="ExplainId" runat="server">
            </asp:DropDownList></td>
    </tr>
  <tr>
	 <td style="width: 96px; text-align: right;">
		 <span style="color: #ff0000">*</span><asp:Literal ID="ltrMethodName" runat="server" Text="方法名称："></asp:Literal></td>
	 <td><asp:TextBox ID="MethodName" runat="server" Width="150px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;">
		 <span style="color: #ff0000">*</span><asp:Literal ID="ltrClassName" runat="server" Text="类名："></asp:Literal></td>
	 <td><asp:TextBox ID="ClassName" runat="server" Width="150px"></asp:TextBox></td>
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

