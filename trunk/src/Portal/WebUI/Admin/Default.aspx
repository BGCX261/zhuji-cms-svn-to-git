<%@ Page Language="C#" MasterPageFile="~/App_Master/Admin/Layout.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="ZhuJi.Portal.WebUI.Admin.Default" Theme="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContentMenu" runat="server">
    <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" Width="100%" OnTreeNodePopulate="TreeView1_TreeNodePopulate" Target="mainFrame" ExpandDepth="0">
    <NodeStyle Width="100%" />
</asp:TreeView>

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPluginMenu" runat="server">
    <asp:TreeView ID="TreeView2" runat="server" ShowLines="True" Width="100%" OnTreeNodePopulate="TreeView2_TreeNodePopulate" Target="mainFrame" ExpandDepth="0">
    <NodeStyle Width="100%" />
    </asp:TreeView>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <iframe name="mainFrame" src="" scrolling="no"
        width="98%" height="100%" frameborder="0" onload="document.all['mainFrame'].style.height=mainFrame.document.body.scrollHeight">
    </iframe>
</asp:Content>
