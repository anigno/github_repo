<%@ Page language="c#" Codebehind="adminBusiness.aspx.cs" AutoEventWireup="false" Inherits="business.admin.adminBusiness" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminBusiness</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Admin Business</asp:label><asp:button id="btnRemoveBusiness" style="Z-INDEX: 106; LEFT: 200px; POSITION: absolute; TOP: 96px"
				runat="server" CausesValidation="False" Text="Remove business" Width="136px"></asp:button><asp:panel id="pnlAddNewBusiness" style="Z-INDEX: 105; LEFT: 352px; POSITION: absolute; TOP: 64px"
				runat="server" Width="232px" Visible="False" Height="112px">
				<P>Add new business</P>
				<P>
					<asp:TextBox id="txtWebName" runat="server" Height="24px" Rows="4" TextMode="MultiLine"></asp:TextBox>
					<asp:Button id="btnAddNewBusiness" runat="server" Width="144px" Text="Add new Business"></asp:Button>&nbsp;
					<asp:Button id="btnCancel" runat="server" Width="64px" Text="Cancel" CausesValidation="False"></asp:Button>
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="56px" ControlToValidate="txtWebName"
						ErrorMessage="Empty!"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtWebName" ErrorMessage="Letters and numbers only"
						ValidationExpression="[_0-9a-zA-Z]*"></asp:RegularExpressionValidator></P>
			</asp:panel><asp:button id="ntnNewBusiness" style="Z-INDEX: 104; LEFT: 200px; POSITION: absolute; TOP: 64px"
				runat="server" CausesValidation="False" Text="New business" Width="136px"></asp:button><asp:label id="Label2" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server">Businesses list:</asp:label><asp:listbox id="lstBusinesses" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 64px"
				runat="server" Width="184px" Height="336px" AutoPostBack="True"></asp:listbox><asp:panel id="pnlRemoveBusiness" style="Z-INDEX: 107; LEFT: 352px; POSITION: absolute; TOP: 184px"
				runat="server" Width="384px" Visible="False" Height="56px">
				<P>Sure you want to remove selected business?</P>
				<P>
					<asp:Button id="btnConfirmRemoveBusiness" runat="server" Width="64px" Text="Yes"></asp:Button>&nbsp;
					<asp:Button id="btnCancelRemoveBusiness" runat="server" Width="64px" Text="Cancel" CausesValidation="False"></asp:Button></P>
			</asp:panel>
			<P><asp:label id="lblMessage" style="Z-INDEX: 108; LEFT: 200px; POSITION: absolute; TOP: 32px"
					runat="server" Width="376px"></asp:label><asp:button id="btnEditBusiness" style="Z-INDEX: 109; LEFT: 200px; POSITION: absolute; TOP: 128px"
					runat="server" CausesValidation="False" Text="Edit business" Width="136px"></asp:button></P>
		</form>
	</body>
</HTML>
