<%@ Control Language="C#" AutoEventWireup="True" Codebehind="SinglePageShow.ascx.cs" Inherits="ZhuJi.Modules.SinglePageModule.WebUI.SinglePageShow" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrSummary" runat="server" Text="ժҪ"></asp:Literal></td>
        <td>
            <asp:Literal ID="Summary" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrContent" runat="server" Text="����"></asp:Literal></td>
        <td>
            <asp:Literal ID="Content" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrKeyword" runat="server" Text="�ؼ���"></asp:Literal></td>
        <td>
            <asp:Literal ID="Keyword" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrPicture" runat="server" Text="˵��ͼƬ"></asp:Literal></td>
        <td>
            <asp:Literal ID="Picture" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrPassed" runat="server" Text="�Ƿ�ͨ��"></asp:Literal></td>
        <td>
            <asp:Literal ID="Passed" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrCreatedByUser" runat="server" Text="�ύ�û�"></asp:Literal></td>
        <td>
            <asp:Literal ID="CreatedByUser" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrCreatedByIp" runat="server" Text="�ύIP"></asp:Literal></td>
        <td>
            <asp:Literal ID="CreatedByIp" runat="server"></asp:Literal></td>
    </tr>
    <tr>
        <td style="width: 96px">
            <asp:Literal ID="ltrCreatedByDate" runat="server" Text="�ύ����"></asp:Literal></td>
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
