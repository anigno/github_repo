<%@ Page language="c#" Codebehind="header.aspx.cs" AutoEventWireup="false" Inherits="business.visitors.header" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML dir="rtl">
	<HEAD>
		<title>header</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblBusinessName" style="Z-INDEX: 100; LEFT: 104px; POSITION: absolute; TOP: 8px"
				runat="server" Width="506px" Font-Size="Medium"></asp:Label>
			<asp:Label id="lblCounter" style="Z-INDEX: 107; LEFT: 72px; POSITION: absolute; TOP: 48px"
				runat="server" Width="77px"></asp:Label>
			<asp:Image id="imgLogo" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Width="60px" Height="60px"></asp:Image>
			<asp:Label id="lblEmail" style="Z-INDEX: 104; LEFT: 168px; POSITION: absolute; TOP: 48px" runat="server"
				Width="240px"></asp:Label>&nbsp;
		</form>
	</body>
</HTML>
