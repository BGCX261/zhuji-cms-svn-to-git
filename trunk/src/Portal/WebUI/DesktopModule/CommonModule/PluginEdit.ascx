﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PluginEdit.ascx.cs" Inherits="ZhuJi.Portal.WebUI.DesktopModule.CommonModule.PluginEdit" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="width: 96px; height: 24px">
			&nbsp;</td>
		<td style="height: 24px">
			&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
				ShowSummary="False" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Keyword"
				Display="None" ErrorMessage="关键字不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Configure"
				Display="None" ErrorMessage="配置文件不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Title"
				Display="None" ErrorMessage="插件标题不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
	</tr>
  <tr>
	 <td style="width: 96px; height: 24px; text-align: right;"><span style="color: #ff0000">*</span><asp:Literal ID="ltrKeyword" runat="server" Text="关键字："></asp:Literal></td>
	 <td style="height: 24px"><asp:TextBox ID="Keyword" runat="server" Width="100px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; height: 24px; text-align: right;"><span style="color: #ff0000">*</span><asp:Literal ID="ltrConfigure" runat="server" Text="配置文件："></asp:Literal></td>
	 <td><asp:TextBox ID="Configure" runat="server" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; height: 24px; text-align: right;"><span style="color: #ff0000">*</span><asp:Literal ID="ltrTitle" runat="server" Text="插件标题："></asp:Literal></td>
	 <td><asp:TextBox ID="Title" runat="server" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; height: 24px; text-align: right;"><asp:Literal ID="ltrRemarks" runat="server" Text="插件说明："></asp:Literal></td>
	 <td style="height: 24px"><asp:TextBox ID="Remarks" runat="server" Width="300px"></asp:TextBox></td>
  </tr>
    <tr>
        <td rowspan="2" style="width: 96px; height: 24px; text-align: right;">
            <asp:Literal ID="ltrCurrentNode" runat="server" Text="参考目录："></asp:Literal></td>
        <td style="height: 22px">
            <asp:DropDownList ID="Parent" runat="server">
            </asp:DropDownList></td>
    </tr>
  <tr>
	 <td><asp:RadioButtonList ID="rblCurrentNode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
             <asp:ListItem Value="0">目录前</asp:ListItem>
             <asp:ListItem Value="1">目录后</asp:ListItem>
             <asp:ListItem Value="2" Selected="True">子目录</asp:ListItem>
         </asp:RadioButtonList></td>
  </tr>
  <tr>
	 <td style="width: 96px">&nbsp;</td>
	 <td>
         <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="False"/>
         <asp:Button ID="btnEdit" runat="server" Text="更新" OnClick="btnEdit_Click" Visible="False"/>
         <asp:Button ID="btnDel" runat="server" Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;" OnClick="btnDel_Click" Visible="False" CausesValidation="False"/>
         <asp:TextBox ID="Id" runat="server" Visible="False" Width="31px"></asp:TextBox>
         <asp:CheckBox ID="IsSystem" runat="server" Text="是否系统" Visible="False" />
         <asp:TextBox ID="Depth" runat="server" Visible="False" Width="31px">1</asp:TextBox>
         <asp:TextBox ID="OrderBy" runat="server" Visible="False" Width="31px">0</asp:TextBox><asp:TextBox
             ID="Url" runat="server" Visible="False" Width="31px">/</asp:TextBox><asp:TextBox
                 ID="Target" runat="server" Visible="False" Width="31px">_self</asp:TextBox>
         <asp:TextBox ID="Path" runat="server" Visible="False" Width="31px">0.</asp:TextBox>
         <asp:TextBox ID="Child" runat="server" Visible="False" Width="31px">0</asp:TextBox></td>
  </tr>
</table>

