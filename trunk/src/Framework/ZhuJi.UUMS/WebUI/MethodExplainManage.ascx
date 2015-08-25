<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="MethodExplainManage.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.MethodExplainManage"  %>
<%@ Register Src="MethodExplainList.ascx" TagName="MethodExplainList" TagPrefix="uc1" %>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:MethodExplainList id="MethodExplainList1" runat="server" OrderNo="tmp.OrderBy"></uc1:MethodExplainList>
</fieldset>
</asp:Panel>

