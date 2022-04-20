<%@ Page language="c#" Codebehind="fShop.aspx.cs" AutoEventWireup="false" Inherits="anignoEShop.user.fShop" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="vs_showGrid" content="True">
		<title>fShop</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK REL="stylesheet" TYPE="text/css" HREF="..\style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 16px" runat="server">List of subjects:</asp:label><asp:label id="Label7" style="Z-INDEX: 104; LEFT: 296px; POSITION: absolute; TOP: 16px" runat="server">Products:</asp:label><asp:datagrid id="dgProducts" style="Z-INDEX: 103; LEFT: 296px; POSITION: absolute; TOP: 40px"
				runat="server" AutoGenerateColumns="False" Height="48px" Width="424px">
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="fldKey" HeaderText="key"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="fldSubjectKey" HeaderText="subjectKey"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldName" HeaderText="Product">
						<HeaderStyle Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="fldPrise" HeaderText="Prise"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="image">
						<ItemTemplate>
							<IMG src='<%=anignoEShop.classes.cUtil.UPLOAD_PATH_HTML+"/"%><%# DataBinder.Eval(Container.DataItem, "fldImage") %>' height=30>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="count">
						<ItemTemplate>
							<asp:DropDownList id="ddlCount" runat="server">
								<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
								<asp:ListItem Value="2">2</asp:ListItem>
								<asp:ListItem Value="3">3</asp:ListItem>
								<asp:ListItem Value="4">4</asp:ListItem>
								<asp:ListItem Value="5">5</asp:ListItem>
								<asp:ListItem Value="6">6</asp:ListItem>
								<asp:ListItem Value="7">7</asp:ListItem>
								<asp:ListItem Value="8">8</asp:ListItem>
								<asp:ListItem Value="9">9</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
							</asp:DropDownList>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:ButtonColumn Text="Add" CommandName="add"></asp:ButtonColumn>
				</Columns>
			</asp:datagrid><asp:listbox id="lstSubjects" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 40px"
				runat="server" Height="216px" Width="264px" AutoPostBack="True"></asp:listbox>
			<asp:DataGrid id="dgBasket" style="Z-INDEX: 105; LEFT: 16px; POSITION: absolute; TOP: 296px" runat="server"
				Width="264px" Height="8px" AutoGenerateColumns="False" Visible="False">
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="fldBasketKey" HeaderText="fldBasketKey"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="fldKey" HeaderText="fldKey"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldName" HeaderText="Product"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldCount" HeaderText="Count"></asp:BoundColumn>
					<asp:ButtonColumn Text="Remove" CommandName="remove"></asp:ButtonColumn>
					<asp:BoundColumn Visible="False" DataField="fldPrise" HeaderText="fldPrise"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
			<asp:Button id="btnBuy" style="Z-INDEX: 106; LEFT: 208px; POSITION: absolute; TOP: 264px" runat="server"
				Width="72px" Visible="False" Text="Buy"></asp:Button>
			<asp:Label id="lblBasket" style="Z-INDEX: 107; LEFT: 16px; POSITION: absolute; TOP: 272px"
				runat="server" Width="56px" Visible="False">Basket:</asp:Label>
			<asp:Label id="lblSum" style="Z-INDEX: 108; LEFT: 96px; POSITION: absolute; TOP: 272px" runat="server"
				Width="56px" Visible="False">0</asp:Label></form>
	</body>
</HTML>
