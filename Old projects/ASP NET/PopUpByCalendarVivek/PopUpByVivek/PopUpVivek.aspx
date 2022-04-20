<%@ Page language="c#" Codebehind="PopUpVivek.aspx.cs" AutoEventWireup="false" Inherits="PopUpByVivek.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Calendar id="CalVivek" nSelectionChanged="Change_Date" runat="server" backcolor="White" width="200px"
				daynameformat="FirstLetter" forecolor="Black" height="180px" font-size="8pt" font-names="Verdana"
				bordercolor="#999999" cellpadding="4" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px">
				<TodayDayStyle Font-Bold="True" BorderColor="LightSalmon" BackColor="#C0C0FF"></TodayDayStyle>
				<SelectorStyle BorderStyle="Inset" BorderColor="#400040" BackColor="Salmon"></SelectorStyle>
				<DayStyle Font-Bold="True" BorderStyle="Ridge" BorderColor="#C04000" BackColor="Gray"></DayStyle>
				<NextPrevStyle Font-Bold="True" BorderStyle="Outset" BorderColor="Yellow" BackColor="#C00000"></NextPrevStyle>
				<DayHeaderStyle Font-Italic="True" Font-Bold="True" BorderStyle="Groove" BorderColor="DarkGray"
					BackColor="#FF8000"></DayHeaderStyle>
				<SelectedDayStyle BorderStyle="Dotted" BorderColor="OliveDrab" BackColor="Desktop"></SelectedDayStyle>
				<TitleStyle Font-Bold="True" ForeColor="Maroon" BorderStyle="Inset" BorderColor="Olive" BackColor="Desktop"></TitleStyle>
				<WeekendDayStyle BorderStyle="Dashed" BorderColor="#80FF80" BackColor="Aqua"></WeekendDayStyle>
				<OtherMonthDayStyle ForeColor="#C0FFC0" BorderStyle="Ridge" BorderColor="Teal" BackColor="DimGray"></OtherMonthDayStyle>
			</asp:Calendar></form>
	</body>
</HTML>
