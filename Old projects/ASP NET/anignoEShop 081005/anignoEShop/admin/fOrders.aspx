<%@ Register TagPrefix="miu" Namespace="MarkItUp.WebControls" Assembly="MarkItUp.WebControls.Timer" %>
<%@ Page language="c#" Codebehind="fOrders.aspx.cs" AutoEventWireup="false" Inherits="anignoEShop.admin.fOrders" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fOrders</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK REL="stylesheet" TYPE="text/css" HREF="..\style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 16px" runat="server"
				Height="32px">Orders:</asp:Label>
			<asp:Label id="Label6" style="Z-INDEX: 114; LEFT: 144px; POSITION: absolute; TOP: 120px" runat="server"
				Width="72px">Phone:</asp:Label>
			<asp:Label id="Label5" style="Z-INDEX: 113; LEFT: 144px; POSITION: absolute; TOP: 96px" runat="server"
				Width="72px">Address:</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 112; LEFT: 144px; POSITION: absolute; TOP: 72px" runat="server"
				Width="72px">Name:</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 111; LEFT: 144px; POSITION: absolute; TOP: 48px" runat="server"
				Width="72px">Date:</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 110; LEFT: 296px; POSITION: absolute; TOP: 152px" runat="server"
				Width="56px">Total:</asp:Label>
			<asp:Label id="lblSum" style="Z-INDEX: 109; LEFT: 352px; POSITION: absolute; TOP: 152px" runat="server"
				Width="64px">Sum</asp:Label>
			<asp:CheckBox id="chkReady" style="Z-INDEX: 108; LEFT: 144px; POSITION: absolute; TOP: 152px"
				runat="server" Text="Order ready:" AutoPostBack="True" TextAlign="Left"></asp:CheckBox>
			<asp:Label id="lblOrderPhone" style="Z-INDEX: 107; LEFT: 224px; POSITION: absolute; TOP: 120px"
				runat="server" Width="360px">Phone</asp:Label>
			<asp:Label id="lblOrderAddress" style="Z-INDEX: 106; LEFT: 224px; POSITION: absolute; TOP: 96px"
				runat="server" Width="360px">Address</asp:Label>
			<asp:Label id="lblOrderName" style="Z-INDEX: 105; LEFT: 224px; POSITION: absolute; TOP: 72px"
				runat="server" Width="360px">Name</asp:Label>
			<asp:Label id="lblOrderDate" style="Z-INDEX: 104; LEFT: 224px; POSITION: absolute; TOP: 48px"
				runat="server" Width="360px">Date</asp:Label>
			<asp:ListBox id="lstOrders" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 40px" runat="server"
				Width="120px" Height="272px" AutoPostBack="True"></asp:ListBox><miu:timer id="tmrRefresh" runat="server" MaxTicks="20"></miu:timer>
			<asp:DataGrid id="dgProductsOrder" style="Z-INDEX: 103; LEFT: 144px; POSITION: absolute; TOP: 176px"
				runat="server" Width="368px" Height="16px" AutoGenerateColumns="False">
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="fldOrderNumber"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldProductName" HeaderText="Product"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldProductCount" HeaderText="Count"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldProductPrise" HeaderText="prise"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid></form>
	</body>
</HTML>
