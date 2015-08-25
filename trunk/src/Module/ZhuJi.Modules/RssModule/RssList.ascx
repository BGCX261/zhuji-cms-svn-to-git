<%@ Control Language="C#" AutoEventWireup="true" Codebehind="RssList.ascx.cs" Inherits="ZhuJi.Modules.RssModule.WebUI.RssList" %>
<?xml version="1.0" encoding="utf-8" ?>
<rss version="2.0">
	<channel>
		<title><asp:Literal ID="Title" runat="server"></asp:Literal></title>
		<image><asp:Literal ID="Image" runat="server"></asp:Literal></image>
		<description><asp:Literal ID="Description" runat="server"></asp:Literal></description>
		<link><asp:Literal ID="Link" runat="server"></asp:Literal></link>
		<language><asp:Literal ID="Language" runat="server"></asp:Literal></language>
		<docs><asp:Literal ID="Docs" runat="server"></asp:Literal></docs>
		<generator><asp:Literal ID="Generator" runat="server"></asp:Literal></generator>
		<ttl><asp:Literal ID="Ttl" runat="server"></asp:Literal></ttl>
	<asp:Repeater ID="rptList" runat="server">
		<ItemTemplate>
			<item>
				<title><%# DataBinder.Eval(Container, "DataItem.Title")%></title>
				<link><%# DataBinder.Eval(Container, "DataItem.Link")%></link>
				<pubDate><%# DataBinder.Eval(Container, "DataItem.PubDate")%></pubDate>
				<source><%# DataBinder.Eval(Container, "DataItem.Source")%></source>
				<author><%# DataBinder.Eval(Container, "DataItem.Author")%></author>
				<description><%# DataBinder.Eval(Container, "DataItem.Description")%></description>
			</item>
		</ItemTemplate>
	</asp:Repeater>
	</channel>
</rss>
