<%@ Page language="c#" Codebehind="fSubjects.aspx.cs" AutoEventWireup="false" Inherits="onlineMall.admin.fSubjects" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fSubjects</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Font-Underline="True">Subjects:</asp:Label>
			<asp:Button id="btnReturn" style="Z-INDEX: 108; LEFT: 8px; POSITION: absolute; TOP: 344px" runat="server"
				Width="80px" Text="Return" CausesValidation="False"></asp:Button>
			<asp:Button id="btnDown" style="Z-INDEX: 107; LEFT: 216px; POSITION: absolute; TOP: 72px" runat="server"
				Width="56px" Text="Down" Enabled="False"></asp:Button>
			<asp:Button id="btnUp" style="Z-INDEX: 106; LEFT: 216px; POSITION: absolute; TOP: 40px" runat="server"
				Width="56px" Text="UP" Enabled="False"></asp:Button>
			<asp:Button id="btnEditProducts" style="Z-INDEX: 105; LEFT: 184px; POSITION: absolute; TOP: 304px"
				runat="server" Width="112px" Text="Edit products" CausesValidation="False"></asp:Button>
			<asp:Button id="btnRemove" style="Z-INDEX: 104; LEFT: 96px; POSITION: absolute; TOP: 304px"
				runat="server" Width="80px" Text="Remove" CausesValidation="False" Enabled="False"></asp:Button>
			<asp:Button id="btnAddNew" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 304px" runat="server"
				Width="80px" Text="Add new" CausesValidation="False"></asp:Button>
			<asp:ListBox id="lstSubjects" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 40px"
				runat="server" Width="200px" Height="256px" AutoPostBack="True"></asp:ListBox>
			<asp:Panel id="panelAddNew" style="Z-INDEX: 109; LEFT: 56px; POSITION: absolute; TOP: 384px"
				runat="server" Width="240px" Height="96px" BorderStyle="Solid" Visible="False">
				<P>
					<asp:Label id="Label5" runat="server">New subject name</asp:Label>&nbsp;
					<asp:TextBox id="txtNewSubject" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtNewSubject"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtNewSubject"
						ValidationExpression="[^<>']*"></asp:RegularExpressionValidator>
					<asp:Button id="btnNewSubjectOK" runat="server" Text="OK" Width="64px"></asp:Button>&nbsp;&nbsp;
					<asp:Button id="btnNewSubjectCancel" runat="server" CausesValidation="False" Text="Cancel" Width="64px"></asp:Button></P>
			</asp:Panel>
			<asp:Panel id="panelImage" style="Z-INDEX: 110; LEFT: 352px; POSITION: absolute; TOP: 336px"
				runat="server" Width="248px" Height="139px" BorderStyle="Solid" Visible="False">Image <INPUT id="fileSubjectImage" style="WIDTH: 184px; HEIGHT: 25px" type="file" size="11" name="File1"
					runat="server"> 
<asp:Image id="imgSubject" runat="server" Width="100px" Height="100px"></asp:Image>
<asp:Button id="btnUploadImage" runat="server" Text="Upload" Width="64px"></asp:Button></asp:Panel>
			<asp:Panel id="panelData" style="Z-INDEX: 111; LEFT: 352px; POSITION: absolute; TOP: 40px"
				runat="server" Width="248px" Height="264px" BorderStyle="Solid" Visible="False">
				<P>
					<asp:Label id="Label2" runat="server" Width="224px">Name</asp:Label>
					<asp:TextBox id="txtName" runat="server"></asp:TextBox>
					<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtName"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtName"
						ValidationExpression="[^<>']*"></asp:RegularExpressionValidator></P>
				<P>
					<asp:Label id="Label3" runat="server" Width="232px">Description</asp:Label>
					<asp:TextBox id="txtDescription" runat="server" Height="72px" TextMode="MultiLine"></asp:TextBox>
					<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtDescription"
						ValidationExpression="[^<>']*"></asp:RegularExpressionValidator></P>
				<P>
					<asp:CheckBox id="chkShow" runat="server" Text="Show" TextAlign="Left"></asp:CheckBox></P>
				<P>&nbsp;&nbsp;
					<asp:Button id="btnUpdate" runat="server" Text="Update" Width="64px"></asp:Button></P>
			</asp:Panel>
			<asp:Label id="lblMessage" style="Z-INDEX: 112; LEFT: 192px; POSITION: absolute; TOP: 8px"
				runat="server" Width="440px"></asp:Label>
		</form>
	</body>
</HTML>
