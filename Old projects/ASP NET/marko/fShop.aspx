<%@ Page language="c#" Codebehind="fShop.aspx.cs" AutoEventWireup="false" Inherits="marko.fShop" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fShop</title>
		<meta name="vs_showGrid" content="True">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK REL="stylesheet" TYPE="text/css" HREF="style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label4" style="Z-INDEX: 104; LEFT: 72px; POSITION: absolute; TOP: 176px" runat="server">סל הזמנות</asp:label>
			<asp:Button id="btnBuy" style="Z-INDEX: 111; LEFT: 152px; POSITION: absolute; TOP: 192px" runat="server"
				Text="בצע הזמנה" Width="97px"></asp:Button>
			<asp:Label id="Label3" style="Z-INDEX: 110; LEFT: 40px; POSITION: absolute; TOP: 200px" runat="server">ש"ח</asp:Label>
			<asp:Label id="lblSum" style="Z-INDEX: 109; LEFT: 80px; POSITION: absolute; TOP: 200px" runat="server"
				Width="40px">0</asp:Label>
			<asp:label id="lblProducts" style="Z-INDEX: 103; LEFT: 320px; POSITION: absolute; TOP: 16px"
				runat="server">קבוצה</asp:label><asp:label id="Label2" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 16px" runat="server">?מה תרצו לאכול</asp:label>
			<asp:ListBox id="lstSubjects" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 40px"
				runat="server" Width="176px" Height="120px" AutoPostBack="True"></asp:ListBox>
			<asp:Image id="imgSubject" style="Z-INDEX: 106; LEFT: 192px; POSITION: absolute; TOP: 64px"
				runat="server" Height="96px" Width="96px"></asp:Image>
			<asp:DataGrid id="dgProducts" style="Z-INDEX: 107; LEFT: 304px; POSITION: absolute; TOP: 40px"
				runat="server" Width="256px" Height="74px" AutoGenerateColumns="False">
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="fldKey" HeaderText="Key"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldName" HeaderText="תאור"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldPrise" HeaderText="מחיר יחידה"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<IMG src='<%=imagesPath+"\\"%><%# DataBinder.Eval(Container.DataItem, "fldImage") %>' width=80>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
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
					<asp:ButtonColumn Text="הוספה" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
				</Columns>
			</asp:DataGrid>
			<asp:DataGrid id="dgBasket" style="Z-INDEX: 108; LEFT: 8px; POSITION: absolute; TOP: 224px" runat="server"
				Width="232px" Height="16px" AutoGenerateColumns="False">
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="fldBasketKey" HeaderText="fldBasketKey"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="fldKey" HeaderText="fldKey"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldName" HeaderText="תאור"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldCount" HeaderText="כמות"></asp:BoundColumn>
					<asp:ButtonColumn Text="Remove" ButtonType="PushButton"></asp:ButtonColumn>
					<asp:BoundColumn Visible="False" DataField="fldPrise" HeaderText="fldPrise"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
