<%@ Page language="c#" Codebehind="adminEditBusiness.aspx.cs" AutoEventWireup="false" Inherits="business.admin.adminEditBusiness" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminEditBusiness</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="btnUpdate" style="Z-INDEX: 121; LEFT: 136px; POSITION: absolute; TOP: 536px"
				runat="server" Text="Update data" tabIndex="20" Width="104px"></asp:Button>
			<asp:Label id="Label15" style="Z-INDEX: 137; LEFT: 144px; POSITION: absolute; TOP: 8px" runat="server">webName:</asp:Label>
			<asp:Label id="Label14" style="Z-INDEX: 136; LEFT: 584px; POSITION: absolute; TOP: 40px" runat="server">Subjects:</asp:Label>
			<asp:ListBox id="lstSubjects" style="Z-INDEX: 135; LEFT: 584px; POSITION: absolute; TOP: 64px"
				runat="server" Width="144px" Height="200px"></asp:ListBox>
			<asp:Button id="btnEditSubjects" style="Z-INDEX: 134; LEFT: 256px; POSITION: absolute; TOP: 536px"
				runat="server" Text="Edit subjects -->" Width="144px"></asp:Button>
			<asp:Image id="imgLogo" style="Z-INDEX: 133; LEFT: 448px; POSITION: absolute; TOP: 168px" runat="server"
				Width="105px" Height="100px"></asp:Image>
			<asp:Button id="btnUploadLogo" style="Z-INDEX: 132; LEFT: 264px; POSITION: absolute; TOP: 208px"
				runat="server" Text="Upload Logo picture" Width="177px" CausesValidation="False"></asp:Button><INPUT id="FileLogo" style="Z-INDEX: 131; LEFT: 136px; POSITION: absolute; TOP: 176px"
				type="file" name="FileLogo" runat="server">
			<asp:Label id="Label13" style="Z-INDEX: 130; LEFT: 40px; POSITION: absolute; TOP: 184px" runat="server">Logo picture:</asp:Label>
			<asp:Label id="lblWebName" style="Z-INDEX: 129; LEFT: 216px; POSITION: absolute; TOP: 8px"
				runat="server" Width="176px"></asp:Label>
			<asp:RegularExpressionValidator id="RegularExpressionValidator2" style="Z-INDEX: 128; LEFT: 144px; POSITION: absolute; TOP: 264px"
				runat="server" ValidationExpression='[, ".:!0-9a-zA-Zà-ú]*' ErrorMessage="Letters and numbers only" ControlToValidate="txtName"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 127; LEFT: 608px; POSITION: absolute; TOP: 344px"
				runat="server" ValidationExpression="[^'<>]*" ErrorMessage="All but ' < >" ControlToValidate="txtAbout"></asp:RegularExpressionValidator>
			<asp:Button id="btnCancel" style="Z-INDEX: 126; LEFT: 16px; POSITION: absolute; TOP: 536px"
				runat="server" Text="<-- Return" CausesValidation="False" Width="104px"></asp:Button>
			<asp:Label id="Label1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Admin edit business</asp:Label>
			<asp:Label id="lblMessage" style="Z-INDEX: 125; LEFT: 136px; POSITION: absolute; TOP: 32px"
				runat="server" Width="416px"></asp:Label>
			<asp:Button id="btnUploadMain" style="Z-INDEX: 124; LEFT: 264px; POSITION: absolute; TOP: 96px"
				runat="server" Text="Upload main picture" Width="177px" CausesValidation="False"></asp:Button>
			<asp:Label id="Label11" style="Z-INDEX: 123; LEFT: 40px; POSITION: absolute; TOP: 64px" runat="server">Main picture:</asp:Label>
			<asp:Label id="Label10" style="Z-INDEX: 120; LEFT: 88px; POSITION: absolute; TOP: 504px" runat="server">Email:</asp:Label>
			<asp:TextBox id="txtEmail" style="Z-INDEX: 119; LEFT: 136px; POSITION: absolute; TOP: 504px"
				runat="server"></asp:TextBox><INPUT id="File1" style="Z-INDEX: 118; LEFT: 136px; POSITION: absolute; TOP: 64px" type="file"
				name="File1" runat="server">
			<asp:Label id="Label9" style="Z-INDEX: 117; LEFT: 48px; POSITION: absolute; TOP: 472px" runat="server">Fax number:</asp:Label>
			<asp:Label id="Label8" style="Z-INDEX: 116; LEFT: 16px; POSITION: absolute; TOP: 440px" runat="server"
				Width="104px">Cellolar number:</asp:Label>
			<asp:Label id="Label7" style="Z-INDEX: 115; LEFT: 24px; POSITION: absolute; TOP: 408px" runat="server">Phone number:</asp:Label>
			<asp:Label id="Label6" style="Z-INDEX: 114; LEFT: 368px; POSITION: absolute; TOP: 344px" runat="server">About:</asp:Label>
			<asp:TextBox id="txtAbout" style="Z-INDEX: 113; LEFT: 368px; POSITION: absolute; TOP: 368px"
				runat="server" Width="360px" Height="160px" TextMode="MultiLine"></asp:TextBox>
			<asp:Image id="Image1" style="Z-INDEX: 112; LEFT: 448px; POSITION: absolute; TOP: 56px" runat="server"
				Width="105px" Height="100px"></asp:Image>
			<asp:DropDownList id="drpRegion" style="Z-INDEX: 111; LEFT: 136px; POSITION: absolute; TOP: 376px"
				runat="server"></asp:DropDownList>
			<asp:TextBox id="txtFaxNumber" style="Z-INDEX: 110; LEFT: 136px; POSITION: absolute; TOP: 472px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="txtCellolarNumber" style="Z-INDEX: 109; LEFT: 136px; POSITION: absolute; TOP: 440px"
				runat="server"></asp:TextBox>
			<asp:Label id="Label5" style="Z-INDEX: 108; LEFT: 72px; POSITION: absolute; TOP: 376px" runat="server">Region:</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 107; LEFT: 96px; POSITION: absolute; TOP: 344px" runat="server">City:</asp:Label>
			<asp:TextBox id="txtPhoneNumber" style="Z-INDEX: 106; LEFT: 136px; POSITION: absolute; TOP: 408px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="txtCity" style="Z-INDEX: 105; LEFT: 136px; POSITION: absolute; TOP: 344px" runat="server"></asp:TextBox>
			<asp:TextBox id="txtAddress" style="Z-INDEX: 104; LEFT: 136px; POSITION: absolute; TOP: 312px"
				runat="server" Width="432px"></asp:TextBox>
			<asp:Label id="Label3" style="Z-INDEX: 103; LEFT: 64px; POSITION: absolute; TOP: 312px" runat="server">Address:</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 280px" runat="server"> Business name:</asp:Label>
			<asp:TextBox id="txtName" style="Z-INDEX: 101; LEFT: 136px; POSITION: absolute; TOP: 280px" runat="server"
				Width="432px"></asp:TextBox>
		</form>
	</body>
</HTML>
