<%@ Page language="c#" Codebehind="editSubjects.aspx.cs" AutoEventWireup="false" Inherits="webName.admin.editSubjects" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>editSubjects</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="btnDummie" style="Z-INDEX: 112; LEFT: 600px; POSITION: absolute; TOP: 416px"
				runat="server" Height="8px" Width="6px" Text="_"></asp:Button>
			<asp:ListBox id="lstSubjects" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 96px"
				runat="server" Width="264px" Height="344px" AutoPostBack="True" tabIndex="1"></asp:ListBox>
			<asp:Button id="btnRemove" style="Z-INDEX: 108; LEFT: 280px; POSITION: absolute; TOP: 128px"
				runat="server" Width="104px" Text="Remove" CausesValidation="False" tabIndex="3"></asp:Button>
			<asp:Panel id="panelAddNew" style="Z-INDEX: 107; LEFT: 392px; POSITION: absolute; TOP: 96px"
				runat="server" Width="184px" Height="144px" Visible="False">
				<P>Add new Subject</P>
				<P>
					<asp:TextBox id="txtNewSubject" tabIndex="5" runat="server"></asp:TextBox>
					<asp:Button id="btnAddNewSubject" tabIndex="6" runat="server" Width="80px" Text="Add new"></asp:Button>
					<asp:Button id="btnCancelAddNewSubject" tabIndex="7" runat="server" CausesValidation="False"
						Text="Cancel"></asp:Button>
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewSubject" ErrorMessage="Empty!"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtNewSubject"
						ErrorMessage="WebName error!" ValidationExpression="[^'<>]*"></asp:RegularExpressionValidator></P>
			</asp:Panel>
			<asp:Button id="btnAdd" style="Z-INDEX: 106; LEFT: 280px; POSITION: absolute; TOP: 96px" runat="server"
				Width="104px" Text="Add subject" CausesValidation="False" tabIndex="2"></asp:Button>
			<asp:Label id="Label2" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 72px" runat="server">Subjects:</asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server">webName:</asp:Label>
			<asp:Label id="lblMessage" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Width="568px"></asp:Label>
			<asp:Label id="lblWebName" style="Z-INDEX: 102; LEFT: 112px; POSITION: absolute; TOP: 40px"
				runat="server" Width="216px"></asp:Label>
			<asp:Panel id="pnlRemove" style="Z-INDEX: 109; LEFT: 392px; POSITION: absolute; TOP: 240px"
				runat="server" Width="224px" Height="24px" Visible="False">
				<P>Remove selected subject?</P>
				<P>
					<asp:Button id="btnRemoveYes" tabIndex="8" runat="server" Width="40px" CausesValidation="False"
						Text="Yes"></asp:Button>
					<asp:Button id="btnRemoveNo" tabIndex="9" runat="server" Width="40px" CausesValidation="False"
						Text="No"></asp:Button></P>
			</asp:Panel>
			<P>
				<asp:Button id="btnEdit" style="Z-INDEX: 110; LEFT: 280px; POSITION: absolute; TOP: 160px" runat="server"
					Width="104px" Text="Edit subject" CausesValidation="False" tabIndex="4"></asp:Button>
				<asp:Button id="btnReturn" style="Z-INDEX: 111; LEFT: 16px; POSITION: absolute; TOP: 440px"
					runat="server" Width="104px" Text="< Return" CausesValidation="False"></asp:Button>
			</P>
		</form>
	</body>
</HTML>
