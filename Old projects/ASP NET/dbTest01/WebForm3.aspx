<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm3.aspx.vb" Inherits="dbTest01.WebForm3"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm3</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Repeater id="names" runat="server">
				<HeaderTemplate>
				<table border=1>
				</HeaderTemplate>
				<ItemTemplate>
			<tr>
			<td><%#Container.DataItem("iKey")%></td>
			<td><%#Container.DataItem("iName")%></td>
			<td><%#Container.DataItem("iId")%></td>
			</tr>
			
				</ItemTemplate>
				<FooterTemplate>
				</table>
				</FooterTemplate>
			
			</asp:Repeater>
		</form>
	</body>
</HTML>
