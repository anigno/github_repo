<%@ Page language="c#" Codebehind="fNewWorker.aspx.cs" AutoEventWireup="false" Inherits="webProjectFinal.fNewWorker" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fWorkers</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="../style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label5" style="Z-INDEX: 110; LEFT: 176px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Add new worker</asp:Label>
			<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 117; LEFT: 432px; POSITION: absolute; TOP: 136px"
				runat="server" ErrorMessage="9 Digits!" ControlToValidate="txtID" ValidationExpression="\d{9}"></asp:RegularExpressionValidator>
			<asp:RangeValidator id="RangeValidator1" style="Z-INDEX: 116; LEFT: 432px; POSITION: absolute; TOP: 104px"
				runat="server" ErrorMessage="Value?" ControlToValidate="txtBaseHourRate" MaximumValue="999999" MinimumValue="0"
				Type="Double"></asp:RangeValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator4" style="Z-INDEX: 115; LEFT: 360px; POSITION: absolute; TOP: 136px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtID"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator3" style="Z-INDEX: 114; LEFT: 360px; POSITION: absolute; TOP: 104px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtBaseHourRate"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" style="Z-INDEX: 113; LEFT: 360px; POSITION: absolute; TOP: 72px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" style="Z-INDEX: 112; LEFT: 360px; POSITION: absolute; TOP: 40px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
			<asp:Label id="lblDuplicateIDError" style="Z-INDEX: 111; LEFT: 152px; POSITION: absolute; TOP: 200px"
				runat="server" ForeColor="Red" Visible="False">WorkerID already exist!</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 109; LEFT: 32px; POSITION: absolute; TOP: 136px" runat="server">Worker ID:</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 108; LEFT: 8px; POSITION: absolute; TOP: 104px" runat="server">Base hour rate:</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 107; LEFT: 40px; POSITION: absolute; TOP: 72px" runat="server">Last name:</asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 106; LEFT: 40px; POSITION: absolute; TOP: 40px" runat="server">First name:</asp:Label>
			<asp:TextBox id="txtID" style="Z-INDEX: 105; LEFT: 152px; POSITION: absolute; TOP: 136px" runat="server"
				tabIndex="4"></asp:TextBox>
			<asp:TextBox id="txtBaseHourRate" style="Z-INDEX: 104; LEFT: 152px; POSITION: absolute; TOP: 104px"
				runat="server" tabIndex="3"></asp:TextBox>
			<asp:TextBox id="txtLastName" style="Z-INDEX: 103; LEFT: 152px; POSITION: absolute; TOP: 72px"
				runat="server" tabIndex="2"></asp:TextBox>
			<asp:TextBox id="txtFirstName" style="Z-INDEX: 102; LEFT: 152px; POSITION: absolute; TOP: 40px"
				runat="server" tabIndex="1"></asp:TextBox>
			<asp:Button id="btnAddNew" style="Z-INDEX: 101; LEFT: 152px; POSITION: absolute; TOP: 168px"
				runat="server" Text="Add new worker" tabIndex="5"></asp:Button>
		</form>
	</body>
</HTML>
