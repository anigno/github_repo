<%@ Page language="c#" Codebehind="fWorkerReport.aspx.cs" AutoEventWireup="false" Inherits="webProjectFinal.reports.fWorkerReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fWorkerReport</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="../style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:ListBox id="lstWorkerID" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 48px"
				runat="server" Width="144px" Height="312px" tabIndex="4"></asp:ListBox>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" style="Z-INDEX: 110; LEFT: 24px; POSITION: absolute; TOP: 368px"
				runat="server" ErrorMessage="Select ID!" ControlToValidate="lstWorkerID"></asp:RequiredFieldValidator>
			<asp:Label id="lblWorkerID" style="Z-INDEX: 109; LEFT: 16px; POSITION: absolute; TOP: 16px"
				runat="server"></asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 108; LEFT: 248px; POSITION: absolute; TOP: 40px" runat="server">Month:</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 107; LEFT: 264px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Worker report</asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 106; LEFT: 176px; POSITION: absolute; TOP: 40px" runat="server">Year:</asp:Label>
			<asp:Button id="btnCreate" style="Z-INDEX: 105; LEFT: 168px; POSITION: absolute; TOP: 104px"
				runat="server" Text="Create report" Width="128px" tabIndex="3"></asp:Button>
			<asp:DropDownList id="drpMonth" style="Z-INDEX: 104; LEFT: 256px; POSITION: absolute; TOP: 64px" runat="server"
				Width="40px" tabIndex="2"></asp:DropDownList>
			<asp:DropDownList id="drpYear" style="Z-INDEX: 103; LEFT: 168px; POSITION: absolute; TOP: 64px" runat="server"
				Width="64px" tabIndex="1"></asp:DropDownList>
			<asp:ListBox id="lstReport" style="Z-INDEX: 102; LEFT: 168px; POSITION: absolute; TOP: 144px"
				runat="server" Width="240px" Height="216px" tabIndex="5"></asp:ListBox>
		</form>
	</body>
</HTML>
