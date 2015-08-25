<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="VoteSubjectEdit.ascx.cs" Inherits="ZhuJi.Modules.VoteModule.WebUI.VoteSubjectEdit" %>
<%@ Register Assembly="ZhuJi.Component" Namespace="ZhuJi.Component" TagPrefix="cc2" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="width: 96px">
			&nbsp;</td>
		<td>
			&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
				ShowSummary="False" />
			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Title"
				Display="None" ErrorMessage="标题不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="BeginTime"
				Display="None" ErrorMessage="开始时间不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EndTime"
				Display="None" ErrorMessage="结束时间不能为空！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
	</tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><asp:Literal ID="ltrVoteType" runat="server" Text="投票类型"></asp:Literal></td>
	 <td>
		 <asp:DropDownList ID="VoteType" runat="server">
		 </asp:DropDownList></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;">
		 <span style="color: #ff0000">*</span><asp:Literal ID="ltrTitle" runat="server" Text="标题"></asp:Literal></td>
	 <td><asp:TextBox ID="Title" runat="server" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><asp:Literal ID="ltrContent" runat="server" Text="内容"></asp:Literal></td>
	 <td><FCKeditorV2:FCKeditor ID="Content" runat="server" BasePath="~/FCKeditor/" Height="100px"
                ToolbarSet="Basic">
            </FCKeditorV2:FCKeditor></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;">
		 <span style="color: #ff0000">*</span><asp:Literal ID="ltrBeginTime" runat="server" Text="开始时间"></asp:Literal></td>
	 <td>
		 <cc2:datetimecontrol id="BeginTime" runat="server" Format="yyyy-MM-dd"></cc2:datetimecontrol></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;">
		 <span style="color: #ff0000">*</span><asp:Literal ID="ltrEndTime" runat="server" Text="结束时间"></asp:Literal></td>
	 <td>
		 <cc2:datetimecontrol id="EndTime" runat="server" Format="yyyy-MM-dd"></cc2:datetimecontrol></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><asp:Literal ID="ltrIsIp" runat="server" Text="是否IP地址"></asp:Literal></td>
	 <td>
		 <asp:CheckBox ID="IsIp" runat="server" Text="是否IP地址" /></td>
  </tr>
  <tr>
	 <td style="width: 96px; text-align: right;"><asp:Literal ID="ltrPassed" runat="server" Text="是否通过"></asp:Literal></td>
	 <td>
		 <asp:CheckBox ID="Passed" runat="server" Text="是否通过" /></td>
  </tr>
  <tr>
	 <td style="width: 96px">&nbsp;</td>
	 <td>
         <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" Visible="False"/>
         <asp:Button ID="btnEdit" runat="server" Text="更新" OnClick="btnEdit_Click" Visible="False"/>
         <asp:Button ID="btnDel" runat="server" Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;" OnClick="btnDel_Click" Visible="False" CausesValidation="False"/>
         <asp:TextBox ID="Id" runat="server" Visible="False" Width="31px"></asp:TextBox>
		 <asp:TextBox ID="TopicType" runat="server" Width="1px" Visible="False"></asp:TextBox>
         <asp:TextBox ID="TopicId" runat="server" Width="1px" Visible="False"></asp:TextBox></td>
  </tr>
</table>

