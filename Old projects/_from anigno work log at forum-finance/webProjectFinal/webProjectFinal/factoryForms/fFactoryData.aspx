<%@ Page language="c#" Codebehind="fFactoryData.aspx.cs" AutoEventWireup="false" Inherits="webProjectFinal.fFactoryData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fFactoryData</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="../style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 208px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Factory data</asp:Label>
			<asp:Label id="lblStages" style="Z-INDEX: 148; LEFT: 304px; POSITION: absolute; TOP: 280px"
				runat="server" Width="72px" ForeColor="Red" Visible="False">Stages?</asp:Label>
			<asp:RangeValidator id="RangeValidator9" style="Z-INDEX: 147; LEFT: 400px; POSITION: absolute; TOP: 240px"
				runat="server" ErrorMessage="Value?" ControlToValidate="txtSocialSecurityTax" MinimumValue="0" MaximumValue="100"
				Type="Double"></asp:RangeValidator>
			<asp:RangeValidator id="RangeValidator8" style="Z-INDEX: 146; LEFT: 400px; POSITION: absolute; TOP: 208px"
				runat="server" ErrorMessage="Value?" ControlToValidate="txtExtraTimeFactor" MinimumValue="100" MaximumValue="1000"
				Type="Double"></asp:RangeValidator>
			<asp:RangeValidator id="RangeValidator7" style="Z-INDEX: 145; LEFT: 400px; POSITION: absolute; TOP: 176px"
				runat="server" ErrorMessage="Value?" ControlToValidate="txtBaseWorkdayHours" MinimumValue="0" MaximumValue="24"
				Type="Double"></asp:RangeValidator>
			<asp:RangeValidator id="RangeValidator6" style="Z-INDEX: 144; LEFT: 496px; POSITION: absolute; TOP: 136px"
				runat="server" ErrorMessage="Value?" ControlToValidate="txtTax2" MinimumValue="0" MaximumValue="100"
				Type="Double"></asp:RangeValidator>
			<asp:RangeValidator id="RangeValidator5" style="Z-INDEX: 143; LEFT: 496px; POSITION: absolute; TOP: 104px"
				runat="server" ErrorMessage="Value?" ControlToValidate="txtTax1" MinimumValue="0" MaximumValue="100"
				Type="Double"></asp:RangeValidator>
			<asp:RangeValidator id="RangeValidator4" style="Z-INDEX: 142; LEFT: 496px; POSITION: absolute; TOP: 72px"
				runat="server" ErrorMessage="Value?" ControlToValidate="txtTax0" MinimumValue="0" MaximumValue="100"
				Type="Double"></asp:RangeValidator>
			<asp:RangeValidator id="RangeValidator3" style="Z-INDEX: 141; LEFT: 424px; POSITION: absolute; TOP: 136px"
				runat="server" ErrorMessage="Value?" ControlToValidate="txtStage2" MinimumValue="0" MaximumValue="999999"
				Type="Double"></asp:RangeValidator>
			<asp:RangeValidator id="RangeValidator2" style="Z-INDEX: 140; LEFT: 424px; POSITION: absolute; TOP: 104px"
				runat="server" ErrorMessage="Value?" ControlToValidate="txtStage1" MinimumValue="0" MaximumValue="999999"
				Type="Double"></asp:RangeValidator>
			<asp:RangeValidator id="RangeValidator1" style="Z-INDEX: 139; LEFT: 424px; POSITION: absolute; TOP: 72px"
				runat="server" ErrorMessage="Value?" ControlToValidate="txtStage0" MinimumValue="0" MaximumValue="999999"
				Type="Double"></asp:RangeValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator11" style="Z-INDEX: 138; LEFT: 328px; POSITION: absolute; TOP: 240px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtSocialSecurityTax"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator10" style="Z-INDEX: 137; LEFT: 328px; POSITION: absolute; TOP: 208px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtExtraTimeFactor"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator9" style="Z-INDEX: 136; LEFT: 328px; POSITION: absolute; TOP: 176px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtBaseWorkdayHours"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator8" style="Z-INDEX: 130; LEFT: 352px; POSITION: absolute; TOP: 104px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtTax1"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator7" style="Z-INDEX: 128; LEFT: 352px; POSITION: absolute; TOP: 136px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtTax2"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator6" style="Z-INDEX: 135; LEFT: 280px; POSITION: absolute; TOP: 72px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtStage0"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator5" style="Z-INDEX: 134; LEFT: 280px; POSITION: absolute; TOP: 104px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtStage1"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator4" style="Z-INDEX: 133; LEFT: 280px; POSITION: absolute; TOP: 136px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtStage2"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator3" style="Z-INDEX: 132; LEFT: 352px; POSITION: absolute; TOP: 72px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtTax0"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" style="Z-INDEX: 131; LEFT: 352px; POSITION: absolute; TOP: 104px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtTax1"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" style="Z-INDEX: 129; LEFT: 352px; POSITION: absolute; TOP: 136px"
				runat="server" ErrorMessage="Empty!" ControlToValidate="txtTax2"></asp:RequiredFieldValidator>
			<asp:TextBox id="txtTax0" style="Z-INDEX: 127; LEFT: 200px; POSITION: absolute; TOP: 72px" runat="server"
				Width="72px" tabIndex="2"></asp:TextBox>
			<asp:TextBox id="TextBox11" style="Z-INDEX: 119; LEFT: 120px; POSITION: absolute; TOP: 104px"
				runat="server" Width="72px"></asp:TextBox>
			<asp:TextBox id="TextBox10" style="Z-INDEX: 118; LEFT: 120px; POSITION: absolute; TOP: 72px"
				runat="server" Width="72px"></asp:TextBox>
			<asp:TextBox id="txtTax1" style="Z-INDEX: 126; LEFT: 200px; POSITION: absolute; TOP: 104px" runat="server"
				Width="72px" tabIndex="4"></asp:TextBox>
			<asp:TextBox id="TextBox8" style="Z-INDEX: 121; LEFT: 120px; POSITION: absolute; TOP: 104px"
				runat="server" Width="72px"></asp:TextBox>
			<asp:TextBox id="txtStage0" style="Z-INDEX: 120; LEFT: 120px; POSITION: absolute; TOP: 72px"
				runat="server" Width="72px" tabIndex="1"></asp:TextBox>
			<asp:TextBox id="txtTax2" style="Z-INDEX: 125; LEFT: 200px; POSITION: absolute; TOP: 136px" runat="server"
				Width="72px" tabIndex="6"></asp:TextBox>
			<asp:TextBox id="TextBox5" style="Z-INDEX: 122; LEFT: 120px; POSITION: absolute; TOP: 104px"
				runat="server" Width="72px"></asp:TextBox>
			<asp:TextBox id="TextBox4" style="Z-INDEX: 117; LEFT: 120px; POSITION: absolute; TOP: 72px" runat="server"
				Width="72px"></asp:TextBox>
			<asp:TextBox id="txtStage2" style="Z-INDEX: 124; LEFT: 120px; POSITION: absolute; TOP: 136px"
				runat="server" Width="72px" tabIndex="5"></asp:TextBox>
			<asp:TextBox id="txtStage1" style="Z-INDEX: 123; LEFT: 120px; POSITION: absolute; TOP: 104px"
				runat="server" Width="72px" tabIndex="3"></asp:TextBox>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 116; LEFT: 120px; POSITION: absolute; TOP: 72px" runat="server"
				Width="72px"></asp:TextBox>
			<asp:Label id="Label12" style="Z-INDEX: 115; LEFT: 40px; POSITION: absolute; TOP: 136px" runat="server">Stage 2:</asp:Label>
			<asp:Label id="Label11" style="Z-INDEX: 114; LEFT: 40px; POSITION: absolute; TOP: 104px" runat="server">Stage 1:</asp:Label>
			<asp:Label id="Label10" style="Z-INDEX: 113; LEFT: 40px; POSITION: absolute; TOP: 72px" runat="server">Stage 0:</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 112; LEFT: 304px; POSITION: absolute; TOP: 208px" runat="server">%</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 111; LEFT: 208px; POSITION: absolute; TOP: 48px" runat="server">Tax %</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 110; LEFT: 128px; POSITION: absolute; TOP: 48px" runat="server">Salary</asp:Label>
			<asp:Label id="Label8" style="Z-INDEX: 109; LEFT: 304px; POSITION: absolute; TOP: 240px" runat="server">%</asp:Label>
			<asp:Button id="btnUpdate" style="Z-INDEX: 108; LEFT: 176px; POSITION: absolute; TOP: 280px"
				runat="server" Text="Update" tabIndex="9" Width="120px"></asp:Button>
			<asp:TextBox id="txtSocialSecurityTax" style="Z-INDEX: 107; LEFT: 232px; POSITION: absolute; TOP: 240px"
				runat="server" Width="64px" tabIndex="9"></asp:TextBox>
			<asp:TextBox id="txtExtraTimeFactor" style="Z-INDEX: 106; LEFT: 232px; POSITION: absolute; TOP: 208px"
				runat="server" Width="64px" tabIndex="8"></asp:TextBox>
			<asp:TextBox id="txtBaseWorkdayHours" style="Z-INDEX: 105; LEFT: 232px; POSITION: absolute; TOP: 176px"
				runat="server" Width="88px" tabIndex="7"></asp:TextBox>
			<asp:Label id="Label7" style="Z-INDEX: 104; LEFT: 48px; POSITION: absolute; TOP: 240px" runat="server">Social security tax:</asp:Label>
			<asp:Label id="Label6" style="Z-INDEX: 103; LEFT: 62px; POSITION: absolute; TOP: 208px" runat="server">Extra time factor:</asp:Label>
			<asp:Label id="Label5" style="Z-INDEX: 102; LEFT: 26px; POSITION: absolute; TOP: 176px" runat="server">Base workday hours:</asp:Label>
		</form>
	</body>
</HTML>
