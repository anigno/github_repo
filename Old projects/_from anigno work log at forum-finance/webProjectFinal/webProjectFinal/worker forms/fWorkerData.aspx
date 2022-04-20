<%@ Page language="c#" Codebehind="fWorkerData.aspx.cs" AutoEventWireup="false" Inherits="webProjectFinal.fWorkerData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fWorkerData</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" type="text/css" href="../style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 176px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Worker data</asp:label>
			<asp:RequiredFieldValidator id="RequiredFieldValidator4" style="Z-INDEX: 117; LEFT: 168px; POSITION: absolute; TOP: 320px"
				runat="server" ControlToValidate="lstWorkerID" ErrorMessage="Select ID!"></asp:RequiredFieldValidator>
			<asp:RangeValidator id="RangeValidator1" style="Z-INDEX: 116; LEFT: 536px; POSITION: absolute; TOP: 104px"
				runat="server" ErrorMessage="Value?" ControlToValidate="txtBaseHourRate" MinimumValue="0" MaximumValue="999999"
				Type="Double"></asp:RangeValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator3" style="Z-INDEX: 115; LEFT: 464px; POSITION: absolute; TOP: 104px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtBaseHourRate"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" style="Z-INDEX: 114; LEFT: 464px; POSITION: absolute; TOP: 72px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" style="Z-INDEX: 113; LEFT: 464px; POSITION: absolute; TOP: 40px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
			<asp:Button id="btnDelete" style="Z-INDEX: 112; LEFT: 448px; POSITION: absolute; TOP: 176px"
				runat="server" Text="Delete" Width="64px" tabIndex="6"></asp:Button><asp:button id="btnUpdate" style="Z-INDEX: 111; LEFT: 312px; POSITION: absolute; TOP: 176px"
				runat="server" Text="Update data" Width="120px" tabIndex="5"></asp:button><asp:listbox id="lstWorkerID" style="Z-INDEX: 110; LEFT: 8px; POSITION: absolute; TOP: 40px"
				runat="server" Height="312px" Width="152px" AutoPostBack="True" tabIndex="7"></asp:listbox><asp:label id="Label5" style="Z-INDEX: 109; LEFT: 200px; POSITION: absolute; TOP: 136px" runat="server">worker ID:</asp:label><asp:label id="Label4" style="Z-INDEX: 108; LEFT: 164px; POSITION: absolute; TOP: 104px" runat="server">Base hour rate:</asp:label><asp:label id="Label3" style="Z-INDEX: 107; LEFT: 203px; POSITION: absolute; TOP: 72px" runat="server">Last name:</asp:label><asp:label id="Label2" style="Z-INDEX: 106; LEFT: 199px; POSITION: absolute; TOP: 40px" runat="server">First name:</asp:label><asp:textbox id="txtID" style="Z-INDEX: 105; LEFT: 312px; POSITION: absolute; TOP: 136px" runat="server"
				Enabled="False" tabIndex="4" Width="144px" TextMode="MultiLine" Rows="1"></asp:textbox><asp:textbox id="txtBaseHourRate" style="Z-INDEX: 104; LEFT: 312px; POSITION: absolute; TOP: 104px"
				runat="server" tabIndex="3" Width="144px" TextMode="MultiLine" Rows="1"></asp:textbox><asp:textbox id="txtLastName" style="Z-INDEX: 103; LEFT: 312px; POSITION: absolute; TOP: 72px"
				runat="server" tabIndex="2" Width="144px" TextMode="MultiLine" Rows="1"></asp:textbox><asp:textbox id="txtFirstName" style="Z-INDEX: 102; LEFT: 312px; POSITION: absolute; TOP: 40px"
				runat="server" tabIndex="1" Width="144px" TextMode="MultiLine" Rows="1"></asp:textbox></form>
	</body>
</HTML>
