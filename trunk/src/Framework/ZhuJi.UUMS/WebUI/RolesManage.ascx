<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="RolesManage.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.RolesManage"  %>
<%@ Register Src="RolesList.ascx" TagName="RolesList" TagPrefix="uc1" %>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:RolesList id="RolesList1" runat="server" OrderNo="tmp.OrderBy"></uc1:RolesList>
</fieldset>
</asp:Panel>

