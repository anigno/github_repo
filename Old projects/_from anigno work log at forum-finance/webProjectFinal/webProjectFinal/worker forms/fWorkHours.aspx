<%@ Page language="c#" Codebehind="fWorkHours.aspx.cs" AutoEventWireup="false" Inherits="webProjectFinal.worker_forms.fWorkHours" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fWorkHours</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Language" content="en-us">
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 256px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Work hours managment</asp:label>
			<asp:Label id="lblUpdate" style="Z-INDEX: 113; LEFT: 264px; POSITION: absolute; TOP: 352px"
				runat="server" Visible="False" ForeColor="#8080FF">Update?</asp:Label><asp:requiredfieldvalidator id="RequiredFieldValidator1" style="Z-INDEX: 112; LEFT: 320px; POSITION: absolute; TOP: 312px"
				runat="server" ControlToValidate="lstIds" ErrorMessage="Select ID!"></asp:requiredfieldvalidator><asp:rangevalidator id="RangeValidator1" style="Z-INDEX: 111; LEFT: 224px; POSITION: absolute; TOP: 312px"
				runat="server" ControlToValidate="txtWorkHours" ErrorMessage="Value?" MinimumValue="0" MaximumValue="24" Type="Double"></asp:rangevalidator><asp:calendar id="Calendar1" style="Z-INDEX: 110; LEFT: 136px; POSITION: absolute; TOP: 96px"
				runat="server" Visible="False" FirstDayOfWeek="Sunday">
				<DayStyle Font-Names="Aharoni"></DayStyle>
				<DayHeaderStyle Font-Names="Aharoni"></DayHeaderStyle>
				<OtherMonthDayStyle Font-Size="Smaller"></OtherMonthDayStyle>
			</asp:calendar><asp:button id="btnDate" style="Z-INDEX: 109; LEFT: 136px; POSITION: absolute; TOP: 72px" tabIndex="2"
				runat="server" Width="176px" Text="1/1/1"></asp:button><asp:button id="btnAddUpdate" style="Z-INDEX: 108; LEFT: 136px; POSITION: absolute; TOP: 352px"
				tabIndex="4" runat="server" Width="120px" Text="Add/Update"></asp:button><asp:label id="Label4" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 312px" runat="server">Work hours:</asp:label><asp:label id="Label3" style="Z-INDEX: 106; LEFT: 80px; POSITION: absolute; TOP: 72px" runat="server">Date:</asp:label><asp:label id="Label2" style="Z-INDEX: 105; LEFT: 24px; POSITION: absolute; TOP: 40px" runat="server">worker ID:</asp:label><asp:textbox id="txtWorkHours" style="Z-INDEX: 104; LEFT: 136px; POSITION: absolute; TOP: 312px"
				tabIndex="3" runat="server" Width="80px" TextMode="MultiLine" Rows="1"></asp:textbox><asp:textbox id="txtID" style="Z-INDEX: 103; LEFT: 136px; POSITION: absolute; TOP: 40px" tabIndex="1"
				runat="server" Width="176px" Enabled="False"></asp:textbox><asp:listbox id="lstIds" style="Z-INDEX: 102; LEFT: 320px; POSITION: absolute; TOP: 40px" tabIndex="5"
				runat="server" Width="160px" Height="272px" AutoPostBack="True"></asp:listbox></form>
	</body>
</HTML>
