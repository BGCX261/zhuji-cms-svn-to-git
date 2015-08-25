<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ArticleEdit.ascx.cs"
    Inherits="ZhuJi.Modules.ArticleModule.WebUI.ArticleEdit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="width: 96px">
			&nbsp;</td>
		<td>
			&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
				ShowSummary="False" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Title"
				Display="None" ErrorMessage="标题不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
	</tr>
    <tr>
        <td style="width: 96px; text-align: right;">
			<span style="color: #ff0000">*</span><asp:Literal ID="ltrTitle" runat="server" Text="标题："></asp:Literal></td>
        <td>
            <asp:TextBox ID="Title" runat="server" Width="300px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrSummary" runat="server" Text="摘要："></asp:Literal></td>
        <td>
            <FCKeditorV2:FCKeditor ID="Summary" runat="server" BasePath="~/FCKeditor/" Height="100px"
                ToolbarSet="Basic">
            </FCKeditorV2:FCKeditor>
        </td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrContent" runat="server" Text="内容："></asp:Literal></td>
        <td>
            <FCKeditorV2:FCKeditor ID="Content" runat="server" BasePath="~/FCKeditor/" Height="350px">
            </FCKeditorV2:FCKeditor>
        </td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrAuthor" runat="server" Text="作者："></asp:Literal></td>
        <td>
            <asp:TextBox ID="Author" runat="server" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrCopyFrom" runat="server" Text="来源："></asp:Literal></td>
        <td>
            <asp:TextBox ID="CopyFrom" runat="server" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrKeyword" runat="server" Text="关键字："></asp:Literal></td>
        <td>
            <asp:TextBox ID="Keyword" runat="server" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 96px; text-align: right;">
            <asp:Literal ID="ltrPicture" runat="server" Text="说明图片："></asp:Literal></td>
        <td>
            <asp:TextBox ID="Picture" runat="server" Width="300px"></asp:TextBox>
        </td>
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
            <asp:Literal ID="ltrCreatedByIp" runat="server" Text="提交IP："></asp:Literal></td>
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
        <td style="width: 96px">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="False" />
            <asp:Button ID="btnEdit" runat="server" Text="更新" OnClick="btnEdit_Click" Visible="False" />
            <asp:Button ID="btnDel" runat="server" Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;" OnClick="btnDel_Click" Visible="False"
                CausesValidation="False" />&nbsp;
            <asp:TextBox ID="Id" runat="server" Visible="False" Width="16px"></asp:TextBox>
            <asp:TextBox ID="ContentBaseId" runat="server" Visible="False" Width="1px"></asp:TextBox>
            <asp:TextBox ID="ChannelId" runat="server" Visible="False" Width="9px">0</asp:TextBox>
            <asp:TextBox ID="SkinId" runat="server" Visible="False" Width="1px">0</asp:TextBox>
            <asp:TextBox ID="Hits" runat="server" Visible="False" Width="1px">0</asp:TextBox>
            <asp:TextBox ID="Comments" runat="server" Visible="False" Width="1px">0</asp:TextBox>
            <asp:TextBox ID="Recommends" runat="server" Visible="False" Width="1px">0</asp:TextBox>
            <asp:TextBox ID="Collections" runat="server" Visible="False" Width="1px">0</asp:TextBox>
            <asp:TextBox ID="Votes" runat="server" Visible="False" Width="1px">0</asp:TextBox></td>
    </tr>
</table>
