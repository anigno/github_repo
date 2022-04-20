<%@ Page language="c#" Codebehind="fUserData.aspx.cs" AutoEventWireup="false" Inherits="anignoEShop.user.fUserData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fUserData</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK REL="stylesheet" TYPE="text/css" HREF="..\style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblBasket" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 16px" runat="server"
				Width="56px">Basket:</asp:Label>
			<asp:Button id="btnReturn" style="Z-INDEX: 128; LEFT: 496px; POSITION: absolute; TOP: 320px"
				runat="server" Visible="False" Width="168px" Text="Return" CausesValidation="False"></asp:Button>
			<asp:Button id="btnCancel" style="Z-INDEX: 127; LEFT: 592px; POSITION: absolute; TOP: 280px"
				runat="server" Width="72px" Text="Cancel" CausesValidation="False"></asp:Button>
			<asp:RegularExpressionValidator id="RegularExpressionValidator3" style="Z-INDEX: 126; LEFT: 720px; POSITION: absolute; TOP: 112px"
				runat="server" ErrorMessage="!" ControlToValidate="txtPhone" ValidationExpression="[0-9-]{7,20}"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator2" style="Z-INDEX: 125; LEFT: 720px; POSITION: absolute; TOP: 208px"
				runat="server" Visible="False" ErrorMessage="!" ControlToValidate="txtId" ValidationExpression="[0-9]{9}"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 124; LEFT: 720px; POSITION: absolute; TOP: 176px"
				runat="server" Visible="False" ErrorMessage="!" ControlToValidate="txtCreditCardNumber" ValidationExpression="[0-9]{16}"></asp:RegularExpressionValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator6" style="Z-INDEX: 123; LEFT: 704px; POSITION: absolute; TOP: 208px"
				runat="server" Visible="False" ErrorMessage="!" ControlToValidate="txtId"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator5" style="Z-INDEX: 122; LEFT: 704px; POSITION: absolute; TOP: 176px"
				runat="server" Visible="False" ErrorMessage="!" ControlToValidate="txtCreditCardNumber"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator3" style="Z-INDEX: 121; LEFT: 704px; POSITION: absolute; TOP: 112px"
				runat="server" ErrorMessage="!" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" style="Z-INDEX: 120; LEFT: 704px; POSITION: absolute; TOP: 80px"
				runat="server" ErrorMessage="!" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" style="Z-INDEX: 119; LEFT: 704px; POSITION: absolute; TOP: 48px"
				runat="server" ErrorMessage="!" ControlToValidate="txtName"></asp:RequiredFieldValidator>
			<asp:DropDownList id="ddlCardExDate" style="Z-INDEX: 118; LEFT: 496px; POSITION: absolute; TOP: 240px"
				runat="server" Visible="False" Width="200px"></asp:DropDownList>
			<asp:DropDownList id="ddlCardType" style="Z-INDEX: 117; LEFT: 496px; POSITION: absolute; TOP: 144px"
				runat="server" Visible="False" Width="200px">
				<asp:ListItem Value="Visa" Selected="True">Visa</asp:ListItem>
				<asp:ListItem Value="Isracard">Isracard</asp:ListItem>
				<asp:ListItem Value="LeumiCard">LeumiCard</asp:ListItem>
				<asp:ListItem Value="DynersCard">DynersCard</asp:ListItem>
			</asp:DropDownList>
			<asp:Label id="Label8" style="Z-INDEX: 116; LEFT: 368px; POSITION: absolute; TOP: 144px" runat="server"
				Visible="False" Width="120px" Height="16px">Card type:</asp:Label>
			<asp:TextBox id="txtId" style="Z-INDEX: 115; LEFT: 496px; POSITION: absolute; TOP: 208px" runat="server"
				Visible="False" Width="200px"></asp:TextBox>
			<asp:TextBox id="txtCreditCardNumber" style="Z-INDEX: 114; LEFT: 496px; POSITION: absolute; TOP: 176px"
				runat="server" Visible="False" Width="200px"></asp:TextBox>
			<asp:Label id="Label7" style="Z-INDEX: 113; LEFT: 368px; POSITION: absolute; TOP: 240px" runat="server"
				Visible="False" Width="120px" Height="16px">Card Ex date:</asp:Label>
			<asp:Label id="Label6" style="Z-INDEX: 112; LEFT: 368px; POSITION: absolute; TOP: 176px" runat="server"
				Visible="False" Width="120px" Height="16px">Card number:</asp:Label>
			<asp:Label id="Label5" style="Z-INDEX: 111; LEFT: 368px; POSITION: absolute; TOP: 208px" runat="server"
				Visible="False" Width="120px" Height="16px">Id:</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 110; LEFT: 368px; POSITION: absolute; TOP: 112px" runat="server"
				Width="120px" Height="16px">Phone:</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 109; LEFT: 368px; POSITION: absolute; TOP: 80px" runat="server"
				Width="120px" Height="16px">Address:</asp:Label>
			<asp:TextBox id="txtPhone" style="Z-INDEX: 108; LEFT: 496px; POSITION: absolute; TOP: 112px"
				runat="server" Width="200px"></asp:TextBox>
			<asp:TextBox id="txtAddress" style="Z-INDEX: 107; LEFT: 496px; POSITION: absolute; TOP: 80px"
				runat="server" Width="200px"></asp:TextBox>
			<asp:Label id="Label2" style="Z-INDEX: 104; LEFT: 368px; POSITION: absolute; TOP: 48px" runat="server"
				Width="120px" Height="16px">Name:</asp:Label>
			<asp:TextBox id="txtName" style="Z-INDEX: 106; LEFT: 496px; POSITION: absolute; TOP: 48px" runat="server"
				Width="200px"></asp:TextBox>
			<asp:Button id="btnExecute" style="Z-INDEX: 103; LEFT: 496px; POSITION: absolute; TOP: 280px"
				runat="server" Width="72px" Text="Execute"></asp:Button>
			<asp:Label id="lblSum" style="Z-INDEX: 101; LEFT: 96px; POSITION: absolute; TOP: 16px" runat="server"
				Width="56px">0</asp:Label>
			<asp:DataGrid id="dgBasket" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 40px" runat="server"
				Width="264px" AutoGenerateColumns="False" Height="8px">
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="fldBasketKey" HeaderText="fldBasketKey"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="fldKey" HeaderText="fldKey"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldName" HeaderText="תאור"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldCount" HeaderText="כמות"></asp:BoundColumn>
					<asp:ButtonColumn Visible="False" Text="Remove" CommandName="remove"></asp:ButtonColumn>
					<asp:BoundColumn Visible="False" DataField="fldPrise" HeaderText="fldPrise"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
			<asp:Label id="Label1" style="Z-INDEX: 105; LEFT: 368px; POSITION: absolute; TOP: 48px" runat="server"
				Width="120px" Height="16px">Name:</asp:Label>
		</form>
	</body>
</HTML>
