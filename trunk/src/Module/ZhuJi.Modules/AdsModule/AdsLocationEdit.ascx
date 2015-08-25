<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="AdsLocationEdit.ascx.cs" Inherits="ZhuJi.Modules.AdsModule.WebUI.AdsLocationEdit" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="width: 96px">
			&nbsp;</td>
		<td>
			&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
				ShowSummary="False" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name"
				Display="None" ErrorMessage="版位名称不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Width"
				Display="None" ErrorMessage="宽不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Height"
				Display="None" ErrorMessage="高不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
	</tr>
  <tr>
	 <td style="width: 96px; text-align: right;">
		 <span style="color: #ff0000">*</span><asp:Literal ID="ltrName" runat="server" Text="版位名称："></asp:Literal></td>
	 <td><asp:TextBox ID="Name" runat="server" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><asp:Literal ID="ltrType" runat="server" Text="版位类型："></asp:Literal></td>
	 <td>
		 <asp:DropDownList ID="Type" runat="server">
		 </asp:DropDownList></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;">
		 <span style="color: #ff0000">*</span><asp:Literal ID="ltrWidth" runat="server" Text="版位宽高："></asp:Literal></td>
	 <td>
		 <cc1:numericcontrol id="Width" runat="server" width="68px"></cc1:numericcontrol>X<cc1:numericcontrol id="Height" runat="server" width="68px"></cc1:numericcontrol></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><asp:Literal ID="ltrIspass" runat="server" Text="版位状态："></asp:Literal></td>
	 <td>
		 <asp:CheckBox ID="Ispass" runat="server" /></td>
  </tr>
  <tr>
	 <td style="width: 96px">&nbsp;</td>
	 <td>
         <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="False"/>
         <asp:Button ID="btnEdit" runat="server" Text="更新" OnClick="btnEdit_Click" Visible="False"/>
         <asp:Button ID="btnDel" runat="server" Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;" OnClick="btnDel_Click" Visible="False" CausesValidation="False"/>
         <asp:TextBox ID="Id" runat="server" Visible="False" Width="31px"></asp:TextBox></td>
  </tr>
</table>

