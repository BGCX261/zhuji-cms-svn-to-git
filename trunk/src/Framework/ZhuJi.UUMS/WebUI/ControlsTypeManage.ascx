<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ControlsTypeManage.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.ControlsTypeManage"  %>
<%@ Register Src="ControlsTypeList.ascx" TagName="ControlsTypeList" TagPrefix="uc1" %>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:ControlsTypeList id="ControlsTypeList1" runat="server" OrderNo="tmp.OrderBy"></uc1:ControlsTypeList>
</fieldset>
</asp:Panel>

