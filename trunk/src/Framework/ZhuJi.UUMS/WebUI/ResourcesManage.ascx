<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ResourcesManage.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.ResourcesManage"  %>
<%@ Register Src="ResourcesList.ascx" TagName="ResourcesList" TagPrefix="uc1" %>

<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:ResourcesList id="ResourcesList1" runat="server" OrderNo="tmp.OrderBy"></uc1:ResourcesList>
</fieldset>
</asp:Panel>

