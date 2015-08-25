<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="VoteSubjectTypeManage.ascx.cs" Inherits="ZhuJi.Modules.VoteModule.WebUI.VoteSubjectTypeManage"  %>
<%@ Register Src="VoteSubjectTypeList.ascx" TagName="VoteSubjectTypeList" TagPrefix="uc1" %>
<asp:Panel ID="pnlList" runat="server" Visible="False" Width="100%">
<fieldset>
    <legend><asp:Literal ID="ltrList" runat="server" Text="数据列表"></asp:Literal></legend>
    <uc1:VoteSubjectTypeList id="VoteSubjectTypeList1" runat="server"></uc1:VoteSubjectTypeList>
</fieldset>
</asp:Panel>

