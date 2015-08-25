<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="PluginList.ascx.cs" Inherits="ZhuJi.Portal.WebUI.DesktopModule.CommonModule.PluginList" %>

<asp:TreeView ID="tvList" runat="server"
    ShowCheckBoxes="All" ShowLines="True" Width="100%" OnTreeNodePopulate="tvList_TreeNodePopulate">
    <NodeStyle Width="100%" />
</asp:TreeView>
