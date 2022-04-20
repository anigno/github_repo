<%@ Page language="c#" Codebehind="fStoreSelect.aspx.cs" AutoEventWireup="false" Inherits="onlineMall.admin.fStoreSelect" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fStoreSelect</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Store select:</asp:Label>
			<asp:Button id="btnRemove" style="Z-INDEX: 105; LEFT: 224px; POSITION: absolute; TOP: 112px"
				runat="server" Width="88px" Text="Remove" Enabled="False"></asp:Button>
			<asp:Button id="btnEdit" style="Z-INDEX: 104; LEFT: 224px; POSITION: absolute; TOP: 80px" runat="server"
				Width="88px" Text="Edit"></asp:Button>
			<asp:Button id="btnAddNew" style="Z-INDEX: 102; LEFT: 224px; POSITION: absolute; TOP: 48px"
				runat="server" Width="88px" Text="Add new"></asp:Button>
			<asp:ListBox id="lstStores" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server"
				Width="200px" Height="256px" AutoPostBack="True"></asp:ListBox>
			<asp:Panel id="panelAddNew" style="Z-INDEX: 106; LEFT: 328px; POSITION: absolute; TOP: 48px"
				runat="server" Width="360px" Height="154px" Visible="False" BorderStyle="Solid">
				<P>Add new store:</P>
				<P>WebName:&nbsp;
					<asp:TextBox id="txtNewWebName" runat="server" Width="224px"></asp:TextBox>
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewWebName" ErrorMessage="*"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtNewWebName"
						ErrorMessage="*" ValidationExpression="[^<>']*"></asp:RegularExpressionValidator></P>
				<P>&nbsp;&nbsp;
					<asp:Button id="btnAddNewOk" runat="server" Text="Ok" Width="64px"></asp:Button>&nbsp;&nbsp;
					<asp:Button id="btnAddNewCancel" runat="server" Text="Cancel" Width="64px" CausesValidation="False"></asp:Button></P>
			</asp:Panel>
			<P>
				<asp:Button id="btnCreateSimpleWeb" style="Z-INDEX: 107; LEFT: 16px; POSITION: absolute; TOP: 320px"
					runat="server" Text="Create simple web" Width="152px"></asp:Button></P>
		</form>
	</body>
</HTML>
