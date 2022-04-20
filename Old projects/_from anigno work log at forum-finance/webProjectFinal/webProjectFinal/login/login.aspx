<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="false" Inherits="webProjectFinal.login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>default</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:textbox id="txtWorkerID" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 112px"
				tabIndex="1" runat="server" Width="104px"></asp:textbox>
			<asp:Label id="lblCounter" style="Z-INDEX: 108; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Width="32px">0</asp:Label><asp:label id="lblLoginAllow" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 280px"
				runat="server" Width="112px" Visible="False" ForeColor="Red" Height="56px">Only one login allow!</asp:label><asp:button id="btnLogIn" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 240px" tabIndex="3"
				runat="server" Width="72px" Text="Log in"></asp:button><asp:label id="Label3" style="Z-INDEX: 105; LEFT: 24px; POSITION: absolute; TOP: 56px" runat="server"
				Font-Underline="True">Log in</asp:label><asp:label id="Label2" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 144px" runat="server"
				Width="104px">Admin password:</asp:label><asp:label id="Label1" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 88px" runat="server">Worker ID:</asp:label>
			<asp:TextBox id="txtPassword" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 200px"
				runat="server" Width="104px" TextMode="Password" tabIndex="2"></asp:TextBox></form>
	</body>
</HTML>
