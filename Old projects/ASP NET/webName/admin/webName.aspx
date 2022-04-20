<%@ Page language="c#" Codebehind="webName.aspx.cs" AutoEventWireup="false" Inherits="webName.admin.webName" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>webName</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="btnDummie" style="Z-INDEX: 104; LEFT: 512px; POSITION: absolute; TOP: 400px"
				runat="server" Text="_" tabIndex="999" Width="8px" Height="12px"></asp:Button>
			<asp:Button id="btnCreate" style="Z-INDEX: 109; LEFT: 232px; POSITION: absolute; TOP: 392px"
				tabIndex="4" runat="server" Width="200px" Text="Create web site" CausesValidation="False"></asp:Button>
			<asp:Button id="btnEdit" style="Z-INDEX: 108; LEFT: 192px; POSITION: absolute; TOP: 120px" runat="server"
				Width="88px" Text="Edit" CausesValidation="False" tabIndex="4"></asp:Button>
			<asp:Panel id="pnlRemove" style="Z-INDEX: 107; LEFT: 296px; POSITION: absolute; TOP: 160px"
				runat="server" Height="40px" Width="152px" Visible="False">
				<P>Remove selected?
					<asp:Button id="btnRemoveYes" tabIndex="8" runat="server" Width="48px" Text="Yes"></asp:Button>&nbsp;&nbsp;
					<asp:Button id="btnRemoveNo" tabIndex="9" runat="server" Width="48px" Text="No"></asp:Button></P>
			</asp:Panel>
			<asp:Button id="btnRemove" style="Z-INDEX: 106; LEFT: 192px; POSITION: absolute; TOP: 88px"
				runat="server" Text="Remove" CausesValidation="False" tabIndex="3"></asp:Button>
			<asp:ListBox id="lstWebName" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 56px" runat="server"
				Height="368px" Width="176px" tabIndex="1"></asp:ListBox>
			<asp:Panel id="pnlAddNew" style="Z-INDEX: 103; LEFT: 296px; POSITION: absolute; TOP: 56px"
				runat="server" Height="80px" Width="216px" Visible="False">
				<P>Web name:
					<asp:TextBox id="txtAddNew" tabIndex="5" runat="server"></asp:TextBox>
					<asp:Button id="btnAddNew" tabIndex="6" runat="server" Width="88px" Text="Add"></asp:Button>&nbsp;&nbsp;
					<asp:Button id="btnAddCancel" tabIndex="7" runat="server" Width="88px" Text="Cancel" CausesValidation="False"></asp:Button>
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddNew" ErrorMessage="Empty!"></asp:RequiredFieldValidator>&nbsp;&nbsp;
					<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtAddNew" ErrorMessage="WebName error!"
						ValidationExpression="[a-zA-Z_0-9]*"></asp:RegularExpressionValidator></P>
			</asp:Panel>
			<asp:Button id="btnAdd" style="Z-INDEX: 102; LEFT: 192px; POSITION: absolute; TOP: 56px" runat="server"
				Text="Add new" Width="88px" CausesValidation="False" tabIndex="2"></asp:Button>
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 32px" runat="server">Web names:</asp:Label>
			<asp:Label id="lblMessage" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Width="488px"></asp:Label>
		</form>
	</body>
</HTML>
