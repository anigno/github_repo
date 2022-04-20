<%@ Page language="c#" Codebehind="editWebName.aspx.cs" AutoEventWireup="false" Inherits="webName.admin.editWebName" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>editWebName</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:button id="btnDummie" style="Z-INDEX: 133; LEFT: 824px; POSITION: absolute; TOP: 456px"
				runat="server" Width="6px" Text="_" Height="8px"></asp:button>
			<asp:RegularExpressionValidator id="RegularExpressionValidator3" style="Z-INDEX: 138; LEFT: 456px; POSITION: absolute; TOP: 376px"
				runat="server" ErrorMessage="Text!" ControlToValidate="txtSecondText" ValidationExpression="[^<>']*"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator2" style="Z-INDEX: 137; LEFT: 456px; POSITION: absolute; TOP: 272px"
				runat="server" ErrorMessage="Text!" ControlToValidate="txtMainText" ValidationExpression="[^<>']*"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 136; LEFT: 416px; POSITION: absolute; TOP: 32px"
				runat="server" ErrorMessage="Text!" ControlToValidate="txtAbout" ValidationExpression="[^<>']*"></asp:RegularExpressionValidator>
			<asp:label id="Label13" style="Z-INDEX: 135; LEFT: 16px; POSITION: absolute; TOP: 144px" runat="server">Real name:</asp:label>
			<asp:TextBox id="txtRealName" style="Z-INDEX: 134; LEFT: 120px; POSITION: absolute; TOP: 144px"
				runat="server"></asp:TextBox><asp:label id="lblMessage" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Width="528px"></asp:label><asp:button id="btnUploadLogoImage" style="Z-INDEX: 132; LEFT: 776px; POSITION: absolute; TOP: 304px"
				tabIndex="12" runat="server" Width="65px" Text="Upload"></asp:button><asp:button id="btnUploadMainImage" style="Z-INDEX: 131; LEFT: 776px; POSITION: absolute; TOP: 88px"
				tabIndex="11" runat="server" Width="64px" Text="Upload"></asp:button><INPUT id="fileLogoImage" style="Z-INDEX: 128; LEFT: 656px; WIDTH: 184px; POSITION: absolute; TOP: 272px; HEIGHT: 25px"
				type="file" size="11" name="File2" runat="server"><INPUT id="fileMainImage" style="Z-INDEX: 127; LEFT: 656px; WIDTH: 184px; POSITION: absolute; TOP: 56px; HEIGHT: 25px"
				type="file" size="11" name="File1" runat="server">
			<asp:label id="Label12" style="Z-INDEX: 126; LEFT: 656px; POSITION: absolute; TOP: 24px" runat="server">MainImage:</asp:label><asp:label id="Label11" style="Z-INDEX: 125; LEFT: 656px; POSITION: absolute; TOP: 240px" runat="server">LogoImage:</asp:label><asp:button id="btnEditSubjects" style="Z-INDEX: 124; LEFT: 448px; POSITION: absolute; TOP: 504px"
				tabIndex="16" runat="server" Width="112px" Text="Edit subjects >"></asp:button><asp:button id="btnReturn" style="Z-INDEX: 123; LEFT: 256px; POSITION: absolute; TOP: 504px"
				tabIndex="14" runat="server" Width="88px" Text="< Return"></asp:button><asp:button id="btnUpdate" style="Z-INDEX: 122; LEFT: 352px; POSITION: absolute; TOP: 504px"
				tabIndex="15" runat="server" Width="88px" Text="Update"></asp:button><asp:textbox id="txtAbout" style="Z-INDEX: 121; LEFT: 352px; POSITION: absolute; TOP: 56px" tabIndex="8"
				runat="server" Width="288px" TextMode="MultiLine" Height="200px"></asp:textbox><asp:label id="Label10" style="Z-INDEX: 120; LEFT: 352px; POSITION: absolute; TOP: 32px" runat="server">About:</asp:label><asp:textbox id="txtSecondText" style="Z-INDEX: 119; LEFT: 352px; POSITION: absolute; TOP: 400px"
				tabIndex="10" runat="server" Width="288px" TextMode="MultiLine" Height="72px"></asp:textbox><asp:label id="Label9" style="Z-INDEX: 118; LEFT: 352px; POSITION: absolute; TOP: 376px" runat="server">SecondText:</asp:label><asp:textbox id="txtMainText" style="Z-INDEX: 117; LEFT: 352px; POSITION: absolute; TOP: 296px"
				tabIndex="9" runat="server" Width="288px" TextMode="MultiLine" Height="72px"></asp:textbox><asp:textbox id="txtEmail" style="Z-INDEX: 116; LEFT: 120px; POSITION: absolute; TOP: 392px"
				tabIndex="7" runat="server"></asp:textbox><asp:textbox id="txtFax" style="Z-INDEX: 115; LEFT: 120px; POSITION: absolute; TOP: 360px" tabIndex="6"
				runat="server"></asp:textbox><asp:textbox id="txtCellPhone" style="Z-INDEX: 114; LEFT: 120px; POSITION: absolute; TOP: 328px"
				tabIndex="5" runat="server"></asp:textbox><asp:label id="Label8" style="Z-INDEX: 113; LEFT: 72px; POSITION: absolute; TOP: 360px" runat="server">Fax:</asp:label><asp:label id="Label7" style="Z-INDEX: 112; LEFT: 54px; POSITION: absolute; TOP: 392px" runat="server">Email:</asp:label><asp:label id="Label6" style="Z-INDEX: 111; LEFT: 19px; POSITION: absolute; TOP: 328px" runat="server">CellPhone:</asp:label><asp:label id="Label5" style="Z-INDEX: 110; LEFT: 352px; POSITION: absolute; TOP: 272px" runat="server"
				Width="88px">MainText:</asp:label><asp:textbox id="txtPhone" style="Z-INDEX: 109; LEFT: 120px; POSITION: absolute; TOP: 296px"
				tabIndex="4" runat="server"></asp:textbox><asp:label id="Label4" style="Z-INDEX: 108; LEFT: 53px; POSITION: absolute; TOP: 296px" runat="server">Phone:</asp:label><asp:textbox id="txtAddress" style="Z-INDEX: 107; LEFT: 120px; POSITION: absolute; TOP: 184px"
				tabIndex="3" runat="server" TextMode="MultiLine" Height="104px"></asp:textbox><asp:label id="Label3" style="Z-INDEX: 106; LEFT: 32px; POSITION: absolute; TOP: 184px" runat="server">Address:</asp:label><asp:dropdownlist id="drpWebColor" style="Z-INDEX: 105; LEFT: 120px; POSITION: absolute; TOP: 104px"
				tabIndex="2" runat="server"></asp:dropdownlist><asp:label id="Label2" style="Z-INDEX: 104; LEFT: 16px; POSITION: absolute; TOP: 104px" runat="server">Web color:</asp:label><asp:label id="Label1" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 72px" runat="server">Web type:</asp:label><asp:dropdownlist id="drpWebType" style="Z-INDEX: 102; LEFT: 120px; POSITION: absolute; TOP: 72px"
				tabIndex="1" runat="server"></asp:dropdownlist><asp:label id="lblWebName" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server"
				Width="264px"></asp:label><asp:image id="imgMain" style="Z-INDEX: 129; LEFT: 656px; POSITION: absolute; TOP: 88px" runat="server"
				Width="100px" Height="100px"></asp:image>
			<asp:Image id="imgLogo" style="Z-INDEX: 130; LEFT: 656px; POSITION: absolute; TOP: 304px" runat="server"
				Width="100px" Height="100px"></asp:Image></form>
	</body>
</HTML>
