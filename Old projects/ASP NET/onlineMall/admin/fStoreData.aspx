<%@ Page language="c#" Codebehind="fStoreData.aspx.cs" AutoEventWireup="false" Inherits="onlineMall.admin.fStoreData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fStoreData</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="btnDummie" style="Z-INDEX: 124; LEFT: 720px; POSITION: absolute; TOP: 504px"
				runat="server" Height="20px" Width="24px"></asp:Button>
			<asp:TextBox id="txtHeader" style="Z-INDEX: 138; LEFT: 128px; POSITION: absolute; TOP: 472px"
				tabIndex="5" runat="server"></asp:TextBox>
			<asp:Label id="Label10" style="Z-INDEX: 137; LEFT: 16px; POSITION: absolute; TOP: 472px" runat="server">Header</asp:Label>
			<asp:Label id="Label9" style="Z-INDEX: 136; LEFT: 16px; POSITION: absolute; TOP: 392px" runat="server">Description</asp:Label>
			<asp:TextBox id="txtDescription" style="Z-INDEX: 135; LEFT: 128px; POSITION: absolute; TOP: 392px"
				tabIndex="7" runat="server" Width="296px" Height="72px" TextMode="MultiLine"></asp:TextBox>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" style="Z-INDEX: 134; LEFT: 368px; POSITION: absolute; TOP: 40px"
				runat="server" ErrorMessage="*" ControlToValidate="txtWebName"></asp:RequiredFieldValidator>
			<asp:Label id="lblMesage" style="Z-INDEX: 133; LEFT: 216px; POSITION: absolute; TOP: 8px" runat="server"
				Width="384px"></asp:Label>
			<asp:RegularExpressionValidator id="RegularExpressionValidator8" style="Z-INDEX: 132; LEFT: 408px; POSITION: absolute; TOP: 320px"
				runat="server" ValidationExpression="[^<>']*" ControlToValidate="txtAbout" ErrorMessage="*"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator7" style="Z-INDEX: 131; LEFT: 360px; POSITION: absolute; TOP: 240px"
				runat="server" ValidationExpression="[^<>']*" ControlToValidate="txtAddress" ErrorMessage="*"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator6" style="Z-INDEX: 130; LEFT: 352px; POSITION: absolute; TOP: 208px"
				runat="server" ValidationExpression="[^<>']*" ControlToValidate="txtEmail" ErrorMessage="*"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator5" style="Z-INDEX: 129; LEFT: 352px; POSITION: absolute; TOP: 176px"
				runat="server" ValidationExpression="[^<>']*" ControlToValidate="txtFax" ErrorMessage="*"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator4" style="Z-INDEX: 128; LEFT: 352px; POSITION: absolute; TOP: 144px"
				runat="server" ValidationExpression="[^<>']*" ControlToValidate="txtCellPhone" ErrorMessage="*"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator3" style="Z-INDEX: 127; LEFT: 352px; POSITION: absolute; TOP: 112px"
				runat="server" ValidationExpression="[^<>']*" ControlToValidate="txtPhone" ErrorMessage="*"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator2" style="Z-INDEX: 126; LEFT: 352px; POSITION: absolute; TOP: 40px"
				runat="server" ValidationExpression="[^<>']*" ControlToValidate="txtWebName" ErrorMessage="*"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 125; LEFT: 352px; POSITION: absolute; TOP: 72px"
				runat="server" ValidationExpression="[^<>']*" ControlToValidate="txtName" ErrorMessage="*"></asp:RegularExpressionValidator>
			<asp:Label id="Label1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Store data:</asp:Label>
			<asp:Button id="btnEditSubjects" style="Z-INDEX: 123; LEFT: 256px; POSITION: absolute; TOP: 504px"
				runat="server" Width="112px" Text="Edit subjects"></asp:Button>
			<asp:Button id="btnReturn" style="Z-INDEX: 122; LEFT: 72px; POSITION: absolute; TOP: 504px"
				runat="server" Width="72px" Text="Return" CausesValidation="False"></asp:Button>
			<asp:Button id="btnUpdate" style="Z-INDEX: 121; LEFT: 152px; POSITION: absolute; TOP: 504px"
				runat="server" Width="96px" Text="Update" Font-Bold="True" tabIndex="8"></asp:Button>
			<asp:Panel id="Panel1" style="Z-INDEX: 118; LEFT: 448px; POSITION: absolute; TOP: 336px" runat="server"
				Height="104px" Width="304px" BorderStyle="Solid">
				<P>Main image <INPUT id="fileMainImage" style="WIDTH: 184px; HEIGHT: 25px" type="file" size="11" name="File1"
						runat="server">
					<asp:Image id="imgMain" runat="server" Width="100px" Height="100px"></asp:Image>
					<asp:Button id="btnUploadMainImage" runat="server" Width="64px" Text="Upload" CausesValidation="False"></asp:Button></P>
			</asp:Panel>
			<asp:TextBox id="txtAbout" style="Z-INDEX: 117; LEFT: 128px; POSITION: absolute; TOP: 312px"
				runat="server" TextMode="MultiLine" Height="73px" Width="296px" tabIndex="7"></asp:TextBox>
			<asp:Label id="Label11" style="Z-INDEX: 116; LEFT: 16px; POSITION: absolute; TOP: 312px" runat="server">About</asp:Label>
			<asp:Label id="Label8" style="Z-INDEX: 115; LEFT: 16px; POSITION: absolute; TOP: 200px" runat="server">Email</asp:Label>
			<asp:TextBox id="txtEmail" style="Z-INDEX: 113; LEFT: 144px; POSITION: absolute; TOP: 200px"
				runat="server" tabIndex="5"></asp:TextBox>
			<asp:TextBox id="txtFax" style="Z-INDEX: 112; LEFT: 144px; POSITION: absolute; TOP: 168px" runat="server"
				tabIndex="4"></asp:TextBox>
			<asp:Label id="Label7" style="Z-INDEX: 111; LEFT: 16px; POSITION: absolute; TOP: 168px" runat="server">Fax</asp:Label>
			<asp:TextBox id="txtAddress" style="Z-INDEX: 110; LEFT: 128px; POSITION: absolute; TOP: 232px"
				runat="server" TextMode="MultiLine" Height="72px" Width="296px" tabIndex="6"></asp:TextBox>
			<asp:Label id="Label6" style="Z-INDEX: 109; LEFT: 16px; POSITION: absolute; TOP: 232px" runat="server">Address</asp:Label>
			<asp:TextBox id="txtCellPhone" style="Z-INDEX: 108; LEFT: 144px; POSITION: absolute; TOP: 136px"
				runat="server"></asp:TextBox>
			<asp:Label id="Label5" style="Z-INDEX: 107; LEFT: 16px; POSITION: absolute; TOP: 136px" runat="server">Cell phone</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 106; LEFT: 16px; POSITION: absolute; TOP: 104px" runat="server">Phone</asp:Label>
			<asp:TextBox id="txtPhone" style="Z-INDEX: 105; LEFT: 144px; POSITION: absolute; TOP: 104px"
				runat="server" tabIndex="3"></asp:TextBox>
			<asp:TextBox id="txtName" style="Z-INDEX: 104; LEFT: 144px; POSITION: absolute; TOP: 72px" runat="server"
				tabIndex="2"></asp:TextBox>
			<asp:Label id="Label3" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 72px" runat="server">Name</asp:Label>
			<asp:TextBox id="txtWebName" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 40px"
				runat="server" tabIndex="1"></asp:TextBox>
			<asp:Label id="Label2" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 40px" runat="server">Web name</asp:Label>
			<asp:Panel id="Panel2" style="Z-INDEX: 119; LEFT: 448px; POSITION: absolute; TOP: 48px" runat="server"
				Height="139px" Width="304px" BorderStyle="Solid">Logo image&nbsp; <INPUT id="fileLogoImage" style="WIDTH: 184px; HEIGHT: 25px" type="file" size="11" name="File1"
					runat="server"> 
<asp:Image id="imgLogo" runat="server" Width="100px" Height="100px"></asp:Image>
<asp:Button id="btnUploadLogoImage" runat="server" Width="64px" Text="Upload" CausesValidation="False"></asp:Button></asp:Panel>
			<asp:Panel id="Panel3" style="Z-INDEX: 120; LEFT: 448px; POSITION: absolute; TOP: 192px" runat="server"
				Height="112px" Width="304px" BorderStyle="Solid">About image <INPUT id="fileAboutImage" style="WIDTH: 184px; HEIGHT: 25px" type="file" size="11" name="File1"
					runat="server"> 
<asp:Image id="imgAbout" runat="server" Width="100px" Height="100px"></asp:Image>
<asp:Button id="btnUploadAboutImage" runat="server" Width="64px" Text="Upload" CausesValidation="False"></asp:Button></asp:Panel>
		</form>
	</body>
</HTML>
