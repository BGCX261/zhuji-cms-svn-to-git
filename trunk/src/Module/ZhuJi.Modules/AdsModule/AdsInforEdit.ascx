<%@ Control Language="C#" AutoEventWireup="True" Codebehind="AdsInforEdit.ascx.cs"
	Inherits="ZhuJi.Modules.AdsModule.WebUI.AdsInforEdit" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="width: 96px">
			&nbsp;</td>
		<td>
			&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
				ShowSummary="False" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name"
				Display="None" ErrorMessage="广告名称不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
	</tr>
	<tr>
		<td style="width: 96px; text-align: right;">
			<asp:Literal ID="ltrLocation" runat="server" Text="所属版位："></asp:Literal></td>
		<td>
			<asp:DropDownList ID="Location" runat="server">
			</asp:DropDownList></td>
	</tr>
	<tr>
		<td style="width: 96px; text-align: right;">
			<span style="color: #ff0000">*</span><asp:Literal ID="ltrName" runat="server" Text="广告名称："></asp:Literal></td>
		<td>
			<asp:TextBox ID="Name" runat="server" Width="300px"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 96px; text-align: right;">
			<asp:Literal ID="ltrContent" runat="server" Text="广告内容："></asp:Literal></td>
		<td>
			<FCKeditorV2:FCKeditor ID="Content" runat="server" BasePath="~/FCKeditor/" Height="100px"
				ToolbarSet="Basic">
			</FCKeditorV2:FCKeditor>
		</td>
	</tr>
	<tr>
		<td style="width: 96px; text-align: right;">
			<asp:Literal ID="ltrHots" runat="server" Text="权重："></asp:Literal></td>
		<td>
			<?xml namespace="" prefix="SOAP-ENV" ?>
			<soap-env:envelope soap-env:encodingstyle="http://schemas.xmlsoap.org/soap/encoding/"
				xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" xmlns:soap-enc="http://schemas.xmlsoap.org/soap/encoding/"
				xmlns:soap-env="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsd="http://www.w3.org/2001/XMLSchema"
				xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
				<cc1:numericcontrol id="Hots" runat="server" width="68px"></cc1:numericcontrol>
			</soap-env:envelope></td>
	</tr>
	<tr>
		<td style="width: 96px; height: 24px; text-align: right;">
			<asp:Literal ID="ltrRegisterTime" runat="server" Text="受理日期："></asp:Literal></td>
		<td style="height: 24px">
			<cc1:datetimecontrol id="RegisterTime" runat="server" format="yyyy-MM-dd" width="150px"></cc1:datetimecontrol>
		</td>
	</tr>
	<tr>
		<td style="width: 96px; text-align: right;">
			<asp:Literal ID="ltrBeginTime" runat="server" Text="开播日期："></asp:Literal></td>
		<td>
			<cc1:datetimecontrol id="BeginTime" runat="server" format="yyyy-MM-dd" width="150px"></cc1:datetimecontrol>
		</td>
	</tr>
	<tr>
		<td style="width: 96px; text-align: right;">
			<asp:Literal ID="ltrEndTime" runat="server" Text="停播日期："></asp:Literal></td>
		<td>
			<cc1:datetimecontrol id="EndTime" runat="server" format="yyyy-MM-dd" width="150px"></cc1:datetimecontrol>
		</td>
	</tr>
	<tr>
		<td style="width: 96px; text-align: right;">
			<asp:Literal ID="ltrCustomerUnits" runat="server" Text="客户单位："></asp:Literal></td>
		<td>
			<asp:TextBox ID="CustomerUnits" runat="server" Width="300px"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 96px; text-align: right;">
			<asp:Literal ID="ltrCustomerPerson" runat="server" Text="联系人："></asp:Literal></td>
		<td>
			<asp:TextBox ID="CustomerPerson" runat="server" Width="300px"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 96px; text-align: right;">
			<asp:Literal ID="ltrCustomerContact" runat="server" Text="联系方法："></asp:Literal></td>
		<td>
			<asp:TextBox ID="CustomerContact" runat="server" Width="300px" Height="120px" TextMode="MultiLine"></asp:TextBox></td>
	</tr>
	<tr>
		<td style="width: 96px">
			&nbsp;</td>
		<td>
			<asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="False" />
			<asp:Button ID="btnEdit" runat="server" Text="更新" OnClick="btnEdit_Click" Visible="False" />
			<asp:Button ID="btnDel" runat="server" Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;"
				OnClick="btnDel_Click" Visible="False" CausesValidation="False" />
			<asp:TextBox ID="Id" runat="server" Visible="False" Width="31px"></asp:TextBox></td>
	</tr>
</table>
