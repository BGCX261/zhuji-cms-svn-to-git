<%@ Control Language="C#" AutoEventWireup="True" Codebehind="ControlsEdit.ascx.cs"
    Inherits="ZhuJi.UUMS.WebUI.ControlsEdit" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="width: 96px">
			&nbsp;</td>
		<td>
			&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
				ShowSummary="False" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PageName"
				Display="None" ErrorMessage="内容名称不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ControlName"
				Display="None" ErrorMessage="控件名称不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
	</tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrResourcesId" runat="server" Text="选择资源："></asp:Literal></td>
        <td>
            <asp:DropDownList ID="ResourcesId" runat="server">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
			<span style="color: #ff0000">*</span><asp:Literal ID="ltrPageName" runat="server" Text="页名称："></asp:Literal></td>
        <td>
            <asp:TextBox ID="PageName" runat="server" Width="150px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
			<span style="color: #ff0000">*</span><asp:Literal ID="ltrControlName" runat="server" Text="控件名称："></asp:Literal></td>
        <td>
            <asp:TextBox ID="ControlName" runat="server" Width="150px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrControlType" runat="server" Text="控件类型："></asp:Literal></td>
        <td>
            <asp:DropDownList ID="ControlType" runat="server">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrAttribute" runat="server" Text="控件属性："></asp:Literal></td>
        <td>
            <asp:DropDownList ID="Attribute" runat="server">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 96px">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="False" />
            <asp:Button ID="btnEdit" runat="server" Text="更新" OnClick="btnEdit_Click" Visible="False" />
            <asp:Button ID="btnDel" runat="server" Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;" OnClick="btnDel_Click" Visible="False"
                CausesValidation="False" />
            <asp:TextBox ID="Id" runat="server" Visible="False" Width="31px"></asp:TextBox></td>
    </tr>
</table>
