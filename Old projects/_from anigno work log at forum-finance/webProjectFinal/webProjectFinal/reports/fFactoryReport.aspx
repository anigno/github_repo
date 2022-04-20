<%@ Page language="c#" Codebehind="fFactoryReport.aspx.cs" AutoEventWireup="false" Inherits="webProjectFinal.fFactoryReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fFactoryReport</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:dropdownlist id="drpMonth" style="Z-INDEX: 101; LEFT: 144px; POSITION: absolute; TOP: 80px" runat="server"
				Width="40px"></asp:dropdownlist><asp:listbox id="lstGeneralData" style="Z-INDEX: 108; LEFT: 224px; POSITION: absolute; TOP: 48px"
				runat="server" Width="256px" Height="120px"></asp:listbox><asp:datagrid id="DataGrid1" style="Z-INDEX: 107; LEFT: 0px; POSITION: absolute; TOP: 176px" runat="server"
				Width="472px" Height="72px" Font-Size="X-Small" AllowPaging="True" PageSize="20">
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
			</asp:datagrid><asp:button id="btnCreate" style="Z-INDEX: 106; LEFT: 32px; POSITION: absolute; TOP: 136px"
				runat="server" Width="184px" Text="Create report"></asp:button><asp:label id="Label3" style="Z-INDEX: 105; LEFT: 144px; POSITION: absolute; TOP: 48px" runat="server">Month:</asp:label><asp:label id="Label2" style="Z-INDEX: 104; LEFT: 272px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Factory report</asp:label><asp:label id="Label1" style="Z-INDEX: 103; LEFT: 40px; POSITION: absolute; TOP: 48px" runat="server">Year:</asp:label><asp:dropdownlist id="drpYear" style="Z-INDEX: 102; LEFT: 40px; POSITION: absolute; TOP: 80px" runat="server"></asp:dropdownlist></form>
	</body>
</HTML>
