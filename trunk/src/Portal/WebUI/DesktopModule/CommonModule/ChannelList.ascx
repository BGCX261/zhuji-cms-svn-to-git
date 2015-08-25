<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChannelList.ascx.cs" Inherits="ZhuJi.Portal.WebUI.DesktopModule.CommonModule.ChannelList" %>

<asp:TreeView ID="tvList" runat="server"
    ShowCheckBoxes="All" ShowLines="True" Width="100%" OnTreeNodePopulate="tvList_TreeNodePopulate">
    <NodeStyle Width="100%" />
</asp:TreeView>
