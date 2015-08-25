<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="AdsLocationTypeManage.ascx.cs" Inherits="ZhuJi.Modules.AdsModule.WebUI.AdsLocationTypeManage"  %>
<%@ Register Src="AdsLocationTypeList.ascx" TagName="AdsLocationTypeList" TagPrefix="uc1" %>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:AdsLocationTypeList id="AdsLocationTypeList1" runat="server" OrderNo="tmp.OrderBy"></uc1:AdsLocationTypeList>
</fieldset>
</asp:Panel>

