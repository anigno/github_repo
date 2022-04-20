<%@ Page language="c#" Codebehind="fAdmin.aspx.cs" AutoEventWireup="false" Inherits="marko.fAdmin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fAdmin</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="refresh" content="120">
		<LINK REL="stylesheet" TYPE="text/css" HREF="style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:ListBox id="lstOrders" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 80px" runat="server"
				Width="256px" Height="272px" AutoPostBack="True"></asp:ListBox>
			<asp:DataGrid id="dgProducts" style="Z-INDEX: 104; LEFT: 304px; POSITION: absolute; TOP: 232px"
				runat="server" Width="256px" AutoGenerateColumns="False">
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="fldKey" HeaderText="Key"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldProductName" HeaderText="Product"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldProductCount" HeaderText="Count"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
			<asp:Label id="Label2" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 56px" runat="server">Orders:</asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 16px" runat="server"
				Font-Underline="True">Admin</asp:Label>
			<asp:Panel id="Panel1" style="Z-INDEX: 105; LEFT: 304px; POSITION: absolute; TOP: 80px" runat="server"
				Height="144px" Width="232px" BorderStyle="Solid" BorderWidth="1px">&nbsp;
<asp:Label id="Label4" runat="server" Width="24px">Total:</asp:Label>&nbsp;
<asp:Label id="lblSum" runat="server" Width="40px">0</asp:Label>
<asp:Label id="Label3" runat="server" Width="24px">nis</asp:Label>&nbsp;
<asp:Label id="lblDate" runat="server" Width="256px" BorderWidth="1px" BorderStyle="Solid">Date</asp:Label>&nbsp;
<asp:Label id="lblName" runat="server" Width="256px" BorderWidth="1px" BorderStyle="Solid">Name</asp:Label>&nbsp;
<asp:Label id="lblAddress" runat="server" Width="256px" BorderWidth="1px" BorderStyle="Solid">Address</asp:Label>&nbsp;
<asp:Label id="lblPhone" runat="server" Width="256px" BorderWidth="1px" BorderStyle="Solid">Phone</asp:Label>&nbsp;&nbsp; 
<asp:CheckBox id="chkReady" runat="server" AutoPostBack="True" Text="  הזמנה מוכנה"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			</asp:Panel>
			<asp:Button id="btnRefrash" style="Z-INDEX: 106; LEFT: 168px; POSITION: absolute; TOP: 360px"
				runat="server" Width="104px" Text="רענן רשימה"></asp:Button>
		</form>
	</body>
</HTML>
