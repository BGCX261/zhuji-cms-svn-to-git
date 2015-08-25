<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ArticleShow.ascx.cs"
    Inherits="ZhuJi.Modules.ArticleModule.WebUI.ArticleShow" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrTitle" runat="server" Text="标题"></asp:Literal></td>
        <td>
            <asp:Literal ID="Title" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrSummary" runat="server" Text="摘要"></asp:Literal></td>
        <td>
           <asp:Literal ID="Summary" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrContent" runat="server" Text="内容"></asp:Literal></td>
        <td>
            <asp:Literal ID="Content" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrAuthor" runat="server" Text="作者"></asp:Literal></td>
        <td>
            <asp:Literal ID="Author" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrCopyFrom" runat="server" Text="来源"></asp:Literal></td>
        <td>
            <asp:Literal ID="CopyFrom" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrKeyword" runat="server" Text="关键字"></asp:Literal></td>
        <td>
            <asp:Literal ID="Keyword" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrPicture" runat="server" Text="说明图片"></asp:Literal></td>
        <td>
            <asp:Literal ID="Picture" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrPassed" runat="server" Text="是否通过"></asp:Literal></td>
        <td>
           <asp:Literal ID="Passed" runat="server"></asp:Literal> </td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrCreatedByUser" runat="server" Text="提交用户"></asp:Literal></td>
        <td>
            <asp:Literal ID="CreatedByUser" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrCreatedByIp" runat="server" Text="提交IP"></asp:Literal></td>
        <td>
            <asp:Literal ID="CreatedByIp" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrCreatedByDate" runat="server" Text="提交日期"></asp:Literal></td>
        <td>
            <asp:Literal ID="CreatedByDate" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            &nbsp;</td>
        <td>
            <asp:Literal ID="Id" runat="server" Visible="False"></asp:Literal>
            <asp:Literal ID="ContentBaseId" runat="server" Visible="False"></asp:Literal>
            <asp:Literal ID="ChannelId" runat="server" Visible="False"></asp:Literal>
            <asp:Literal ID="SkinId" runat="server" Visible="False"></asp:Literal>
            <asp:Literal ID="Hits" runat="server" Visible="False"></asp:Literal>
            <asp:Literal ID="Comments" runat="server" Visible="False"></asp:Literal>
            <asp:Literal ID="Recommends" runat="server" Visible="False"></asp:Literal>
            <asp:Literal ID="Collections" runat="server" Visible="False"></asp:Literal>
            <asp:Literal ID="Votes" runat="server" Visible="False"></asp:Literal></td>
    </tr>
</table>
