<%@ Page language="c#" Codebehind="fProducts.aspx.cs" AutoEventWireup="false" Inherits="onlineMall.admin.fProducts" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fProducts</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Products:</asp:Label>
			<asp:Label id="lblMessage" style="Z-INDEX: 110; LEFT: 160px; POSITION: absolute; TOP: 8px"
				runat="server" Width="448px"></asp:Label>
			<asp:Panel id="panelAddNew" style="Z-INDEX: 109; LEFT: 24px; POSITION: absolute; TOP: 384px"
				runat="server" Width="248px" Height="96px" BorderStyle="Solid" Visible="False">
				<P>
					<asp:Label id="Label5" runat="server">New Product name</asp:Label>
					<asp:TextBox id="txtNewName" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewName" ErrorMessage="*"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ControlToValidate="txtNewName" ErrorMessage="*"
						ValidationExpression="[^<>']*"></asp:RegularExpressionValidator>
					<asp:Button id="btnNewSubjectOK" runat="server" Width="64px" Text="OK"></asp:Button>&nbsp;&nbsp;
					<asp:Button id="btnNewSubjectCancel" runat="server" Width="64px" Text="Cancel" CausesValidation="False"></asp:Button></P>
			</asp:Panel>
			<asp:Button id="btnDown" style="Z-INDEX: 108; LEFT: 216px; POSITION: absolute; TOP: 72px" runat="server"
				Enabled="False" Text="Down" Width="56px"></asp:Button>
			<asp:Button id="btnUp" style="Z-INDEX: 107; LEFT: 216px; POSITION: absolute; TOP: 40px" runat="server"
				Enabled="False" Text="UP" Width="56px"></asp:Button>
			<asp:Panel id="panelImage" style="Z-INDEX: 106; LEFT: 280px; POSITION: absolute; TOP: 384px"
				runat="server" Width="248px" Height="139px" BorderStyle="Solid" Visible="False">Image <INPUT id="fileProductImage" style="WIDTH: 184px; HEIGHT: 25px" type="file" size="11" name="File1"
					runat="server"> 
<asp:Image id="imgProduct" runat="server" Height="100px" Width="100px"></asp:Image>
<asp:Button id="btnUploadImage" runat="server" Width="64px" Text="Upload"></asp:Button></asp:Panel>
			<asp:Panel id="panelData" style="Z-INDEX: 105; LEFT: 280px; POSITION: absolute; TOP: 32px"
				runat="server" Width="248px" Height="264px" BorderStyle="Solid" Visible="False">
				<P>
					<asp:Label id="Label2" runat="server" Width="224px">Name</asp:Label>
					<asp:TextBox id="txtName" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="*"
						ValidationExpression="[^<>']*"></asp:RegularExpressionValidator></P>
				<P>
					<asp:Label id="Label3" runat="server" Width="232px">Description</asp:Label>
					<asp:TextBox id="txtDescription" runat="server" Height="72px" TextMode="MultiLine"></asp:TextBox>
					<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ControlToValidate="txtDescription"
						ErrorMessage="*" ValidationExpression="[^<>']*"></asp:RegularExpressionValidator></P>
				<P>
					<asp:Label id="Label4" runat="server" Width="224px">Prise</asp:Label>
					<asp:TextBox id="txtPrise" runat="server"></asp:TextBox>
					<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrise" ErrorMessage="*"
						ValidationExpression="[0-9.]*"></asp:RegularExpressionValidator></P>
				<P>
					<asp:CheckBox id="chkShow" runat="server" Text="Show" TextAlign="Left"></asp:CheckBox></P>
				<P>&nbsp;&nbsp;
					<asp:Button id="btnUpdate" runat="server" Width="64px" Text="Update"></asp:Button></P>
			</asp:Panel>
			<asp:Button id="btnRemove" style="Z-INDEX: 104; LEFT: 96px; POSITION: absolute; TOP: 304px"
				runat="server" Width="80px" Text="Remove" CausesValidation="False"></asp:Button>
			<asp:Button id="btnReturn" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 344px" runat="server"
				Width="80px" Text="Return" CausesValidation="False"></asp:Button>
			<asp:Button id="btnAddNew" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 304px" runat="server"
				Width="80px" Text="Add new"></asp:Button>
			<asp:ListBox id="lstProducts" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 40px"
				runat="server" Height="256px" AutoPostBack="True" Width="200px"></asp:ListBox>
			<asp:Panel id="panelRemove" style="Z-INDEX: 111; LEFT: 312px; POSITION: absolute; TOP: 200px"
				runat="server" Visible="False" BorderStyle="Solid" Height="56px" Width="224px">Remove selected Product?
<asp:Button id="btnRemoveOK" runat="server" Width="40px" Text="Yes"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnRemoveNo" runat="server" Width="40px" Text="No"></asp:Button></asp:Panel>
		</form>
	</body>
</HTML>
