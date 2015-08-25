<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ControlsAttributeManage.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.ControlsAttributeManage"  %>
<%@ Register Src="ControlsAttributeList.ascx" TagName="ControlsAttributeList" TagPrefix="uc1" %>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:ControlsAttributeList id="ControlsAttributeList1" runat="server" OrderNo="tmp.OrderBy"></uc1:ControlsAttributeList>
</fieldset>
</asp:Panel>

