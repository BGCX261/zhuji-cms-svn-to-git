<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ResourcesList.ascx.cs" Inherits="ZhuJi.UUMS.WebUI.ResourcesList" %>
<asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvList_RowCancelingEdit"
	OnRowDeleting="gvList_RowDeleting" OnRowEditing="gvList_RowEditing" OnRowUpdating="gvList_RowUpdating"
	Width="100%" ShowFooter="True">
	<Columns>
		<asp:BoundField DataField="Id" HeaderText="标识" ReadOnly="True">
			<ItemStyle HorizontalAlign="Center" Width="48px" />
		</asp:BoundField>
		<asp:TemplateField HeaderText="资源名称">
			<EditItemTemplate>
				<asp:TextBox ID="txtResourceName" runat="server" Text='<%# Bind("ResourceName") %>' Width="300px"></asp:TextBox>
			</EditItemTemplate>
			<ItemTemplate>
				<asp:Label ID="lblResourceName" runat="server" Text='<%# Bind("ResourceName") %>'></asp:Label>
			</ItemTemplate>
			<FooterTemplate>
			<asp:TextBox ID="txtResourceName" runat="server" Width="300px"></asp:TextBox>
			</FooterTemplate>
		</asp:TemplateField>
		<asp:TemplateField HeaderText="排序">
			<EditItemTemplate>
				<asp:TextBox ID="txtOrderBy" runat="server" Text='<%# Bind("OrderBy") %>' Width="100%"></asp:TextBox>
			</EditItemTemplate>
			<ItemStyle HorizontalAlign="Center" Width="48px" />
			<ItemTemplate>
				<asp:Label ID="lblOrderBy" runat="server" Text='<%# Bind("OrderBy") %>'></asp:Label>
			</ItemTemplate>
			<FooterStyle HorizontalAlign="Center" Width="48px" />
			<FooterTemplate>
			<asp:TextBox ID="txtOrderBy" runat="server" Width="48px"></asp:TextBox>
			</FooterTemplate>
		</asp:TemplateField>
		<asp:TemplateField ShowHeader="False">
			<EditItemTemplate>
				<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
					Text="更新"></asp:LinkButton>
				<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
					Text="取消"></asp:LinkButton>
				<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
					Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;"></asp:LinkButton>
			</EditItemTemplate>
			<ItemStyle HorizontalAlign="Center" Width="100px" />
			<ItemTemplate>
				<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
					Text="编辑"></asp:LinkButton>
				<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
					Text="删除" OnClientClick="javascript:return confirm('删除后不能恢复，是否确认删除？');return false;"></asp:LinkButton>
			</ItemTemplate>
			<FooterStyle HorizontalAlign="Center" Width="100px" />
			<FooterTemplate>
			<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" OnClick="gvList_RowInserting"
					Text="新建"></asp:LinkButton>
			</FooterTemplate>
		</asp:TemplateField>
	</Columns>
	<HeaderStyle Height="30px" />
</asp:GridView>
