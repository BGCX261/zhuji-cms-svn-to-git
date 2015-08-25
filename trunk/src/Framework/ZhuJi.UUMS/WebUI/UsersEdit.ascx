<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="UsersEdit.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.UsersEdit" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="width: 96px; height: 15px; text-align: right">
			&nbsp;
		</td>
		<td style="height: 15px">
			&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
				ShowSummary="False" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Username"
				Display="None" ErrorMessage="用户名称不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
	</tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><asp:Literal ID="ltrRolesId" runat="server" Text="用户角色："></asp:Literal></td>
	 <td>
         <asp:DropDownList ID="RolesId" runat="server">
         </asp:DropDownList></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;">
		 <span style="color: #ff0000">*</span><asp:Literal ID="ltrUsername" runat="server" Text="用户名称："></asp:Literal></td>
	 <td><asp:TextBox ID="Username" runat="server" Width="200px"></asp:TextBox>
         <asp:RequiredFieldValidator ID="rfvUsername" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="Username"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><asp:Literal ID="ltrPassword" runat="server" Text="用户密码："></asp:Literal></td>
	 <td><asp:TextBox ID="Password" runat="server" Width="200px"></asp:TextBox>
         <asp:CheckBox ID="cbPassword" runat="server" OnCheckedChanged="cbPassword_CheckedChanged"
             Text="修改密码" Visible="False" AutoPostBack="True" /></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><asp:Literal ID="ltrQuestion" runat="server" Text="问题："></asp:Literal></td>
	 <td><asp:TextBox ID="Question" runat="server" Width="200px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><asp:Literal ID="ltrAnswer" runat="server" Text="回答："></asp:Literal></td>
	 <td><asp:TextBox ID="Answer" runat="server" Width="200px"></asp:TextBox></td>
  </tr>
  <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrPassed" runat="server" Text="是否通过："></asp:Literal></td>
        <td>
            <asp:CheckBox ID="Passed" runat="server" Text="是否通过" /></td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrCreatedByUser" runat="server" Text="提交用户："></asp:Literal></td>
        <td>
            <asp:TextBox ID="CreatedByUser" runat="server" Width="150px" Enabled="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrCreatedByIp" runat="server" Text="提交IP地址："></asp:Literal></td>
        <td>
            <asp:TextBox ID="CreatedByIp" runat="server" Width="150px" Enabled="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrCreatedByDate" runat="server" Text="提交日期："></asp:Literal></td>
        <td>
            <asp:TextBox ID="CreatedByDate" runat="server" Width="150px" Enabled="False"></asp:TextBox></td>
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

