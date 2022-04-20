<%@ Page language="c#" Codebehind="fBuy.aspx.cs" AutoEventWireup="false" Inherits="marko.fBuy" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fBuy</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK REL="stylesheet" TYPE="text/css" HREF="style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="dgUser" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 88px" runat="server"
				AutoGenerateColumns="False" Width="176px">
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="fldKey" HeaderText="fldKey"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="fldPrise" HeaderText="fldPrise"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldName" HeaderText="Product"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldCount" HeaderText="Count"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
			<asp:Label id="Label6" style="Z-INDEX: 116; LEFT: 416px; POSITION: absolute; TOP: 64px" runat="server"
				Width="89px">:מספר הזמנה</asp:Label>
			<asp:Button id="btnReturn" style="Z-INDEX: 115; LEFT: 208px; POSITION: absolute; TOP: 224px"
				runat="server" Width="136px" Visible="False" Text="חזרה" tabIndex="6"></asp:Button>
			<asp:Label id="lblMessage" style="Z-INDEX: 114; LEFT: 104px; POSITION: absolute; TOP: 24px"
				runat="server" Width="305px">מלאו את הפרטים הבאים ולחצו על בצע</asp:Label>
			<asp:Button id="btnOK" style="Z-INDEX: 113; LEFT: 208px; POSITION: absolute; TOP: 192px" runat="server"
				Width="64px" Text="בצע" tabIndex="4"></asp:Button>
			<asp:Button id="btnCancel" style="Z-INDEX: 112; LEFT: 280px; POSITION: absolute; TOP: 192px"
				runat="server" Width="64px" Text="ביטול" tabIndex="5"></asp:Button>
			<asp:Label id="Label5" style="Z-INDEX: 111; LEFT: 416px; POSITION: absolute; TOP: 160px" runat="server"
				Width="72px">:טלפון</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 110; LEFT: 416px; POSITION: absolute; TOP: 128px" runat="server"
				Width="104px">:כתובת משלוח</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 108; LEFT: 416px; POSITION: absolute; TOP: 96px" runat="server"
				Width="80px">:שם המזמין</asp:Label>
			<asp:TextBox id="txtPhone" style="Z-INDEX: 107; LEFT: 208px; POSITION: absolute; TOP: 160px"
				runat="server" Width="200px" tabIndex="3"></asp:TextBox>
			<asp:TextBox id="txtAddress" style="Z-INDEX: 106; LEFT: 208px; POSITION: absolute; TOP: 128px"
				runat="server" Width="200px" tabIndex="2"></asp:TextBox>
			<asp:Label id="lblOrderNumber" style="Z-INDEX: 105; LEFT: 208px; POSITION: absolute; TOP: 64px"
				runat="server" Width="200px" BorderStyle="Solid" BorderWidth="1px">orderNumber</asp:Label>
			<asp:TextBox id="txtName" style="Z-INDEX: 104; LEFT: 208px; POSITION: absolute; TOP: 96px" runat="server"
				Width="200px" tabIndex="1"></asp:TextBox>
			<asp:Label id="Label3" style="Z-INDEX: 103; LEFT: 64px; POSITION: absolute; TOP: 64px" runat="server">nis</asp:Label>
			<asp:Label id="lblSum" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 64px" runat="server"
				Width="40px">0</asp:Label>
		</form>
	</body>
</HTML>
