<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="ZhuJi.SSO._Default" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>逐迹内容管理系统</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><style type="text/css">
<!--
body {
	background-image: url(Images/main_bg.gif);
	background-repeat: repeat-x;
}
-->
</style></head>
<body>
    <form id="form1" runat="server">
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <table width="600" height="400" border="0" align="center" cellpadding="0" cellspacing="0" background="Images/login.png">
            <tr>
                <td width="120" rowspan="2">&nbsp;</td>
                <td width="480" style="height: 164px">&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
						ShowSummary="False" />
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUsername"
						Display="None" ErrorMessage="用户名称不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPassword"
						Display="None" ErrorMessage="用户密码不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCheckCode"
						Display="None" ErrorMessage="验证码不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="80" height="40">
					  用户名称：</td>
                  <td width="400"><asp:TextBox ID="tbUsername" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                  <td height="40">
					  用户密码：</td>
                  <td><asp:TextBox ID="tbPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox></td>
                </tr>
				  <tr>
					  <td height="40">
						  验 证 码：</td>
					  <td>
						  <asp:TextBox ID="txtCheckCode" runat="server" Width="132px"></asp:TextBox>
						  <IMG src="ValidateCode.aspx"></td>
				  </tr>
                <tr>
                  <td height="40">&nbsp;</td>
                  <td height="40"><asp:Button ID="bLogin" runat="server" Text="登录" OnClick="bLogin_Click" /></td>
                </tr>
              </table></td>
            </tr>
      </table>
    </form>
</body>
</html>
